using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This updates the BAS Version parameter in families to have the value equal to the date they were last modified
    class AdminFamiliesLBCRequest
    {
        public AdminFamiliesLBCRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            string saveDirectory = uiForm.adminFamiliesLBCSaveDirectoryTextBox.Text;

            List<string> existingFiles = GeneralOperations.GetAllRvtFamilyNames(uiForm.adminFamiliesLBCSaveDirectoryTextBox.Text, false);
            try
            {
                List<string> familyFiles = new List<string>();
                if (uiForm.adminFamiliesLBCUseDateCheckBox.Checked)
                {
                    familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesLBCDirectoryTextBox.Text, uiForm.adminFamiliesLBCDatePicker.Value, true);
                }
                else
                {
                    familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesLBCDirectoryTextBox.Text, false);
                }

                if (familyFiles.Count > 0)
                {
                    foreach (string familyFileToUse in familyFiles)
                    {

                        string familyFile = familyFileToUse;
                        if (!existingFiles.Contains(Path.GetFileNameWithoutExtension(familyFile)))
                        {
                            try
                            {
                                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFile);
                                try
                                {
                                    string Category = RVTOperations.GetRevitFamilyCategory(famDoc);
                                    string manufacturer = "";

                                    try
                                    {
                                        manufacturer = famDoc.FamilyManager.CurrentType.AsString(famDoc.FamilyManager.get_Parameter(BuiltInParameter.ALL_MODEL_MANUFACTURER));
                                    }
                                    catch {; }

                                    string saveSubDirectory = saveDirectory + "\\" + Category;
                                    string saveLocation = "";

                                    if (manufacturer != "")
                                    {
                                        saveLocation = saveSubDirectory + "\\" + manufacturer + "\\" + Path.GetFileName(familyFile);
                                    }
                                    else
                                    {
                                        saveLocation = saveSubDirectory + "\\" + Path.GetFileName(familyFile);
                                    }

                                    if (!Directory.Exists(Path.GetDirectoryName(saveLocation)))
                                    {
                                        Directory.CreateDirectory(Path.GetDirectoryName(saveLocation));
                                    }

                                    try
                                    {
                                        if (File.Exists(saveLocation))
                                        {
                                            if (File.GetLastWriteTime(familyFile) > File.GetLastWriteTime(saveLocation))
                                            {
                                                RVTOperations.SaveRevitFile(uiApp, famDoc, saveLocation, true);
                                            }
                                            else
                                            {
                                                famDoc.Close(false);
                                            }
                                        }
                                        else
                                        {
                                            RVTOperations.SaveRevitFile(uiApp, famDoc, saveLocation, true);
                                        }
                                        GeneralOperations.CleanRfaBackups(Path.GetDirectoryName(saveLocation));
                                    }
                                    catch
                                    {
                                        uiForm.adminFamiliesLBCFamiliesListBox.Items.Add(familyFile + " : NOT MOVED");
                                        uiForm.Update();
                                    }
                                }
                                catch //(Exception f)
                                {
                                    uiForm.adminFamiliesLBCFamiliesListBox.Items.Add(familyFile + " : NOT MOVED");
                                    uiForm.Update();
                                }
                            }
                            catch //(Exception e)
                            {
                                uiForm.adminFamiliesLBCFamiliesListBox.Items.Add(familyFile + " : NOT MOVED");
                                uiForm.Update();
                                //MessageBox.Show(e.ToString());
                            }
                        }
                    }                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
