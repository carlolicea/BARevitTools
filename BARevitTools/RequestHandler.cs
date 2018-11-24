using Autodesk.Revit.UI;
using System;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools
{
    public partial class RequestHandler : IExternalEventHandler
    {        
        UIControlledApplication uiApp = null;
        public RequestHandler(UIControlledApplication newUIApp)
        {
            uiApp = newUIApp;
        }
        public Requests m_request = new Requests();        
        public Requests Request
        {
            get { return m_request; }
        }        
        public String GetName()
        {
            return "BARevitTools External Event";
        }
        public void Execute(UIApplication uiApp)
        {
            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {return;}
                    case RequestId.multiCatCFFE1:
                        Tools.AllCatCFFE1Request allCatCFFE1Request = new Tools.AllCatCFFE1Request(uiApp, "Get Parameters");
                        break;
                    case RequestId.multiCatCFFE2:
                        Tools.AllCatCFFE2Request allCatCFFE2Request = new Tools.AllCatCFFE2Request(uiApp, "Make Families");
                        break;
                    case RequestId.electricalCEOE:
                        Tools.ElectricalCEORequest electricalCEORequest = new Tools.ElectricalCEORequest(uiApp, "Correct Electrical Outlet Elevation");
                        break;
                    case RequestId.floorsCFBR:
                        Tools.FloorsCFBRRequest floorsCFBRRequest = new Tools.FloorsCFBRRequest(uiApp, "Create Floors by Room");
                        break;
                    case RequestId.materialsCMS:
                        Tools.MaterialsCMSRequest materialsCMSRequest = new Tools.MaterialsCMSRequest(uiApp, "Create Material Symbols");
                        break;
                    case RequestId.materialsAML:
                        Tools.MaterialsAMLRequest materialsAMLRequest = new Tools.MaterialsAMLRequest(uiApp, "Accent Material Lines");
                        break;
                    case RequestId.materialsAMLPalette:
                        Tools.MaterialsAMLPaletteRequest materialsAMLPaletteRequest = new Tools.MaterialsAMLPaletteRequest(uiApp, "Accent Material Lines Palette");
                        break;
                    case RequestId.roomsSRNN:
                        Tools.RoomsSRNNRequest roomsSRNNRequest = new Tools.RoomsSRNNRequest(uiApp, "Swap Room Names and Numbers");
                        break;
                    case RequestId.roomsCDRT:
                        Tools.RoomsCDRTRequest roomsCDRTRequest = new Tools.RoomsCDRTRequest(uiApp, "Create Demo Room Tags");
                        break;
                    case RequestId.wallsMPW:
                        Tools.WallsMPWRequest wallsMPWRequest = new Tools.WallsMPWRequest(uiApp, "Make Perimeter Walls");
                        break;
                    case RequestId.wallsDP:
                        Tools.WallsDPRequest wallsDPRequest = new Tools.WallsDPRequest(uiApp, "Delete Wall Parts");
                        break;
                    case RequestId.sheetsCSL:
                        Tools.SheetsCSLRequest sheetsCSLReqeuset = new Tools.SheetsCSLRequest(uiApp, "Copy Sheet Legends to Sheets");
                        break;
                    case RequestId.sheetsISFL:
                        Tools.SheetsISFLRequest sheetsISFLRequest = new Tools.SheetsISFLRequest(uiApp, "Insert sheets from link");
                        break;
                    case RequestId.sheetsCSSFS:
                        Tools.SheetsCSSFRequest sheetsCSSFRequest = new Tools.SheetsCSSFRequest(uiApp, "Create Sheet Set from Schedule");
                        break;
                    case RequestId.sheetsOSS:
                        Tools.SheetsOSSRequest sheetsOSSRequest = new Tools.SheetsOSSRequest(uiApp, "Organize Sheet Set");
                        break;
                    case RequestId.sheetSOSSNewSet:
                        Tools.SheetsOSSNewSetRequest sheetsOSSNewSetRequest = new Tools.SheetsOSSNewSetRequest(uiApp, "Make New Set");
                        break;
                    case RequestId.viewsCEPR:
                        Tools.ViewsCEPRRequest viewsCEPRRequest = new Tools.ViewsCEPRRequest(uiApp, "Create Elevations Per Room");
                        break;
                    case RequestId.viewsOICB:
                        Tools.ViewsOICBRequest viewsOICBRequest = new Tools.ViewsOICBRequest(uiApp, "Override Interior Elevation Crop Boundaries");
                        break;
                    case RequestId.viewsHNIEC:
                        Tools.ViewsHNIECRequest viewsHNIECRequest = new Tools.ViewsHNIECRequest(uiApp, "Hide Non Interior Elevation Crops");
                        break;
                    case RequestId.dataEPI:
                        Tools.DataEPIRequest dataEPIRequest = new Tools.DataEPIRequest(uiApp, "Export Plan Image");
                        break;
                    case RequestId.miscEDV:
                        Tools.MiscEDVRequest miscEDVRequest = new Tools.MiscEDVRequest(uiApp, "Export Drafting Views");
                        break;
                    case RequestId.documentsCTS:
                        Tools.DocumentsCTSRequest documentsCTSRequest = new Tools.DocumentsCTSRequest(uiApp, "Change Text Scale");
                        break;
                    case RequestId.qaqcCSVN:
                        Tools.QaqcCSVNRequest qaqcCSVNRequest = new Tools.QaqcCSVNRequest(uiApp, "Capitalize Sheet and View Names");
                        break;
                    case RequestId.qaqcDRNP:
                        Tools.QaqcDRNPRequest qaqcDRNPRequest = new Tools.QaqcDRNPRequest(uiApp, "Delete Rooms Not Placed");
                        break;
                    case RequestId.qaqcCSV:
                        Tools.QaqcCSVRequest qaqcCSVRequest= new Tools.QaqcCSVRequest(uiApp, "Capitalize Sheet Values");
                        break;
                    case RequestId.qaqcRLS:
                        Tools.QaqcRLSRequest qaqcRLSRequest = new Tools.QaqcRLSRequest(uiApp, "Remove Line Styles");
                        break;
                    case RequestId.qaqcRFSP:
                        Tools.QaqcRFSPRequest qaqcRFSPRequest = new Tools.QaqcRFSPRequest(uiApp, "Remove Family Shared Parameters");
                        break;
                    case RequestId.setupCWS:
                        Tools.SetupCWSRequest setupCWSRequest = new Tools.SetupCWSRequest(uiApp, "Create Worksets");
                        break;
                    case RequestId.setupUP:
                        Tools.SetupUPRequest setupUPRequest = new Tools.SetupUPRequest(uiApp, "Upgrade Project");
                        break;
                    case RequestId.adminDataGFF:
                        Tools.AdminDataGFFRequest adminDataGFFRequest = new Tools.AdminDataGFFRequest(uiApp, "Get Family Data");
                        break;
                    case RequestId.adminFamiliesUF:
                        Tools.AdminFamiliesUFRequest adminFamiliesUFRequest = new Tools.AdminFamiliesUFRequest(uiApp, "Upgrade Families");
                        break;
                    case RequestId.adminFamiliesBAP:
                        Tools.AdminFamiliesBAPRequest adminFamiliesBAPRequest = new Tools.AdminFamiliesBAPRequest(uiApp, "Bulk Add Parameters");
                        break;
                    case RequestId.adminFamiliesBRP:
                        Tools.AdminFamiliesBRPRequest adminFamiliesBRPRequest = new Tools.AdminFamiliesBRPRequest(uiApp, "Bulk Remove Parameters");
                        break;
                    case RequestId.testApp:
                        Tools.AdminSandboxSetPreviewHost adminSandboxSetPreviewHost = new Tools.AdminSandboxSetPreviewHost(uiApp, "testapp");
                        break;

                    default:
                        break;
                }
            }
            finally
            {
                Application.thisApp.WakeFormUp();
            }
            return;
        }
    } 
}