using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class SheetsISFLRequest
    {
        public SheetsISFLRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            Transaction t1 = new Transaction(uidoc.Document, "InsertSheetsFromLink");
            t1.Start();
            foreach (DataGridViewRow row in uiForm.sheetsISFLDataGridView.Rows)
            {
                if (row.Cells["To Add"].Value != null)
                {
                    if (row.Cells["To Add"].Value.ToString() == "True" && row.Cells["Pre-exists"].Value.ToString() == "True")
                    {
                        string sheetToDelete = row.Cells["Sheet Number"].Value.ToString();
                        IList<Element> sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
                        foreach (Element elem in sheetsCollector)
                        {
                            ViewSheet viewSheet = elem as ViewSheet;
                            if (viewSheet.SheetNumber == sheetToDelete && viewSheet.IsPlaceholder == true)
                            {
                                try
                                {
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
                    if (row.Cells["To Add"].Value.ToString() == "True")
                    {
                        try
                        {
                            ViewSheet newSheet = ViewSheet.CreatePlaceholder(uidoc.Document);
                            newSheet.SheetNumber = row.Cells["Sheet Number"].Value.ToString();
                            if (row.Cells["Host Sheet Name"].Value.ToString() == "" || row.Cells["Host Sheet Name"].Value.ToString() == "Sheet")
                            {
                                newSheet.Name = row.Cells["Link Sheet Name"].Value.ToString();
                            }
                            else { newSheet.Name = row.Cells["Host Sheet Name"].Value.ToString(); }
                            IList<Parameter> disciplineParameters = newSheet.GetParameters("BA Sheet Discipline");
                            foreach (Parameter param in disciplineParameters)
                            {
                                try
                                {
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
            RVTDocument linkDoc = uiForm.SheetsISFLGetLinkDoc();
            uiForm.SheetsISFLUpdateDataGridView(linkDoc);
        }
    }
}
