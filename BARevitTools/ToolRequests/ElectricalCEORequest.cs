using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    class ElectricalCEORequest
    {
        public ElectricalCEORequest(UIApplication uiApp, String text)
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
                    { continue; }
                }
                t.Commit();
            }
            catch (Exception f)
            {
                t.RollBack();
                MessageBox.Show(f.ToString());
            }
        }
    }
}
