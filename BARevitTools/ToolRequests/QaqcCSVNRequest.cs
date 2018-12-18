using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is used in the Capitalize Sheet and View Names tool, which capitalizes the names of all sheets and views on sheets. Views not on sheets are skipped.
    class QaqcCSVNRequest
    {
        public QaqcCSVNRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Collect the sheets and viewports
            ICollection<Element> sheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).WhereElementIsNotElementType().ToElements();
            ICollection<Element> viewports = new FilteredElementCollector(doc).OfClass(typeof(Viewport)).WhereElementIsNotElementType().ToElements();

            //Start a transaction. All actions are encapislated in this transaction so USING was used here for tidiness
            using (Transaction t1 = new Transaction(doc, "CapitalizeSheetAndViewNames"))
            {
                t1.Start();

                //Cycle through each sheet
                foreach (ViewSheet sheet in sheets)
                {
                    try
                    {
                        //Set the name of the sheet to an all capitalized name
                        sheet.Name = sheet.Name.ToString().ToUpper();
                    }
                    catch
                    {
                        continue;
                    }
                }

                //Cycle through each viewport
                foreach (Viewport viewport in viewports)
                {
                    try
                    {
                        //Assuming the viewport is on a sheet, continue
                        if (viewport.SheetId.ToString() != "InvalidElementId")
                        {
                            //Get the viewport as a view, then set the view name to all caps
                            ElementId viewId = viewport.ViewId;
                            Autodesk.Revit.DB.View viewportView = doc.GetElement(viewId) as Autodesk.Revit.DB.View;
                            viewportView.Name = viewportView.Name.ToString().ToUpper();
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                t1.Commit();
            }
        }
    }
}
