using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is responsible for the portion of the Create Families From Excel tool that converts the table data from Excel to families or family types
    class AllCatCFFE2Request
    {
        public AllCatCFFE2Request(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.multiCatCFFEFamiliesProgressBar.Value = 0;
            string saveDirectory = uiForm.multiCatCFFEFamilySaveLocation;
            DataGridView dgv = uiForm.multiCatCFFEFamiliesDGV;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 1;
            saveAsOptions.OverwriteExistingFile = true;

            //From the Comments section of the Excel template properties, get the family path for the family that was used to make the template
            string familyFileToUse = uiForm.multiCatCFFEFamilyFileToUse;
            if (!File.Exists(familyFileToUse))
            {
                //If the family does not exist at that path, prompt the user to find it
                MessageBox.Show(String.Format("Could not find the family file '{0}'. Please navigate to it in the following window", familyFileToUse));
                string file = GeneralOperations.GetFile();
                if (file != "")
                {
                    //If the family was selected, set the selection to the family to use
                    familyFileToUse = file;
                }
                else
                {
                    familyFileToUse = "";
                }
            }

            //Assuming the family file to use exists, the user has set the save location, and they have set the creation method, continue
            if (familyFileToUse != "" && uiForm.multiCatCFFEFamilySaveLocation != "" && uiForm.multiCatCFFEFamiliesDGV.Rows.Count != 0 && uiForm.multiCatCFFEFamilyCreationComboBox.Text != "<Select Creation Method>")
            {
                //Call the AllCatCFFE2Request.CreateFamilyTypesFromTable method
                CreateFamilyTypesFromTable(uiApp, uiForm, saveDirectory, dgv, saveAsOptions, familyFileToUse);
            }
            //Otherwise, tell the user 
            else if (uiForm.multiCatCFFEFamilySaveLocation == "")
            {
                MessageBox.Show("No save directory selected");
            }
            else if (uiForm.multiCatCFFEFamilyCreationComboBox.Text == "<Select Creation Method>")
            {
                MessageBox.Show("Please select a creation method");
            }
            else
            {
                MessageBox.Show("No families can be made because a family to use was not identified");
            }
        }

        //Here, the families or types will be made
        private static void CreateFamilyTypesFromTable(UIApplication uiApp, MainUI uiForm, string saveDirectory, DataGridView dgv, SaveAsOptions saveAsOptions, string familyFileToUse)
        {
            //First thing to do is open the family document and access the FamilyManager
            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFileToUse);
            FamilyManager famMan = famDoc.FamilyManager;

            string tempFamilyPath = "";
            //Next, delete all of the family types except one from the family and save the file off for temporary use
            try
            {
                //This is in a Try/Catch becuse there is a possibility for failure
                RVTOperations.DeleteFamilyTypes(famDoc, famMan);
                tempFamilyPath = saveDirectory + "\\" + String.Format(famDoc.Title).Replace(".rfa", "") + "_temp.rfa";
                famDoc.SaveAs(tempFamilyPath, saveAsOptions);
            }
            catch { MessageBox.Show("Could not save out a temporary family file to the location where the families are to be saved. Verify the location is not read-only."); }
            //Ensure the open family gets closed
            finally { famDoc.Close(); }

            //Then, reopen the temporary family if it exists
            if(tempFamilyPath != "")
            {
                //Get all of the parameters in the family and add them to a dictionary indexed by the parameter name
                RVTDocument newFamDoc = RVTOperations.OpenRevitFile(uiApp, tempFamilyPath);
                FamilyManager newFamMan = newFamDoc.FamilyManager;
                FamilyParameterSet parameters = newFamMan.Parameters;
                Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
                foreach (FamilyParameter param in parameters)
                {
                    famParamDict.Add(param.Definition.Name, param);
                }

                //These integer values will be used to increment loops
                int rowsCount = dgv.Rows.Count;
                int columnsCount = dgv.Columns.Count;

                //Keep track of what family types were made so the script can later delete out the one that pre-existed in the family but is not needed.
                List<string> familyTypesMade = new List<string>();
                //If the user decide to make types per row instead of families per row...
                if (uiForm.multiCatCFFEFamilyCreationComboBox.SelectedItem.ToString() == "Combine Types (1 File)")
                {
                    //The progress bar should be prepared using the number of rows multipled by the number of columns for the number of steps to perform. This gives a better indication of progress than doing it based on the number of rows
                    uiForm.multiCatCFFEFamiliesProgressBar.Minimum = 0;
                    uiForm.multiCatCFFEFamiliesProgressBar.Maximum = (rowsCount - 1) * (columnsCount - 1);
                    uiForm.multiCatCFFEFamiliesProgressBar.Step = 1;
                    uiForm.multiCatCFFEFamiliesProgressBar.Visible = true;

                    //Open the transaction
                    Transaction t2 = new Transaction(newFamDoc, "MakeNewTypes");
                    t2.Start();
                    //The maximum of rows is greater than the maximum index value by 1, so this uses < to stop before an index out of range exception occurs. Also, the index starts at 1 instead of 0 because the top row is the info about the data type
                    for (int i = 1; i < rowsCount; i++)
                    {
                        //The type name is in the first column.
                        string newTypeName = dgv.Rows[i].Cells[0].Value.ToString();
                        //This operation will get the existing type names in the family as new ones are added to avoide duplication
                        Dictionary<string, FamilyType> existingTypeNames = RVTOperations.GetFamilyTypeNames(newFamMan);
                        //If the type does not exist in the dictionary...
                        if (!existingTypeNames.Keys.Contains(newTypeName))
                        {
                            //Create a new type and add it to the list of types made
                            FamilyType newType = newFamMan.NewType(newTypeName);
                            newFamMan.CurrentType = newType;
                            familyTypesMade.Add(newType.Name);
                        }
                        else
                        {
                            //Otherwise set the current type in the family manager to the pre-existing one with the name of the one to be created
                            newFamMan.CurrentType = existingTypeNames[newTypeName];
                            //Add that one to the list of types made, though it wasn't actually made
                            familyTypesMade.Add(newFamMan.CurrentType.Name);
                        }

                        //Next, cycle through the columns, again starting with the column at index 1 and incrementing the columns to one less than the number of columns
                        for (int j = 1; j < columnsCount; j++)
                        {
                            //Get the parameter name from the first column's header text
                            string paramName = dgv.Columns[j].HeaderText;
                            //Get the storage type from the first row
                            string paramStorageTypeString = dgv.Rows[0].Cells[j].Value.ToString();
                            var paramValue = dgv.Rows[i].Cells[j].Value;
                            //Assuming the parameter value is set...
                            if (paramValue.ToString() != "")
                            {
                                //Set the parameter given the information about the FamilyManager, parameter definition, parameter type, parameter data type, value to set, and whether or not to convert inches to feet. Because this script relies on inch input, this needs done to convert to feet used by the Revit API
                                FamilyParameter param = famParamDict[paramName];
                                ParameterType paramType = param.Definition.ParameterType;
                                RVTOperations.SetFamilyParameterValue(newFamMan, param, paramType, paramStorageTypeString, paramValue, true);
                            }
                            //Step forward the progress bar for this parameter
                            uiForm.multiCatCFFEFamiliesProgressBar.PerformStep();
                        }
                    }
                    t2.Commit();

                    //In another transaction, delete the pre-existing type used to generate the other types
                    Transaction t3 = new Transaction(newFamDoc, "DeleteOldTypes");
                    t3.Start();
                    foreach (FamilyType type in newFamMan.Types)
                    {
                        //Set the current type to the one with the pre-existing type name and delete it
                        if (!familyTypesMade.Contains(type.Name))
                        {
                            newFamMan.CurrentType = type;
                            newFamMan.DeleteCurrentType();
                        }
                    }
                    t3.Commit();

                    //Save out the family to the directory and remove the _temp from the name
                    newFamDoc.SaveAs(saveDirectory + "\\" + String.Format(newFamDoc.Title).Replace("_temp", "")+".rfa", saveAsOptions);
                    newFamDoc.Close();
                }

                //If the user chose to make a family file per row, the family will be saved out multiple times
                else if (uiForm.multiCatCFFEFamilyCreationComboBox.SelectedItem.ToString() == "1 Family Per Type (Multiple Files)")
                {
                    //Set the number of steps for the progress bar to the number of rows with families to make
                    uiForm.multiCatCFFEFamiliesProgressBar.Minimum = 0;
                    uiForm.multiCatCFFEFamiliesProgressBar.Maximum = rowsCount - 1;
                    uiForm.multiCatCFFEFamiliesProgressBar.Step = 1;
                    uiForm.multiCatCFFEFamiliesProgressBar.Visible = true;

                    //Again, starting at row index 1 because the first is the information about the data types. This loop will produce a family per row. One familly will be opened and saved off multiple times, performing the process of deleting types, adding a default type, and setting parameters before each save
                    for (int i = 1; i < rowsCount; i++)
                    {
                        Transaction t2 = new Transaction(newFamDoc, "MakeNewTypes");
                        t2.Start();
                        //Create a new type using the name of the type in the first column
                        FamilyType newType = newFamMan.NewType(dgv.Rows[i].Cells[0].Value.ToString());
                        //Clean up the family file name by leaving everything that does not pass the regular expression in CleanFileName
                        
                        string saveName = GeneralOperations.CleanFileName(newType.Name);
                        if (saveName != "")
                        {
                            //Assuming nothing went wrong modifying the family name...
                            newFamMan.CurrentType = newType;
                            //Cycle through the columns to set the parameter values this performs the same operations as those above for making 1 family with multiple types
                            for (int j = 1; j < columnsCount; j++)
                            {
                                string paramName = dgv.Columns[j].HeaderText;
                                string paramStorageTypeString = dgv.Rows[0].Cells[j].Value.ToString();
                                var paramValue = dgv.Rows[i].Cells[j].Value;
                                if (paramValue.ToString() != "")
                                {
                                    FamilyParameter param = famParamDict[paramName];
                                    ParameterType paramType = param.Definition.ParameterType;
                                    RVTOperations.SetFamilyParameterValue(newFamMan, param, paramType, paramStorageTypeString, paramValue, true);
                                }
                            }
                            t2.Commit();

                            //Again, do another transaction to delete the pre-existing type
                            Transaction t3 = new Transaction(newFamDoc, "DeleteOldTypes");
                            t3.Start();
                            foreach (FamilyType type in newFamMan.Types)
                            {
                                newFamMan.CurrentType = type;
                                if (newFamMan.CurrentType.Name != newType.Name)
                                {
                                    newFamMan.DeleteCurrentType();
                                }
                            }
                            t3.Commit();
                            //Save out the family and continue the loop
                            newFamDoc.SaveAs(saveDirectory + "\\" + saveName + ".rfa", saveAsOptions);
                            uiForm.multiCatCFFEFamiliesProgressBar.PerformStep();
                        }
                    }
                    // The family document is finally closed after saving off itself for each row
                    newFamDoc.Close();
                }
                else { MessageBox.Show("No Creation Method was selected"); }

                //Delete the _temp file
                File.Delete(tempFamilyPath);

                //Clean up the backup files too
                List<string> backupFiles = GeneralOperations.GetAllRvtBackupFamilies(uiForm.multiCatCFFEFamilySaveLocation);
                GeneralOperations.CleanRfaBackups(backupFiles);
            }
            
        }
    }
}
