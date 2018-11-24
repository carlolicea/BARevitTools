using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
{
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

            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            foreach (DataGridViewRow row in uiForm.adminFamiliesBRPFamiliesDGV.Rows)
            {
                string filePath = row.Cells[2].Value.ToString();
                Dictionary<string, FamilyParameter> famParams = new Dictionary<string, FamilyParameter>();
                string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);
                if (row.Cells[0].Value.ToString() == "True" && Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
                {
                    RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                    if (famDoc.IsFamilyDocument)
                    {
                        bool saveFamily = false;
                        FamilyManager familyManager = famDoc.FamilyManager;
                        foreach (FamilyParameter famParam in familyManager.Parameters)
                        {
                            if (!famParams.Keys.Contains(famParam.Definition.Name))
                            {
                                famParams.Add(famParam.Definition.Name, famParam);
                            }
                            else { continue; }

                        }
                        foreach (DataGridViewRow paramRow in uiForm.adminFamiliesBRPParametersDGV.Rows)
                        {
                            try
                            {
                                string name = paramRow.Cells[0].Value.ToString();
                                try
                                {
                                    if (famParams.Keys.Contains(name))
                                    {
                                        using (Transaction t = new Transaction(famDoc, "Remove Parameter"))
                                        {
                                            t.Start();
                                            familyManager.RemoveParameter(famParams[name]);
                                            t.Commit();
                                            saveFamily = true;
                                        }
                                    }
                                }
                                catch { continue; }
                            }
                            catch { continue; }
                        }
                        if (saveFamily == true)
                        {
                            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                            famDoc.SaveAs(filePath, saveAsOptions);
                        }
                    }
                    famDoc.Close(false);
                }
                else { continue; }
                uiForm.adminFamiliesBRPProgressBar.PerformStep();
            }
            uiForm.adminFamiliesBRPProgressBar.Visible = false;
        }
    }
}
