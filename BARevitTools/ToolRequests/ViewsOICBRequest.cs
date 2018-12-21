using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Override Interior Crop Boundary tool which works with the HNIEC tool
    class ViewsOICBRequest
    {
        public ViewsOICBRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            //Collect all viewers and viewports
            var viewerCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();
            //Generate an OverrideGraphicsSetting
            OverrideGraphicSettings orgs = new OverrideGraphicSettings();
            //Use the solid line pattern
            orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
            //Set the line weight to the property value
            orgs.SetProjectionLineWeight(Properties.Settings.Default.RevitOverrideInteriorCropWeight);

            //Start a new transaction and cycle through the viewports
            Transaction t1 = new Transaction(uidoc.Document, "OverrideInteriorElevationCrops");
            t1.Start();
            foreach (Viewport viewport in viewportCollector)
            {
                //Get the view associated with the viewport, then get its ViewType
                ElementId viewId = viewport.ViewId;
                Element viewElem = uidoc.Document.GetElement(viewId);
                Autodesk.Revit.DB.View viewElemView = viewElem as Autodesk.Revit.DB.View;
                ElementId typeId = viewElem.GetTypeId();
                Element typeElement = uidoc.Document.GetElement(typeId);
                string typeElementName = typeElement.Name.ToString();
                //If the view is a derivative of a section, its type is an Elevation, and its type name contains Interior, continue
                if (viewElem.GetType().ToString() == "Autodesk.Revit.DB.ViewSection" && viewElemView.ViewType == ViewType.Elevation && typeElementName.Contains("Interior"))
                {
                    //Get the viewers and cycle through them
                    var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                    foreach (Element viewer in viewerCollector)
                    {
                        //If the viewer's name is equal to the view's name, continue
                        if (viewer.Name.ToString() == viewElem.Name.ToString())
                        {
                            //Override the view element's viewer with the settings
                            Autodesk.Revit.DB.View viewToOverride = viewElem as Autodesk.Revit.DB.View;
                            viewToOverride.SetElementOverrides(viewer.Id, orgs);
                        }else{continue;}
                    }
                }else{continue;}
            }
            t1.Commit();
        }
    }
}
