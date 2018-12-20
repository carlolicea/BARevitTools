using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Organize Sheet Set class for making a new sheet set's DataGridView column 
    class SheetsOSSNewSetRequest
    {
        public SheetsOSSNewSetRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;

            //Get all of the existing sheets sets by the column headers
            List<string> dtColumnsCollection = new List<string>();
            foreach (DataColumn dtColumn in uiForm.sheetsOSSDataTable.Columns)
            {
                dtColumnsCollection.Add(dtColumn.ColumnName);
            }
            
            //IF the sheet set does not already exist, and the user has specified a new sheet set name, continue
            if (!dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text) && uiForm.sheetsOSSNewSetTextBox.Text != "<New Set Name>")
            {
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                //Get the PrintManager
                PrintManager printManager = doc.PrintManager;
                //Set the PrintManager PrintRange to Select
                printManager.PrintRange = PrintRange.Select;
                //Get the PrintManager's ViewSheetSetting
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;

                //Create a temporary sheet set
                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                try
                {
                    //Save the ViewSheetSetting with the user defined name so it can be modified later
                    viewSheetSetting.SaveAs(uiForm.sheetsOSSNewSetTextBox.Text);
                    t0.Commit();
                    
                    //Add a new DataColumn to the MainUI's DataTable with the header name of the user defined sheet set
                    DataColumn newColumn = new DataColumn();
                    newColumn.ColumnName = uiForm.sheetsOSSNewSetTextBox.Text;
                    newColumn.DataType = typeof(Boolean);
                    uiForm.sheetsOSSDataTable.Columns.Add(newColumn);
                }
                catch { t0.RollBack(); }
                dgv.Update();
            }
            else if (dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text))
            {
                //If a sheet set already exists with the same name as the user defined name, let the user know
                MessageBox.Show("Set with specified name already exists");
            }
            else
            {
                //Let the user know if they specified a name that could not be used
                MessageBox.Show("Cannot make a set with the specified name");
            }

            dgv.Update();
            dgv.Refresh();
            //Evaluate the cells of the DataGridView and set the background color for those that are checked
            GraphicsFormatting.HighlightCellsFromDataGridView(dgv, System.Drawing.Color.GreenYellow);
        }
    }
}
