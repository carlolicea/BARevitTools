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
    //
    //This updates the BAS Version parameter in families to have the value equal to the date they were last modified
    class AdminFamiliesSRCPRequest
    {
        public AdminFamiliesSRCPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Clear out the backup families from the directory
            List<string> backupFamilies = GeneralOperations.GetAllRvtBackupFamilies(uiForm.adminFamiliesSRCPDirectoryTextBox.Text, true);
            GeneralOperations.CleanRfaBackups(backupFamilies);

            //Get the family files from the directory. If the option to use the date since last modified was checked, use the first method, else use the second method
            List<string> familyFiles = new List<string>();
            if (uiForm.adminFamiliesSRCPUseDateCheckBox.Checked)
            {
                familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesSRCPDirectoryTextBox.Text, uiForm.adminFamiliesSRCPDatePicker.Value, true);
            }
            else
            {
                familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesSRCPDirectoryTextBox.Text, false);
            }

            //Verify the number of families collected is more than 0
            if (familyFiles.Count > 0)
            {
                foreach (string familyFile in familyFiles)
                {
                    RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFile);
                    Family family = famDoc.OwnerFamily;
                    Parameter rcp = family.get_Parameter(BuiltInParameter.ROOM_CALCULATION_POINT);
                    if (rcp.AsInteger() == 0)
                    {
                        try
                        {
                            using (Transaction t1 = new Transaction(famDoc, "SetRoomCalculationPoint"))
                            {
                                t1.Start();
                                rcp.Set(1);
                                t1.Commit();
                            }                                
                            uiForm.adminFamiliesSRCPListBox.Items.Add(famDoc.Title.Replace(".rfa", "") + ": Updated");
                        }
                        catch
                        {
                            uiForm.adminFamiliesSRCPListBox.Items.Add(famDoc.Title.Replace(".rfa", "") + ": FAILED");
                        }                       
                    }
                    else
                    {
                        uiForm.adminFamiliesSRCPListBox.Items.Add(famDoc.Title.Replace(".rfa", "") + ": Ignored");
                    }
                    RVTOperations.SaveRevitFile(uiApp, famDoc, true);
                }                
            }
            GeneralOperations.CleanRfaBackups(uiForm.adminFamiliesSRCPDirectoryTextBox.Text);
        }
    }        
}
