using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Autodesk.Revit.DB;
using RVTDocument = Autodesk.Revit.DB.Document;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace BARevitTools
{
    class GeneralOperations
    {
        public static MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
        public static void BindDataSourceToDataGridView(DataGridView dgv, DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dgv.DataSource = bs;
        }
        public static void CleanRfaBackups(string file)
        {
            if (file != "")
            {
                bool isDirectory = false;
                FileAttributes fileAttributes = File.GetAttributes(file);
                if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isDirectory = true;
                }

                if (isDirectory)
                {
                    foreach (string filePath in GeneralOperations.GetAllRvtFamilies(file,true))
                    {
                        Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                        if (match1.Success)
                        {
                            try
                            {
                                File.Delete(filePath);
                            }
                            catch { MessageBox.Show(String.Format("Could not delete {0}", filePath)); }
                        }
                    }
                }
                else
                {
                    Match match1 = Regex.Match(file, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                    if (match1.Success)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch { MessageBox.Show(String.Format("Could not delete {0}", file)); }
                    }
                }                
            }
        }
        public static void CleanRfaBackups(List<string> files)
        {
            if (files.Count != 0)
            {
                foreach (string filePath in files)
                {
                    Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                    if (match1.Success)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch { continue; }
                    }
                }
            }
        }
        //
        //This method will clean up strings to be able to be used as file paths by removing everything that is not acceptable in a path string
        public static string CleanFileName(string originalName)
        {
            try
            {
                //Replace using the regular expression looking for anything that is not (^) a part of the set ([]). The set includes:
                // words (\w)
                // escape characters (\.)
                // @ signs (@)
                // dashes (-)
                // whitespace (\s)
                return Regex.Replace(originalName, @"[^\s\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
        public static void DeleteFiles(List<string> filePaths)
        {
            foreach (string path in filePaths)
            {
                File.Delete(path);
            }
        }
        public static List<string> GetAllRvtFamilies(string directoryPath, bool includeBackups)
        {
            List<string> filePaths = new List<string>();
            if (includeBackups)
            {
                if (directoryPath != "")
                {
                    foreach (string filePath in Directory.GetFiles(directoryPath, "*.rfa", SearchOption.AllDirectories))
                    {
                        if (!filePath.Contains("Archive") && !filePath.Contains("Parts"))
                        {
                            FileInfo fileInfo = new FileInfo(filePath);
                            filePaths.Add(filePath);
                        }
                    }
                }
                return filePaths;
            }
            else
            {
                if (directoryPath != "")
                {
                    foreach (string filePath in Directory.GetFiles(directoryPath, "*.rfa", SearchOption.AllDirectories))
                    {
                        Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                        if (!filePath.Contains("Archive") && !filePath.Contains("Parts") && !match1.Success)
                        {
                            FileInfo fileInfo = new FileInfo(filePath);
                            filePaths.Add(filePath);
                        }
                    }
                }
                return filePaths;
            }
            
            
        }
        public static List<string> GetAllRvtFamilies(string directoryPath, DateTime date, bool useDate)
        {
            List<string> filePaths = new List<string>();
            if (directoryPath != "")
            {
                foreach (string filePath in Directory.GetFiles(directoryPath, "*.rfa", SearchOption.AllDirectories))
                {
                    Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                    if (!filePath.Contains("Archive") && !filePath.Contains("Parts") && !match1.Success)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        if (useDate == true && fileInfo.LastWriteTime >= date)
                        { filePaths.Add(filePath); }
                        else if (useDate == false)
                        { filePaths.Add(filePath); }
                        else
                        { continue; }
                    }
                }
            }
            return filePaths;
        }
        public static List<string> GetAllRvtBackupFamilies(string directoryPath, bool searchAllDirectories)
        {
            List<string> filePaths = new List<string>();
            if (directoryPath != "")
            {
                
                if (searchAllDirectories)
                {
                    foreach (string filePath in Directory.GetFiles(directoryPath, "*.rfa", SearchOption.AllDirectories))
                    {
                        Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                        if (match1.Success)
                        {
                            FileInfo fileInfo = new FileInfo(filePath);
                            filePaths.Add(filePath);
                        }
                    }
                }
                else
                {
                    foreach (string filePath in Directory.GetFiles(directoryPath, "*.rfa", SearchOption.TopDirectoryOnly))
                    {
                        Match match1 = Regex.Match(filePath, @".00\d\d.rfa", RegexOptions.IgnoreCase);
                        if (match1.Success)
                        {
                            FileInfo fileInfo = new FileInfo(filePath);
                            filePaths.Add(filePath);
                        }
                    }
                }                
            }
            return filePaths;
        }
        //
        //Gets all Revit RVT files from a directory, passing a last modified date newer than the one supplied. This also takes the log file to record failures
        public static List<string> GetAllRvtProjectFiles(string directoryPath, DateTime date)
        {
            List<string> files = new List<string>();
            //Get an array of directories given the path
            string[] directories = Directory.GetDirectories(directoryPath);
            //Cyle through the directories
            foreach (string directory in directories)
            {
                //Wrapping this in a TRY/CATCH because some directories may not be accessible
                try
                {
                    //Get the files from the directory and add them to a list
                    List<string> filePaths = Directory.EnumerateFiles(directory, "*.rvt", SearchOption.AllDirectories).ToList();
                    //Cycle through the file paths
                    foreach (string file in filePaths)
                    {
                        //Wrapping this in a TRY/CATCH because some files may not be accessible
                        try
                        {
                            //If the file path contains the main folder for Project files, continue
                            if (file.Contains(Properties.Settings.Default.BAProjectCentralFolder))
                            {
                                //Change the attributes to normal to disable any Read Only attribute, then reset the Archive attribute.
                                File.SetAttributes(file, FileAttributes.Normal);
                                File.SetAttributes(file, FileAttributes.Archive);
                                //Get the FileInfo from the file
                                FileInfo fileInfo = new FileInfo(file);
                                //If the LastWriteTime is newer than the date supplied to the method, add the file path to the list of files
                                if (fileInfo.LastWriteTime >= date)
                                {
                                    files.Add(file);
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch { continue; }
            }
            return files;
        }
        public static string GetDirectory()
        {
            string directory = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.ToString() != "")
            {
                directory = folderBrowserDialog.SelectedPath;
            }
            return directory;
        }
        public static string GetExcelFile()
        {
            string file = "";
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Excel Spreadsheet (*.xlsx)|*xlsx"
            };
            fileDialog.ShowDialog();
            if (fileDialog.FileName.ToString() != "")
            {
                file = fileDialog.FileName;
            }
            return file;
        }
        public static string GetFile()
        {
            string file = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            if (fileDialog.FileName.ToString() != "")
            {
                file = fileDialog.FileName;
            }
            return file;
        }
        public static string GetFileName(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
        public static string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }
        public static double GetFileSize(string filePath)
        {
            FileInfo familyFileInfo = new FileInfo(filePath);
            double fileSize = ((double)(familyFileInfo.Length) / 1000000.00);
            return fileSize;
        }
        public static string GetFileLastModifiedDate(string filePath)
        {
            return File.GetLastWriteTime(filePath).ToString();
        }
        public static bool IsCadDriveAccessible()
        {
            if (Directory.Exists(Properties.Settings.Default.RevitCadDrive))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ResetDataGridView(DataGridView dataGridView)
        {
            dataGridView.CancelEdit();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
        }
        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            try
            {
                using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }
            }
            catch { MessageBox.Show("Internal Error: Could not get the resource for the spreadsheet"); }
        }
    }

    public static class NumberOperations
    {
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, @"\d+", match => match.Value.PadLeft(4, '0'));
        }
    }

    public static class StringOperations
    {
        public static StringBuilder BuildCSVStringFromDataTable(DataTable dt)
        {
            StringBuilder output = new StringBuilder();
            foreach (DataColumn column in dt.Columns)
            {
                var item = column.ColumnName;
                output.AppendFormat(string.Concat("\"", item.ToString(), "\"", ","));
            }
            output.AppendLine();

            foreach (DataRow rows in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    var item = rows[col];
                    output.AppendFormat(string.Concat("\"", item.ToString(), "\"", ","));
                }
                output.AppendLine();
            }
            return output;
        }
        public static StringBuilder BuildStringFromDataTable(DataTable dt)
        {
            StringBuilder output = new StringBuilder();
            foreach (DataRow rows in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    var item = rows[col];
                    output.AppendFormat(string.Concat(item.ToString(), " "));
                }
                output.AppendLine();
            }
            return output;
        }
        public static StringBuilder BuildStringFromList(List<string> list)
        {
            StringBuilder output = new StringBuilder();
            foreach (string item in list)
            {
                output.AppendFormat(string.Concat(item, " "));
                output.AppendLine();
            }
            return output;
        }
    }

    public static class CsvOperations
    {
        public static void CreateCSVFromDataTable(DataTable dt, string exportName, string exportDirectory)
        {
            string exportPath = exportDirectory + @"\" + exportName + ".csv";
            if (File.Exists(exportPath))
            {
                File.Delete(exportPath);
            }
            StringBuilder sb = StringOperations.BuildCSVStringFromDataTable(dt);
            File.WriteAllText(exportPath, sb.ToString());
        }
    }

    public class CustomColors
    {
        public static System.Drawing.Color baTeal = System.Drawing.Color.FromArgb(150, 208, 202);
        public static System.Drawing.Color baDarkPink = System.Drawing.Color.FromArgb(233, 164, 195);
        public static System.Drawing.Color baLightPink = System.Drawing.Color.FromArgb(241, 219, 235);
        public static System.Drawing.Color baClayRed = System.Drawing.Color.FromArgb(224, 155, 144);
        public static System.Drawing.Color baBrownTan = System.Drawing.Color.FromArgb(198, 166, 140);
        public static System.Drawing.Color baYellow = System.Drawing.Color.FromArgb(247, 234, 136);
        public static System.Drawing.Color baPeach = System.Drawing.Color.FromArgb(245, 221, 195);
        public static System.Drawing.Color baCornflowerBlue = System.Drawing.Color.FromArgb(185, 218, 243);
        public static System.Drawing.Color baPowderBlue = System.Drawing.Color.FromArgb(217, 234, 236);
        public static System.Drawing.Color baDarkMoss = System.Drawing.Color.FromArgb(172, 185, 147);
        public static System.Drawing.Color baLightMoss = System.Drawing.Color.FromArgb(219, 234, 184);
        public static System.Drawing.Color baCustard = System.Drawing.Color.FromArgb(246, 248, 233);
        public static System.Drawing.Color baSlate = System.Drawing.Color.FromArgb(159, 172, 170);
        public static System.Drawing.Color baGray = System.Drawing.Color.FromArgb(220, 221, 222);
        public static System.Drawing.Color baLightGray = System.Drawing.Color.FromArgb(245, 246, 246);
        public static System.Drawing.Color baWhite = System.Drawing.Color.FromArgb(255, 255, 255);

        public static ColorDialog CustomColorDialog()
        {
            int[] customColors = new int[]
            {
                ColorToInt(baTeal),
                ColorToInt(baDarkPink),
                ColorToInt(baLightPink),
                ColorToInt(baClayRed),
                ColorToInt(baBrownTan),
                ColorToInt(baYellow),
                ColorToInt(baPeach),
                ColorToInt(baCornflowerBlue),
                ColorToInt(baPowderBlue),
                ColorToInt(baDarkMoss),
                ColorToInt(baLightMoss),
                ColorToInt(baCustard),
                ColorToInt(baSlate),
                ColorToInt(baGray),
                ColorToInt(baLightGray),
                ColorToInt(baWhite)
            };
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.CustomColors = customColors;
            return colorDialog;
        }

        private static int ColorToInt(System.Drawing.Color color)
        {
            byte[] result = new byte[4];
            result[0] = color.R;
            result[1] = color.G;
            result[2] = color.B;
            result[3] = 0;
            return BitConverter.ToInt32(result, 0);
        }
    }
}
