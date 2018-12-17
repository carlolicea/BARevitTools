using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is for the Convert Text Size tool for conversion of text prior to Revit 2017 to a similarly scaled text size for 2017 and later
    class DocumentsCTSRequest
    {
        public DocumentsCTSRequest(UIApplication uiApp, String text)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            //Collect the text note types and dimension types
            FilteredElementCollector textNoteTypesCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector dimensionTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> textNoteTypes = textNoteTypesCollector.OfClass(typeof(TextNoteType)).ToElements();
            ICollection<Element> dimensionTypes = dimensionTypesCollector.OfClass(typeof(DimensionType)).ToElements();

            //The amount to decrease the text by is 1/64", and thus this formula gets the 1/64" in decimal feet
            decimal decreaseValue = (decimal)(1m / 64m / 12m);
            //The lower limit of the text size is 3/128", and thus this formula gets 3/128" in decimal feet
            decimal lowerLimit = (decimal)(3m / 128m / 12m);

            //Start the transaction
            Transaction t1 = new Transaction(uidoc.Document, "Convert Text Note Text");
            t1.Start();

            //Evaluate each text note type
            foreach (TextNoteType textNoteType in textNoteTypes)
            {
                //Get the text note type's text size
                Parameter param = textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE);
                //Get the original size in decimal feet
                decimal originalSize = (decimal)param.AsDouble();
                //Get the new size by subtracting 1/64" from the original size
                decimal newSize = originalSize - decreaseValue;
                //Verify the new size is greater than the lower limit
                if (newSize > lowerLimit)
                {
                    try
                    {
                        //Set the size of the text note type
                        param.Set((double)newSize);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            //Perform the same operations for the dimension types
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
        }
    }
}
