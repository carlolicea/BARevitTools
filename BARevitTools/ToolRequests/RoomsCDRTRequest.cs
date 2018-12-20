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
    //
    //This class is associated with the Create Demo Room Tags tool, which places symbols for rooms in a previous phase as fake tags in the active view's phase, but only for rooms within the view crop
    class RoomsCDRTRequest
    {
        public RoomsCDRTRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            Autodesk.Revit.DB.View activeView = doc.ActiveView;

            //Verify the active view is a floor plan view 
            if (activeView.ViewType != ViewType.FloorPlan)
            {
                MessageBox.Show("Please run from a demo floor plan view.");
            }
            else
            {
                //Get the current phase of the active view
                Phase currentPhase = doc.GetElement(activeView.get_Parameter(BuiltInParameter.VIEW_PHASE).AsElementId()) as Phase;
                ElementId currentPhaseId = currentPhase.Id;
                ElementId previousPhaseId = null;
                //Collect the phases of the document
                PhaseArray phaseArray = doc.Phases;
                
                //Cycle through the phases in the project to get the previous phase
                for (int i = 0; i < phaseArray.Size; i++)
                {
                    //By finding the index of the current phase, which must not be the first phase, the phase in the previous index can be obtained
                    if (phaseArray.get_Item(i).ToString() == currentPhase.ToString() && i != 0)
                    {
                        previousPhaseId = phaseArray.get_Item(i - 1).Id;
                    }
                    i++;
                }

                //Collect the rooms in the current view where their phase is equal to the active view's phase
                List<Room> currentVisibleRooms = new FilteredElementCollector(doc, activeView.Id).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().ToElements().Cast<Room>().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == currentPhaseId).ToList();
                List<string> currentVisibleRoomNumbers = new List<string>();

                //Get the list of currently visible rooms' numbers
                foreach (Room room in currentVisibleRooms)
                {
                    currentVisibleRoomNumbers.Add(room.Number);
                }

                //Only continue if the previous phase was found
                if (previousPhaseId != null)
                {
                    List<Room> previousRoomsToTag = new List<Room>();
                    Outline outline = null;
                    try
                    {
                        //This portion will require a new outline from the view's bounding box
                        BoundingBoxXYZ viewBBox = activeView.get_BoundingBox(activeView);
                        //Get the active view as a plan view so the view range can be obtained for the height of the outline
                        ViewPlan viewPlan = activeView as ViewPlan;
                        PlanViewRange planViewRange = viewPlan.GetViewRange();
                        double minX = viewBBox.Min.X;
                        double minY = viewBBox.Min.Y;
                        //The bottom Z point of the outline will be the elevation of the view's level plus the bottom offset
                        double minZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.BottomClipPlane);
                        double maxX = viewBBox.Max.X;
                        double maxY = viewBBox.Max.Y;
                        //The top Z point of the outline will be the elevation of the view's level plust the top offset
                        double maxZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.TopClipPlane);
                        //Generate the minimum and maximum points
                        XYZ minPoint = new XYZ(minX, minY, minZ);
                        XYZ maxPoint = new XYZ(maxX, maxY, maxZ);
                        //Make a new outline from the points
                        outline = new Outline(minPoint, maxPoint);

                        //Establish a new bounding box filter using the outline
                        BoundingBoxIntersectsFilter bboxFilter = new BoundingBoxIntersectsFilter(outline);
                        //The previous rooms will be those that pass the bounding box intersects filter (their bounding boxes intersect the view bounding box) and they belong to the previous phase
                        var previousNonVisibleRooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().WherePasses(bboxFilter).ToElements().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == previousPhaseId);
                        foreach (Element elem in previousNonVisibleRooms)
                        {
                            //Get the rooms and their numbers
                            Room room = elem as Room;
                            string roomNumber = room.Number;
                            //Verify the room number is not in the current view's list of visible room numbers
                            if (!currentVisibleRoomNumbers.Contains(roomNumber))
                            {
                                previousRoomsToTag.Add(room);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //If something went wrong in getting the demoed rooms, report an error
                        MessageBox.Show(e.ToString(), "Getting Demo Rooms Error");
                    }

                    //Start a transaction to make the new tags
                    Transaction t = new Transaction(doc, "Create Demo Room Tags");
                    t.Start();
                    FamilySymbol symbol = null;
                    //Create a new instance of the load options
                    IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();

                    try
                    {
                        //Get the versioned symbol family to use as a "tag"
                        string roomTagSymbolPath = RVTOperations.GetVersionedFamilyFilePath(uiApp, Properties.Settings.Default.RevitRoomTagSymbol);
                        try
                        {
                            //Load only the particular type of tag 
                            doc.LoadFamilySymbol(roomTagSymbolPath, Properties.Settings.Default.RevitRoomTagSymbolType, loadOptions, out FamilySymbol symb);
                            symbol = symb;
                        }
                        catch
                        {
                            //If it could not be loaded, let the user know it needs added to the family for the script to work
                            MessageBox.Show(String.Format("The family type {0} could not be found in {1}. Please add it for this tool to work.",
                                Properties.Settings.Default.RevitRoomTagSymbolType, 
                                Properties.Settings.Default.RevitRoomTagSymbol));
                        }                            
                    }
                    catch
                    {
                        //If the family itself could not be loaded, let the user know where the family was expected to be found.
                        MessageBox.Show(String.Format("The {0} family could not be found at {1}. Please place the {0} family in the {1} folder for this tool to work.",
                            Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitRoomTagSymbol),
                            Path.GetDirectoryName(Properties.Settings.Default.RevitRoomTagSymbol)));
                    }

                    try
                    {
                        //Verify there are rooms to tag and the family symbol to use is not null
                        if (previousRoomsToTag.Count > 0 && symbol != null)
                        {
                            //Cycle through the demoed rooms
                            foreach (Room demoRoom in previousRoomsToTag)
                            {
                                //Get the location point of the demo room as a point
                                LocationPoint roomLocationPoint = demoRoom.Location as LocationPoint;
                                //Make a new symbol at the locatoin
                                FamilyInstance newSymbol = doc.Create.NewFamilyInstance(roomLocationPoint.Point, symbol, activeView);
                                //Update the parameter values for room Name and Number in the symbol
                                newSymbol.GetParameters("Name").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NAME).AsString());
                                newSymbol.GetParameters("Number").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString());
                            }
                        }
                        t.Commit();
                    }
                    catch (Exception f)
                    {
                        //Well, crap, the symbol didn't place in the view
                        MessageBox.Show(f.ToString(), "Placement Error");
                        t.RollBack();
                    }
                }
                else
                {
                    //If the previous phase was null, then the current phase of the view is the first phase, so let the user know
                    MessageBox.Show("The currently viewed phase is the earliest phase in the project. Please verify you are viewing a new construction phase, but showing previous and demoed elements.");
                }
            }
        }
    }
    
}
