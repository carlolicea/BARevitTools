using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Insert Sheets From Links tool
    class SheetsISFLRequest
    {
        public SheetsISFLRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            //Start a transaction
            Transaction t1 = new Transaction(uidoc.Document, "InsertSheetsFromLink");
            t1.Start();
            //Cycle through each row in the DataGridView
            foreach (DataGridViewRow row in uiForm.sheetsISFLDataGridView.Rows)
            {
                if (row.Cells["To Add"].Value != null)
                {
                    //If the checkbox to add the sheet is checked, and the sheet already exists
                    if (row.Cells["To Add"].Value.ToString() == "True" && row.Cells["Pre-exists"].Value.ToString() == "True")
                    {
                        //Get the sheet number of the old sheet
                        string sheetToDelete = row.Cells["Sheet Number"].Value.ToString();
                        //Collect the sheets in the project
                        IList<Element> sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
                        foreach (Element elem in sheetsCollector)
                        {
                            ViewSheet viewSheet = elem as ViewSheet;
                            //If the sheet number of the sheet to delete matches the sheet being evaluated, and the sheet being evaluated is a placeholder, continue
                            //It is important that the sheet is placeholder and not a sheet that could potentially have views on it
                            if (viewSheet.SheetNumber == sheetToDelete && viewSheet.IsPlaceholder == true)
                            {
                                try
                                {
                                    //Use a subtransaction to delete the sheet view
                                    SubTransaction deleteTransaction = new SubTransaction(uidoc.Document);
                                    deleteTransaction.Start();
                                    uidoc.Document.Delete(viewSheet.Id);
                                    deleteTransaction.Commit();
                                }
                                catch { continue; }
                            }
                            else { continue; }
                        }
                    }
                    //Otherwise, if the sheet does not already exist, continue
                    if (row.Cells["To Add"].Value.ToString() == "True")
                    {
                        try
                        {
                            //Create a new placeholder sheet
                            ViewSheet newSheet = ViewSheet.CreatePlaceholder(uidoc.Document);
                            newSheet.SheetNumber = row.Cells["Sheet Number"].Value.ToString();
                            //Set the new placeholder sheet's name 
                            if (row.Cells["Host Sheet Name"].Value.ToString() == "" || row.Cells["Host Sheet Name"].Value.ToString() == "Sheet")
                            {
                                newSheet.Name = row.Cells["Link Sheet Name"].Value.ToString();
                            }
                            else { newSheet.Name = row.Cells["Host Sheet Name"].Value.ToString(); }
                            //Get the list of sheet parameters and find the BA Sheet Discipline parameter
                            IList<Parameter> disciplineParameters = newSheet.GetParameters(Properties.Settings.Default.BASheetDisciplineParameter);
                            foreach (Parameter param in disciplineParameters)
                            {
                                try
                                {
                                    //Set the BA Sheet Discipline from the value in the DataGridView
                                    param.Set(row.Cells["Discipline"].Value.ToString());
                                }
                                catch { continue; }
                            }
                        }
                        catch { continue; }
                    }
                    else { continue; }
                }
                else { continue; }
            }
            t1.Commit();
            //Update the DataGridView with fresh data using the inserted sheets and sheets from the link
            RVTDocument linkDoc = uiForm.SheetsISFLGetLinkDoc();
            uiForm.SheetsISFLUpdateDataGridView(linkDoc);
        }
    }
}
