using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is used by the Create Floors By Rooms tool. It obtains the room boundary loop to create a floor 
    //and offset it from the level by the floor thickness in cases where the floor adds substantial finish depth.
    class FloorsCFBRRequest
    {
        public FloorsCFBRRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FloorType selectedFloorType = null;

            //Get the name of the floor type selected in the MainUI
            string selectedFloorTypeName = uiForm.floorsCFBRSelectFloorTypeComboBox.Text.ToString();
            //Create lists to use locally from the rooms selected from the MainUI, the collection of floor types, and to store newly created floors.
            List<Room> roomElements = uiForm.floorsCFBRRoomsList;
            List<FloorType> floorTypes = RVTGetElementsByCollection.DocumentFloorTypes(uiApp);
            List<Floor> newFloors = new List<Floor>();

            //First, make sure the user is running the tool from a plan view
            if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                //If they are int a plan view, start a transaction
                Transaction t1 = new Transaction(uidoc.Document, "CreateFloorsByRoom");
                t1.Start();
                //Cycle through the floor types in the project until the one with a name matching the one selected in the MainUI is found
                foreach (FloorType floorType in floorTypes)
                {
                    if (floorType.Name.ToString() == selectedFloorTypeName)
                    {
                        selectedFloorType = floorType;
                        break;
                    }
                    else { continue; }
                }

                try
                {
                    //Generate new GeometryOptions to allow evaluation of room volumes that may not be visible.
                    Options geomOptions = new Options();
                    geomOptions.IncludeNonVisibleObjects = true;

                    //For each room that was selected with the MainUI...
                    foreach (Room room in roomElements)
                    {
                        //Create a new iterable list for the CurveLoops reprsenting the edges of the room boundary
                        IList<CurveLoop> faceCurveLoops = null;
                        //Get the level associated with the room for floor creation
                        Level roomLevel = room.Level;

                        //Get the geometry of the room
                        GeometryElement roomGeomElements = room.get_Geometry(geomOptions);
                        Solid roomSolid = null;

                        //Cycle through the geometry associated with the room until the solid form is found
                        foreach (GeometryObject geom in roomGeomElements)
                        {
                            if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                            {
                                roomSolid = geom as Solid;
                                break;
                            }
                        }

                        //If the solid form of the room was found, continue
                        if (roomSolid != null)
                        {
                            //Get the faces of the solid
                            FaceArray solidFaces = roomSolid.Faces;
                            foreach (PlanarFace solidFace in solidFaces)
                            {
                                //Check the direction of the face normal
                                XYZ faceNormal = solidFace.FaceNormal;
                                //If the face normal faced down, it is a bottom face. Because the room cannot be split into multiple portions, 
                                //and a split level room is unlikely, it is safe to select the first downward face.
                                if (faceNormal.Z == -1)
                                {
                                    //Get the edges of the face as curve loops
                                    faceCurveLoops = solidFace.GetEdgesAsCurveLoops();
                                    break;
                                }
                            }
                        }

                        //If the face's curve loops were retrieved, continue
                        if (faceCurveLoops.Count != 0)
                        {
                            try
                            {
                                //Make a new CurveArray from the loops
                                CurveArray curveArray = new CurveArray();
                                foreach (CurveLoop cloop in faceCurveLoops)
                                {
                                    CurveLoopIterator cLoopIter = cloop.GetCurveLoopIterator();
                                    while (cLoopIter.MoveNext())
                                    {
                                        curveArray.Append(cLoopIter.Current);
                                    }
                                }
                                //The new floow will require the CurveArray, FloorType, Level, and boolean for making it structural (false for this tool's purpose)
                                Floor newFloor = uidoc.Document.Create.NewFloor(curveArray, selectedFloorType, roomLevel, false);
                                //After making the floor, add it to the list of new floors created
                                newFloors.Add(newFloor);
                            }
                            catch
                            {
                                //If the room had more than one edge loop, such as another room was enveloped by the selected room, the operation will fail because the API only allows one loop
                                MessageBox.Show(string.Format("Floor could not be made for {0}, which is likely due to the room having more than one boundary loop. The Revit API only allows for one contiuous loop.", room.Number.ToString()));
                            }
                        }
                    }
                    t1.Commit();
                    //Provide some feedback to the MainUI
                    uiForm.floorsCFBRDoneLabel.Visible = true;
                    uiForm.floorsCFBRRoomsList = new List<Room>();                    
                }
                catch { t1.RollBack(); }

                //If the user wanted to offset the floors by their thickness, this will offset the newly made and collected floors
                if (uiForm.floorsCFBROffsetFinishFloorCheckBox.Checked)
                {
                    Transaction t2 = new Transaction(uidoc.Document, "ElevateFloors");
                    t2.Start();
                    try
                    {
                        //Cycle through the list of new floors
                        foreach (Floor floor in newFloors)
                        {
                            //Make a new set of geometry options
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            //Get the floor geometry and the bounding box of the geometry
                            GeometryElement floorGeometry = floor.get_Geometry(geomOptions);
                            BoundingBoxXYZ floorBBox = floorGeometry.GetBoundingBox();
                            //Use the minimum and maximum Z coordinates from the bounding box to determine the floor thickness because that's not natively supported in the Revit API
                            double bBoxMinZ = floorBBox.Min.Z;
                            double bBoxMaxZ = floorBBox.Max.Z;
                            double floorThickness = bBoxMaxZ - bBoxMinZ;
                            //Move the floor up with a translation in the Z axis by the thickness value
                            XYZ translation = new XYZ(0, 0, floorThickness);
                            ElementTransformUtils.MoveElement(uidoc.Document, floor.Id, translation);
                        }
                        t2.Commit();
                    }
                    catch { t2.RollBack(); }
                }
            }            
        }
    }
}
