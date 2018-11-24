using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
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
                string currentLibraryPath = Properties.Settings.Default.BARTBARevitFamilyLibraryPath;
                string upgradedLibraryPath = currentLibraryPath.Replace(currentVersion, upgradedVersion);
                if (!Directory.Exists(upgradedLibraryPath)) { Directory.CreateDirectory(upgradedLibraryPath); }

                GeneralOperations.CleanRfaBackups(currentLibraryPath);
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);

                List<string> familiesInCurrentLibrary = GeneralOperations.GetAllRvtFamilies(currentLibraryPath);
                Dictionary<string, string> currentLibraryDict = new Dictionary<string, string>();
                List<string> familiesInUpgradedLibrary = GeneralOperations.GetAllRvtFamilies(upgradedLibraryPath);
                Dictionary<string, string> upgradedLibraryDict = new Dictionary<string, string>();
                List<string> familiesToUpgrade = new List<string>();
                List<string> familiesToDelete = new List<string>();
                List<string> upgradedFamilies = new List<string>();
                List<string> deletedFamilies = new List<string>();

                string currentEvaluation = "";
                if (familiesInUpgradedLibrary.Count > 0)
                {
                    foreach (string upgradedFamilyPath in familiesInUpgradedLibrary)
                    {
                        try
                        {
                            currentEvaluation = Path.GetFileNameWithoutExtension(upgradedFamilyPath);
                            upgradedLibraryDict.Add(Path.GetFileNameWithoutExtension(upgradedFamilyPath), upgradedFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                foreach (string currentFamilyPath in familiesInCurrentLibrary)
                {
                    if (!currentFamilyPath.Contains("Archive") && !currentFamilyPath.Contains("Backup"))
                    {
                        try
                        {
                            currentEvaluation = Path.GetFileNameWithoutExtension(currentFamilyPath);
                            currentLibraryDict.Add(Path.GetFileNameWithoutExtension(currentFamilyPath), currentFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                if (familiesInUpgradedLibrary.Count > 0)
                {
                    foreach (string upgradedFamily in upgradedLibraryDict.Keys)
                    {
                        if (currentLibraryDict.Keys.Contains(upgradedFamily))
                        {
                            DateTime currentFamilyWriteTime = File.GetLastWriteTime(currentLibraryDict[upgradedFamily]);
                            DateTime upgradedFamilyWriteTime = File.GetLastWriteTime(upgradedLibraryDict[upgradedFamily]);
                            if (currentFamilyWriteTime > upgradedFamilyWriteTime)
                            {
                                familiesToUpgrade.Add(currentLibraryDict[upgradedFamily]);
                            }
                        }
                        else
                        {
                            familiesToDelete.Add(upgradedLibraryDict[upgradedFamily]);
                        }
                    }

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
                    familiesToUpgrade = familiesInCurrentLibrary;
                }

                foreach (string familyToUpgrade in familiesToUpgrade)
                {
                    try
                    {
                        if (RVTOperations.RevitVersionUpgradeCheck(uiApp, familyToUpgrade, true))
                        {
                            bool result = RVTOperations.UpgradeRevitFile(uiApp, familyToUpgrade, familyToUpgrade.Replace(currentVersion, upgradedVersion), true);
                            if (result == true)
                            {
                                upgradedFamilies.Add(Path.GetFileNameWithoutExtension(familyToUpgrade));
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("{0} was saved in a new version of Revit", Path.GetFileNameWithoutExtension(familyToUpgrade)));
                        }
                    }
                    catch (Exception f)
                    { MessageBox.Show(f.ToString()); }
                }

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

                uiForm.adminFamiliesUFUpgradedFamiliesListBox.DataSource = upgradedFamilies;
                uiForm.adminFamiliesUFDeletedFamiliesListBox.DataSource = deletedFamilies;
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            }
        }
    }
}
