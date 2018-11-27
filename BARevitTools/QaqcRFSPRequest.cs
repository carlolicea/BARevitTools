using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class QaqcRFSPRequest
    {
        public QaqcRFSPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            string familyFile = uiForm.qaqcRFSPFamilyFile;
            RVTDocument familyDoc = uiApp.Application.OpenDocumentFile(familyFile);
            FamilyManager famMan = familyDoc.FamilyManager;
            IList<FamilyParameter> famParams = famMan.GetParameters();

            Transaction t = new Transaction(familyDoc, "ChangeSharedParameters");
            t.Start();
            try
            {
                foreach (FamilyParameter param in famParams)
                {
                    string paramName = param.Definition.Name;
                    try
                    {
                        if (param.IsShared && !paramName.ToUpper().Contains("BA ") && !paramName.ToUpper().Contains("BAS "))
                        {
                            BuiltInParameterGroup paramGroup = param.Definition.ParameterGroup;
                            string paramTempName = "tempName";
                            bool paramInstance = param.IsInstance;
                            FamilyParameter newParam = famMan.ReplaceParameter(param, paramTempName, paramGroup, paramInstance);
                            famMan.RenameParameter(newParam, paramName);
                            uiForm.qaqcRFSPParametersListBox.Items.Add(paramName + ": SUCCESS");
                        }
                    }
                    catch
                    {
                        uiForm.qaqcRFSPParametersListBox.Items.Add(paramName + ": FAILED");
                    }
                }
                t.Commit();
                uiForm.qaqcRFSPParametersListBox.Update();
                uiForm.qaqcRFSPParametersListBox.Refresh();
            }
            catch
            {
                t.RollBack();
            }
            RVTOperations.SaveRevitFile(uiApp, familyDoc, true);
            GeneralOperations.CleanRfaBackups(Path.GetDirectoryName(familyFile));
        }
    }
}
