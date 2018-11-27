using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;


namespace BARevitTools.ToolRequests.ToolRequests
{
    class QaqcCSVRequest
    {
        public QaqcCSVRequest(UIApplication uiApp, String text)
        {
            DataTable dt = new DataTable();
            DataColumn paramIdColumn = dt.Columns.Add("ID", typeof(Int32));
            DataColumn paramNameColumn = dt.Columns.Add("Name", typeof(String));
            DataColumn paramElemColumn = dt.Columns.Add("Element", typeof(Object));
            List<string> fieldNamesCollection = new List<string>();
            List<Parameter> elementParameters = new List<Parameter>();
            List<DataRow> duplicateRows = new List<DataRow>();
            List<ElementId> idsToUpdate = new List<ElementId>();
            List<string> failList = new List<string>();
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DialogResult result = MessageBox.Show("Have you synchronized your model changes?", "Synchronization Prompt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (doc.ActiveView.ViewType == ViewType.Schedule)
                {
                    ViewSchedule viewSchedule = doc.ActiveView as ViewSchedule;
                    var scheduleCollector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
                    ScheduleDefinition scheduleDefinition = viewSchedule.Definition;
                    int scheduleFieldCount = scheduleDefinition.GetFieldCount();
                    for (int i = 0; i < scheduleFieldCount; i++)
                    {
                        ScheduleField scheduleField = scheduleDefinition.GetField(i);
                        fieldNamesCollection.Add(scheduleField.GetName().Replace("Material: ", ""));
                    }

                    foreach (Element elem in scheduleCollector)
                    {
                        foreach (Parameter instanceParam in elem.Parameters)
                        {
                            elementParameters.Add(instanceParam);
                            DataRow row = dt.NewRow();
                            row["ID"] = instanceParam.Id.IntegerValue;
                            row["Name"] = instanceParam.Definition.Name;
                            row["Element"] = instanceParam;
                            dt.Rows.Add(row);
                        }
                        ElementId typeId = elem.GetTypeId();
                        Element typeElement = doc.GetElement(typeId);
                        try
                        {
                            foreach (Parameter typeParameter in typeElement.Parameters)
                            {
                                elementParameters.Add(typeParameter);
                                DataRow row = dt.NewRow();
                                row["ID"] = typeParameter.Id.IntegerValue;
                                row["Name"] = typeParameter.Definition.Name;
                                row["Element"] = typeParameter;
                                dt.Rows.Add(row);
                            }
                        }
                        catch { continue; }
                    }

                    List<Parameter> elementParameterList = elementParameters.Distinct().ToList();
                    Hashtable hashTable = new Hashtable();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (hashTable.Contains(row["ID"]))
                        { duplicateRows.Add(row); }
                        else
                        { hashTable.Add(row["ID"], null); }
                    }
                    foreach (DataRow item in duplicateRows)
                    { dt.Rows.Remove(item); }

                    Transaction t1 = new Transaction(doc, "CapitalizeScheduleValues");
                    t1.Start();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            if (fieldNamesCollection.Contains(row["Name"].ToString()))
                            {
                                Parameter rowParam = row["Element"] as Parameter;
                                if (rowParam.StorageType == StorageType.String && !rowParam.IsReadOnly)
                                {
                                    idsToUpdate.Add(new ElementId(Convert.ToInt32(row["ID"])));
                                }
                            }
                        }
                        catch { continue; }
                    }
                    foreach (Element elem in scheduleCollector)
                    {
                        try
                        {
                            foreach (Parameter param in elementParameterList)
                            {
                                if (idsToUpdate.Contains(param.Id) && param.AsString() != null)
                                {
                                    if (!param.AsString().Contains("{") && !param.AsString().Contains("}"))
                                    {
                                        try { param.Set(param.AsString().ToUpper()); }
                                        catch { failList.Add(param.Definition.Name); continue; }
                                    }
                                }
                            }
                        }
                        catch { continue; }
                    }
                    t1.Commit();
                }

                else
                {
                    MessageBox.Show(String.Format("The currently active view is of type: {0}. " +
                 "Please make the desired schedule the active view by clicking into the schedule view and rerun the script",
                 doc.ActiveView.ViewType.ToString()));
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Please synchronize and/or save the model, then run again");
            }
            else
            {
                ;
            }

            if (failList.Count > 1)
            {
                string failMessage = StringOperations.BuildStringFromList(failList).ToString();
                MessageBox.Show(String.Format("Could not convert the following parameters: {0}", failMessage));
            }
        }
    }
}
