using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class AdminSandboxSetPreviewHost
    {
        public AdminSandboxSetPreviewHost(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sandBoxElementHost.Child = new PreviewControl(uiApp.ActiveUIDocument.Document, uiApp.ActiveUIDocument.Document.ActiveView.Id);
            uiForm.sandBoxElementHost.Update();
        }
    }
}
