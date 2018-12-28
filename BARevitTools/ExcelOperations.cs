using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace BARevitTools
{
    class ExcelOperations
    {
        public static DataTable ExcelTableToDataTable(string filePath, bool hasHeader)
        {
            DataTable dt = new DataTable();

            Excel.Application excel = new Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;

            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            try
            {
                workbook = excel.Workbooks.Open(filePath);
                worksheet = workbook.ActiveSheet;
            }
            catch
            { MessageBox.Show("Could not open the Excel file. Please verify it is not currently open."); }
            
            Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Excel.Range range = worksheet.get_Range("A1", last);

            int lastUsedRow = last.Row;
            int lastUsedColumn = last.Column;

            if (hasHeader)
            {
                for (int i = 1; i <= lastUsedColumn; i++)
                {
                    if (!dt.Columns.Contains(worksheet.Cells[1, i].Value2.ToString()) && worksheet.Cells[1, i].Value2.ToString() != "")
                    {
                        DataColumn newcolumn = dt.Columns.Add(worksheet.Cells[1, i].Value2.ToString());
                    }
                    else
                    { continue; }
                }
            } 
            else
            {
                for (int i = 1; i <= lastUsedColumn; i++)
                {
                    DataColumn newcolumn = dt.Columns.Add("Column"+Convert.ToString(i));
                }
            }
                        
            int columnCount = dt.Columns.Count;

            for (int j = 2; j <= lastUsedRow; j++)
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

            workbook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            return dt;
        }
        public static void DataTableToExcel(string filePath, DataTable dt)
        {            
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;
                try
                {
                    workbook = excel.Workbooks.Open(filePath);
                    worksheet = workbook.ActiveSheet;
                }
                catch
                { MessageBox.Show("Could not open the Excel file. Please verify it is not currently open."); }

                for (int c = 1; c < dt.Columns.Count; c++)
                {
                    try
                    {
                        worksheet.Cells[1, c] = dt.Columns[c - 1].ColumnName;
                    }
                    catch
                    {
                        continue;
                    }                    
                }

                for (int c = 1; c <= dt.Columns.Count; c++)
                {
                    try
                    {
                        for (int r = 2; r <= dt.Rows.Count + 1; r++)
                        {
                            worksheet.Cells[r, c] = dt.Rows[r - 2][c - 1].ToString();
                        }
                    }
                    catch
                    {
                        continue;
                    }                    
                }

                workbook.Save();
                workbook.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
        public static void DataGridViewToExcel(string filePath, DataGridView dgv)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;
                try
                {
                    workbook = excel.Workbooks.Open(filePath);
                    worksheet = workbook.ActiveSheet;
                }
                catch
                { MessageBox.Show("Could not open the Excel file. Please verify it is not currently open."); }

                for (int c = 1; c <= dgv.Columns.Count; c++)
                {
                    try
                    {
                        worksheet.Cells[1, c] = dgv.Columns[c - 1].HeaderText;
                    }
                    catch
                    {
                        continue;
                    }
                }

                for (int c = 1; c <= dgv.Columns.Count; c++)
                {
                    try
                    {
                        for (int r = 2; r <= dgv.Rows.Count + 1; r++)
                        {
                            worksheet.Cells[r, c] = dgv.Rows[r - 2].Cells[c - 1].Value.ToString();
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                workbook.Save();
                workbook.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
