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
    //This is the main entry point for all parts of BART. It is what creates the UIs and makes the Ribbon Panel Add-ins button
    //Derive a class from IExternalApplication in the Revit API
    class Application : IExternalApplication
    {
        //
        //Create a DataTable object for collecting button presses
        public DataTable appUseDataTable = null;
        //
        //Create an object for the Revit API Application class
        internal static Application thisApp = null;
        //
        //Create an object for the Revit API UIControlled Application
        public static UIControlledApplication _cachedUiCtrApp;
        //
        //Create an object for the MainUI interface to be assigned to a new UI when it is created
        public MainUI newMainUi = null;
        //
        //Create an object for the additional shared parameters UI to be assigned with it is created
        public SharedParametersUI newSPUi = null;   
        
        public bool CadDriveIsAccessible = false;
        //
        //When Revit starts, IExternalApplication implements OnStartup
        public Result OnStartup(UIControlledApplication application)
        {
            //The UIControlledApplication is the Application
            _cachedUiCtrApp = application;
            //thisApp is this IExternal Application
            thisApp = this;

            //Try to generate the ribbon panel from the CreateExtAppRibbonPanel method. Return the result
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
        //
        //When Revit shuts down, close the open MainUI if it is visible. Return the result.
        public Result OnShutdown(UIControlledApplication application)
        {
            if (newMainUi != null && newMainUi.Visible)
            {
                newMainUi.Close();                
            }            
            return Result.Succeeded;
        } 
        //
        //When this method is used, it will show the MainUI
        public void ShowForm(UIApplication uiApp)
        {
            //Create a new RequestHandler object
            RequestHandler handler = new RequestHandler(_cachedUiCtrApp);
            //Create a new ExternalEvent object
            ExternalEvent exEvent = ExternalEvent.Create(handler);
            //Set newMainUI to a new instance of MainUI, passing the UIApplication, ExternalEvent, and RequestHandler it will need to use
            newMainUi = new MainUI(uiApp, exEvent, handler);
            //Set the newSPUi to a new instance of SharedParameterUI, which only needs UIApplication. Do not show until needed
            newSPUi = new SharedParametersUI(uiApp);

            CadDriveIsAccessible = GeneralOperations.IsCadDriveAccessible();
            if (CadDriveIsAccessible == false)
            {
                MessageBox.Show("Cannot access the K Drive. Some tools will not be functional.");
            }

            //Generate a new DataTable for collecting data
            appUseDataTable = new DataTable();
            //Prep the appUseDataTable by adding the appropriate columns using the following method
            DatabaseOperations.MakeAppUseDataTable(appUseDataTable);

            //Show the MainUI
            newMainUi.Show();
        }
        //
        //This is used to activate MainUI's buttons
        public void WakeFormUp()
        {
            if (newMainUi != null)
            {
                //Exists in the MainUI class, where newMainUI was derived.
                newMainUi.WakeUp();
            }
        }
        //
        //This creates a new Revit UI Ribbon Panel for launching BART's MainUI
        private RibbonPanel CreateExtAppRibbonPanel()
        {
            //The icon for the ribbon panel button will need to be generated from an Image source
            System.Windows.Media.ImageSource largeIcon = BmpImageSource(Properties.Resources.BAlogo32x32);
            System.Windows.Media.ImageSource smallIcon = BmpImageSource(Properties.Resources.BAlogo16x16);

            //For the UIControlledApp, create the ribbon panel
            RibbonPanel ribbonPanel = _cachedUiCtrApp.CreateRibbonPanel("BART");
            ribbonPanel.Name = "BART";
            ribbonPanel.Title = "BART";

            //Add a button that executes the ExternalCommand, BARevitTools.Launcher class
            PushButtonData mainExtAppButtonData = new PushButtonData("BART", "BART", Assembly.GetExecutingAssembly().Location, "BARevitTools.Launcher");
            PushButton mainExtAppButton = ribbonPanel.AddItem(mainExtAppButtonData) as PushButton;
            mainExtAppButton.ToolTip = "Launch the BART UI";
            mainExtAppButton.LargeImage = largeIcon;
            mainExtAppButton.Image = smallIcon;

            return ribbonPanel;
        }
        //
        //This creates the ImageSource for the button associated with the ribbon panel
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


