#region Namespaces
using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
#endregion

namespace BARevitTools
{
    //Set the TransactionMode to manual so transactions must be made as needed
    [Transaction(TransactionMode.Manual)]
    //Set the RegenerationOption to manual so the document only regenerates as needed
    [Regeneration(RegenerationOption.Manual)]

    //Deriving an ExternalCommand from the IExternalCommand interface
    public class Launcher : IExternalCommand
    {
        //Implements the required Execute method.
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            try
            {
                //When the ribbon panel button is pushed, this ExternalCommand will try to show the MainUI form already created by the ExternalApplication class
                Application.thisApp.ShowForm(commandData.Application);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                //If it fails, the message output will be the exception thrown
                message = ex.Message;
                return Result.Failed;
            }                
        }
    }
}
