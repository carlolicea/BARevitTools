using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class SetupUPRequest
    {
        public SetupUPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            string hostFilePathToUpgrade = uiForm.setupUPOriginalFilePathTextBox.Text;
            string hostFilePathForUpgrade = uiForm.setupUPUpgradedFilePathSetTextBox.Text + "\\" + uiForm.setupUPUpgradedFilePathUserTextBox.Text + ".rvt";

            if (File.Exists(hostFilePathForUpgrade))
            {
                MessageBox.Show("A file already exists with the name and location specified for the upgrade of the host Revit project file");
            }
            else if (uiForm.setupUPUpgradedFilePathUserTextBox.Text == "")
            {
                MessageBox.Show("No location for the upgraded of the host Revit project file is set");
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        if (dgv.Rows[i].Cells["Upgrade"].Value != null)
                        {
                            if (dgv.Rows[i].Cells["Allow Upgrade"].Value.ToString() == "True" && dgv.Rows[i].Cells["Upgrade"].Value.ToString() == "True")
                            {
                                string linkFilePathToUpgrade = dgv.Rows[i].Cells["Original Path"].Value.ToString();
                                string linkFilePathForUpgrade = dgv.Rows[i].Cells["New Path"].Value.ToString();
                                bool linkResult = RVTOperations.UpgradeRevitFile(uiApp, linkFilePathToUpgrade, linkFilePathForUpgrade, false);
                                if (linkResult == true)
                                {
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = true;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
                                }
                                else
                                {
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = false;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                        else { continue; }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                }

                bool hostResult = RVTOperations.UpgradeRevitFile(uiApp, hostFilePathToUpgrade, hostFilePathForUpgrade, false);
                int countOfUpgradeLinks = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    try
                    {
                        if (row.Cells["Upgrade"].Value != null)
                        {
                            if (row.Cells["Upgrade"].Value.ToString() == "True")
                            {
                                countOfUpgradeLinks++;
                            }
                        }
                    }
                    catch { continue; }
                }

                if (hostResult == true)
                {
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.GreenYellow;
                    if (countOfUpgradeLinks > 0)
                    {
                        try
                        {
                            RVTDocument hostDoc = RVTOperations.OpenRevitFile(uiApp, hostFilePathForUpgrade);
                            Dictionary<string, RevitLinkType> linkNames = new Dictionary<string, RevitLinkType>();
                            var linkTypes = new FilteredElementCollector(hostDoc).OfClass(typeof(RevitLinkType)).ToElements();
                            foreach (RevitLinkType linkType in linkTypes)
                            {
                                linkNames.Add(linkType.Name.Replace(".rvt", ""), linkType);
                            }

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                try
                                {
                                    if (row.Cells["Upgrade"].Value.ToString() == "True" &&
                                        row.Cells["Upgrade Result"].Value.ToString() == "True" &&
                                        File.Exists(row.Cells["New Path"].Value.ToString()) &&
                                        linkNames.Keys.Contains(row.Cells["Original Name"].Value.ToString()))
                                    {
                                        try
                                        {

                                            RevitLinkType linkToReload = linkNames[row.Cells["Original Name"].Value.ToString().Replace(".rvt", "")];
                                            ModelPath modelPathToLoadFrom = ModelPathUtils.ConvertUserVisiblePathToModelPath(row.Cells["New Path"].Value.ToString());
                                            linkToReload.LoadFrom(modelPathToLoadFrom, new WorksetConfiguration());
                                        }
                                        catch (Exception e)
                                        {
                                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                                            MessageBox.Show(String.Format("Could not remap the link named {0} in the host file", row.Cells["Original Name"].Value.ToString()));
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                }
                                catch { continue; }

                            }
                            RVTOperations.SaveRevitFile(uiApp, hostDoc, true);
                        }
                        catch (Exception e) { MessageBox.Show(e.ToString()); }
                    }
                }
                else
                {
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.Red;
                }
                uiForm.Update();
                uiForm.Refresh();
            }
        }
    }
}
