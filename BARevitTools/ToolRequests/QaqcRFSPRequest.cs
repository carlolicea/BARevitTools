using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Remove Family Shared Parameters tool
    class QaqcRFSPRequest
    {
        public QaqcRFSPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            List<string> familyFiles = uiForm.qaqcRFSPFamilyFiles;

            foreach(string familyFile in familyFiles)
            {
                //Open the family file and get its Family Manager. Then, get the list of family parameters
                RVTDocument familyDoc = uiApp.Application.OpenDocumentFile(familyFile);
                FamilyManager famMan = familyDoc.FamilyManager;
                IList<FamilyParameter> famParams = famMan.GetParameters();
                string famName = familyDoc.Title.Replace(".rfa", "");
                //Start a transaction
                using (Transaction t1 = new Transaction(familyDoc, "ChangeSharedParameters"))
                {
                    t1.Start();
                    try
                    {
                        //Cycle through the family parameters
                        foreach (FamilyParameter param in famParams)
                        {
                            string paramName = param.Definition.Name;
                            try
                            {
                                //If the parameter is shared, and the name does not contain BA or BAS, continue
                                if (param.IsShared && !paramName.ToUpper().Contains("BA ") && !paramName.ToUpper().Contains("BAS "))
                                {
                                    //A temporary parameter needs to be made in the place of the one to be removed, so get the group of the parameter to be replaced
                                    BuiltInParameterGroup paramGroup = param.Definition.ParameterGroup;
                                    string paramTempName = "tempName";
                                    //Determine if the parameter to replaced is an instance parameter
                                    bool paramInstance = param.IsInstance;
                                    //Make replace the parameter with the temporary one, giving it the same group and instance settings
                                    FamilyParameter newParam = famMan.ReplaceParameter(param, paramTempName, paramGroup, paramInstance);
                                    //Then, rename the new parameter
                                    famMan.RenameParameter(newParam, paramName);
                                    //Add to the ListBox the outcome of the shared parameter replacement
                                    uiForm.qaqcRFSPParametersListBox.Items.Add(famName+" : "+paramName + ": SUCCESS");
                                }
                            }
                            catch
                            {
                                //If the replacement fails, report that too
                                uiForm.qaqcRFSPParametersListBox.Items.Add(famName + " : " + paramName + ": FAILED");
                            }
                        }
                        t1.Commit();
                        //Update the MainUI
                        uiForm.qaqcRFSPParametersListBox.Update();
                        uiForm.qaqcRFSPParametersListBox.Refresh();
                    }
                    catch
                    {
                        t1.RollBack();
                    }
                }
                //Save the family and remove the backups
                RVTOperations.SaveRevitFile(uiApp, familyDoc, true);
                GeneralOperations.CleanRfaBackups(Path.GetDirectoryName(familyFile));
            }            
        }
    }
}
