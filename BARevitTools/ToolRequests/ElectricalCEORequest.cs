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
    //
    //This class is used by the Correct Electrical Outlet Elevations tool. If an outlet was moved up physically instead of using the MOUNTING HEIGHT parameter, 
    //this will correct the Offset or Elevation parameter to be 0' and reflect the actual height in the MOUNTING HEIGHT parameter value without moving the physical location of the outlet.
    class ElectricalCEORequest
    {
        public ElectricalCEORequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Collect all electrical fixture instances.
            var elecFixturesCollection = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType().ToElements();
            Transaction t = new Transaction(doc, "CorrectElectricalOutletElevations");
            t.Start();
            try
            {
                //Cycle through each electrical fixture family instance
                foreach (Element elem in elecFixturesCollection)
                {
                    try
                    {
                        //Get the list of parameters in the family instance and cast it to a list
                        Parameter mountingHeightParameter = null;
                        List<Parameter> parameters = elem.Parameters.Cast<Parameter>().ToList();
                        //Cycle through the list of parameters and see if any are named MOUNTING HEIGHT
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            Parameter currentParam = parameters[i];
                            //Capitalizing the name of the parameter in case Mounting Height, mounting height, or some variation is used.
                            if (currentParam.Definition.Name.ToUpper() == "MOUNTING HEIGHT")
                            {
                                //If the parameter is found, exit the loop immediately
                                mountingHeightParameter = currentParam;
                                break;
                            }
                        }

                        //If the MOUNTING HEIGHT parameter is not null...
                        if (mountingHeightParameter != null)
                        {
                            //Get the value of MOUNTING HEIGHT
                            double originalMountingHeight = mountingHeightParameter.AsDouble();
                            //If MOUNTING HEIGHT is not equal to 0', continue
                            if (originalMountingHeight != 0)
                            {
                                double savedOffset = 0;
                                //The outlet could be wall-hosted or non-hosted. Try to find the Offset parameter first, then try Elevation.
                                try
                                {
                                    //Get the Offset parameter value
                                    Parameter offset = elem.GetParameters("Offset").First();
                                    savedOffset = offset.AsDouble();
                                    //Set the MOUNTING HEIGHT parameter to the original value plus the Offset value
                                    mountingHeightParameter.Set(savedOffset + originalMountingHeight);
                                    //Reset the Offset parameter value to 0'
                                    offset.Set(0);
                                }
                                catch
                                {
                                    //Get the Elevation parameter value
                                    Parameter elevation = elem.GetParameters("Elevation").First();
                                    savedOffset = elevation.AsDouble();
                                    //Set the MOUNTING HEIGHT parameter to the original value plus the Elevation value
                                    mountingHeightParameter.Set(savedOffset + originalMountingHeight);
                                    //Reset the Elevation parameter value to 0'
                                    elevation.Set(0);
                                }
                            }
                        }
                    }
                    catch
                    {
                        //A simple continue is being used here because the electrical fixture may not have the MOUNTING HEIGHT parameter, \
                        //in which case, it is fine to just skip to evaluate the next family instance.
                        continue;
                    }
                }
                t.Commit();
            }
            catch (Exception f)
            {
                //If the electrical fixture collection was empty, just roll back the transaction 
                t.RollBack();
                MessageBox.Show(f.ToString());
            }
        }
    }
}
