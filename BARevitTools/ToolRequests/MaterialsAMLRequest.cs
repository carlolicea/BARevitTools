using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Accent Material Lines tool for the process of creating the line styles right before the palette launches.
    class MaterialsAMLRequest
    {
        public MaterialsAMLRequest(UIApplication uiApp, String text)
        {
            DataGridView dgv = BARevitTools.Application.thisApp.newMainUi.materialsAMLDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            //Get all of the line styles in the project and assign them to a dictionary indexed by line style name
            Dictionary<string, Category> lineStyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in RVTGetElementsByCollection.DocumentLineStyles(uiApp))
            {
                lineStyleDict.Add(lineStyle.Name.Replace("ID ", ""), lineStyle);
            }

            //All new line styles will use the solid line pattern, so get that from the project
            ElementId solidPatternId = LinePatternElement.GetSolidPatternId();

            //Start the transaction to create the line styles
            Transaction t1 = new Transaction(doc, "CreateLineStyles");
            t1.Start();
            //Cycle through the rows of line styles in the MainUI form
            foreach (DataGridViewRow row in dgv.Rows)
            {
                //Get the color of the button in the row and convert it to a Revit color
                System.Drawing.Color buttonColor = row.Cells["Color"].Style.BackColor;
                Color revitColor = new Color(buttonColor.R, buttonColor.G, buttonColor.B);

                //If the Updated column cell is not null, continue
                if (row.Cells["Updated"].Value != null)
                {
                    //Assuming the user made a modification to the color for an existing line style and the Mark is part of the dictionary keys...
                    if (row.Cells["Updated"].Value.ToString() == "True" && lineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()))
                    {
                        try
                        {
                            //Get the line style by key name in the dictionary and update its line color to the one from the button
                            Category lineStyleToUpdate = lineStyleDict[row.Cells["Mark"].Value.ToString()];
                            lineStyleToUpdate.LineColor = revitColor;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }

                //If the Select column cell is not null, continue
                if (row.Cells["Select"].Value != null)
                {
                    //Assuming the user checked the box in the Select column, Mark is not emtpy, and the dictionary of line styles does not already contain a line style with the same mark name... 
                    if (row.Cells["Select"].Value.ToString() == "True" && row.Cells["Mark"].Value.ToString() != "" && !lineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()))
                    {
                        try
                        {
                            //Get the category for Lines
                            Category linesCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
                            //Make a new line style subcategory with the name of the mark value from the Mark column cell, prefixed with ID so it is easier to find during the sort
                            Category newLineStyleCategory = doc.Settings.Categories.NewSubcategory(linesCategory, "ID " + row.Cells["Mark"].Value.ToString());
                            //Set the line style's color, projection weight, and solid line pattern
                            newLineStyleCategory.LineColor = revitColor;
                            newLineStyleCategory.SetLineWeight(6, GraphicsStyleType.Projection);
                            newLineStyleCategory.SetLinePatternId(solidPatternId, GraphicsStyleType.Projection);
                            //Regenerate the document
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

            //Update the DataGridView of the MainUI with the changes and new line styles
            BARevitTools.Application.thisApp.newMainUi.MaterialsAMLUpdateDGV(dgv);

            //Make another line style dictionary with the line styles indexed by name (mark)
            Dictionary<string, Category> newlineStyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in RVTGetElementsByCollection.DocumentLineStyles(uiApp))
            {
                newlineStyleDict.Add(lineStyle.Name.Replace("ID ", ""), lineStyle);
            }

            //Add a default line style to the palette's combo box, then add the checked line styles to a list in alphabetical order
            SortedList<string, string> materialsToUseList = new SortedList<string, string>();
            BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Items.Add("Default");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (newlineStyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()) && row.Cells["Select"].Value.ToString() == "True")
                {
                    materialsToUseList.Add(row.Cells["Mark"].Value.ToString(), row.Cells["Mark"].Value.ToString());
                }
            }

            //Assuming there were checked linestyles to add to the palette's combo box, add them to the combo box
            if (materialsToUseList.Count != 0)
            {
                foreach (string item in materialsToUseList.Keys)
                {
                    BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Items.Add(item);
                }
            }
            else
            {
                //If there were no additional line styles to add to the combo box, disable it and set it to Default
                BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Text = "Default";
                BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.paletteMaterialComboBox.Enabled = false;
            }

            //Show the palette and continue doing requests for the Accent Material Lines tool from there.
            BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette.Show();
        }
    }
}
