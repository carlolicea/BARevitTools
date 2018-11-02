using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
    public static class GraphicsFormatting
    {
        public static void HighlightCellsFromDataGridView(DataGridView dgv, System.Drawing.Color color)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (row.Cells[column.Index].Value.ToString() == "True")
                    {
                        row.Cells[column.Index].Style.BackColor = color;
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
    }        
}