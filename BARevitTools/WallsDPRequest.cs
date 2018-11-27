using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class WallsDPRequest
    {
        public WallsDPRequest(UIApplication uiApp, String text)
        {
            Transaction t1 = new Transaction(uiApp.ActiveUIDocument.Document, "RemoveWallParts");
            t1.Start();
            ElementId elementId = RVTOperations.SelectElement(uiApp);
            if (elementId != null)
            {
                RVTOperations.DeleteParts(uiApp, uiApp.ActiveUIDocument.Document, elementId);
            }
            else { MessageBox.Show("No element was selected"); }
            t1.Commit();
        }
    }
}
