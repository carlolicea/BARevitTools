using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using Excel = Microsoft.Office.Interop.Excel;

namespace BARevitTools.Tools
{
    public partial class AllCatCFFEForm : System.Windows.Forms.Form
    {
        private UIApplication uiApp;
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;
        public MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;

        public AllCatCFFEForm(UIApplication exUiApp, ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;
            uiApp = exUiApp;
        }

        #region multiCatCFFE
        public string multiCatSelectedFamilyFile = "";
        public string multiCatCFFEExcelFileToUse = "";
        public string multiCatCFFEFamilyFileToUse = "";
        public string multiCatCFFEFamilySaveLocation = "";

        private void AllCatCFFEDirectorySelectButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            string saveDirectory = GeneralOperations.GetDirectory();
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEDirectoryTextBox.Text = saveDirectory;
        }
        private void AllCatCFFESelectFamilyButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            bool readFamilyFile = false;
            string fileName = RVTOperations.GetFamilyFile();
            if (fileName != "")
            {
                string rvtVersion = RVTOperations.GetRevitVersion(fileName);
                if (rvtVersion != "")
                {
                    string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);
                    if (Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
                    { BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = Path.GetFileNameWithoutExtension(fileName); readFamilyFile = true; }
                }
                else
                { BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = "RVT Version Error"; }
            }
            else
            { BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = "No Selection Error"; }

