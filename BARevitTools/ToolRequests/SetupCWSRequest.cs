using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Create Worksets tool which automates creation of worksets and saving central files
    class SetupCWSRequest
    {
        public SetupCWSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Make the transaction options
            TransactWithCentralOptions TWCOptions = new TransactWithCentralOptions();
            //Make the relinquish options
            RelinquishOptions relinquishOptions = new RelinquishOptions(true);
            //Make the synchronization options
            SynchronizeWithCentralOptions SWCOptions = new SynchronizeWithCentralOptions();
            SWCOptions.Compact = true;
            SWCOptions.SetRelinquishOptions(relinquishOptions);
            //Make the worksharing SaveAs options
            WorksharingSaveAsOptions worksharingSaveOptions = new WorksharingSaveAsOptions();
            worksharingSaveOptions.SaveAsCentral = true;
            worksharingSaveOptions.OpenWorksetsDefault = SimpleWorksetConfiguration.AllWorksets;
            //Make the save options
            SaveOptions projectSaveOptions = new SaveOptions();
            projectSaveOptions.Compact = true;
            //Finally, make the SaveAs options
            SaveAsOptions projectSaveAsOptions = new SaveAsOptions();
            projectSaveAsOptions.Compact = true;
            projectSaveAsOptions.OverwriteExistingFile = true;
            projectSaveAsOptions.SetWorksharingOptions(worksharingSaveOptions);

            //The worksetsToAdd list will the names of the worksets to create
            List<string> worksetsToAdd = new List<string>();
            //Collect the names of the worksets from the defaults
            foreach (string item in uiForm.setupCWSDefaultListBox.Items)
            {
                worksetsToAdd.Add(item);
            }
            //Collect any names selected in the extended list
            foreach (string item in uiForm.setupCWSExtendedListBox.CheckedItems)
            {
                worksetsToAdd.Add(item);
            }
            //Collect the names of any user defined worksets 
            foreach (DataGridViewRow row in uiForm.setupCWSUserDataGridView.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() != "")
                    { worksetsToAdd.Add(row.Cells[0].Value.ToString()); }
                }
                catch { continue; }
            }

            //Collect all worksets in the current project
            List<Workset> worksets = new FilteredWorksetCollector(doc).Cast<Workset>().ToList();
            List<string> worksetNames = new List<string>();

            //Cycle through the worksets in the project
            if (worksets.Count>0)
            {
                foreach (Workset workset in worksets)
                {
                    //If Workset1 exists, rename it Arch
                    if (workset.Name == "Workset1")
                    {
                        try
                        {
                            WorksetTable.RenameWorkset(doc, workset.Id, "Arch");
                            worksetNames.Add("Arch");
                            break;
                        }
                        catch { continue; }
                    }
                    else { worksetNames.Add(workset.Name); }
                }
            }            

            //If the file has been saved and is workshared, continue
            if (doc.IsWorkshared && doc.PathName != "")
            {
                //Start a transaction
                Transaction t1 = new Transaction(doc, "CreateWorksets");
                t1.Start();
                //For each workset name in the list of worksets to add, continue
                foreach (string worksetName in worksetsToAdd)
                {
                    //If the list of existing worksets does not contain the workset to make, continue
                    if (!worksetNames.Contains(worksetName))
                    {
                        //Create the new workset
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();
                
                try
                {
                    //Save the project with the save options, then synchronize
                    doc.Save(projectSaveOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
                catch
                {
                    //Else, try using the SaveAs method, then synchronize
                    doc.SaveAs(doc.PathName, projectSaveAsOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
            }

            //If the project has been saved and the document is not workshared, continue
            else if (!doc.IsWorkshared && doc.PathName != "")
            {
                //Make the document workshared and set the default worksets
                doc.EnableWorksharing("Shared Levels and Grids", "Arch");
                //Add the default worksets to the list of pre-existing worksets
                worksetNames.Add("Shared Levels and Grids");
                worksetNames.Add("Arch");

                //Start the transaction
                Transaction t1 = new Transaction(doc, "MakeWorksets");
                t1.Start();
                foreach (string worksetName in worksetsToAdd)
                {
                    //Create the workset if it does not exist in the list of pre-existing worksets
                    if (!worksetNames.Contains(worksetName))
                    {
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();
                //Use the SaveAs method for saving the file, then synchronize
                doc.SaveAs(doc.PathName, projectSaveAsOptions);
                doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
            }
            else
            {
                //If the project has not been saved, let the user know to save it first somewhere
                MessageBox.Show("Project file needs to be saved somewhere before it can be made a central model");
            }
        }
    }
}
