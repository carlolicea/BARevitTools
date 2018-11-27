using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class SheetsOSSRequest
    {
        public SheetsOSSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;
            var viewSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();
            var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
            Dictionary<string, Autodesk.Revit.DB.ViewSheet> viewSheetDict = new Dictionary<string, Autodesk.Revit.DB.ViewSheet>();
            Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
            List<int> viewSheetIds = new List<int>();
            List<string> viewSheetSetNames = new List<string>();

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
            foreach (ViewSheetSet viewSheetSet in viewSheetSets)
            {
                viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                viewSheetSetNames.Add(viewSheetSet.Name);
            }


            PrintManager printManager = doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;


            Transaction t1 = new Transaction(doc, "UpdateViewSheetSets");
            t1.Start();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 2)
                {
                    ViewSet newViewSet = new ViewSet();
                    viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[column.Index].Value.ToString() == "True")
                        {
                            newViewSet.Insert(viewSheetDict[row.Cells[1].Value.ToString()]);
                        }
                    }
                    if (viewSheetSetNames.Contains(column.Name))
                    {
                        ElementId vssId = viewSheetSetDict[column.Name].Id;
                        doc.Delete(vssId);
                        viewSheetSetting.SaveAs(column.Name);
                    }
                    else
                    {
                        viewSheetSetting.SaveAs(column.Name);
                    }
                }
            }
            t1.Commit();
            uiForm.SheetsOSSButton_Click(null, null);
        }
    }
}
