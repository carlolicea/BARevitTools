using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is responsible for exporting an image of a plan view with the lower left and upper right coordinates of the viewport in the file name
    class DataEPIRequest
    {
        public DataEPIRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            //Get the active view in Revit
            Autodesk.Revit.DB.View activeView = uidoc.Document.ActiveView;
            //If the active view is a Plan View, continue
            if (activeView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
                //If the active view does not have an active crop box, activate it.
                if (activeView.CropBoxActive == false)
                {
                    Transaction t1 = new Transaction(uidoc.Document, "Crop Active View");
                    t1.Start();
                    try
                    {
                        activeView.CropBoxActive = true;
                        t1.Commit();
                    }
                    catch
                    {
                        t1.RollBack();
                    }
                }

                //Get the cropbox's bounding box
                BoundingBoxXYZ cropBox = activeView.CropBox;
                double cropBoxOriginX = 0;
                double cropBoxOriginY = 0;
                //If the origin of the crop box has shifted, reset it 
                if (cropBox.Transform.Origin.X != 0)
                {
                    cropBoxOriginX = cropBox.Transform.Origin.X;
                }
                if (cropBox.Transform.Origin.Y != 0)
                {
                    cropBoxOriginY = cropBox.Transform.Origin.Y;
                }

                //Get the minimum and maximum points of the cropbox bounding box
                XYZ cropboxMin = cropBox.Min;
                XYZ cropboxMax = cropBox.Max;

                //Get the minimum and maximum X and Y coordinates of the points, rounded to 3 decimal places
                double cropBoxMinX = Math.Round(cropBox.Min.X, 3) + cropBoxOriginX;
                double cropBoxMinY = Math.Round(cropBox.Min.Y, 3) + cropBoxOriginY;
                double cropBoxMaxX = Math.Round(cropBox.Max.X, 3) + cropBoxOriginX;
                double cropBoxMaxY = Math.Round(cropBox.Max.Y, 3) + cropBoxOriginY;

                //Construct the file path with the coordinates in the path name
                string filePath = uiForm.dataEPIDirectorySelectedLabel.Text + "\\" + uiForm.dataEPISaveTextBox.Text + "_" + cropBoxMinX.ToString() + "_" + cropBoxMinY.ToString() + "_" + cropBoxMaxX.ToString() + "_" + cropBoxMaxY.ToString() + ".jpg";
                //Set the export options
                ImageExportOptions imageExportOptions = new ImageExportOptions();
                imageExportOptions.FilePath = filePath;
                imageExportOptions.FitDirection = FitDirectionType.Horizontal;
                //Set the zoom to 100%
                imageExportOptions.ZoomType = ZoomFitType.Zoom;
                imageExportOptions.Zoom = 100;
                imageExportOptions.HLRandWFViewsFileType = ImageFileType.JPEGSmallest;
                //Determing what DPI the user selected, and set the ImageResoltion property accordingly
                if (uiForm.dataEPIDPIComboBox.Text == "150")
                {
                    imageExportOptions.ImageResolution = ImageResolution.DPI_150;
                }
                else if (uiForm.dataEPIDPIComboBox.Text == "300")
                {
                    imageExportOptions.ImageResolution = ImageResolution.DPI_300;
                }
                else { imageExportOptions.ImageResolution = ImageResolution.DPI_600; }
                imageExportOptions.ExportRange = ExportRange.CurrentView;

                //If the image already exists, delete it
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                //Then, export the image
                uidoc.Document.ExportImage(imageExportOptions);
            }
            //If the view was not a plan view, this reminder will tell the user to run the script from a cropped Plan View
            else { MessageBox.Show("Please run from a cropped plan view"); }
        }
    }
}
