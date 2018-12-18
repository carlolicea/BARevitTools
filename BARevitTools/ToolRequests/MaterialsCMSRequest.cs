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
            DataGridView dgv = uiForm.materialsCMSExcelDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Reset the progress bar
            uiForm.materialsCMSExcelCreateSymbolsProgressBar.Value = 0;
            
            //Get version of the family file used for the ID Material Schedule symbol that matches the version of Revit running
            string familyFile = Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule;
            string versionedFamilyFile = "";
            try
            {
                versionedFamilyFile = RVTOperations.GetVersionedFamilyFilePath(uiApp, familyFile);
            }
            catch
            {
                //But if that fails, just take the original version and upgrade it
                versionedFamilyFile = familyFile;
            }
            
            //Assuming nothing went to hell in the process of getting one string...
            if (versionedFamilyFile != "")
            {
                //Do some stuff to make the family types from the DataGridView
                RVTDocument famDoc = RVTOperations.CreateFamilyTypesFromTable(uiApp, uiForm.materialsCMSExcelCreateSymbolsProgressBar, uiForm.materialsCMSExcelDataGridView, versionedFamilyFile);

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

                //Start a transaction
                Transaction t = new Transaction(doc, "MakeIDMaterialView");
                t.Start();
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
                t.Commit();

                //Do magic to place each symbol in its view by calling the method below in this class
                PlaceSymbolsInView(uiApp, famDoc, "ID Use", "Mark", placementView);
            }
            else
            {
                //If the family could not be found, well, let the user know of this.
                MessageBox.Show(String.Format("The {0} family could not be found at {1}. Please place the {0} family in the {1} folder for this tool to work.", 
                    Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule), 
                    Path.GetDirectoryName(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule)));
            }
        }

        //This method is to be used with the above constructor. It is private because it is not needed outside of this tool's use
        private static void PlaceSymbolsInView(UIApplication uiApp, RVTDocument famDoc, string groupingParameter, string subgroupingParameter, Autodesk.Revit.DB.View placementView)
        {
            try
            {
                IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();
                RVTDocument doc = uiApp.ActiveUIDocument.Document;
                famDoc.LoadFamily(doc, loadOptions);

                Transaction t = new Transaction(doc, "LoadMaterialSymbolsFamily");
                t.Start();

                placementView.Scale = 1;
                Dictionary<Element, string> familyTypesDict = new Dictionary<Element, string>();
                List<Element> familyTypesList = new List<Element>();
                Family refFamily = new FilteredElementCollector(doc).OfClass(typeof(Family)).WhereElementIsNotElementType().Cast<Family>().Where(elem => elem.Name == famDoc.Title.Replace(".rfa", "")).First();
                famDoc.Close(false);
                foreach (ElementId symbId in refFamily.GetFamilySymbolIds())
                {
                    FamilySymbol familySymbol = doc.GetElement(symbId) as FamilySymbol;
                    string paramValue = familySymbol.GetParameters(groupingParameter).First().AsString();
                    familyTypesList.Add(familySymbol);
                    familyTypesDict.Add(familySymbol, paramValue);
                }
                var familyTypesGroupedQuery =
                     from elemSymbol in familyTypesList
                     orderby elemSymbol.GetParameters(subgroupingParameter).First().AsString() ascending
                     group elemSymbol by elemSymbol.GetParameters(groupingParameter).First().AsString() into mainGroup
                     orderby mainGroup.First().GetParameters(groupingParameter).First().AsString() descending
                     select mainGroup;

                double spacing = 0.08333;
                int rowNum = 0;
                foreach (var mainGroup in familyTypesGroupedQuery)
                {
                    int columnNum = 0;
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
