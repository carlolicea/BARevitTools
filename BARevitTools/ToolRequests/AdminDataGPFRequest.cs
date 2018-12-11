using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class AdminDataGPFRequest
    {
        public static DataTable consolidatedTable = null;
        public static StringBuilder consolidatedSB = null;
        public static string consolidatedLog = "";

        public AdminDataGPFRequest(UIApplication uiApp, String text)
        {
            consolidatedTable = new DataTable();
            consolidatedSB = new StringBuilder();

            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;

            Dictionary<string, string> pathsToSearch = new Dictionary<string, string>();
            foreach (int i in uiForm.adminDataGPFSelectDataDrivesListBox.CheckedIndices)
            {
                string drivePath = "";
                string officeLocation = "";
                string driveName = uiForm.adminDataGPFSelectDataDrivesListBox.Items[i].ToString();
                switch (driveName)
                {
                    case "Boulder Projects":
                        drivePath = Properties.Settings.Default.BABoulderProjects;
                        officeLocation = "Boulder";
                        break;
                    case "Dallas Projects":
                        drivePath = Properties.Settings.Default.BADallasProjects;
                        officeLocation = "Dallas";
                        break;
                    case "OC Projects":
                        drivePath = Properties.Settings.Default.BAOcProjects;
                        officeLocation = "Irvine";
                        break;
                    case "SAC Projects":
                        drivePath = Properties.Settings.Default.BASacProjects;
                        officeLocation = "Sacramento";
                        break;
                    case "SF Projects":
                        drivePath = Properties.Settings.Default.BASfProjects;
                        officeLocation = "San Francisco";
                        break;
                    default:
                        break;
                }
                pathsToSearch.Add(officeLocation, drivePath);
            }

            if (pathsToSearch.Count > 0)
            {
                CreateOutputLog LogFile = null;
                string officeDbTableName = BARevitTools.Application.thisApp.newMainUi.adminDataGPFExportDbSelectDbComboBox.Text;
                foreach (string officeLocation in pathsToSearch.Keys)
                {
                    DateTime startDate = uiForm.adminDataGPFSelectDataDatePicker.Value;
                    string year = DateTime.Today.Year.ToString();
                    string month = DateTime.Today.Month.ToString();
                    string day = DateTime.Today.Day.ToString();

                    string path = pathsToSearch[officeLocation];                    
                    LogFile = new CreateOutputLog(officeLocation, startDate, DateTime.Today, path); PerformOperations(startDate, path, officeLocation, LogFile);
                    PerformOperations(startDate, path, officeLocation, LogFile);
                    LogFile.SetOutputLogData(consolidatedSB, officeLocation, startDate, DateTime.Today, path, LogFile.m_fileReadErrors, LogFile.m_newDbEntries, LogFile.m_existingDbEntries, LogFile.m_dbTableName, year, month, day);
                }
                SqlConnection sqlConnection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
                DatabaseOperations.SqlWriteDataTable(officeDbTableName, sqlConnection, consolidatedTable, false);
                DatabaseOperations.SqlCloseConnection(sqlConnection);
                uiForm.adminDataGPFResultsTextBox.Text = consolidatedSB.ToString();
            }
            uiForm.adminDataGPFExportTable = consolidatedTable;
        }

        public static DataTable PerformOperations(DateTime startDate, string officeDrivePath, string officeLocation, CreateOutputLog LogFile)
        {
            List<string> filesToCheck = GeneralOperations.GetAllRvtProjectFiles(officeDrivePath, startDate, LogFile);
            DataTable dataTable = FillDataTable(officeLocation, officeDrivePath, filesToCheck, LogFile.m_fileReadErrors, consolidatedTable);
            return dataTable;
        }

        public static DataTable FillDataTable(string office, string drive, List<string> files, List<string> fileReadErrors, DataTable dt)
        {
            DataColumn projectOfficeColumn = dt.Columns.Add("ProjectOffice", typeof(String));
            DataColumn projectDriveColumn = dt.Columns.Add("ProjectDrive", typeof(String));
            DataColumn projectNumberColumn = dt.Columns.Add("ProjectNumber", typeof(String));
            DataColumn hostModelNameColumn = dt.Columns.Add("HostModelName", typeof(String));
            DataColumn hostRevitVersionColumn = dt.Columns.Add("HostRevitVersion", typeof(Int32));
            DataColumn hostFilePathColumn = dt.Columns.Add("HostFilePath", typeof(String));
            DataColumn hostFileSizeColumn = dt.Columns.Add("HostSizeMB", typeof(Decimal));
            DataColumn linkModelNameColumn = dt.Columns.Add("LinkModelName", typeof(String));
            DataColumn linkRevitVersionColumn = dt.Columns.Add("LinkRevitVersion", typeof(Int32));
            DataColumn linkFilePathColumn = dt.Columns.Add("LinkFilePath", typeof(String));
            DataColumn linkFileSizeColumn = dt.Columns.Add("LinkSizeMB", typeof(Decimal));
            DataColumn dateColumn = dt.Columns.Add("DateModified", typeof(DateTime));


            foreach (string file in files)
            {
                bool skip = false;

                string projectNumber = "";
                Match matchProjectNumber1 = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9].[0-9][0-9]", RegexOptions.IgnoreCase);
                Match matchProjectNumber2 = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9].\w\w", RegexOptions.IgnoreCase);
                Match matchProjectNumber3 = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase);

                if (matchProjectNumber1.Success)
                {
                    GroupCollection groups = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9].[0-9][0-9]", RegexOptions.IgnoreCase).Groups;
                    projectNumber = matchProjectNumber1.Value;
                }
                else if (matchProjectNumber2.Success)
                {
                    GroupCollection groups = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9].\w\w", RegexOptions.IgnoreCase).Groups;
                    projectNumber = matchProjectNumber2.Value;
                }
                else if (matchProjectNumber3.Success)
                {
                    GroupCollection groups = Regex.Match(file, @"[0-9][0-9][0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase).Groups;
                    projectNumber = matchProjectNumber3.Value;
                }
                else
                {
                    skip = true;
                }

                if (skip == false)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string hostModelName = Path.GetFileNameWithoutExtension(file);
                        int hostRevitVersion = RVTOperations.GetRevitNumber(file);
                        string hostFilePath = file;
                        decimal hostFileSize = fileInfo.Length / 1000000m;
                        string linkModelName = "";
                        int linkRevitVersion = 0;
                        string linkFilePath = "";
                        decimal linkFileSize = 0m;
                        DateTime date = fileInfo.LastWriteTime;

                        ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(file);
                        TransmissionData transmissionData = TransmissionData.ReadTransmissionData(modelPath);
                        if (transmissionData != null)
                        {
                            ICollection<ElementId> elementIds = transmissionData.GetAllExternalFileReferenceIds();
                            foreach (ElementId elementId in elementIds)
                            {
                                ExternalFileReference externalFileReference = transmissionData.GetLastSavedReferenceData(elementId);
                                if (externalFileReference.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink && externalFileReference.GetLinkedFileStatus() != LinkedFileStatus.NotFound)
                                {
                                    try
                                    {
                                        linkFilePath = ModelPathUtils.ConvertModelPathToUserVisiblePath(externalFileReference.GetAbsolutePath());
                                        linkModelName = Path.GetFileNameWithoutExtension(linkFilePath);
                                        linkRevitVersion = RVTOperations.GetRevitNumber(linkFilePath);
                                        FileInfo linkFileInfo = new FileInfo(linkFilePath);
                                        linkFileSize = linkFileInfo.Length / 1000000m;

                                        DataRow row = dt.NewRow();
                                        row["ProjectOffice"] = office;
                                        row["ProjectDrive"] = drive;
                                        row["ProjectNumber"] = projectNumber;
                                        row["HostModelName"] = hostModelName;
                                        row["HostRevitVersion"] = hostRevitVersion;
                                        row["HostFilePath"] = hostFilePath;
                                        row["HostSizeMB"] = hostFileSize;
                                        row["LinkModelName"] = linkModelName;
                                        row["LinkRevitVersion"] = linkRevitVersion;
                                        row["LinkFilePath"] = linkFilePath;
                                        row["LinkSizeMB"] = linkFileSize;
                                        row["DateModified"] = date;
                                        dt.Rows.Add(row);
                                    }
                                    catch (Exception e)
                                    {
                                        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Exception: {1}", file, e.Message));
                                        fileReadErrors.Add(file);
                                        fileReadErrors.Add("    Exception: " + e.Message);
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                DataRow row = dt.NewRow();
                                row["ProjectOffice"] = office;
                                row["ProjectDrive"] = drive;
                                row["ProjectNumber"] = projectNumber;
                                row["HostModelName"] = hostModelName;
                                row["HostRevitVersion"] = hostRevitVersion;
                                row["HostFilePath"] = hostFilePath;
                                row["HostSizeMB"] = hostFileSize;
                                row["LinkModelName"] = linkModelName;
                                row["LinkRevitVersion"] = linkRevitVersion;
                                row["LinkFilePath"] = linkFilePath;
                                row["LinkSizeMB"] = linkFileSize;
                                row["DateModified"] = date;
                                dt.Rows.Add(row);
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine(String.Format("{0} : Exception: {1}", file, e.Message));
                                fileReadErrors.Add(file);
                                fileReadErrors.Add("    Exception: " + e.Message);
                                continue;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Exception: {1}", file, e.Message));
                        fileReadErrors.Add(file);
                        fileReadErrors.Add("    Exception: " + e.Message);
                        continue;
                    }

                }
            }
            return dt;
        }

    }

    public class CreateOutputLog
    {
        public List<string> m_fileReadErrors = new List<string>();
        public List<string> m_newDbEntries = new List<string>();
        public List<string> m_existingDbEntries = new List<string>();
        public string m_dbTableName;
        public string m_officeLocation;
        public DateTime m_startDateRange;
        public DateTime m_endDateRange;
        public string m_officeDrive;

        public CreateOutputLog(string officeLocation, DateTime startDateRange, DateTime endDateRange, string officeDrive)
        {
            m_officeLocation = officeLocation;
            m_startDateRange = startDateRange;
            m_endDateRange = endDateRange;
            m_officeDrive = officeDrive;
        }

        public StringBuilder SetOutputLogData(StringBuilder sb, string officeLocation, DateTime startDateRange, DateTime endDateRange, string officeDrive, List<string> slogReadErrors, List<string> newDbEntries, List<string> existingDbEntries, string dbTableName, string year, string month, string day)
        {
            sb.Append(String.Format("Office: {0}", officeLocation));
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("Date Range: {0} - {1}", startDateRange.ToString(), endDateRange.ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("Drive Searched: {0}", officeDrive));
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("The Following Errors Occurred:");
            sb.Append(Environment.NewLine);
            foreach (string line in slogReadErrors)
            {
                sb.Append(line);
                sb.Append(Environment.NewLine);
            }
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("The Following Entries Were Added To {0}:", dbTableName));
            sb.Append(Environment.NewLine);
            foreach (string line in newDbEntries)
            {
                sb.Append(line);
            }
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("The Following Entries Already Existed And Were Skipped In {0}:", dbTableName));
            sb.Append(Environment.NewLine);
            foreach (string line in existingDbEntries)
            {
                sb.Append(line);
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();

            return sb;
        }
    }
}
