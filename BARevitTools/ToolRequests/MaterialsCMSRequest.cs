using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class MaterialsCMSRequest
    {
        public MaterialsCMSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.materialsCMSExcelDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            uiForm.materialsCMSExcelCreateSymbolsProgressBar.Value = 0;
            int columnCount = dgv.Columns.Count;
            int rowCount = dgv.Rows.Count;

            string familyFile = Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule;
            string versionedFamilyFile = RVTOperations.GetVersionedFamilyFilePath(uiApp, familyFile);
            if (versionedFamilyFile != "")
            {
                RVTDocument famDoc = RVTOperations.CreateFamilyTypesFromTable(uiApp, uiForm.materialsCMSExcelCreateSymbolsProgressBar, uiForm.materialsCMSExcelDataGridView, versionedFamilyFile);
                ViewDrafting placementView = null;
                var draftingViews = new FilteredElementCollector(doc).OfClass(typeof(ViewDrafting)).WhereElementIsNotElementType().ToElements();
                ViewFamilyType draftingViewType = null;
                try
                {
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().Where(elem => elem.Name == "BA Drafting View").First() as ViewFamilyType;
                }
                catch
                {
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().First() as ViewFamilyType;
                }

                Transaction t = new Transaction(doc, "MakeIDMaterialView");
                t.Start();
                foreach (ViewDrafting view in draftingViews)
                {
                    if (view.Name == "ID Material View" || view.Name == uiForm.materialsCMSSetViewNameTextBox.Text)
                    {
                        doc.Delete(view.Id);
                        doc.Regenerate();
                        break;
                    }
                    else { continue; }
                }
                placementView = ViewDrafting.Create(doc, draftingViewType.Id);
                placementView.Scale = 1;
                if (uiForm.materialsCMSSetViewNameTextBox.Text != "")
                {
                    placementView.Name = uiForm.materialsCMSSetViewNameTextBox.Text.Replace("{", "").Replace("}", "");
                }
                else
                {
                    placementView.Name = "ID Material View";
                }

                try
                {
                    placementView.GetParameters("BA View Sort 1 Division").First().Set("2 Plans");
                    placementView.GetParameters("BA View Sort 2 Type").First().Set("230 Finish Plans");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                doc.Regenerate();
                t.Commit();

                RVTOperations.PlaceSymbolsInView(uiApp, famDoc, "ID Use", "Mark", placementView);
            }
        }
    }
}
