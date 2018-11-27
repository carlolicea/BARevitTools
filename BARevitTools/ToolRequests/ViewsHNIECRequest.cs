using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class ViewsHNIECRequest
    {
        public ViewsHNIECRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();

            Transaction t1 = new Transaction(uidoc.Document, "HideNonInteriorElevationCrops");
            t1.Start();
            try
            {
                foreach (Viewport viewport in viewportCollector)
                {
                    ElementId viewId = viewport.ViewId;
                    Autodesk.Revit.DB.View viewElem = uidoc.Document.GetElement(viewId) as Autodesk.Revit.DB.View;
                    string viewType = viewElem.GetType().ToString();
                    if (viewType == "Autodesk.Revit.DB.ViewPlan")
                    {
                        viewElem.CropBoxVisible = false;
                    }
                    else if (viewType == "Autodesk.Revit.DB.ViewSection")
                    {
                        if (viewElem.ViewType.ToString() == "Elevation")
                        {
                            ElementId typeId = viewElem.GetTypeId();
                            ElementType typeElement = uidoc.Document.GetElement(typeId) as ElementType;
                            string typeElementName = typeElement.Name.ToString();
                            if (!typeElementName.Contains("Interior"))
                            {
                                viewElem.CropBoxVisible = false;
                            }
                            else
                            { continue; }
                        }
                        else
                        {
                            viewElem.CropBoxVisible = false;
                        }
                    }
                    else { continue; }
                }
                t1.Commit();
            }
            catch
            {
                t1.RollBack();
            }
        }
    }
}
