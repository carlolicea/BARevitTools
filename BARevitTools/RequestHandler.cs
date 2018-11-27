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
                        ToolRequests.AllCatCFFE1Request allCatCFFE1Request = new ToolRequests.AllCatCFFE1Request(uiApp, "Get Parameters");
                        break;
                    case RequestId.multiCatCFFE2:
                        ToolRequests.AllCatCFFE2Request allCatCFFE2Request = new ToolRequests.AllCatCFFE2Request(uiApp, "Make Families");
                        break;
                    case RequestId.electricalCEOE:
                        ToolRequests.ElectricalCEORequest electricalCEORequest = new ToolRequests.ElectricalCEORequest(uiApp, "Correct Electrical Outlet Elevation");
                        break;
                    case RequestId.floorsCFBR:
                        ToolRequests.FloorsCFBRRequest floorsCFBRRequest = new ToolRequests.FloorsCFBRRequest(uiApp, "Create Floors by Room");
                        break;
                    case RequestId.materialsCMS:
                        ToolRequests.MaterialsCMSRequest materialsCMSRequest = new ToolRequests.MaterialsCMSRequest(uiApp, "Create Material Symbols");
                        break;
                    case RequestId.materialsAML:
                        ToolRequests.MaterialsAMLRequest materialsAMLRequest = new ToolRequests.MaterialsAMLRequest(uiApp, "Accent Material Lines");
                        break;
                    case RequestId.materialsAMLPalette:
                        ToolRequests.MaterialsAMLPaletteRequest materialsAMLPaletteRequest = new ToolRequests.MaterialsAMLPaletteRequest(uiApp, "Accent Material Lines Palette");
                        break;
                    case RequestId.roomsSRNN:
                        ToolRequests.RoomsSRNNRequest roomsSRNNRequest = new ToolRequests.RoomsSRNNRequest(uiApp, "Swap Room Names and Numbers");
                        break;
                    case RequestId.roomsCDRT:
                        ToolRequests.RoomsCDRTRequest roomsCDRTRequest = new ToolRequests.RoomsCDRTRequest(uiApp, "Create Demo Room Tags");
                        break;
                    case RequestId.wallsMPW:
                        ToolRequests.WallsMPWRequest wallsMPWRequest = new ToolRequests.WallsMPWRequest(uiApp, "Make Perimeter Walls");
                        break;
                    case RequestId.wallsDP:
                        ToolRequests.WallsDPRequest wallsDPRequest = new ToolRequests.WallsDPRequest(uiApp, "Delete Wall Parts");
                        break;
                    case RequestId.sheetsCSL:
                        ToolRequests.SheetsCSLRequest sheetsCSLReqeuset = new ToolRequests.SheetsCSLRequest(uiApp, "Copy Sheet Legends to Sheets");
                        break;
                    case RequestId.sheetsISFL:
                        ToolRequests.SheetsISFLRequest sheetsISFLRequest = new ToolRequests.SheetsISFLRequest(uiApp, "Insert sheets from link");
                        break;
                    case RequestId.sheetsCSSFS:
                        ToolRequests.SheetsCSSFRequest sheetsCSSFRequest = new ToolRequests.SheetsCSSFRequest(uiApp, "Create Sheet Set from Schedule");
                        break;
                    case RequestId.sheetsOSS:
                        ToolRequests.SheetsOSSRequest sheetsOSSRequest = new ToolRequests.SheetsOSSRequest(uiApp, "Organize Sheet Set");
                        break;
                    case RequestId.sheetSOSSNewSet:
                        ToolRequests.SheetsOSSNewSetRequest sheetsOSSNewSetRequest = new ToolRequests.SheetsOSSNewSetRequest(uiApp, "Make New Set");
                        break;
                    case RequestId.viewsCEPR:
                        ToolRequests.ViewsCEPRRequest viewsCEPRRequest = new ToolRequests.ViewsCEPRRequest(uiApp, "Create Elevations Per Room");
                        break;
                    case RequestId.viewsOICB:
                        ToolRequests.ViewsOICBRequest viewsOICBRequest = new ToolRequests.ViewsOICBRequest(uiApp, "Override Interior Elevation Crop Boundaries");
                        break;
                    case RequestId.viewsHNIEC:
                        ToolRequests.ViewsHNIECRequest viewsHNIECRequest = new ToolRequests.ViewsHNIECRequest(uiApp, "Hide Non Interior Elevation Crops");
                        break;
                    case RequestId.dataEPI:
                        ToolRequests.DataEPIRequest dataEPIRequest = new ToolRequests.DataEPIRequest(uiApp, "Export Plan Image");
                        break;
                    case RequestId.miscEDV:
                        ToolRequests.MiscEDVRequest miscEDVRequest = new ToolRequests.MiscEDVRequest(uiApp, "Export Drafting Views");
                        break;
                    case RequestId.documentsCTS:
                        ToolRequests.DocumentsCTSRequest documentsCTSRequest = new ToolRequests.DocumentsCTSRequest(uiApp, "Change Text Scale");
                        break;
                    case RequestId.qaqcCSVN:
                        ToolRequests.QaqcCSVNRequest qaqcCSVNRequest = new ToolRequests.QaqcCSVNRequest(uiApp, "Capitalize Sheet and View Names");
                        break;
                    case RequestId.qaqcDRNP:
                        ToolRequests.QaqcDRNPRequest qaqcDRNPRequest = new ToolRequests.QaqcDRNPRequest(uiApp, "Delete Rooms Not Placed");
                        break;
                    case RequestId.qaqcCSV:
                        ToolRequests.QaqcCSVRequest qaqcCSVRequest= new ToolRequests.QaqcCSVRequest(uiApp, "Capitalize Sheet Values");
                        break;
                    case RequestId.qaqcRLS:
                        ToolRequests.QaqcRLSRequest qaqcRLSRequest = new ToolRequests.QaqcRLSRequest(uiApp, "Remove Line Styles");
                        break;
                    case RequestId.qaqcRFSP:
                        ToolRequests.QaqcRFSPRequest qaqcRFSPRequest = new ToolRequests.QaqcRFSPRequest(uiApp, "Remove Family Shared Parameters");
                        break;
                    case RequestId.setupCWS:
                        ToolRequests.SetupCWSRequest setupCWSRequest = new ToolRequests.SetupCWSRequest(uiApp, "Create Worksets");
                        break;
                    case RequestId.setupUP:
                        ToolRequests.SetupUPRequest setupUPRequest = new ToolRequests.SetupUPRequest(uiApp, "Upgrade Project");
                        break;
                    case RequestId.adminDataGFF:
                        ToolRequests.AdminDataGFFRequest adminDataGFFRequest = new ToolRequests.AdminDataGFFRequest(uiApp, "Get Family Data");
                        break;
                    case RequestId.adminFamiliesUF:
                        ToolRequests.AdminFamiliesUFRequest adminFamiliesUFRequest = new ToolRequests.AdminFamiliesUFRequest(uiApp, "Upgrade Families");
                        break;
                    case RequestId.adminFamiliesBAP:
                        ToolRequests.AdminFamiliesBAPRequest adminFamiliesBAPRequest = new ToolRequests.AdminFamiliesBAPRequest(uiApp, "Bulk Add Parameters");
                        break;
                    case RequestId.adminFamiliesBRP:
                        ToolRequests.AdminFamiliesBRPRequest adminFamiliesBRPRequest = new ToolRequests.AdminFamiliesBRPRequest(uiApp, "Bulk Remove Parameters");
                        break;
                    case RequestId.testApp:
                        ToolRequests.AdminSandboxSetPreviewHost adminSandboxSetPreviewHost = new ToolRequests.AdminSandboxSetPreviewHost(uiApp, "testapp");
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