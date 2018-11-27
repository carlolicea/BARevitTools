using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class SetupCWSRequest
    {
        public SetupCWSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            TransactWithCentralOptions TWCOptions = new TransactWithCentralOptions();
            RelinquishOptions relinquishOptions = new RelinquishOptions(true);
            SynchronizeWithCentralOptions SWCOptions = new SynchronizeWithCentralOptions();
            SWCOptions.Compact = true;
            SWCOptions.SetRelinquishOptions(relinquishOptions);
            WorksharingSaveAsOptions worksharingSaveOptions = new WorksharingSaveAsOptions();
            worksharingSaveOptions.SaveAsCentral = true;
            worksharingSaveOptions.OpenWorksetsDefault = SimpleWorksetConfiguration.AllWorksets;
            SaveOptions projectSaveOptions = new SaveOptions();
            projectSaveOptions.Compact = true;
            SaveAsOptions projectSaveAsOptions = new SaveAsOptions();
            projectSaveAsOptions.Compact = true;
            projectSaveAsOptions.OverwriteExistingFile = true;
            projectSaveAsOptions.SetWorksharingOptions(worksharingSaveOptions);

            List<string> worksetsToAdd = new List<string>();
            foreach (string item in uiForm.setupCWSDefaultListBox.Items)
            {
                worksetsToAdd.Add(item);
            }
            foreach (string item in uiForm.setupCWSExtendedListBox.CheckedItems)
            {
                worksetsToAdd.Add(item);
            }
            foreach (DataGridViewRow row in uiForm.setupCWSUserDataGridView.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() != "")
                    { worksetsToAdd.Add(row.Cells[0].Value.ToString()); }
                }
                catch { continue; }
            }

            List<Workset> worksets = new FilteredWorksetCollector(doc).Cast<Workset>().ToList();
            List<string> worksetNames = new List<string>();

            foreach (Workset workset in worksets)
            {
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

            if (doc.IsWorkshared && doc.PathName != "")
            {
                Transaction t1 = new Transaction(doc, "CreateWorksets");
                t1.Start();
                foreach (string worksetName in worksetsToAdd)
                {
                    if (!worksetNames.Contains(worksetName))
                    {
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();

                try
                {
                    doc.Save(projectSaveOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
                catch
                {
                    doc.SaveAs(doc.PathName, projectSaveAsOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
            }
            else if (!doc.IsWorkshared && doc.PathName != "")
            {
                doc.EnableWorksharing("Shared Levels and Grids", "Arch");
                worksetNames.Add("Shared Levels and Grids");
                worksetNames.Add("Arch");
                Transaction t1 = new Transaction(doc, "MakeWorksets");
                t1.Start();
                foreach (string worksetName in worksetsToAdd)
                {
                    if (!worksetNames.Contains(worksetName))
                    {
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();
                doc.SaveAs(doc.PathName, projectSaveAsOptions);
                doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
            }
            else
            {
                MessageBox.Show("Project file needs to be saved somewhere before it can be made a central model");
            }
        }
    }
}
