using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class MaterialsAMLRequest
    {
        public MaterialsAMLRequest(UIApplication uiApp, String text)
        {
            DataGridView dgv = BARevitTools.Application.thisApp.newMainUi.materialsAMLDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            Dictionary<string, Category> lineStyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in RVTGetElementsByCollection.DocumentLineStyles(uiApp))
            {
                lineStyleDict.Add(lineStyle.Name.Replace("ID ", ""), lineStyle);
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
                            Category newLineStyleCategory = doc.Settings.Categories.NewSubcategory(linesCategory, "ID " + row.Cells["Mark"].Value.ToString());
                            newLineStyleCategory.LineColor = revitColor;
                            newLineStyleCategory.SetLineWeight(6, GraphicsStyleType.Projection);
                            newLineStyleCategory.SetLinePatternId(solidPatternId, GraphicsStyleType.Projection);
                            doc.Regenerate();
                        }
                        catch (Exception e)
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
                newlineStyleDict.Add(lineStyle.Name.Replace("ID ", ""), lineStyle);
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
    }
}
