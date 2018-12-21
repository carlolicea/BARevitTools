using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This will remove parameters in bulk operations, where possible, using the parameter names in the DataGridView
    class AdminFamiliesBRPRequest
    {
        public AdminFamiliesBRPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;

            //Get how many families to evaluate for the progress bar steps and resetting the progress bar
            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBRPFamiliesDGV.Rows)
            {
                if (rowCount.Cells[0].Value.ToString() == "True")
                {
                    filesToProcess++;
                }
            }
            uiForm.adminFamiliesBRPProgressBar.Value = 0;
            uiForm.adminFamiliesBRPProgressBar.Minimum = 0;
            uiForm.adminFamiliesBRPProgressBar.Maximum = filesToProcess;
            uiForm.adminFamiliesBRPProgressBar.Step = 1;
            uiForm.adminFamiliesBRPProgressBar.Visible = true;

            //Stop all edits to the DataGridView table 
            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            foreach (DataGridViewRow row in uiForm.adminFamiliesBRPFamiliesDGV.Rows)
            {                
                //If the checkbox to select the family is not in a null state, continue
                if (row.Cells["Family Select"].Value!= null)
                {                    
                    //If the checkbox to select the family is checked, continue
                    if (row.Cells["Family Select"].Value.ToString() == "True")
                    {
                        //Get the family path for the selected row and make a dictionary to store the parameters by name
                        string filePath = row.Cells["Family Path"].Value.ToString();
                        Dictionary<string, FamilyParameter> famParams = new Dictionary<string, FamilyParameter>();
                        try
                        {
                            //Open the file and verify it is a family document
                            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                            if (famDoc.IsFamilyDocument)
                            {
                                //saveFamily will be used to determine if the family needs saved or just closed. No need to save the family if nothing was modified
                                bool saveFamily = false;
                                //Get the Family Manager to retrieve the parameters, then add each parameter to the dictionary by name
                                FamilyManager familyManager = famDoc.FamilyManager;
                                foreach (FamilyParameter famParam in familyManager.Parameters)
                                {
                                    if (!famParams.Keys.Contains(famParam.Definition.Name))
                                    {
                                        famParams.Add(famParam.Definition.Name, famParam);
                                    }
                                    else { continue; }
                                }

                                //Cycle through the rows of parameter to remove
                                foreach (DataGridViewRow paramRow in uiForm.adminFamiliesBRPParametersDGV.Rows)
                                {
                                    //If the cell for the parameter name is not null, continue
                                    if (paramRow.Cells["Parameter Name"].Value!= null)
                                    {
                                        //Get the name of the parameter to attempt removal, and see if it exists in the dictionary
                                        string name = paramRow.Cells["Parameter Name"].Value.ToString();
                                        if (famParams.Keys.Contains(name))
                                        {
                                            try
                                            {
                                                //Attempt to remove the parameter. This may not be possible if a built-in parameter was specified by name, so the Catch will throw the message stating the name of the parameter that could not be removed and which family it was attempted on
                                                using (Transaction t = new Transaction(famDoc, "Remove Parameter"))
                                                {
                                                    t.Start();
                                                    familyManager.RemoveParameter(famParams[name]);
                                                    t.Commit();
                                                    saveFamily = true;
                                                }
                                            }
                                            catch
                                            {
                                                MessageBox.Show(String.Format("Could not remove parameter '{0}' for family {1}", name, famDoc.Title));
                                            }
                                        }
                                    }                                        
                                }

                                //If there were any changes, save the family. If not, continue on to close the family
                                if (saveFamily == true)
                                {
                                    ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                                    famDoc.SaveAs(filePath, saveAsOptions);
                                }
                            }
                            //Close the family document
                            famDoc.Close(false);
                        }
                        catch
                        {
                            MessageBox.Show("The family could not be opened, likely due to being a newer version of Revit");
                        }
                        finally
                        {
                            //No matter what, step forward the progress bar
                            uiForm.adminFamiliesBRPProgressBar.PerformStep();
                        }                        
                    }
                    else { continue; }                    
                }                
            }
            GeneralOperations.CleanRfaBackups(uiForm.adminFamiliesBRPFamilyDirectory);
            uiForm.adminFamiliesBRPProgressBar.Visible = false;
        }
    }
}
