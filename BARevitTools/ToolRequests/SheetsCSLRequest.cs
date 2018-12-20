using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This tool is associated with the Copy Sheet Legends tool
    class SheetsCSLRequest
    {
        public SheetsCSLRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            //Reset the progress bar
            uiForm.sheetsCSLProgressBar.Value = 0;
            uiForm.sheetsCSLProgressBar.Minimum = 0;
            uiForm.sheetsCSLProgressBar.Step = 1;
            uiForm.sheetsCSLProgressBar.Visible = true;

            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();

            //Create some objects for storage
            string selectedSheetNumber = uiForm.sheetsCSLComboBox.Text;
            List<string> selectedSheets = new List<string>();
            List<ElementId> viewsToCopy = new List<ElementId>();
            List<ElementId> viewportTypeIds = new List<ElementId>();
            List<XYZ> viewportLocations = new List<XYZ>();

            //Count the number of sheets with checkboxes in the DataGridView. Use that to set the number of steps for the progress bar
            int countOfSheets = 0;
            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if (row.Cells["Select"].Value.ToString() == "True")
                    {
                        selectedSheets.Add(row.Cells["Sheet Number"].Value.ToString());
                        countOfSheets++;
                    }
                    else { continue; }
                }
                else { continue; }
            }
            uiForm.sheetsCSLProgressBar.Maximum = countOfSheets;

            //Get the sheet to copy legends from
            if (uiForm.sheetsCSLComboBox.Text != "<Originating Sheet>")
            {
                //Cycle through the collection of sheets
                foreach (ViewSheet sheet in sheetsCollector)
                {
                    //If the current sheet number matches the sheet number of the sheet to copy from, continue
                    if (sheet.SheetNumber.ToString() == selectedSheetNumber)
                    {
                        //Collect the viewports from the sheet
                        ICollection<ElementId> viewportIds = sheet.GetAllViewports();
                        foreach (ElementId viewportId in viewportIds)
                        {
                            //For each viewport, get the ViewId, TypeId, and location
                            Viewport viewportElement = uidoc.Document.GetElement(viewportId) as Viewport;
                            ElementId viewportViewId = viewportElement.ViewId;
                            ElementId viewportViewTypeId = viewportElement.GetTypeId();
                            XYZ viewportLocation = viewportElement.GetBoxCenter();
                            Autodesk.Revit.DB.View viewportView = uidoc.Document.GetElement(viewportViewId) as Autodesk.Revit.DB.View;
                            //If the viewport is a legend, continue
                            if (viewportView.ViewType.ToString() == "Legend")
                            {
                                //Add the three sets of data to the lists
                                viewsToCopy.Add(viewportViewId);
                                viewportTypeIds.Add(viewportViewTypeId);
                                viewportLocations.Add(viewportLocation);
                            }
                            else { continue; }
                        }
                        break;
                    }
                    else { continue; }
                }
            }

            //Start a new transaction
            Transaction t1 = new Transaction(uidoc.Document, "CopyLegendsFromSheetToSheets");
            t1.Start();
            //For each sheet in the collector...
            foreach (ViewSheet sheet in sheetsCollector)
            {
                //If the selected sheets contains the sheet number, continue
                if (selectedSheets.Contains(sheet.SheetNumber.ToString()))
                {
                    //Step forward the progress bar
                    uiForm.sheetsCSLProgressBar.PerformStep();
                    int x = viewsToCopy.Count();
                    int i = 0;

                    //For each sheet in viewsToCopy
                    while (i < x)
                    {
                        try
                        {
                            //Create a new viewport and place it on the sheet in the same location 
                            Viewport newViewport = Viewport.Create(uidoc.Document, sheet.Id, viewsToCopy[i], viewportLocations[i]);
                            newViewport.ChangeTypeId(viewportTypeIds[i]);
                            i++;
                        }
                        catch { i++; }
                    }
                }
                else { continue; }
            }
            t1.Commit();
            t1.Dispose();
            //Reset the filter text box if it was set
            uiForm.sheetsCSLFilterTextBox.Text = "";

            //Reset the backcolor of each row in the DataGridView
            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                row.Cells["Select"].Value = false;
                row.Cells["Select"].Style.BackColor = uiForm.sheetsCSLDataGridView.DefaultCellStyle.BackColor;
            }
        }
    }
}
