using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;


namespace BARevitTools.Tools
{
    class AdminDataGFFRequest
    {
        public AdminDataGFFRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataTable dt = new DataTable();
            List<string> itemsToCollect = uiForm.adminDataGFFItemsToCollect;
            int statementSelect = -1;
            uiForm.adminDataGFFDataProgressBar.Value = 0;

            if (itemsToCollect.Contains("Family Name"))
            { DataColumn familyNameColumn = dt.Columns.Add("FamilyName", typeof(String)); }

            if (itemsToCollect.Contains("Family Size"))
            { DataColumn familySizeColumn = dt.Columns.Add("FamilySize", typeof(Double)); }

            if (itemsToCollect.Contains("Date Last Modified"))
            { DataColumn dateLastModifiedColumn = dt.Columns.Add("DateLastModified", typeof(String)); }

            if (itemsToCollect.Contains("Revit Version"))
            {
                DataColumn revitVersionColumn = dt.Columns.Add("RevitVersion", typeof(String));
                statementSelect = 0;
            }

            if (itemsToCollect.Contains("Family Category"))
            {
                DataColumn familyCategoryColumn = dt.Columns.Add("FamilyCategory", typeof(String));
                statementSelect = 0;
            }

            if (itemsToCollect.Contains("Family Types"))
            {
                DataColumn familyTypeColumn = dt.Columns.Add("FamilyType", typeof(String));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Name"))
            {
                DataColumn parameterNameColumn = dt.Columns.Add("ParameterName", typeof(String));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Group"))
            {
                DataColumn parameterGroupColumn = dt.Columns.Add("ParameterGroup", typeof(String));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Type"))
            {
                DataColumn parameterTypeColumn = dt.Columns.Add("ParameterType", typeof(String));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Value"))
            {
                DataColumn parameterValueIntegerColumn = dt.Columns.Add("ParameterValueInteger", typeof(Int32));
                DataColumn parameterValueDoubleColumn = dt.Columns.Add("ParameterValueDouble", typeof(Double));
                DataColumn parameterValueStringColumn = dt.Columns.Add("ParameterValueString", typeof(String));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Is Instance"))
            {
                DataColumn parameterIsInstanceColumn = dt.Columns.Add("ParameterIsInstance", typeof(Boolean));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter Is Shared"))
            {
                DataColumn parameterIsSharedColumn = dt.Columns.Add("ParameterIsShared", typeof(Boolean));
                statementSelect = 1;
            }

            if (itemsToCollect.Contains("Parameter GUID"))
            {
                DataColumn parameterGUIDColumn = dt.Columns.Add("ParameterGUID", typeof(String));
                statementSelect = 1;
            }

            int filesToProcess = uiForm.adminDataGFFFiles.Count;
            uiForm.adminDataGFFDataProgressBar.Minimum = 0;
            uiForm.adminDataGFFDataProgressBar.Maximum = filesToProcess;
            uiForm.adminDataGFFDataProgressBar.Step = 1;
            uiForm.adminDataGFFDataProgressBar.Visible = true;

            foreach (string filePath in uiForm.adminDataGFFFiles)
            {
                uiForm.adminDataGFFDataProgressBar.PerformStep();
                if (statementSelect == -1)
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

                else if (statementSelect == 0)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
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

                else if (statementSelect == 1)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) >= rvtNumber)
                    {
                        RVTDocument doc = RVTOperations.OpenRevitFile(uiApp, filePath);
                        if (doc.IsFamilyDocument)
                        {
                            FamilyManager famMan = doc.FamilyManager;
                            FamilyTypeSet familyTypes = famMan.Types;
                            Transaction t1 = new Transaction(doc, "CycleFamilyTypes");
                            t1.Start();
                            foreach (FamilyType famType in familyTypes)
                            {
                                SubTransaction s1 = new SubTransaction(doc);
                                s1.Start();
                                famMan.CurrentType = famType;
                                s1.Commit();
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
                                        try { row["ParameterValueString"] = doc.GetElement(famType.AsElementId(param)).Name; }
                                        catch { row["ParameterValueString"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueString") && param.StorageType == StorageType.String)
                                    {
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
                                    dt.Rows.Add(row);
                                }
                            }
                            t1.Commit();
                        }
                        doc.Close(false);
                    }
                }
                else if (statementSelect == 0 || statementSelect == 1)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) <= rvtNumber)
                    {
                        MessageBox.Show(String.Format("{0} was saved in a newer version of Revit", System.IO.Path.GetFileNameWithoutExtension(filePath)));
                    }
                }
                else
                {
                    continue;
                }
            }

            uiForm.adminDataGFFDataTable = dt;
            uiForm.adminDataGFFCollectDataWaitLabel.Text = "Done!";
            uiForm.adminDataGFFDataProgressBar.Visible = false;
            uiForm.adminDataGFFItemsToCollect.Clear();
        }
    }
}
