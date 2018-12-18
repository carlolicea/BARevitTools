using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Delet Rooms Not Placed which delete Not Placed rooms
    class QaqcDRNPRequest
    {
        public QaqcDRNPRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Collect all rooms in the project
            ICollection<Element> rooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).ToElements();
                       
            //For each room in the collection, add its ElementId to the list if it does not have a location
            List<ElementId> idsToDelete = new List<ElementId>();
            foreach (Room room in rooms)
            {
                if (room.Location == null)
                {
                    idsToDelete.Add(room.Id);
                }
            }

            //Wrapping this in one transaction for tidiness
            using (Transaction t1 = new Transaction(doc, "DeleteNotPlacedRooms"))
            {
                t1.Start();     
                //Delete every room in the list of rooms to delete
                foreach (ElementId idToDelete in idsToDelete)
                {
                    try
                    {
                        doc.Delete(idsToDelete);
                    }
                    catch
                    {
                        continue;
                    }
                }
                t1.Commit();
                t1.Dispose();
            }
        }
    }
}
