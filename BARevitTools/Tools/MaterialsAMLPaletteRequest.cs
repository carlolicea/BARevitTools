using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
{
    class MaterialsAMLPaletteRequest
    {
        public MaterialsAMLPaletteRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            MaterialsAMLPalette materialsPalette = BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette;

            //Get the versioned symbol family
            FamilySymbol familySymbol = null;
            string versionedFamily = RVTOperations.GetVersionedFamilyFilePath(uiApp, BARevitTools.Properties.Settings.Default.RevitIDAccentMatTag);

            //Try loading the family symbol
            Transaction loadSymbolTransaction = new Transaction(doc, "LoadFamilySymbol");
            loadSymbolTransaction.Start();
            try
            {
                try
                {
                    IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();
                    doc.LoadFamilySymbol(versionedFamily, "Legend Tag (Fake)", loadOptions, out FamilySymbol symb);
                    familySymbol = symb;
                }
                catch
                {
                    MessageBox.Show(String.Format("Could not get the 'Legend Tag (Fake)' type from {0}", versionedFamily), "Family Symbol Load Error");
                }
                loadSymbolTransaction.Commit();
            }
            catch (Exception transactionException)
            { loadSymbolTransaction.RollBack(); MessageBox.Show(transactionException.ToString()); }

            //Get the line style to use, or create the default
            Element lineStyle = null;
            if (materialsPalette.paletteMaterialComboBox.Text == "Default")
            {
                try
                {
                    lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines).SubCategories.get_Item("6 BA ID ACCENT").GetGraphicsStyle(GraphicsStyleType.Projection);
                }
                catch
                {
                    try
                    {
                        Category linesCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
                        Category newLineStyleCategory = doc.Settings.Categories.NewSubcategory(linesCategory, "6 BA ID ACCENT");
                        newLineStyleCategory.LineColor = new Color(0, 0, 0);
                        newLineStyleCategory.SetLineWeight(6, GraphicsStyleType.Projection);
                        newLineStyleCategory.SetLinePatternId(LinePatternElement.GetSolidPatternId(), GraphicsStyleType.Projection);
                        doc.Regenerate();
                        lineStyle = newLineStyleCategory.GetGraphicsStyle(GraphicsStyleType.Projection);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
            else
            {
                lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines).SubCategories.get_Item("ID " + materialsPalette.paletteMaterialComboBox.Text).GetGraphicsStyle(GraphicsStyleType.Projection);
            }

            //Assure the view being used is a floor plan
            if (doc.ActiveView.ViewType != ViewType.FloorPlan)
            {
                MessageBox.Show("This tool should be used ina a Floor Plan or Area Plan view");
            }
            else
            {
                //Create a loop for picking points. Change the palette background color based on the number of points picked
                List<XYZ> pickedPoints = new List<XYZ>();
                bool breakLoop = false;
                int pickCount = 0;
                while (breakLoop == false)
                {
                    try
                    {
                        XYZ point = uiApp.ActiveUIDocument.Selection.PickPoint(Autodesk.Revit.UI.Selection.ObjectSnapTypes.Endpoints, "Click points for the line to follow. Then click once to the side where the lines should be drawn. Hit ESC to finish");
                        pickedPoints.Add(point);

                        if (pickCount == 1)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.Firebrick;
                        }
                        else if (pickCount == 2)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.Orange;
                        }
                        else if (pickCount > 2)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.GreenYellow;
                        }
                        else {; }

                        pickCount++;
                    }
                    catch
                    {
                        materialsPalette.BackColor = MaterialsAMLPalette.DefaultBackColor;
                        breakLoop = true;
                    }
                }

                //Get rid of the first point from clicking into the Revit view. This point is not needed.
                pickedPoints.RemoveAt(0);

                if (pickedPoints.Count > 2)
                {
                    Transaction createLinesTransaction = new Transaction(doc, "CreateAccentLines");
                    createLinesTransaction.Start();

                    try
                    {
                        //These points will be used in determining the start, end, and room points
                        XYZ firstPoint = pickedPoints[0];
                        XYZ roomPoint = pickedPoints[pickedPoints.Count - 1];
                        XYZ lastPoint = pickedPoints[pickedPoints.Count - 2];

                        //Create  a list of points for the polyline that excludes the room point
                        List<XYZ> polyLinePoints = new List<XYZ>();
                        for (int i = 0; i < pickedPoints.Count - 1; i++)
                        {
                            polyLinePoints.Add(pickedPoints[i]);
                        }

                        //Create a polyline from the list of picked points and then get make lines from the points on the poly line
                        PolyLine guidePolyLine = PolyLine.Create(polyLinePoints);
                        IList<XYZ> polyPoints = guidePolyLine.GetCoordinates();

                        List<Line> guideLines = new List<Line>();
                        for (int i = 0; i < polyLinePoints.Count - 1; i++)
                        {
                            guideLines.Add(Line.CreateBound(polyLinePoints[i], polyLinePoints[i + 1]));
                        }

                        //Get the direction of the line offset by measuring the first offset for positive and negative values and comparing their distances the room point
                        bool positiveZ = false;

                        List<Line> offsetLines = new List<Line>();
                        Line positiveOffsetLine = guideLines.Last().CreateOffset(0.6666666667d, XYZ.BasisZ) as Line;
                        Line negativeOffsetLine = guideLines.Last().CreateOffset(-0.6666666667d, XYZ.BasisZ) as Line;
                        XYZ positiveOffsetMidPoint = positiveOffsetLine.Evaluate(0.5d, true);
                        XYZ negativeOffsetMidPoint = negativeOffsetLine.Evaluate(0.5d, true);

                        Double positiveOffsetDistance = positiveOffsetMidPoint.DistanceTo(roomPoint);
                        Double negativeOffsetDistance = negativeOffsetMidPoint.DistanceTo(roomPoint);

                        if (positiveOffsetDistance < negativeOffsetDistance)
                        {
                            positiveZ = true;
                        }

                        //Knowing whether or not to use a positive or negative offset, begin creating offset lines for each guide line
                        foreach (Line guideLine in guideLines)
                        {
                            if (positiveZ)
                            {
                                offsetLines.Add(guideLine.CreateOffset(0.6666666667d, XYZ.BasisZ) as Line);
                            }
                            else
                            {
                                offsetLines.Add(guideLine.CreateOffset(-0.6666666667d, XYZ.BasisZ) as Line);
                            }

                        }

                        //Determine if the number of line segments is 1 or more
                        Line firstLine = offsetLines.First();
                        Line lastLine = null;
                        if (offsetLines.Count > 1)
                        {
                            lastLine = offsetLines.Last();
                        }

                        //If there is only one line segment, both end operations must be performed on it
                        if (lastLine == null)
                        {

                            double lineLength = firstLine.Length;
                            double fractionOfLength = 0.6666666667d / lineLength;

                            //Checking fractions to ensure they are not greater than 1 for the normalization
                            if (fractionOfLength > 1)
                            {
                                fractionOfLength = 0.25d;
                            }

                            //Re-evaluating where to place the start and end point of the line
                            XYZ shiftedStartPoint = firstLine.Evaluate(fractionOfLength, true);
                            XYZ shiftedEndPoint = firstLine.Evaluate(1 - fractionOfLength, true);
                            firstLine = Line.CreateBound(shiftedStartPoint, shiftedEndPoint);

                            //Creating the angled corner lines 
                            Line firstCornerLine = Line.CreateBound(firstPoint, firstLine.GetEndPoint(0));
                            Line lastCornerLine = Line.CreateBound(lastPoint, firstLine.GetEndPoint(1));

                            //Create the detail lines from the lines
                            DetailCurve newAccentLine1 = doc.Create.NewDetailCurve(doc.ActiveView, firstCornerLine);
                            DetailCurve newAccentLine2 = doc.Create.NewDetailCurve(doc.ActiveView, firstLine);
                            DetailCurve newAccentLine3 = doc.Create.NewDetailCurve(doc.ActiveView, lastCornerLine);

                            //Assign a line style to the newly created detail lines
                            newAccentLine1.LineStyle = lineStyle;
                            newAccentLine2.LineStyle = lineStyle;
                            newAccentLine3.LineStyle = lineStyle;


                            XYZ tagPlacementPoint = firstLine.Evaluate(0.5d, true);
                            XYZ direction = firstLine.Direction;
                            Line axisLine = Line.CreateUnbound(tagPlacementPoint, XYZ.BasisZ);
                            double rotationAngle = direction.AngleTo(XYZ.BasisX);

                            //Get the midpoint of the line, its direction, and create the rotation and axis
                            if (familySymbol != null)
                            {
                                //Create the tag instance
                                FamilyInstance newTag = doc.Create.NewFamilyInstance(tagPlacementPoint, familySymbol, doc.ActiveView);
                                //Rotate the new tag instance
                                ElementTransformUtils.RotateElement(doc, newTag.Id, axisLine, rotationAngle);
                            }

                            createLinesTransaction.Commit();
                        }
                        //If there is more than one line segment, an operation must be performed on the start and end of the start and end lines, respectively
                        else
                        {

                            List<Line> linesToDraw = new List<Line>();
                            // Get the normalized value for 8" relative to the lengths of the start and end lines
                            double firstLineLength = firstLine.Length;
                            double fractionOfFirstLine = 0.6666666667 / firstLineLength;
                            double lastLineLength = lastLine.Length;
                            double fractionOfLastLine = 0.666666667 / lastLineLength;

                            //Checking fractions to ensure they are not greater than 1 for the normalization
                            if (fractionOfFirstLine > 1)
                            {
                                fractionOfFirstLine = 0.25d;
                            }
                            if (fractionOfLastLine > 1)
                            {
                                fractionOfLastLine = 0.25d;
                            }

                            //Shift the ends of the start and end lines by finding the point along the line relative to the normalized 8" value
                            XYZ shiftedStartPoint = firstLine.Evaluate(fractionOfFirstLine, true);
                            XYZ shiftedEndPoint = lastLine.Evaluate(1 - fractionOfLastLine, true);

                            //Reset the start and end lines with the new shifted points
                            firstLine = Line.CreateBound(shiftedStartPoint, firstLine.GetEndPoint(1));
                            lastLine = Line.CreateBound(lastLine.GetEndPoint(0), shiftedEndPoint);
                            linesToDraw.Add(firstLine);

                            //If there are only 3 offset lines, there will be just one middle segment
                            if (offsetLines.Count == 3)
                            {
                                linesToDraw.Add(offsetLines[1]);
                            }
                            //If there are more than three offset lines, there will be more than one middle line segment                            
                            else
                            {
                                List<Line> middleLines = offsetLines.GetRange(1, offsetLines.Count - 2);
                                foreach (Line middleLine in middleLines)
                                {
                                    linesToDraw.Add(middleLine);
                                }
                            }
                            linesToDraw.Add(lastLine);

                            //For the lines to draw, intersect them with the next line in the list and reset their start and end points to be the intersection
                            for (int i = 0; i < linesToDraw.Count - 1; i++)
                            {
                                Line line1 = linesToDraw[i];
                                Line scaledLine1 = Line.CreateUnbound(line1.GetEndPoint(1), line1.Direction);
                                Line line2 = linesToDraw[i + 1];
                                Line scaledLine2 = Line.CreateUnbound(line2.GetEndPoint(0), line2.Direction.Negate());
                                SetComparisonResult intersectionResult = scaledLine1.Intersect(scaledLine2, out IntersectionResultArray results);
                                if (intersectionResult == SetComparisonResult.Overlap)
                                {
                                    IntersectionResult result = results.get_Item(0);
                                    Line newLine1 = Line.CreateBound(line1.GetEndPoint(0), result.XYZPoint);
                                    Line newLine2 = Line.CreateBound(result.XYZPoint, line2.GetEndPoint(1));

                                    linesToDraw[i] = newLine1;
                                    linesToDraw[i + 1] = newLine2;
                                }
                            }

                            //Create the angled corner lines at the start and end of the line chain
                            Line firstCornerLine = Line.CreateBound(firstPoint, firstLine.GetEndPoint(0));
                            Line lastCornerLine = Line.CreateBound(lastPoint, lastLine.GetEndPoint(1));
                            linesToDraw.Add(firstCornerLine);
                            linesToDraw.Add(lastCornerLine);

                            //Create each line as a detail line
                            foreach (Line apiLine in linesToDraw)
                            {
                                DetailCurve newAccentLine = doc.Create.NewDetailCurve(doc.ActiveView, apiLine);
                                newAccentLine.LineStyle = lineStyle;
                            }

                            //Declare some stuff for use in the symbol placement
                            Line firstMiddleLine = linesToDraw[0];
                            Line lastMiddleLine = linesToDraw[linesToDraw.Count - 3];
                            XYZ firstTagPoint = firstMiddleLine.Evaluate(0.5d, true);
                            XYZ lastTagPoint = lastMiddleLine.Evaluate(0.5d, true);
                            XYZ firstDirection = firstMiddleLine.Direction;
                            XYZ lastDirection = lastMiddleLine.Direction;
                            Line firstAxisLine = Line.CreateUnbound(firstTagPoint, XYZ.BasisZ);
                            Line lastAxisLine = Line.CreateUnbound(lastTagPoint, XYZ.BasisZ);
                            double firstRotation = firstDirection.AngleTo(XYZ.BasisX);
                            double lastRotation = lastDirection.AngleTo(XYZ.BasisX);

                            if (familySymbol != null)
                            {
                                //Create tag at the beginning of the middle lines
                                FamilyInstance firstTag = doc.Create.NewFamilyInstance(firstTagPoint, familySymbol, doc.ActiveView);
                                ElementTransformUtils.RotateElement(doc, firstTag.Id, firstAxisLine, firstRotation);

                                //Create a tag at the end of the middle lines if there are more than 2 middle lines
                                if (linesToDraw.Count > 4)
                                {
                                    FamilyInstance lastTag = doc.Create.NewFamilyInstance(lastTagPoint, familySymbol, doc.ActiveView);
                                    ElementTransformUtils.RotateElement(doc, lastTag.Id, lastAxisLine, lastRotation);
                                }
                            }

                            createLinesTransaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette == null)
                        {
                            MessageBox.Show("AML Picker was closed prematurely. Please keep the picker open until the lines are drawn.");
                        }
                        else
                        {
                            var st = new StackTrace(e, true);
                            var LineNumber = st.GetFrame(st.FrameCount - 1).GetFileLineNumber();
                            MessageBox.Show("Exception \"" + e.ToString() + "\" was thrown at line: " + LineNumber.ToString());
                        }
                        createLinesTransaction.RollBack();
                    }
                }
                else
                {
                    ;
                }
            }
        }
    }
}
