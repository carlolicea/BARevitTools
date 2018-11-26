using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
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

                            #region Transaction
                            Transaction t1 = new Transaction(uidoc.Document, "Create Elevations Per Room");
                            t1.Start();
                            try
                            {
                                IList<CurveLoop> westCurveLoops = null;
                                IList<CurveLoop> northCurveLoops = null;
                                IList<CurveLoop> southCurveLoops = null;
                                IList<CurveLoop> eastCurveLoops = null;
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
                                    Solid westBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, westPlane);
                                    FaceArray westBoolSolidFaces = westBooleanSolid.Faces;
                                    foreach (PlanarFace westFace in westBoolSolidFaces)
                                    {
                                        XYZ westFaceNormal = westFace.FaceNormal;
                                        if (westFaceNormal.X == 1)
                                        {
                                            westCurveLoops = westFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                    westCropRegionShapeManager.SetCropShape(westCurveLoops[0]);

                                    Plane northPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), point);
                                    Solid northBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, northPlane);
                                    FaceArray northBoolSolidFaces = northBooleanSolid.Faces;
                                    foreach (PlanarFace northFace in northBoolSolidFaces)
                                    {
                                        XYZ northFaceNormal = northFace.FaceNormal;
                                        if (northFaceNormal.Y == -1)
                                        {
                                            northCurveLoops = northFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager northCropRegionShapeManager = view1.GetCropRegionShapeManager();
                                    northCropRegionShapeManager.SetCropShape(northCurveLoops[0]);

                                    Plane eastPlane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), point);
                                    Solid eastBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, eastPlane);
                                    FaceArray eastBoolSolidFaces = eastBooleanSolid.Faces;
                                    foreach (PlanarFace eastFace in eastBoolSolidFaces)
                                    {
                                        XYZ eastFaceNormal = eastFace.FaceNormal;
                                        if (eastFaceNormal.X == -1)
                                        {
                                            eastCurveLoops = eastFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager eastCropRegionShapeManager = view2.GetCropRegionShapeManager();
                                    eastCropRegionShapeManager.SetCropShape(eastCurveLoops[0]);

                                    Plane southPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), point);
                                    Solid southBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, southPlane);
                                    FaceArray southBoolSolidFaces = southBooleanSolid.Faces;
                                    foreach (PlanarFace southFace in southBoolSolidFaces)
                                    {
                                        XYZ southFaceNormal = southFace.FaceNormal;
                                        if (southFaceNormal.Y == 1)
                                        {
                                            southCurveLoops = southFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager southCropRegionShapeManager = view3.GetCropRegionShapeManager();
                                    southCropRegionShapeManager.SetCropShape(southCurveLoops[0]);

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
                            catch
                            {
                                t1.RollBack();
                            }
                            t1.Dispose();
                            #endregion Transaction
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
