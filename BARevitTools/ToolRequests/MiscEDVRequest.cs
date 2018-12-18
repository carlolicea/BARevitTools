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
    //
    //This class is responsible for the Export Drafting Views tool which saves out each drafting view to a file
    class MiscEDVRequest
    {
        public MiscEDVRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            if (uiForm.miscEDVSelectDirectoryTextBox.Text != "")
            {
                //Create a list for storing drafting views to export
                List<ViewDrafting> viewsToUse = new List<ViewDrafting>();
                foreach (DataGridViewRow row in uiForm.miscEDVDataGridView.Rows)
                {
                    //If the rows's Select column checkbox is checked, get the element and add it to the views to use
                    if (row.Cells["Select"].Value.ToString() == "True")
                    {
                        DataRow dgvRow = (row.DataBoundItem as DataRowView).Row;
                        viewsToUse.Add(dgvRow["View Element"] as ViewDrafting);
                    }
                }

                //Preparing the progress bar
                int filesToProcess = viewsToUse.Count;
                uiForm.miscEDVProgressBar.Value = 0;
                uiForm.miscEDVProgressBar.Minimum = 0;
                uiForm.miscEDVProgressBar.Maximum = filesToProcess;
                uiForm.miscEDVProgressBar.Step = 1;
                uiForm.miscEDVProgressBar.Visible = true;

                //For each drafting view to export...
                foreach (ViewDrafting fromView in viewsToUse)
                {
                    //Make a new Revit document file
                    RVTDocument newDoc = uiApp.Application.NewProjectDocument(UnitSystem.Imperial);

                    //Start the transaction
                    Transaction t1 = new Transaction(newDoc, "ExportDraftingViews");
                    t1.Start();

                    //Start a subtransaction
                    SubTransaction s1 = new SubTransaction(newDoc);
                    s1.Start();
                    //In the new file, get the first view family type that is a drafting view type
                    FilteredElementCollector collector = new FilteredElementCollector(newDoc);
                    collector.OfClass(typeof(ViewFamilyType));
                    ViewFamilyType viewFamilyType = collector.Cast<ViewFamilyType>().First(vft => vft.ViewFamily == ViewFamily.Drafting);
                    //In the new file, make a new drafting view using the view family type found in it
                    ViewDrafting toView = ViewDrafting.Create(newDoc, viewFamilyType.Id);
                    //Commit the sub transaction
                    s1.Commit();

                    //Now the the drafting view exists in the new file, collect the elements in the originating drafting view
                    List<ElementId> viewElementIds = new FilteredElementCollector(uidoc.Document, fromView.Id).ToElementIds().Cast<ElementId>().ToList();
                    CopyPasteOptions copyPasteOptions = new CopyPasteOptions();
                    copyPasteOptions.SetDuplicateTypeNamesHandler(new RVTDuplicateTypesHandler());
                    //Copy and paste the elements from the originating drafting view into the new file's drafting view
                    ElementTransformUtils.CopyElements(fromView, viewElementIds, toView, null, copyPasteOptions);
                    t1.Commit();

                    //Find the newly created drafting view's ID so the view can be used as the preview view when saving the new project file
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

                    //Set the SaveAsOptions as follows, including the PreviewViewId
                    SaveAsOptions saveAsOptions = new SaveAsOptions();
                    saveAsOptions.Compact = true;
                    saveAsOptions.MaximumBackups = 1;
                    saveAsOptions.OverwriteExistingFile = true;
                    saveAsOptions.PreviewViewId = viewPreviewId;

                    //The string array of illegal characters in the name is used to determine 
                    string[] illegalCharacters = { "<", ">", ":", "/", @"\", @"|", "?", "*" };
                    //Also remove quotation marks and periods from the view name
                    string fileName = fromView.Name.Replace("\"", "").Replace(".", "");
                    //For each illegal character in the string array, remove it from the view name if it exists
                    foreach (string item in illegalCharacters)
                    {
                        if (fileName.Contains(item))
                        {
                            fileName.Replace(item, "");
                        }
                    }

                    //With a cleaned view name for saving to a file, save the new project file containing the new drafting view with the cleaned name
                    string savePath = uiForm.miscEDVSelectDirectoryTextBox.Text + "\\" + fileName + ".rvt";
                    if (File.Exists(savePath))
                    {
                        try
                        {
                            //Delete the file if it already exists
                            File.Delete(savePath);
                        }
                        catch { continue; }
                    }
                    newDoc.SaveAs(savePath, saveAsOptions);
                    newDoc.Close(false);
                    //Step forward the progress bar.
                    uiForm.miscEDVProgressBar.PerformStep();
                }
            }
            else
            {
                //If the user forgot to set the directory of where to export the drafting views, let them know
                MessageBox.Show("No save directory is set. Please pick a directory.");
            }
        }
    }
}
