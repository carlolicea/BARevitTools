using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class SheetsOSSNewSetRequest
    {
        public SheetsOSSNewSetRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;

            List<string> dtColumnsCollection = new List<string>();
            foreach (DataColumn dtColumn in uiForm.sheetsOSSDataTable.Columns)
            {
                dtColumnsCollection.Add(dtColumn.ColumnName);
            }
            if (!dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text) && uiForm.sheetsOSSNewSetTextBox.Text != "<New Set Name>")
            {
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                PrintManager printManager = doc.PrintManager;
                printManager.PrintRange = PrintRange.Select;
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;

                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                try
                {
                    viewSheetSetting.SaveAs(uiForm.sheetsOSSNewSetTextBox.Text);
                    t0.Commit();

                    DataColumn newColumn = new DataColumn();
                    newColumn.ColumnName = uiForm.sheetsOSSNewSetTextBox.Text;
                    newColumn.DataType = typeof(Boolean);
                    uiForm.sheetsOSSDataTable.Columns.Add(newColumn);
                }
                catch { t0.RollBack(); }
                dgv.Update();
            }
            else if (dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text))
            { MessageBox.Show("Set with specified name already exists"); }
            else
            { MessageBox.Show("Cannot make a set with the specified name"); }

            dgv.Update();
            dgv.Refresh();
            GraphicsFormatting.HighlightCellsFromDataGridView(dgv, System.Drawing.Color.GreenYellow);
        }
    }
}
