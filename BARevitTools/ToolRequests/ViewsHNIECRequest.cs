using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Hide Non-Interior Crop Boundaries to be used with the CEPR and OICB tools
    class ViewsHNIECRequest
    {
        public ViewsHNIECRequest(UIApplication uiApp, String text)
        {
            //Collect all viewports
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();

            //Start the transaction
            Transaction t1 = new Transaction(uidoc.Document, "HideNonInteriorElevationCrops");
            t1.Start();
            try
            {
                //Cycle through the viewports
                foreach (Viewport viewport in viewportCollector)
                {
                    //Get the view type for the view by getting the associated view
                    ElementId viewId = viewport.ViewId;
                    Autodesk.Revit.DB.View viewElem = uidoc.Document.GetElement(viewId) as Autodesk.Revit.DB.View;
                    string viewType = viewElem.GetType().ToString();
                    //If the ViewType indicates a plan, turn off the crop box
                    if (viewType == "Autodesk.Revit.DB.ViewPlan")
                    {
                        viewElem.CropBoxVisible = false;
                    }
                    //If the ViewType is a section, check if it is an elevation
                    else if (viewType == "Autodesk.Revit.DB.ViewSection")
                    {
                        if (viewElem.ViewType.ToString() == "Elevation")
                        {
                            //If the ViewType indicaes it is an elevation, check the type name
                            ElementId typeId = viewElem.GetTypeId();
                            ElementType typeElement = uidoc.Document.GetElement(typeId) as ElementType;
                            string typeElementName = typeElement.Name.ToString();
                            //If the type name does not contain Interior, turn off the crop boundary
                            if (!typeElementName.Contains("Interior"))
                            {
                                viewElem.CropBoxVisible = false;
                            }
                            else
                            { continue; }
                        }
                        else
                        {
                            //If the section is not an elevation, turn off the crop box anyways
                            viewElem.CropBoxVisible = false;
                        }
                    }
                    //We only care about floor plans' and section derivatives' crop boxes, so skip the other types
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
