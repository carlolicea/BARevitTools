using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Remove Line Styles tool
    class QaqcRLSRequest
    {
        public QaqcRLSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.qaqcRLSDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            List<ElementId> unswitchableElements = new List<ElementId>();
            
            //Creating a DataTable for this tool's operations
            DataTable dt = new DataTable();
            DataColumn elementIdColumn = dt.Columns.Add("Element Id", typeof(ElementId));
            DataColumn groupNameColumn = dt.Columns.Add("Group Name", typeof(String));
                       
            if (uiForm.qaqcRLSReplaceComboBox.Text == "<Replace>")
            {
                //If the user has not selected a line style to replace, remind them
                MessageBox.Show("Select the line style to replace");
            }
            else if (uiForm.qaqcRLSReplaceWithComboBox.Text == "<With>")
            {
                //If the user has not selected a line style to use as a replacement, remind them
                MessageBox.Show("Select the line style to replace with");
            }
            else
            {
                //Otherwise, they did a good job following instructions and they can continue. Get the line styles to use from the dictionary
                Category replaceStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceComboBox.Text.ToString()];
                Category replaceWithStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceWithComboBox.Text.ToString()];
                //The Projection style is needed from the line style to use in the replacement
                GraphicsStyle setStyle = replaceWithStyle.GetGraphicsStyle(GraphicsStyleType.Projection);
                                
                //Start a new transaction
                Transaction t1 = new Transaction(doc, "ConvertLines");
                t1.Start();

                //Collect all of the lines in the project, then cycle through them
                var lineCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Lines).ToElements();
                foreach (CurveElement elem in lineCollector)
                {
                    //Get the name of the line style and the GroupId of the group it belongs to
                    string lineStyleName = elem.LineStyle.Name;
                    ElementId groupId = elem.GroupId;

                    //If the name of the line style is the same as the one to replace, and its GroupId is -1 (no group), continue
                    if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) == -1)
                    {
                        //Create a boolean variable to save the pinned state
                        bool wasPinned = false;

                        //If the line is pinned, unpin it and set the wasPinned variable to true
                        if (elem.Pinned)
                        {
                            elem.Pinned = false;
                            wasPinned = true;
                        }

                        //Then, set the line's line style to the style to use in the replacement
                        try
                        {
                            elem.LineStyle = setStyle;
                        }
                        catch (Exception e)
                        {
                            //If it could not be switched, add it to the list
                            MessageBox.Show(e.ToString());
                            unswitchableElements.Add(elem.Id);
                            continue;
                        }

                        //If the line had been pinned, repin it
                        if (wasPinned)
                        {
                            elem.Pinned = true;
                        }
                    }

                    //If the line style matched the name of the line style to replace, but it belonged to a group, add the line to the list of elements that could not be switched
                    else if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) != -1)
                    {
                        unswitchableElements.Add(elem.Id);
                    }
                    else { continue; }
                }
                t1.Commit();

                //Start another transaction
                Transaction t2 = new Transaction(doc, "ReplaceRegions");
                t2.Start();
                //Next, evaluate all filled regions for their sketch boundary lines
                var regionCollector = new FilteredElementCollector(doc).OfClass(typeof(FilledRegion)).ToElements().ToList();
                foreach (FilledRegion region in regionCollector)
                {
                    //Get the ID of the filled region
                    ElementId regionId = region.Id;
                    //Start a subtransaction because the region must be deleted to get the sketch lines that were deleted.
                    SubTransaction st2 = new SubTransaction(doc);
                    st2.Start();
                    //Collect the list of element Ids deleted from the deletion
                    List<ElementId> deletedIds = doc.Delete(regionId).ToList();
                    //Roll back the subtransaction to undelete the filled region
                    st2.RollBack();

                    //Now we know what sketch lines belong to the filled region. Evaluate each ElementId from the subtransaction
                    foreach (ElementId id in deletedIds)
                    {
                        Element regionSubElem = doc.GetElement(id);
                        //Determine if the element is a detail line
                        if (regionSubElem.GetType().ToString() == "Autodesk.Revit.DB.DetailLine")
                        {
                            //If it is a detail line, get the curve of the line, then its line style name
                            CurveElement curveElement = regionSubElem as CurveElement;
                            string sketchLineStyleName = curveElement.LineStyle.Name;
                            //If the line style name matches the name of the line style to replace, and the region does not belong to a group, continue
                            if (sketchLineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(region.GroupId.ToString()) == -1)
                            {
                                //Again, determin if the region was pinned, just like the lines
                                bool wasPinned = false;
                                if (region.Pinned)
                                {
                                    region.Pinned = false;
                                    wasPinned = true;
                                }
                                                                
                                try
                                {
                                    //Change the line style of the curve
                                    curveElement.LineStyle = setStyle;
                                    XYZ z = XYZ.BasisZ;
                                    //Then, move the region up and then down in the Z axis to cause a redraw.
                                    ElementTransformUtils.MoveElement(doc, region.Id, z);
                                    ElementTransformUtils.MoveElement(doc, region.Id, -z);
                                }
                                catch (Exception e)
                                {
                                    //If the region's sketch lines could not be switched, add it to the list of elements that could not be switched
                                    MessageBox.Show(e.ToString());
                                    unswitchableElements.Add(region.Id);
                                    continue;
                                }

                                if (wasPinned)
                                {
                                    region.Pinned = true;
                                }
                            }
                            //If the region belonged to a group, add it to the list of elements that could not be switched immediately
                            else if (sketchLineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(region.GroupId.ToString()) != -1)
                            {
                                unswitchableElements.Add(region.Id);
                                continue;
                            }
                            else { continue; }
                        }
                        else { continue; }
                    }
                }
                t2.Commit();

                //Now, for each element in the unswitchableElements list...
                foreach (ElementId elemId in unswitchableElements)
                {
                    //Create a new row and fill it out with the ElementId and group name if it exists
                    DataRow row = dt.NewRow();
                    row["Element Id"] = elemId;
                    if (doc.GetElement(elemId).GroupId.IntegerValue != -1)
                    {
                        row["Group Name"] = doc.GetElement(doc.GetElement(elemId).GroupId).Name;
                    }
                    else { row["Group Name"] = ""; }
                    dt.Rows.Add(row);
                }

                //Bind the DataTable to the DataGridView
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                //Turn off the blank column at the beginning of the rows
                dgv.RowHeadersVisible = false;
                //Set the row selection to be full row selection
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //Sort the rows by the group name
                dgv.Sort(dgv.Columns["Group Name"], ListSortDirection.Ascending);

                //If the user wanted to delete the line styles, and nothing is preventing it because the DataTable has no rows, continue
                if (uiForm.qaqcRLSDeleteCheckBox.Checked && dt.Rows.Count == 0)
                {
                    //New transaction
                    Transaction t = new Transaction(doc, String.Format("Delete{0}", replaceStyle.Name));
                    t.Start();
                    try
                    {
                        //Delete the linestyle
                        doc.Delete(replaceStyle.Id);
                        t.Commit();
                        //Reset the combo boxes from the MainUI and reset them with new data of existing Line Styles
                        uiForm.qaqcRLSReplaceComboBox.Text = "<Replace>";
                        uiForm.qaqcRLSReplaceComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Text = "<With>";
                        uiForm.QaqcRLSSetReplaceComboBox(uiForm, doc);
                    }
                    catch
                    {
                        //If the deletion fails, roll back the transaction and let the user know
                        t.RollBack();
                        MessageBox.Show(String.Format("Could not delete {0}", replaceStyle.Name));
                    }
                }
                else
                {
                    //If there were instances that could not be switched, report this to the user, and instruct them to check the table for the groups where the instances occur
                    MessageBox.Show(String.Format("Could not delete {0} because {1} instances could not be switched. See the the table for instances in groups +" +
                        "that could not be switched.", replaceStyle.Name, dgv.Rows.Count.ToString()));
                }
            }
        }
    }
}
