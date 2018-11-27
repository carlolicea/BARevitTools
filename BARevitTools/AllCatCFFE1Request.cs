using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests.ToolRequests
{
    class AllCatCFFE1Request
    {
        public AllCatCFFE1Request(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.ToolRequests.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataTable dt = new DataTable();
            DataGridView dgv = uiForm.multiCatCFFEExcelDGV;
            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, Application.thisApp.newMainUi.multiCatSelectedFamilyFile);
            FamilyManager famMan = famDoc.FamilyManager;
            FamilyParameterSet famParamSet = famMan.Parameters;

            DataColumn paramSelectColumn = dt.Columns.Add("Parameter Select", typeof(Boolean));
            DataColumn parameterNameColumn = dt.Columns.Add("Parameter Name", typeof(String));
            DataColumn parameterGroupColumn = dt.Columns.Add("Parameter Group", typeof(String));
            DataColumn parameterTypeColumn = dt.Columns.Add("Parameter Type", typeof(String));
            DataColumn parameterStorageTypeColumn = dt.Columns.Add("Parameter Storage Type", typeof(String));

            foreach (FamilyParameter famParam in famParamSet)
            {
                string paramName = famParam.Definition.Name;
                string paramGroup = RVTOperations.GetNameFromBuiltInParameterGroup(famParam.Definition.ParameterGroup);
                string paramType = famParam.Definition.ParameterType.ToString();
                string paramStorageType = famParam.StorageType.ToString();
                if (paramStorageType.ToString() != "ElementId" && famParam.IsDeterminedByFormula == false && famParam.Definition.ParameterType != ParameterType.Invalid)
                {
                    DataRow row = dt.NewRow();
                    row["Parameter Select"] = false;
                    row["Parameter Name"] = paramName;
                    row["Parameter Group"] = paramGroup;
                    row["Parameter Type"] = paramType;
                    row["Parameter Storage Type"] = paramStorageType;
                    dt.Rows.Add(row);
                }
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dgv.DataSource = bs;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns["Parameter Select"].Width = 45;
            dgv.Columns["Parameter Select"].HeaderText = "Select";
            dgv.Columns["Parameter Name"].Width = 125;
            dgv.Columns["Parameter Name"].ReadOnly = true;
            dgv.Columns["Parameter Name"].HeaderText = "Name";
            dgv.Columns["Parameter Group"].Width = 75;
            dgv.Columns["Parameter Group"].ReadOnly = true;
            dgv.Columns["Parameter Group"].HeaderText = "Group";
            dgv.Columns["Parameter Type"].Width = 100;
            dgv.Columns["Parameter Type"].ReadOnly = true;
            dgv.Columns["Parameter Type"].HeaderText = "Param Type";
            dgv.Columns["Parameter Storage Type"].Width = 100;
            dgv.Columns["Parameter Storage Type"].ReadOnly = true;
            dgv.Columns["Parameter Storage Type"].HeaderText = "Data Format";

            dgv.Sort(dgv.Columns["Parameter Name"], ListSortDirection.Ascending);
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            famDoc.Close(false);
        }
    }
}