            if (readFamilyFile == true)
            {
                multiCatSelectedFamilyFile = fileName;
                m_ExEvent.Raise();
                uiForm.MakeRequest(RequestId.multiCatCFFE1);
            }

        }
        private void AllCatCFFEExcelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEExcelDGV;
            if (dgv.Rows.Count > 0)
            {
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void AllCatCFFEExcelRunButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEExcelDGV;

            int trueCount = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    trueCount++;
                }
            }

            if (uiForm.multiCatCFFEDirectoryTextBox.Text == "")
            {
                MessageBox.Show("No save directory was selected");
            }
            else if (uiForm.multiCatCFFESelectFamilyTextBox.Text == "")
            {
                MessageBox.Show("No family was selected");
            }
            else if (dgv.Rows.Count == 0 || trueCount == 0)
            {
                MessageBox.Show("No family parameters were selected");
            }
            else
            {
                string savePath = uiForm.multiCatCFFEDirectoryTextBox.Text;
                string familyName = uiForm.multiCatCFFESelectFamilyTextBox.Text;

                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook newWorkbook = excel.Workbooks.Add("");
                Excel.Worksheet newWorksheet = newWorkbook.ActiveSheet;
                newWorksheet.Cells.Locked = true;

                newWorksheet.Cells[3, 1] = "Family Type Name";
                newWorksheet.Cells[1, 1] = "READ ME: Refer to the family parameters to know what is expected for parameter values. " +
                    "The GREEN row is the parameter names. " +
                    "The BLUE row is the parameter types as seen in Revit. " +
                    "The ORANGE row is the types of data formats expected. " +
                    "NOTE: INTEGERS are whole Numbers, DOUBLES are decimal numbers, STRINGS are text. " +
                    "For all parameters that are LENGTHS, use DECIMAL INCHES. For YES/NO Parameters, 0 is False and 1 is True";
                Excel.Range mergeRange = excel.Range[newWorksheet.Cells[1, 1], newWorksheet.Cells[2, 1]];
                mergeRange.Merge(Missing.Value);
                newWorksheet.Range["A1,A2"].Cells.Interior.ColorIndex = 3; //Red//
                newWorksheet.Range["A1,A2"].Cells.WrapText = true;

                int j = 2; //Parameter Names starting column//
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        newWorksheet.Cells[1, j] = row.Cells[3].Value.ToString();//Parameter Type
                        newWorksheet.Cells[2, j] = row.Cells[4].Value.ToString();//Parameter Storage Type
                        newWorksheet.Cells[3, j] = row.Cells[1].Value.ToString();//Parameter Name
                        j++;
                    }
                }
                excel.Cells.Locked = false;
                newWorksheet.Cells[3, 1].Locked = true;
                Excel.Range familyTypeHeaderCells = newWorksheet.Cells[3, 1];
                Excel.Range paramNamesStartCells = newWorksheet.Cells[3, 2];
                Excel.Range paramNamesEndCells = newWorksheet.Cells[3, j - 1];
                Excel.Range paramTypesStartCells = newWorksheet.Cells[1, 2];
                Excel.Range paramTypesEndCells = newWorksheet.Cells[1, j - 1];
                Excel.Range paramStorageTypesStartCells = newWorksheet.Cells[2, 2];
                Excel.Range paramStorageTypesEndCells = newWorksheet.Cells[2, j - 1];
                Excel.Range paramNamesRange = excel.Range[paramNamesStartCells, paramNamesEndCells];
                familyTypeHeaderCells.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                paramNamesRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                paramNamesRange.Locked = true;
                Excel.Range paramTypesRange = excel.Range[paramTypesStartCells, paramTypesEndCells];
                paramTypesRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                paramTypesRange.Locked = true;
                Excel.Range paramStorageRange = excel.Range[paramStorageTypesStartCells, paramStorageTypesEndCells];
                paramStorageRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold);
                paramStorageRange.Locked = true;


                string password = BARevitTools.Properties.Settings.Default.ExcelWorksheetPwd;
                bool drawingObjects = false;
                bool contents = true;
                bool scenarios = false;
                bool userInterfaceOnly = false;
                bool allowFormattingCells = false;
                bool allowFormattingColumns = true;
                bool allowFormattingRows = true;
                bool allowInsertingColumns = false;
                bool allowInsertingRows = true;
                bool allowInsertingHyperlinks = false;
                bool allowDeletingColumns = false;
                bool allowDeletingRows = true;
                bool allowSorting = false;
                bool allowFiltering = true;
                bool allowUsingPivotTables = false;
                newWorksheet.Protect(password, drawingObjects, contents, scenarios, userInterfaceOnly, allowFormattingCells,
                    allowFormattingColumns, allowFormattingRows, allowInsertingColumns, allowInsertingRows, allowInsertingHyperlinks,
                    allowDeletingColumns, allowDeletingRows, allowSorting, allowFiltering, allowUsingPivotTables);
                try
                {
                    dynamic properties = newWorkbook.BuiltinDocumentProperties;
                    properties["Comments"].Value = multiCatSelectedFamilyFile;
                    newWorkbook.SaveAs(savePath + "\\" + familyName + "_Types Template.xlsx");
                    newWorkbook.Close();
                    excel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = true;
                }
                catch
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    MessageBox.Show("Error: A previously saved template with the same name might be open. " +
                    "Please close it in Excel and re-export the template. " +
                    "If that's not the case, something else went wrong in exporting the spreadsheet");
                }
            }
        }
        private void AllCatCFFEExcelSelectButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEFamiliesDGV;

            int fnrs = 4; // family name row start index
            int pnrs = 3; // parameter name row start index
            int pncs = 2; // parameter name column start index
            int ptrs = 2; // parameter type row start index
            int ptcs = 2; // paramter type column start index

            string file = GeneralOperations.GetExcelFile();
            if (file != "")
            {
                BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelFileToUse = file;
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;
                try
                {
                    workbook = excel.Workbooks.Open(file);
                    worksheet = workbook.ActiveSheet;
                }
                catch
                { MessageBox.Show("Could not open the Excel file. Please verify it is not currently open."); }

                if (worksheet != null)
                {
                    DataTable dt = new DataTable();
                    DataColumn familyTypeNameColumn = dt.Columns.Add("FamilyTypeName", typeof(String));
                    worksheet.Unprotect("T3kZ!lla");
                    Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range range = worksheet.get_Range("A1", last);

                    int lastUsedRow = last.Row;
                    int lastUsedColumn = last.Column;

                    for (int i = pncs; i < lastUsedColumn; i++)
                    {
                        if (!dt.Columns.Contains(worksheet.Cells[pnrs, i].Value2.ToString()) && worksheet.Cells[pnrs, i].Value2.ToString() != "")
                        {
                            DataColumn newcolumn = dt.Columns.Add(worksheet.Cells[pnrs, i].Value2.ToString());
                        }
                        else
                        { continue; }
                    }

                    DataRow parameterTypeRow = dt.NewRow();
                    int columnCount = dt.Columns.Count;
                    for (int i = 1; i < columnCount; i++)
                    {
                        parameterTypeRow[dt.Columns[i].ColumnName] = worksheet.Cells[ptrs, ptcs].Value2.ToString();
                        ptcs++;
                    }
                    dt.Rows.Add(parameterTypeRow);

                    for (int j = fnrs; j <= lastUsedRow; j++)
                    {
                        DataRow valueRow = dt.NewRow();
                        for (int k = 1; k <= columnCount; k++)
                        {
                            try
                            {
                                valueRow[dt.Columns[k - 1]] = worksheet.Cells[j, k].Value2.ToString();
                            }
                            catch
                            {
                                valueRow[dt.Columns[k - 1]] = "";
                                continue;
                            }

                        }
                        dt.Rows.Add(valueRow);
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dgv.DataSource = bs;

                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    dgv.Rows[0].Frozen = true;
                    dgv.Rows[0].ReadOnly = true;
                    dgv.AllowUserToOrderColumns = false;
                    dgv.Update();
                    dgv.Refresh();
                }
                dynamic properties = workbook.BuiltinDocumentProperties;
                uiForm.multiCatCFFEFamilyFileToUse = properties["Comments"].Value;
                workbook.Close();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
        }
        private void AllCatCFFEFamiliesSaveDirectoryButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEFamilySaveLocation = GeneralOperations.GetDirectory();
            if (multiCatCFFEFamilySaveLocation != "")
            {
                BARevitTools.Application.thisApp.newMainUi.allCATCFFEFamiliesSaveDirectoryTextBox.Text = multiCatCFFEFamilySaveLocation;
            }
        }
        private void AllCatCFFEFamiliesRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            uiForm.MakeRequest(RequestId.multiCatCFFE2);
        }
        #endregion multiCatCFFE
    }
}
