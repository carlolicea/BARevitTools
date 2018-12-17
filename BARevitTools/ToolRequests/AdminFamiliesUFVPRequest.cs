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
    class AdminFamiliesUFVPRequest
    {
        public AdminFamiliesUFVPRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Clear out the backup families from the directory
            List<string> backupFamilies = GeneralOperations.GetAllRvtBackupFamilies(uiForm.adminFamiliesUFVPDirectoryTextBox.Text);
            GeneralOperations.CleanRfaBackups(backupFamilies);

            //Get the family files from the directory. If the option to use the date since last modified was checked, use the first method, else use the second method
            List<string> familyFiles = new List<string>();
            if (uiForm.adminFamiliesUFVPCheckBox.Checked)
            {
                familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesUFVPDirectoryTextBox.Text, uiForm.adminFamiliesUFVPDatePicker.Value, true);
            }
            else
            {
                familyFiles = GeneralOperations.GetAllRvtFamilies(uiForm.adminFamiliesUFVPDirectoryTextBox.Text);
            }
           
            //Verify the number of families collected is more than 0
            if (familyFiles.Count > 0)
            {
                
                try
                {
                    //Make a dictionary of the shared parameter names and definitions for use later.
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
                    // If the shared parameters file is not accessible, set to false
                    catch { sharedParametersIsAccessible = false; }

                    //Reset and prepare the progress bar
                    uiForm.adminFamiliesUFVPProgressBar.Value = 0;
                    uiForm.adminFamiliesUFVPProgressBar.Minimum = 0;
                    uiForm.adminFamiliesUFVPProgressBar.Maximum = familyFiles.Count;
                    uiForm.adminFamiliesUFVPProgressBar.Step = 1;
                    uiForm.adminFamiliesUFVPProgressBar.Visible = true;
                    
                    //Only proceed if the shared parameters file was accessible and the version parameter exists in the shared parameters
                    if (sharedParametersIsAccessible && sharedParameterDefinitions.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                    {
                        foreach (string familyFile in familyFiles)
                        {
                            //The AdminFamiliesUFVPRequest.SetParameters() method will set the parameter value 
                            SetParameters(uiApp, familyFile, sharedParameterDefinitions[Properties.Settings.Default.RevitUFVPParameter]);
                            uiForm.adminFamiliesUFVPProgressBar.PerformStep();
                        }
                        
                    }
                    //If the shared parameter does not exist, let the user know. It will need to be made first
                    else if (sharedParametersIsAccessible && !sharedParameterDefinitions.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                    {                        
                        MessageBox.Show(String.Format("Could not get the shared parameter '{0}' in the shared parameters file located at {1}. Please verify its existence",Properties.Settings.Default.RevitUFVPParameter,definitionFile.Filename));
                    }
                    //If the shared parameters file itself could not be accessed, inform the user.
                    else { MessageBox.Show("Could not open the shared parameters file. Verify it is loaded in the Manage Tab > Shared Parameters"); }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }   
                finally
                {
                    //Go back through the directory where the families are located and clean up the backups made from saving them after the parameter value was set.
                    List<string> backupFamilies2 = GeneralOperations.GetAllRvtBackupFamilies(uiForm.adminFamiliesUFVPDirectoryTextBox.Text);
                    GeneralOperations.CleanRfaBackups(backupFamilies2);
                }
            }
        }

        private void SetParameters(UIApplication uiApp, string familyFile, ExternalDefinition externalDefinition)
        {
            try
            {
                //Get the FileInfo of the family file and then get the LastWriteTime value as a date string in MM/DD/YYYY format
                FileInfo fileInfo = new FileInfo(familyFile);
                string lastModified = fileInfo.LastWriteTime.ToShortDateString();

                //Open the family file
                RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFile);
                if (famDoc!=null)
                {
                    //Get the family manager for the family file
                    FamilyManager famMan = famDoc.FamilyManager;
                    //Get the family parameters and add them to a dictionary indexed by parameter name
                    FamilyParameter famParameter = null;
                    Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
                    foreach (FamilyParameter famParam in famMan.Parameters)
                    {
                        famParamDict.Add(famParam.Definition.Name, famParam);
                    }

                    //Get the number of family types because there must be at least one family type to make this work
                    FamilyTypeSet types = famMan.Types;
                    int numberOfTypes = types.Size;

                    Transaction t1 = new Transaction(famDoc, "SetParameters");
                    t1.Start();
                    if (numberOfTypes == 0)
                    {
                        //If the number of family types was 0, then one must be made. Thus Default is a family type created
                        try
                        {
                            famMan.NewType("Default");
                        }
                        catch { MessageBox.Show(String.Format("Could not make a default type or find any type for {0}", familyFile)); }
                    }

                    //Once the existence of a family type is confirmed, move on with determining if the version parameter already exists. If it doesn't add the parameter to the family and regenerate the document
                    if (!famParamDict.Keys.Contains(BARevitTools.Properties.Settings.Default.RevitUFVPParameter))
                    {
                        famParameter = famMan.AddParameter(externalDefinition, BuiltInParameterGroup.PG_IDENTITY_DATA, false);
                        famDoc.Regenerate();
                    }
                    else
                    {
                        famParameter = famParamDict[BARevitTools.Properties.Settings.Default.RevitUFVPParameter];
                    }
                    //Set the formula of the version parameter to the quote encapsulated date, just like it would appear in Revit, commit it, then save.
                    famMan.SetFormula(famParameter, "\""+lastModified+"\"");                      
                    t1.Commit();
                    RVTOperations.SaveRevitFile(uiApp, famDoc, true);
                }
                else
                {
                    //If the family could not be opened for any reason, let the user know
                    MessageBox.Show(String.Format("{0} could not be opened.", familyFile));
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }            
        }
    }
}
