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
    class MiscEDVRequest
    {
        public MiscEDVRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            if (uiForm.miscEDVSelectDirectoryTextBox.Text != "")
            {
                string[] illegalCharacters = { "<", ">", ":", "/", @"\", @"|", "?", "*" };
                List<ViewDrafting> viewsToUse = new List<ViewDrafting>();
                foreach (DataGridViewRow row in uiForm.miscEDVDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        DataRow dgvRow = (row.DataBoundItem as DataRowView).Row;
                        viewsToUse.Add(dgvRow["View Element"] as ViewDrafting);
                    }
                }

                int filesToProcess = viewsToUse.Count;
                uiForm.miscEDVProgressBar.Value = 0;
                uiForm.miscEDVProgressBar.Minimum = 0;
                uiForm.miscEDVProgressBar.Maximum = filesToProcess;
                uiForm.miscEDVProgressBar.Step = 1;
                uiForm.miscEDVProgressBar.Visible = true;


                foreach (ViewDrafting fromView in viewsToUse)
                {
                    RVTDocument newDoc = uiApp.Application.NewProjectDocument(UnitSystem.Imperial);
                    Transaction t1 = new Transaction(newDoc, "ExportDraftingViews");
                    t1.Start();
                    SubTransaction s1 = new SubTransaction(newDoc);
                    s1.Start();
                    FilteredElementCollector collector = new FilteredElementCollector(newDoc);
                    collector.OfClass(typeof(ViewFamilyType));
                    ViewFamilyType viewFamilyType = collector.Cast<ViewFamilyType>().First(vft => vft.ViewFamily == ViewFamily.Drafting);
                    ViewDrafting toView = ViewDrafting.Create(newDoc, viewFamilyType.Id);
                    s1.Commit();
                    List<ElementId> viewElementIds = new FilteredElementCollector(uidoc.Document, fromView.Id).ToElementIds().Cast<ElementId>().ToList();
                    CopyPasteOptions copyPasteOptions = new CopyPasteOptions();
                    copyPasteOptions.SetDuplicateTypeNamesHandler(new RVTDuplicateTypesHandler());
                    ElementTransformUtils.CopyElements(fromView, viewElementIds, toView, null, copyPasteOptions);
                    t1.Commit();

                    ElementId viewPreviewId = null;
                    var newDocViews = new FilteredElementCollector(newDoc).OfClass(typeof(ViewDrafting)).ToElements().Cast<Element>().ToList();
                    foreach (ViewDrafting newDocView in newDocViews)
                    {
                        if (newDocView.Name == fromView.Name)
                        {
                            viewPreviewId = newDocView.Id;
                            break;
                        }
                    }

                    SaveAsOptions saveAsOptions = new SaveAsOptions();
                    saveAsOptions.Compact = true;
                    saveAsOptions.MaximumBackups = 1;
                    saveAsOptions.OverwriteExistingFile = true;
                    saveAsOptions.PreviewViewId = viewPreviewId;

                    string fileName = fromView.Name.Replace("\"", "").Replace(".", "");
                    foreach (string item in illegalCharacters)
                    {
                        if (fileName.Contains(item))
                        {
                            fileName.Replace(item, "");
                        }
                    }

                    string savePath = uiForm.miscEDVSelectDirectoryTextBox.Text + "\\" + fileName + ".rvt";
                    if (File.Exists(savePath))
                    {
                        try
                        {
                            File.Delete(savePath);
                        }
                        catch { continue; }
                    }
                    newDoc.SaveAs(savePath, saveAsOptions);
                    newDoc.Close(false);
                    uiForm.miscEDVProgressBar.PerformStep();
                }
            }
            else
            {
                MessageBox.Show("No save directory is set. Please pick a directory.");
            }
        }
    }
}
