using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using RVTApplication = Autodesk.Revit.ApplicationServices.Application;
using RVTDocument = Autodesk.Revit.DB.Document;

namespace BARevitTools
{
    public partial class SharedParametersUI : System.Windows.Forms.Form
    {
        List<string> sharedParameterNames = new List<string>();
        List<string> sharedParameterGroupNames = new List<string>();
        List<string> sharedParameterTypeNames = new List<string>();
        List<ParameterType> sharedParameterTypes = new List<ParameterType>();
        SortedList<string, string> sortedSharedParameterGroupNames = new SortedList<string, string>();
        List<ExternalDefinition> sharedParameterDefinitions = new List<ExternalDefinition>();

        MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
        UIApplication SPUiApp = null;
        public SharedParametersUI(UIApplication uiApp)
        {
            InitializeComponent();
            SPUiApp = uiApp;
        }

        public void UpdateFields()
        {
            RVTDocument doc = SPUiApp.ActiveUIDocument.Document;
            DefinitionFile sharedParameterDoc = SPUiApp.Application.OpenSharedParameterFile();
            DefinitionGroups definitionGroups = sharedParameterDoc.Groups;
            foreach (DefinitionGroup dgroup in definitionGroups)
            {
                foreach (ExternalDefinition definition in dgroup.Definitions)
                {
                    sharedParameterNames.Add(definition.Name);
                    sharedParameterGroupNames.Add(dgroup.Name);
                    sharedParameterTypeNames.Add(definition.ParameterType.ToString());
                    sharedParameterTypes.Add(definition.ParameterType);
                    sharedParameterDefinitions.Add(definition);
                    if (!sortedSharedParameterGroupNames.Keys.Contains(dgroup.Name))
                    {
                        sortedSharedParameterGroupNames.Add(dgroup.Name, dgroup.Name);
                    }
                    else { continue; }
                }
            }
            foreach(string item in sortedSharedParameterGroupNames.Keys)
            {
                this.SharedParameterGroupComboBox.Items.Add(item);
            }
        }

        private void SharedParameterGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SharedParameterNameComboBox.Items.Clear();
            this.SharedParameterNameComboBox.Text = "";
            string groupName = this.SharedParameterGroupComboBox.Text;
            for(int i = 0; i<sharedParameterGroupNames.Count;i++)
            {
                if(sharedParameterGroupNames[i] == groupName)
                {
                    this.SharedParameterNameComboBox.Items.Add(sharedParameterNames[i]);
                }
            }
        }

        private void SharedParameterNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string paramName = this.SharedParameterNameComboBox.Text;
            for (int i = 0; i < sharedParameterNames.Count; i++)
            {
                if (sharedParameterNames[i] == paramName)
                {
                    this.SharedParameterTypeTextBox.Text = sharedParameterTypeNames[i];
                    break;
                }
            }
        }

        private void SharedParameterAddButton_Click(object sender, EventArgs e)
        {
            if (SharedParameterNameComboBox.Text != "")
            {
                int rowIndex = uiForm.adminFamiliesBAPParametersDGV.Rows.Add(true, SharedParameterNameComboBox.Text, SharedParameterTypeTextBox.Text, null, false);
                uiForm.adminFamiliesBAPParametersDGV.Rows[rowIndex].Cells[1].ReadOnly = true;
                uiForm.adminFamiliesBAPParametersDGV.Rows[rowIndex].Cells[2].ReadOnly = true;
            }
            else { MessageBox.Show("No parameter was selected."); }
        }
    }
}
