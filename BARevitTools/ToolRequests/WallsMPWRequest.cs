using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is related to the Make Perimeter Walls tool
    class WallsMPWRequest
    {
        public WallsMPWRequest (UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Collect all the levels
            FilteredElementCollector levelsCollector = new FilteredElementCollector(doc);
            ICollection<Element> existingLevels = levelsCollector.OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().ToElements();
            //Collect the wall types
            FilteredElementCollector wallTypesCollector = new FilteredElementCollector(doc);
            ICollection<Element> existingWallTypes = wallTypesCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsElementType().ToElements();

            List<Line> wallLines = new List<Line>();
            List<Wall> newWalls = new List<Wall>();
            List<Element> selectedElements = new List<Element>();
            //Get the wall type name from the MainUI combobox
            string selectedWallTypeName = uiForm.wallsMPWComboBoxWall.Text.ToString();
            WallType wallTypeInput = null;
            double wallHeightInput = 0;

            //Ensure the active view is a plan view
            if (doc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                try
                {
                    //Get the height of the walls to create from the MainUI, converted to a Double value in decimal feet
                    wallHeightInput = (Convert.ToDouble(uiForm.wallsMPWNumericUpDownWallHeightFt.Value + (uiForm.wallsMPWNumericUpDownWallHeightIn.Value / 12)));
                }
                catch
                {
                    //If the wall height input is invalid, let the user know
                    throw new System.ArgumentException("Invalid wall height");
                }

                double offsetDistance = 0;
                try
                {
                    //To get the distance to offset the wall, get the wall type's thickness, then divide it in half because walls are placed along the centerline
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

                //Get the active view and its associated level
                ViewPlan activeView = doc.ActiveView as ViewPlan;
                Level levelInput = activeView.GenLevel;

                //If the user selected a wall type, the level was obtained from the view, and the wall height is valid, continue
                if (wallTypeInput != null && levelInput != null && wallHeightInput != 0)
                {
                    //Invoke selection of the rooms and get them from either the rooms or room tags selected
                    List<Room> selectedRoomElements = RVTOperations.SelectRoomElements(uiApp);

                    //Cycle through the room elements
                    foreach (Room roomElem in selectedRoomElements)
                    {
                        try
                        {
                            //Get the location of the room as a point
                            Location roomLocation = roomElem.Location;
                            LocationPoint rlp = roomLocation as LocationPoint;

                            //Get the room geometry
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = roomElem.get_Geometry(geomOptions);
                            foreach (GeometryObject geomObject in geomElements)
                            {
                                if (geomObject.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                {
                                    //Grab the solid form of the room geometry
                                    Solid roomSolid = geomObject as Solid;
                                    FaceArray roomSolidFaces = roomSolid.Faces;
                                    foreach (PlanarFace roomSolidFace in roomSolidFaces)
                                    {
                                        //Get the bottom face of the room which is the face that has a -Z vector
                                        XYZ faceNormal = roomSolidFace.FaceNormal;
                                        if (faceNormal.Z == -1)
                                        {
                                            //Get the CurveLoops for the bottom face
                                            IList<CurveLoop> faceCurveLoops = roomSolidFace.GetEdgesAsCurveLoops();
                                            foreach (CurveLoop curveLoop in faceCurveLoops)
                                            {
                                                //Offset the CurveLoop by the half thickness of the wall
                                                CurveLoop offsetCurveLoops = CurveLoop.CreateViaOffset(curveLoop, offsetDistance, XYZ.BasisZ);
                                                foreach (Line line in offsetCurveLoops)
                                                {
                                                    //Collect the lines to draw walls along
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

                    //Start a transaction
                    using (Transaction t1 = new Transaction(doc, "MakeWalls"))
                    {
                        t1.Start();
                        foreach (Line wallLine in wallLines)
                        {
                            //Draw a line along each of the lines and add them to a list of walls created
                            Wall newWall = Wall.Create(doc, wallLine, wallTypeInput.Id, levelInput.Id, wallHeightInput, 0, true, false);
                            newWalls.Add(newWall);
                        }
                        t1.Commit();
                    }

                    //Start a new transaction to join the walls to adjacent walls
                    using (Transaction t2 = new Transaction(doc, "JoinWalls"))
                    {
                        t2.Start();
                        foreach (Wall newWall in newWalls)
                        {
                            //Collect the walls in the project
                            FilteredElementCollector existingWallsCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                            existingWallsCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElements();
                            //Get the bounding box of each wall
                            BoundingBoxXYZ wallBBox = newWall.get_BoundingBox(doc.ActiveView);
                            //Get the outline of the bounding box using the minimum and maximum points
                            Outline wallBBoxOutline = new Outline(wallBBox.Min, wallBBox.Max);
                            //Generate a new BoundingBoxIntersectsFilter to find the other bounding boxes that intersect the outline
                            BoundingBoxIntersectsFilter bBoxFilter = new BoundingBoxIntersectsFilter(wallBBoxOutline);
                            //Get all walls that pass the filter (they intersect the evaluated new wall's outline)
                            existingWallsCollector.WherePasses(bBoxFilter);
                            foreach (Wall existingWall in existingWallsCollector)
                            {
                                try
                                {
                                    //Try to joing the new wall to the existing walls so they are cut by the hosted elements
                                    JoinGeometryUtils.JoinGeometry(doc, newWall, existingWall);
                                }
                                catch {continue;}
                            }
                        }
                        t2.Commit();
                    }                        
                }
                else if (levelInput == null)
                {
                    //Let the user know if the level could not be obtained
                    MessageBox.Show("No level set");
                }
                else if (wallTypeInput == null)
                {
                    //Let the user know if they didn't select a wall type
                    MessageBox.Show("No wall type set");
                }
                else if (wallHeightInput <= 0)
                {
                    //Let the user know if they specified a 0 or negative wall height
                    MessageBox.Show("Wall height must be set to greater than 0'");
                }
                else
                {
                    //If for some reason the script fails, report that one of the following settings could not be used. This is highly unlikely though
                    MessageBox.Show(String.Format("One of the following settings could not be used: Wall Type = '{0}'; " +
                        "Level = '{1}'; " +
                        "Wall Height = '{2}'", 
                        ((Wall)doc.GetElement(wallTypeInput.Id)).WallType.Name.ToString(),
                        ((Level)doc.GetElement(levelInput.Id)).Name.ToString(),
                        (wallHeightInput/12d).ToString()));
                }
            }
        }
    }
}
