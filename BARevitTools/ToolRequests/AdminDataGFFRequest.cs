using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //Get Family Files tool request
    class AdminDataGFFRequest
    {
        public AdminDataGFFRequest(UIApplication uiApp, String text)
        {
            //Items pertaining to the open UI
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;            
            List<string> itemsToCollect = uiForm.adminDataGFFItemsToCollect;

            //UI settings related to the proggress bar
            int filesToProcess = uiForm.adminDataGFFFiles.Count;
            uiForm.adminDataGFFDataProgressBar.Value = 0;
            uiForm.adminDataGFFDataProgressBar.Minimum = 0;
            uiForm.adminDataGFFDataProgressBar.Maximum = filesToProcess;
            uiForm.adminDataGFFDataProgressBar.Step = 1;
            uiForm.adminDataGFFDataProgressBar.Visible = true;

            //New objects
            DataTable dt = new DataTable();
            int selectionGroup = -2;
            
            //Getting the items from the list obtained from checked listbox items to determine what datatable columns are needed
            //The items below are able to be obtained without API calls. Statementselect remains -1 to indicate no API request will be needed, saving time.
            if (itemsToCollect.Contains("Family Name"))
            {
                DataColumn familyNameColumn = dt.Columns.Add("FamilyName", typeof(String));
                selectionGroup = -1;
            }

            if (itemsToCollect.Contains("Family Size"))
            {
                DataColumn familySizeColumn = dt.Columns.Add("FamilySize", typeof(Double));
                selectionGroup = -1;
            }

            if (itemsToCollect.Contains("Date Last Modified"))
            {
                DataColumn dateLastModifiedColumn = dt.Columns.Add("DateLastModified", typeof(String));
                selectionGroup = -1;
            }

            //Here is where items must be obtained via API calls. Statementselect changes from -1 to 0 to later indicate that API usage will be needed.
            if (itemsToCollect.Contains("Revit Version"))
            {
                DataColumn revitVersionColumn = dt.Columns.Add("RevitVersion", typeof(String));
                selectionGroup = 0;
            }

            if (itemsToCollect.Contains("Family Category"))
            {
                DataColumn familyCategoryColumn = dt.Columns.Add("FamilyCategory", typeof(String));
                selectionGroup = 0;
            }

            //From here, the IF statments indicate the files will need to be opened and API calls will be used, resulting in a slow data collection. Statementselect becomes 1
            if (itemsToCollect.Contains("Family Types"))
            {
                DataColumn familyTypeColumn = dt.Columns.Add("FamilyType", typeof(String));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Name"))
            {
                DataColumn parameterNameColumn = dt.Columns.Add("ParameterName", typeof(String));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Group"))
            {
                DataColumn parameterGroupColumn = dt.Columns.Add("ParameterGroup", typeof(String));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Type"))
            {
                DataColumn parameterTypeColumn = dt.Columns.Add("ParameterType", typeof(String));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Value"))
            {
                //If the parameter value is to be collected, it could be either an integer, double, or string, so create all three columns anyways
                DataColumn parameterValueIntegerColumn = dt.Columns.Add("ParameterValueInteger", typeof(Int32));
                DataColumn parameterValueDoubleColumn = dt.Columns.Add("ParameterValueDouble", typeof(Double));
                DataColumn parameterValueStringColumn = dt.Columns.Add("ParameterValueString", typeof(String));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Is Instance"))
            {
                DataColumn parameterIsInstanceColumn = dt.Columns.Add("ParameterIsInstance", typeof(Boolean));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter Is Shared"))
            {
                DataColumn parameterIsSharedColumn = dt.Columns.Add("ParameterIsShared", typeof(Boolean));
                selectionGroup = 1;
            }

            if (itemsToCollect.Contains("Parameter GUID"))
            {
                DataColumn parameterGUIDColumn = dt.Columns.Add("ParameterGUID", typeof(String));
                selectionGroup = 1;
            }

            //Cycle through the file paths obtained from the open UI
            foreach (string filePath in uiForm.adminDataGFFFiles)
            {
                //Increment the progress bar of the open UI
                uiForm.adminDataGFFDataProgressBar.PerformStep();
                // If selectionGroup is -1, no use of the API will be used
                if (selectionGroup == -1)
                {
                    DataRow row = dt.NewRow();
                    if (dt.Columns.Contains("FamilyName"))
                    { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }

                    if (dt.Columns.Contains("FamilySize"))
                    { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }

                    if (dt.Columns.Contains("DateLastModified"))
                    { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }

                    dt.Rows.Add(row);
                }

                //If selectionGroup is 0, then the API will be used, resulting in slower processing
                else if (selectionGroup == 0)
                {
                    //Get the Revit version year of the file
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    //Check to see if the GetRevitNumber did not return 0 (could not be determined), and that the saved in version is not newer that the one running.
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) >= rvtNumber)
                    {
                        DataRow row = dt.NewRow();

                        if (dt.Columns.Contains("FamilyName"))
                        { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }

                        if (dt.Columns.Contains("FamilySize"))
                        { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }

                        if (dt.Columns.Contains("DateLastModified"))
                        { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }

                        if (dt.Columns.Contains("RevitVersion"))
                        { row["RevitVersion"] = RVTOperations.GetRevitVersion(filePath); }

                        RVTDocument doc = RVTOperations.OpenRevitFile(uiApp, filePath);
                        if (dt.Columns.Contains("FamilyCategory") && doc.IsFamilyDocument)
                        { row["FamilyCategory"] = RVTOperations.GetRevitFamilyCategory(doc); }

                        doc.Close(false);
                        dt.Rows.Add(row);
                    }
                }

                //If selectionGroup is 1, then the API will be used, and the file must be opened to obtain the information
                else if (selectionGroup == 1)
                {
                    //Verifying Revit version year
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) >= rvtNumber)
                    {
                        //Open the Revit file
                        RVTDocument doc = RVTOperations.OpenRevitFile(uiApp, filePath);
                        //Ensure it is a family document
                        if (doc.IsFamilyDocument)
                        {
                            //Get the family manager of the family file
                            FamilyManager famMan = doc.FamilyManager;
                            //Get the set of family types from the family file
                            FamilyTypeSet familyTypes = famMan.Types;

                            Transaction t1 = new Transaction(doc, "CycleFamilyTypes");
                            t1.Start();

                            //For each family type...
                            foreach (FamilyType famType in familyTypes)
                            {
                                //Create a subtransaction to change the current family type in the family manager
                                SubTransaction s1 = new SubTransaction(doc);
                                s1.Start();
                                famMan.CurrentType = famType;
                                s1.Commit();

                                //Get each parameter from the current family type, and create a row for each parameter
                                foreach (FamilyParameter param in famMan.GetParameters())
                                {
                                    DataRow row = dt.NewRow();
                                    if (dt.Columns.Contains("FamilyName"))
                                    {
                                        try { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }
                                        catch { row["FamilyName"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilySize"))
                                    {
                                        try { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }
                                        catch { row["FamilySize"] = 0; }
                                    }
                                    if (dt.Columns.Contains("DateLastModified"))
                                    {
                                        try { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }
                                        catch { row["DateLastModified"] = ""; }
                                    }
                                    if (dt.Columns.Contains("RevitVersion"))
                                    {
                                        try { row["RevitVersion"] = RVTOperations.GetRevitVersion(filePath); }
                                        catch { row["RevitVersion"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilyCategory"))
                                    {
                                        try { row["FamilyCategory"] = RVTOperations.GetRevitFamilyCategory(doc); }
                                        catch { row["FamilyCategory"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilyType"))
                                    {
                                        try { row["FamilyType"] = famType.Name.ToString(); }
                                        catch { row["FamilyType"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterName"))
                                    {
                                        try { row["ParameterName"] = param.Definition.Name; }
                                        catch { row["ParameterName"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterGroup"))
                                    {
                                        try { row["ParameterGroup"] = param.Definition.ParameterGroup.ToString(); }
                                        catch { row["ParameterGroup"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterType"))
                                    {
                                        try { row["ParameterType"] = param.Definition.ParameterType.ToString(); }
                                        catch { row["ParameterType"] = ""; }
                                    }

                                    //Here is where the attempts to get the parameter values begins. Get the StorageType of the parameter, then determine which column the data goes in
                                    if (dt.Columns.Contains("ParameterValueInteger") && param.StorageType == StorageType.Integer)
                                    {
                                        try { row["ParameterValueInteger"] = famType.AsInteger(param); }
                                        catch { row["ParameterValueInteger"] = 0; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueDouble") && param.StorageType == StorageType.Double)
                                    {
                                        try { row["ParameterValueDouble"] = famType.AsDouble(param); }
                                        catch { row["ParameterValueDouble"] = 0; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueString") && param.StorageType == StorageType.ElementId)
                                    {
                                        //Instead of getting the ElementID, which is limited in value to someone reading the data, get the element name instead
                                        try { row["ParameterValueString"] = doc.GetElement(famType.AsElementId(param)).Name; }
                                        catch { row["ParameterValueString"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueString") && param.StorageType == StorageType.String)
                                    {
                                        //First, try getting the parameter string as a string. If that fails, try getting it as a ValueString
                                        try
                                        {
                                            string paramValue = famType.AsString(param);
                                            row["ParameterValueString"] = paramValue;
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                string paramValue = famType.AsValueString(param).ToString();
                                                row["ParameterValueString"] = paramValue;
                                            }
                                            catch
                                            {
                                                row["ParameterValueString"] = "";
                                            }
                                        }
                                    }

                                    if (dt.Columns.Contains("ParameterIsInstance"))
                                    {
                                        try { row["ParameterIsInstance"] = param.IsInstance; }
                                        catch { row["ParameterIsInstance"] = null; }
                                    }

                                    if (dt.Columns.Contains("ParameterIsShared"))
                                    {
                                        try { row["ParameterIsShared"] = param.IsShared; }
                                        catch { row["ParameterIsShared"] = null; }
                                    }

                                    if (dt.Columns.Contains("ParameterGUID"))
                                    {
                                        try { row["ParameterGUID"] = param.GUID.ToString(); }
                                        catch { row["ParameterGUID"] = ""; }
                                    }
                                    //Add the datatable row to the datatable
                                    dt.Rows.Add(row);
                                }
                            }
                            //Commit the primary transaction
                            t1.Commit();
                        }
                        //Close the document, do not save
                        doc.Close(false);
                    }
                }
                else
                {
                    //selectionGroup is still -2, and thus nothing was selected. Do nothing.
                    continue;
                }
            }

            //Set the datatable of the open UI to the one with the obtained data
            uiForm.adminDataGFFDataTable = dt;
            //Indicate the collection is done with the label
            uiForm.adminDataGFFCollectDataWaitLabel.Text = "Done!";
            //Hide the progress bar when done, and clear out the list of data items to collect
            uiForm.adminDataGFFDataProgressBar.Visible = false;
            uiForm.adminDataGFFItemsToCollect.Clear();
        }
    }
}
