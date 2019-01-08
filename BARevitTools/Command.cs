#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System.Windows.Forms;
#endregion

namespace BARevitTools
{
    //
    //Set the TransactionMode to manual so transactions must be made as needed, and set the document regeneration to manual since it is usually not necessary and should be manually invoked
    [Transaction(TransactionMode.Manual)]          
    [Regeneration(RegenerationOption.Manual)]
    //Deriving an ExternalCommand from the IExternalCommand interface
    public class Launcher : IExternalCommand
    {
        //
        //Implements the required Execute method.
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            try
            {
                //When the ribbon panel button is pushed, this ExternalCommand will try to show the MainUI form already created by the ExternalApplication class
                Application.thisApp.ShowForm(commandData.Application);
                commandData.Application.ActiveUIDocument.Document.Application.FailuresProcessing += new EventHandler<Autodesk.Revit.DB.Events.FailuresProcessingEventArgs>(OnFailuresProcessing);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                //If it fails, the message output will be the exception thrown
                message = ex.Message;
                return Result.Failed;
            }                
        }

        //
        //This is the default error/warning message handler for when they occur
        private void OnFailuresProcessing(object sender, FailuresProcessingEventArgs e)
        {
            //Get the FailuresAccessor
            FailuresAccessor failuresAccessor = e.GetFailuresAccessor();
            //Get all messages in the FailuresAccessor
            IList<FailureMessageAccessor> fmas = failuresAccessor.GetFailureMessages();
            //If there are no failures, just continue
            if(fmas.Count == 0)
            {
                e.SetProcessingResult(FailureProcessingResult.Continue);
            }
            //Otherwwise, evaluate the severity of the failure messages
            else
            {
                //Cycle through each failure message
                foreach (FailureMessageAccessor fma in fmas)
                {
                    //If the message is just a warning...
                    if (failuresAccessor.GetSeverity() == FailureSeverity.Warning)
                    {
                        //Delete the warning.
                        failuresAccessor.DeleteWarning(fma);
                    }
                    //If the message is an error, try the following
                    if (failuresAccessor.GetSeverity() == FailureSeverity.Error)
                    {
                        //This is specific and may be used later for evaluating family construction
                        if (fma.GetFailureDefinitionId() == BuiltInFailures.DimensionFailures.UnstableConstraintInFamily)
                        {
                            try
                            {
                                failuresAccessor.DeleteWarning(fma);
                            }
                            catch
                            {
                                failuresAccessor.ResolveFailure(fma);
                            }
                            finally
                            {
                                //Include a log here to record the family having the issue
                                ;
                            }
                        }
                        else
                        {
                            try
                            {
                                failuresAccessor.DeleteWarning(fma);
                            }
                            catch
                            {
                                failuresAccessor.ResolveFailure(fma);
                            }
                        }
                    }
                }                
            }
        }
    }
}
