using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class QaqcRLSRequest
    {
        public QaqcRLSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView dgv = uiForm.qaqcRLSDataGridView;

            List<ElementId> unswitchableElements = new List<ElementId>();

            DataTable dt = new DataTable();
            DataColumn elementIdColumn = dt.Columns.Add("Element Id", typeof(ElementId));
            DataColumn groupNameColumn = dt.Columns.Add("Group Name", typeof(String));

            if (uiForm.qaqcRLSReplaceComboBox.Text == "<Replace>")
            {
                MessageBox.Show("Select the line style to replace");
            }
            else if (uiForm.qaqcRLSReplaceWithComboBox.Text == "<With>")
            {
                MessageBox.Show("Select the line style to replace with");
            }
            else
            {
                Category replaceStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceComboBox.Text.ToString()];
                Category replaceWithStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceWithComboBox.Text.ToString()];
                GraphicsStyle setStyle = replaceWithStyle.GetGraphicsStyle(GraphicsStyleType.Projection);

                var lineCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Lines).ToElements();
                Transaction t1 = new Transaction(doc, "ConvertLines");
                t1.Start();
                foreach (CurveElement elem in lineCollector)
                {
                    string lineStyleName = elem.LineStyle.Name;
                    ElementId groupId = elem.GroupId;

                    if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) == -1)
                    {
                        bool wasPinned = false;

                        if (elem.Pinned)
                        {
                            elem.Pinned = false;
                            wasPinned = true;
                        }

                        try
                        {
                            elem.LineStyle = setStyle;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            unswitchableElements.Add(elem.Id);
                            continue;
                        }

                        if (wasPinned)
                        {
                            elem.Pinned = true;
                        }
                    }

                    else if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) != -1)
                    {
                        unswitchableElements.Add(elem.Id);
                    }
                    else { continue; }
                }
                t1.Commit();

                var regionCollector = new FilteredElementCollector(doc).OfClass(typeof(FilledRegion)).ToElements().ToList();
                Transaction t2 = new Transaction(doc, "ReplaceRegions");
                t2.Start();
                foreach (FilledRegion region in regionCollector)
                {
                    ElementId regionId = region.Id;
                    SubTransaction st2 = new SubTransaction(doc);
                    st2.Start();
                    List<ElementId> deletedIds = doc.Delete(regionId).ToList();
                    st2.RollBack();

                    foreach (ElementId id in deletedIds)
                    {
                        Element regionSubElem = doc.GetElement(id);
                        if (regionSubElem.GetType().ToString() == "Autodesk.Revit.DB.DetailLine")
                        {
                            CurveElement curveElement = regionSubElem as CurveElement;
                            string sketchLineStyleName = curveElement.LineStyle.Name;
                            if (sketchLineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(region.GroupId.ToString()) == -1)
                            {
                                bool wasPinned = false;
                                if (region.Pinned)
                                {
                                    region.Pinned = false;
                                    wasPinned = true;
                                }

                                try
                                {
                                    curveElement.LineStyle = setStyle;
                                    XYZ z = XYZ.BasisZ;
                                    ElementTransformUtils.MoveElement(doc, region.Id, z);
                                    ElementTransformUtils.MoveElement(doc, region.Id, -z);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                    unswitchableElements.Add(region.Id);
                                    continue;
                                }

                                if (wasPinned)
                                {
                                    region.Pinned = true;
                                }
                            }
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

                foreach (ElementId elemId in unswitchableElements)
                {
                    DataRow row = dt.NewRow();
                    row["Element Id"] = elemId;
                    if (doc.GetElement(elemId).GroupId.IntegerValue != -1)
                    {
                        row["Group Name"] = doc.GetElement(doc.GetElement(elemId).GroupId).Name;
                    }
                    else { row["Group Name"] = ""; }
                    dt.Rows.Add(row);
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.Sort(dgv.Columns["Group Name"], ListSortDirection.Ascending);

                if (uiForm.qaqcRLSDeleteCheckBox.Checked && dt.Rows.Count == 0)
                {
                    Transaction t = new Transaction(doc, String.Format("Delete{0}", replaceStyle.Name));
                    t.Start();
                    try
                    {
                        doc.Delete(replaceStyle.Id);
                        t.Commit();
                        uiForm.qaqcRLSReplaceComboBox.Text = "<Replace>";
                        uiForm.qaqcRLSReplaceComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Text = "<With>";
                        uiForm.QaqcRLSSetReplaceComboBox(uiForm, doc);
                    }
                    catch
                    {
                        t.RollBack();
                        MessageBox.Show(String.Format("Could not delete {0}", replaceStyle.Name));
                    }
                }
                else { MessageBox.Show(String.Format("Could not Delete {0} because {1} instances could not be switched. See the table for instances in groups that could not be switched", replaceStyle.Name, dgv.Rows.Count.ToString())); }
            }
        }
    }
}
