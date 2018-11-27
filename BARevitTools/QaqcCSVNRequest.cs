using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class QaqcCSVNRequest
    {
        public QaqcCSVNRequest(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector sheetsCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector viewportsCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> sheets = sheetsCollector.OfClass(typeof(ViewSheet)).WhereElementIsNotElementType().ToElements();
            ICollection<Element> viewports = viewportsCollector.OfClass(typeof(Viewport)).WhereElementIsNotElementType().ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "Capitalize Sheet and View Names");
            t1.Start();
            foreach (ViewSheet sheet in sheets)
            {
                try
                {
                    sheet.Name = sheet.Name.ToString().ToUpper();
                }
                catch
                {
                    continue;
                }
            }
            foreach (Viewport viewport in viewports)
            {
                try
                {
                    if (viewport.SheetId.ToString() != "InvalidElementId")
                    {
                        ElementId viewId = viewport.ViewId;
                        Autodesk.Revit.DB.View viewportView = uidoc.Document.GetElement(viewId) as Autodesk.Revit.DB.View;
                        viewportView.Name = viewportView.Name.ToString().ToUpper();
                    }
                }
                catch
                {
                    continue;
                }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
    }
}
