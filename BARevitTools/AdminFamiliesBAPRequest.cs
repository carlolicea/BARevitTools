using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class AdminFamiliesBAPRequest
    {
        public AdminFamiliesBAPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;
            Dictionary<string, ExternalDefinition> sharedParameterDefinitions = new Dictionary<string, ExternalDefinition>();
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

            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                if (rowCount.Cells[0].Value.ToString() == "True")
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
            foreach (DataGridViewRow row in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                string filePath = row.Cells[2].Value.ToString();
                List<string> famParamNames = new List<string>();
                string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);

                if (row.Cells[0].Value.ToString() == "True" && Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
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
                                string name = newParamRow.Cells[1].Value.ToString();
                                BuiltInParameterGroup group = RVTOperations.GetBuiltInParameterGroupFromString(newParamRow.Cells[3].Value.ToString());
                                ParameterType type = RVTOperations.GetParameterTypeFromString(newParamRow.Cells[2].Value.ToString());
                                bool isInstance = Convert.ToBoolean(newParamRow.Cells[4].Value.ToString());
                                bool isShared = false;
                                try
                                {
                                    isShared = Convert.ToBoolean(newParamRow.Cells[0].Value.ToString());
                                }
                                catch { isShared = false; }

                                if (isShared == true && !famParamNames.Contains(name))
                                {
                                    using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                    {
                                        t.Start();
                                        ExternalDefinition definition = sharedParameterDefinitions[newParamRow.Cells[1].Value.ToString()];
                                        FamilyParameter newParam = familyManager.AddParameter(definition, group, isInstance);
                                        t.Commit();
                                    }
                                }
                                else if (isShared != true && !famParamNames.Contains(name))
                                {
                                    using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                    {
                                        t.Start();
                                        FamilyParameter newParam = familyManager.AddParameter(name, group, type, isInstance);
                                        t.Commit();
                                    }
                                }
                                else { MessageBox.Show(String.Format("Could not make parameter '{0}' because it already exists.", name)); }
                            }
                            catch { continue; }

                        }
                        ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                        famDoc.SaveAs(filePath, saveAsOptions);
                    }
                    famDoc.Close(false);
                }
                else { continue; }
                uiForm.adminFamiliesBAPProgressBar.PerformStep();
            }
            uiForm.adminFamiliesBAPProgressBar.Visible = false;
        }
    }
}
