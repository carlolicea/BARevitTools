using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is used by the Create Material Symbols tool. It will take the rows of the DataGridView and make symbol family types for each row,
    //group them by ID Use, sort by Mark, then place them in a drafting view
    class MaterialsCMSRequest
    {
        public MaterialsCMSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            ProgressBar progressBar = uiForm.materialsCMSExcelCreateSymbolsProgressBar;
            DataGridView dgv = uiForm.materialsCMSExcelDataGridView;
            int rowsCount = dgv.Rows.Count;
            int columnsCount = dgv.Columns.Count;
            List<string> familyTypesMade = new List<string>();

            //Prepare the progress bar. The column count is one less because the first column is the column for family type names
            progressBar.Minimum = 0;
            progressBar.Maximum = (rowsCount) * (columnsCount - 1);
            progressBar.Step = 1;
            progressBar.Visible = true;

            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Reset the progress bar
            uiForm.materialsCMSExcelCreateSymbolsProgressBar.Value = 0;

            //First, try to use the family from the project. If that fails, use the family file
            Family familyToUse = RVTGetElementsByCollection.FamilyByFamilyName(uiApp,Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));            
            
            //Assuming nothing went to hell in the process of loading one famiy...
            if (familyToUse!= null)
            {
                //Save out the family to use
                RVTDocument tempFamDoc = doc.EditFamily(familyToUse);
                RVTOperations.SaveRevitFile(uiApp, tempFamDoc, @"C:\Temp\" + Path.GetFileName(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule), true);

                //Open the family to use and get its FamilyManager
                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, @"C:\Temp\" + Path.GetFileName(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));
                FamilyManager famMan = famDoc.FamilyManager;

                //Get the parameters from the Family Manager and add them to a dictionary
                FamilyParameterSet parameters = famMan.Parameters;
                Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
                foreach (FamilyParameter param in parameters)
                {
                    famParamDict.Add(param.Definition.Name, param);
                }

                //Start a new transaction to make the new family types in the family to use
                using (Transaction t1 = new Transaction(famDoc, "MakeNewTypes"))
                {
                    t1.Start();
                    //Cycle through the rows in the dgv
                    for (int i = 0; i < rowsCount; i++)
                    {
                        //The first column cell will be the type name
                        string newTypeName = dgv.Rows[i].Cells[0].Value.ToString();
                        //Get the family type names in the family
                        Dictionary<string, FamilyType> existingTypeNames = RVTOperations.GetFamilyTypeNames(famMan);
                        //If the family to make from the DGV does not exist in the dictionary keys...
                        if (!existingTypeNames.Keys.Contains(newTypeName))
                        {
                            //Make the family type and add it to the list of types made
                            FamilyType newType = famMan.NewType(newTypeName);
                            famMan.CurrentType = newType;
                            familyTypesMade.Add(newType.Name);
                        }
                        else
                        {
                            //If the type exists, set the current type it from the dictionary and add it to the list of types made
                            famMan.CurrentType = existingTypeNames[newTypeName];
                            familyTypesMade.Add(famMan.CurrentType.Name);
                        }

                        //Next, evaluate the columns that contain parameters
                        for (int j = 1; j < columnsCount; j++)
                        {
                            //The parameter names will be retrieved from the column HeaderText property
                            string paramName = dgv.Columns[j].HeaderText;
                            //Meanwhile the parameter value will come from the DGV cells
                            var paramValue = dgv.Rows[i].Cells[j].Value;

                            try
                            {
                                //If the parameter dictionary contains the parameter and the value to assign it is not empty, continue.
                                if (paramValue.ToString() != "" && famParamDict.Keys.Contains(paramName))
                                {
                                    //Get the family parameter and check if it is locked by a formula
                                    FamilyParameter param = famParamDict[paramName];
                                    if (!param.IsDeterminedByFormula)
                                    {
                                        //If it is not locked by a formula, set the parameter
                                        ParameterType paramType = param.Definition.ParameterType;
                                        RVTOperations.SetFamilyParameterValue(famMan, param, paramValue);
                                    }
                                }
                            }
                            catch
                            {; }
                            finally
                            {
                                //Always perform the step to indicate the progress.
                                progressBar.PerformStep();
                            }
                        }
                    }
                    t1.Commit();
                }

                //Use another transaction to delete the types that were not needed
                using (Transaction t2 = new Transaction(famDoc, "DeleteOldTypes"))
                {                    
                    t2.Start();
                    //Cycle through the family types and determine if it is in the list of types made
                    foreach (FamilyType type in famMan.Types)
                    {
                        if (!familyTypesMade.Contains(type.Name))
                        {
                            //If the type is not in the list of types made, delete it from the family file
                            famMan.CurrentType = type;
                            famMan.DeleteCurrentType();
                        }
                    }
                    t2.Commit();
                }                

                //Save the family document at this point as all of the types and their parameters have been set
                famDoc.Close(true);                

                using (Transaction t3 = new Transaction(doc, "LoadFamily"))
                {
                    t3.Start();
                    doc.LoadFamily(@"C:\Temp\" + Path.GetFileName(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule), new RVTFamilyLoadOptions(), out Family loadedFamily);
                    t3.Commit();
                } 

                //Get the drafting view type in the project for BA Drafting View, else just get the first drafting view type
                ViewDrafting placementView = null;
                var draftingViews = new FilteredElementCollector(doc).OfClass(typeof(ViewDrafting)).WhereElementIsNotElementType().ToElements();
                ViewFamilyType draftingViewType = null;
                try
                {
                    //From the view family types collection, get the first one where its name is BA Drafting View
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().Where(elem => elem.Name == "BA Drafting View").First() as ViewFamilyType;
                }
                catch
                {
                    //Well, crap. It doesn't exist. Just get the first type then and call it good.
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().First() as ViewFamilyType;
                }

                //Start a transaction for making the ID Material View and placing the family symbol types
                using (Transaction t4 = new Transaction(doc, "MakeIDMaterialView"))
                {
                    t4.Start();
                    foreach (ViewDrafting view in draftingViews)
                    {
                        //Find the view named ID Material View, or whatever jibberish someone typed in the CMS text box for the name to use. in the drafting views
                        if (view.Name == "ID Material View" || view.Name == uiForm.materialsCMSSetViewNameTextBox.Text)
                        {
                            //Delete the drafting view
                            doc.Delete(view.Id);
                            doc.Regenerate();
                            break;
                        }
                        else { continue; }
                    }

                    //Make a new view
                    placementView = ViewDrafting.Create(doc, draftingViewType.Id);
                    placementView.Scale = 1;
                    if (uiForm.materialsCMSSetViewNameTextBox.Text != "")
                    {
                        //If someone defined a custom view name, use that and strip out brackets if they exist
                        placementView.Name = uiForm.materialsCMSSetViewNameTextBox.Text.Replace("{", "").Replace("}", "");
                    }
                    else
                    {
                        //Otherwise, this will be the new ID Material View
                        placementView.Name = "ID Material View";
                    }

                    try
                    {
                        //Set the view sort parameters if they exist
                        placementView.GetParameters(Properties.Settings.Default.BAViewSort1).First().Set("2 Plans");
                        placementView.GetParameters(Properties.Settings.Default.BAViewSort2).First().Set("230 Finish Plans");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    doc.Regenerate();
                    t4.Commit();
                }
                    

                //Do magic to place each symbol in its view by calling the method below in this class
                PlaceSymbolsInView(uiApp, "ID Use", "Mark", placementView);

                //Clean up the files from the operations
                GeneralOperations.CleanRfaBackups(GeneralOperations.GetAllRvtBackupFamilies(@"C:\Temp\", false));
                File.Delete(@"C:\Temp\" + Path.GetFileName(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));
                Application.thisApp.newMainUi.materialsCMSFamilyToUse = RVTGetElementsByCollection.FamilyByFamilyName(uiApp, Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));
            }
            else
            {
                //If the family could not be found, well, let the user know of this.
                MessageBox.Show(String.Format("The {0} family could not be found in the project.", 
                    Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule)));
            }
        }

        //This method is to be used with the above constructor. It is private because it is not needed outside of this tool's use
        private static void PlaceSymbolsInView(UIApplication uiApp, string groupingParameter, string subgroupingParameter, Autodesk.Revit.DB.View placementView)
        {
            try
            {                
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                //Start a transaction
                Transaction t = new Transaction(doc, "LoadMaterialSymbolsFamily");
                t.Start();  

                //Get the family loaded into the project by its name, then close the family document in the background
                Family refFamily = RVTGetElementsByCollection.FamilyByFamilyName(uiApp, Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));

                //Add each family symbol (type) to a list of symbols and a dictionary of grouping values indexed by symbol
                Dictionary<Element, string> familyTypesDict = new Dictionary<Element, string>();
                List<Element> familyTypesList = new List<Element>();                
                foreach (ElementId symbId in refFamily.GetFamilySymbolIds())
                {
                    FamilySymbol familySymbol = doc.GetElement(symbId) as FamilySymbol;
                    string paramValue = familySymbol.GetParameters(groupingParameter).First().AsString();
                    familyTypesList.Add(familySymbol);
                    familyTypesDict.Add(familySymbol, paramValue);
                }
                //Next, use Linq to group the family types by ID Use, then sort each group by Mark
                var familyTypesGroupedQuery =
                     from elemSymbol in familyTypesList
                     orderby elemSymbol.GetParameters(subgroupingParameter).First().AsString() ascending
                     group elemSymbol by elemSymbol.GetParameters(groupingParameter).First().AsString() into mainGroup
                     orderby mainGroup.First().GetParameters(groupingParameter).First().AsString() descending
                     select mainGroup;

                //The spacing is the distance between each symbol when it is placed in fractional feet. 0.08333 is about 1" which works well for the scale used in making the drafting view
                double spacing = 0.08333;
                int rowNum = 0;
                //Cycle through each group ID Use grouping
                foreach (var mainGroup in familyTypesGroupedQuery)
                {
                    int columnNum = 0;
                    //Then for each family symbol in the ID Use grouping, place them in the view, incrementing the X distance by (spacing x the column number) each time. They will be in order of their Mark value
                    foreach (FamilySymbol symbol in mainGroup)
                    {
                        doc.Create.NewFamilyInstance(new XYZ(Convert.ToDouble(columnNum) * spacing, Convert.ToDouble(rowNum) * spacing, 0), symbol, placementView);
                        columnNum++;
                    }
                    rowNum++;
                }
                t.Commit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
