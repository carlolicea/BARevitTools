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
    //
    //This class is used to make the materials from in the Create Materials tool.
    class MaterialsCMRequest
    {
        public MaterialsCMRequest(UIApplication uiApp, String text)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            ProgressBar progressBar = uiForm.materialsCMProgressBar;
            DataGridView dgv = uiForm.materialsCMDataGridView;
            int rowsCount = dgv.Rows.Count;
            int columnsCount = dgv.Columns.Count;


            //Prepare the progress bar.
            progressBar.Minimum = 0;
            progressBar.Maximum = (rowsCount);
            progressBar.Step = 1;
            progressBar.Visible = true;

            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            progressBar.Value = 0;

            using (Transaction t = new Transaction(doc, "CreateMaterials"))
            {
                t.Start();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["Id"].Value != null && row.Cells["Id"].Value.ToString() != "")
                    {
                        try
                        {
                            ElementId elementId = new ElementId((Convert.ToInt32(row.Cells["Id"].Value)));
                            try
                            {
                                Material material = doc.GetElement(elementId) as Material;
                                material.Name = row.Cells["Name"].Value.ToString();
                                SetParameterValueFromDgvRow(row, material);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                            finally
                            {
                                progressBar.PerformStep();
                            }
                        }
                        catch
                        { continue; }
                    }
                    else
                    {
                        try
                        {
                            ElementId newMaterialId = Material.Create(doc, row.Cells["Name"].Value.ToString());
                            doc.Regenerate();
                            Material newMaterial = doc.GetElement(newMaterialId) as Material;
                            SetParameterValueFromDgvRow(row, newMaterial);
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        finally
                        {
                            progressBar.PerformStep();
                        }                        
                    }
                }
                t.Commit();
            }
            uiForm.materialsCMProgressBar.Visible = false;
        }

        private static void SetParameterValueFromDgvRow(DataGridViewRow row, Material material)
        {
            if(row.Cells["Description"].Value != null)
            {
                material.get_Parameter(BuiltInParameter.ALL_MODEL_DESCRIPTION).Set(row.Cells["Description"].Value.ToString());
            }
            if(row.Cells["Class"].Value != null)
            {
                material.MaterialClass = row.Cells["Class"].Value.ToString();
            }
            if(row.Cells["Comments"].Value != null)
            {
                material.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set(row.Cells["Comments"].Value.ToString());
            }
            if(row.Cells["Mark"].Value!= null)
            {
                material.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).Set(row.Cells["Mark"].Value.ToString());
            }            
        }
    }
}
