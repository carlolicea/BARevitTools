using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Autodesk.Revit.DB;
using RVTDocument = Autodesk.Revit.DB.Document;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BARevitTools
{    
    class RVTOperations
    {
        public static void CreateFamilyTypesFromTable(UIApplication uiApp, ProgressBar progressBar, string saveDirectory, DataGridView dgv, string familyFileToUse)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFileToUse);

            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 1;
            saveAsOptions.OverwriteExistingFile = true;

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
            progressBar.Minimum = 0;
            progressBar.Maximum = (rowsCount - 1) * (columnsCount - 1);
            progressBar.Step = 1;
            progressBar.Visible = true;
            Transaction t2 = new Transaction(newFamDoc, "MakeNewTypes");
            t2.Start();
            for (int i = 0; i < rowsCount; i++)
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
                    progressBar.PerformStep();
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
            string nonTempFamilyPath = saveDirectory + "\\" + String.Format(newFamDoc.Title).Replace("_temp", "");
            newFamDoc.SaveAs(nonTempFamilyPath, saveAsOptions);
            newFamDoc.Close();
            
            File.Delete(tempFamilyPath);
            File.Delete(tempFamilyPath.Replace(".rfa", ".0001.rfa"));
            File.Delete(nonTempFamilyPath.Replace(".rfa", ".0001.rfa"));
        }
        public static RVTDocument CreateFamilyTypesFromTable(UIApplication uiApp, ProgressBar progressBar, DataGridView dgv, string familyFileToUse)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument famDoc = RVTOperations.OpenRevitFile(uiApp, familyFileToUse);

            FamilyManager famMan = famDoc.FamilyManager;
            RVTOperations.DeleteFamilyTypes(famDoc, famMan);

            FamilyParameterSet parameters = famMan.Parameters;
            Dictionary<string, FamilyParameter> famParamDict = new Dictionary<string, FamilyParameter>();
            foreach (FamilyParameter param in parameters)
            {
                famParamDict.Add(param.Definition.Name, param);
            }
            int rowsCount = dgv.Rows.Count;
            int columnsCount = dgv.Columns.Count;

            List<string> familyTypesMade = new List<string>();
            progressBar.Minimum = 0;
            progressBar.Maximum = (rowsCount - 1) * (columnsCount - 1);
            progressBar.Step = 1;
            progressBar.Visible = true;
            Transaction t2 = new Transaction(famDoc, "MakeNewTypes");
            t2.Start();
            for (int i = 0; i < rowsCount; i++)
            {
                string newTypeName = dgv.Rows[i].Cells[0].Value.ToString();
                Dictionary<string, FamilyType> existingTypeNames = RVTOperations.GetFamilyTypeNames(famMan);
                if (!existingTypeNames.Keys.Contains(newTypeName))
                {
                    FamilyType newType = famMan.NewType(newTypeName);
                    famMan.CurrentType = newType;
                    familyTypesMade.Add(newType.Name);
                }
                else
                {
                    famMan.CurrentType = existingTypeNames[newTypeName];
                    familyTypesMade.Add(famMan.CurrentType.Name);
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
                        RVTOperations.SetFamilyParameterValue(famMan, param, paramType, paramStorageTypeString, paramValue, true);
                    }
                    progressBar.PerformStep();
                }
            }
            t2.Commit();
            Transaction t3 = new Transaction(famDoc, "DeleteOldTypes");
            t3.Start();
            foreach (FamilyType type in famMan.Types)
            {
                if (!familyTypesMade.Contains(type.Name))
                {
                    famMan.CurrentType = type;
                    famMan.DeleteCurrentType();
                }
            }
            t3.Commit();
            return famDoc;
        }
        public static void DeleteFamilyTypes(RVTDocument famDoc, FamilyManager famMan)
        {
            int numberOfPreExistingTypes = famMan.Types.Size;
            if (numberOfPreExistingTypes >1)
            {
                Transaction t1 = new Transaction(famDoc, "DeletePreExistingTypes");
                t1.Start();
                foreach (FamilyType type in famMan.Types)
                {
                    try
                    {
                        famMan.DeleteCurrentType();
                    }
                    catch { break; }
                }
                t1.Commit();
            }            
        }
        public static void DeleteParts(UIApplication uiApp, RVTDocument doc, ElementId elementId)
        {
            doc.Delete(PartUtils.GetAssociatedPartMaker(uiApp.ActiveUIDocument.Document, elementId).Id);
        }
        public static BuiltInParameterGroup GetBuiltInParameterGroupFromString(string groupName)
        {
            BuiltInParameterGroup group = BuiltInParameterGroup.INVALID;
            switch (groupName)
            {
                case "Analysis Results":
                    group = BuiltInParameterGroup.PG_ANALYSIS_RESULTS;
                    break;
                case "Analytical Alignment":
                    group = BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT;
                    break;
                case "Analytical Model":
                    group = BuiltInParameterGroup.PG_ANALYTICAL_MODEL;
                    break;
                case "Constraints":
                    group = BuiltInParameterGroup.PG_CONSTRAINTS;
                    break;
                case "Construction":
                    group = BuiltInParameterGroup.PG_CONSTRUCTION;
                    break;
                case "Data":
                    group = BuiltInParameterGroup.PG_DATA;
                    break;
                case "Dimensions":
                    group = BuiltInParameterGroup.PG_GEOMETRY;
                    break;
                case "Division Geometry":
                    group = BuiltInParameterGroup.PG_DIVISION_GEOMETRY;
                    break;
                case "Electrical":
                    group = BuiltInParameterGroup.PG_ELECTRICAL;
                    break;
                case "Electrical - Circuiting":
                    group = BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING;
                    break;
                case "Electrical - Lighting":
                    group = BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING;
                    break;
                case "Electrical - Loads":
                    group = BuiltInParameterGroup.PG_ELECTRICAL_LOADS;
                    break;
                case "Electrical Engineering":
                    group = BuiltInParameterGroup.PG_AELECTRICAL;
                    break;
                case "Energy Analysis":
                    group = BuiltInParameterGroup.PG_ENERGY_ANALYSIS;
                    break;
                case "Fire Protection":
                    group = BuiltInParameterGroup.PG_FIRE_PROTECTION;
                    break;
                case "Forces":
                    group = BuiltInParameterGroup.PG_FORCES;
                    break;
                case "General":
                    group = BuiltInParameterGroup.PG_GENERAL;
                    break;
                case "Graphics":
                    group = BuiltInParameterGroup.PG_GRAPHICS;
                    break;
                case "Green Building Properties":
                    group = BuiltInParameterGroup.PG_GREEN_BUILDING;
                    break;
                case "Identity Data":
                    group = BuiltInParameterGroup.PG_IDENTITY_DATA;
                    break;
                case "IFC Parameters":
                    group = BuiltInParameterGroup.PG_IFC;
                    break;
                case "Materials and Finishes":
                    group = BuiltInParameterGroup.PG_MATERIALS;
                    break;
                case "Mechanical":
                    group = BuiltInParameterGroup.PG_MECHANICAL;
                    break;
                case "Mechanical - Flow":
                    group = BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW;
                    break;
                case "Mechanical - Loads":
                    group = BuiltInParameterGroup.PG_MECHANICAL_LOADS;
                    break;
                case "Model Properties":
                    group = BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES;
                    break;
                case "Moments":
                    group = BuiltInParameterGroup.PG_MOMENTS;
                    break;
                case "Other":
                    group = BuiltInParameterGroup.INVALID;
                    break;
                case "Overall Legend":
                    group = BuiltInParameterGroup.PG_OVERALL_LEGEND;
                    break;
                case "Phasing":
                    group = BuiltInParameterGroup.PG_PHASING;
                    break;
                case "Photometrics":
                    group = BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS;
                    break;
                case "Plumbing":
                    group = BuiltInParameterGroup.PG_PLUMBING;
                    break;
                case "Primary End":
                    group = BuiltInParameterGroup.PG_PRIMARY_END;
                    break;
                case "Rebar Set":
                    group = BuiltInParameterGroup.PG_REBAR_ARRAY;
                    break;
                case "Releases / Member Forces":
                    group = BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES;
                    break;
                case "Secondary End":
                    group = BuiltInParameterGroup.PG_SECONDARY_END;
                    break;
                case "Segments and Fittings":
                    group = BuiltInParameterGroup.PG_SEGMENTS_FITTINGS;
                    break;
                case "Slab Shape Edit":
                    group = BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT;
                    break;
                case "Structural":
                    group = BuiltInParameterGroup.PG_STRUCTURAL;
                    break;
                case "Structural Analysis":
                    group = BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS;
                    break;
                case "Text":
                    group = BuiltInParameterGroup.PG_TEXT;
                    break;
                case "Title Text":
                    group = BuiltInParameterGroup.PG_TITLE;
                    break;
                case "Visibility":
                    group = BuiltInParameterGroup.PG_VISIBILITY;
                    break;
                default:
                    MessageBox.Show(String.Format("Could not get the BuiltInParameterGroup {0}", groupName));
                    break;
            }
            return group;
        }
        public static string GetFamilyFile()
        {
            string file = "";
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "RVT Family (*.rfa)|*rfa"
            };
            fileDialog.ShowDialog();
            if (fileDialog.FileName.ToString() != "")
            {
                file = fileDialog.FileName;
            }
            return file;
        }
        public static string GetProjectFile()
        {
            string file = "";
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "RVT Project (*.rvt)|*rvt"
            };
            fileDialog.ShowDialog();
            if (fileDialog.FileName.ToString() != "")
            {
                file = fileDialog.FileName;
            }
            return file;
        }
        public static string GetRevitVersion(string filePath)
        {
            
            if (filePath != null && filePath != "")
            {
                try
                {
                    BasicFileInfo rvtInfo = BasicFileInfo.Extract(filePath);
                    string rvtVersion = rvtInfo.SavedInVersion.ToString();
                    return rvtVersion;
                }
                catch
                {
                    string fileName = GeneralOperations.GetFileName(filePath);
                    return string.Empty;
                }
            }
            else { return string.Empty; }
        }
        public static int GetRevitNumber(string filePath)
        {
            int rvtNumber = 0;
            try
            {
                string rvtVersion = RVTOperations.GetRevitVersion(filePath);
                rvtNumber = Convert.ToInt32(rvtVersion.Substring(rvtVersion.Length - 4));
                return rvtNumber;

            }
            catch { return rvtNumber; }
        }
        public static Dictionary<string, FamilyType> GetFamilyTypeNames(FamilyManager famMan)
        {
            Dictionary<string, FamilyType> types = new Dictionary<string, FamilyType>();
            foreach (FamilyType type in famMan.Types)
            {
                types.Add(type.Name, type);
            }
            return types;
        }
        public static string GetNameFromBuiltInParameterGroup(BuiltInParameterGroup paramGroup)
        {
            string group = "Other";
            switch (paramGroup)
            {
                case BuiltInParameterGroup.PG_ANALYSIS_RESULTS:
                    group = "Analysis Results";
                    break;
                case BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT:
                    group = "Analytical Alignment";
                    break;
                case BuiltInParameterGroup.PG_ANALYTICAL_MODEL:
                    group = "Analytical Model";
                    break;
                case BuiltInParameterGroup.PG_CONSTRAINTS:
                    group = "Constraints";
                    break;
                case BuiltInParameterGroup.PG_CONSTRUCTION:
                    group = "Construction";
                    break;
                case BuiltInParameterGroup.PG_DATA:
                    group = "Data";
                    break;
                case BuiltInParameterGroup.PG_GEOMETRY:
                    group = "Dimensions";
                    break;
                case BuiltInParameterGroup.PG_DIVISION_GEOMETRY:
                    group = "Division Geometry";
                    break;
                case BuiltInParameterGroup.PG_ELECTRICAL:
                    group = "Electrical";
                    break;
                case BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING:
                    group = "Electrical - Circuiting";
                    break;
                case BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING:
                    group = "Electrical - Lighting";
                    break;
                case BuiltInParameterGroup.PG_ELECTRICAL_LOADS:
                    group = "Electrical - Loads";
                    break;
                case BuiltInParameterGroup.PG_AELECTRICAL:
                    group = "Electrical Engineering";
                    break;
                case BuiltInParameterGroup.PG_ENERGY_ANALYSIS:
                    group = "Energy Analysis";
                    break;
                case BuiltInParameterGroup.PG_FIRE_PROTECTION:
                    group = "Fire Protection";
                    break;
                case BuiltInParameterGroup.PG_FORCES:
                    group = "Forces";
                    break;
                case BuiltInParameterGroup.PG_GENERAL:
                    group = "General";
                    break;
                case BuiltInParameterGroup.PG_GRAPHICS:
                    group = "Graphics";
                    break;
                case BuiltInParameterGroup.PG_GREEN_BUILDING:
                    group = "Green Building Properties";
                    break;
                case BuiltInParameterGroup.PG_IDENTITY_DATA:
                    group = "Identity Data";
                    break;
                case BuiltInParameterGroup.PG_IFC:
                    group = "IFC Parameters";
                    break;
                case BuiltInParameterGroup.PG_MATERIALS:
                    group = "Materials and Finishes";
                    break;
                case BuiltInParameterGroup.PG_MECHANICAL:
                    group = "Mechanical";
                    break;
                case BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW:
                    group = "Mechanical - Flow";
                    break;
                case BuiltInParameterGroup.PG_MECHANICAL_LOADS:
                    group = "Mechanical - Loads";
                    break;
                case BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES:
                    group = "Model Properties";
                    break;
                case BuiltInParameterGroup.PG_MOMENTS:
                    group = "Moments";
                    break;
                case BuiltInParameterGroup.INVALID:
                    group = "Other";
                    break;
                case BuiltInParameterGroup.PG_OVERALL_LEGEND:
                    group = "Overall Legend";
                    break;
                case BuiltInParameterGroup.PG_PHASING:
                    group = "Phasing";
                    break;
                case BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS:
                    group = "Photometrics";
                    break;
                case BuiltInParameterGroup.PG_PLUMBING:
                    group = "Plumbing";
                    break;
                case BuiltInParameterGroup.PG_PRIMARY_END:
                    group = "Primary End";
                    break;
                case BuiltInParameterGroup.PG_REBAR_ARRAY:
                    group = "Rebar Set";
                    break;
                case BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES:
                    group = "Releases / Member Forces";
                    break;
                case BuiltInParameterGroup.PG_SECONDARY_END:
                    group = "Secondary End";
                    break;
                case BuiltInParameterGroup.PG_SEGMENTS_FITTINGS:
                    group = "Segments and Fittings";
                    break;
                case BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT:
                    group = "Slab Shape Edit";
                    break;
                case BuiltInParameterGroup.PG_STRUCTURAL:
                    group = "Structural";
                    break;
                case BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS:
                    group = "Structural Analysis";
                    break;
                case BuiltInParameterGroup.PG_TEXT:
                    group = "Text";
                    break;
                case BuiltInParameterGroup.PG_TITLE:
                    group = "Title Text";
                    break;
                case BuiltInParameterGroup.PG_VISIBILITY:
                    group = "Visibility";
                    break;
                default:
                    break;
            }
            return group;
        }
        public static ParameterType GetParameterTypeFromString(string typeName)
        {
            ParameterType type = ParameterType.Invalid;
            switch (typeName)
            {
                case "Text":
                    type = ParameterType.Text;
                    break;
                case "Integer":
                    type = ParameterType.Integer;
                    break;
                case "Number":
                    type = ParameterType.Number;
                    break;
                case "Length":
                    type = ParameterType.Length;
                    break;
                case "Area":
                    type = ParameterType.Area;
                    break;
                case "Volume":
                    type = ParameterType.Volume;
                    break;
                case "Angle":
                    type = ParameterType.Angle;
                    break;
                case "Slope":
                    type = ParameterType.Slope;
                    break;
                case "Currencey":
                    type = ParameterType.Currency;
                    break;
                case "Mass Density":
                    type = ParameterType.MassDensity;
                    break;
                case "URL":
                    type = ParameterType.URL;
                    break;
                case "Material":
                    type = ParameterType.Material;
                    break;
                case "Image":
                    type = ParameterType.Image;
                    break;
                case "Yes/No":
                    type = ParameterType.YesNo;
                    break;
                case "Multiline Text":
                    type = ParameterType.MultilineText;
                    break;
                case "<Family Type...>":
                    type = ParameterType.FamilyType;
                    break;
                default:
                    type = ParameterType.Invalid;
                    break;
            }
            return type;
        }
        
        public static string GetRevitFamilyCategory(RVTDocument doc)
        {
            string familyCategory = null;
            if (doc.IsFamilyDocument)
            {
                try
                {
                    Family ownerFamily = doc.OwnerFamily;
                    familyCategory = ownerFamily.FamilyCategory.Name.ToString();
                }
                catch
                {
                    string filePath = doc.PathName;
                    string fileName = GeneralOperations.GetFileName(filePath);
                    MessageBox.Show(string.Format("Could not get the Revit family category for {0}", fileName));
                }
            }
            return familyCategory;
        }
        public static string GetVersionedFamilyFilePath(UIApplication uiApp, string familyFileToUse)
        {
            string versionedFamilyFile = familyFileToUse.Replace(Properties.Settings.Default.BARTRevitFamilyCurrentYear, uiApp.Application.VersionNumber);
            if (!File.Exists(versionedFamilyFile))
            {
                MessageBox.Show(String.Format("Could not find the family file '{0}'. Please navigate to it in the following window", versionedFamilyFile));
                string file = GeneralOperations.GetFile();
                if (file != "")
                {
                    versionedFamilyFile = file;
                }
                else
                {
                    versionedFamilyFile = "";
                }
            }
            return versionedFamilyFile;
        }
        public static RVTDocument OpenRevitFile(UIApplication uiApp, string filePath)
        {
            RVTDocument doc = null;
            string fileExtension = GeneralOperations.GetFileExtension(filePath);
            string fileName = GeneralOperations.GetFileName(filePath);
            if (fileExtension.ToLower() == ".rvt" || fileExtension.ToLower() == ".rfa")
            {
                try
                {
                    doc = uiApp.Application.OpenDocumentFile(filePath);
                }
                catch
                {
                    MessageBox.Show(string.Format("{0} is a Revit file, but could not be opened", fileName));
                }
            }
            else
            {
                MessageBox.Show(string.Format("{0} is not a Revit file", fileName));
            }
            return doc;
        }
        public static void PlaceSymbolsInView(UIApplication uiApp, RVTDocument famDoc, string groupingParameter, string subgroupingParameter, Autodesk.Revit.DB.View placementView)
        {            
            try
            {
                IFamilyLoadOptions loadOptions = new RVTFamilyLoadOptions();
                RVTDocument doc = uiApp.ActiveUIDocument.Document;
                famDoc.LoadFamily(doc,loadOptions);

                Transaction t = new Transaction(doc, "LoadMaterialSymbolsFamily");
                t.Start();

                placementView.Scale = 1;                
                Dictionary<Element, string> familyTypesDict = new Dictionary<Element, string>();
                List<Element> familyTypesList = new List<Element>();
                Family refFamily = new FilteredElementCollector(doc).OfClass(typeof(Family)).WhereElementIsNotElementType().Cast<Family>().Where(elem => elem.Name == famDoc.Title.Replace(".rfa","")).First();
                famDoc.Close(false);
                foreach (ElementId symbId in refFamily.GetFamilySymbolIds())
                {
                    FamilySymbol familySymbol = doc.GetElement(symbId) as FamilySymbol;
                    string paramValue = familySymbol.GetParameters(groupingParameter).First().AsString();
                    familyTypesList.Add(familySymbol);
                    familyTypesDict.Add(familySymbol, paramValue);
                }
                var familyTypesGroupedQuery =
                     from elemSymbol in familyTypesList
                     orderby elemSymbol.GetParameters(subgroupingParameter).First().AsString() ascending
                     group elemSymbol by elemSymbol.GetParameters(groupingParameter).First().AsString() into mainGroup
                     orderby mainGroup.First().GetParameters(groupingParameter).First().AsString() descending
                     select mainGroup;

                double spacing = 0.08333;
                int rowNum = 0;
                foreach (var mainGroup in familyTypesGroupedQuery)
                {
                    int columnNum = 0;
                    foreach (FamilySymbol symbol in mainGroup)
                    {
                        doc.Create.NewFamilyInstance(new XYZ(Convert.ToDouble(columnNum) * spacing, Convert.ToDouble(rowNum) * spacing, 0), symbol, placementView);
                        columnNum++;
                    }
                    rowNum++;
                }
                t.Commit();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
        public static TransmissionData ReloadLinks(string filePath)
        {

            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
            try
            {
                TransmissionData transmissionData = TransmissionData.ReadTransmissionData(modelPath);
                if (transmissionData != null)
                {
                    ICollection<ElementId> externalFileReferences = transmissionData.GetAllExternalFileReferenceIds();
                    foreach (ElementId elemId in externalFileReferences)
                    {
                        ExternalFileReference exRef = transmissionData.GetLastSavedReferenceData(elemId);
                        if (exRef.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink)
                        {
                            transmissionData.SetDesiredReferenceData(elemId, modelPath, PathType.Absolute, true);
                        }
                    }
                }
                transmissionData.IsTransmitted = false;
                TransmissionData.WriteTransmissionData(modelPath, transmissionData);
                return transmissionData;
            }
            catch
            {
                return null;
            }
        }
        public static bool RevitVersionUpgradeCheck(UIApplication uiApp, string filePath)
        {
            bool result = false;
            int projectRevitNumber = RVTOperations.GetRevitNumber(filePath);
            if (projectRevitNumber < Convert.ToInt32(uiApp.Application.VersionNumber))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool RevitVersionUpgradeCheck(UIApplication uiApp, string filePath, bool equalVersion)
        {
            bool result = false;
            int projectRevitNumber = RVTOperations.GetRevitNumber(filePath);
            if (projectRevitNumber <= Convert.ToInt32(uiApp.Application.VersionNumber))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool SaveRevitFile(UIApplication uiApp, RVTDocument doc, bool close)
        {
            bool result = false;
            TransactWithCentralOptions TWCOptions = new TransactWithCentralOptions();
            RelinquishOptions relinquishOptions = new RelinquishOptions(true);
            SynchronizeWithCentralOptions SWCOptions = new SynchronizeWithCentralOptions();
            SWCOptions.Compact = true;
            SWCOptions.SetRelinquishOptions(relinquishOptions);
            WorksharingSaveAsOptions worksharingSaveOptions = new WorksharingSaveAsOptions();
            worksharingSaveOptions.SaveAsCentral = true;
            SaveOptions saveOptions = new SaveOptions();
            saveOptions.Compact = true;
            SaveAsOptions saveAsOptions = new SaveAsOptions();
            saveAsOptions.Compact = true;
            saveAsOptions.MaximumBackups = 3;
            saveAsOptions.OverwriteExistingFile = true;

            try
            {
                if (doc.IsFamilyDocument)
                {
                    try
                    {
                        doc.SaveAs(doc.PathName,saveAsOptions);
                        result = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);                        
                    }
                }
                else
                {
                    try
                    {
                        SetLinksToOverlay(doc);
                        if (doc.IsWorkshared)
                        {
                            doc.Save(saveOptions);
                            doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                        }
                        else
                        {
                            doc.EnableWorksharing("Shared Levels and Grids", "Workset1");
                            doc.Save(saveOptions);
                            doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                        }
                        result = true;
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); doc.Close(); }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (close == true)
                {
                    doc.Close(false);
                }
            }
            return result;
        }
        public static ElementId SelectElement(UIApplication uiApp)
        {
            ElementId elementId = null;
            Selection selection = uiApp.ActiveUIDocument.Selection;
            Reference elemReference = selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            if (elemReference != null)
            {
                elementId = elemReference.ElementId;
            }
            return elementId;
        }
        public static List<Room> SelectRoomElements(UIApplication uiApp)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            List<Element> selectedElements = new List<Element>();
            IList<Reference> elemReferences = new List<Reference>();

            try
            {
                elemReferences = uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element).Distinct().ToList();
                foreach (Reference selectedReference in elemReferences)
                {
                    ElementId referenceId = selectedReference.ElementId;
                    Element referenceElement = uidoc.Document.GetElement(referenceId);
                    selectedElements.Add(referenceElement);
                }

                Dictionary<int,Room> roomIdsDict = new Dictionary<int,Room>();
                foreach (Element element in selectedElements)
                {
                    if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.Room")
                    {
                        Room room = element as Room;
                        if (!roomIdsDict.Keys.Contains(room.Id.IntegerValue))
                        {
                            roomIdsDict[room.Id.IntegerValue] = room;
                        }
                    }
                    else if (element.GetType().ToString() == "Autodesk.Revit.DB.Architecture.RoomTag")
                    {
                        RoomTag tag = element as RoomTag;
                        Room tagRoom = tag.Room;
                        if (!roomIdsDict.Keys.Contains(tag.Room.Id.IntegerValue))
                        {
                            roomIdsDict[tag.Room.Id.IntegerValue] = tagRoom;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                List<Room> selectedRoomElements = new List<Room>();
                foreach (int key in roomIdsDict.Keys)
                {
                    selectedRoomElements.Add(roomIdsDict[key]);
                }
                return selectedRoomElements;
            }
            catch
            {
                return null;
            }
        }
        public static void SetFamilyParameterValue(FamilyManager famMan, FamilyParameter param, ParameterType paramType, string paramStorageTypeString, object paramValue, bool convertInchestoFeet)
        {
            try
            {
                if (paramStorageTypeString == "Integer")
                {
                    famMan.Set(param, Convert.ToInt32(paramValue));
                }
                else if (paramStorageTypeString == "Double")
                {
                    if (paramType.ToString() == "Length" && convertInchestoFeet == true)
                    {
                        famMan.Set(param, Convert.ToDouble(paramValue) / 12d);
                    }
                    else if (paramType.ToString() == "Length" && convertInchestoFeet == false)
                    {
                        famMan.Set(param, Convert.ToDouble(paramValue));
                    }
                    else
                    {
                        famMan.Set(param, Convert.ToDouble(paramValue));
                    }
                }
                else if (paramStorageTypeString == "ElementId")
                {
                    famMan.Set(param, new ElementId(Convert.ToInt32(paramValue)));
                }
                else
                {
                    famMan.Set(param, Convert.ToString(paramValue));
                }
            }
            catch { MessageBox.Show(String.Format("Could not set parameter ({0}) with value ({1}) for type ({2})", param.Definition.Name, paramValue.ToString(), famMan.CurrentType.Name)); }
        }
        public static void SetFamilyParameterValue(FamilyManager famMan, FamilyParameter param, object paramValue)
        {
            string paramStorageTypeString = param.StorageType.ToString();
            try
            {
                if (paramStorageTypeString == "Integer")
                {
                    famMan.Set(param, Convert.ToInt32(paramValue));
                }
                else if (paramStorageTypeString == "Double")
                {
                    famMan.Set(param, Convert.ToDouble(paramValue) / 12d);
                }
                else if (paramStorageTypeString == "ElementId")
                {
                    famMan.Set(param, new ElementId(Convert.ToInt32(paramValue)));
                }
                else
                {
                    famMan.Set(param, Convert.ToString(paramValue));
                }
            }
            catch { MessageBox.Show(String.Format("Could not set parameter {0} with value {1}", param.Definition.Name, paramValue.ToString())); }
        }
        public static void SetLinksToOverlay(RVTDocument doc)
        {
            var linkTypes = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkType)).ToElements();

            Transaction t = new Transaction(doc, "SetLinksToOverlay");
            t.Start();
            try
            {
                foreach (Element elem in linkTypes)
                {
                    RevitLinkType linkType = elem as RevitLinkType;
                    linkType.AttachmentType = AttachmentType.Overlay;
                }
                t.Commit();
            }
            catch
            {
                t.RollBack();
            }
        }
        public static object SetParameterValueFromString(string typeName, object value)
        {
            object returnValue = null;
            switch (typeName)
            {
                case "Text":
                    returnValue = Convert.ToString(value);
                    break;
                case "Integer":
                    returnValue = Convert.ToInt32(value);
                    break;
                case "Number":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Length":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Area":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Volume":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Angle":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Slope":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Currencey":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "Mass Density":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "URL":
                    returnValue = Convert.ToString(value);
                    break;
                case "Material":
                    returnValue = new ElementId(Convert.ToInt32(value));
                    break;
                case "Image":
                    returnValue = ParameterType.Image;
                    break;
                case "Yes/No":
                    if (Convert.ToBoolean(value) == true)
                    { returnValue = 1; }
                    else if (Convert.ToBoolean(value) == false)
                    { returnValue = 0; }
                    else
                    { returnValue = null; }
                    break;
                case "Multiline Text":
                    returnValue = Convert.ToString(value);
                    break;
                case "<Family Type...>":
                    returnValue = new ElementId(Convert.ToInt32(value));
                    break;
                default:
                    returnValue = ParameterType.Invalid;
                    break;
            }
            return returnValue;
        }
        public static string SetProjectUpgradeName(UIApplication uiApp, string originalFilePath)
        {
            
            string upgradeFileName = String.Empty;
            string[] lettersToCheck = new string[] { "A", "a", "V", "v", "R", "r", "S", "s", "M", "m", "E", "e", "P", "p" };
            List<string> tags = new List<string>();
            string originalFileName = Path.GetFileNameWithoutExtension(originalFilePath);
            string changingFileName = Path.GetFileNameWithoutExtension(originalFilePath);

            string fileRevitVersion = Convert.ToString(RVTOperations.GetRevitNumber(originalFilePath));
            string appRevitVersion = uiApp.Application.VersionNumber;

            string fileRevitDigits = fileRevitVersion.Substring(fileRevitVersion.Length-2);
            string appRevitDigits = appRevitVersion.Substring(appRevitVersion.Length - 2);

            bool skip = false;

            foreach (string x in lettersToCheck)
            {
                tags.Add(string.Join("", x, fileRevitDigits));
            }

            foreach (string tag in tags)
            {
                string replacementTag = tag.Replace(fileRevitDigits, appRevitDigits);
                if (originalFileName.Contains(replacementTag))
                {
                    return originalFileName;
                }
                else
                {
                    changingFileName = changingFileName.Replace(tag, replacementTag);
                }                
            }

            if (skip == true)
            {
                upgradeFileName = originalFileName;
            }
            else if (changingFileName == originalFileName && skip == false)
            {
                upgradeFileName = string.Join("", originalFileName, "-A", appRevitDigits);
            }
            else
            {
                upgradeFileName = changingFileName;
            }

            return upgradeFileName;
        }
        public static TransmissionData UnloadLinks(string filePath)
        {
            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
            try
            {
                TransmissionData transmissionData = TransmissionData.ReadTransmissionData(modelPath);
                if (transmissionData != null)
                {
                    ICollection<ElementId> externalFileReferences = transmissionData.GetAllExternalFileReferenceIds();
                    foreach (ElementId elemId in externalFileReferences)
                    {
                        ExternalFileReference exRef = transmissionData.GetLastSavedReferenceData(elemId);
                        if (exRef.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink)
                        {
                            transmissionData.SetDesiredReferenceData(elemId, exRef.GetPath(), PathType.Absolute, false);
                        }
                    }
                }
                transmissionData.IsTransmitted = true;
                TransmissionData.WriteTransmissionData(modelPath, transmissionData);
                return transmissionData;
            }
            catch
            {
                return null;
            }
        }
        public static bool UpgradeRevitFile(UIApplication uiApp, string filePath, string upgradePath,bool overwrite)
        {
            bool result = false;
            if (!File.Exists(upgradePath) || overwrite == true)
            {
                TransactWithCentralOptions TWCOptions = new TransactWithCentralOptions();
                RelinquishOptions relinquishOptions = new RelinquishOptions(true);
                SynchronizeWithCentralOptions SWCOptions = new SynchronizeWithCentralOptions();
                SWCOptions.Compact = true;
                SWCOptions.SetRelinquishOptions(relinquishOptions);
                WorksharingSaveAsOptions worksharingSaveOptions = new WorksharingSaveAsOptions();
                worksharingSaveOptions.SaveAsCentral = true;
                SaveOptions saveOptions = new SaveOptions();
                saveOptions.Compact = true;
                SaveAsOptions saveAsOptions = new SaveAsOptions();
                saveAsOptions.Compact = true;
                saveAsOptions.OverwriteExistingFile = true;
                saveAsOptions.SetWorksharingOptions(worksharingSaveOptions);
                
                try
                {
                    TransmissionData transmissionData = UnloadLinks(filePath);
                    RVTDocument doc = OpenRevitFile(uiApp, filePath);
                    if (doc.IsFamilyDocument)
                    {
                        try
                        {
                            SaveAsOptions familySaveAsOptions = new SaveAsOptions();
                            familySaveAsOptions.Compact = true;
                            familySaveAsOptions.OverwriteExistingFile = true;
                            doc.SaveAs(upgradePath,familySaveAsOptions);
                            result = true;
                        }
                        catch (Exception e) { MessageBox.Show(e.Message); doc.Close(); }
                    }

                    else
                    {
                        
                        try
                        {                            
                            RVTOperations.SetLinksToOverlay(doc);
                            if (doc.IsWorkshared)
                            {
                                doc.SaveAs(upgradePath, saveAsOptions);
                                doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                                doc.Close();
                            }
                            else
                            {
                                doc.EnableWorksharing("Shared Levels and Grids", "Workset1");
                                doc.SaveAs(upgradePath, saveAsOptions);
                                doc.SynchronizeWithCentral(TWCOptions, SWCOptions);
                                doc.Close();
                            }
                            result = true;
                        }
                        catch (Exception e) { MessageBox.Show(e.Message); doc.Close(); }
                        //Write Upgraded File TransmissionData
                        ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(upgradePath);
                        TransmissionData upgradedTransmissionData = TransmissionData.ReadTransmissionData(modelPath);
                        upgradedTransmissionData.IsTransmitted = false;
                        TransmissionData.WriteTransmissionData(modelPath, upgradedTransmissionData);

                        //Write Original File TransmissionData
                        transmissionData.IsTransmitted = false;
                        TransmissionData.WriteTransmissionData(ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath), transmissionData);
                    }                                       
                }
                catch(Exception e) { MessageBox.Show(e.Message); }                             
            }        
            return result;
        }
    }

    public static class RVTGetElementsByCollection
    {
        public static List<ViewDrafting> DocumentDraftingViews(UIApplication uiApp)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            List<ViewDrafting> draftingViews = new FilteredElementCollector(doc).OfClass(typeof(ViewDrafting)).WhereElementIsNotElementType().ToElements().Cast<ViewDrafting>().ToList();
            return draftingViews;
        }
        public static List<FloorType> DocumentFloorTypes(UIApplication uiApp)
        {
            List<FloorType> floorTypes = new List<FloorType>();
            UIDocument uiDoc = uiApp.ActiveUIDocument;

            var floorTypeCollector = new FilteredElementCollector(uiDoc.Document).OfClass(typeof(FloorType)).WhereElementIsElementType().ToElements();
            foreach (Element elem in floorTypeCollector)
            {
                FloorType floorType = elem as FloorType;
                floorTypes.Add(floorType);
            }
            return floorTypes;
        }
        public static List<string> DocumentFloorTypeNames(UIApplication uiApp)
        {
            List<string> floorTypeNames = new List<string>();
            UIDocument uiDoc = uiApp.ActiveUIDocument;

            var floorTypeCollector = new FilteredElementCollector(uiDoc.Document).OfClass(typeof(FloorType)).WhereElementIsElementType().ToElements();
            foreach (Element elem in floorTypeCollector)
            {
                FloorType floorType = elem as FloorType;
                floorTypeNames.Add(floorType.Name.ToString());
            }
            return floorTypeNames;
        }
        public static CategoryNameMap DocumentLineStyles(UIApplication uiApp)
        {
            CategoryNameMap lineStyleSubCats = null;
            var lineStyles = uiApp.ActiveUIDocument.Document.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            lineStyleSubCats = lineStyles.SubCategories;
            return lineStyleSubCats;
        }
        public static List<FamilySymbol> FamilyTypesByFamilyName(UIApplication uiApp, string familyName)
        {            
            try
            {
                List<FamilySymbol> familySymbols = new List<FamilySymbol>();
                var familySymbolsCollector = new FilteredElementCollector(uiApp.ActiveUIDocument.Document).OfClass(typeof(FamilySymbol)).ToList();
                foreach (Element elem in familySymbolsCollector)
                {
                    FamilySymbol symbol = elem as FamilySymbol;
                    if (symbol.FamilyName == familyName)
                    {
                        familySymbols.Add(symbol);
                    }
                }
                return familySymbols;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }

    public class RVTDuplicateTypesHandler : IDuplicateTypeNamesHandler
    {
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs e)
        {
            return DuplicateTypeAction.UseDestinationTypes;
        }
    }
    
    public class RVTFamilyLoadOptions : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true;
        }
        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true;
        }
    }
}
