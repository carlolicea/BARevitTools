using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
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
    class RoomsCDRTRequest
    {
        public RoomsCDRTRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            Autodesk.Revit.DB.View activeView = doc.ActiveView;

            if (activeView.ViewType != ViewType.FloorPlan)
            {
                MessageBox.Show("Please run from a demo floor plan view.");
            }
            else
            {
                Phase currentPhase = doc.GetElement(activeView.get_Parameter(BuiltInParameter.VIEW_PHASE).AsElementId()) as Phase;
                ElementId currentPhaseId = currentPhase.Id;
                ElementId previousPhaseId = null;
                PhaseArray phaseArray = doc.Phases;
                List<Room> currentVisibleRooms = new FilteredElementCollector(doc, activeView.Id).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().ToElements().Cast<Room>().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == currentPhaseId).ToList();
                List<string> currentVisibleRoomNumbers = new List<string>();

                for (int i = 0; i < phaseArray.Size; i++)
                {
                    if (phaseArray.get_Item(i).ToString() == currentPhase.ToString() && i != 0)
                    {
                        previousPhaseId = phaseArray.get_Item(i - 1).Id;
                    }
                    i++;
                }

                foreach (Room room in currentVisibleRooms)
                {
                    currentVisibleRoomNumbers.Add(room.Number);
                }

                if (previousPhaseId != null)
                {
                    List<Room> previousRoomsToTag = new List<Room>();
                    Outline outline = null;
                    try
                    {
                        BoundingBoxXYZ viewBBox = activeView.get_BoundingBox(activeView);
                        ViewPlan viewPlan = activeView as ViewPlan;
                        PlanViewRange planViewRange = viewPlan.GetViewRange();

                        double minX = viewBBox.Min.X;
                        double minY = viewBBox.Min.Y;
                        double minZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.BottomClipPlane);
                        double maxX = viewBBox.Max.X;
                        double maxY = viewBBox.Max.Y;
                        double maxZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.TopClipPlane);
                        XYZ minPoint = new XYZ(minX, minY, minZ);
                        XYZ maxPoint = new XYZ(maxX, maxY, maxZ);

                        outline = new Outline(minPoint, maxPoint);
                        BoundingBoxIntersectsFilter bboxFilter = new BoundingBoxIntersectsFilter(outline);
                        var previousNonVisibleRooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().WherePasses(bboxFilter).ToElements().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == previousPhaseId);
                        foreach (Element elem in previousNonVisibleRooms)
                        {
                            Room room = elem as Room;
                            string roomNumber = room.Number;
                            if (!currentVisibleRoomNumbers.Contains(roomNumber))
                            {
                                previousRoomsToTag.Add(room);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), "Getting Demo Rooms Error");
                    }

                    Transaction t = new Transaction(doc, "Create Demo Room Tags");
                    t.Start();
                    FamilySymbol symbol = null;
                    IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();

                    try
                    {
                        string roomTagSymbolPath = RVTOperations.GetVersionedFamilyFilePath(uiApp, Properties.Settings.Default.RevitRoomTagSymbol);
                        try
                        {
                            doc.LoadFamilySymbol(roomTagSymbolPath, "Name and Number", loadOptions, out FamilySymbol symb);
                            symbol = symb;
                        }
                        catch
                        {
                            MessageBox.Show(String.Format("The family type 'Name and Number' could not be found in {0}. Please add it for this tool to work.", Properties.Settings.Default.RevitRoomTagSymbol));
                        }                            
                    }
                    catch
                    {
                        MessageBox.Show(String.Format("The {0} family could not be found at {1}. Please place the {0} family in the {1} folder for this tool to work.",
                            Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitRoomTagSymbol),
                            Path.GetDirectoryName(Properties.Settings.Default.RevitRoomTagSymbol)));
                    }

                    try
                    {
                        if (previousRoomsToTag.Count > 0 && symbol != null)
                        {
                            foreach (Room demoRoom in previousRoomsToTag)
                            {
                                LocationPoint roomLocationPoint = demoRoom.Location as LocationPoint;
                                XYZ placementPoint = new XYZ();
                                if (outline != null && outline.Contains(placementPoint, 0))
                                {
                                    placementPoint = roomLocationPoint.Point;
                                }
                                else
                                {
                                    placementPoint = roomLocationPoint.Point;
                                }
                                FamilyInstance newSymbol = doc.Create.NewFamilyInstance(placementPoint, symbol, activeView);
                                newSymbol.GetParameters("Name").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NAME).AsString());
                                newSymbol.GetParameters("Number").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString());
                            }
                        }
                        t.Commit();
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show(f.ToString(), "Placement Error");
                        t.RollBack();
                    }
                }
                else
                {
                    MessageBox.Show("The currently viewed phase is the earliest phase in the project. Please verify you are viewing a new construction phase, but showing previous and demoed elements.");
                }
            }
        }
    }
    
}
