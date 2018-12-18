using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;


namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Capitalize Schedule Values tool that capitalizes all text parameter values displayed in a schedule view
    class QaqcCSVRequest
    {
        public QaqcCSVRequest(UIApplication uiApp, String text)
        {
            //Prepare a DataTable just for this operation
            DataTable dt = new DataTable();
            DataColumn paramIdColumn = dt.Columns.Add("ID", typeof(Int32));
            DataColumn paramNameColumn = dt.Columns.Add("Name", typeof(String));
            DataColumn paramElemColumn = dt.Columns.Add("Element", typeof(Object));

            //Create some lists for collecting data
            List<string> fieldNamesCollection = new List<string>();
            List<Parameter> elementParameters = new List<Parameter>();
            List<DataRow> duplicateRows = new List<DataRow>();
            List<ElementId> idsToUpdate = new List<ElementId>();
            List<string> failList = new List<string>();


            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Give a dialog box to verify the user has synchronized model changes, and only proceed if they click Yes
            DialogResult result = MessageBox.Show("Have you synchronized your model changes?", "Synchronization Prompt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Double check the active view is a schedule
                if (doc.ActiveView.ViewType == ViewType.Schedule)
                {
                    ViewSchedule viewSchedule = doc.ActiveView as ViewSchedule;
                    //Collect all of the elements displayed in the schedule
                    var scheduleCollector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
                    //Get the number of fields in the schedule
                    ScheduleDefinition scheduleDefinition = viewSchedule.Definition;
                    int scheduleFieldCount = scheduleDefinition.GetFieldCount();
                    for (int i = 0; i < scheduleFieldCount; i++)
                    {
                        //Get the fields and replace "Material: " in any name because those come from Material elemements that just have parameters with normal names
                        ScheduleField scheduleField = scheduleDefinition.GetField(i);
                        fieldNamesCollection.Add(scheduleField.GetName().Replace("Material: ", ""));
                    }

                    //For each element in the schedule...
                    foreach (Element elem in scheduleCollector)
                    {
                        //Get every instance parameter for the element and add it to the list of parameters to evaluate
                        foreach (Parameter instanceParam in elem.Parameters)
                        {                            
                            elementParameters.Add(instanceParam);

                            //Also, add a new row to the DataTable with the parameter ID, parameter Name, and the parameter Element
                            DataRow row = dt.NewRow();
                            row["ID"] = instanceParam.Id.IntegerValue;
                            row["Name"] = instanceParam.Definition.Name;
                            row["Element"] = instanceParam;
                            dt.Rows.Add(row);
                        }

                        //Then, get the type parameters of each element
                        ElementId typeId = elem.GetTypeId();
                        Element typeElement = doc.GetElement(typeId);
                        try
                        {
                            //For each type parameter, add it to the list of parameters to evaluate
                            foreach (Parameter typeParameter in typeElement.Parameters)
                            {
                                elementParameters.Add(typeParameter);

                                //Also, add a new row to the DataTable with the parameter ID, parameter Name, and parameter Element
                                DataRow row = dt.NewRow();
                                row["ID"] = typeParameter.Id.IntegerValue;
                                row["Name"] = typeParameter.Definition.Name;
                                row["Element"] = typeParameter;
                                dt.Rows.Add(row);
                            }
                        }
                        catch { continue; }
                    }

                    //Get the list of distinct parameters
                    List<Parameter> elementParameterList = elementParameters.Distinct().ToList();

                    //Make a new HashTable
                    Hashtable hashTable = new Hashtable();
                    //Cycle through the rows in the DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        if (hashTable.Contains(row["ID"]))
                        {
                            //If the hash table already contains the parameter ID of the row being evaluated, add the row to the list of duplicate rows
                            duplicateRows.Add(row);
                        }
                        else
                        {
                            //Otherwise, add the parameter ID to the hash table for further evaluations
                            hashTable.Add(row["ID"], null);
                        }
                    }

                    //For each row in the list of duplicate rows, delete them from the DataTable
                    foreach (DataRow item in duplicateRows)
                    {
                        dt.Rows.Remove(item);
                    }


                    //With a DataTable of unique parameters, start a transaction
                    Transaction t1 = new Transaction(doc, "CapitalizeScheduleValues");
                    t1.Start();
                    //For each row in the DataTable...
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            //If the list of field names contains the parameter name in the row...
                            if (fieldNamesCollection.Contains(row["Name"].ToString()))
                            {
                                Parameter rowParam = row["Element"] as Parameter;
                                //Get the parameter of the row and verify its data type is a string, and it is not read only
                                if (rowParam.StorageType == StorageType.String && !rowParam.IsReadOnly)
                                {
                                    //Add to the list of parameter IDs to update the ID of the parameter in the row
                                    idsToUpdate.Add(new ElementId(Convert.ToInt32(row["ID"])));
                                }
                            }
                        }
                        catch { continue; }
                    }

                    //For each Element in the schedule...
                    foreach (Element elem in scheduleCollector)
                    {
                        try
                        {
                            //For each parameter in the list of parameters
                            foreach (Parameter param in elementParameterList)
                            {
                                //If the list of parameter IDs to update contains the parameter in the list, and the parameter value is not null...
                                if (idsToUpdate.Contains(param.Id) && param.AsString() != null)
                                {
                                    //If the element happens to be a view with brackets it will be skipped because a name value cannot be set with brackets
                                    if (!param.AsString().Contains("{") && !param.AsString().Contains("}"))
                                    {
                                        try
                                        {
                                            //Try setting the parameter's value to an all caps value
                                            param.Set(param.AsString().ToUpper());
                                        }
                                        catch
                                        {
                                            //Otherwise add the parameter's name to a list for failed capitalizations
                                            failList.Add(param.Definition.Name);
                                            continue;
                                        }
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
                    //If the active view is not a schedule view, let the user know
                    MessageBox.Show(String.Format("The currently active view is of type: {0}. " +
                 "Please make the desired schedule the active view by clicking into the schedule view and rerun the script",
                 doc.ActiveView.ViewType.ToString()));
                }
            }
            else if (result == DialogResult.No)
            {
                //If the user selected No when asked if they synchronized, remind them to synchronize and try again
                MessageBox.Show("Please synchronize and/or save the model, then run again");
            }
            else
            {
                ;
            }

            //If there were any failures, output the list of parameter names that failed to a string in a MessageBox
            if (failList.Count > 1)
            {
                string failMessage = StringOperations.BuildStringFromList(failList).ToString();
                MessageBox.Show(String.Format("Could not convert the following parameters: {0}", failMessage));
            }
        }
    }
}
