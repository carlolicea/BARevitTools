using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools.ToolRequests
{
    //
    //This class is associated with the Delete Parts tool which deletes parats associations with the selected wall
    class WallsDPRequest
    {
        public WallsDPRequest(UIApplication uiApp, String text)
        {
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            //Encapsulating in a transaction for tidiness
            using (Transaction t1 = new Transaction(doc, "RemoveWallParts"))
            {
                t1.Start();
                //Get the ElementId of the wall to remove parts from
                ElementId elementId = RVTOperations.SelectElement(uiApp);
                if (elementId != null)
                {
                    //Verify the element is a wall
                    if(doc.GetElement(elementId).Category.Name.ToString() == "Walls")
                    {
                        try
                        {
                            //Delete the parts associated with the wall
                            RVTOperations.DeleteParts(uiApp, doc, elementId);
                        }
                        catch
                        {
                            //If the parts could not be deleted, report it
                            MessageBox.Show("Could not delete any parts from the wall."+ 
                                " If the element you selected has parts, ensure you are selecting the original wall and not the parts."+
                                " Set the view's Parts Visibility property to Show Original to assist with selecting the wall.");
                        }
                    }
                    else
                    {
                        //If the element was not a wall element, let the user know to select a wall element
                        MessageBox.Show("The element selected was not a wall. Please select a wall element.");
                    }                    
                }
                else
                {
                    //If the user didn't select an element, 
                    MessageBox.Show("No element was selected");
                }
                t1.Commit();
            }                
        }
    }
}
