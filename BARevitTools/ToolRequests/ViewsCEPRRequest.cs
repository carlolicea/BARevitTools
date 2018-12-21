using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Create Elevations Per Room tool, which makes elevations in 4 directions at room locations and crops them
    class ViewsCEPRRequest
    {
        public ViewsCEPRRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            //Collect the ViewTypes in the project
            FilteredElementCollector viewTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> viewTypes = viewTypesCollector.OfClass(typeof(ViewFamilyType)).ToElements();
            ElementId viewTypeId = null;

            //Cycle through the ViewType elements to find the one with a type name equal to the one selected in the MainUI's combobox
            foreach (ViewFamilyType viewType in viewTypes)
            {
                if (viewType.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_NAME).AsString() == uiForm.viewsCEPRElevationComboBox.Text)
                {
                    viewTypeId = viewType.Id;
                }
            }

            //If the ViewType was found, and the active view is a plan view, continue
            if (viewTypeId != null && uidoc.ActiveView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
                //Invoke a room selection
                List<Room> selectedRoomElements = RVTOperations.SelectRoomElements(uiApp);

                //If the user selected rooms, continue
                if (selectedRoomElements != null)
                {
                    try
                    {
                        //Cycle through each selected room
                        foreach (Room room in selectedRoomElements)
                        {
                            //First, get the room number for use in generating the elevation view names
                            string roomNumber = room.Number;
                            string roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME).AsString().ToUpper();
                            //Get the geometry of the room
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = room.get_Geometry(geomOptions);
                            //Get the location point of the room as a point for where to place the elevation marker
                            LocationPoint roomLocation = room.Location as LocationPoint;
                            XYZ point = roomLocation.Point;

                            //Start a transaction
                            Transaction t1 = new Transaction(uidoc.Document, "Create Elevations Per Room");
                            t1.Start();
                            try
                            {
                                //Make a new ElevationMarker that uses the ViewType earlier, the location point of the room, and has a view scale of 1/8"                                
                                ElevationMarker newMarker = ElevationMarker.CreateElevationMarker(uidoc.Document, viewTypeId, point, 96);
                                //Start making views going around the elevation marker where the indexes start on the west side and go clockwise
                                ViewSection view0 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 0);
                                //Set the view name equal to the room number + room name + plus orientation
                                view0.Name = roomNumber + " " + roomName + " WEST";
                                view0.CropBoxActive = true;
                                //Repeat for the other view directions at their appropriate index
                                ViewSection view1 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 1);
                                view1.Name = roomNumber + " " + roomName + " NORTH";
                                view1.CropBoxActive = true;
                                ViewSection view2 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 2);
                                view2.Name = roomNumber + " " + roomName + " EAST";
                                view2.CropBoxActive = true;
                                ViewSection view3 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 3);
                                view3.Name = roomNumber + " " + roomName + " SOUTH";
                                view3.CropBoxActive = true;

                                //Make a Solid object for assignment
                                Solid roomSolid = null;
                                //The following section is dedicated to cropping the elevation views to the cross-section of the room geometry
                                if (uiForm.viewsCEPRCropCheckBox.Checked == true)
                                {
                                    //Cycle through the geometry elements associated with the room geometry until the solid is found
                                    foreach (GeometryObject geom in geomElements)
                                    {
                                        if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                        {
                                            roomSolid = geom as Solid;
                                            break;
                                        }
                                    }

                                    //Generate 4 planes at the room point that will correspond to each elevation view's cross section of the room geometry
                                    // Each plane's normal vector is in the direction their view is facing
                                    Plane westPlane = Plane.CreateByNormalAndOrigin(new XYZ(-1, 0, 0), point); //-X vector for West
                                    Plane northPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), point); //+Y vector for North
                                    Plane eastPlane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), point); //+X vector for East
                                    Plane southPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), point); //-Y vector for South

                                    //Use the room section's perimeter as the crop boundary if the first index of the MainUI combobox is selected
                                    if (uiForm.viewsCEPRCropMethodComboBox.SelectedIndex == 0)
                                    {
                                        try
                                        {
                                            //Generate some CurveLoop lists for use later
                                            IList<CurveLoop> westCurveLoopsFitted = null;
                                            IList<CurveLoop> northCurveLoopsFitted = null;
                                            IList<CurveLoop> southCurveLoopsFitted = null;
                                            IList<CurveLoop> eastCurveLoopsFitted = null;

                                            //Slice the room solid with the westPlane object made earlier. This will result in a solid boolean result to the west of the plane because the positive side of the plane faces west
                                            Solid westBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, westPlane);
                                            //Grab the faces of the solid that resulted from the boolean
                                            FaceArray westBoolSolidFaces = westBooleanSolid.Faces;
                                            //Cycle through each face and get the normal vector
                                            foreach (PlanarFace westFace in westBoolSolidFaces)
                                            {
                                                //For the west elevation face to use as the crop boundary, we need the face that has a vector going east, or the +X vector
                                                XYZ westFaceNormal = westFace.FaceNormal;
                                                if (westFaceNormal.X == 1)
                                                {
                                                    //Get the edges as a CurveLoops once the face is found, then jump out of the loop thorugh the faces
                                                    westCurveLoopsFitted = westFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //Repeat for the north elevation
                                            Solid northBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, northPlane);
                                            FaceArray northBoolSolidFaces = northBooleanSolid.Faces;
                                            foreach (PlanarFace northFace in northBoolSolidFaces)
                                            {
                                                XYZ northFaceNormal = northFace.FaceNormal;
                                                if (northFaceNormal.Y == -1)
                                                {
                                                    northCurveLoopsFitted = northFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //Repeat for the east elevation
                                            Solid eastBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, eastPlane);
                                            FaceArray eastBoolSolidFaces = eastBooleanSolid.Faces;
                                            foreach (PlanarFace eastFace in eastBoolSolidFaces)
                                            {
                                                XYZ eastFaceNormal = eastFace.FaceNormal;
                                                if (eastFaceNormal.X == -1)
                                                {
                                                    eastCurveLoopsFitted = eastFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //Repeat for the south elevation
                                            Solid southBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, southPlane);
                                            FaceArray southBoolSolidFaces = southBooleanSolid.Faces;
                                            foreach (PlanarFace southFace in southBoolSolidFaces)
                                            {
                                                
                                                XYZ southFaceNormal = southFace.FaceNormal;
                                                if (southFaceNormal.Y == 1)
                                                {
                                                    southCurveLoopsFitted = southFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //To get the CurveLoop fitted 0.5" offset to the boundary of the face retrieved, create a CurveLoop via an offset
                                            //Now, the original curve loop was drawn on a plane with a +X axis vector normal, so the offset must be made in the positive X axis plane as well
                                            CurveLoop offsetWestCurveLoopFitted = CurveLoop.CreateViaOffset(westCurveLoopsFitted[0], (0.5d/12), XYZ.BasisX);
                                            ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                            westCropRegionShapeManager.SetCropShape(offsetWestCurveLoopFitted);

                                            //Repeat for the north CurveLoop
                                            //Note that because the plane has a -Y vector, the offset needs to be negative too
                                            CurveLoop offsetNorthCurveLoopFitted = CurveLoop.CreateViaOffset(northCurveLoopsFitted[0], -(0.5d / 12), XYZ.BasisY); ;
                                            ViewCropRegionShapeManager northCropRegionShapeManager = view1.GetCropRegionShapeManager();
                                            northCropRegionShapeManager.SetCropShape(offsetNorthCurveLoopFitted);

                                            //Repeat for the east CurveLoop
                                            CurveLoop offsetEastCurveLoopFitted = CurveLoop.CreateViaOffset(eastCurveLoopsFitted[0], -(0.5d / 12), XYZ.BasisX); ;
                                            ViewCropRegionShapeManager eastCropRegionShapeManager = view2.GetCropRegionShapeManager();
                                            eastCropRegionShapeManager.SetCropShape(offsetEastCurveLoopFitted);

                                            //Repeat for the south CurveLoop
                                            CurveLoop offsetSouthCurveLoopFitted = CurveLoop.CreateViaOffset(southCurveLoopsFitted[0], (0.5d / 12), XYZ.BasisY); ;
                                            ViewCropRegionShapeManager southCropRegionShapeManager = view3.GetCropRegionShapeManager();
                                            southCropRegionShapeManager.SetCropShape(offsetSouthCurveLoopFitted);
                                        }
                                        catch(Exception e)
                                        {
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                    
                                    //Use the room section's rectangular extents as the crop boundary if the second index was selected for the MainUI combobox
                                    if (uiForm.viewsCEPRCropMethodComboBox.SelectedIndex == 1)
                                    {
                                        try
                                        {
                                            //Create some CurveLoop lists to use later
                                            IList<CurveLoop> westCurveLoopsRectangular = null;
                                            IList<CurveLoop> northCurveLoopsRectangular = null;
                                            IList<CurveLoop> southCurveLoopsRectangular = null;
                                            IList<CurveLoop> eastCurveLoopsRectangular = null;

                                            //To get a rectangular cross section of a non-rectangular room cross section, we need to generate a bounding box for the room, then make a solid from the bounding box
                                            //Get the bounding box of the room
                                            BoundingBoxXYZ roomBBox = roomSolid.GetBoundingBox();
                                            //Use the minimum and maximum points of the bounding box to get the 4 points along the bottom of the bounding box
                                            XYZ pt0 = new XYZ(roomBBox.Min.X, roomBBox.Min.Y, roomBBox.Min.Z);
                                            XYZ pt1 = new XYZ(roomBBox.Max.X, roomBBox.Min.Y, roomBBox.Min.Z);
                                            XYZ pt2 = new XYZ(roomBBox.Max.X, roomBBox.Max.Y, roomBBox.Min.Z);
                                            XYZ pt3 = new XYZ(roomBBox.Min.X, roomBBox.Max.Y, roomBBox.Min.Z);
                                            //Generate perimeter lines for the bottom of the bounding box points
                                            Line edge0 = Line.CreateBound(pt0, pt1);
                                            Line edge1 = Line.CreateBound(pt1, pt2);
                                            Line edge2 = Line.CreateBound(pt2, pt3);
                                            Line edge3 = Line.CreateBound(pt3, pt0);
                                            //Make a list of curves out of the edges
                                            List<Curve> edges = new List<Curve>();
                                            edges.Add(edge0);
                                            edges.Add(edge1);
                                            edges.Add(edge2);
                                            edges.Add(edge3);
                                            //Use the curves to make a CurveLoop list
                                            List<CurveLoop> loops = new List<CurveLoop>();
                                            loops.Add(CurveLoop.Create(edges));
                                            //Generate a solid from an extrusion that uses the CurveLoops extruded upward a height equal to the the height of the bounding box
                                            Solid initialSolidBBox = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, (roomBBox.Max.Z - roomBBox.Min.Z));
                                            //Create a transformed solid box from the previously created box moved to where the room bounding box is located
                                            Solid roomSolidBBox = SolidUtils.CreateTransformed(initialSolidBBox, roomBBox.Transform);

                                            //Cut the solid box with the west plane created earlier and get the faces
                                            Solid westBooleanSolidBBox = BooleanOperationsUtils.CutWithHalfSpace(roomSolidBBox, westPlane);
                                            FaceArray westBoolSolidFacesBBox = westBooleanSolidBBox.Faces;
                                            foreach (PlanarFace westFace in westBoolSolidFacesBBox)
                                            {
                                                //As with the earlier code for a fitted crop, get the face with a positive X normal
                                                XYZ westFaceNormal = westFace.FaceNormal;
                                                if (westFaceNormal.X == 1)
                                                {
                                                    //Obtain the edges of the face
                                                    westCurveLoopsRectangular = westFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }                                           

                                            //Repeat for the north face
                                            Solid northBooleanSolidBBox = BooleanOperationsUtils.CutWithHalfSpace(roomSolidBBox, northPlane);
                                            FaceArray northBoolSolidFacesBBox = northBooleanSolidBBox.Faces;
                                            foreach (PlanarFace northFace in northBoolSolidFacesBBox)
                                            {
                                                XYZ northFaceNormal = northFace.FaceNormal;
                                                if (northFaceNormal.Y == -1)
                                                {
                                                    northCurveLoopsRectangular = northFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //Repeat for the east face
                                            Solid eastBooleanSolidBBox = BooleanOperationsUtils.CutWithHalfSpace(roomSolidBBox, eastPlane);
                                            FaceArray eastBoolSolidFacesBBox = eastBooleanSolidBBox.Faces;
                                            foreach (PlanarFace eastFace in eastBoolSolidFacesBBox)
                                            {
                                                XYZ eastFaceNormal = eastFace.FaceNormal;
                                                if (eastFaceNormal.X == -1)
                                                {
                                                    eastCurveLoopsRectangular = eastFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //Repeat for the south face
                                            Solid southBooleanSolidBBox = BooleanOperationsUtils.CutWithHalfSpace(roomSolidBBox, southPlane);
                                            FaceArray southBoolSolidFacesBBox = southBooleanSolidBBox.Faces;
                                            foreach (PlanarFace southFace in southBoolSolidFacesBBox)
                                            {
                                                XYZ southFaceNormal = southFace.FaceNormal;
                                                if (southFaceNormal.Y == 1)
                                                {
                                                    southCurveLoopsRectangular = southFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

                                            //As before, get the offset curve from the original curve, but offset by 1'
                                            CurveLoop offsetWestCurveLoopRectangular = CurveLoop.CreateViaOffset(westCurveLoopsRectangular[0], 1, XYZ.BasisX);
                                            ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                            westCropRegionShapeManager.SetCropShape(offsetWestCurveLoopRectangular);

                                            //As with the fitted offset curve, the offset for a curve in a plane with a negative vector must also be negative
                                            CurveLoop offsetNorthCurveLoopRectangular = CurveLoop.CreateViaOffset(northCurveLoopsRectangular[0], -1, XYZ.BasisY);
                                            ViewCropRegionShapeManager northCropRegionShapeManager = view1.GetCropRegionShapeManager();
                                            northCropRegionShapeManager.SetCropShape(offsetNorthCurveLoopRectangular);

                                            CurveLoop offsetEastCurveLoopRectangular = CurveLoop.CreateViaOffset(eastCurveLoopsRectangular[0], -1, XYZ.BasisX);
                                            ViewCropRegionShapeManager eastCropRegionShapeManager = view2.GetCropRegionShapeManager();
                                            eastCropRegionShapeManager.SetCropShape(offsetEastCurveLoopRectangular);

                                            CurveLoop offsetSouthCurveLoopRectangular = CurveLoop.CreateViaOffset(southCurveLoopsRectangular[0], 1, XYZ.BasisY);
                                            ViewCropRegionShapeManager southCropRegionShapeManager = view3.GetCropRegionShapeManager();
                                            southCropRegionShapeManager.SetCropShape(offsetSouthCurveLoopRectangular);
                                        }
                                        catch(Exception e)
                                        {
                                            MessageBox.Show(e.ToString());
                                        }                                        
                                    }

                                    //If the user opted to override the crop boundary of the elevations, continue as follows
                                    if (uiForm.viewsCEPROverrideCheckBox.Checked == true)
                                    {
                                        //Make a new OverrideGraphicsSetting to use in the boundary override
                                        OverrideGraphicSettings orgs = new OverrideGraphicSettings();
                                        //Use the solid line pattern
                                        orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
                                        //Set the line weight to the properties value
                                        orgs.SetProjectionLineWeight(Properties.Settings.Default.RevitOverrideInteriorCropWeight);

                                        //Grab all of the viewers, which are the viewport windows, and cycle through them
                                        var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                                        foreach (Element viewer in viewers)
                                        {
                                            //Get the parameters for the viewer
                                            ParameterSet parameters = viewer.Parameters;
                                            foreach (Parameter parameter in parameters)
                                            {
                                                //Get the View Name parameter
                                                if (parameter.Definition.Name.ToString() == "View Name")
                                                {                                                    
                                                    string viewName = parameter.AsString();
                                                    //If the view's view name is the same as the west elvation, continue
                                                    if (viewName == view0.Name)
                                                    {
                                                        //Set the view's override setting using the viewer and the OverrideGraphicsSettings
                                                        Autodesk.Revit.DB.View viewtouse = view0 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    //Continue to evaluate for the other view names
                                                    else if (viewName == view1.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view1 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else if (viewName == view2.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view2 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else if (viewName == view3.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view3 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else
                                                    {
                                                        //If the view's name is not one of the create elevation views, skip it
                                                        continue;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                t1.Commit();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                                t1.RollBack();
                            }
                            t1.Dispose();
                        }
                    }
                    catch
                    {
                        //If the user did not select any room tags or room elements, then report that
                        MessageBox.Show("No rooms were selected");
                    }
                }
            }
            else if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                //If the user tried to run this outside a plan view, report it
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                //If the user did not select an elevation type, report it
                MessageBox.Show("No elevation type selected");
            }
        }
    }
}
