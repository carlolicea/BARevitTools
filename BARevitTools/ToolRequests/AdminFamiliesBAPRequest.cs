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
    //This will add parameters to a selection of families in one bulk process. It will allow addition of shared parameters and assigning parameter values.
    class AdminFamiliesBAPRequest
    {
        public AdminFamiliesBAPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminFamiliesBAPDoneLabel.Visible = false;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;
            Dictionary<string, ExternalDefinition> sharedParameterDefinitions = new Dictionary<string, ExternalDefinition>();

            //Determine if the shared parameters file is accessible and try to get the shared parameters so their definition names and definitions could be added to a dictionary
            bool sharedParametersIsAccessible = true;
            try
            {
                DefinitionGroups sharedParameterGroups = uiApp.Application.OpenSharedParameterFile().Groups;
                foreach (DefinitionGroup group in sharedParameterGroups)
                {
                    foreach (ExternalDefinition definition in group.Definitions)
                    {
                        if (!sharedParameterDefinitions.Keys.Contains(definition.Name))
                        {
                            sharedParameterDefinitions.Add(definition.Name, definition);
                        }
                    }
                }
            } //If the access fails, then the shared parameters file was not accessible.
            catch { sharedParametersIsAccessible = false;}

            //Get the number of families to process from the DataGridView
            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                if (rowCount.Cells["Family Select"].Value.ToString() == "True")
                {
                    filesToProcess++;
                }
            }

            //Prepare the progress bar
            uiForm.adminFamiliesBAPProgressBar.Value = 0;
            uiForm.adminFamiliesBAPProgressBar.Minimum = 0;
            uiForm.adminFamiliesBAPProgressBar.Maximum = filesToProcess;
            uiForm.adminFamiliesBAPProgressBar.Step = 1;
            uiForm.adminFamiliesBAPProgressBar.Visible = true;

            //Stop any edits to the DataGridView of parameters to add
            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            try
            {
                foreach (DataGridViewRow row in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
                {
                    try
                    {
                        //If the checkbox for including the family in the process is not null, continue
                        if (row.Cells["Family Select"].Value != null)
                        {
                            //Grab the file path for the family
                            string filePath = row.Cells["Family Path"].Value.ToString();
                            List<string> famParamNames = new List<string>();
                            //If the checkbox is checked to select the family
                            if (row.Cells["Family Select"].Value.ToString() == "True")
                            {
                                //Open the family document
                                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                                if (famDoc.IsFamilyDocument)
                                {
                                    //Grab the family manager and make a list of parameter names already in the family
                                    FamilyManager familyManager = famDoc.FamilyManager;
                                    foreach (FamilyParameter famParam in familyManager.Parameters)
                                    {
                                        if (!famParamNames.Contains(famParam.Definition.Name))
                                        {
                                            famParamNames.Add(famParam.Definition.Name);
                                        }
                                        else { continue; }
                                    }

                                    foreach (DataGridViewRow newParamRow in uiForm.adminFamiliesBAPParametersDGV.Rows)
                                    {
                                        try
                                        {
                                            //Get the name of the parameter, group, and type of parameter to add
                                            string name = newParamRow.Cells["Parameter Name"].Value.ToString();
                                            BuiltInParameterGroup group = RVTOperations.GetBuiltInParameterGroupFromString(newParamRow.Cells["Parameter Group"].Value.ToString());
                                            ParameterType type = RVTOperations.GetParameterTypeFromString(newParamRow.Cells["Parameter Type"].Value.ToString());
                                            //Determine if the checkbox for making the parameter an instance parameter is checked
                                            bool isInstance = false;
                                            try
                                            {
                                                isInstance = Convert.ToBoolean(newParamRow.Cells["Parameter Is Instance"].Value.ToString());
                                            }
                                            catch { isInstance = false; }

                                            //Determine if the read-only checkbox for the parameter being a shared parameter is checked.
                                            bool isShared = false;
                                            try
                                            {
                                                isShared = Convert.ToBoolean(newParamRow.Cells["Parameter Is Shared"].Value.ToString());
                                            }
                                            catch { isShared = false; }

                                            //If the parameter is shared, and the parameter file is still accessible, and the family does not already contain a parameter with that name, continue
                                            if (isShared == true && sharedParametersIsAccessible == true && !famParamNames.Contains(name))
                                            {
                                                using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                                {
                                                    t.Start();
                                                    //Get the parameter definition from the dictionary of shared parameters, then add it to the family
                                                    ExternalDefinition definition = sharedParameterDefinitions[newParamRow.Cells["Parameter Name"].Value.ToString()];
                                                    FamilyParameter newParam = familyManager.AddParameter(definition, group, isInstance);
                                                    try
                                                    {
                                                        //Try to assign the parameter value if one is to be assigned
                                                        if (newParamRow.Cells["Parameter Value"].Value != null)
                                                        {
                                                            //If the number of types is greater than 0, cycle through them
                                                            if (familyManager.Types.Size > 0)
                                                            { 
                                                                foreach (FamilyType familyType in familyManager.Types)
                                                                {
                                                                    //For each type, make a subtransaction
                                                                    SubTransaction s1 = new SubTransaction(famDoc);
                                                                    s1.Start();
                                                                    try
                                                                    {
                                                                        //Then set the family type as current
                                                                        familyManager.CurrentType = familyType;
                                                                        //Attempt to set the parameter value
                                                                        RVTOperations.SetFamilyParameterValue(familyManager, newParam, RVTOperations.SetParameterValueFromString(newParamRow.Cells["Parameter Type"].Value.ToString(), newParamRow.Cells["Parameter Value"].Value));
                                                                        s1.Commit();
                                                                    }
                                                                    catch
                                                                    {
                                                                        //If that fails, let the user know and break out of the loop
                                                                        MessageBox.Show(String.Format("Could not assign value {0} to parameter {1} for type {2} in family {3}.", newParamRow.Cells["Parameter Value"], newParamRow.Cells["Parameter Name"], familyType.Name, row.Cells["Family Name"]));
                                                                        break;
                                                                    }
                                                                }                                                                
                                                            }
                                                            else
                                                            {
                                                                //If there was was no family types in the family, just set it for the default one
                                                                RVTOperations.SetFamilyParameterValue(familyManager, newParam, RVTOperations.SetParameterValueFromString(newParamRow.Cells["Parameter Type"].Value.ToString(), newParamRow.Cells["Parameter Value"].Value));
                                                            }
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        //If assignment fails, let the user know the parameter value, parameter name, and the family where the failure occured.
                                                        MessageBox.Show(String.Format("Could not assign value {0} to parameter {1} for family {2}", newParamRow.Cells["Parameter Value"], newParamRow.Cells["Parameter Name"], row.Cells["Family Name"]));
                                                    }
                                                    t.Commit();
                                                }
                                            }
                                            else if (isShared == true && sharedParametersIsAccessible == false && !famParamNames.Contains(name))
                                            {
                                                //If the shared parameter file could not be accessed, let the user know
                                                MessageBox.Show(String.Format("Could not set the shared parameter {0} because the shared parameters file for this project could not be found. " +
                                                    "Verify the shared parameters file is mapped correctly.", name));
                                            }
                                            else if (isShared != true && !famParamNames.Contains(name))
                                            {
                                                //Otherwise, just make a standard parameter
                                                using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                                {
                                                    t.Start();
                                                    FamilyParameter newParam = familyManager.AddParameter(name, group, type, isInstance);
                                                    try
                                                    {
                                                        if (newParamRow.Cells["Parameter Value"].Value != null)
                                                        {
                                                            RVTOperations.SetFamilyParameterValue(familyManager, newParam, RVTOperations.SetParameterValueFromString(newParamRow.Cells["Parameter Type"].Value.ToString(), newParamRow.Cells["Parameter Value"].Value));
                                                        }
                                                    }
                                                    catch { continue; }
                                                    t.Commit();
                                                }
                                            }
                                            else
                                            {
                                                //If all other conditions were not met, then the parameter already exists.
                                                MessageBox.Show(String.Format("Could not make parameter '{0}' for {1} because it already exists.", name, famDoc.Title));
                                            }
                                        }
                                        catch { continue; }
                                        finally
                                        {
                                            //Save the family
                                            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                                            famDoc.SaveAs(filePath, saveAsOptions);
                                        }
                                    }
                                }
                                //Close the family
                                famDoc.Close(false);
                            }
                            else
                            {
                                continue;
                            }
                            //Step forward the progress bar
                            uiForm.adminFamiliesBAPProgressBar.PerformStep();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("The family could not be opened, likely due to being saved in a newer version of Revit");
                    }                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                //Clean up the backups when done
                GeneralOperations.CleanRfaBackups(uiForm.adminFamiliesBAPFamilyDirectory);
            }
            uiForm.adminFamiliesBAPProgressBar.Visible = false;
            uiForm.adminFamiliesBAPDoneLabel.Visible = true;
            uiForm.Update();
        }
    }
}
