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
                #region Switch Cases
                switch (Request.Take())
                {
                    case RequestId.None:
                        {return;}
                    case RequestId.multiCatCFFE1:
                        AllCatCFFE1(uiApp, "Get Parameters");
                        break;
                    case RequestId.multiCatCFFE2:
                        AllCatCFFE2(uiApp, "Make Families");
                        break;
                    case RequestId.electricalCEOE:
                        ElectricalCEOERun(uiApp, "Correct Electrical Outlet Elevation");
                        break;
                    case RequestId.floorsCFBR:
                        FloorsCFBRRun(uiApp, "Create Floors by Room");
                        break;
                    case RequestId.materialsCMS:
                        MaterialsCMSRun(uiApp, "Create Material Symbols");
                        break;
                    case RequestId.materialsAML:
                        MaterialsAMLRun(uiApp, "Accent Material Lines");
                        break;
                    case RequestId.materialsAMLPalette:
                        MaterialsAMLPaletteRun(uiApp, "Accent Material Lines Palette");
                        break;
                    case RequestId.roomsSRNN:
                        RoomsSRNNRun(uiApp, "Swap Room Names and Numbers");
                        break;
                    case RequestId.roomsCDRT:
                        RoomsCDRTRun(uiApp, "Create Demo Room Tags");
                        break;
                    case RequestId.sheetsCSL:
                        SheetsCSLRun(uiApp, "Copy Sheet Legends to Sheets");
                        break;
                    case RequestId.sheetsISFL:
                        SheetsISFLRun(uiApp, "Insert sheets from link");
                        break;
                    case RequestId.sheetsCSSFS:
                        SheetsCSSFSRun(uiApp, "Create Sheet Set from Schedule");
                        break;
                    case RequestId.sheetsOSS:
                        SheetsOSSRun(uiApp, "Organize Sheet Set");
                        break;
                    case RequestId.sheetSOSSNewSet:
                        SheetsOSSNewSetRun(uiApp, "Make New Set");
                        break;
                    case RequestId.wallsMPW:
                        WallsMPWRun(uiApp, "Make Perimeter Walls");
                        break;
                    case RequestId.wallsDP:
                        WallsDPRun(uiApp, "Delete Wall Parts");
                        break;
                    case RequestId.viewsCEPR:
                        ViewsCEPRRun(uiApp, "Create Elevations Per Room");
                        break;
                    case RequestId.viewsOICB:
                        ViewsOICBRun(uiApp, "Override Interior Elevation Crop Boundaries");
                        break;
                    case RequestId.viewsHNIEC:
                        ViewsHNIECRun(uiApp, "Hide Non Interior Elevation Crops");
                        break;
                    case RequestId.dataEPI:
                        DataEPIRun(uiApp, "Export Plan Image");
                        break;
                    case RequestId.miscEDV:
                        MiscEDVRun(uiApp, "Export Drafting Views");
                        break;
                    case RequestId.documentsCTS:
                        DocumentsCTSRun(uiApp, "Change Text Scale");
                        break;
                    case RequestId.qaqcCSVN:
                        QaqcCSVNRun(uiApp, "Capitalize Sheet and View Names");
                        break;
                    case RequestId.qaqcDRNP:
                        QaqcDRNPRun(uiApp, "Delete Rooms Not Placed");
                        break;
                    case RequestId.qaqcCSV:
                        QaqcCSVRun(uiApp, "Capitalize Sheet Values");
                        break;
                    case RequestId.qaqcRLS:
                        QaqcRLSRun(uiApp, "Remove Line Styles");
                        break;
                    case RequestId.qaqcRFSP:
                        QaqcRFSPRun(uiApp, "Remove Family Shared Parameters");
                        break;
                    case RequestId.setupCWS:
                        SetupCWSRun(uiApp, "Create Worksets");
                        break;
                    case RequestId.setupUP:
                        SetupUPRun(uiApp, "Upgrade Project");
                        break;
                    case RequestId.adminDataGFF:
                        AdminDataGFFRun(uiApp, "Get Family Data");
                        break;
                    case RequestId.adminFamiliesUF:
                        AdminFamiliesUFRun(uiApp, "Upgrade Families");
                        break;
                    case RequestId.adminFamiliesBAP:
                        AdminFamiliesBAPRun(uiApp, "Bulk Add Parameters");
                        break;
                    case RequestId.adminFamiliesBRP:
                        AdminFamiliesBRPRun(uiApp, "Bulk Remove Parameters");
                        break;
                    case RequestId.testApp:
                        SetPreviewHost(uiApp, "testapp");
                        break;

                    default:
                        break;
                }
                #endregion Switch Cases
            }
            finally
            {
                Application.thisApp.WakeFormUp();
            }
            return;
        }

        // MODELING TAB
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

            foreach(FamilyParameter famParam in famParamSet)
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

            if (versionedFamilyFile!= "" && File.Exists(versionedFamilyFile) && uiForm.multiCatCFFEFamilySaveLocation != "" && uiForm.multiCatCFFEFamiliesDGV.Rows.Count != 0 && uiForm.multiCatCFFEFamilyCreationComboBox.Text != "<Select Creation Method>")
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
        public void ElectricalCEOERun(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            var elecFixturesCollection = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType().ToElements();
            Transaction t = new Transaction(doc, "CorrectElectricalOutletElevations");
            t.Start();
            try
            {
                foreach (Element elem in elecFixturesCollection)
                {
                    try
                    {
                        Parameter mountingHeightParameter = null;
                        List<Parameter> parameters = elem.Parameters.Cast<Parameter>().ToList();
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            Parameter currentParam = parameters[i];
                            if (currentParam.Definition.Name.ToUpper() == "MOUNTING HEIGHT")
                            {
                                mountingHeightParameter = currentParam;
                                break;
                            }
                        }
                        if (mountingHeightParameter != null)
                        {
                            double originalMountingHeight = mountingHeightParameter.AsDouble();
                            if (originalMountingHeight != 0)
                            {
                                double savedOffset = 0;
                                try
                                {
                                    Parameter offset = elem.GetParameters("Offset").First();
                                    savedOffset = offset.AsDouble();
                                    mountingHeightParameter.Set(savedOffset + originalMountingHeight);
                                    offset.Set(0);
                                }
                                catch
                                {
                                    Parameter elevation = elem.GetParameters("Elevation").First();
                                    savedOffset = elevation.AsDouble();
                                    mountingHeightParameter.Set(savedOffset + originalMountingHeight);
                                    elevation.Set(0);
                                }                                
                            }
                        }                        
                    }
                    catch
                    {continue; }
                }
                t.Commit();
            }
            catch(Exception f)
            {
                t.RollBack();
                MessageBox.Show(f.ToString());
            }
            
        }
        public void FloorsCFBRRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FloorType selectedFloorType = null;

            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            string selectedFloorTypeName = uiForm.floorsCFBRSelectFloorTypeComboBox.Text.ToString();
            List<Room> roomElements = uiForm.floorsCFBRRoomsList;           
            List<FloorType> floorTypes = RVTGetElementsByCollection.DocumentFloorTypes(uiApp);
            List<Floor> newFloors = new List<Floor>();
           
            #region Transactions
            if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                Transaction t1 = new Transaction(uidoc.Document, "CreateFloorsByRoom");
                t1.Start();
                foreach (FloorType floorType in floorTypes)
                {
                    if (floorType.Name.ToString() == selectedFloorTypeName)
                    {
                        selectedFloorType = floorType;
                        break;
                    }
                    else { continue; }
                }
                                
                try
                {
                    Options geomOptions = new Options();
                    geomOptions.IncludeNonVisibleObjects = true;
                    foreach (Room room in roomElements)
                    {
                        MessageBox.Show(room.Id.ToString());
                        IList<CurveLoop> faceCurveLoops = null;
                        Level roomLevel = room.Level;
                        GeometryElement roomGeomElements = room.get_Geometry(geomOptions);
                        Solid roomSolid = null;
                        foreach (GeometryObject geom in roomGeomElements)
                        {
                            if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                            {
                                roomSolid = geom as Solid;
                                break;
                            }
                        }

                        if (roomSolid != null)
                        {
                            FaceArray solidFaces = roomSolid.Faces;
                            foreach (PlanarFace solidFace in solidFaces)
                            {
                                XYZ faceNormal = solidFace.FaceNormal;
                                if (faceNormal.Z == -1)
                                {
                                    faceCurveLoops = solidFace.GetEdgesAsCurveLoops();
                                    break;
                                }
                            }
                        }
                                                
                        if (faceCurveLoops.Count != 0)
                        {
                            try
                            {
                                CurveArray curveArray = new CurveArray();
                                foreach (CurveLoop cloop in faceCurveLoops)
                                {
                                    CurveLoopIterator cLoopIter = cloop.GetCurveLoopIterator();
                                    while (cLoopIter.MoveNext())
                                    {
                                        curveArray.Append(cLoopIter.Current);
                                    }
                                }
                                Floor newFloor = uidoc.Document.Create.NewFloor(curveArray, selectedFloorType, roomLevel, false);
                                newFloors.Add(newFloor);
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("Floor could not be made for {0}, which is likely due to the room having more than one boundary loop. The Revit API only allows for one contiuous loop.", room.Number.ToString()));
                            }                                
                        }
                    }                   
                    t1.Commit();
                }
                catch { t1.RollBack(); }

                if (uiForm.floorsCFBROffsetFinishFloorCheckBox.Checked)
                {
                    Transaction t2 = new Transaction(uidoc.Document, "ElevateFloors");
                    t2.Start();
                    try
                    {
                        foreach (Floor floor in newFloors)
                        {
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement floorGeometry = floor.get_Geometry(geomOptions);
                            BoundingBoxXYZ floorBBox = floorGeometry.GetBoundingBox();
                            double bBoxMinZ = floorBBox.Min.Z;
                            double bBoxMaxZ = floorBBox.Max.Z;
                            double floorThickness = bBoxMaxZ - bBoxMinZ;
                            XYZ translation = new XYZ(0, 0, floorThickness);
                            ElementTransformUtils.MoveElement(uidoc.Document, floor.Id, translation);
                        }
                        t2.Commit();
                    }
                    catch { t2.RollBack(); }
                }
            }
            #endregion Transactions
            uiForm.adminDataGFFElementList = null;
        }
        public void MaterialsCMSRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.materialsCMSExcelDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            uiForm.materialsCMSExcelCreateSymbolsProgressBar.Value = 0;
            int columnCount = dgv.Columns.Count;
            int rowCount = dgv.Rows.Count;

            string familyFile = BARevitTools.Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule;
            string versionedFamilyFile = RVTOperations.GetVersionedFamilyFilePath(uiApp, familyFile);
            if (versionedFamilyFile != "")
            {
                RVTDocument famDoc = RVTOperations.CreateFamilyTypesFromTable(uiApp, uiForm.materialsCMSExcelCreateSymbolsProgressBar, uiForm.materialsCMSExcelDataGridView, versionedFamilyFile);
                ViewDrafting placementView = null;
                var draftingViews = new FilteredElementCollector(doc).OfClass(typeof(ViewDrafting)).WhereElementIsNotElementType().ToElements();
                ViewFamilyType draftingViewType = null;
                try
                {
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().Where(elem => elem.Name == "BA Drafting View").First() as ViewFamilyType;
                }
                catch
                {
                    draftingViewType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).WhereElementIsElementType().ToElements().First() as ViewFamilyType;
                }

                Transaction t = new Transaction(doc, "MakeIDMaterialView");
                t.Start();
                foreach (ViewDrafting view in draftingViews)
                {
                    if (view.Name == "ID Material View" || view.Name == uiForm.materialsCMSSetViewNameTextBox.Text)
                    {
                        doc.Delete(view.Id);
                        doc.Regenerate();
                        break;
                    }
                    else{ continue;}
                }
                placementView = ViewDrafting.Create(doc, draftingViewType.Id);
                placementView.Scale = 1;
                if (uiForm.materialsCMSSetViewNameTextBox.Text != "")
                {
                    placementView.Name = uiForm.materialsCMSSetViewNameTextBox.Text.Replace("{", "").Replace("}", "");
                }
                else
                {
                    placementView.Name = "ID Material View";
                }

                try
                {
                    placementView.GetParameters("BA View Sort 1 Division").First().Set("2 Plans");
                    placementView.GetParameters("BA View Sort 2 Type").First().Set("230 Finish Plans");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                doc.Regenerate();                
                t.Commit();

                RVTOperations.PlaceSymbolsInView(uiApp, famDoc, "ID Use", "Mark", placementView);
            }
        }
        public void MaterialsAMLRun(UIApplication uiApp, String text)
        {

            DataGridView dgv = BARevitTools.Application.thisApp.newMainUi.materialsAMLDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            Dictionary<string, Category> lineStyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in RVTGetElementsByCollection.DocumentLineStyles(uiApp))
            {
                lineStyleDict.Add(lineStyle.Name.Replace("ID ",""), lineStyle);
            }


            ElementId solidPatternId = LinePatternElement.GetSolidPatternId();
            Transaction t1 = new Transaction(doc, "CreateLineStyles");
            t1.Start();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                System.Drawing.Color buttonColor = row.Cells["Color"].Style.BackColor;
                Color revitColor = new Color(buttonColor.R, buttonColor.G, buttonColor.B);

                if (row.Cells["Updated"].Value != null)
                {
                    if (row.Cells["Updated"].Value.ToString() == "True" && lineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()))
                    {                        
                        try
                        {
                            Category lineStyleToUpdate = lineStyleDict[row.Cells["Mark"].Value.ToString()];
                            lineStyleToUpdate.LineColor = revitColor;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        } 
                    }
                }

                if (row.Cells["Select"].Value != null)
                {
                    if (row.Cells["Select"].Value.ToString() == "True" && row.Cells["Mark"].Value.ToString() != "" && !lineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()))
                    {                        
                        try
                        {
                            Category linesCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
                            Category newLineStyleCategory = doc.Settings.Categories.NewSubcategory(linesCategory, "ID "+row.Cells["Mark"].Value.ToString());                            
                            newLineStyleCategory.LineColor = revitColor;
                            newLineStyleCategory.SetLineWeight(6, GraphicsStyleType.Projection);
                            newLineStyleCategory.SetLinePatternId(solidPatternId, GraphicsStyleType.Projection);                            
                            doc.Regenerate();
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        } 
                    }
                }                
            }
            t1.Commit();

            BARevitTools.Application.thisApp.newMainUi.MaterialsAMLUpdateDGV(dgv);

            Dictionary<string, Category> newlineStyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in RVTGetElementsByCollection.DocumentLineStyles(uiApp))
            {
                newlineStyleDict.Add(lineStyle.Name.Replace("ID ",""), lineStyle);
            }

            SortedList<string, string> materialsToUseList = new SortedList<string, string>();
            BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Items.Add("Default");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (newlineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()) && row.Cells["Select"].Value.ToString() == "True")
                {
                    materialsToUseList.Add(row.Cells["Mark"].Value.ToString(), row.Cells["Mark"].Value.ToString());
                }                
            }

            if (materialsToUseList.Count != 0)
            {
                foreach (string item in materialsToUseList.Keys)
                {
                    BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Items.Add(item);
                }
            }
            else
            {
                BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Text = "Default";
                BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Enabled = false;
            }

            BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.Show();

        }
        public void MaterialsAMLPaletteRun(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;            
            MaterialsAMLPalette materialsPalette = BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette;

            //Get the versioned symbol family
            FamilySymbol familySymbol = null;
            string versionedFamily = RVTOperations.GetVersionedFamilyFilePath(uiApp, BARevitTools.Properties.Settings.Default.RevitIDAccentMatTag);

            //Try loading the family symbol
            Transaction loadSymbolTransaction = new Transaction(doc, "LoadFamilySymbol");
            loadSymbolTransaction.Start();
            try
            {
                try
                {
                    IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();
                    doc.LoadFamilySymbol(versionedFamily, "Legend Tag (Fake)", loadOptions, out FamilySymbol symb);
                    familySymbol = symb;
                }
                catch
                {
                    MessageBox.Show(String.Format("Could not get the 'Legend Tag (Fake)' type from {0}", versionedFamily), "Family Symbol Load Error");
                }
                loadSymbolTransaction.Commit();
            }
            catch(Exception transactionException)
            { loadSymbolTransaction.RollBack(); MessageBox.Show(transactionException.ToString());}
            
            //Assure the view being used is a floor plan
            if (doc.ActiveView.ViewType != ViewType.FloorPlan)
            {
                MessageBox.Show("This tool should be used ina a Floor Plan or Area Plan view");
            }
            else
            {
                //Create a loop for picking points. Change the palette background color based on the number of points picked
                List<XYZ> pickedPoints = new List<XYZ>();
                bool breakLoop = false;
                int pickCount = 0;
                while (breakLoop == false)
                {
                    try
                    {
                        XYZ point = uiApp.ActiveUIDocument.Selection.PickPoint(Autodesk.Revit.UI.Selection.ObjectSnapTypes.Endpoints,"Click points for the line to follow. Then click once to the side where the lines should be drawn. Hit ESC to finish");
                        pickedPoints.Add(point);
                        
                        if (pickCount == 1)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.Firebrick;
                        }
                        else if (pickCount == 2)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.Orange;
                        }
                        else if (pickCount>2)
                        {
                            materialsPalette.BackColor = System.Drawing.Color.GreenYellow;
                        }
                        else { ; }

                        pickCount++;
                    }
                    catch
                    {
                        materialsPalette.BackColor = MaterialsAMLPalette.DefaultBackColor;
                        breakLoop = true;
                    }
                }

                //Get rid of the first point from clicking into the Revit view. This point is not needed.
                pickedPoints.RemoveAt(0);

                if (pickedPoints.Count>2)
                {
                    Transaction createLinesTransaction = new Transaction(doc, "CreateAccentLines");
                    createLinesTransaction.Start();

                    try
                    {
                        //These points will be used in determining the start, end, and room points
                        XYZ firstPoint = pickedPoints[0];
                        XYZ roomPoint = pickedPoints[pickedPoints.Count - 1];
                        XYZ lastPoint = pickedPoints[pickedPoints.Count - 2];

                        //Create  a list of points for the polyline that excludes the room point
                        List<XYZ> polyLinePoints = new List<XYZ>();
                        for (int i = 0; i < pickedPoints.Count - 1; i++)
                        {
                            polyLinePoints.Add(pickedPoints[i]);
                        }

                        //Create a polyline from the list of picked points and then get make lines from the points on the poly line
                        PolyLine guidePolyLine = PolyLine.Create(polyLinePoints);
                        IList<XYZ> polyPoints = guidePolyLine.GetCoordinates();

                        List<Line> guideLines = new List<Line>();
                        for (int i = 0; i < polyLinePoints.Count - 1; i++)
                        {
                            guideLines.Add(Line.CreateBound(polyLinePoints[i], polyLinePoints[i + 1]));
                        }

                        //Get the direction of the line offset by measuring the first offset for positive and negative values and comparing their distances the room point
                        bool positiveZ = false;

                        List<Line> offsetLines = new List<Line>();
                        Line positiveOffsetLine = guideLines.Last().CreateOffset(0.6666666667d, XYZ.BasisZ) as Line;
                        Line negativeOffsetLine = guideLines.Last().CreateOffset(-0.6666666667d, XYZ.BasisZ) as Line;
                        XYZ positiveOffsetMidPoint = positiveOffsetLine.Evaluate(0.5d, true);
                        XYZ negativeOffsetMidPoint = negativeOffsetLine.Evaluate(0.5d, true);

                        Double positiveOffsetDistance = positiveOffsetMidPoint.DistanceTo(roomPoint);
                        Double negativeOffsetDistance = negativeOffsetMidPoint.DistanceTo(roomPoint);

                        if (positiveOffsetDistance < negativeOffsetDistance)
                        {
                            positiveZ = true;
                        }

                        //Knowing whether or not to use a positive or negative offset, begin creating offset lines for each guide line
                        foreach (Line guideLine in guideLines)
                        {
                            if (positiveZ)
                            {
                                offsetLines.Add(guideLine.CreateOffset(0.6666666667d, XYZ.BasisZ) as Line);
                            }
                            else
                            {
                                offsetLines.Add(guideLine.CreateOffset(-0.6666666667d, XYZ.BasisZ) as Line);
                            }

                        }

                        //Determine if the number of line segments is 1 or more
                        Line firstLine = offsetLines.First();
                        Line lastLine = null;
                        if (offsetLines.Count > 1)
                        {
                            lastLine = offsetLines.Last();
                        }

                        //Get the line style to use, or create the default
                        Element lineStyle = null;
                        if (materialsPalette.paletteMaterialComboBox.Text == "Default")
                        {
                            try
                            {
                                lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines).SubCategories.get_Item("6 BA ID ACCENT").GetGraphicsStyle(GraphicsStyleType.Projection);
                            }
                            catch
                            {
                                try
                                {
                                    Category linesCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
                                    Category newLineStyleCategory = doc.Settings.Categories.NewSubcategory(linesCategory, "6 BA ID ACCENT");
                                    newLineStyleCategory.LineColor = new Color(0, 0, 0);
                                    newLineStyleCategory.SetLineWeight(6, GraphicsStyleType.Projection);
                                    newLineStyleCategory.SetLinePatternId(LinePatternElement.GetSolidPatternId(), GraphicsStyleType.Projection);
                                    doc.Regenerate();
                                    lineStyle = newLineStyleCategory.GetGraphicsStyle(GraphicsStyleType.Projection);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                        }
                        else
                        {
                            lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines).SubCategories.get_Item("ID " + materialsPalette.paletteMaterialComboBox.Text).GetGraphicsStyle(GraphicsStyleType.Projection);
                        }                        

                        //If there is only one line segment, both end operations must be performed on it
                        if (lastLine == null)
                        {

                            double lineLength = firstLine.Length;
                            double fractionOfLength = 0.6666666667d / lineLength;

                            //Re-evaluating where to place the start and end point of the line
                            XYZ shiftedStartPoint = firstLine.Evaluate(fractionOfLength, true);
                            XYZ shiftedEndPoint = firstLine.Evaluate(1 - fractionOfLength, true);
                            firstLine = Line.CreateBound(shiftedStartPoint, shiftedEndPoint);

                            //Creating the angled corner lines 
                            Line firstCornerLine = Line.CreateBound(firstPoint, firstLine.GetEndPoint(0));
                            Line lastCornerLine = Line.CreateBound(lastPoint, firstLine.GetEndPoint(1));

                            //Create the detail lines from the lines
                            DetailCurve newAccentLine1 = doc.Create.NewDetailCurve(doc.ActiveView, firstCornerLine);
                            DetailCurve newAccentLine2 = doc.Create.NewDetailCurve(doc.ActiveView, firstLine);
                            DetailCurve newAccentLine3 = doc.Create.NewDetailCurve(doc.ActiveView, lastCornerLine);

                            //Assign a line style to the newly created detail lines
                            newAccentLine1.LineStyle = lineStyle;
                            newAccentLine2.LineStyle = lineStyle;
                            newAccentLine3.LineStyle = lineStyle;

                            XYZ tagPlacementPoint = firstLine.Evaluate(0.5d, true);
                            XYZ direction = firstLine.Direction;
                            Line axisLine = Line.CreateUnbound(tagPlacementPoint, XYZ.BasisZ);
                            double rotationAngle = direction.AngleTo(XYZ.BasisX);

                            //Get the midpoint of the line, its direction, and create the rotation and axis
                            if (familySymbol != null)
                            {
                                //Create the tag instance
                                FamilyInstance newTag = doc.Create.NewFamilyInstance(tagPlacementPoint, familySymbol, doc.ActiveView);
                                //Rotate the new tag instance
                                ElementTransformUtils.RotateElement(doc, newTag.Id, axisLine, rotationAngle);
                            }

                            createLinesTransaction.Commit();
                        }
                        //If there is more than one line segment, an operation must be performed on the start and end of the start and end lines, respectively
                        else
                        {
                            
                            List<Line> linesToDraw = new List<Line>();
                            // Get the normalized value for 8" relative to the lengths of the start and end lines
                            double firstLineLength = firstLine.Length;
                            double fractionOfFirstLine = 0.6666666667 / firstLineLength;
                            double lastLineLength = lastLine.Length;
                            double fractionOfLastLine = 0.666666667 / lastLineLength;

                            //Shift the ends of the start and end lines by finding the point along the line relative to the normalized 8" value
                            XYZ shiftedStartPoint = firstLine.Evaluate(fractionOfFirstLine, true);
                            XYZ shiftedEndPoint = lastLine.Evaluate(1 - fractionOfLastLine, true);

                            //Reset the start and end lines with the new shifted points
                            firstLine = Line.CreateBound(shiftedStartPoint, firstLine.GetEndPoint(1));
                            lastLine = Line.CreateBound(lastLine.GetEndPoint(0), shiftedEndPoint);
                            linesToDraw.Add(firstLine);
                            
                            //If there are only 3 offset lines, there will be just one middle segment
                            if (offsetLines.Count == 3)
                            {
                                linesToDraw.Add(offsetLines[1]);
                            }
                            //If there are more than three offset lines, there will be more than one middle line segment                            
                            else
                            {
                                List<Line> middleLines = offsetLines.GetRange(1, offsetLines.Count - 2);
                                foreach (Line middleLine in middleLines)
                                {
                                    linesToDraw.Add(middleLine);
                                }
                            }
                            linesToDraw.Add(lastLine);

                            //For the lines to draw, intersect them with the next line in the list and reset their start and end points to be the intersection
                            for (int i = 0; i < linesToDraw.Count - 1; i++)
                            {
                                Line line1 = linesToDraw[i];
                                Line scaledLine1 = Line.CreateUnbound(line1.GetEndPoint(1), line1.Direction);
                                Line line2 = linesToDraw[i + 1];
                                Line scaledLine2 = Line.CreateUnbound(line2.GetEndPoint(0), line2.Direction.Negate());
                                SetComparisonResult intersectionResult = scaledLine1.Intersect(scaledLine2, out IntersectionResultArray results);
                                if (intersectionResult == SetComparisonResult.Overlap)
                                {
                                    IntersectionResult result = results.get_Item(0);
                                    Line newLine1 = Line.CreateBound(line1.GetEndPoint(0), result.XYZPoint);
                                    Line newLine2 = Line.CreateBound(result.XYZPoint, line2.GetEndPoint(1));

                                    linesToDraw[i] = newLine1;
                                    linesToDraw[i + 1] = newLine2;
                                }
                            }

                            //Create the angled corner lines at the start and end of the line chain
                            Line firstCornerLine = Line.CreateBound(firstPoint, firstLine.GetEndPoint(0));
                            Line lastCornerLine = Line.CreateBound(lastPoint, lastLine.GetEndPoint(1));
                            linesToDraw.Add(firstCornerLine);
                            linesToDraw.Add(lastCornerLine);

                            //Create each line as a detail line
                            foreach (Line apiLine in linesToDraw)
                            {
                                DetailCurve newAccentLine = doc.Create.NewDetailCurve(doc.ActiveView, apiLine);
                                newAccentLine.LineStyle = lineStyle;
                            }

                            //Declare some stuff for use in the symbol placement
                            Line firstMiddleLine = linesToDraw[0];
                            Line lastMiddleLine = linesToDraw[linesToDraw.Count - 3];
                            XYZ firstTagPoint = firstMiddleLine.Evaluate((firstLineLength / 2), false);
                            XYZ lastTagPoint = lastMiddleLine.Evaluate((lastLineLength / 2), false);
                            XYZ firstDirection = firstMiddleLine.Direction;
                            XYZ lastDirection = lastMiddleLine.Direction;
                            Line firstAxisLine = Line.CreateUnbound(firstTagPoint, XYZ.BasisZ);
                            Line lastAxisLine = Line.CreateUnbound(lastTagPoint, XYZ.BasisZ);
                            double firstRotation = firstDirection.AngleTo(XYZ.BasisX);
                            double lastRotation = lastDirection.AngleTo(XYZ.BasisX);

                            if (familySymbol != null)
                            {
                                //Create tag at the beginning of the middle lines
                                FamilyInstance firstTag = doc.Create.NewFamilyInstance(firstTagPoint, familySymbol, doc.ActiveView);
                                ElementTransformUtils.RotateElement(doc, firstTag.Id, firstAxisLine, firstRotation);

                                //Create a tag at the end of the middle lines if there are more than 2 middle lines
                                if (linesToDraw.Count>4)
                                {
                                    FamilyInstance lastTag = doc.Create.NewFamilyInstance(lastTagPoint, familySymbol, doc.ActiveView);
                                    ElementTransformUtils.RotateElement(doc, lastTag.Id, lastAxisLine, lastRotation);
                                }
                            }

                            #region PlaceAtEveryLine
                            //*This is old, and was designed for tagging every middle line segment*//
                            //foreach (Line middleLine in linesToDraw.GetRange(0, linesToDraw.Count - 2))
                            //{
                            //    //Get the midpoint of the line, its direction, and create the rotation and axis
                            //    XYZ tagPlacementPoint = middleLine.Evaluate(middleLine.Length/2, false);
                            //    XYZ direction = middleLine.Direction;
                            //    Line axisLine = Line.CreateUnbound(tagPlacementPoint, XYZ.BasisZ);
                            //    double rotationAngle = direction.AngleTo(XYZ.BasisX);

                            //    if (familySymbol != null)
                            //    {
                            //        //Create the tag instance
                            //        FamilyInstance newTag = doc.Create.NewFamilyInstance(tagPlacementPoint, familySymbol, doc.ActiveView);
                            //        //Rotate the new tag instance
                            //        ElementTransformUtils.RotateElement(doc, newTag.Id, axisLine, rotationAngle);
                            //    }
                            //}
                            #endregion PlaceAtEveryLine

                            createLinesTransaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette == null)
                        {
                            MessageBox.Show("AML Picker was closed prematurely. Please keep the picker open until the lines are drawn.");
                        }
                        else {MessageBox.Show(e.ToString()); }
                        createLinesTransaction.RollBack();
                    }                    
                }
                else
                {
                    ;
                }
            }

        }
        public void RoomsSRNNRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var roomsCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Rooms).ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "SwapRoomNameAndNumber");
            t1.Start();
            foreach (Room room in roomsCollector)
            {
                Parameter roomNumber = room.get_Parameter(BuiltInParameter.ROOM_NUMBER);
                string tempRoomNumber = roomNumber.AsString();
                Parameter roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME);
                string tempRoomName = roomName.AsString();
                try
                {
                    roomNumber.Set(tempRoomName);
                    roomName.Set(tempRoomNumber);
                }
                catch
                { continue; }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
        public void RoomsCDRTRun(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            Autodesk.Revit.DB.View activeView = doc.ActiveView;

            if (activeView.ViewType != ViewType.FloorPlan)
            {
                MessageBox.Show("Please run from a demo floor plan view.");
            }
            else
            {
                Phase currentPhase = doc.GetElement(activeView.get_Parameter(BuiltInParameter.VIEW_PHASE).AsElementId()) as Phase;
                ElementId currentPhaseId = currentPhase.Id;
                ElementId previousPhaseId = null;
                PhaseArray phaseArray = doc.Phases;
                List<Room> currentVisibleRooms = new FilteredElementCollector(doc,activeView.Id).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().ToElements().Cast<Room>().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == currentPhaseId).ToList();
                List<string> currentVisibleRoomNumbers = new List<string>();

                for (int i = 0;i<phaseArray.Size;i++)
                {
                    if (phaseArray.get_Item(i).ToString() == currentPhase.ToString() && i!=0)
                    {
                        previousPhaseId = phaseArray.get_Item(i - 1).Id;
                    }
                    i++;
                }    
                
                foreach (Room room in currentVisibleRooms)
                {
                    currentVisibleRoomNumbers.Add(room.Number);
                }
                
                if (previousPhaseId != null)
                {
                    List<Room> previousRoomsToTag = new List<Room>();
                    Outline outline = null;
                    try
                    {
                        BoundingBoxXYZ viewBBox = activeView.get_BoundingBox(activeView);
                        ViewPlan viewPlan = activeView as ViewPlan;
                        PlanViewRange planViewRange = viewPlan.GetViewRange();
                        
                        double minX = viewBBox.Min.X;
                        double minY = viewBBox.Min.Y;
                        double minZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.BottomClipPlane);
                        double maxX = viewBBox.Max.X;
                        double maxY = viewBBox.Max.Y;
                        double maxZ = activeView.GenLevel.Elevation + planViewRange.GetOffset(PlanViewPlane.TopClipPlane);
                        XYZ minPoint = new XYZ(minX, minY, minZ);
                        XYZ maxPoint = new XYZ(maxX, maxY, maxZ);

                        outline = new Outline(minPoint, maxPoint);
                        BoundingBoxIntersectsFilter bboxFilter = new BoundingBoxIntersectsFilter(outline);
                        var previousNonVisibleRooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().WherePasses(bboxFilter).ToElements().Where(r => r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == previousPhaseId);                        
                        foreach (Element elem in previousNonVisibleRooms)
                        {
                            Room room = elem as Room;
                            string roomNumber = room.Number;
                            if (!currentVisibleRoomNumbers.Contains(roomNumber))
                            {
                                previousRoomsToTag.Add(room);
                            }                            
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), "Getting Demo Rooms Error");
                    }

                    Transaction t = new Transaction(doc, "Create Demo Room Tags");
                    t.Start();
                    FamilySymbol symbol = null;
                    try
                    {
                        IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();
                        string roomTagSymbolPath = RVTOperations.GetVersionedFamilyFilePath(uiApp, BARevitTools.Properties.Settings.Default.RevitRoomTagSymbol);
                        doc.LoadFamilySymbol(roomTagSymbolPath, "Name and Number", loadOptions, out FamilySymbol symb);
                        symbol = symb;
                    }
                    catch(Exception g)
                    {
                        MessageBox.Show(g.ToString(), "Loading Symbol Error");
                    }                   

                    try
                    {
                        if (previousRoomsToTag.Count > 0 && symbol!=null)
                        {
                            foreach (Room demoRoom in previousRoomsToTag)
                            {
                                LocationPoint roomLocationPoint = demoRoom.Location as LocationPoint;
                                XYZ placementPoint = new XYZ();
                                if (outline != null && outline.Contains(placementPoint, 0))
                                {
                                    placementPoint = roomLocationPoint.Point;
                                }
                                else
                                {
                                    placementPoint = roomLocationPoint.Point;
                                }
                                FamilyInstance newSymbol = doc.Create.NewFamilyInstance(placementPoint, symbol, activeView);
                                newSymbol.GetParameters("Name").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NAME).AsString());
                                newSymbol.GetParameters("Number").First().Set(demoRoom.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString());
                            }
                        }
                        t.Commit();
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show(f.ToString(),"Placement Error");
                        t.RollBack();
                    }                    
                }
                else
                {
                    MessageBox.Show("The currently viewed phase is the earliest phase in the project. Please verify you are viewing a new construction phase, but showing previous and demoed elements.");
                }
            }
        }
        public void WallsMPWRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector levelsCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector wallTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> existingLevels = levelsCollector.OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().ToElements();
            ICollection<Element> existingWallTypes = wallTypesCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsElementType().ToElements();
            List<Line> wallLines = new List<Line>();
            List<Wall> newWalls = new List<Wall>();
            List<Element> selectedElements = new List<Element>();
            string selectedWallTypeName = uiForm.wallsMPWComboBoxWall.Text.ToString();
            WallType wallTypeInput = null;
            double wallHeightInput = 0;
            #endregion Collectors, Lists, Objects

            if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {

                #region Get Wall Height Input
                try
                {
                    wallHeightInput = (Convert.ToDouble(uiForm.wallsMPWNumericUpDownWallHeightFt.Value + (uiForm.wallsMPWNumericUpDownWallHeightIn.Value / 12)));
                }
                catch
                {
                    throw new System.ArgumentException("Invalid wall height");
                }
                #endregion Get Wall Height Input

                #region Get Selected Wall Type Input
                double offsetDistance = 0;
                try
                {
                    foreach (WallType wallType in existingWallTypes)
                    {
                        if (wallType.Name == selectedWallTypeName)
                        {
                            wallTypeInput = wallType;
                            offsetDistance = (wallTypeInput.Width) / 2;
                            break;
                        }
                    }
                }
                catch
                {
                    new System.ArgumentException("No wall type was selected");
                }
                #endregion Get Selected Wall Type Input

                ViewPlan activeView = uidoc.Document.ActiveView as ViewPlan;
                Level levelInput = activeView.GenLevel;

                #region Create Walls
                if (wallTypeInput != null && levelInput != null && wallHeightInput != 0)
                {
                    #region Select Elements
                    IList<Reference> elemReferences = new List<Reference>();
                    elemReferences = uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element);

                    foreach (Reference selectedReference in elemReferences)
                    {
                        ElementId referenceId = selectedReference.ElementId;
                        Element referenceElement = uidoc.Document.GetElement(referenceId);
                        selectedElements.Add(referenceElement);
                    }
                    #endregion Select Elements

                    #region Get Rooms
                    List<Element> selectedRoomElements = new List<Element>();
                    foreach (Element element in selectedElements.Distinct())
                    {
                        if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.Room")
                        {
                            Room room = element as Room;
                            selectedRoomElements.Add(room);
                        }
                        else if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.RoomTag")
                        {
                            RoomTag tag = element as RoomTag;
                            selectedRoomElements.Add(tag.Room);
                        }
                        else
                        {
                        }
                    }
                    #endregion Get Rooms

                    #region Get Room Boundary Offset Lines
                    foreach (Element roomElem in selectedRoomElements)
                    {
                        try
                        {
                            Location roomLocation = roomElem.Location;
                            LocationPoint rlp = roomLocation as LocationPoint;
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = roomElem.get_Geometry(geomOptions);
                            foreach (GeometryObject geomObject in geomElements)
                            {
                                if (geomObject.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                {
                                    Solid roomSolid = geomObject as Solid;
                                    FaceArray roomSolidFaces = roomSolid.Faces;
                                    foreach (PlanarFace roomSolidFace in roomSolidFaces)
                                    {
                                        XYZ faceNormal = roomSolidFace.FaceNormal;
                                        if (faceNormal.Z == -1)
                                        {
                                            IList<CurveLoop> faceCurveLoops = roomSolidFace.GetEdgesAsCurveLoops();
                                            foreach (CurveLoop curveLoop in faceCurveLoops)
                                            {
                                                CurveLoop offsetCurveLoops = CurveLoop.CreateViaOffset(curveLoop, offsetDistance, XYZ.BasisZ);
                                                foreach (Line line in offsetCurveLoops)
                                                {
                                                    wallLines.Add(line);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        catch{continue;}
                    }
                    #endregion Get Room Boundary Offset Line

                    #region Transactions
                    Transaction t1 = new Transaction(uidoc.Document, "MakeWalls");
                    t1.Start();
                    foreach (Line wallLine in wallLines)
                    {
                        Wall newWall = Wall.Create(uidoc.Document, wallLine, wallTypeInput.Id, levelInput.Id, wallHeightInput, 0, true, false);
                        newWalls.Add(newWall);
                    }
                    t1.Commit();

                    Transaction t2 = new Transaction(uidoc.Document, "JoinWalls");
                    t2.Start();
                    foreach (Wall newWall in newWalls)
                    {
                        FilteredElementCollector existingWallsCollector = new FilteredElementCollector(uidoc.Document, uidoc.ActiveView.Id);
                        existingWallsCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElements();
                        BoundingBoxXYZ wallBBox = newWall.get_BoundingBox(uidoc.Document.ActiveView);
                        Outline wallBBoxOutline = new Outline(wallBBox.Min, wallBBox.Max);
                        BoundingBoxIntersectsFilter bBoxFilter = new BoundingBoxIntersectsFilter(wallBBoxOutline);
                        existingWallsCollector.WherePasses(bBoxFilter);
                        foreach (Wall existingWall in existingWallsCollector)
                        {
                            try
                            {
                                JoinGeometryUtils.JoinGeometry(uidoc.Document, newWall, existingWall);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    t2.Commit();
                    t1.Dispose();
                    t2.Dispose();
                    #endregion Transactions
                }
                else if (levelInput == null)
                {
                    MessageBox.Show("No level set");
                }
                else if (wallTypeInput == null)
                {
                    MessageBox.Show("No wall type set");
                }
                else if (wallHeightInput <= 0)
                {
                    MessageBox.Show("Wall height must be set to greater than 0");
                }
                else
                {
                    MessageBox.Show(wallTypeInput.Id.ToString());
                    MessageBox.Show(levelInput.Id.ToString());
                    MessageBox.Show(wallHeightInput.ToString());
                }
                #endregion Create Walls
            }

        }
        public void WallsDPRun(UIApplication uiApp, String text)
        {
            Transaction t1 = new Transaction(uiApp.ActiveUIDocument.Document, "RemoveWallParts");
            t1.Start();
            ElementId elementId = RVTOperations.SelectElement(uiApp);
            if (elementId != null)
            {
                RVTOperations.DeleteParts(uiApp, uiApp.ActiveUIDocument.Document, elementId);
            }
            else { MessageBox.Show("No element was selected"); }
            t1.Commit();
        }

        // DOCUMENTATION TAB
        public void SheetsCSLRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            #endregion Collectors, Lists, Objects

            #region Get Sheets from DataGridView
            string selectedSheetNumber = uiForm.sheetsCSLComboBox.Text;
            List<string> selectedSheets = new List<string>();
            List<ElementId> viewsToCopy = new List<ElementId>();
            List<ElementId> viewportTypeIds = new List<ElementId>();
            List<XYZ> viewportLocations = new List<XYZ>();

            foreach (DataGridViewRow row in uiForm.sheetsCSLDataGridView.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if (row.Cells["Select"].Value.ToString() == "True")
                    {
                        selectedSheets.Add(row.Cells["Sheet Number"].Value.ToString());
                    }
                    else { continue; }
                }
                else { continue; }
            }
            #endregion Get Sheets from DataGridView

            #region Get Legends from SelectedSheet
            if (uiForm.sheetsCSLComboBox.Text != "<Originating Sheet>")
            {
                foreach (ViewSheet sheet in sheetsCollector)
                {
                    if (sheet.SheetNumber.ToString() == selectedSheetNumber)
                    {
                        ICollection<ElementId> viewportIds = sheet.GetAllViewports();
                        foreach (ElementId viewportId in viewportIds)
                        {

                            Viewport viewportElement = uidoc.Document.GetElement(viewportId) as Viewport;
                            ElementId viewportViewId = viewportElement.ViewId;
                            ElementId viewportViewTypeId = viewportElement.GetTypeId();
                            XYZ viewportLocation = viewportElement.GetBoxCenter();
                            Autodesk.Revit.DB.View viewportView = uidoc.Document.GetElement(viewportViewId) as Autodesk.Revit.DB.View;
                            if (viewportView.ViewType.ToString() == "Legend")
                            {
                                viewsToCopy.Add(viewportViewId);
                                ; viewportTypeIds.Add(viewportViewTypeId);
                                viewportLocations.Add(viewportLocation);
                            }
                            else { continue; }
                        }
                        break;
                    }
                    else { continue; }
                }
            }
            #endregion Get Legends from Selected Sheet

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "CopyLegendsFromSheetToSheets");
            t1.Start();
            foreach (ViewSheet sheet in sheetsCollector)
            {
                if (selectedSheets.Contains(sheet.SheetNumber.ToString()))
                {
                    int x = viewsToCopy.Count();
                    int i = 0;
                    while (i < x)
                    {
                        try
                        {
                            Viewport newViewport = Viewport.Create(uidoc.Document, sheet.Id, viewsToCopy[i], viewportLocations[i]);
                            newViewport.ChangeTypeId(viewportTypeIds[i]);
                            i++;
                        }
                        catch { i++; }
                    }
                }
                else { continue; }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
        public void SheetsISFLRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            #endregion Collectors, Lists, Objects

            #region Transaction
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
            #endregion Transaction
        }
        public void SheetsCSSFSRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            ViewSchedule schedule = uiForm.sheetsCSSFSDictionary[uiForm.sheetsCSSFSScheduleComboBox.Text];

            if (uiForm.sheetsCSSFSSetNameTextBox.Text != "<Sheet Set Name>" && uiForm.sheetsCSSFSSetNameTextBox.Text != "")
            {
                var sheetCollection = new FilteredElementCollector(doc, schedule.Id).OfClass(typeof(ViewSheet)).ToElements();

                PrintManager printManager = doc.PrintManager;
                printManager.PrintRange = PrintRange.Select;
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                t0.Commit();

                var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
                Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
                List<string> viewSheetSetNames = new List<string>();

                foreach (ViewSheetSet viewSheetSet in viewSheetSets)
                {
                    viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                    viewSheetSetNames.Add(viewSheetSet.Name);
                }

                Transaction t1 = new Transaction(doc, "CreateSheetSet");
                t1.Start();
                ViewSet newViewSet = new ViewSet();
                viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;
                if (sheetCollection != null)
                {
                    foreach (ViewSheet sheet in sheetCollection)
                    {
                        if (!sheet.IsPlaceholder)
                        { newViewSet.Insert(sheet); }
                    }
                    try
                    {
                        if(viewSheetSetNames.Contains(uiForm.sheetsCSSFSSetNameTextBox.Text))
                        {
                            ElementId vssId = viewSheetSetDict[uiForm.sheetsCSSFSSetNameTextBox.Text].Id;
                            doc.Delete(vssId);
                            viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                        }
                        else
                        {
                            viewSheetSetting.SaveAs(uiForm.sheetsCSSFSSetNameTextBox.Text);
                        }                        
                    }
                    catch
                    { MessageBox.Show("A sheet set with that name already exists"); }
                }
                t1.Commit();
            }
        }
        public void SheetsOSSRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;
            var viewSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();
            var viewSheetSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).ToElements();
            Dictionary<string, Autodesk.Revit.DB.ViewSheet> viewSheetDict = new Dictionary<string, Autodesk.Revit.DB.ViewSheet>();
            Dictionary<string, ViewSheetSet> viewSheetSetDict = new Dictionary<string, ViewSheetSet>();
            List<int> viewSheetIds = new List<int>();
            List<string> viewSheetSetNames = new List<string>();

            foreach (ViewSheet viewSheet in viewSheets)
            {
                if (!viewSheet.IsPlaceholder)
                {
                    try
                    {
                        viewSheetDict.Add(viewSheet.Name, viewSheet);
                        viewSheetIds.Add(viewSheet.Id.IntegerValue);
                    }
                    catch { MessageBox.Show(viewSheet.IsPlaceholder.ToString()); }
                }
            }
            foreach (ViewSheetSet viewSheetSet in viewSheetSets)
            {
                viewSheetSetDict.Add(viewSheetSet.Name, viewSheetSet);
                viewSheetSetNames.Add(viewSheetSet.Name);
            }
            

            PrintManager printManager = doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
            

            Transaction t1 = new Transaction(doc, "UpdateViewSheetSets");
            t1.Start();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 2)
                {
                    ViewSet newViewSet = new ViewSet();
                    viewSheetSetting.CurrentViewSheetSet.Views = newViewSet;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[column.Index].Value.ToString() == "True")
                        {
                            newViewSet.Insert(viewSheetDict[row.Cells[1].Value.ToString()]);
                        }
                    }
                    if (viewSheetSetNames.Contains(column.Name))
                    {
                        ElementId vssId = viewSheetSetDict[column.Name].Id;
                        doc.Delete(vssId);
                        viewSheetSetting.SaveAs(column.Name);
                    }
                    else
                    {
                        viewSheetSetting.SaveAs(column.Name);
                    }
                }
            }
            t1.Commit();
            uiForm.SheetsOSSButton_Click(null, null);
        }
        public void SheetsOSSNewSetRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;
                        
            List<string> dtColumnsCollection = new List<string>();
            foreach (DataColumn dtColumn in uiForm.sheetsOSSDataTable.Columns)
            {
                dtColumnsCollection.Add(dtColumn.ColumnName);
            }
            if (!dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text) && uiForm.sheetsOSSNewSetTextBox.Text != "<New Set Name>")
            {
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                PrintManager printManager = doc.PrintManager;
                printManager.PrintRange = PrintRange.Select;
                ViewSheetSetting viewSheetSetting = printManager.ViewSheetSetting;
                
                Transaction t0 = new Transaction(doc, "CreateTempSheetSet");
                t0.Start();
                try
                {
                    viewSheetSetting.SaveAs(uiForm.sheetsOSSNewSetTextBox.Text);
                    t0.Commit();

                    DataColumn newColumn = new DataColumn();
                    newColumn.ColumnName = uiForm.sheetsOSSNewSetTextBox.Text;
                    newColumn.DataType = typeof(Boolean);
                    uiForm.sheetsOSSDataTable.Columns.Add(newColumn);
                }
                catch { t0.RollBack();}                
                dgv.Update();
            }
            else if (dtColumnsCollection.Contains(uiForm.sheetsOSSNewSetTextBox.Text))
            { MessageBox.Show("Set with specified name already exists"); }
            else
            { MessageBox.Show("Cannot make a set with the specified name"); }

            dgv.Update();
            dgv.Refresh();
            GraphicsFormatting.HighlightCellsFromDataGridView(dgv, System.Drawing.Color.GreenYellow);
        }
        public void ViewsCEPRRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            FilteredElementCollector viewTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> viewTypes = viewTypesCollector.OfClass(typeof(ViewFamilyType)).ToElements();
            ElementId viewTypeId = null;

            #region Get View Type Input
            foreach (ViewFamilyType viewType in viewTypes)
            {
                if (viewType.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_NAME).AsString() == uiForm.viewsCEPRElevationComboBox.Text)
                {
                    viewTypeId = viewType.Id;
                }
            }

            if (viewTypeId != null && uidoc.ActiveView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
                List<Room> selectedRoomElements = uiForm.floorsCFBRRoomsList;

                #region Create Elevations
                if (selectedRoomElements != null)
                {
                    try
                    {
                        foreach (Element roomElem in selectedRoomElements)
                        {
                            Room room = roomElem as Room;
                            string roomNumber = room.Number;
                            string roomName = room.get_Parameter(BuiltInParameter.ROOM_NAME).AsString().ToUpper();
                            Level roomLevel = room.Level;
                            Options geomOptions = new Options();
                            geomOptions.IncludeNonVisibleObjects = true;
                            GeometryElement geomElements = roomElem.get_Geometry(geomOptions);
                            LocationPoint roomLocation = room.Location as LocationPoint;
                            XYZ point = roomLocation.Point;

                            #region Transaction
                            Transaction t1 = new Transaction(uidoc.Document, "Create Elevations Per Room");
                            t1.Start();
                            try
                            {
                                IList<CurveLoop> westCurveLoops = null;
                                IList<CurveLoop> northCurveLoops = null;
                                IList<CurveLoop> southCurveLoops = null;
                                IList<CurveLoop> eastCurveLoops = null;
                                Solid roomSolid = null;
                                ElevationMarker newMarker = ElevationMarker.CreateElevationMarker(uidoc.Document, viewTypeId, point, 96);
                                ViewSection view0 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 0);
                                view0.Name = roomNumber + " " + roomName + " WEST";
                                view0.CropBoxActive = true;
                                ViewSection view1 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 1);
                                view1.Name = roomNumber + " " + roomName + " NORTH";
                                view1.CropBoxActive = true;
                                ViewSection view2 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 2);
                                view2.Name = roomNumber + " " + roomName + " EAST";
                                view2.CropBoxActive = true;
                                ViewSection view3 = newMarker.CreateElevation(uidoc.Document, uidoc.ActiveView.Id, 3);
                                view3.Name = roomNumber + " " + roomName + " SOUTH";
                                view3.CropBoxActive = true;
                                if (uiForm.viewsCEPRCropCheckBox.Checked == true)
                                {
                                    foreach (GeometryObject geom in geomElements)
                                    {
                                        if (geom.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                                        {
                                            roomSolid = geom as Solid;
                                        }
                                    }

                                    Plane westPlane = Plane.CreateByNormalAndOrigin(new XYZ(-1, 0, 0), point);
                                    Solid westBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, westPlane);
                                    FaceArray westBoolSolidFaces = westBooleanSolid.Faces;
                                    foreach (PlanarFace westFace in westBoolSolidFaces)
                                    {
                                        XYZ westFaceNormal = westFace.FaceNormal;
                                        if (westFaceNormal.X == 1)
                                        {
                                            westCurveLoops = westFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager westCropRegionShapeManager = view0.GetCropRegionShapeManager();
                                    westCropRegionShapeManager.SetCropShape(westCurveLoops[0]);

                                    Plane northPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), point);
                                    Solid northBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, northPlane);
                                    FaceArray northBoolSolidFaces = northBooleanSolid.Faces;
                                    foreach (PlanarFace northFace in northBoolSolidFaces)
                                    {
                                        XYZ northFaceNormal = northFace.FaceNormal;
                                        if (northFaceNormal.Y == -1)
                                        {
                                            northCurveLoops = northFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager northCropRegionShapeManager = view1.GetCropRegionShapeManager();
                                    northCropRegionShapeManager.SetCropShape(northCurveLoops[0]);

                                    Plane eastPlane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), point);
                                    Solid eastBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, eastPlane);
                                    FaceArray eastBoolSolidFaces = eastBooleanSolid.Faces;
                                    foreach (PlanarFace eastFace in eastBoolSolidFaces)
                                    {
                                        XYZ eastFaceNormal = eastFace.FaceNormal;
                                        if (eastFaceNormal.X == -1)
                                        {
                                            eastCurveLoops = eastFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager eastCropRegionShapeManager = view2.GetCropRegionShapeManager();
                                    eastCropRegionShapeManager.SetCropShape(eastCurveLoops[0]);

                                    Plane southPlane = Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), point);
                                    Solid southBooleanSolid = BooleanOperationsUtils.CutWithHalfSpace(roomSolid, southPlane);
                                    FaceArray southBoolSolidFaces = southBooleanSolid.Faces;
                                    foreach (PlanarFace southFace in southBoolSolidFaces)
                                    {
                                        XYZ southFaceNormal = southFace.FaceNormal;
                                        if (southFaceNormal.Y == 1)
                                        {
                                            southCurveLoops = southFace.GetEdgesAsCurveLoops();
                                            break;
                                        }
                                    }
                                    ViewCropRegionShapeManager southCropRegionShapeManager = view3.GetCropRegionShapeManager();
                                    southCropRegionShapeManager.SetCropShape(southCurveLoops[0]);

                                    if (uiForm.viewsCEPROverrideCheckBox.Checked == true)
                                    {
                                        OverrideGraphicSettings orgs = new OverrideGraphicSettings();
                                        orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
                                        orgs.SetProjectionLineWeight(5);

                                        var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                                        foreach (Element viewer in viewers)
                                        {
                                            ParameterSet parameters = viewer.Parameters;
                                            foreach (Parameter parameter in parameters)
                                            {
                                                if (parameter.Definition.Name.ToString() == "View Name")
                                                {
                                                    string viewName = parameter.AsString();
                                                    if (viewName == view0.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view0 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else if (viewName == view1.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view1 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else if (viewName == view2.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view2 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else if (viewName == view3.Name)
                                                    {
                                                        Autodesk.Revit.DB.View viewtouse = view3 as Autodesk.Revit.DB.View;
                                                        viewtouse.SetElementOverrides(viewer.Id, orgs);
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                t1.Commit();
                            }
                            catch
                            {
                                t1.RollBack();
                            }
                            t1.Dispose();
                            #endregion Transaction
                        }
                    }
                    catch
                    {
                        MessageBox.Show("No rooms were selected");
                    }
                    #endregion Create Elevations
                }
            }
            else if (uidoc.ActiveView.GetType().ToString() != "Autodesk.Revit.DB.ViewPlan")
            {
                MessageBox.Show("Please run from a plan view");
            }
            else
            {
                MessageBox.Show("No elevation type selected");
            }
            #endregion Get View Type Input
        }
        public void ViewsOICBRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewerCollector = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();
            OverrideGraphicSettings orgs = new OverrideGraphicSettings();
            orgs.SetProjectionLinePatternId(LinePatternElement.GetSolidPatternId());
            orgs.SetProjectionLineWeight(5);
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "OverrideInteriorElevationCrops");
            t1.Start();
            foreach (Viewport viewport in viewportCollector)
            {
                ElementId viewId = viewport.ViewId;
                Element viewElem = uidoc.Document.GetElement(viewId);
                Autodesk.Revit.DB.View viewElemView = viewElem as Autodesk.Revit.DB.View;
                ElementId typeId = viewElem.GetTypeId();
                Element typeElement = uidoc.Document.GetElement(typeId);
                string typeElementName = typeElement.Name.ToString();
                if (viewElem.GetType().ToString() == "Autodesk.Revit.DB.ViewSection" && viewElemView.ViewType == ViewType.Elevation && typeElementName.Contains("Interior"))
                {
                    var viewers = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Viewers);
                    foreach (Element viewer in viewerCollector)
                    {
                        if (viewer.Name.ToString() == viewElem.Name.ToString())
                        {
                            Autodesk.Revit.DB.View viewToOverride = viewElem as Autodesk.Revit.DB.View;
                            viewToOverride.SetElementOverrides(viewer.Id, orgs);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }

            }
            t1.Commit();
            #endregion Transaction
        }
        public void ViewsHNIECRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewportCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Viewport)).ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "HideNonInteriorElevationCrops");
            t1.Start();
            try
            {
                foreach (Viewport viewport in viewportCollector)
                {
                    ElementId viewId = viewport.ViewId;
                    Autodesk.Revit.DB.View viewElem = uidoc.Document.GetElement(viewId) as Autodesk.Revit.DB.View;
                    string viewType = viewElem.GetType().ToString();
                    if (viewType == "Autodesk.Revit.DB.ViewPlan")
                    {
                        viewElem.CropBoxVisible = false;
                    }
                    else if (viewType == "Autodesk.Revit.DB.ViewSection")
                    {
                        if (viewElem.ViewType.ToString() == "Elevation")
                        {
                            ElementId typeId = viewElem.GetTypeId();
                            ElementType typeElement = uidoc.Document.GetElement(typeId) as ElementType;
                            string typeElementName = typeElement.Name.ToString();
                            if (!typeElementName.Contains("Interior"))
                            {
                                viewElem.CropBoxVisible = false;
                            }
                            else
                            { continue; }
                        }
                        else
                        {
                            viewElem.CropBoxVisible = false;
                        }
                    }
                    else { continue; }
                }
                t1.Commit();
            }
            catch
            {
                t1.RollBack();
            }
            #endregion Transaction
        }

        // MANAGEMENT TAB
        public void DataEPIRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;

            #region Transaction
            Autodesk.Revit.DB.View activeView = uidoc.Document.ActiveView;
            if (activeView.GetType().ToString() == "Autodesk.Revit.DB.ViewPlan")
            {
                if (activeView.CropBoxActive == false)
                {
                    Transaction t1 = new Transaction(uidoc.Document, "Crop Active View");
                    t1.Start();
                    try
                    {
                        activeView.CropBoxActive = true;
                        t1.Commit();
                    }
                    catch
                    {
                        t1.RollBack();
                    }
                }

                BoundingBoxXYZ cropBox = activeView.CropBox;
                double cropBoxOriginX = 0;
                double cropBoxOriginY = 0;
                if (cropBox.Transform.Origin.X != 0)
                {
                    cropBoxOriginX = cropBox.Transform.Origin.X;
                }
                if (cropBox.Transform.Origin.Y != 0)
                {
                    cropBoxOriginY = cropBox.Transform.Origin.Y;
                }

                XYZ cropboxMin = cropBox.Min;
                XYZ cropboxMax = cropBox.Max;

                double cropBoxMinX = Math.Round(cropBox.Min.X, 3) + cropBoxOriginX;
                double cropBoxMinY = Math.Round(cropBox.Min.Y, 3) + cropBoxOriginY;
                double cropBoxMaxX = Math.Round(cropBox.Max.X, 3) + cropBoxOriginX;
                double cropBoxMaxY = Math.Round(cropBox.Max.Y, 3) + cropBoxOriginY;

                string filePath = uiForm.dataEPIDirectorySelectedLabel.Text + "\\" + uiForm.dataEPISaveTextBox.Text + "_" + cropBoxMinX.ToString() + "_" + cropBoxMinY.ToString() + "_" + cropBoxMaxX.ToString() + "_" + cropBoxMaxY.ToString() + ".jpg";
                ImageExportOptions imageExportOptions = new ImageExportOptions();
                imageExportOptions.FilePath = filePath;
                imageExportOptions.FitDirection = FitDirectionType.Horizontal;
                imageExportOptions.ZoomType = ZoomFitType.Zoom;
                imageExportOptions.Zoom = 100;
                imageExportOptions.HLRandWFViewsFileType = ImageFileType.JPEGSmallest;
                if (uiForm.dataEPIDPIComboBox.Text == "150")
                {
                    imageExportOptions.ImageResolution = ImageResolution.DPI_150;
                }
                else if (uiForm.dataEPIDPIComboBox.Text == "300")
                {
                    imageExportOptions.ImageResolution = ImageResolution.DPI_300;
                }
                else { imageExportOptions.ImageResolution = ImageResolution.DPI_600; }
                imageExportOptions.ExportRange = ExportRange.CurrentView;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                uidoc.Document.ExportImage(imageExportOptions);
            }
            else { MessageBox.Show("Please run from a cropped plan view"); }
            #endregion Transaction
        }
        public void MiscEDVRun(UIApplication uiApp, String text)
        {            
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            if (uiForm.miscEDVSelectDirectoryTextBox.Text != "")
            {
                string[] illegalCharacters = { "<", ">", ":", "/", @"\", @"|", "?", "*" };
                List<ViewDrafting> viewsToUse = new List<ViewDrafting>();
                foreach (DataGridViewRow row in uiForm.miscEDVDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        DataRow dgvRow = (row.DataBoundItem as DataRowView).Row;
                        viewsToUse.Add(dgvRow["View Element"] as ViewDrafting);
                    }
                }

                int filesToProcess = viewsToUse.Count;
                uiForm.miscEDVProgressBar.Value = 0;
                uiForm.miscEDVProgressBar.Minimum = 0;
                uiForm.miscEDVProgressBar.Maximum = filesToProcess;
                uiForm.miscEDVProgressBar.Step = 1;
                uiForm.miscEDVProgressBar.Visible = true;


                foreach (ViewDrafting fromView in viewsToUse)
                {
                    RVTDocument newDoc = uiApp.Application.NewProjectDocument(UnitSystem.Imperial);
                    Transaction t1 = new Transaction(newDoc, "ExportDraftingViews");
                    t1.Start();
                        SubTransaction s1 = new SubTransaction(newDoc);
                        s1.Start();
                        FilteredElementCollector collector = new FilteredElementCollector(newDoc);
                        collector.OfClass(typeof(ViewFamilyType));
                        ViewFamilyType viewFamilyType = collector.Cast<ViewFamilyType>().First(vft => vft.ViewFamily == ViewFamily.Drafting);
                        ViewDrafting toView = ViewDrafting.Create(newDoc, viewFamilyType.Id);
                        s1.Commit();
                    List<ElementId> viewElementIds = new FilteredElementCollector(uidoc.Document, fromView.Id).ToElementIds().Cast<ElementId>().ToList();
                    CopyPasteOptions copyPasteOptions = new CopyPasteOptions();
                    copyPasteOptions.SetDuplicateTypeNamesHandler(new RVTDuplicateTypesHandler());
                    ElementTransformUtils.CopyElements(fromView, viewElementIds, toView, null, copyPasteOptions);
                    t1.Commit();

                    ElementId viewPreviewId = null;
                    var newDocViews = new FilteredElementCollector(newDoc).OfClass(typeof(ViewDrafting)).ToElements().Cast<Element>().ToList();
                    foreach (ViewDrafting newDocView in newDocViews)
                    {
                        if (newDocView.Name == fromView.Name)
                        {
                            viewPreviewId = newDocView.Id;
                            break;
                        }
                    }

                    SaveAsOptions saveAsOptions = new SaveAsOptions();
                    saveAsOptions.Compact = true;
                    saveAsOptions.MaximumBackups = 1;
                    saveAsOptions.OverwriteExistingFile = true;
                    saveAsOptions.PreviewViewId = viewPreviewId;

                    string fileName = fromView.Name.Replace("\"", "").Replace(".", "");
                    foreach (string item in illegalCharacters)
                    {
                        if (fileName.Contains(item))
                        {
                            fileName.Replace(item, "");
                        }
                    }

                    string savePath = uiForm.miscEDVSelectDirectoryTextBox.Text + "\\" + fileName + ".rvt";
                    if (File.Exists(savePath))
                    {
                        try
                        {
                            File.Delete(savePath);
                        }
                        catch { continue; }
                    }
                    newDoc.SaveAs(savePath, saveAsOptions);
                    newDoc.Close(false);
                    uiForm.miscEDVProgressBar.PerformStep();
                }
            }
            else
            {
                MessageBox.Show("No save directory is set. Please pick a directory.");
            }
        }
        public void DocumentsCTSRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector textNoteTypesCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector dimensionTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> textNoteTypes = textNoteTypesCollector.OfClass(typeof(TextNoteType)).ToElements();
            ICollection<Element> dimensionTypes = dimensionTypesCollector.OfClass(typeof(DimensionType)).ToElements();
            decimal decreaseValue = (decimal)(1m / 64m / 12m);
            decimal lowerLimit = (decimal)(3m / 128m / 12m);
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "Convert Text Note Text");
            t1.Start();

            foreach (TextNoteType textNoteType in textNoteTypes)
            {
                Parameter param = textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE);
                decimal originalSize = (decimal)param.AsDouble();
                decimal newSize = originalSize - decreaseValue;
                if (newSize > lowerLimit)
                {
                    try
                    {
                        param.Set((double)newSize);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            foreach (DimensionType dimensiontype in dimensionTypes)
            {
                Parameter param = dimensiontype.get_Parameter(BuiltInParameter.TEXT_SIZE);
                decimal originalSize = (decimal)param.AsDouble();
                decimal newSize = originalSize - decreaseValue;
                if (newSize > lowerLimit)
                {
                    try
                    {
                        param.Set((double)newSize);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
        public void QaqcCSVNRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector sheetsCollector = new FilteredElementCollector(uidoc.Document);
            FilteredElementCollector viewportsCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> sheets = sheetsCollector.OfClass(typeof(ViewSheet)).WhereElementIsNotElementType().ToElements();
            ICollection<Element> viewports = viewportsCollector.OfClass(typeof(Viewport)).WhereElementIsNotElementType().ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            Transaction t1 = new Transaction(uidoc.Document, "Capitalize Sheet and View Names");
            t1.Start();
            foreach (ViewSheet sheet in sheets)
            {
                try
                {
                    sheet.Name = sheet.Name.ToString().ToUpper();
                }
                catch
                {
                    continue;
                }
            }
            foreach (Viewport viewport in viewports)
            {
                try
                {
                    if (viewport.SheetId.ToString() != "InvalidElementId")
                    {
                        ElementId viewId = viewport.ViewId;
                        Autodesk.Revit.DB.View viewportView = uidoc.Document.GetElement(viewId) as Autodesk.Revit.DB.View;
                        viewportView.Name = viewportView.Name.ToString().ToUpper();
                    }
                }
                catch
                {
                    continue;
                }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
        public void QaqcDRNPRun(UIApplication uiApp, String text)
        {
            #region Collectors, Lists, Objects
            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector roomsCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> rooms = roomsCollector.OfCategory(BuiltInCategory.OST_Rooms).ToElements();
            #endregion Collectors, Lists, Objects

            #region Transaction
            List<ElementId> idsToDelete = new List<ElementId>();
            Transaction t1 = new Transaction(uidoc.Document, "DeleteNotPlacedRooms");
            t1.Start();
            foreach (Room room in rooms)
            {
                if (room.Location == null)
                {
                    idsToDelete.Add(room.Id);
                }
            }
            foreach (ElementId idToDelete in idsToDelete)
            {
                try
                {
                    uidoc.Document.Delete(idsToDelete);
                }
                catch
                {
                    continue;
                }
            }
            t1.Commit();
            t1.Dispose();
            #endregion Transaction
        }
        public void QaqcCSVRun(UIApplication uiApp, String text)
        {
            DataTable dt = new DataTable();
            DataColumn paramIdColumn = dt.Columns.Add("ID", typeof(Int32));
            DataColumn paramNameColumn = dt.Columns.Add("Name", typeof(String));
            DataColumn paramElemColumn = dt.Columns.Add("Element", typeof(Object));
            List<string> fieldNamesCollection = new List<string>();
            List<Parameter> elementParameters = new List<Parameter>();
            List<DataRow> duplicateRows = new List<DataRow>();
            List<ElementId> idsToUpdate = new List<ElementId>();
            List<string> failList = new List<string>();
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DialogResult result = MessageBox.Show("Have you synchronized your model changes?", "Synchronization Prompt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (doc.ActiveView.ViewType == ViewType.Schedule)
                {
                    ViewSchedule viewSchedule = doc.ActiveView as ViewSchedule;
                    var scheduleCollector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
                    ScheduleDefinition scheduleDefinition = viewSchedule.Definition;
                    int scheduleFieldCount = scheduleDefinition.GetFieldCount();
                    for ( int i = 0; i<scheduleFieldCount; i++)
                    {
                        ScheduleField scheduleField = scheduleDefinition.GetField(i);
                        fieldNamesCollection.Add(scheduleField.GetName().Replace("Material: ", ""));
                    }

                    foreach (Element elem in scheduleCollector)
                    {
                        foreach (Parameter instanceParam in elem.Parameters)
                        {
                            elementParameters.Add(instanceParam);
                            DataRow row = dt.NewRow();
                            row["ID"] = instanceParam.Id.IntegerValue;
                            row["Name"] = instanceParam.Definition.Name;
                            row["Element"] = instanceParam;
                            dt.Rows.Add(row);
                        }
                        ElementId typeId = elem.GetTypeId();
                        Element typeElement = doc.GetElement(typeId);
                        try
                        {
                            foreach (Parameter typeParameter in typeElement.Parameters)
                            {
                                elementParameters.Add(typeParameter);
                                DataRow row = dt.NewRow();
                                row["ID"] = typeParameter.Id.IntegerValue;
                                row["Name"] = typeParameter.Definition.Name;
                                row["Element"] = typeParameter;
                                dt.Rows.Add(row);
                            }
                        }
                        catch { continue; }
                    }

                    List<Parameter> elementParameterList = elementParameters.Distinct().ToList();
                    Hashtable hashTable = new Hashtable();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (hashTable.Contains(row["ID"]))
                        { duplicateRows.Add(row); }
                        else
                        { hashTable.Add(row["ID"], null); }
                    }
                    foreach (DataRow item in duplicateRows)
                    { dt.Rows.Remove(item); }

                    Transaction t1 = new Transaction(doc, "CapitalizeScheduleValues");
                    t1.Start();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            if (fieldNamesCollection.Contains(row["Name"].ToString()))
                            {
                                Parameter rowParam = row["Element"] as Parameter;
                                if (rowParam.StorageType == StorageType.String && !rowParam.IsReadOnly)
                                {
                                    idsToUpdate.Add(new ElementId(Convert.ToInt32(row["ID"])));
                                }
                            }
                        }
                        catch { continue; }                        
                    }
                    foreach (Element elem in scheduleCollector)
                    {
                        try
                        {
                            foreach (Parameter param in elementParameterList)
                            {
                                if (idsToUpdate.Contains(param.Id) && param.AsString() != null)
                                {
                                    if (!param.AsString().Contains("{") && !param.AsString().Contains("}"))
                                    {
                                    try { param.Set(param.AsString().ToUpper()); }
                                    catch { failList.Add(param.Definition.Name); continue; }
                                    }                                    
                                }
                            }
                        }
                        catch { continue; }
                    }
                    t1.Commit();
                }

                else { MessageBox.Show(String.Format("The currently active view is of type: {0}. " +
                    "Please make the desired schedule the active view by clicking into the schedule view and rerun the script", 
                    doc.ActiveView.ViewType.ToString())); }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Please synchronize and/or save the model, then run again");
            }
            else
            {
                ;
            }

            if (failList.Count>1)
            {
                string failMessage = StringOperations.BuildStringFromList(failList).ToString();
                MessageBox.Show(String.Format("Could not convert the following parameters: {0}",failMessage));
            }

        }
        public void QaqcRLSRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView dgv = uiForm.qaqcRLSDataGridView;
            
            List<ElementId> unswitchableElements = new List<ElementId>();

            DataTable dt = new DataTable();            
            DataColumn elementIdColumn = dt.Columns.Add("Element Id", typeof(ElementId));
            DataColumn groupNameColumn = dt.Columns.Add("Group Name", typeof(String));

            if (uiForm.qaqcRLSReplaceComboBox.Text == "<Replace>")
            {
                MessageBox.Show("Select the line style to replace");
            }
            else if (uiForm.qaqcRLSReplaceWithComboBox.Text =="<With>")
            {
                MessageBox.Show("Select the line style to replace with");
            }
            else
            {
                Category replaceStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceComboBox.Text.ToString()];
                Category replaceWithStyle = uiForm.qaqcLineStyleDict[uiForm.qaqcRLSReplaceWithComboBox.Text.ToString()];
                GraphicsStyle setStyle = replaceWithStyle.GetGraphicsStyle(GraphicsStyleType.Projection);

                var lineCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Lines).ToElements();
                Transaction t1 = new Transaction(doc, "ConvertLines");
                t1.Start();
                foreach (CurveElement elem in lineCollector)
                {
                    string lineStyleName = elem.LineStyle.Name;
                    ElementId groupId = elem.GroupId;

                    if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) == -1)
                    {
                        bool wasPinned = false;

                        if (elem.Pinned)
                        {
                            elem.Pinned = false;
                            wasPinned = true;
                        }

                        try
                        {
                            elem.LineStyle = setStyle;
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            unswitchableElements.Add(elem.Id);
                            continue;
                        }

                        if (wasPinned)
                        {
                            elem.Pinned = true;
                        }
                    }

                    else if (lineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(elem.GroupId.ToString()) != -1)
                    {
                        unswitchableElements.Add(elem.Id);
                    }
                    else{continue;}
                }
                t1.Commit();

                var regionCollector = new FilteredElementCollector(doc).OfClass(typeof(FilledRegion)).ToElements().ToList();
                Transaction t2 = new Transaction(doc, "ReplaceRegions");
                t2.Start();
                foreach (FilledRegion region in regionCollector)
                {
                    ElementId regionId = region.Id;
                    SubTransaction st2 = new SubTransaction(doc);
                    st2.Start();
                    List<ElementId> deletedIds = doc.Delete(regionId).ToList();
                    st2.RollBack();

                    foreach (ElementId id in deletedIds)
                    {
                        Element regionSubElem = doc.GetElement(id);
                        if (regionSubElem.GetType().ToString() == "Autodesk.Revit.DB.DetailLine")
                        {
                            CurveElement curveElement = regionSubElem as CurveElement;
                            string sketchLineStyleName = curveElement.LineStyle.Name;
                            if (sketchLineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(region.GroupId.ToString()) == -1)
                            {
                                bool wasPinned = false;
                                if (region.Pinned)
                                {
                                    region.Pinned = false;
                                    wasPinned = true;
                                }

                                try
                                {
                                    curveElement.LineStyle = setStyle;
                                    XYZ z = XYZ.BasisZ;
                                    ElementTransformUtils.MoveElement(doc, region.Id, z);
                                    ElementTransformUtils.MoveElement(doc, region.Id, -z);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                    unswitchableElements.Add(region.Id);
                                    continue;
                                }

                                if (wasPinned)
                                {
                                    region.Pinned = true;
                                }
                            }
                            else if (sketchLineStyleName == uiForm.qaqcRLSReplaceComboBox.Text.ToString() && Convert.ToInt32(region.GroupId.ToString()) != -1)
                            {
                                unswitchableElements.Add(region.Id);
                                continue;
                            }
                            else { continue; }
                        }
                        else { continue; }
                    }
                }
                t2.Commit();

                foreach (ElementId elemId in unswitchableElements)
                {
                    DataRow row = dt.NewRow();
                    row["Element Id"] = elemId;
                    if (doc.GetElement(elemId).GroupId.IntegerValue != -1)
                    {
                        row["Group Name"] = doc.GetElement(doc.GetElement(elemId).GroupId).Name;
                    }
                    else { row["Group Name"] = ""; }
                    dt.Rows.Add(row);
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.Sort(dgv.Columns["Group Name"], ListSortDirection.Ascending);

                if (uiForm.qaqcRLSDeleteCheckBox.Checked && dt.Rows.Count == 0)
                {
                    Transaction t = new Transaction(doc, String.Format("Delete{0}", replaceStyle.Name));
                    t.Start();
                    try
                    {                        
                        doc.Delete(replaceStyle.Id);
                        t.Commit();
                        uiForm.qaqcRLSReplaceComboBox.Text = "<Replace>";
                        uiForm.qaqcRLSReplaceComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Items.Clear();
                        uiForm.qaqcRLSReplaceWithComboBox.Text = "<With>";
                        uiForm.QaqcRLSSetReplaceComboBox(uiForm, doc);
                    }
                    catch
                    {
                        t.RollBack();
                        MessageBox.Show(String.Format("Could not delete {0}", replaceStyle.Name));
                    }
                }
                else { MessageBox.Show(String.Format("Could not Delete {0} because {1} instances could not be switched. See the table for instances in groups that could not be switched", replaceStyle.Name, dgv.Rows.Count.ToString())); }
            }
        }
        public void QaqcRFSPRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string familyFile = uiForm.qaqcRFSPFamilyFile;
            RVTDocument familyDoc = uiApp.Application.OpenDocumentFile(familyFile);
            FamilyManager famMan = familyDoc.FamilyManager;
            IList<FamilyParameter> famParams = famMan.GetParameters();

            Transaction t = new Transaction(familyDoc, "ChangeSharedParameters");
            t.Start();
            try
            {
                foreach (FamilyParameter param in famParams)
                {
                    string paramName = param.Definition.Name;
                    try
                    {                        
                        if (param.IsShared && !paramName.ToUpper().Contains("BA ") && !paramName.ToUpper().Contains("BAS "))
                        {
                            BuiltInParameterGroup paramGroup = param.Definition.ParameterGroup;
                            string paramTempName = "tempName";
                            bool paramInstance = param.IsInstance;
                            FamilyParameter newParam = famMan.ReplaceParameter(param, paramTempName, paramGroup, paramInstance);
                            famMan.RenameParameter(newParam, paramName);
                            uiForm.qaqcRFSPParametersListBox.Items.Add(paramName + ": SUCCESS");
                        }
                    }
                    catch
                    {
                        uiForm.qaqcRFSPParametersListBox.Items.Add(paramName + ": FAILED");
                    }
                }
                t.Commit();
                uiForm.qaqcRFSPParametersListBox.Update();
                uiForm.qaqcRFSPParametersListBox.Refresh();
            }
            catch
            {
                t.RollBack();
            }
            RVTOperations.SaveRevitFile(uiApp, familyDoc);
        }
        public void SetupCWSRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            TransactWithCentralOptions TWCOptions = new TransactWithCentralOptions();
            RelinquishOptions relinquishOptions = new RelinquishOptions(true);
            SynchronizeWithCentralOptions SWCOptions = new SynchronizeWithCentralOptions();
            SWCOptions.Compact = true;
            SWCOptions.SetRelinquishOptions(relinquishOptions);
            WorksharingSaveAsOptions worksharingSaveOptions = new WorksharingSaveAsOptions();
            worksharingSaveOptions.SaveAsCentral = true;
            SaveOptions projectSaveOptions = new SaveOptions();
            projectSaveOptions.Compact = true;
            SaveAsOptions projectSaveAsOptions = new SaveAsOptions();
            projectSaveAsOptions.Compact = true;
            projectSaveAsOptions.OverwriteExistingFile = true;
            projectSaveAsOptions.SetWorksharingOptions(worksharingSaveOptions);

            List<string> worksetsToAdd = new List<string>();
            foreach (string item in uiForm.setupCWSDefaultListBox.Items)
            {
                worksetsToAdd.Add(item);
            }
            foreach (string item in uiForm.setupCWSExtendedListBox.CheckedItems)
            {
                worksetsToAdd.Add(item);
            }
            foreach (DataGridViewRow row in uiForm.setupCWSUserDataGridView.Rows)
            {
                try
                {
                    if(row.Cells[0].Value.ToString() != "")
                    { worksetsToAdd.Add(row.Cells[0].Value.ToString()); }
                }
                catch { continue; }
            }
                        
            List<Workset> worksets = new FilteredWorksetCollector(doc).Cast<Workset>().ToList();
            List<string> worksetNames = new List<string>();

            foreach (Workset workset in worksets)
            {
                if (workset.Name == "Workset1")
                {
                    try
                    {
                        WorksetTable.RenameWorkset(doc, workset.Id, "Arch");
                        worksetNames.Add("Arch");
                        break;
                    }
                    catch { continue; }
                }
                else{ worksetNames.Add(workset.Name); }                
            }

            if (doc.IsWorkshared && doc.PathName != "")
            {
                Transaction t1 = new Transaction(doc, "CreateWorksets");
                t1.Start();
                foreach (string worksetName in worksetsToAdd)
                {
                    if (!worksetNames.Contains(worksetName))
                    {
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();

                try
                {
                    doc.Save(projectSaveOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
                catch
                {
                    doc.SaveAs(doc.PathName, projectSaveAsOptions);
                    doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                }
            }
            else if (!doc.IsWorkshared && doc.PathName != "")
            {
                doc.EnableWorksharing("Shared Levels and Grids", "Arch");
                worksetNames.Add("Shared Levels and Grids");
                worksetNames.Add("Arch");
                Transaction t1 = new Transaction(doc, "MakeWorksets");
                t1.Start();
                foreach (string worksetName in worksetsToAdd)
                {
                    if (!worksetNames.Contains(worksetName))
                    {
                        Workset.Create(doc, worksetName);
                    }
                }
                t1.Commit();
                doc.SaveAs(doc.PathName, projectSaveAsOptions);
                doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
            }
            else
            {
                MessageBox.Show("Project file needs to be saved somewhere before it can be made a central model");
            }
        }
        public void SetupUPRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            string hostFilePathToUpgrade = uiForm.setupUPOriginalFilePathTextBox.Text;
            string hostFilePathForUpgrade = uiForm.setupUPUpgradedFilePathSetTextBox.Text + "\\" + uiForm.setupUPUpgradedFilePathUserTextBox.Text + ".rvt";

            if (File.Exists(hostFilePathForUpgrade))
            {
                MessageBox.Show("A file already exists with the name and location specified for the upgrade of the host Revit project file");
            }
            else if(uiForm.setupUPUpgradedFilePathUserTextBox.Text == "")
            {
                MessageBox.Show("No location for the upgraded of the host Revit project file is set");
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        if (dgv.Rows[i].Cells["Upgrade"].Value != null)
                        {
                            if (dgv.Rows[i].Cells["Allow Upgrade"].Value.ToString() == "True" && dgv.Rows[i].Cells["Upgrade"].Value.ToString() == "True")
                            {
                                string linkFilePathToUpgrade = dgv.Rows[i].Cells["Original Path"].Value.ToString();
                                string linkFilePathForUpgrade = dgv.Rows[i].Cells["New Path"].Value.ToString();
                                bool linkResult = RVTOperations.UpgradeRevitFile(uiApp, linkFilePathToUpgrade, linkFilePathForUpgrade,false);
                                if (linkResult == true)
                                {
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = true;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
                                }
                                else
                                {
                                    dgv.Rows[i].Cells["Upgrade Result"].Value = false;
                                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                        else { continue; }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    
                }

                bool hostResult = RVTOperations.UpgradeRevitFile(uiApp, hostFilePathToUpgrade, hostFilePathForUpgrade,false);
                int countOfUpgradeLinks = 0;                   
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    try
                    {
                        if (row.Cells["Upgrade"].Value != null)
                        {
                            if (row.Cells["Upgrade"].Value.ToString() == "True")
                            {
                                countOfUpgradeLinks++;
                            }
                        }
                    }
                    catch { continue; }                                           
                }                

                if (hostResult == true)
                {                    
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.GreenYellow;
                    if (countOfUpgradeLinks > 0)
                    {
                        try
                        {
                            RVTDocument hostDoc = RVTOperations.OpenRevitFile(uiApp,hostFilePathForUpgrade);
                            Dictionary<string,RevitLinkType> linkNames = new Dictionary<string, RevitLinkType>();
                            var linkTypes = new FilteredElementCollector(hostDoc).OfClass(typeof(RevitLinkType)).ToElements();
                            foreach(RevitLinkType linkType in linkTypes)
                            {
                                linkNames.Add(linkType.Name.Replace(".rvt",""),linkType);
                            }

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                try
                                {
                                    if (row.Cells["Upgrade"].Value.ToString() == "True" &&
                                        row.Cells["Upgrade Result"].Value.ToString() == "True" &&
                                        File.Exists(row.Cells["New Path"].Value.ToString()) &&
                                        linkNames.Keys.Contains(row.Cells["Original Name"].Value.ToString()))
    {
                                        try
                                        {

                                            RevitLinkType linkToReload = linkNames[row.Cells["Original Name"].Value.ToString().Replace(".rvt", "")];
                                            ModelPath modelPathToLoadFrom = ModelPathUtils.ConvertUserVisiblePathToModelPath(row.Cells["New Path"].Value.ToString());
                                            linkToReload.LoadFrom(modelPathToLoadFrom, new WorksetConfiguration());
                                        }
                                        catch (Exception e)
                                        {
                                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                                            MessageBox.Show(String.Format("Could not remap the link named {0} in the host file", row.Cells["Original Name"].Value.ToString()));
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                }
                                catch { continue; }
                                
                            }
                            RVTOperations.SaveRevitFile(uiApp,hostDoc);
                        }
                        catch (Exception e) { MessageBox.Show(e.ToString()); }
                    }
                }
                else
                {
                    uiForm.setupUPOriginalFilePathTextBox.BackColor = System.Drawing.Color.Red;
                }                             
                uiForm.Update();
                uiForm.Refresh();
            }           
        }

        // ADMIN TAB
        public void AdminDataGFFRun(UIApplication uiApp, String text)
        {            
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;            
            DataTable dt = new DataTable();
            List<string> itemsToCollect = uiForm.adminDataGFFItemsToCollect;
            int statementSelect = -1;
            uiForm.adminDataGFFDataProgressBar.Value = 0;

            if (itemsToCollect.Contains("Family Name"))
            {   DataColumn familyNameColumn = dt.Columns.Add("FamilyName", typeof(String)); }

            if (itemsToCollect.Contains("Family Size"))
            {   DataColumn familySizeColumn = dt.Columns.Add("FamilySize", typeof(Double)); }

            if (itemsToCollect.Contains("Date Last Modified"))
            {   DataColumn dateLastModifiedColumn = dt.Columns.Add("DateLastModified", typeof(String)); }

            if (itemsToCollect.Contains("Revit Version"))
            {   DataColumn revitVersionColumn = dt.Columns.Add("RevitVersion", typeof(String));
                statementSelect = 0; }

            if (itemsToCollect.Contains("Family Category"))
            {   DataColumn familyCategoryColumn = dt.Columns.Add("FamilyCategory", typeof(String));
                statementSelect = 0; }

            if (itemsToCollect.Contains("Family Types"))
            {   DataColumn familyTypeColumn = dt.Columns.Add("FamilyType", typeof(String));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Name"))
            {   DataColumn parameterNameColumn = dt.Columns.Add("ParameterName", typeof(String));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Group"))
            {   DataColumn parameterGroupColumn = dt.Columns.Add("ParameterGroup", typeof(String));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Type"))
            {   DataColumn parameterTypeColumn = dt.Columns.Add("ParameterType", typeof(String));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Value"))
            {   DataColumn parameterValueIntegerColumn = dt.Columns.Add("ParameterValueInteger", typeof(Int32));
                DataColumn parameterValueDoubleColumn = dt.Columns.Add("ParameterValueDouble", typeof(Double));
                DataColumn parameterValueStringColumn = dt.Columns.Add("ParameterValueString", typeof(String));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Is Instance"))
            {   DataColumn parameterIsInstanceColumn = dt.Columns.Add("ParameterIsInstance", typeof(Boolean));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter Is Shared"))
            {    DataColumn parameterIsSharedColumn = dt.Columns.Add("ParameterIsShared", typeof(Boolean));
                statementSelect = 1; }

            if (itemsToCollect.Contains("Parameter GUID"))
            {   DataColumn parameterGUIDColumn = dt.Columns.Add("ParameterGUID", typeof(String));
                statementSelect = 1; }

            int filesToProcess = uiForm.adminDataGFFFiles.Count;
            uiForm.adminDataGFFDataProgressBar.Minimum = 0;
            uiForm.adminDataGFFDataProgressBar.Maximum = filesToProcess;
            uiForm.adminDataGFFDataProgressBar.Step = 1;
            uiForm.adminDataGFFDataProgressBar.Visible = true;

            foreach (string filePath in uiForm.adminDataGFFFiles)
            {
                uiForm.adminDataGFFDataProgressBar.PerformStep();
                if (statementSelect == -1)
                {
                    DataRow row = dt.NewRow();
                    if (dt.Columns.Contains("FamilyName"))
                    { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }

                    if (dt.Columns.Contains("FamilySize"))
                    { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }

                    if (dt.Columns.Contains("DateLastModified"))
                    { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }

                    dt.Rows.Add(row);
                }

                else if (statementSelect == 0)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) >= rvtNumber)
                    {
                        DataRow row = dt.NewRow();

                        if (dt.Columns.Contains("FamilyName"))
                        { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }

                        if (dt.Columns.Contains("FamilySize"))
                        { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }

                        if (dt.Columns.Contains("DateLastModified"))
                        { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }

                        if (dt.Columns.Contains("RevitVersion"))
                        { row["RevitVersion"] = RVTOperations.GetRevitVersion(filePath); }

                        RVTDocument doc = RVTOperations.OpenRevitFile(uiApp, filePath);
                        if (dt.Columns.Contains("FamilyCategory") && doc.IsFamilyDocument)
                        { row["FamilyCategory"] = RVTOperations.GetRevitFamilyCategory(doc); }

                        doc.Close(false);
                        dt.Rows.Add(row);
                    }
                }

                else if (statementSelect == 1)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) >= rvtNumber)
                    {
                        RVTDocument doc = RVTOperations.OpenRevitFile(uiApp, filePath);
                        if (doc.IsFamilyDocument)
                        {
                            FamilyManager famMan = doc.FamilyManager;
                            FamilyTypeSet familyTypes = famMan.Types;
                            Transaction t1 = new Transaction(doc, "CycleFamilyTypes");
                            t1.Start();
                            foreach (FamilyType famType in familyTypes)
                            {
                                SubTransaction s1 = new SubTransaction(doc);
                                s1.Start();
                                famMan.CurrentType = famType;
                                s1.Commit();
                                foreach (FamilyParameter param in famMan.GetParameters())
                                {
                                    DataRow row = dt.NewRow();
                                    if (dt.Columns.Contains("FamilyName"))
                                    {
                                        try { row["FamilyName"] = GeneralOperations.GetFileName(filePath); }
                                        catch { row["FamilyName"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilySize"))
                                    {
                                        try { row["FamilySize"] = GeneralOperations.GetFileSize(filePath); }
                                        catch { row["FamilySize"] = 0; }
                                    }
                                    if (dt.Columns.Contains("DateLastModified"))
                                    {
                                        try { row["DateLastModified"] = GeneralOperations.GetFileLastModifiedDate(filePath); }
                                        catch { row["DateLastModified"] = ""; }
                                    }
                                    if (dt.Columns.Contains("RevitVersion"))
                                    {
                                        try { row["RevitVersion"] = RVTOperations.GetRevitVersion(filePath); }
                                        catch { row["RevitVersion"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilyCategory"))
                                    {
                                        try { row["FamilyCategory"] = RVTOperations.GetRevitFamilyCategory(doc); }
                                        catch { row["FamilyCategory"] = ""; }
                                    }
                                    if (dt.Columns.Contains("FamilyType"))
                                    {
                                        try { row["FamilyType"] = famType.Name.ToString(); }
                                        catch { row["FamilyType"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterName"))
                                    {
                                        try { row["ParameterName"] = param.Definition.Name; }
                                        catch { row["ParameterName"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterGroup"))
                                    {
                                        try { row["ParameterGroup"] = param.Definition.ParameterGroup.ToString(); }
                                        catch { row["ParameterGroup"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterType"))
                                    {
                                        try { row["ParameterType"] = param.Definition.ParameterType.ToString(); }
                                        catch { row["ParameterType"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueInteger") && param.StorageType == StorageType.Integer)
                                    {
                                        try { row["ParameterValueInteger"] = famType.AsInteger(param); }
                                        catch { row["ParameterValueInteger"] = 0; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueDouble") && param.StorageType == StorageType.Double)
                                    {
                                        try { row["ParameterValueDouble"] = famType.AsDouble(param); }
                                        catch { row["ParameterValueDouble"] = 0; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueString") && param.StorageType == StorageType.ElementId)
                                    {
                                        try { row["ParameterValueString"] = doc.GetElement(famType.AsElementId(param)).Name; }
                                        catch { row["ParameterValueString"] = ""; }
                                    }

                                    if (dt.Columns.Contains("ParameterValueString") && param.StorageType == StorageType.String)
                                    {
                                        try
                                        {
                                            string paramValue = famType.AsString(param);
                                            row["ParameterValueString"] = paramValue;
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                string paramValue = famType.AsValueString(param).ToString();
                                                row["ParameterValueString"] = paramValue;
                                            }
                                            catch
                                            {
                                                row["ParameterValueString"] = "";
                                            }
                                        }
                                    }

                                    if (dt.Columns.Contains("ParameterIsInstance"))
                                    {
                                        try { row["ParameterIsInstance"] = param.IsInstance; }
                                        catch { row["ParameterIsInstance"] = null; }
                                    }

                                    if (dt.Columns.Contains("ParameterIsShared"))
                                    {
                                        try { row["ParameterIsShared"] = param.IsShared; }
                                        catch { row["ParameterIsShared"] = null; }
                                    }

                                    if (dt.Columns.Contains("ParameterGUID"))
                                    {
                                        try { row["ParameterGUID"] = param.GUID.ToString(); }
                                        catch { row["ParameterGUID"] = ""; }
                                    }
                                    dt.Rows.Add(row);
                                }
                            }
                            t1.Commit();
                        }
                        doc.Close(false);
                    }
                }
                else if (statementSelect == 0 || statementSelect == 1)
                {
                    int rvtNumber = RVTOperations.GetRevitNumber(filePath);
                    if (rvtNumber != 0 && Convert.ToInt32(uiApp.Application.VersionNumber) <= rvtNumber)
                    {
                        MessageBox.Show(String.Format("{0} was saved in a newer version of Revit", System.IO.Path.GetFileNameWithoutExtension(filePath)));
                    }
                }
                else
                {
                    continue;
                }
            }
            
            uiForm.adminDataGFFDataTable = dt;
            uiForm.adminDataGFFCollectDataWaitLabel.Text = "Done!";
            uiForm.adminDataGFFDataProgressBar.Visible = false;
            uiForm.adminDataGFFItemsToCollect.Clear();
        }
        public void AdminFamiliesUFRun(UIApplication uiApp, String text)
        {
            try
            {
                MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
                RVTDocument doc = uiApp.ActiveUIDocument.Document;

                bool fullSync = uiForm.adminFamiliesUFFullSyncCheckbox.Checked;
                string currentVersion = Properties.Settings.Default.BARTRevitFamilyCurrentYear;
                string upgradedVersion = uiApp.Application.VersionNumber;
                string currentLibraryPath = Properties.Settings.Default.BARTBARevitFamilyLibraryPath;
                string upgradedLibraryPath = currentLibraryPath.Replace(currentVersion, upgradedVersion);
                if (!Directory.Exists(upgradedLibraryPath)) { Directory.CreateDirectory(upgradedLibraryPath); }

                GeneralOperations.CleanRfaBackups(currentLibraryPath);
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);

                List<string> familiesInCurrentLibrary = GeneralOperations.GetAllRvtFamilies(currentLibraryPath);
                Dictionary<string, string> currentLibraryDict = new Dictionary<string, string>();
                List<string> familiesInUpgradedLibrary = GeneralOperations.GetAllRvtFamilies(upgradedLibraryPath);
                Dictionary<string, string> upgradedLibraryDict = new Dictionary<string, string>();
                List<string> familiesToUpgrade = new List<string>();
                List<string> familiesToDelete = new List<string>();
                List<string> upgradedFamilies = new List<string>();
                List<string> deletedFamilies = new List<string>();

                string currentEvaluation = "";
                if (familiesInUpgradedLibrary.Count > 0)
                {
                    foreach (string upgradedFamilyPath in familiesInUpgradedLibrary)
                    {
                        try
                        {
                            currentEvaluation = Path.GetFileNameWithoutExtension(upgradedFamilyPath);
                            upgradedLibraryDict.Add(Path.GetFileNameWithoutExtension(upgradedFamilyPath), upgradedFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }            
                    
                foreach (string currentFamilyPath in familiesInCurrentLibrary)
                {
                    if (!currentFamilyPath.Contains("Archive") && !currentFamilyPath.Contains("Backup"))
                    {
                        try
                        {
                            currentEvaluation = Path.GetFileNameWithoutExtension(currentFamilyPath);
                            currentLibraryDict.Add(Path.GetFileNameWithoutExtension(currentFamilyPath), currentFamilyPath);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                if (familiesInUpgradedLibrary.Count > 0)
                {
                    foreach (string upgradedFamily in upgradedLibraryDict.Keys)
                    {
                        if (currentLibraryDict.Keys.Contains(upgradedFamily))
                        {
                            DateTime currentFamilyWriteTime = File.GetLastWriteTime(currentLibraryDict[upgradedFamily]);
                            DateTime upgradedFamilyWriteTime = File.GetLastWriteTime(upgradedLibraryDict[upgradedFamily]);
                            if (currentFamilyWriteTime > upgradedFamilyWriteTime)
                            {
                                familiesToUpgrade.Add(currentLibraryDict[upgradedFamily]);
                            }
                        }
                        else
                        {
                            familiesToDelete.Add(upgradedLibraryDict[upgradedFamily]);
                        }
                    }

                    foreach (string originalFamily in currentLibraryDict.Keys)
                    {
                        if (!upgradedLibraryDict.Keys.Contains(originalFamily))
                        {
                            familiesToUpgrade.Add(currentLibraryDict[originalFamily]);
                        }
                    }
                }
                else
                {
                    familiesToUpgrade = familiesInCurrentLibrary;
                }                

                foreach (string familyToUpgrade in familiesToUpgrade)
                {
                    try
                    {
                        if (RVTOperations.RevitVersionUpgradeCheck(uiApp, familyToUpgrade, true))
                        {
                            bool result = RVTOperations.UpgradeRevitFile(uiApp, familyToUpgrade, familyToUpgrade.Replace(currentVersion, upgradedVersion),true);
                            if (result == true)
                            {
                                upgradedFamilies.Add(Path.GetFileNameWithoutExtension(familyToUpgrade));
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("{0} was saved in a new version of Revit", Path.GetFileNameWithoutExtension(familyToUpgrade)));
                        }
                    }
                    catch (Exception f)
                    { MessageBox.Show(f.ToString()); }
                }

                if (fullSync)
                {
                    foreach (string familyToDelete in familiesToDelete)
                    {
                        try
                        {
                            File.Delete(familyToDelete);
                            deletedFamilies.Add(Path.GetFileNameWithoutExtension(familyToDelete));
                        }
                        catch (Exception e)
                        { MessageBox.Show(e.ToString()); }
                    }
                }

                uiForm.adminFamiliesUFUpgradedFamiliesListBox.DataSource = upgradedFamilies;
                uiForm.adminFamiliesUFDeletedFamiliesListBox.DataSource = deletedFamilies;
                GeneralOperations.CleanRfaBackups(upgradedLibraryPath);
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            }
            
        }
        public void AdminFamiliesBAPRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;
            Dictionary<string, ExternalDefinition> sharedParameterDefinitions = new Dictionary<string, ExternalDefinition>();
            DefinitionGroups sharedParameterGroups = uiApp.Application.OpenSharedParameterFile().Groups;
            foreach (DefinitionGroup group in sharedParameterGroups)
            {
                foreach (ExternalDefinition definition in group.Definitions)
                {
                    if (!sharedParameterDefinitions.Keys.Contains(definition.Name))
                    {
                        sharedParameterDefinitions.Add(definition.Name, definition);
                    }                    
                }
            }

            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                if(rowCount.Cells[0].Value.ToString()=="True")
                {
                    filesToProcess++;
                }
            }

            uiForm.adminFamiliesBAPProgressBar.Value = 0;            
            uiForm.adminFamiliesBAPProgressBar.Minimum = 0;
            uiForm.adminFamiliesBAPProgressBar.Maximum = filesToProcess;
            uiForm.adminFamiliesBAPProgressBar.Step = 1;
            uiForm.adminFamiliesBAPProgressBar.Visible = true;

            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            foreach (DataGridViewRow row in uiForm.adminFamiliesBAPFamiliesDGV.Rows)
            {
                string filePath = row.Cells[2].Value.ToString();
                List<string> famParamNames = new List<string>();
                string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);

                if (row.Cells[0].Value.ToString() == "True" && Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
                {
                    RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                    if (famDoc.IsFamilyDocument)
                    {
                        FamilyManager familyManager = famDoc.FamilyManager;
                        foreach (FamilyParameter famParam in familyManager.Parameters)
                        {
                            if (!famParamNames.Contains(famParam.Definition.Name))
                            {
                                famParamNames.Add(famParam.Definition.Name);
                            }
                            else { continue; }
                        }
                        foreach (DataGridViewRow newParamRow in uiForm.adminFamiliesBAPParametersDGV.Rows)
                        {
                            try
                            {
                                string name = newParamRow.Cells[1].Value.ToString();
                                BuiltInParameterGroup group = RVTOperations.GetBuiltInParameterGroupFromString(newParamRow.Cells[3].Value.ToString());
                                ParameterType type = RVTOperations.GetParameterTypeFromString(newParamRow.Cells[2].Value.ToString());
                                bool isInstance = Convert.ToBoolean(newParamRow.Cells[4].Value.ToString());
                                bool isShared = false;
                                try
                                {
                                    isShared = Convert.ToBoolean(newParamRow.Cells[0].Value.ToString());
                                }
                                catch { isShared = false; }

                                if (isShared == true && !famParamNames.Contains(name))
                                {
                                    using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                    {
                                        t.Start();
                                        ExternalDefinition definition = sharedParameterDefinitions[newParamRow.Cells[1].Value.ToString()];
                                        FamilyParameter newParam = familyManager.AddParameter(definition, group, isInstance);
                                        t.Commit();
                                    }
                                }
                                else if (isShared != true && !famParamNames.Contains(name))
                                {
                                    using (Transaction t = new Transaction(famDoc, "Add Parameter"))
                                    {
                                        t.Start();
                                        FamilyParameter newParam = familyManager.AddParameter(name, group, type, isInstance);
                                        t.Commit();
                                    }
                                }
                                else { MessageBox.Show(String.Format("Could not make parameter '{0}' because it already exists.", name)); }
                            }
                            catch { continue; }

                        }
                        ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                        famDoc.SaveAs(filePath, saveAsOptions);
                    }
                    famDoc.Close(false);
                }
                else { continue; }
                uiForm.adminFamiliesBAPProgressBar.PerformStep();
            }
            uiForm.adminFamiliesBAPProgressBar.Visible = false;
        }
        public void AdminFamiliesBRPRun(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;

            int filesToProcess = 0;
            foreach (DataGridViewRow rowCount in uiForm.adminFamiliesBRPFamiliesDGV.Rows)
            {
                if (rowCount.Cells[0].Value.ToString() == "True")
                {
                    filesToProcess++;
                }
            }
            uiForm.adminFamiliesBRPProgressBar.Value = 0;
            uiForm.adminFamiliesBRPProgressBar.Minimum = 0;
            uiForm.adminFamiliesBRPProgressBar.Maximum = filesToProcess;
            uiForm.adminFamiliesBRPProgressBar.Step = 1;
            uiForm.adminFamiliesBRPProgressBar.Visible = true;

            uiForm.adminFamiliesBAPParametersDGV.EndEdit();
            foreach (DataGridViewRow row in uiForm.adminFamiliesBRPFamiliesDGV.Rows)
            {
                string filePath = row.Cells[2].Value.ToString();
                Dictionary<string, FamilyParameter> famParams = new Dictionary<string, FamilyParameter>();
                string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                string rvtNumber = rvtVersion.Substring(rvtVersion.Length - 4);
                if (row.Cells[0].Value.ToString() == "True" && Convert.ToDouble(uiApp.Application.VersionNumber) >= Convert.ToDouble(rvtNumber))
                {
                    RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, filePath);
                    if (famDoc.IsFamilyDocument)
                    {
                        bool saveFamily = false;
                        FamilyManager familyManager = famDoc.FamilyManager;
                        foreach (FamilyParameter famParam in familyManager.Parameters)
                        {
                            if (!famParams.Keys.Contains(famParam.Definition.Name))
                            {
                                famParams.Add(famParam.Definition.Name,famParam);
                            }
                            else { continue; }

                        }
                        foreach (DataGridViewRow paramRow in uiForm.adminFamiliesBRPParametersDGV.Rows)
                        {
                            try
                            {
                                string name = paramRow.Cells[0].Value.ToString();
                                try
                                {
                                    if (famParams.Keys.Contains(name))
                                    {
                                        using (Transaction t = new Transaction(famDoc, "Remove Parameter"))
                                        {
                                            t.Start();
                                            familyManager.RemoveParameter(famParams[name]);
                                            t.Commit();
                                            saveFamily = true;
                                        }
                                    }
                                }
                                catch {continue; }
                            }
                            catch { continue; }                            
                        }
                        if (saveFamily == true)
                        {
                            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
                            famDoc.SaveAs(filePath, saveAsOptions);
                        } 
                    }
                    famDoc.Close(false);
                }
                else { continue; }
                uiForm.adminFamiliesBRPProgressBar.PerformStep();
            }
            uiForm.adminFamiliesBRPProgressBar.Visible = false;
        }
        public void SetPreviewHost(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sandBoxElementHost.Child = new PreviewControl(uiApp.ActiveUIDocument.Document, uiApp.ActiveUIDocument.Document.ActiveView.Id);
            uiForm.sandBoxElementHost.Update();
        }
    } 
}