#region Namespaces
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;
using Autodesk.Revit.UI;
#endregion

namespace BARevitTools
{
    class Application : IExternalApplication
    {
        public DataTable appUseDataTable = null;
        internal static Application thisApp = null;
        public static UIControlledApplication _cachedUiCtrApp;
        public MainUI newMainUi = null;
        public SharedParametersUI newSPUi = null;        
        public Result OnStartup(UIControlledApplication application)
        {
            _cachedUiCtrApp = application;
            thisApp = this;
            try
            {
                RibbonPanel BARevitToolsPanel = CreateExtAppRibbonPanel();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return Result.Failed;
            }
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            if (newMainUi != null && newMainUi.Visible)
            {
                newMainUi.Close();                
            }            
            return Result.Succeeded;
        } 
        public void ShowForm(UIApplication uiApp)
        {
            RequestHandler handler = new RequestHandler(_cachedUiCtrApp);
            ExternalEvent exEvent = ExternalEvent.Create(handler);
            newMainUi = new MainUI(uiApp, exEvent, handler);
            newSPUi = new SharedParametersUI(uiApp);
            appUseDataTable = new DataTable();
            DatabaseOperations.MakeAppUseDataTable(appUseDataTable);
            newMainUi.Show();
        }
        public void WakeFormUp()
        {
            if (newMainUi != null)
            {
                newMainUi.WakeUp();
            }
        }
        private RibbonPanel CreateExtAppRibbonPanel()
        {
            System.Windows.Media.ImageSource largeIcon = BmpImageSource(Properties.Resources.BAlogo32x32);
            System.Windows.Media.ImageSource smallIcon = BmpImageSource(Properties.Resources.BAlogo16x16);

            RibbonPanel ribbonPanel = _cachedUiCtrApp.CreateRibbonPanel("BART");
            ribbonPanel.Name = "BART";
            ribbonPanel.Title = "BART";

            PushButtonData mainExtAppButtonData = new PushButtonData("BART", "BART", Assembly.GetExecutingAssembly().Location, "BARevitTools.Launcher");
            PushButton mainExtAppButton = ribbonPanel.AddItem(mainExtAppButtonData) as PushButton;
            mainExtAppButton.ToolTip = "Launch the BART UI";
            mainExtAppButton.LargeImage = largeIcon;
            mainExtAppButton.Image = smallIcon;

            return ribbonPanel;
        }
        private System.Windows.Media.ImageSource BmpImageSource(System.Drawing.Bitmap bitmap)
        {
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);
            image.StreamSource = memoryStream;
            image.EndInit();
            return image;
        }
    }
}


