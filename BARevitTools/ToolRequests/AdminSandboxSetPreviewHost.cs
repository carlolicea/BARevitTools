using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is not used in the BART add-in but remains as an example of how to incorporate a WPF window in a WinForms application
    // *This class is set to not build along with the rest of the classes*
    class AdminSandboxSetPreviewHost
    {
        public AdminSandboxSetPreviewHost(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            //This will add a child window of the Revit UI's preview window
            uiForm.sandBoxElementHost.Child = new PreviewControl(uiApp.ActiveUIDocument.Document, uiApp.ActiveUIDocument.Document.ActiveView.Id);
            uiForm.sandBoxElementHost.Update();
        }
    }
}
