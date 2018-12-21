using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Organize Sheet Set tool to update a sheet set
    class SheetsOSSRequest
    {
        public SheetsOSSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;

            //Collect the view sheets and view sheet sets
            var viewSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();
            var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
            Dictionary<string, Autodesk.Revit.DB.ViewSheet> viewSheetDict = new Dictionary<string, Autodesk.Revit.DB.ViewSheet>();
            Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
            List<int> viewSheetIds = new List<int>();
            List<string> viewSheetSetNames = new List<string>();

            //Add the sheets to the dictionary and list
            foreach (ViewSheet viewSheet in viewSheets)
            {
                if (!viewSheet.IsPlaceholder)
                {
                    try
                    {
                        viewSheetDict.Add(viewSheet.Name, viewSheet);
                        viewSheetIds.Add(viewSheet.Id.IntegerValue);
                    }
                    catch { MessageBox.Show(viewSheet.IsPlaceholder.ToString()); }
                }
            }

            //Add the view sheet sets to the dictionary and list
            foreach (ViewSheetSet viewSheetSet in viewSheetSets)
            {
                viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                viewSheetSetNames.Add(viewSheetSet.Name);
            }

            //Get the PrintManager and set its PrintRange to Select, then assign it the VeiwSheetSetting
            PrintManager printManager = doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;

            //Start a transaction
            Transaction t1 = new Transaction(doc, "UpdateViewSheetSets");
            t1.Start();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                //Go through the columns, but only grab those that have an index greater than 2, which correspond to the sheet set names
                if (column.Index > 2)
                {
                    //Make a new ViewSet
                    ViewSet newViewSet = new ViewSet();
                    viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;

                    //Foreach row, if the column has a checked checkbox, insert the sheet from the dictionary matching the sheet number into the ViewSet
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[column.Index].Value.ToString() == "True")
                        {
                            newViewSet.Insert(viewSheetDict[row.Cells[1].Value.ToString()]);
                        }
                    }

                    //If the viewSheetSetNames contains the column name, indicating the SheetSet already exists, delete it, then save a new one with the same name
                    if (viewSheetSetNames.Contains(column.Name))
                    {
                        ElementId vssId = viewSheetSetDict[column.Name].Id;
                        doc.Delete(vssId);
                        viewSheetSetting.SaveAs(column.Name);
                    }
                    else
                    {
                        //If the SheetSet does not already exist, just save it
                        viewSheetSetting.SaveAs(column.Name);
                    }
                }
            }
            t1.Commit();
            //Re-invoke the creation of the MainUI's controls for the OSS tool so the table updates with new data from the previous run
            uiForm.SheetsOSSButton_Click(null, null);
        }
    }
}
