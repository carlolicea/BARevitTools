using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Swap Room Name/Number tool, which simply swaps the room name and number values
    class RoomsSRNNRequest
    {
        public RoomsSRNNRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            //Collect all rooms in the project
            var roomsCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Rooms).ToElements();

            //Enclosing the operations in a transaction for tidiness
            using (Transaction t1 = new Transaction(uidoc.Document, "SwapRoomNameAndNumber"))
            {
                t1.Start();
                //Cycle through each room
                foreach (Room room in roomsCollector)
                {
                    //Get the room number and name and store them
                    Parameter roomNumber = room.get_Parameter(BuiltInParameter.ROOM_NUMBER);
                    string tempRoomNumber = roomNumber.AsString();
                    Parameter roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME);
                    string tempRoomName = roomName.AsString();
                    try
                    {
                        //Set the parameters from the stored values
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
}
