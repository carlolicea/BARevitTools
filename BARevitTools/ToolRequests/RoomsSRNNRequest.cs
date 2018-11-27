using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class RoomsSRNNRequest
    {
        public RoomsSRNNRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var roomsCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Rooms).ToElements();

            Transaction t1 = new Transaction(uidoc.Document, "SwapRoomNameAndNumber");
            t1.Start();
            foreach (Room room in roomsCollector)
            {
                Parameter roomNumber = room.get_Parameter(BuiltInParameter.ROOM_NUMBER);
                string tempRoomNumber = roomNumber.AsString();
                Parameter roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME);
                string tempRoomName = roomName.AsString();
                try
                {
                    roomNumber.Set(tempRoomName);
                    roomName.Set(tempRoomNumber);
                }
                catch
                { continue; }
            }
            t1.Commit();
            t1.Dispose();
        }
    }
}
