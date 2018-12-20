using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Create Sheet Sets From Schedules tool
    class SheetsCSSFSRequest
    {
        public SheetsCSSFSRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //From the MainUI's dictionary, get the schedule by name
            ViewSchedule schedule = uiForm.sheetsCSSFSDictionary[uiForm.sheetsCSSFSScheduleComboBox.Text];

            //Assuming the user has set the name for the sheet set, continue
            if (uiForm.sheetsCSSFSSetNameTextBox.Text != "<Sheet Set Name>" && uiForm.sheetsCSSFSSetNameTextBox.Text != "")
            {
                //Collect all sheets in the project
                var sheetCollection = new FilteredElementCollector(doc, schedule.Id).OfClass(typeof(ViewSheet)).ToElements();

                //Get the PrintManager for the project
                PrintManager printManager = doc.PrintManager;
                //Set the PrintManager PrintRange to Select
                printManager.PrintRange = PrintRange.Select;
                //Set the PrintManager ViewSheetSetting
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
                //Create a new transaction to make a temporary sheet set with the user defined name
                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                t0.Commit();
                //The temporary sheet set was needed to ensure there was a sheet set to modify

                //Collect the view sheet sets
                var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
                Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
                List<string> viewSheetSetNames = new List<string>();

                //Add the view sheet sets to the dictionary and list
                foreach (ViewSheetSet viewSheetSet in viewSheetSets)
                {
                    viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                    viewSheetSetNames.Add(viewSheetSet.Name);
                }

                //Make a new ViewSet
                Transaction t1 = new Transaction(doc, "CreateSheetSet");
                t1.Start();
                ViewSet newViewSet = new ViewSet();
                //Set the ViewSheetSetting to the current ViewSet's views
                viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;
                if (sheetCollection != null)
                {
                    //For each sheet in the collection...
                    foreach (ViewSheet sheet in sheetCollection)
                    {
                        //If the sheet is not a placeholder, add it to the ViewSet
                        if (!sheet.IsPlaceholder)
                        { newViewSet.Insert(sheet); }
                    }
                    try
                    {
                        //If the ViewSheetSet list of names contains the user defined set...
                        if (viewSheetSetNames.Contains(uiForm.sheetsCSSFSSetNameTextBox.Text))
                        {
                            //Get the ID of the ViewSheetSet from the dictionary
                            ElementId vssId = viewSheetSetDict[uiForm.sheetsCSSFSSetNameTextBox.Text].Id;
                            //Delete that ViewSheetSet to make way for a new version. The old version was the temporary one
                            doc.Delete(vssId);
                            //Save the ViewSheetSetting as the user defined name for the sheet set
                            viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                        }
                        else
                        {
                            //If the ViewSheetSet did not already exist, save the ViewSheetSetting
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
