using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class SheetsCSLRequest
    {
        public SheetsCSLRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;

            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();

            string selectedSheetNumber = uiForm.sheetsCSLComboBox.Text;
            List<string> selectedSheets = new List<string>();
            List<ElementId> viewsToCopy = new List<ElementId>();
            List<ElementId> viewportTypeIds = new List<ElementId>();
            List<XYZ> viewportLocations = new List<XYZ>();

            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if (row.Cells["Select"].Value.ToString() == "True")
                    {
                        selectedSheets.Add(row.Cells["Sheet Number"].Value.ToString());
                    }
                    else { continue; }
                }
                else { continue; }
            }

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
                                ; viewportTypeIds.Add(viewportViewTypeId);
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
        }
    }
}
