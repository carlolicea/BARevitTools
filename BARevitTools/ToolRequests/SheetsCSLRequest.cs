using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class SheetsCSLRequest
    {
        public SheetsCSLRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sheetsCSLProgressBar.Value = 0;
            uiForm.sheetsCSLProgressBar.Minimum = 0;
            uiForm.sheetsCSLProgressBar.Step = 1;
            uiForm.sheetsCSLProgressBar.Visible = true;

            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();

            string selectedSheetNumber = uiForm.sheetsCSLComboBox.Text;
            List<string> selectedSheets = new List<string>();
            List<ElementId> viewsToCopy = new List<ElementId>();
            List<ElementId> viewportTypeIds = new List<ElementId>();
            List<XYZ> viewportLocations = new List<XYZ>();

            int countOfSheets = 0;
            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if (row.Cells["Select"].Value.ToString() == "True")
                    {
                        selectedSheets.Add(row.Cells["Sheet Number"].Value.ToString());
                        countOfSheets++;
                    }
                    else { continue; }
                }
                else { continue; }
            }
            uiForm.sheetsCSLProgressBar.Maximum = countOfSheets;

            if (uiForm.sheetsCSLComboBox.Text != "<Originating Sheet>")
            {
                foreach (ViewSheet sheet in sheetsCollector)
                {
                    if (sheet.SheetNumber.ToString() == selectedSheetNumber)
                    {
                        ICollection<ElementId> viewportIds = sheet.GetAllViewports();
                        foreach (ElementId viewportId in viewportIds)
                        {
                            Viewport viewportElement = uidoc.Document.GetElement(viewportId) as Viewport;
                            ElementId viewportViewId = viewportElement.ViewId;
                            ElementId viewportViewTypeId = viewportElement.GetTypeId();
                            XYZ viewportLocation = viewportElement.GetBoxCenter();
                            Autodesk.Revit.DB.View viewportView = uidoc.Document.GetElement(viewportViewId) as Autodesk.Revit.DB.View;
                            if (viewportView.ViewType.ToString() == "Legend")
                            {
                                viewsToCopy.Add(viewportViewId);
                                viewportTypeIds.Add(viewportViewTypeId);
                                viewportLocations.Add(viewportLocation);
                            }
                            else { continue; }
                        }
                        break;
                    }
                    else { continue; }
                }
            }

            Transaction t1 = new Transaction(uidoc.Document, "CopyLegendsFromSheetToSheets");
            t1.Start();
            foreach (ViewSheet sheet in sheetsCollector)
            {
                if (selectedSheets.Contains(sheet.SheetNumber.ToString()))
                {
                    uiForm.sheetsCSLProgressBar.PerformStep();
                    int x = viewsToCopy.Count();
                    int i = 0;
                    while (i < x)
                    {
                        try
                        {
                            Viewport newViewport = Viewport.Create(uidoc.Document, sheet.Id, viewsToCopy[i], viewportLocations[i]);
                            newViewport.ChangeTypeId(viewportTypeIds[i]);
                            i++;
                        }
                        catch { i++; }
                    }
                }
                else { continue; }
            }
            t1.Commit();
            t1.Dispose();
            uiForm.sheetsCSLFilterTextBox.Text = "";

            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                row.Cells["Select"].Value = false;
                row.Cells["Select"].Style.BackColor = uiForm.sheetsCSLDataGridView.DefaultCellStyle.BackColor;
            }
        }
    }
}
