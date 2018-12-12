using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARevitTools
{
    class ReferencedSwitchCaseIds
    {
        //
        //The current last number used for switch case IDs
        private const int currentnumber = 037;

        //Multicategory Create Family From Excel
        public const int multiCatCFFE1 = 001;
        public const int multiCatCFFE2 = 002;
        //Electrical Correct Electrical Outlet Elevation
        public const int electricalCEOE = 035;
        //Floors Create From Room Boundary
        public const int floorsCFBR = 003;
        //Materials Create Material Symbols
        public const int materialsCMS = 004;
        //Materials Accent Material Lines
        public const int materialsAML = 005;
        public const int materialsAMLPalette = 030;
        //Rooms Swap Room Name Number
        public const int roomsSRNN = 006;
        //Rooms Demo Room Symbols
        public const int roomsCDRT = 034;
        //Walls Make Perimeter Walls
        public const int wallsMPW = 007;
        //Walls Delete Parts
        public const int wallsDP = 008;
        //Sheets Copy Sheet Legends
        public const int sheetsCSL = 009;
        //Sheets Insert Sheets From Link
        public const int sheetsISFL = 010;
        //Sheets Create Sheet Set From Schedule
        public const int sheetsCSSFS = 011;
        //Sheets Organize Sheet Sets
        public const int sheetsOSS1 = 012;
        public const int sheetsOSS2 = 013;
        //Views Create Elevations Per Room
        public const int viewsCEPR = 014;
        //Views Override Interior Crop Boundary
        public const int viewsOICB = 015;
        //Views Hide Non Interior Elevation Crop
        public const int viewsHNIEC = 016;
        //Data Export Plan Image
        public const int dataEPI = 017;
        //Documents Convert Text Size
        public const int documentsCTS = 018;
        //Misc Export Drafting Views
        public const int miscEDV = 019;
        //QAQC Capitalize Sheet View Names
        public const int qaqcCSVN = 020;
        //QAQC Delete Rooms Not Placed 
        public const int qaqcDRNP = 021;
        //QAQC Capitalize Sheet Values
        public const int qaqcCSV = 022;
        //QAQC Replace Lines Styles
        public const int qaqcRLS = 023;
        //QAQC Remove Family Shared Parameters
        public const int qaqcRFSP = 031;
        //Setup Create Worksets
        public const int setupCWS = 024;
        //Setup Upgrade Project
        public const int setupUP = 025;
        //Admin Get Family Files
        public const int adminDataGFF = 026;
        //Admin Get BA Details
        public const int adminDataGBDV = 033;
        //Admin Upgrade Families
        public const int adminFamiliesUF = 036;
        //Admin Bulk Add Parameters
        public const int adminFamiliesBAP = 027;
        //Admin Bulk Remove Parameters
        public const int adminFamiliesBRP = 028;
        //Admin Delete Family Backups
        public const int adminFamiliesDFB = 029;
        //Admin Update Family Version Parameter
        public const int adminFamiliesUFVP = 037;
    }
}
