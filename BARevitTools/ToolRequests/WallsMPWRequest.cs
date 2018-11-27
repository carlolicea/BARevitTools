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
    class WallsMPWRequest
    {
        public WallsMPWRequest (UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;

            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector levelsCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector wallTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> existingLevels = levelsCollector.OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().ToElements();
            ICollection<Element> existingWallTypes = wallTypesCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsElementType().ToElements();
            List<Line> wallLines = new List<Line>();
            List<Wall> newWalls = new List<Wall>();
            List<Element> selectedElements = new List<Element>();
            string selectedWallTypeName = uiForm.wallsMPWComboBoxWall.Text.ToString();
            WallType wallTypeInput = null;
            double wallHeightInput = 0;

            if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                try
                {
                    wallHeightInput = (Convert.ToDouble(uiForm.wallsMPWNumericUpDownWallHeightFt.Value + (uiForm.wallsMPWNumericUpDownWallHeightIn.Value / 12)));
                }
                catch
                {
                    throw new System.ArgumentException("Invalid wall height");
                }

                double offsetDistance = 0;
                try
                {
                    foreach (WallType wallType in existingWallTypes)
                    {
                        if (wallType.Name == selectedWallTypeName)
                        {
                            wallTypeInput = wallType;
                            offsetDistance = (wallTypeInput.Width) / 2;
                            break;
                        }
                    }
                }
                catch
                {
                    new System.ArgumentException("No wall type was selected");
                }

                ViewPlan activeView = uidoc.Document.ActiveView as ViewPlan;
                Level levelInput = activeView.GenLevel;

                if (wallTypeInput != null && levelInput != null && wallHeightInput != 0)
                {
                    IList<Reference> elemReferences = new List<Reference>();
                    elemReferences = uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element);

                    foreach (Reference selectedReference in elemReferences)
                    {
                        ElementId referenceId = selectedReference.ElementId;
                        Element referenceElement = uidoc.Document.GetElement(referenceId);
                        selectedElements.Add(referenceElement);
                    }

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
                        }
                    }

                    foreach (Element roomElem in selectedRoomElements)
                    {
                        try
                        {
                            Location roomLocation = roomElem.Location;
                            LocationPoint rlp = roomLocation as LocationPoint;
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = roomElem.get_Geometry(geomOptions);
                            foreach (GeometryObject geomObject in geomElements)
                            {
                                if (geomObject.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                {
                                    Solid roomSolid = geomObject as Solid;
                                    FaceArray roomSolidFaces = roomSolid.Faces;
                                    foreach (PlanarFace roomSolidFace in roomSolidFaces)
                                    {
                                        XYZ faceNormal = roomSolidFace.FaceNormal;
                                        if (faceNormal.Z == -1)
                                        {
                                            IList<CurveLoop> faceCurveLoops = roomSolidFace.GetEdgesAsCurveLoops();
                                            foreach (CurveLoop curveLoop in faceCurveLoops)
                                            {
                                                CurveLoop offsetCurveLoops = CurveLoop.CreateViaOffset(curveLoop, offsetDistance, XYZ.BasisZ);
                                                foreach (Line line in offsetCurveLoops)
                                                {
                                                    wallLines.Add(line);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        catch { continue; }
                    }

                    Transaction t1 = new Transaction(uidoc.Document, "MakeWalls");
                    t1.Start();
                    foreach (Line wallLine in wallLines)
                    {
                        Wall newWall = Wall.Create(uidoc.Document, wallLine, wallTypeInput.Id, levelInput.Id, wallHeightInput, 0, true, false);
                        newWalls.Add(newWall);
                    }
                    t1.Commit();

                    Transaction t2 = new Transaction(uidoc.Document, "JoinWalls");
                    t2.Start();
                    foreach (Wall newWall in newWalls)
                    {
                        FilteredElementCollector existingWallsCollector = new FilteredElementCollector(uidoc.Document, uidoc.ActiveView.Id);
                        existingWallsCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElements();
                        BoundingBoxXYZ wallBBox = newWall.get_BoundingBox(uidoc.Document.ActiveView);
                        Outline wallBBoxOutline = new Outline(wallBBox.Min, wallBBox.Max);
                        BoundingBoxIntersectsFilter bBoxFilter = new BoundingBoxIntersectsFilter(wallBBoxOutline);
                        existingWallsCollector.WherePasses(bBoxFilter);
                        foreach (Wall existingWall in existingWallsCollector)
                        {
                            try
                            {
                                JoinGeometryUtils.JoinGeometry(uidoc.Document, newWall, existingWall);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    t2.Commit();
                    t1.Dispose();
                    t2.Dispose();
                }
                else if (levelInput == null)
                {
                    MessageBox.Show("No level set");
                }
                else if (wallTypeInput == null)
                {
                    MessageBox.Show("No wall type set");
                }
                else if (wallHeightInput <= 0)
                {
                    MessageBox.Show("Wall height must be set to greater than 0");
                }
                else
                {
                    MessageBox.Show(wallTypeInput.Id.ToString());
                    MessageBox.Show(levelInput.Id.ToString());
                    MessageBox.Show(wallHeightInput.ToString());
                }
            }
        }
    }
}
