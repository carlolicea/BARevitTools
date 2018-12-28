using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class MaterialsCMSLoadFamilyRequest
    {
        public MaterialsCMSLoadFamilyRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Get version of the family file used for the ID Material Schedule symbol that matches the version of Revit running
            string familyFile = Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule;
            string versionedFamilyFile = "";
            try
            {
                versionedFamilyFile = RVTOperations.GetVersionedFamilyFilePath(uiApp, familyFile);
            }
            catch
            {
                //But if that fails, just take the original version and upgrade it
                versionedFamilyFile = familyFile;
            }
            using (Transaction t1 = new Transaction(doc, "LoadFamily"))
            {
                t1.Start();
                uiApp.ActiveUIDocument.Document.LoadFamily(versionedFamilyFile, out Family loadedFamily);
                Application.thisApp.newMainUi.materialsCMSFamilyToUse = loadedFamily;
                t1.Commit();
            }           
        }
    }
}
