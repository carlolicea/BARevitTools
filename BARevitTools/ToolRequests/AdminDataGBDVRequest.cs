using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class and constructor is responsible for collecting the detail and sheet views in the BA Details file saved in the active version of Revit. 
    //Thus, this needs to be invoked when a BA Details A## has been made in the version of the currently running Revit.
    class AdminDataGBDVRequest
    {
        public AdminDataGBDVRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataTable dt = new DataTable();
            uiForm.adminDataGBDVWaitLabel.Text = "Please Wait...";
            uiForm.adminDataGBDVWaitLabel.Visible = true;

            //Begin by getting the Revit version of the BA Details file in the BART properties. This should be lowest supported BART version
            string detailVersion = RVTOperations.GetRevitNumber(BARevitTools.Properties.Settings.Default.RevitProjectBADetails).ToString();
            //Get the last two digits for the year of the BA Details Revit version
            string detailSubVersion = detailVersion.Substring(detailVersion.Length - 2);
            //Get the version of Revit running and then get the last two digits
            string activeSubVersion = uiApp.Application.VersionNumber.Substring(uiApp.Application.VersionNumber.Length - 2);
            //Get the appropriate BA Details file by version number. This only works if the files are named with the A## suffix
            string detailsFile = BARevitTools.Properties.Settings.Default.RevitProjectBADetails.Replace(detailSubVersion, activeSubVersion);

            //Create a new DataTable to collect data.
            dt = new DataTable();
            DataColumn categoryColumn =dt.Columns.Add("Category", typeof(String)); //View type
            DataColumn divisionSortColumn =dt.Columns.Add("Division", typeof(String)); //BA View Sort 1 Division
            DataColumn typeSortColumn =dt.Columns.Add("Type", typeof(String)); //BA View Sort 2 Type
            DataColumn nameColumn =dt.Columns.Add("Name", typeof(String)); //View name

            //Try to open the details file saved in the running version of Revit.
            RVTDocument detailsDoc = null;
            try
            {
                //Open the BA Details file
                detailsDoc = RVTOperations.OpenRevitFile(uiApp, detailsFile);
            }
            catch
            {
                //Assuming the file could not be opened because it does not exist at the expected location, prompt the user to select it.
                MessageBox.Show(String.Format("Could not load the {0} file. Please select the BA Details file to use in the following dialog.", detailsFile));
                try
                {
                    //Generate the file selection dialog
                    string filePath = GeneralOperations.GetFile();
                    detailsDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                }
                catch {; }
            }
            
            //Assuming the BA Details was opened, continue
            if (detailsDoc != null)
            {
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
                    DataRow row = dt.NewRow();
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
                    DataRow row = dt.NewRow();
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
}
