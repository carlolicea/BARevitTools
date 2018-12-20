using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class SetupUPRequest
    {
        //
        //This class is associated with the Upgrade Projects tool
        public SetupUPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            dgv.EndEdit();

            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            string hostFilePathToUpgrade = uiForm.setupUPOriginalFilePathTextBox.Text;
            string hostFilePathForUpgrade = uiForm.setupUPUpgradedFilePathSetTextBox.Text + "\\" + uiForm.setupUPUpgradedFilePathUserTextBox.Text + ".rvt";
            
            //Reset the progress bar
            uiForm.setupUPProgressBar.Value = 0;
            uiForm.setupUPProgressBar.Minimum = 0;
            uiForm.setupUPProgressBar.Step = 1;

            //Determine the number of steps for the progress bar based on the number of links checked for upgrading plus 1 for the host
            int progressBarSteps = 1;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Upgrade"].Value != null)
                {
                    if (row.Cells["Upgrade"].Value.ToString() == "True")
                    {
                        progressBarSteps++;
                    }                    
                }
            }
            uiForm.setupUPProgressBar.Maximum = progressBarSteps;

            //Let the user know if they are trying to save over a file that already exists
            if (File.Exists(hostFilePathForUpgrade))
            {
                MessageBox.Show("A file already exists with the name and location specified for the upgrade of the host Revit project file");
            }
            //If they didn't set a save location for the file, let them know
            else if (uiForm.setupUPUpgradedFilePathUserTextBox.Text == "")
            {
                MessageBox.Show("No location for the upgrade of the host Revit project file is set");
            }
            else
            {
                //Otherwise, show the progress bar and step through the rows of the DataGridView links
                uiForm.setupUPProgressBar.Visible = true;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        if (dgv.Rows[i].Cells["Upgrade"].Value != null)
                        {
                            //If the link is allowed to be upgraded, and its checkbox is checked, continue
                            if (dgv.Rows[i].Cells["Allow Upgrade"].Value.ToString() == "True" && dgv.Rows[i].Cells["Upgrade"].Value.ToString() == "True")
                            {
                                //Grab the orignial path for the link and the path for where it will be saved
                                string linkFilePathToUpgrade = dgv.Rows[i].Cells["Original Path"].Value.ToString();
                                string linkFilePathForUpgrade = dgv.Rows[i].Cells["New Path"].Value.ToString();
                                //Perform the upgrade operations on the file and report if it was successful
                                bool linkResult = RVTOperations.UpgradeRevitFile(uiApp, linkFilePathToUpgrade, linkFilePathForUpgrade, false);
                                
                                if (linkResult == true)
                                {
                                    //If the upgrade was successful, set the Upgrade Result column to true and set the row's background color to GreenYellow
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = true;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
                                }
                                else
                                {
                                    //If the upgrade failed, set the Upgrade Result column to false and set the background color to red
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = false;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                                //Step forward the progress bar
                                uiForm.setupUPProgressBar.PerformStep();
                                uiForm.Update();
                            }
                        }
                        else { continue; }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }

                //Once the links are done upgrading, upgrade the host
                bool hostResult = RVTOperations.UpgradeRevitFile(uiApp, hostFilePathToUpgrade, hostFilePathForUpgrade, false);
                //Determine how many links were able to be upgraded
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
                    catch
                    {
                        continue;
                    }
                    finally
                    {
                        uiForm.setupUPProgressBar.PerformStep();
                        uiForm.Update();
                    }
                }

                //If the host was able to be upgraded, continue
                if (hostResult == true)
                {
                    //Set the background color of the text box to GreenYellow
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.GreenYellow;
                    if (countOfUpgradeLinks > 0)
                    {
                        try
                        {
                            //Open the upgraded host and get the links
                            RVTDocument hostDoc = RVTOperations.OpenRevitFile(uiApp, hostFilePathForUpgrade);
                            Dictionary<string, RevitLinkType> linkNames = new Dictionary<string, RevitLinkType>();
                            var linkTypes = new FilteredElementCollector(hostDoc).OfClass(typeof(RevitLinkType)).ToElements();
                            foreach (RevitLinkType linkType in linkTypes)
                            {
                                //Add each link to a dictionary with their file name and indexed link type
                                linkNames.Add(linkType.Name.Replace(".rvt", ""), linkType);
                            }

                            //Cycle through the links 
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                try
                                {
                                    //If the link's row was checked for upgrading, it was able to be upgraded, the upgraded file exists at the New Path location, and the dictionary of links contains the original name of the link, continue
                                    if (row.Cells["Upgrade"].Value.ToString() == "True" &&
                                        row.Cells["Upgrade Result"].Value.ToString() == "True" &&
                                        File.Exists(row.Cells["New Path"].Value.ToString()) &&
                                        linkNames.Keys.Contains(row.Cells["Original Name"].Value.ToString()))
                                    {
                                        try
                                        {
                                            //Get the link to reload via the name from the dictionary
                                            RevitLinkType linkToReload = linkNames[row.Cells["Original Name"].Value.ToString().Replace(".rvt", "")];
                                            //Convert the link's user path to a model path, then reload it
                                            ModelPath modelPathToLoadFrom = ModelPathUtils.ConvertUserVisiblePathToModelPath(row.Cells["New Path"].Value.ToString());
                                            linkToReload.LoadFrom(modelPathToLoadFrom, new WorksetConfiguration());
                                        }
                                        catch (Exception e)
                                        {
                                            //If the link was upgraded but could not be reloaded, set the background color to orange and let the user know it could not be reloaded
                                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                                            MessageBox.Show(String.Format("Could not remap the link named {0} in the host file", row.Cells["Original Name"].Value.ToString()));
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                }
                                catch { continue; }

                            }
                            //Save the upgraded host file
                            RVTOperations.SaveRevitFile(uiApp, hostDoc, true);
                        }
                        catch (Exception e) { MessageBox.Show(e.ToString()); }
                    }
                }
                else
                {
                    //If the host file failed to upgrade, set its text box background color to red
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.Red;
                }
                uiForm.Update();
                uiForm.Refresh();
            }
        }
    }
}
