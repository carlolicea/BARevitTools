using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
{
    class ViewsOICBRequest
    {
        public ViewsOICBRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewerCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();
            OverrideGraphicSettings orgs = new OverrideGraphicSettings();
            orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
            orgs.SetProjectionLineWeight(5);

            
            Transaction t1 = new Transaction(uidoc.Document, "OverrideInteriorElevationCrops");
            t1.Start();
            foreach (Viewport viewport in viewportCollector)
            {
                ElementId viewId = viewport.ViewId;
                Element viewElem = uidoc.Document.GetElement(viewId);
                Autodesk.Revit.DB.View viewElemView = viewElem as Autodesk.Revit.DB.View;
                ElementId typeId = viewElem.GetTypeId();
                Element typeElement = uidoc.Document.GetElement(typeId);
                string typeElementName = typeElement.Name.ToString();
                if (viewElem.GetType().ToString() == "Autodesk.Revit.DB.ViewSection" && viewElemView.ViewType == ViewType.Elevation && typeElementName.Contains("Interior"))
                {
                    var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                    foreach (Element viewer in viewerCollector)
                    {
                        if (viewer.Name.ToString() == viewElem.Name.ToString())
                        {
                            Autodesk.Revit.DB.View viewToOverride = viewElem as Autodesk.Revit.DB.View;
                            viewToOverride.SetElementOverrides(viewer.Id, orgs);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            t1.Commit();
        }
    }
}
