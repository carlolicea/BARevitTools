using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.Tools
{
    class AllCatCFFE
    {
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;
        private UIApplication uiApp;

        public void AllCatCFFE1(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
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
        public void AllCatCFFE2(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.multiCatCFFEFamiliesProgressBar.Value = 0;
            string saveDirectory = uiForm.multiCatCFFEFamilySaveLocation;
            DataGridView dgv = uiForm.multiCatCFFEFamiliesDGV;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 1;
            saveAsOptions.OverwriteExistingFile = true;

            string familyFileToUse = uiForm.multiCatCFFEFamilyFileToUse;
            string versionedFamilyFile = RVTOperations.GetVersionedFamilyFilePath(uiApp, familyFileToUse);

            if (versionedFamilyFile != "" && File.Exists(versionedFamilyFile) && uiForm.multiCatCFFEFamilySaveLocation != "" && uiForm.multiCatCFFEFamiliesDGV.Rows.Count != 0 && uiForm.multiCatCFFEFamilyCreationComboBox.Text != "<Select Creation Method>")
            {
                AllCatCFFECreateFamilyTypesFromTable(uiApp, uiForm, saveDirectory, dgv, saveAsOptions, versionedFamilyFile);
            }
            else if (uiForm.multiCatCFFEFamilySaveLocation == "")
            {
                MessageBox.Show("No save directory selected");
            }
            else if (uiForm.multiCatCFFEFamilyCreationComboBox.Text == "<Select Creation Method>")
            {
                MessageBox.Show("Please select a creation method");
            }
            else
            {
                MessageBox.Show("No families could be made from the data table");
            }
        }
        private static void AllCatCFFECreateFamilyTypesFromTable(UIApplication uiApp, MainUI uiForm, string saveDirectory, DataGridView dgv, SaveAsOptions saveAsOptions, string familyFileToUse)
        {
            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFileToUse);

            FamilyManager famMan = famDoc.FamilyManager;
            RVTOperations.DeleteFamilyTypes(famDoc, famMan);
            string tempFamilyPath = saveDirectory + "\\" + String.Format(famDoc.Title).Replace(".rfa", "") + "_temp.rfa";
            famDoc.SaveAs(tempFamilyPath, saveAsOptions);
            famDoc.Close();

            RVTDocument newFamDoc = RVTOperations.OpenRevitFile(uiApp, tempFamilyPath);
            FamilyManager newFamMan = newFamDoc.FamilyManager;
            FamilyParameterSet parameters = newFamMan.Parameters;
            Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
            foreach (FamilyParameter param in parameters)
            {
                famParamDict.Add(param.Definition.Name, param);
            }
            int rowsCount = dgv.Rows.Count;
            int columnsCount = dgv.Columns.Count;

            List<string> familyTypesMade = new List<string>();
            if (uiForm.multiCatCFFEFamilyCreationComboBox.SelectedItem.ToString() == "Combine Types (1 File)")
            {
                uiForm.multiCatCFFEFamiliesProgressBar.Minimum = 0;
                uiForm.multiCatCFFEFamiliesProgressBar.Maximum = (rowsCount - 1) * (columnsCount - 1);
                uiForm.multiCatCFFEFamiliesProgressBar.Step = 1;
                uiForm.multiCatCFFEFamiliesProgressBar.Visible = true;
                Transaction t2 = new Transaction(newFamDoc, "MakeNewTypes");
                t2.Start();
                for (int i = 1; i < rowsCount; i++)
                {
                    string newTypeName = dgv.Rows[i].Cells[0].Value.ToString();
                    Dictionary<string, FamilyType> existingTypeNames = RVTOperations.GetFamilyTypeNames(newFamMan);
                    if (!existingTypeNames.Keys.Contains(newTypeName))
                    {
                        FamilyType newType = newFamMan.NewType(newTypeName);
                        newFamMan.CurrentType = newType;
                        familyTypesMade.Add(newType.Name);
                    }
                    else
                    {
                        newFamMan.CurrentType = existingTypeNames[newTypeName];
                        familyTypesMade.Add(newFamMan.CurrentType.Name);
                    }

                    for (int j = 1; j < columnsCount; j++)
                    {
                        string paramName = dgv.Columns[j].HeaderText;
                        string paramStorageTypeString = dgv.Rows[0].Cells[j].Value.ToString();
                        var paramValue = dgv.Rows[i].Cells[j].Value;
                        if (paramValue.ToString() != "")
                        {
                            FamilyParameter param = famParamDict[paramName];
                            ParameterType paramType = param.Definition.ParameterType;
                            RVTOperations.SetFamilyParameterValue(newFamMan, param, paramType, paramStorageTypeString, paramValue, true);
                        }
                        uiForm.multiCatCFFEFamiliesProgressBar.PerformStep();
                    }
                }
                t2.Commit();
                Transaction t3 = new Transaction(newFamDoc, "DeleteOldTypes");
                t3.Start();
                foreach (FamilyType type in newFamMan.Types)
                {
                    if (!familyTypesMade.Contains(type.Name))
                    {
                        newFamMan.CurrentType = type;
                        newFamMan.DeleteCurrentType();
                    }
                }
                t3.Commit();
                newFamDoc.SaveAs(saveDirectory + "\\" + String.Format(newFamDoc.Title).Replace("_temp", ""), saveAsOptions);
                newFamDoc.Close();
            }

            else if (uiForm.multiCatCFFEFamilyCreationComboBox.SelectedItem.ToString() == "1 Family Per Type (Multiple Files)")
            {
                uiForm.multiCatCFFEFamiliesProgressBar.Minimum = 0;
                uiForm.multiCatCFFEFamiliesProgressBar.Maximum = rowsCount - 1;
                uiForm.multiCatCFFEFamiliesProgressBar.Step = 1;
                uiForm.multiCatCFFEFamiliesProgressBar.Visible = true;
                for (int i = 1; i < rowsCount; i++)
                {
                    Transaction t2 = new Transaction(newFamDoc, "MakeNewTypes");
                    t2.Start();
                    FamilyType newType = newFamMan.NewType(dgv.Rows[i].Cells[0].Value.ToString());
                    string saveName = GeneralOperations.CleanFileName(newType.Name);
                    if (saveName != "")
                    {
                        newFamMan.CurrentType = newType;
                        for (int j = 1; j < columnsCount; j++)
                        {
                            string paramName = dgv.Columns[j].HeaderText;
                            string paramStorageTypeString = dgv.Rows[0].Cells[j].Value.ToString();
                            var paramValue = dgv.Rows[i].Cells[j].Value;
                            if (paramValue.ToString() != "")
                            {
                                FamilyParameter param = famParamDict[paramName];
                                ParameterType paramType = param.Definition.ParameterType;
                                RVTOperations.SetFamilyParameterValue(newFamMan, param, paramType, paramStorageTypeString, paramValue, true);
                            }
                        }
                        t2.Commit();

                        Transaction t3 = new Transaction(newFamDoc, "DeleteOldTypes");
                        t3.Start();
                        foreach (FamilyType type in newFamMan.Types)
                        {
                            newFamMan.CurrentType = type;
                            if (newFamMan.CurrentType.Name != newType.Name)
                            {
                                newFamMan.DeleteCurrentType();
                            }
                        }
                        t3.Commit();
                        newFamDoc.SaveAs(saveDirectory + "\\" + saveName + ".rfa", saveAsOptions);
                        uiForm.multiCatCFFEFamiliesProgressBar.PerformStep();
                    }
                }
                newFamDoc.Close();
            }
            else { MessageBox.Show("No Creation Method was selected"); }

            File.Delete(tempFamilyPath);
            List<string> backupFiles = GeneralOperations.GetAllRvtBackupFamilies(uiForm.multiCatCFFEFamilySaveLocation);
            foreach (string path in backupFiles)
            {
                File.Delete(path);
            }

        }
    }
}
