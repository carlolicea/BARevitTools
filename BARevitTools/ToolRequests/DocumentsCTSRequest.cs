using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class DocumentsCTSRequest
    {
        public DocumentsCTSRequest(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector textNoteTypesCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector dimensionTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> textNoteTypes = textNoteTypesCollector.OfClass(typeof(TextNoteType)).ToElements();
            ICollection<Element> dimensionTypes = dimensionTypesCollector.OfClass(typeof(DimensionType)).ToElements();
            decimal decreaseValue = (decimal)(1m / 64m / 12m);
            decimal lowerLimit = (decimal)(3m / 128m / 12m);
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "Convert Text Note Text");
            t1.Start();

            foreach (TextNoteType textNoteType in textNoteTypes)
            {
                Parameter param = textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE);
                decimal originalSize = (decimal)param.AsDouble();
                decimal newSize = originalSize - decreaseValue;
                if (newSize > lowerLimit)
                {
                    try
                    {
                        param.Set((double)newSize);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            foreach (DimensionType dimensiontype in dimensionTypes)
            {
                Parameter param = dimensiontype.get_Parameter(BuiltInParameter.TEXT_SIZE);
                decimal originalSize = (decimal)param.AsDouble();
                decimal newSize = originalSize - decreaseValue;
                if (newSize > lowerLimit)
                {
                    try
                    {
                        param.Set((double)newSize);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
    }
}
