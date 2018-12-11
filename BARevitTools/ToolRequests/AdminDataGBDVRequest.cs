using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class AdminDataGBDVRequest
    {
        public AdminDataGBDVRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataTable dt = new DataTable();
            uiForm.adminDataGBDVWaitLabel.Text = "Please Wait...";
            uiForm.adminDataGBDVWaitLabel.Visible = true;

            string detailVersion = RVTOperations.GetRevitNumber(BARevitTools.Properties.Settings.Default.RevitProjectBADetails).ToString();
            string detailSubVersion = detailVersion.Substring(detailVersion.Length - 2);
            string activeSubVersion = BARevitTools.Properties.Settings.Default.BARTRevitFamilyCurrentYear.Substring(BARevitTools.Properties.Settings.Default.BARTRevitFamilyCurrentYear.Length - 2);
            //Get the appropriate BA Details file by version number
            string detailsFile = BARevitTools.Properties.Settings.Default.RevitProjectBADetails.Replace(detailSubVersion, activeSubVersion);

            dt = new DataTable();
            DataColumn categoryColumn =dt.Columns.Add("Category", typeof(String)); //View type
            DataColumn divisionSortColumn =dt.Columns.Add("Division", typeof(String)); //BA View Sort 1 Division
            DataColumn typeSortColumn =dt.Columns.Add("Type", typeof(String)); //BA View Sort 2 Type
            DataColumn nameColumn =dt.Columns.Add("Name", typeof(String)); //View name

            RVTDocument detailsDoc = RVTOperations.OpenRevitFile(uiApp, detailsFile);
            List<ViewDrafting> viewsCollection = new FilteredElementCollector(detailsDoc).OfClass(typeof(ViewDrafting)).WhereElementIsNotElementType().Cast<ViewDrafting>().ToList();
            List<ViewSheet> sheetsCollection = new FilteredElementCollector(detailsDoc).OfClass(typeof(ViewSheet)).WhereElementIsNotElementType().Cast<ViewSheet>().ToList();

            //Order the views by division, type, and name
            var viewsGroupedQuery =
                from viewElem in viewsCollection
                orderby viewElem.GetParameters("BA View Sort 1 Division").First().ToString(), viewElem.GetParameters("BA View Sort 2 Type").First().ToString(), viewElem.Name
                select viewElem;

            //Fill out the DataTable
            foreach (ViewDrafting viewDrafting in viewsGroupedQuery)
            {
                DataRow row =dt.NewRow();
                row["Category"] = "View";
                row["Division"] = viewDrafting.GetParameters("BA View Sort 1 Division").First().AsString();
                row["Type"] = viewDrafting.GetParameters("BA View Sort 2 Type").First().AsString();
                row["Name"] = viewDrafting.Name;
               dt.Rows.Add(row);
            }

            //Order the sheets by discipline, division, and name
            var sheetsGroupedQuery =
                from sheetElem in sheetsCollection
                orderby sheetElem.GetParameters("BA Sheet Discipline").First().AsString(), sheetElem.GetParameters("BA Sheet Division").First().AsString(), sheetElem.Name
                select sheetElem;

            //Add the sheets to the DataTable
            foreach (ViewSheet viewSheet in sheetsGroupedQuery)
            {
                DataRow row =dt.NewRow();
                row["Category"] = "Sheet";
                row["Division"] = viewSheet.GetParameters("BA Sheet Discipline").First().AsString();
                row["Type"] = viewSheet.GetParameters("BA Sheet Division").First().AsString();
                row["Name"] = viewSheet.Name;
               dt.Rows.Add(row);
            }

            uiForm.adminDataGBDVWaitLabel.Text = "Done!";
            detailsDoc.Close(false);

            uiForm.adminDataGBDVDataTable = dt;
        }
    }
}
