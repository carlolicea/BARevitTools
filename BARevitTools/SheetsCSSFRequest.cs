using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class SheetsCSSFRequest
    {
        public SheetsCSSFRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            ViewSchedule schedule = uiForm.sheetsCSSFSDictionary[uiForm.sheetsCSSFSScheduleComboBox.Text];

            if (uiForm.sheetsCSSFSSetNameTextBox.Text != "<Sheet Set Name>" && uiForm.sheetsCSSFSSetNameTextBox.Text != "")
            {
                var sheetCollection = new FilteredElementCollector(doc, schedule.Id).OfClass(typeof(ViewSheet)).ToElements();

                PrintManager printManager = doc.PrintManager;
                printManager.PrintRange = PrintRange.Select;
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                t0.Commit();

                var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
                Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
                List<string> viewSheetSetNames = new List<string>();

                foreach (ViewSheetSet viewSheetSet in viewSheetSets)
                {
                    viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                    viewSheetSetNames.Add(viewSheetSet.Name);
                }

                Transaction t1 = new Transaction(doc, "CreateSheetSet");
                t1.Start();
                ViewSet newViewSet = new ViewSet();
                viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;
                if (sheetCollection != null)
                {
                    foreach (ViewSheet sheet in sheetCollection)
                    {
                        if (!sheet.IsPlaceholder)
                        { newViewSet.Insert(sheet); }
                    }
                    try
                    {
                        if (viewSheetSetNames.Contains(uiForm.sheetsCSSFSSetNameTextBox.Text))
                        {
                            ElementId vssId = viewSheetSetDict[uiForm.sheetsCSSFSSetNameTextBox.Text].Id;
                            doc.Delete(vssId);
                            viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                        }
                        else
                        {
                            viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                        }
                    }
                    catch
                    { MessageBox.Show("A sheet set with that name already exists"); }
                }
                t1.Commit();
            }
        }
    }
}
