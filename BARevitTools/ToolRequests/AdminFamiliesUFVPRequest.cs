using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class AdminFamiliesUFVPRequest
    {
        public AdminFamiliesUFVPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            

            List<string> familyFiles = GeneralOperations.GetAllRvtFamilies(BARevitTools.Properties.Settings.Default.BARTBARevitFamilyLibraryPath);

            if (familyFiles.Count > 0)
            {
                
                try
                {
                    Dictionary<string, ExternalDefinition> sharedParameterDefinitions = new Dictionary<string, ExternalDefinition>();
                    DefinitionFile definitionFile = null;
                    bool sharedParametersIsAccessible = true;
                    try
                    {
                        definitionFile = uiApp.Application.OpenSharedParameterFile();
                        DefinitionGroups sharedParameterGroups = definitionFile.Groups;
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
                    catch { sharedParametersIsAccessible = false; }

                    uiForm.adminFamiliesUFVPProgressBar.Value = 0;
                    uiForm.adminFamiliesUFVPProgressBar.Minimum = 0;
                    uiForm.adminFamiliesUFVPProgressBar.Maximum = familyFiles.Count;
                    uiForm.adminFamiliesUFVPProgressBar.Step = 1;
                    uiForm.adminFamiliesUFVPProgressBar.Visible = true;
                    if (sharedParametersIsAccessible && sharedParameterDefinitions.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                    {
                        foreach (string familyFile in familyFiles)
                        {
                            SetParameters(uiApp, familyFile, sharedParameterDefinitions[Properties.Settings.Default.RevitUFVPParameter]);
                            uiForm.adminFamiliesUFVPProgressBar.PerformStep();
                        }
                    }
                    else if (sharedParametersIsAccessible && !sharedParameterDefinitions.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                    {                        
                        MessageBox.Show("Could not get the parameter to set");
                    }
                    else { MessageBox.Show("Could not open the shared parameters file"); }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }                
            }
        }

        private void SetParameters(UIApplication uiApp, string familyFile, ExternalDefinition externalDefinition)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(familyFile);
                string lastModified = fileInfo.LastWriteTime.ToShortDateString();

                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFile);
                FamilyManager famMan = famDoc.FamilyManager;
                FamilyParameter famParameter = null;
                Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
                foreach (FamilyParameter famParam in famMan.Parameters)
                {
                    famParamDict.Add(famParam.Definition.Name, famParam);
                }

                Transaction t1 = new Transaction(famDoc, "SetParameters");
                t1.Start();
                if (!famParamDict.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                {
                    famParameter = famMan.AddParameter(externalDefinition, BuiltInParameterGroup.PG_IDENTITY_DATA, false);
                }
                else
                {
                    famParameter = famParamDict[BARevitTools.Properties.Settings.Default.RevitUFVPParameter];
                }
                foreach (FamilyType famType in famMan.Types)
                {
                    SubTransaction s1 = new SubTransaction(famDoc);
                    s1.Start();
                    famMan.CurrentType = famType;
                    famMan.Set(famParameter, lastModified);
                    s1.Commit();
                }
                t1.Commit();
                RVTOperations.SaveRevitFile(uiApp, famDoc, true);
                GeneralOperations.CleanRfaBackups(BARevitTools.Properties.Settings.Default.BARTBARevitFamilyLibraryPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }            
        }
    }
}
