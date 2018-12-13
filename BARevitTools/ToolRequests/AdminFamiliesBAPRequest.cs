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
    class AdminFamiliesBAPRequest
    {
        public AdminFamiliesBAPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;
            Dictionary<string, ExternalDefinition> sharedParameterDefinitions = new Dictionary<string, ExternalDefinition>();

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
            }
            catch { sharedParametersIsAccessible = false;}

            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                if (rowCount.Cells["Family Select"].Value.ToString() == "True")
                {
                    filesToProcess++;
                }
            }

            uiForm.adminFamiliesBAPProgressBar.Value = 0;
            uiForm.adminFamiliesBAPProgressBar.Minimum = 0;
            uiForm.adminFamiliesBAPProgressBar.Maximum = filesToProcess;
            uiForm.adminFamiliesBAPProgressBar.Step = 1;
            uiForm.adminFamiliesBAPProgressBar.Visible = true;

            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            try
            {
                foreach (DataGridViewRow row in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
                {
                    
                    if (row.Cells["Family Select"].Value != null)
                    {
                        string filePath = row.Cells[2].Value.ToString();
                        List<string> famParamNames = new List<string>();
                        string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                        if (rvtVersion!="")
                        {
                            string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);
                            if (row.Cells["Family Select"].Value.ToString() == "True" && Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
                            {
                                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                                if (famDoc.IsFamilyDocument)
                                {
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
                                            string name = newParamRow.Cells["Parameter Name"].Value.ToString();
                                            BuiltInParameterGroup group = RVTOperations.GetBuiltInParameterGroupFromString(newParamRow.Cells["Parameter Group"].Value.ToString());
                                            ParameterType type = RVTOperations.GetParameterTypeFromString(newParamRow.Cells["Parameter Type"].Value.ToString());
                                            bool isInstance = false;
                                            try
                                            {
                                                isInstance = Convert.ToBoolean(newParamRow.Cells["Parameter Is Instance"].Value.ToString());
                                            }
                                            catch { isInstance = false; }

                                            bool isShared = false;
                                            try
                                            {
                                                isShared = Convert.ToBoolean(newParamRow.Cells["Parameter Is Shared"].Value.ToString());
                                            }
                                            catch { isShared = false; }

                                            if (isShared == true && sharedParametersIsAccessible == true && !famParamNames.Contains(name))
                                            {
                                                using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                                {
                                                    t.Start();
                                                    ExternalDefinition definition = sharedParameterDefinitions[newParamRow.Cells["Parameter Name"].Value.ToString()];
                                                    FamilyParameter newParam = familyManager.AddParameter(definition, group, isInstance);
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
                                            else if (isShared == true && sharedParametersIsAccessible == false && !famParamNames.Contains(name))
                                            {
                                                MessageBox.Show(String.Format("Could not set the shared parameter {0} because the shared parameters file for this project could not be found. " +
                                                    "Verify the shared parameters file is mapped correctly.", name));
                                            }
                                            else if (isShared != true && !famParamNames.Contains(name))
                                            {
                                                MessageBox.Show("Standard Parameter");
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
                                            else { MessageBox.Show(String.Format("Could not make parameter '{0}' because it already exists.", name)); }
                                        }
                                        catch { continue; }
                                        finally
                                        {
                                            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                                            famDoc.SaveAs(filePath, saveAsOptions);
                                        }
                                    }
                                }
                                famDoc.Close(false);
                            }
                            else { continue; }
                            uiForm.adminFamiliesBAPProgressBar.PerformStep();
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Could not get the Revit version for {0}, so it was not processed.", Path.GetFileNameWithoutExtension(filePath)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            uiForm.adminFamiliesBAPProgressBar.Visible = false;
        }
    }
}
