using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class AdminFamiliesUFRequest
    {
        public AdminFamiliesUFRequest(UIApplication uiApp, String text)
        {
            try
            {
                MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                bool fullSync = uiForm.adminFamiliesUFFullSyncCheckbox.Checked;
                string currentVersion = Properties.Settings.Default.BARTRevitFamilyCurrentYear;
                string upgradedVersion = uiApp.Application.VersionNumber;
                //The current library path is needed to make the new library path by swapping the year of the current development library with the year of the Revit version running.
                string currentLibraryPath = Properties.Settings.Default.RevitBAFamilyLibraryPath;
                string upgradedLibraryPath = currentLibraryPath.Replace(currentVersion, upgradedVersion);
                //If the new library does not yet exist, make it. This will likely be used only once when a new version of Revit is released.
                if (!Directory.Exists(upgradedLibraryPath)) { Directory.CreateDirectory(upgradedLibraryPath); }

                //Do some cleanup in the current library and the new library if backups exist 
                GeneralOperations.CleanRfaBackups(currentLibraryPath);
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);

                //Create a list of family paths in the current library, and a list of family paths in the new library.
                List<string> familiesInCurrentLibrary = GeneralOperations.GetAllRvtFamilies(currentLibraryPath);
                //Also, make a dictionary because while the family paths will be evaluated, the paths themselves will need to be retrieved later by family name.
                Dictionary<string, string> currentLibraryDict = new Dictionary<string, string>();
                List<string> familiesInUpgradedLibrary = GeneralOperations.GetAllRvtFamilies(upgradedLibraryPath);
                Dictionary<string, string> upgradedLibraryDict = new Dictionary<string, string>();
                List<string> familiesToUpgrade = new List<string>();
                List<string> familiesToDelete = new List<string>();
                List<string> upgradedFamilies = new List<string>();
                List<string> deletedFamilies = new List<string>();

                //Just a variable for storing which family name is currently being evaluated
                string currentEvaluation = "";
                //If there are families in the new library...
                if (familiesInUpgradedLibrary.Count > 0)
                {
                    foreach (string upgradedFamilyPath in familiesInUpgradedLibrary)
                    {
                        try
                        {
                            //Get the name of the family and add it as a key in the dictionary, along with the family path
                            currentEvaluation = Path.GetFileNameWithoutExtension(upgradedFamilyPath);
                            upgradedLibraryDict.Add(Path.GetFileNameWithoutExtension(upgradedFamilyPath), upgradedFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                //Next, evaluate what families are in the current library
                foreach (string currentFamilyPath in familiesInCurrentLibrary)
                {
                    //Skip any path that contains "Archive" or "Backup"
                    if (!currentFamilyPath.Contains("Archive") && !currentFamilyPath.Contains("Backup"))
                    {
                        try
                        {
                            //Add the name off the family to dictionary as a key assigned the path
                            currentEvaluation = Path.GetFileNameWithoutExtension(currentFamilyPath);
                            currentLibraryDict.Add(Path.GetFileNameWithoutExtension(currentFamilyPath), currentFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                //Going back to the families in the new library
                if (familiesInUpgradedLibrary.Count > 0)
                {
                    //Evaluate each family name serving as a key in the dictionary for the new library
                    foreach (string upgradedFamily in upgradedLibraryDict.Keys)
                    {
                        //If the current library dictionary has a key with the same family name...
                        if (currentLibraryDict.Keys.Contains(upgradedFamily))
                        {
                            //Compare the dates when the families were last modified to determine if the one in the new library is older than the one in the current library
                            DateTime currentFamilyWriteTime = File.GetLastWriteTime(currentLibraryDict[upgradedFamily]);
                            DateTime upgradedFamilyWriteTime = File.GetLastWriteTime(upgradedLibraryDict[upgradedFamily]);
                            //If the familly in the current library is more recently modified, add it to the list of families that will need upgraded and saved to the new library, thus replacing the one in the new library with the updated one
                            if (currentFamilyWriteTime > upgradedFamilyWriteTime)
                            {
                                familiesToUpgrade.Add(currentLibraryDict[upgradedFamily]);
                            }
                        }
                        else
                        {
                            //Otherwise, if the family in the new library does not exist in the current library, add it to a list of families to delete if a full sync is performed
                            familiesToDelete.Add(upgradedLibraryDict[upgradedFamily]);
                        }
                    }

                    //If the new library does not contain the family in the current library, add it to the list of families to upgrade and save to the new library.
                    foreach (string originalFamily in currentLibraryDict.Keys)
                    {
                        if (!upgradedLibraryDict.Keys.Contains(originalFamily))
                        {
                            familiesToUpgrade.Add(currentLibraryDict[originalFamily]);
                        }
                    }
                }
                else
                {
                    //If there are no families in the new library, such as one that was just created for a new version of Revit, then all families from the current library will need upgraded and saved in the new library
                    familiesToUpgrade = familiesInCurrentLibrary;
                }

                //Cycle through all of the families that will need to be upgraded and saved to the new library
                foreach (string familyToUpgrade in familiesToUpgrade)
                {
                    try
                    {
                        //First, determine if the family can be opened and is not a newer version of Revit
                        if (RVTOperations.RevitVersionUpgradeCheck(uiApp, familyToUpgrade, true))
                        {
                            //If it can be opened, upgrade it and add its name to the list of families that were upgraded
                            bool result = RVTOperations.UpgradeRevitFile(uiApp, familyToUpgrade, familyToUpgrade.Replace(currentVersion, upgradedVersion), true);
                            if (result == true)
                            {
                                upgradedFamilies.Add(Path.GetFileNameWithoutExtension(familyToUpgrade));
                            }
                        }
                        else
                        {
                            //If the family could not be opened because it was saved in a newer version of Revit, let the user know and skip over the family
                            MessageBox.Show(String.Format("{0} was saved in a new version of Revit", Path.GetFileNameWithoutExtension(familyToUpgrade)));
                        }
                    }
                    catch (Exception f)
                    { MessageBox.Show(f.ToString()); }
                }

                //If the user checked the box to do a full sync, delete the families that were added to the list of families to delete. This will ensure the new library and current library match regarding what families they contain
                if (fullSync)
                {
                    foreach (string familyToDelete in familiesToDelete)
                    {
                        try
                        {
                            File.Delete(familyToDelete);
                            deletedFamilies.Add(Path.GetFileNameWithoutExtension(familyToDelete));
                        }
                        catch (Exception e)
                        { MessageBox.Show(e.ToString()); }
                    }
                }
                //Update the listboxes of the UI showing what families were upgraded and what were deleted
                uiForm.adminFamiliesUFUpgradedFamiliesListBox.DataSource = upgradedFamilies;
                uiForm.adminFamiliesUFDeletedFamiliesListBox.DataSource = deletedFamilies;
                //Cleanup the family backups in the new library if they exist
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            }
        }
    }
}
