using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class QaqcDRNPRequest
    {
        public QaqcDRNPRequest(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector roomsCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> rooms = roomsCollector.OfCategory(BuiltInCategory.OST_Rooms).ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            List<ElementId> idsToDelete = new List<ElementId>();
            Transaction t1 = new Transaction(uidoc.Document, "DeleteNotPlacedRooms");
            t1.Start();
            foreach (Room room in rooms)
            {
                if (room.Location == null)
                {
                    idsToDelete.Add(room.Id);
                }
            }
            foreach (ElementId idToDelete in idsToDelete)
            {
                try
                {
                    uidoc.Document.Delete(idsToDelete);
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
