using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class DataEPIRequest
    {
        public DataEPIRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            Autodesk.Revit.DB.View activeView = uidoc.Document.ActiveView;
            if (activeView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
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

                BoundingBoxXYZ cropBox = activeView.CropBox;
                double cropBoxOriginX = 0;
                double cropBoxOriginY = 0;
                if (cropBox.Transform.Origin.X != 0)
                {
                    cropBoxOriginX = cropBox.Transform.Origin.X;
                }
                if (cropBox.Transform.Origin.Y != 0)
                {
                    cropBoxOriginY = cropBox.Transform.Origin.Y;
                }

                XYZ cropboxMin = cropBox.Min;
                XYZ cropboxMax = cropBox.Max;

                double cropBoxMinX = Math.Round(cropBox.Min.X, 3) + cropBoxOriginX;
                double cropBoxMinY = Math.Round(cropBox.Min.Y, 3) + cropBoxOriginY;
                double cropBoxMaxX = Math.Round(cropBox.Max.X, 3) + cropBoxOriginX;
                double cropBoxMaxY = Math.Round(cropBox.Max.Y, 3) + cropBoxOriginY;

                string filePath = uiForm.dataEPIDirectorySelectedLabel.Text + "\\" + uiForm.dataEPISaveTextBox.Text + "_" + cropBoxMinX.ToString() + "_" + cropBoxMinY.ToString() + "_" + cropBoxMaxX.ToString() + "_" + cropBoxMaxY.ToString() + ".jpg";
                ImageExportOptions imageExportOptions = new ImageExportOptions();
                imageExportOptions.FilePath = filePath;
                imageExportOptions.FitDirection = FitDirectionType.Horizontal;
                imageExportOptions.ZoomType = ZoomFitType.Zoom;
                imageExportOptions.Zoom = 100;
                imageExportOptions.HLRandWFViewsFileType = ImageFileType.JPEGSmallest;
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
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                uidoc.Document.ExportImage(imageExportOptions);
            }
            else { MessageBox.Show("Please run from a cropped plan view"); }
        }
    }
}
