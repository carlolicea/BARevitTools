using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class FloorsCFBRRequest
    {
        public FloorsCFBRRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FloorType selectedFloorType = null;

            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            string selectedFloorTypeName = uiForm.floorsCFBRSelectFloorTypeComboBox.Text.ToString();
            List<Room> roomElements = uiForm.floorsCFBRRoomsList;
            List<FloorType> floorTypes = RVTGetElementsByCollection.DocumentFloorTypes(uiApp);
            List<Floor> newFloors = new List<Floor>();

            
            if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                Transaction t1 = new Transaction(uidoc.Document, "CreateFloorsByRoom");
                t1.Start();
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
                    Options geomOptions = new Options();
                    geomOptions.IncludeNonVisibleObjects = true;
                    foreach (Room room in roomElements)
                    {
                        MessageBox.Show(room.Id.ToString());
                        IList<CurveLoop> faceCurveLoops = null;
                        Level roomLevel = room.Level;
                        GeometryElement roomGeomElements = room.get_Geometry(geomOptions);
                        Solid roomSolid = null;
                        foreach (GeometryObject geom in roomGeomElements)
                        {
                            if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                            {
                                roomSolid = geom as Solid;
                                break;
                            }
                        }

                        if (roomSolid != null)
                        {
                            FaceArray solidFaces = roomSolid.Faces;
                            foreach (PlanarFace solidFace in solidFaces)
                            {
                                XYZ faceNormal = solidFace.FaceNormal;
                                if (faceNormal.Z == -1)
                                {
                                    faceCurveLoops = solidFace.GetEdgesAsCurveLoops();
                                    break;
                                }
                            }
                        }

                        if (faceCurveLoops.Count != 0)
                        {
                            try
                            {
                                CurveArray curveArray = new CurveArray();
                                foreach (CurveLoop cloop in faceCurveLoops)
                                {
                                    CurveLoopIterator cLoopIter = cloop.GetCurveLoopIterator();
                                    while (cLoopIter.MoveNext())
                                    {
                                        curveArray.Append(cLoopIter.Current);
                                    }
                                }
                                Floor newFloor = uidoc.Document.Create.NewFloor(curveArray, selectedFloorType, roomLevel, false);
                                newFloors.Add(newFloor);
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("Floor could not be made for {0}, which is likely due to the room having more than one boundary loop. The Revit API only allows for one contiuous loop.", room.Number.ToString()));
                            }
                        }
                    }
                    t1.Commit();
                }
                catch { t1.RollBack(); }

                if (uiForm.floorsCFBROffsetFinishFloorCheckBox.Checked)
                {
                    Transaction t2 = new Transaction(uidoc.Document, "ElevateFloors");
                    t2.Start();
                    try
                    {
                        foreach (Floor floor in newFloors)
                        {
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement floorGeometry = floor.get_Geometry(geomOptions);
                            BoundingBoxXYZ floorBBox = floorGeometry.GetBoundingBox();
                            double bBoxMinZ = floorBBox.Min.Z;
                            double bBoxMaxZ = floorBBox.Max.Z;
                            double floorThickness = bBoxMaxZ - bBoxMinZ;
                            XYZ translation = new XYZ(0, 0, floorThickness);
                            ElementTransformUtils.MoveElement(uidoc.Document, floor.Id, translation);
                        }
                        t2.Commit();
                    }
                    catch { t2.RollBack(); }
                }
            }
            uiForm.adminDataGFFElementList = null;
        }
    }
}
