using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace BARevitTools
{
    public class SelectRooms
    {

        public List<Element> SelectRooms(UIApplication uiApp)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            List<Element> selectedElements = new List<Element>();
            IList<Reference> elemReferences = new List<Reference>();

            #region Select Elements           
            elemReferences = uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element);

            foreach (Reference selectedReference in elemReferences)
            {
                ElementId referenceId = selectedReference.ElementId;
                Element referenceElement = uidoc.Document.GetElement(referenceId);
                selectedElements.Add(referenceElement);
            }
            #endregion Select Elements

            #region Get Rooms
            List<Element> selectedRoomElements = new List<Element>();
            foreach (Element element in selectedElements.Distinct())
            {
                if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.Room")
                {
                    Room room = element as Room;
                    selectedRoomElements.Add(room);
                }
                else if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.RoomTag")
                {
                    RoomTag tag = element as RoomTag;
                    selectedRoomElements.Add(tag.Room);
                }
                else
                {
                    continue;
                }
            }
            #endregion Get Rooms

            return selectedRoomElements;
        }
    }
}