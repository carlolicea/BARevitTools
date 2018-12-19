using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class ViewsCEPRRequest
    {
        public ViewsCEPRRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            FilteredElementCollector viewTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> viewTypes = viewTypesCollector.OfClass(typeof(ViewFamilyType)).ToElements();
            ElementId viewTypeId = null;

            foreach (ViewFamilyType viewType in viewTypes)
            {
                if (viewType.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_NAME).AsString() == uiForm.viewsCEPRElevationComboBox.Text)
                {
                    viewTypeId = viewType.Id;
                }
            }

            if (viewTypeId != null && uidoc.ActiveView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
                List<Room> selectedRoomElements = RVTOperations.SelectRoomElements(uiApp);

                if (selectedRoomElements != null)
                {
                    try
                    {
                        foreach (Element roomElem in selectedRoomElements)
                        {
                            Room room = roomElem as Room;
                            string roomNumber = room.Number;
                            string roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME).AsString().ToUpper();
                            Level roomLevel = room.Level;
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = roomElem.get_Geometry(geomOptions);
                            LocationPoint roomLocation = room.Location as LocationPoint;
                            XYZ point = roomLocation.Point;

                            Transaction t1 = new Transaction(uidoc.Document, "Create Elevations Per Room");
                            t1.Start();
                            try
                            {
                                Solid roomSolid = null;
                                ElevationMarker newMarker = ElevationMarker.CreateElevationMarker(uidoc.Document, viewTypeId, point, 96);
                                ViewSection view0 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 0);
                                view0.Name = roomNumber + " " + roomName + " WEST";
                                view0.CropBoxActive = true;
                                ViewSection view1 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 1);
                                view1.Name = roomNumber + " " + roomName + " NORTH";
                                view1.CropBoxActive = true;
                                ViewSection view2 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 2);
                                view2.Name = roomNumber + " " + roomName + " EAST";
                                view2.CropBoxActive = true;
                                ViewSection view3 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 3);
                                view3.Name = roomNumber + " " + roomName + " SOUTH";
                                view3.CropBoxActive = true;


                                if (uiForm.viewsCEPRCropCheckBox.Checked == true)
                                {
                                    foreach (GeometryObject geom in geomElements)
                                    {
                                        if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                        {
                                            roomSolid = geom as Solid;
                                        }
                                    }

                                    Plane westPlane = Plane.CreateByNormalAndOrigin(new XYZ(-1, 0, 0), point);
                                    Plane northPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), point);
                                    Plane eastPlane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), point);
                                    Plane southPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), point);

                                    //Use the room section's perimeter as the crop boundary
                                    if (uiForm.viewsCEPRCropMethodComboBox.SelectedIndex == 0)
                                    {
                                        try
                                        {
                                            IList<CurveLoop> westCurveLoopsFitted = null;
                                            IList<CurveLoop> northCurveLoopsFitted = null;
                                            IList<CurveLoop> southCurveLoopsFitted = null;
                                            IList<CurveLoop> eastCurveLoopsFitted = null;

                                            Solid westBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, westPlane);
                                            FaceArray westBoolSolidFaces = westBooleanSolid.Faces;
                                            foreach (PlanarFace westFace in westBoolSolidFaces)
                                            {
                                                XYZ westFaceNormal = westFace.FaceNormal;
                                                if (westFaceNormal.X == 1)
                                                {
                                                    westCurveLoopsFitted = westFace.GetEdgesAsCurveLoops();
                                                    break;
                                                }
                                            }

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

                                            CurveLoop offsetWestCurveLoopFitted = CurveLoop.CreateViaOffset(westCurveLoopsFitted[0], (0.5d/12), XYZ.BasisX);
                                            ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                            westCropRegionShapeManager.SetCropShape(offsetWestCurveLoopFitted);

                                            CurveLoop offsetNorthCurveLoopFitted = CurveLoop.CreateViaOffset(northCurveLoopsFitted[0], -(0.5d / 12), XYZ.BasisY); ;
                                            ViewCropRegionShapeManager northCropRegionShapeManager = view1.GetCropRegionShapeManager();
                                            northCropRegionShapeManager.SetCropShape(offsetNorthCurveLoopFitted);

                                            CurveLoop offsetEastCurveLoopFitted = CurveLoop.CreateViaOffset(eastCurveLoopsFitted[0], -(0.5d / 12), XYZ.BasisX); ;
                                            ViewCropRegionShapeManager eastCropRegionShapeManager = view2.GetCropRegionShapeManager();
                                            eastCropRegionShapeManager.SetCropShape(offsetEastCurveLoopFitted);

                                            CurveLoop offsetSouthCurveLoopFitted = CurveLoop.CreateViaOffset(southCurveLoopsFitted[0], (0.5d / 12), XYZ.BasisY); ;
                                            ViewCropRegionShapeManager southCropRegionShapeManager = view3.GetCropRegionShapeManager();
                                            southCropRegionShapeManager.SetCropShape(offsetSouthCurveLoopFitted);
                                        }
                                        catch(Exception e)
                                        {
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                    
                                    //Use the room section's rectangular extents as the crop boundary
                                    if (uiForm.viewsCEPRCropMethodComboBox.SelectedIndex == 1)
                                    {
                                        try
                                        {
                                            IList<CurveLoop> westCurveLoopsRectangular = null;
                                            IList<CurveLoop> northCurveLoopsRectangular = null;
                                            IList<CurveLoop> southCurveLoopsRectangular = null;
                                            IList<CurveLoop> eastCurveLoopsRectangular = null;

                                            
                                            BoundingBoxXYZ roomBBox = roomSolid.GetBoundingBox();
                                            XYZ pt0 = new XYZ(roomBBox.Min.X, roomBBox.Min.Y, roomBBox.Min.Z);
                                            XYZ pt1 = new XYZ(roomBBox.Max.X, roomBBox.Min.Y, roomBBox.Min.Z);
                                            XYZ pt2 = new XYZ(roomBBox.Max.X, roomBBox.Max.Y, roomBBox.Min.Z);
                                            XYZ pt3 = new XYZ(roomBBox.Min.X, roomBBox.Max.Y, roomBBox.Min.Z);
                                            Line edge0 = Line.CreateBound(pt0, pt1);
                                            Line edge1 = Line.CreateBound(pt1, pt2);
                                            Line edge2 = Line.CreateBound(pt2, pt3);
                                            Line edge3 = Line.CreateBound(pt3, pt0);
                                            List<Curve> edges = new List<Curve>();
                                            edges.Add(edge0);
                                            edges.Add(edge1);
                                            edges.Add(edge2);
                                            edges.Add(edge3);
                                            List<CurveLoop> loops = new List<CurveLoop>();
                                            loops.Add(CurveLoop.Create(edges));
                                            Solid initialSolidBBox = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, (roomBBox.Max.Z - roomBBox.Min.Z));
                                            Solid roomSolidBBox = SolidUtils.CreateTransformed(initialSolidBBox, roomBBox.Transform);

                                            try
                                            {
                                                Solid westBooleanSolidBBox = BooleanOperationsUtils.CutWithHalfSpace(roomSolidBBox, westPlane);
                                                FaceArray westBoolSolidFacesBBox = westBooleanSolidBBox.Faces;
                                                foreach (PlanarFace westFace in westBoolSolidFacesBBox)
                                                {
                                                    XYZ westFaceNormal = westFace.FaceNormal;
                                                    if (westFaceNormal.X == 1)
                                                    {
                                                        westCurveLoopsRectangular = westFace.GetEdgesAsCurveLoops();
                                                        break;
                                                    }
                                                }
                                            }
                                            catch(Exception e)
                                            {
                                                MessageBox.Show(e.ToString());
                                            }                                            

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

                                            CurveLoop offsetWestCurveLoopRectangular = CurveLoop.CreateViaOffset(westCurveLoopsRectangular[0], 1, XYZ.BasisX);
                                            ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                            westCropRegionShapeManager.SetCropShape(offsetWestCurveLoopRectangular);

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

                                    if (uiForm.viewsCEPROverrideCheckBox.Checked == true)
                                    {
                                        OverrideGraphicSettings orgs = new OverrideGraphicSettings();
                                        orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
                                        orgs.SetProjectionLineWeight(5);

                                        var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                                        foreach (Element viewer in viewers)
                                        {
                                            ParameterSet parameters = viewer.Parameters;
                                            foreach (Parameter parameter in parameters)
                                            {
                                                if (parameter.Definition.Name.ToString() == "View Name")
                                                {
                                                    string viewName = parameter.AsString();
                                                    if (viewName == view0.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view0 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
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
                        MessageBox.Show("No rooms were selected");
                    }
                }
            }
            else if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                MessageBox.Show("No elevation type selected");
            }
        }
    }
}
