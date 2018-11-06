using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using RVTApplication = Autodesk.Revit.ApplicationServices.Application;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools
{
    public enum RequestId : int
    {
        None = 0,

        multiCatCFFE1 = ReferencedSwitchCaseIds.multiCatCFFE1,
        multiCatCFFE2 = ReferencedSwitchCaseIds.multiCatCFFE2,
        electricalCEOE = ReferencedSwitchCaseIds.electricalCEOE,
        floorsCFBR = ReferencedSwitchCaseIds.floorsCFBR,
        materialsCMS = ReferencedSwitchCaseIds.materialsCMS,
        materialsAML = ReferencedSwitchCaseIds.materialsAML,
        materialsAMLPalette = ReferencedSwitchCaseIds.materialsAMLPalette,
        roomsSRNN = ReferencedSwitchCaseIds.roomsSRNN,
        roomsCDRT = ReferencedSwitchCaseIds.roomsCDRT,
        wallsMPW = ReferencedSwitchCaseIds.wallsMPW,
        wallsDP = ReferencedSwitchCaseIds.wallsDP,

        sheetsCSL = ReferencedSwitchCaseIds.sheetsCSL,
        sheetsISFL = ReferencedSwitchCaseIds.sheetsISFL,
        sheetsCSSFS = ReferencedSwitchCaseIds.sheetsCSSFS,
        sheetsOSS = ReferencedSwitchCaseIds.sheetsOSS1,
        sheetSOSSNewSet = ReferencedSwitchCaseIds.sheetsOSS2,
        viewsCEPR = ReferencedSwitchCaseIds.viewsCEPR,
        viewsOICB = ReferencedSwitchCaseIds.viewsOICB,
        viewsHNIEC = ReferencedSwitchCaseIds.viewsHNIEC,

        dataEPI = ReferencedSwitchCaseIds.dataEPI,        
        documentsCTS = ReferencedSwitchCaseIds.documentsCTS,
        miscEDV = ReferencedSwitchCaseIds.miscEDV,

        qaqcCSVN = ReferencedSwitchCaseIds.qaqcCSVN,
        qaqcDRNP = ReferencedSwitchCaseIds.qaqcDRNP,
        qaqcCSV = ReferencedSwitchCaseIds.qaqcCSV,
        qaqcRLS = ReferencedSwitchCaseIds.qaqcRLS,
        qaqcRFSP = ReferencedSwitchCaseIds.qaqcRFSP,
        setupCWS = ReferencedSwitchCaseIds.setupCWS,
        setupUP = ReferencedSwitchCaseIds.setupUP,        
        
        adminDataGFF = ReferencedSwitchCaseIds.adminDataGFF,
        adminFamiliesUF = ReferencedSwitchCaseIds.adminFamiliesUF,
        adminFamiliesBAP = ReferencedSwitchCaseIds.adminFamiliesBAP,
        adminFamiliesBRP = ReferencedSwitchCaseIds.adminFamiliesBRP,

        testApp = ReferencedSwitchCaseIds.testApp,
    }
    
    public class Requests
    {
        private int m_request = (int)RequestId.None;
        public RequestId Take()
        {
            return (RequestId)Interlocked.Exchange(ref m_request, (int)RequestId.None);
        }
        public void Make(RequestId request)
        {
            Interlocked.Exchange(ref m_request, (int)request);
        }
    }
}
