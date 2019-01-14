using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RVTDocument = Autodesk.Revit.DB.Document;

using Excel = Microsoft.Office.Interop.Excel;

namespace BARevitTools
{
    public partial class MainUI : System.Windows.Forms.Form
    {
        private UIApplication uiApp;
        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;        
        //
        //This is the constructor for the MainUI of BART that pops up when the Ribbon Panel button is clicked
        public MainUI(UIApplication exUiApp, ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;
            uiApp = exUiApp;
        }
        //
        // This sets who can access the Admin tab
        private void AllowBIMManagementTab(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            //This will take the Properties setting and split it out to a list to see if the logged in user's name is in the list.
            List<string> adminUsersList = BARevitTools.Properties.Settings.Default.BARTBAAdminUsers.Split(',').ToList();
            string userName = Environment.UserName.ToString();
            if (adminUsersList.Contains(userName))
            {
                uiForm.adminManagementTabControl.Enabled = true;
                uiForm.adminManagementTabControl.Update();
                uiForm.adminManagementTabControl.Refresh();
            }
            else { uiForm.adminManagementTabControl.Enabled = false; }
        }
        //
        //When the MainUI is closed, this is performed to clean up data
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;
            base.OnFormClosed(e);
        }
        //
        //This will allow the MainUI's controls to be interacted with while a Request is not active
        public void WakeUp()
        {
            EnableCommands(true);
        }
        //
        //When a Request is active and modifying the Revit document, the MainUI's controls are disabled
        private void DozeOff()
        {
            EnableCommands(false);
        }
        //
        //This will allow the MainUI controls to be interacted with or disabled.
        private void EnableCommands(bool status)
        {
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                ctrl.Enabled = status;
            }
        }
        //
        //This method is called to make a request from the MainUI, and set the MainUI controsl as inactive so no MainUI operations can be performed while the request's operations are performed
        public void MakeRequest(RequestId request)
        {
            m_Handler.Request.Make(request);
            m_ExEvent.Raise();
            DozeOff();
        }
        //
        //When the MainUI is closed, the activities of the user will be recorded
        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DatabaseOperations.SqlRecordAppUse();
            }
            catch
            {
                ;
            }
        }
        //
        //This Switch Case will determine what panels of controls are visible and which are hidden. This allows multiple panels to be stacked for each tab and only show the one being after the tool button is clicked
        public void SwitchActivePanel(int panelNumber)
        {
            #region Switch Cases for Panels
            int caseSwitch = panelNumber;
            switch (caseSwitch)
            {
                //Each of these cases are to show the parent control (panel or layout panel) when the tool button is pressed, while hiding the other parent controls hosted in the same tab
                case ReferencedSwitchCaseIds.multiCatCFFE1:
                    this.multiCatCFFSplitContainer.Visible = true;
                    this.multiCatCFFEButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.electricalCEOE:
                    this.electricalCEOELayoutPanel.Visible = true;
                    this.electricalCEOEButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.floorsCFBR:
                    this.floorsCFBRLayoutPanel.Visible = true;
                    this.floorsCFBRButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.materialsCMS:
                    this.materialsCMSExcelLayoutPanel.Visible = true;
                    this.materialsCMSButton.Checked = true;
                    this.materialsAMLLayoutPanel.Visible = false;
                    this.materialsAMLButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.materialsAML:
                    this.materialsAMLLayoutPanel.Visible = true;
                    this.materialsAMLButton.Checked = true;
                    this.materialsCMSButton.Checked = false;
                    this.materialsCMSExcelLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.roomsSRNN:
                    this.roomsSRNNLayoutPanel.Visible = true;
                    this.roomsSRNNButton.Checked = true;
                    this.roomsCDRTLayoutPanel.Visible = false;
                    this.roomsCDRTButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.roomsCDRT:
                    this.roomsCDRTLayoutPanel.Visible = true;
                    this.roomsCDRTButton.Checked = true;
                    this.roomsSRNNLayoutPanel.Visible = false;
                    this.roomsSRNNButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.wallsMPW:
                    this.wallsMPWLayoutPanel.Visible = true;
                    this.wallsMPWButton.Checked = true;
                    this.wallsDPLayoutPanel.Visible = false;
                    this.wallsDPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.wallsDP:
                    this.wallsDPLayoutPanel.Visible = true;
                    this.wallsDPButton.Checked = true;
                    this.wallsMPWLayoutPanel.Visible = false;
                    this.wallsMPWButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.sheetsCSL:
                    this.sheetsCSLLayoutPanel.Visible = true;
                    this.sheetsCSLButton.Checked = true;
                    this.sheetsCSSFSLayoutPanel.Visible = false;
                    this.sheetsISFLLayoutPanel.Visible = false;
                    this.sheetsISFLButton.Checked = false;
                    this.sheetsOSSLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.sheetsISFL:
                    this.sheetsISFLLayoutPanel.Visible = true;
                    this.sheetsISFLButton.Checked = true;
                    this.sheetsCSSFSLayoutPanel.Visible = false;
                    this.sheetsCSLLayoutPanel.Visible = false;
                    this.sheetsCSLButton.Checked = false;
                    this.sheetsOSSLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.sheetsCSSFS:
                    this.sheetsCSSFSLayoutPanel.Visible = true;
                    this.sheetsOSSLayoutPanel.Visible = false;
                    this.sheetsISFLLayoutPanel.Visible = false;
                    this.sheetsISFLButton.Checked = false;
                    this.sheetsCSLLayoutPanel.Visible = false;
                    this.sheetsCSLButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.sheetsOSS1:
                    this.sheetsOSSLayoutPanel.Visible = true;
                    this.sheetsCSSFSLayoutPanel.Visible = false;
                    this.sheetsISFLLayoutPanel.Visible = false;
                    this.sheetsISFLButton.Checked = false;
                    this.sheetsCSLLayoutPanel.Visible = false;
                    this.sheetsCSLButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.viewsCEPR:
                    this.viewsCEPRLayoutPanel.Visible = true;
                    this.viewsCEPRButton.Checked = true;
                    this.viewsOICBLayoutPanel.Visible = false;
                    this.viewsHNIECLayoutPanel.Visible = false;
                    this.viewsHNIECButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.viewsOICB:
                    this.viewsOICBLayoutPanel.Visible = true;
                    this.viewsCEPRLayoutPanel.Visible = false;
                    this.viewsCEPRButton.Checked = false;
                    this.viewsHNIECLayoutPanel.Visible = false;
                    this.viewsHNIECButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.viewsHNIEC:
                    this.viewsHNIECLayoutPanel.Visible = true;
                    this.viewsHNIECButton.Checked = true;
                    this.viewsOICBLayoutPanel.Visible = false;
                    this.viewsCEPRLayoutPanel.Visible = false;
                    this.viewsCEPRButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.dataEPI:
                    this.dataEPILayoutPanel.Visible = true;
                    this.dataEPIButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.documentsCTS:
                    this.documentsCTSPanel.Visible = true;
                    this.documentsCTSButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.miscEDV:
                    this.miscEDVLayoutPanel.Visible = true;
                    this.miscEDVButton.Checked = true;
                    break;
                case ReferencedSwitchCaseIds.qaqcCSVN:
                    this.qaqcCSVNPanel.Visible = true;
                    this.qaqcDRNPPanel.Visible = false;
                    this.qaqcDRNPButtton.Checked = false;
                    this.qaqcCSVLayoutPanel.Visible = false;
                    this.qaqcRLSLayoutPanel.Visible = false;
                    this.qaqcRLSButton.Checked = false;
                    this.qaqcRFSPLayoutPanel.Visible = false;
                    this.qaqcRFSPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.qaqcDRNP:
                    this.qaqcDRNPPanel.Visible = true;
                    this.qaqcDRNPButtton.Checked = true;
                    this.qaqcCSVNPanel.Visible = false;
                    this.qaqcCSVLayoutPanel.Visible = false;
                    this.qaqcRLSLayoutPanel.Visible = false;
                    this.qaqcRLSButton.Checked = false;
                    this.qaqcRFSPLayoutPanel.Visible = false;
                    this.qaqcRFSPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.qaqcCSV:
                    this.qaqcCSVLayoutPanel.Visible = true;
                    this.qaqcDRNPPanel.Visible = false;
                    this.qaqcDRNPButtton.Checked = false;
                    this.qaqcCSVNPanel.Visible = false;
                    this.qaqcRLSLayoutPanel.Visible = false;
                    this.qaqcRLSButton.Checked = false;
                    this.qaqcRFSPLayoutPanel.Visible = false;
                    this.qaqcRFSPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.qaqcRLS:
                    this.qaqcRLSLayoutPanel.Visible = true;
                    this.qaqcRLSButton.Checked = true;
                    this.qaqcCSVLayoutPanel.Visible = false;
                    this.qaqcDRNPPanel.Visible = false;
                    this.qaqcDRNPButtton.Checked = false;
                    this.qaqcCSVNPanel.Visible = false;
                    this.qaqcRFSPLayoutPanel.Visible = false;
                    this.qaqcRFSPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.qaqcRFSP:
                    this.qaqcRFSPLayoutPanel.Visible = true;
                    this.qaqcRFSPButton.Checked = true;
                    this.qaqcRLSLayoutPanel.Visible = false;
                    this.qaqcRLSButton.Checked = false;
                    this.qaqcCSVLayoutPanel.Visible = false;
                    this.qaqcDRNPPanel.Visible = false;
                    this.qaqcDRNPButtton.Checked = false;
                    this.qaqcCSVNPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.setupCWS:
                    this.setupCWSLayoutPanel.Visible = true;
                    this.setupCWSButton.Checked = true;
                    this.setupUPLayoutPanel.Visible = false;
                    this.setupUPButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.setupUP:
                    this.setupUPLayoutPanel.Visible = true;
                    this.setupUPButton.Checked = true;
                    this.setupCWSLayoutPanel.Visible = false;
                    this.setupCWSButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.adminDataGFF:
                    this.adminDataGFFLayoutPanel.Visible = true;
                    this.adminDataGFFButton.Checked = true;
                    this.adminDataGBDVLayoutPanel.Visible = false;
                    this.adminDataGBDVButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.adminDataGBDV:
                    this.adminDataGBDVLayoutPanel.Visible = true;
                    this.adminDataGBDVButton.Checked = true;
                    this.adminDataGFFLayoutPanel.Visible = false;
                    this.adminDataGFFButton.Checked = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesUF:
                    this.adminFamiliesUFLayoutPanel.Visible = true;
                    this.adminFamiliesUFButton.Checked = true;
                    this.adminFamiliesBAPLayoutPanel.Visible = false;
                    this.adminFamiliesBAPButton.Checked = false;
                    this.adminFamiliesBRPLayoutPanel.Visible = false;
                    this.adminFamiliesBRPButton.Checked = false;
                    this.adminFamiliesDFBLayoutPanel.Visible = false;
                    this.adminFamiliesDFBButton.Checked = false;
                    this.adminFamiliesUFVPLayoutPanel.Visible = false;
                    this.adminFamiliesSRCPButton.Checked = false;
                    this.adminFamiliesSRCPLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesBAP:
                    this.adminFamiliesBAPLayoutPanel.Visible = true;
                    this.adminFamiliesBAPButton.Checked = true;
                    this.adminFamiliesUFLayoutPanel.Visible = false;
                    this.adminFamiliesUFButton.Checked = false;
                    this.adminFamiliesBRPLayoutPanel.Visible = false;
                    this.adminFamiliesBRPButton.Checked = false;
                    this.adminFamiliesDFBLayoutPanel.Visible = false;
                    this.adminFamiliesDFBButton.Checked = false;
                    this.adminFamiliesUFVPLayoutPanel.Visible = false;
                    this.adminFamiliesSRCPButton.Checked = false;
                    this.adminFamiliesSRCPLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesBRP:
                    this.adminFamiliesBRPLayoutPanel.Visible = true;
                    this.adminFamiliesBRPButton.Checked = true;
                    this.adminFamiliesUFLayoutPanel.Visible = false;
                    this.adminFamiliesUFButton.Checked = false;
                    this.adminFamiliesBAPLayoutPanel.Visible = false;
                    this.adminFamiliesBAPButton.Checked = false;
                    this.adminFamiliesDFBLayoutPanel.Visible = false;
                    this.adminFamiliesDFBButton.Checked = false;
                    this.adminFamiliesUFVPLayoutPanel.Visible = false;
                    this.adminFamiliesSRCPButton.Checked = false;
                    this.adminFamiliesSRCPLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesDFB:
                    this.adminFamiliesDFBLayoutPanel.Visible = true;
                    this.adminFamiliesDFBButton.Checked = true;
                    this.adminFamiliesUFLayoutPanel.Visible = false;
                    this.adminFamiliesUFButton.Checked = false;
                    this.adminFamiliesBAPLayoutPanel.Visible = false;
                    this.adminFamiliesBAPButton.Checked = false;
                    this.adminFamiliesBRPLayoutPanel.Visible = false;
                    this.adminFamiliesBRPButton.Checked = false;
                    this.adminFamiliesUFVPLayoutPanel.Visible = false;
                    this.adminFamiliesSRCPButton.Checked = false;
                    this.adminFamiliesSRCPLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesUFVP:
                    this.adminFamiliesUFVPLayoutPanel.Visible = true;
                    this.adminFamiliesDFBLayoutPanel.Visible = false;
                    this.adminFamiliesDFBButton.Checked = false;
                    this.adminFamiliesUFLayoutPanel.Visible = false;
                    this.adminFamiliesUFButton.Checked = false;
                    this.adminFamiliesBAPLayoutPanel.Visible = false;
                    this.adminFamiliesBAPButton.Checked = false;
                    this.adminFamiliesBRPLayoutPanel.Visible = false;
                    this.adminFamiliesBRPButton.Checked = false;
                    this.adminFamiliesSRCPButton.Checked = false;
                    this.adminFamiliesSRCPLayoutPanel.Visible = false;
                    break;
                case ReferencedSwitchCaseIds.adminFamiliesSRCP:
                    this.adminFamiliesSRCPButton.Checked = true;
                    this.adminFamiliesSRCPLayoutPanel.Visible = true;
                    this.adminFamiliesUFVPLayoutPanel.Visible = false;
                    this.adminFamiliesDFBLayoutPanel.Visible = false;
                    this.adminFamiliesDFBButton.Checked = false;
                    this.adminFamiliesUFLayoutPanel.Visible = false;
                    this.adminFamiliesUFButton.Checked = false;
                    this.adminFamiliesBAPLayoutPanel.Visible = false;
                    this.adminFamiliesBAPButton.Checked = false;
                    this.adminFamiliesBRPLayoutPanel.Visible = false;
                    this.adminFamiliesBRPButton.Checked = false;
                    break;
                default:
                    break;
            }
            #endregion Switch Cases for Panels
        }

        //
        // ABOUT TAB TOOLS
        //

        //When a user clicks on the hyperlink on the main page of the BART UI, it will launch a web browser and the website with these events
        private void AboutTabLearningLinkURLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(BARevitTools.Properties.Settings.Default.UrlBARTLearning);
        }
        
        //
        // MODELING TAB TOOLS

        //Create Families From Excel
        #region multiCatCFFE
        public string multiCatSelectedFamilyFile = "";
        public string multiCatCFFEExcelFileToUse = "";
        public string multiCatCFFEFamilyFileToUse = "";
        public string multiCatCFFEFamilySaveLocation = "";
        private void AllCatCFFEButton_Click(object sender, EventArgs e)
        {
            SwitchActivePanel(ReferencedSwitchCaseIds.multiCatCFFE1);
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEFamiliesProgressBar.Visible = false;
            BARevitTools.Application.thisApp.newMainUi.allCATCFFEFamiliesSaveDirectoryTextBox.Text = "";
            GeneralOperations.ResetDataGridView(Application.thisApp.newMainUi.multiCatCFFEExcelDGV);
            GeneralOperations.ResetDataGridView(Application.thisApp.newMainUi.multiCatCFFEFamiliesDGV);
            DatabaseOperations.CollectUserInputData(BARevitTools.ReferencedGuids.multiCatCFFguid, multiCatCFFEButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void AllCatCFFEDirectorySelectButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            string saveDirectory = GeneralOperations.GetDirectory();
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEDirectoryTextBox.Text = saveDirectory;
        }
        private void AllCatCFFESelectFamilyButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            //A bool is used to determine if Revit should try to read the family file later
            bool readFamilyFile = false;
            string fileName = RVTOperations.GetFamilyFile();
            //If the user selected a file, continue
            if (fileName != "")
            {
                //Determine if the family can be opened by the actively running version of Revit
                if (Convert.ToInt32(uiApp.Application.VersionNumber) >= RVTOperations.GetRevitNumber(fileName))
                {
                    BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = Path.GetFileNameWithoutExtension(fileName);
                    readFamilyFile = true;
                }                
                else
                {
                    BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = "RVT Version Error";
                }
            }
            else
            {
                BARevitTools.Application.thisApp.newMainUi.multiCatCFFESelectFamilyTextBox.Text = "No Selection Error";
            }

            //If the family can be opened by Revit, proceed with raising and ExternalEvent and making the Request
            if (readFamilyFile == true)
            {
                multiCatSelectedFamilyFile = fileName;
                m_ExEvent.Raise();
                MakeRequest(RequestId.multiCatCFFE1);
            }

        }
        private void AllCatCFFEExcelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEExcelDGV;
            //Verify there are rows in the DGV
            if (dgv.Rows.Count > 0)
            {
                //Get the value of the clicked cell and its ColumnIndex
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                //If the user was interacting with the checkboxes...
                if (columnIndex == 0)
                {
                    //If the cell's check state was null...
                    if (rowValue == "")
                    {
                        //Set each selected row's check box to True and set the background color
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    //If the cell's check state was True...
                    else if (rowValue.ToString() == "True")
                    {
                        //Set each selected row's check box to False and clear the background color
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    //Otherwise, the cell's check state was False
                    else
                    {
                        //Sete each Rows's check box to True and set the background color
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void AllCatCFFEExcelRunButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = false;
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEExcelDGV;

            //Determine how many rows of parameters were selected
            int trueCount = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                try
                {
                    if (row.Cells["Parameter Select"].Value.ToString() == "True")
                    {
                        trueCount++;
                    }
                }
                catch { continue; }                
            }

            //If the user didn't select the directory where to save the template, give a message
            if (uiForm.multiCatCFFEDirectoryTextBox.Text == "")
            {
                MessageBox.Show("No save directory was selected");
            }
            //If they also didn't select a family, give a message
            else if (uiForm.multiCatCFFESelectFamilyTextBox.Text == "")
            {
                MessageBox.Show("No family was selected");
            }
            //If they didn't select any parameters, give a message
            else if (dgv.Rows.Count == 0 || trueCount == 0)
            {
                MessageBox.Show("No family parameters were selected");
            }
            //Otherwise not all is lost on them and they can continue
            else
            {
                string savePath = uiForm.multiCatCFFEDirectoryTextBox.Text;
                string familyName = uiForm.multiCatCFFESelectFamilyTextBox.Text;

                //Fire up Excel and set it to be visible when launched, and ignore any alerts
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                //Add a new workbook after Excel launches
                Excel.Workbook newWorkbook = excel.Workbooks.Add("");
                //Set the worksheet to the first active worksheeet
                Excel.Worksheet newWorksheet = newWorkbook.ActiveSheet;
                //Set all cells as locked
                newWorksheet.Cells.Locked = true;

                //For cell A3, set it to the following
                newWorksheet.Cells[3, 1] = "Family Type Name";
                //For cell A1, set it to the following
                newWorksheet.Cells[1, 1] = "READ ME: Refer to the family parameters to know what is expected for parameter values. " +
                    "The GREEN row is the parameter names. " +
                    "The BLUE row is the parameter types as seen in Revit. " +
                    "The ORANGE row is the types of data formats expected. " +
                    "NOTE: INTEGERS are whole Numbers, DOUBLES are decimal numbers, STRINGS are text. " +
                    "For all parameters that are LENGTHS, use DECIMAL INCHES. For YES/NO Parameters, 0 is False and 1 is True";
                //Merge the cells for A1 and A2
                Excel.Range mergeRange = excel.Range[newWorksheet.Cells[1, 1], newWorksheet.Cells[2, 1]];
                mergeRange.Merge(Missing.Value);
                //Set the cell's color to Red
                newWorksheet.Range["A1,A2"].Cells.Interior.ColorIndex = 3;
                //Allow the merged cells to wrap text
                newWorksheet.Range["A1,A2"].Cells.WrapText = true;

                //Now, parameter names will start in column B
                int j = 2; //Parameter Names starting column//
                //For each row in the DGV of parameters
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //If the checkbox is checked for that row...
                    if (row.Cells["Parameter Select"].Value.ToString() == "True")
                    {
                        //Set cell "j"1 to the parameter type
                        newWorksheet.Cells[1, j] = row.Cells["Parameter Type"].Value.ToString();
                        //Set cell "j"2 to the storage type
                        newWorksheet.Cells[2, j] = row.Cells["Parameter Storage Type"].Value.ToString();
                        //Set cell "j"3 to the parameter name
                        newWorksheet.Cells[3, j] = row.Cells["Parameter Name"].Value.ToString();
                        j++;
                    }
                }
                //Unlock the cells
                excel.Cells.Locked = false;
                //Cell A3 should be locked
                newWorksheet.Cells[3, 1].Locked = true;
                //Set the ranges for the cells
                Excel.Range familyTypeHeaderCells = newWorksheet.Cells[3, 1];
                Excel.Range paramNamesStartCells = newWorksheet.Cells[3, 2];
                Excel.Range paramNamesEndCells = newWorksheet.Cells[3, j - 1];
                Excel.Range paramTypesStartCells = newWorksheet.Cells[1, 2];
                Excel.Range paramTypesEndCells = newWorksheet.Cells[1, j - 1];
                Excel.Range paramStorageTypesStartCells = newWorksheet.Cells[2, 2];
                Excel.Range paramStorageTypesEndCells = newWorksheet.Cells[2, j - 1];
                Excel.Range paramNamesRange = excel.Range[paramNamesStartCells, paramNamesEndCells];
                //Set the color of the cells for the family type header
                familyTypeHeaderCells.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                //For the parameter name header cells, set their color
                paramNamesRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                //Lock the cells in the parameter names
                paramNamesRange.Locked = true;
                Excel.Range paramTypesRange = excel.Range[paramTypesStartCells, paramTypesEndCells];
                //Set the color of the cells for the parameter type headers
                paramTypesRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DeepSkyBlue);
                //Lock those cells too
                paramTypesRange.Locked = true;
                Excel.Range paramStorageRange = excel.Range[paramStorageTypesStartCells, paramStorageTypesEndCells];
                //Finally, set the color for the cells in the parameter storage headers and lock them
                paramStorageRange.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold);
                paramStorageRange.Locked = true;

                //The password to lock the sheet
                string password = BARevitTools.Properties.Settings.Default.ExcelWorksheetPwd;
                //Rest of these settings are for allowing or restricting changes
                bool drawingObjects = false;
                bool contents = true;
                bool scenarios = false;
                bool userInterfaceOnly = false;
                bool allowFormattingCells = false;
                bool allowFormattingColumns = true;
                bool allowFormattingRows = true;
                bool allowInsertingColumns = false;
                bool allowInsertingRows = true;
                bool allowInsertingHyperlinks = false;
                bool allowDeletingColumns = false;
                bool allowDeletingRows = true;
                bool allowSorting = false;
                bool allowFiltering = true;
                bool allowUsingPivotTables = false;
                newWorksheet.Protect(password, drawingObjects, contents, scenarios, userInterfaceOnly, allowFormattingCells,
                    allowFormattingColumns, allowFormattingRows, allowInsertingColumns, allowInsertingRows, allowInsertingHyperlinks,
                    allowDeletingColumns, allowDeletingRows, allowSorting, allowFiltering, allowUsingPivotTables);

                //Here is where the Excel file is saved
                try
                {
                    //Get the file properties
                    dynamic properties = newWorkbook.BuiltinDocumentProperties;
                    //Set the Comments field of the properties to the family path so the script will know later which family corresponds to the spreadsheet, even if the spreadsheet name changes
                    properties["Comments"].Value = multiCatSelectedFamilyFile;
                    //Save the file
                    newWorkbook.SaveAs(savePath + "\\" + familyName + "_Types Template.xlsx");
                    //Close the file
                    newWorkbook.Close();
                    //Exit Excel
                    excel.Quit();
                    //Try to close the Excel application running
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelStatusLabel.Visible = true;
                }
                catch
                {
                    //The save could fail because the file was open, this will inform the user
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    MessageBox.Show("Error: A previously saved template with the same name might be open. " +
                    "Please close it in Excel and re-export the template. " +
                    "If that's not the case, something else went wrong in exporting the spreadsheet");
                }
            }
        }
        private void AllCatCFFEExcelSelectButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.multiCatCFFEFamiliesDGV;

            int fnrs = 4; // family name row start index
            int pnrs = 3; // parameter name row start index
            int pncs = 2; // parameter name column start index
            int ptrs = 2; // parameter type row start index
            int ptcs = 2; // paramter type column start index

            string file = GeneralOperations.GetExcelFile();
            if (file != "")
            {
                BARevitTools.Application.thisApp.newMainUi.multiCatCFFEExcelFileToUse = file;
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;
                try
                {
                    workbook = excel.Workbooks.Open(file);
                    worksheet = workbook.ActiveSheet;
                }
                catch
                { MessageBox.Show("Could not open the Excel file. Please verify it is not currently open."); }

                if (worksheet != null)
                {
                    DataTable dt = new DataTable();
                    DataColumn familyTypeNameColumn = dt.Columns.Add("FamilyTypeName", typeof(String));
                    worksheet.Unprotect(BARevitTools.Properties.Settings.Default.ExcelWorksheetPwd);
                    Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range range = worksheet.get_Range("A1", last);

                    int lastUsedRow = last.Row;
                    int lastUsedColumn = last.Column;

                    for (int i = pncs; i <= lastUsedColumn; i++)
                    {
                        if (!dt.Columns.Contains(worksheet.Cells[pnrs, i].Value2.ToString()) && worksheet.Cells[pnrs, i].Value2.ToString() != "")
                        {
                            DataColumn newcolumn = dt.Columns.Add(worksheet.Cells[pnrs, i].Value2.ToString());
                        }
                        else
                        { continue; }
                    }

                    DataRow parameterTypeRow = dt.NewRow();
                    int columnCount = dt.Columns.Count;
                    for (int i = 1; i < columnCount; i++)
                    {
                        parameterTypeRow[dt.Columns[i].ColumnName] = worksheet.Cells[ptrs, ptcs].Value2.ToString();
                        ptcs++;
                    }
                    dt.Rows.Add(parameterTypeRow);

                    for (int j = fnrs; j <= lastUsedRow; j++)
                    {
                        DataRow valueRow = dt.NewRow();
                        for (int k = 1; k <= columnCount; k++)
                        {
                            try
                            {
                                valueRow[dt.Columns[k - 1]] = worksheet.Cells[j, k].Value2.ToString();
                            }
                            catch
                            {
                                valueRow[dt.Columns[k - 1]] = "";
                                continue;
                            }

                        }
                        dt.Rows.Add(valueRow);
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dgv.DataSource = bs;

                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    dgv.Rows[0].Frozen = true;
                    dgv.Rows[0].ReadOnly = true;
                    dgv.AllowUserToOrderColumns = false;
                    dgv.Update();
                    dgv.Refresh();
                }
                dynamic properties = workbook.BuiltinDocumentProperties;
                uiForm.multiCatCFFEFamilyFileToUse = properties["Comments"].Value;
                workbook.Close();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
        }
        private void AllCatCFFEFamiliesSaveDirectoryButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.multiCatCFFEFamilySaveLocation = GeneralOperations.GetDirectory();
            if (multiCatCFFEFamilySaveLocation != "")
            {
                BARevitTools.Application.thisApp.newMainUi.allCATCFFEFamiliesSaveDirectoryTextBox.Text = multiCatCFFEFamilySaveLocation;
            }
        }
        private void AllCatCFFEFamiliesRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.multiCatCFFE2);
        }
        #endregion multiCatCFFE

        #region electricalCEOE
        private void ElectricalCEOEButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.electricalCEOE);
            DatabaseOperations.CollectUserInputData(BARevitTools.ReferencedGuids.electricalCEOEguid, electricalCEOEButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void ElectricalCEOERunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.electricalCEOE);
        }
        #endregion electricalCEOE

        #region floorsCFBR
        public List<Room> floorsCFBRRoomsList = new List<Room>();
        private void FloorsCFBRButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.floorsCFBRDoneLabel.Visible = false;
            uiForm.floorsCFBRSelectFloorTypeComboBox.Items.Clear();

            List<string> floorTypeNames = RVTGetElementsByCollection.DocumentFloorTypeNames(uiApp);
            foreach (string floorTypeName in floorTypeNames)
            {
                uiForm.floorsCFBRSelectFloorTypeComboBox.Items.Add(floorTypeName);
            }
            this.SwitchActivePanel(ReferencedSwitchCaseIds.floorsCFBR);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.floorsCFBRguid, floorsCFBRButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void FloorsCFBRSelectRoomsButton_Click(object sender, EventArgs e)
        {
            try
            {
                floorsCFBRRoomsList.Clear();
            }
            catch {; }
            
            List<Room> rooms = RVTOperations.SelectRoomElements(uiApp);
            if (rooms != null)
            {
                floorsCFBRRoomsList = rooms;
            }
        }
        private void FloorsCFBRRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = Application.thisApp.newMainUi;
            uiForm.floorsCFBRDoneLabel.Visible = false;
            if (floorsCFBRRoomsList == null || floorsCFBRRoomsList.Count==0)
            {
                MessageBox.Show("Either no rooms have been selected, or if the Revit UI is grayed out, then it is waiting for you to click 'Finish' on the Options Bar below the Ribbon");
            }
            else if(floorsCFBRSelectFloorTypeComboBox.Text == "<Floor Type>")
            {
                MessageBox.Show("No floor type was selected. Please select a floor type.");
            }
            else
            {
                m_ExEvent.Raise();
                MakeRequest(RequestId.floorsCFBR);                
            }            
        }
        #endregion floorsCFBR        

        #region materialsCMS       
        public string materialsCMSExcelSaveDirectory = "";
        public Family materialsCMSFamilyToUse = null;
        private void MaterialsCMS_Click(object sender, EventArgs e)
        {
            //Ensure this tool can run
            if(Application.thisApp.CadDriveIsAccessible == false)
            {
                DisableUIFeatures.DisableControls(Application.thisApp.newMainUi.materialsCMSExcelLayoutPanel.Controls, Properties.Settings.Default.RevitCadDrive);
            }

            //Reset the MainUI
            materialsCMSExcelSaveDirectory = "";
            materialsCMSExcelSpreadsheetNameTextBox.Text = "<Excel Spreadsheet Name>";
            materialsCMSExcelDataGridView.DataBindings.Clear();
            materialsCMSExcelDataGridView.Update();
            materialsCMSExcelDataGridView.Refresh();
            materialsCMSExcelCreateSymbolsProgressBar.Value = 0;
            materialsCMSExcelCreateSymbolsProgressBar.Visible = false;
            SwitchActivePanel(ReferencedSwitchCaseIds.materialsCMS);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.materialsCMSguid, materialsCMSButton.Text, Environment.UserName.ToString(), DateTime.Now);

            //First, try to use the family from the project. If that fails, load the family file
            materialsCMSFamilyToUse = RVTGetElementsByCollection.FamilyByFamilyName(uiApp, Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));
            if (materialsCMSFamilyToUse == null && Application.thisApp.CadDriveIsAccessible == true)
            {
                MaterialsCMSLoadFamily();
            }
        }
        private void MaterialsCMSExcelSelectSaveDirectoryButton_Click(object sender, EventArgs e)
        {
            materialsCMSExcelSaveDirectory = GeneralOperations.GetDirectory();
        }
        private void MaterialsCMSExcelCreateSpreadsheetButton_Click(object sender, EventArgs e)
        {
            if (materialsCMSExcelSaveDirectory == "")
            {
                MessageBox.Show("Select a location where to save the Excel file");
            }
            else if (materialsCMSExcelSpreadsheetNameTextBox.Text == "" || materialsCMSExcelSpreadsheetNameTextBox.Text == "<Excel Spreadsheet Name>")
            {
                MessageBox.Show("Set the name of the spreadsheet to export");
            }
            else
            {
                string savePath = materialsCMSExcelSaveDirectory + "\\" + materialsCMSExcelSpreadsheetNameTextBox.Text + ".xlsx";
                GeneralOperations.WriteResourceToFile("BARevitTools.Resources.SYMB Material List.xlsx", savePath);
                DataGridView existingFamilies = GetExistingMaterialSymbolsData();
                if (existingFamilies != null)
                {
                    ExcelOperations.DataGridViewToExcel(savePath, existingFamilies);
                }
                MessageBox.Show(String.Format("{0} was saved to {1}", materialsCMSExcelSpreadsheetNameTextBox.Text, savePath));
            }
        }
        private void MaterialsCMSLoadFamily()
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.materialsCMSLoadFamily);
        }
        private DataGridView GetExistingMaterialSymbolsData()
        {   
            List<FamilySymbol> familySymbols = RVTGetElementsByCollection.FamilyTypesByFamilyName(uiApp, Path.GetFileNameWithoutExtension(BARevitTools.Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));            
            if (familySymbols != null)
            {
                try
                {
                    DataGridView tableToExport = new DataGridView();
                    DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
                    typeColumn.HeaderText = "Type";
                    tableToExport.Columns.Add(typeColumn);

                    RVTDocument famDoc = uiApp.ActiveUIDocument.Document.EditFamily(materialsCMSFamilyToUse);
                    FamilyManager famMan = famDoc.FamilyManager;
                    List<string> columnHeadersList = new List<string>();

                    foreach (FamilyParameter parameter in famMan.Parameters)
                    {
                        if (!columnHeadersList.Contains(parameter.Definition.Name))
                        {
                            columnHeadersList.Add(parameter.Definition.Name);
                            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();                            
                            newColumn.HeaderText = parameter.Definition.Name;
                            tableToExport.Columns.Add(newColumn);
                        }                       
                    }
                    famDoc.Close(false);
                    
                    for(int i = 0; i<familySymbols.Count;i++)
                    {
                        FamilySymbol familySymbol = familySymbols[i];
                        int rowIndex = tableToExport.Rows.Add();
                        DataGridViewRow row = tableToExport.Rows[i];
                        foreach (DataGridViewTextBoxColumn column in tableToExport.Columns)
                        {
                            if (column.HeaderText == "Type")
                            {
                                row.Cells[column.Index].Value = familySymbol.Name;
                            }
                            else
                            {
                                try
                                {
                                    string value = familySymbol.GetParameters(column.HeaderText).First().AsString();
                                    row.Cells[column.Index].Value = value;
                                }
                                catch
                                {
                                    row.Cells[column.Index].Value = "";
                                    continue;
                                }
                            }
                        }
                    }
                    return tableToExport;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }
            }
            else
            {
                MessageBox.Show(String.Format("Could not find the family '{0}' in the project. Please load it first.", Path.GetFileNameWithoutExtension(Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule)));
                return null;
            }
        }
        private void MaterialsCMSExcelSelectImportFileButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string excelFile = GeneralOperations.GetExcelFile();
            if (excelFile != "")
            {
                DataGridView dgv = uiForm.materialsCMSExcelDataGridView;
                DataTable dt = ExcelOperations.ExcelTableToDataTable(excelFile, true);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                if (dgv.Rows.Count > 0)
                {
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dgv.Rows[0].Frozen = true;
                    dgv.Rows[0].ReadOnly = true;
                    dgv.RowHeadersVisible = false;
                    dgv.AllowUserToOrderColumns = false;
                    dgv.Update();
                    dgv.Refresh();
                }
            }
        }
        private void MaterialsCMSExcelCreateSymbolsButton_Click(object sender, EventArgs e)
        {
            if (uiApp.ActiveUIDocument.Document.ActiveView.Name != "ID Material View" && uiApp.ActiveUIDocument.Document.ActiveView.Name != Application.thisApp.newMainUi.materialsCMSSetViewNameTextBox.Text)
            {
                if (BARevitTools.Application.thisApp.newMainUi.materialsCMSExcelDataGridView.Rows.Count > 0)
                {
                    m_ExEvent.Raise();
                    MakeRequest(RequestId.materialsCMS);
                }
            }
            else
            {
                MessageBox.Show(String.Format("This cannot be ran from the '{0}' view. Please switch to a different view temporarily.", uiApp.ActiveUIDocument.ActiveView.Name));
            }
            
        }
        #endregion materialsCMS

        #region materialsAML
        public MaterialsAMLPalette materialsAMLPalette = null;
        public void MaterialsAMLButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.materialsAMLDataGridView;
            SwitchActivePanel(ReferencedSwitchCaseIds.materialsAML);
            MaterialsAMLUpdateDGV(dgv);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.materialsAMLguid, materialsAMLButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        public void MaterialsAMLUpdateDGV(DataGridView dgv)
        {
            GeneralOperations.ResetDataGridView(dgv);
            CategoryNameMap linestyleSubCats = RVTGetElementsByCollection.DocumentLineStyles(uiApp);
            Dictionary<string, Category> linestyleDict = new Dictionary<string, Category>();
            foreach (Category lineStyle in linestyleSubCats)
            {
                linestyleDict[lineStyle.Name.Replace("ID ", "")] = lineStyle;
            }

            DatabaseOperations.CollectUserInputData(ReferencedGuids.materialsAMLguid, materialsAMLButton.Text, Environment.UserName.ToString(), DateTime.Now);
            DataTable dt = this.MaterialsAMLCreateDataTable();
            if (dt != null)
            {
                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                checkboxColumn.HeaderText = "Select";
                checkboxColumn.Name = "Select";
                dgv.Columns.Add(checkboxColumn);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                DataGridViewButtonColumn setColorColumn = new DataGridViewButtonColumn();
                setColorColumn.HeaderText = "Color";
                setColorColumn.Name = "Color";
                setColorColumn.FlatStyle = FlatStyle.Popup;
                dgv.Columns.Add(setColorColumn);
                DataGridViewCheckBoxColumn updatedColumn = new DataGridViewCheckBoxColumn();
                updatedColumn.Name = "Updated";
                updatedColumn.Visible = false;
                dgv.Columns.Add(updatedColumn);

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (linestyleDict.Keys.Contains(row.Cells["Mark"].Value.ToString()))
                    {
                        Autodesk.Revit.DB.Color adskColor = linestyleDict[row.Cells["Mark"].Value.ToString()].LineColor;
                        int red = Convert.ToInt32(adskColor.Red);
                        int green = Convert.ToInt32(adskColor.Green);
                        int blue = Convert.ToInt32(adskColor.Blue);
                        System.Drawing.Color linestyleColor = System.Drawing.Color.FromArgb(red, green, blue);
                        row.Cells["Select"].Value = true;
                        row.Cells["Select"].Style.BackColor = System.Drawing.Color.GreenYellow;
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
                        row.Cells["Color"].Style.BackColor = linestyleColor;
                    }
                    else
                    {
                        row.Cells["Color"].Style.BackColor = System.Drawing.Color.Black;
                    }

                    row.Cells["Mark"].ReadOnly = true;
                    row.Cells["IDUse"].ReadOnly = true;
                }

                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach(DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgv.Update();
                dgv.Refresh();
            }
        }
        public DataTable MaterialsAMLCreateDataTable()
        {
            DataTable dt = null;
            //Obtaining the family types from the family file for the ID Material Symbols from the CMS tool's name for the family to load
            List<FamilySymbol> idMaterialFamilyTypes = RVTGetElementsByCollection.FamilyTypesByFamilyName(uiApp, Path.GetFileNameWithoutExtension(BARevitTools.Properties.Settings.Default.RevitFamilyMaterialsCMSSymbIdMaterialSchedule));
            if (idMaterialFamilyTypes != null)
            {
                dt = new DataTable();
                DataColumn materialIDUse = dt.Columns.Add("IDUse", typeof(String));
                DataColumn materialMark = dt.Columns.Add("Mark", typeof(String));
                foreach (FamilySymbol symbol in idMaterialFamilyTypes)
                {
                    DataRow row = dt.NewRow();
                    row["IDUse"] = symbol.GetParameters("ID Use")[0].AsString();
                    row["Mark"] = symbol.GetParameters("Mark")[0].AsString();
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        private void MaterialsAMLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.materialsAMLDataGridView;
            if (dgv.CurrentCell.ColumnIndex == 3)
            {
                DataGridViewCell cell = dgv.CurrentCell;
                try
                {
                    System.Windows.Forms.ColorDialog clrDialog = CustomColors.CustomColorDialog();
                    
                    if (clrDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.Drawing.Color color = clrDialog.Color;
                        cell.Style.BackColor = color;
                        dgv.Rows[cell.RowIndex].Cells["Updated"].Value = true;
                        dgv.ClearSelection();
                        dgv.CurrentCell = null;
                    }
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.ToString());
                }
            }

            else if (dgv.CurrentCell.ColumnIndex == 0)
            {
                var rowValue = dgv.CurrentCell.Value;
                if (rowValue == null)
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        int rowIndex = row.Index;
                        dgv.Rows[rowIndex].Cells["Select"].Value = true;
                        row.Cells["Select"].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else if (rowValue.ToString() == "True")
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        int rowIndex = row.Index;
                        dgv.Rows[rowIndex].Cells["Select"].Value = false;
                        row.Cells["Select"].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        int rowIndex = row.Index;
                        dgv.Rows[rowIndex].Cells["Select"].Value = true;
                        row.Cells["Select"].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else
            {
                dgv.ClearSelection();
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void MaterialsAMLLaunchPaletteButton_Click(object sender, EventArgs e)
        {
            try
            {
                materialsAMLPalette.Close();
            }
            catch {; }

            materialsAMLPalette = new MaterialsAMLPalette();
            m_ExEvent.Raise();
            MakeRequest(RequestId.materialsAML);
        }
        public void MaterialsAMLPaletteRun_Click()
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.materialsAMLPalette);
        }
        #endregion materialsAML

        #region roomsSRNN
        private void RoomsSRNNButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.roomsSRNN);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.roomsSRNNguid, roomsSRNNButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void RoomsSRRNUrlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(BARevitTools.Properties.Settings.Default.UrlRoomsSRRN);
        }
        private void RoomsSRNNRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.roomsSRNN);
        }
        #endregion roomsSRNN

        #region roomsCDRT
        private void RoomsCDRTButton_Click(object sender, EventArgs e)
        {
            if (Application.thisApp.CadDriveIsAccessible == false)
            {
                DisableUIFeatures.DisableControls(Application.thisApp.newMainUi.roomsCDRTLayoutPanel.Controls, Properties.Settings.Default.RevitCadDrive);
            }
            SwitchActivePanel(ReferencedSwitchCaseIds.roomsCDRT);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.roomsCDRTguid, roomsCDRTButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void RoomsCDRTRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.roomsCDRT);
        }
        #endregion roomsCDRT

        #region wallsMPW
        public void WallsMPWButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.wallsMPWComboBoxWall.Items.Clear();
            uiForm.wallsMPWNumericUpDownWallHeightFt.Value = 0;
            uiForm.wallsMPWNumericUpDownWallHeightIn.Value = 0;
            this.SwitchActivePanel(ReferencedSwitchCaseIds.wallsMPW);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.wallsMPWguid, wallsMPWButton.Text, Environment.UserName.ToString(), DateTime.Now);

            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector wallTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> existingWallTypes = wallTypesCollector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsElementType().ToElements();
            SortedList<string, ElementId> sortedExistingWallTypes = new SortedList<string, ElementId>();
            foreach (WallType existingWallType in existingWallTypes)
            {
                sortedExistingWallTypes.Add(existingWallType.Name, existingWallType.Id);
            }
            foreach (string key in sortedExistingWallTypes.Keys)
            {
                uiForm.wallsMPWComboBoxWall.Items.Add(key);
                uiForm.wallsMPWComboBoxWall.Update();
                uiForm.wallsMPWComboBoxWall.Refresh();
            }
            uiForm.Update();
            uiForm.Refresh();
        }
        public void WallsMPWRun_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.wallsMPW);
        }
        #endregion wallsMPW

        #region wallsDP
        private void WallsDPButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.wallsDP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.wallsDPguid, wallsDPButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void WallsDPRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.wallsDP);
        }
        #endregion wallsDP

        //
        // Documentation Tab
        #region sheetsCSL
        public void SheetsCSLButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sheetsCSLComboBox.Items.Clear();
            uiForm.sheetsCSLProgressBar.Visible = false;
            uiForm.SwitchActivePanel(ReferencedSwitchCaseIds.sheetsCSL);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.sheetsCSLguid, sheetsCSLButton.Text, Environment.UserName.ToString(), DateTime.Now);

            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            SortedList<string, ElementId> sortedSheetNumbers = new SortedList<string, ElementId>();

            #region Update ComboBox
            foreach (ViewSheet sheet in sheetsCollector)
            {
                if (!sheet.IsPlaceholder)
                {
                    sortedSheetNumbers.Add(sheet.SheetNumber, sheet.Id);
                }
                else { continue; }

            }
            foreach (string key in sortedSheetNumbers.Keys)
            {
                this.sheetsCSLComboBox.Items.Add(key);
            }
            uiForm.sheetsCSLComboBox.Update();
            uiForm.sheetsCSLComboBox.Refresh();
            #endregion Update ComboBox

            #region Update DataGridView
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Width = 75;
            checkBoxColumn.Name = "Select";
            DataGridView dataGridView = uiForm.sheetsCSLDataGridView;
            dataGridView.Columns.Add(checkBoxColumn);

            dataGridView.ColumnCount = 3;
            dataGridView.Columns[1].Name = "Sheet Number";
            dataGridView.Columns[1].Width = 75;
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.Columns[2].Name = "Sheet Name";
            dataGridView.Columns[2].Width = 250;
            dataGridView.Columns[2].ReadOnly = true;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Sort(dataGridView.Columns[1], ListSortDirection.Descending);
            dataGridView.AutoGenerateColumns = true;
            dataGridView.RowHeadersVisible = false;
            #endregion Update DataGridView
        }
        public void SheetsCSLComboBox_TextChanged(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dataGridView = uiForm.sheetsCSLDataGridView;
            dataGridView.Rows.Clear();
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var sheetsCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            foreach (ViewSheet sheet in sheetsCollector)
            {
                if (sheet.SheetNumber.ToString() != this.sheetsCSLComboBox.Text.ToString() && sheet.IsPlaceholder == false)
                {
                    dataGridView.Rows.Add(null, sheet.SheetNumber.ToString(), sheet.Name.ToString());
                }
            }
            dataGridView.Sort(dataGridView.Columns["Sheet Number"], ListSortDirection.Ascending);
            dataGridView.Update();
            dataGridView.Refresh();
        }
        private void SheetsCSLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dataGridView = uiForm.sheetsCSLDataGridView;
            if (dataGridView.Rows.Count > 0 && dataGridView.CurrentCell != null)
            {
                var rowValue = dataGridView.CurrentCell.Value;
                if (dataGridView.CurrentCell.ColumnIndex == 0)
                {
                    if (rowValue == null)
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["Select"].Value = true;
                            row.Cells["Select"].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["Select"].Value = false;
                            row.Cells["Select"].Style.BackColor = dataGridView.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["Select"].Value = true;
                            row.Cells["Select"].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }                
            
            dataGridView.Update();
            dataGridView.Refresh();
        }
        private void SheetsCSLFilterConditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SheetsCSLFilterRows();
        }
        private void SheetsCSLFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SheetsCSLFilterRows();
        }
        private void SheetsCSLFilterRows()
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string condition = uiForm.sheetsCSLFilterConditionComboBox.Text;
            string searchString = uiForm.sheetsCSLFilterTextBox.Text;
            DataGridView dgv = uiForm.sheetsCSLDataGridView;

            if (condition != "<Condition>" && searchString != "" && searchString != "<Search String>")
            {
                try
                {
                    if (condition == "CONTAINS")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string sheetNumber = row.Cells["Sheet Number"].Value.ToString();
                            string sheetName = row.Cells["Sheet Name"].Value.ToString();
                            Match matchNumber = Regex.Match(sheetNumber, searchString, RegexOptions.IgnoreCase);
                            Match matchName = Regex.Match(sheetName, searchString, RegexOptions.IgnoreCase);
                            if (matchNumber.Success || matchName.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; }
                        }
                        dgv.Update();
                    }
                    if (condition == "DOES NOT CONTAIN")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string sheetNumber = row.Cells["Sheet Number"].Value.ToString();
                            string sheetName = row.Cells["Sheet Name"].Value.ToString();
                            Match matchNumber = Regex.Match(sheetNumber, searchString, RegexOptions.IgnoreCase);
                            Match matchName = Regex.Match(sheetName, searchString, RegexOptions.IgnoreCase);
                            if (!matchNumber.Success && !matchName.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; }
                        }
                        dgv.Update();
                    }
                }
                catch {; }
            }
            else
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Visible = true;
                }
                dgv.Update();
            }
        }
        private void SheetsCSLRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.sheetsCSL);
        }
        #endregion sheetsCSL

        #region sheetsISFL
        private void SheetsISFLButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            this.sheetsISFLComboBox.Items.Clear();
            this.sheetsISFLDisciplineComboBox.Items.Clear();
            this.sheetsISFLComboBox.Text = "<Originating Link>";
            this.sheetsISFLDisciplineComboBox.Text = "<Select BA Discipline>";
            this.sheetsISFLDataGridView.Rows.Clear();
            this.SwitchActivePanel(ReferencedSwitchCaseIds.sheetsISFL);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.sheetsISFLguid, sheetsISFLButton.Text, Environment.UserName.ToString(), DateTime.Now);
            UIDocument uidoc = uiApp.ActiveUIDocument;

            #region Get Links                     
            SortedList<string, string> sortedLinkTitles = new SortedList<string, string>();
            List<RVTDocument> linkDocs = new List<RVTDocument>();
            foreach (RVTDocument appDoc in uiApp.Application.Documents)
            {
                if (appDoc.IsLinked)
                {
                    sortedLinkTitles.Add(appDoc.Title, appDoc.Title);
                    linkDocs.Add(appDoc);
                }
            }
            #endregion Get Links

            #region Update Links ComboBox            
            foreach (string key in sortedLinkTitles.Keys)
            {
                this.sheetsISFLComboBox.Items.Add(key);
            }
            this.sheetsISFLComboBox.Update();
            this.sheetsISFLComboBox.Refresh();
            #endregion Update Links ComboBox

            #region Get Sheet Disciplines
            SortedList<string, string> sortedSheetDisciplines = new SortedList<string, string>();
            var hostDocSheets = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            foreach (ViewSheet sheet in hostDocSheets)
            {
                try
                {
                    IList<Parameter> parameters = sheet.GetParameters("BA Sheet Discipline");
                    foreach (Parameter param in parameters)
                    {
                        if (param.AsString() != null)
                        {
                            string keyValue = NumberOperations.PadNumbers(param.AsString());
                            sortedSheetDisciplines.Add(keyValue, param.AsString());
                        }
                        else { continue; }
                    }
                }
                catch { continue; }
            }
            #endregion Get Sheet Disciplines

            #region Update Disciplines ComboBox
            foreach (string key in sortedSheetDisciplines.Keys)
            {
                this.sheetsISFLDisciplineComboBox.Items.Add(sortedSheetDisciplines[key]);
            }
            this.sheetsISFLDisciplineComboBox.Update();
            this.sheetsISFLDisciplineComboBox.Refresh();
            #endregion Update Disciplines ComboBox

            #region Update DataGridView
            DataGridView dataGridView = uiForm.sheetsISFLDataGridView;

            DataGridViewCheckBoxColumn toAddCheckBoxColumn = new DataGridViewCheckBoxColumn();
            toAddCheckBoxColumn.HeaderText = "To Add";
            toAddCheckBoxColumn.Width = 75;
            toAddCheckBoxColumn.Name = "To Add";
            dataGridView.Columns.Add(toAddCheckBoxColumn);

            DataGridViewCheckBoxColumn preexistsCheckBoxColumn = new DataGridViewCheckBoxColumn();
            preexistsCheckBoxColumn.HeaderText = "Pre-exists";
            preexistsCheckBoxColumn.Width = 75;
            preexistsCheckBoxColumn.Name = "Pre-exists";
            preexistsCheckBoxColumn.ReadOnly = true;
            dataGridView.Columns.Add(preexistsCheckBoxColumn);

            dataGridView.ColumnCount = 6;
            dataGridView.Columns[2].Name = "Sheet Number";
            dataGridView.Columns[2].Width = 75;
            dataGridView.Columns[2].ReadOnly = true;
            dataGridView.Columns[3].Name = "Host Sheet Name";
            dataGridView.Columns[3].Width = 175;
            dataGridView.Columns[4].Name = "Link Sheet Name";
            dataGridView.Columns[4].Width = 175;
            dataGridView.Columns[4].ReadOnly = true;
            dataGridView.Columns[5].Name = "Discipline";
            dataGridView.Columns[5].Width = 175;
            dataGridView.Columns[5].ReadOnly = true;

            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.RowHeadersVisible = false;
            #endregion Update DataGridView
        }
        public void SheetsISFLComboBox_TextChanged(object sender, EventArgs e)
        {
            RVTDocument linkDoc = SheetsISFLGetLinkDoc();
            if (linkDoc != null)
            {
                SheetsISFLUpdateDataGridView(linkDoc);
            }
        }
        public RVTDocument SheetsISFLGetLinkDoc()
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            RVTDocument linkDocToUse = null;
            List<RVTDocument> linkDocs = new List<RVTDocument>();
            string linkDocName = this.sheetsISFLComboBox.Text;
            foreach (RVTDocument appDoc in uiApp.Application.Documents)
            {
                if (appDoc.IsLinked)
                {
                    linkDocs.Add(appDoc);
                }
            }
            foreach (RVTDocument linkDoc in linkDocs)
            {
                if (linkDoc.Title == linkDocName)
                {
                    linkDocToUse = linkDoc;
                    break;
                }
                else { continue; }
            }
            return linkDocToUse;
        }
        private void SheetsISFLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dataGridView = uiForm.sheetsISFLDataGridView;
            if (dataGridView.Rows.Count > 0)
            {
                var rowValue = dataGridView.CurrentCell.Value;
                int columnIndex = dataGridView.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == null)
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Value = true;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Value = false;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Style.BackColor = dataGridView.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Value = true;
                            dataGridView.Rows[rowIndex].Cells["To Add"].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dataGridView.Update();
            dataGridView.Refresh();
        }
        public void SheetsISFLUpdateDataGridView(RVTDocument linkDoc)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sheetsISFLDataGridView.Rows.Clear();
            DataGridView dataGridView = uiForm.sheetsISFLDataGridView;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;

            var linkDocSheets = new FilteredElementCollector(linkDoc).OfClass(typeof(ViewSheet)).ToElements();
            var hostDocSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();
            Dictionary<string, Element> hostSheetDict = new Dictionary<string, Element>();
            List<string> hostSheetNumbers = new List<string>();
            Dictionary<string, Element> linkSheetDict = new Dictionary<string, Element>();
            List<string> linkSheetNumbers = new List<string>();

            foreach (ViewSheet hostSheet in hostDocSheets)
            {
                hostSheetDict.Add(hostSheet.SheetNumber.ToString(), hostSheet);
                hostSheetNumbers.Add(hostSheet.SheetNumber.ToString());
            }

            foreach (ViewSheet linkSheet in linkDocSheets)
            {
                linkSheetDict.Add(linkSheet.SheetNumber.ToString(), linkSheet);
                linkSheetNumbers.Add(linkSheet.SheetNumber);
            }

            foreach (string linkSheetNumber in linkSheetNumbers)
            {
                if (hostSheetDict.ContainsKey(linkSheetNumber))
                {
                    string hostSheetDiscipline = "";
                    try
                    {
                        IList<Parameter> parameters = hostSheetDict[linkSheetNumber].GetParameters("BA Sheet Discipline");
                        foreach (Parameter param in parameters)
                        {
                            if (param.AsString() != null)
                            {
                                hostSheetDiscipline = param.AsString();
                            }
                            else { continue; }
                        }
                    }
                    catch { continue; }
                    int rowIndex = dataGridView.Rows.Add(null, true, linkSheetNumber, hostSheetDict[linkSheetNumber].Name, linkSheetDict[linkSheetNumber].Name, hostSheetDiscipline);
                    dataGridView.Rows[rowIndex].Cells[1].Style.BackColor = System.Drawing.Color.Gray;
                }
                else
                {
                    dataGridView.Rows.Add(null, false, linkSheetNumber, "", linkSheetDict[linkSheetNumber].Name, "");
                }
            }
            dataGridView.Sort(dataGridView.Columns["Sheet Number"], ListSortDirection.Ascending);
        }
        private void SheetsISFLDisciplineUpdateButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dataGridView = uiForm.sheetsISFLDataGridView;
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                int rowIndex = row.Index;
                dataGridView.Rows[rowIndex].Cells["Discipline"].Value = uiForm.sheetsISFLDisciplineComboBox.Text;
            }
            dataGridView.Update();
            dataGridView.Refresh();
        }
        private void SheetsISFLRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.sheetsISFL);
        }
        #endregion sheetsISFL

        #region sheetsCSSFS
        public Dictionary<string, ViewSchedule> sheetsCSSFSDictionary = null;
        private void SheetsCSSFSButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            SortedList<string, String> sortedScheduleList = new SortedList<string, string>();
            sheetsCSSFSDictionary = new Dictionary<string, ViewSchedule>();

            Categories categories = uidoc.Document.Settings.Categories;

            var schedules = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSchedule)).ToElements();
            foreach (ViewSchedule schedule in schedules)
            {
                try
                {
                    ElementId categoryId = schedule.Definition.CategoryId;
                    foreach (Category cat in categories)
                    {
                        if (cat.Id == categoryId && cat.Name == "Sheets")
                        {
                            sortedScheduleList.Add(schedule.Name, schedule.Name);
                            sheetsCSSFSDictionary.Add(schedule.Name, schedule);
                        }
                    }
                }
                catch { continue; }

            }
            foreach (string schedulename in sortedScheduleList.Keys)
            {
                uiForm.sheetsCSSFSScheduleComboBox.Items.Add(schedulename);
            }
            SwitchActivePanel(ReferencedSwitchCaseIds.sheetsCSSFS);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.sheetsCSSFSguid, sheetsCSSFSButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void SheetsCSSFSRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.sheetsCSSFS);
        }
        #endregion sheetsCSSFS

        #region sheetsOSS
        public DataTable sheetsOSSDataTable = null;
        public void SheetsOSSButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.sheetsOSSFilterConditionComboBox.Text = "<Condition>";
            uiForm.sheetsOSSFilterTextBox.Text = "<Search String>";

            DataGridView dgv = uiForm.sheetsOSSDataGridView;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            var viewSheetSets = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheetSet)).ToElements();
            var viewSheets = new FilteredElementCollector(uidoc.Document).OfClass(typeof(ViewSheet)).ToElements();
            DataTable dt = new DataTable();
            sheetsOSSDataTable = dt;

            DataColumn sheetNumberColumn = dt.Columns.Add("Sheet Number");
            sheetNumberColumn.ReadOnly = true;
            DataColumn sheetNameColumn = dt.Columns.Add("Sheet Name");
            sheetNameColumn.ReadOnly = true;            
            DataColumn sheetIdColumn = dt.Columns.Add("Sheet Id", typeof(Int32));
            sheetIdColumn.ReadOnly = true;

            foreach (ViewSheet viewSheet in viewSheets)
            {
                if (!viewSheet.IsPlaceholder)
                {
                    DataRow row = dt.NewRow();
                    row["Sheet Number"] = viewSheet.SheetNumber;
                    row["Sheet Name"] = viewSheet.Name;
                    row["Sheet Id"] = viewSheet.Id.IntegerValue;
                    foreach (ViewSheetSet ss in viewSheetSets)
                    {
                        if (!dt.Columns.Contains(ss.Name))
                        {
                            DataColumn column = dt.Columns.Add(ss.Name, typeof(Boolean));
                            column.ReadOnly = false;
                        }
                        else if (ss.Views.Contains(viewSheet))
                        {
                            row[ss.Name.ToString()] = true;
                        }
                        else { row[ss.Name.ToString()] = false; }
                    }
                    dt.Rows.Add(row);
                }
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dgv.DataSource = bindingSource;
                dgv.Sort(dgv.Columns["Sheet Number"], ListSortDirection.Ascending);
                dgv.Columns["Sheet Name"].Width = 150;
                dgv.Columns["Sheet Id"].Visible = false;
                dgv.Update();
            }

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            SwitchActivePanel(ReferencedSwitchCaseIds.sheetsOSS1);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.sheetsOSSguid, sheetsOSSButton.Text, Environment.UserName.ToString(), DateTime.Now);
            GraphicsFormatting.HighlightCellsFromDataGridView(dgv, System.Drawing.Color.GreenYellow);
        }
        private void SheetsOSSFilterFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SheetsOSSFilterRows();
        }
        private void SheetsOSSFilterConditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SheetsOSSFilterRows();
        }
        private void SheetsOSSFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SheetsOSSFilterRows();
        }
        private void SheetsOSSFilterRows()
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string condition = uiForm.sheetsOSSFilterConditionComboBox.Text;
            string searchString = uiForm.sheetsOSSFilterTextBox.Text;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;
            if (condition != "<Condition>" && searchString != "" && searchString != "<Search String>")
            {
                try
                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgv.DataSource];
                    currencyManager.SuspendBinding();
                    if (condition == "CONTAINS")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string sheetNumber = row.Cells[0].Value.ToString();
                            string sheetName = row.Cells[1].Value.ToString();
                            Match matchName = Regex.Match(sheetName, searchString, RegexOptions.IgnoreCase);
                            Match matchNumber = Regex.Match(sheetNumber, searchString, RegexOptions.IgnoreCase);
                            if (matchName.Success || matchNumber.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; }
                        }
                        dgv.Update();
                    }
                    if (condition == "DOES NOT CONTAIN")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string sheetNumber = row.Cells[0].Value.ToString();
                            string sheetName = row.Cells[1].Value.ToString();
                            Match matchName = Regex.Match(sheetName, searchString, RegexOptions.IgnoreCase);
                            Match matchNumber = Regex.Match(sheetNumber, searchString, RegexOptions.IgnoreCase);
                            if (!matchName.Success && !matchNumber.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; }
                        }
                        dgv.Update();
                    }
                    currencyManager.ResumeBinding();
                }
                catch {; }
            }
            else
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Visible = true;
                }
            }
        }
        private void SheetsOSSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.sheetsOSSDataGridView;
            if (dgv.Rows.Count > 0 && dgv.CurrentCell != null)
            {
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex > 2)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void SheetsOSSNewSetButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.sheetSOSSNewSet)
;
        }
        private void SheetsOSSRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.sheetsOSS);
        }
        #endregion sheetsOSS

        #region viewsCEPR
        private void ViewsCEPR_Click(object sender, EventArgs e)
        {
            this.viewsCEPRElevationComboBox.Items.Clear();
            this.viewsCEPRCropCheckBox.CheckState = CheckState.Unchecked;
            this.viewsCEPROverrideCheckBox.CheckState = CheckState.Unchecked;
            this.viewsCEPRCropMethodComboBox.SelectedIndex = 0;
            this.SwitchActivePanel(ReferencedSwitchCaseIds.viewsCEPR);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.viewsCEPRguid, viewsCEPRButton.Text, Environment.UserName.ToString(), DateTime.Now);

            UIDocument uidoc = uiApp.ActiveUIDocument;
            FilteredElementCollector viewTypesCollector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> viewTypes = viewTypesCollector.OfClass(typeof(ViewFamilyType)).ToElements();
            SortedList<string, ElementId> viewTypeNames = new SortedList<string, ElementId>();
            foreach (ViewFamilyType viewType in viewTypes)
            {
                if (viewType.ViewFamily.ToString() == "Elevation")
                {
                    viewTypeNames.Add(viewType.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_NAME).AsString(), viewType.Id);
                }
            }
            foreach (string key in viewTypeNames.Keys)
            {
                this.viewsCEPRElevationComboBox.Items.Add(key);
                this.viewsCEPRElevationComboBox.Update();
                this.viewsCEPRElevationComboBox.Refresh();
            }
            this.Update();
            this.Refresh();

        }
        private void ViewsCEPRCropCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            MainUI uiForm = Application.thisApp.newMainUi;
            if (uiForm.viewsCEPRCropCheckBox.Checked)
            {
                viewsCEPRCropMethodComboBox.Visible = true;
            }
            else
            {
                viewsCEPRCropMethodComboBox.Visible = false;
            }
        }
        private void ViewsCEPRUrlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(BARevitTools.Properties.Settings.Default.UrlViewsCEPR);
        }
        private void ViewsCEPRRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.viewsCEPR);
        }
        #endregion viewsCEPR

        #region viewsOICB
        private void ViewsOICBButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.viewsOICB);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.viewsOICBguid, viewsOICBButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void ViewsOCIBRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.viewsOICB);
        }
        #endregion viewsOICB

        #region viewsHNIECB
        private void ViewsHNIECButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.viewsHNIEC);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.viewsHNIECguid, viewsHNIECButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void ViewsHNIECBRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.viewsHNIEC);
        }
        #endregion viewsHNIECB

        // MANAGEMENT TAB
        #region dataEPI
        private void DataEPIButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.dataEPI);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.dataEPIguid, dataEPIButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void DataEPIDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.ToString() != "")
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                uiForm.dataEPIDirectorySelectedLabel.Text = Path.GetFullPath(selectedDirectory);
            }
        }
        private void DataEPIRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.dataEPI);
        }
        #endregion dataEPI        

        #region miscEDV
        private void MiscEDVButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.miscEDVFilterConditionComboBox.Text = "<Condition>";
            uiForm.miscEDVFilterStringTextBox.Text = "<Search String>";
            uiForm.miscEDVProgressBar.Visible = false;

            DataTable dt = new DataTable();
            DataColumn column = dt.Columns.Add("Select", typeof(Boolean));
            column.ReadOnly = false;

            DataColumn viewNameColumn = dt.Columns.Add("View Name", typeof(String));
            viewNameColumn.ReadOnly = true;

            DataColumn viewElementColumn = dt.Columns.Add("View Element", typeof(Object));
            viewElementColumn.ReadOnly = true;
            

            DataGridView dgv = uiForm.miscEDVDataGridView;

            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var draftingViews = RVTGetElementsByCollection.DocumentDraftingViews(uiApp);
            foreach (ViewDrafting view in draftingViews)
            {
                if (view.Name != "")
                {
                    DataRow row = dt.NewRow();
                    row["View Name"] = view.Name;
                    row["View Element"] = view;
                    dt.Rows.Add(row);
                }
            }

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dgv.DataSource = bindingSource;
            dgv.Columns["Select"].Width = 45;
            dgv.Columns["Select"].Name = "Select";
            dgv.Columns["View Name"].Width = dgv.Width - 45;
            dgv.Columns["View Element"].Visible = false;
            dgv.Sort(dgv.Columns["View Name"], ListSortDirection.Ascending);
            dgv.Update();
            dgv.Refresh();
            SwitchActivePanel(ReferencedSwitchCaseIds.miscEDV);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.miscEDVguid, miscEDVButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void MiscEDVSelectDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.ToString() != "")
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                uiForm.miscEDVSelectDirectoryTextBox.Text = Path.GetFullPath(selectedDirectory);
            }
        }
        private void MiscEDVDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.miscEDVDataGridView;
            if (dgv.Rows.Count > 0)
            {
                var rowValue = "";
                try
                {
                    rowValue = dgv.CurrentCell.Value.ToString();
                }
                catch { rowValue = ""; }

                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void MiscEDVSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.miscEDVDataGridView.Rows)
            {
                if (row.Visible)
                {
                    row.Cells[0].Value = true;
                    row.Cells[0].Style.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
        }
        private void MiscEDVSelectNoneButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.miscEDVDataGridView.Rows)
            {
                if (row.Visible)
                {
                    row.Cells[0].Value = false;
                    row.Cells[0].Style.BackColor = Application.thisApp.newMainUi.miscEDVDataGridView.DefaultCellStyle.BackColor;
                }
            }
        }
        private void MiscEDVFilterConditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MiscEDVFilterRows();
        }
        private void MiscEDVFilterStringTextBox_TextChanged(object sender, EventArgs e)
        {
            this.MiscEDVFilterRows();
        }
        private void MiscEDVFilterRows()
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string condition = uiForm.miscEDVFilterConditionComboBox.Text;
            string searchString = uiForm.miscEDVFilterStringTextBox.Text;
            DataGridView dgv = uiForm.miscEDVDataGridView;

            if (condition != "<Condition>" && searchString != "" && searchString != "<Search String>")
            {
                try
                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgv.DataSource];
                    currencyManager.SuspendBinding();
                    if (condition == "CONTAINS")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string viewName = row.Cells[1].Value.ToString();
                            Match match = Regex.Match(viewName, searchString, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; row.Cells[0].Value = false; }
                        }
                        dgv.Update();
                    }
                    if (condition == "DOES NOT CONTAIN")
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string viewName = row.Cells[1].Value.ToString();
                            Match match = Regex.Match(viewName, searchString, RegexOptions.IgnoreCase);
                            if (!match.Success)
                            {
                                row.Visible = true;
                            }
                            else { row.Visible = false; row.Cells[0].Value = false; }
                        }
                        dgv.Update();
                    }
                    currencyManager.ResumeBinding();
                }
                catch {; }
            }
            else
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Visible = true;
                }
            }
        }
        private void MiscEDVRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.miscEDV);
        }
        #endregion miscEDV

        #region documentsCTS
        private void DocumentsCTSButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.documentsCTS);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.documentsCTSguid, documentsCTSButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void DocumentsCTSRun_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.documentsCTS);
        }
        #endregion documentsCTS

        private void QaqcCapitalizeValuesButton_ButtonClick(object sender, EventArgs e)
        {
            this.qaqcCSVNPanel.Visible = false;
            this.qaqcDRNPPanel.Visible = false;
            this.qaqcDRNPButtton.Checked = false;
            this.qaqcCSVLayoutPanel.Visible = false;
            this.qaqcRLSLayoutPanel.Visible = false;
            this.qaqcRLSButton.Checked = false;
        }

        #region qaqcCSVN
        private void QaqcCSVN_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.qaqcCSVN);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.qaqcCSVNguid, capitalizeSheetViewNamesButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void QaqcCSVNRun_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.qaqcCSVN);
        }
        #endregion qaqcCSVN

        #region qaqcDRNP
        private void QaqcDRNPButton_Click(object sender, EventArgs e)
        {
            this.SwitchActivePanel(ReferencedSwitchCaseIds.qaqcDRNP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.qaqcDRNPguid, qaqcDRNPButtton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void QaqcDRNPRun_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.qaqcDRNP);
        }
        #endregion qaqcDRNP       

        #region qaqcCSV
        private void QaqcCSVButton_Click(object sender, EventArgs e)
        {
            SwitchActivePanel(ReferencedSwitchCaseIds.qaqcCSV);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.qaqcCSVguid, capitalizeScheduleValuesButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void QaqcCSVRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.qaqcCSV);
        }
        #endregion qaqcCSV

        #region qaqcRLS
        public SortedDictionary<string, Category> qaqcLineStyleDict = null;
        private void QaqcRLSButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            uiForm.qaqcRLSDataGridView.DataSource = null;
            uiForm.qaqcRLSDeleteCheckBox.Checked = false;
            uiForm.qaqcRLSReplaceComboBox.Items.Clear();
            uiForm.qaqcRLSReplaceComboBox.Text = "<Replace>";
            uiForm.qaqcRLSReplaceWithComboBox.Items.Clear();
            uiForm.qaqcRLSReplaceWithComboBox.Text = "<With>";
            QaqcRLSSetReplaceComboBox(uiForm, doc);

            DatabaseOperations.CollectUserInputData(ReferencedGuids.qaqcRLSguid, qaqcRLSButton.Text, Environment.UserName.ToString(), DateTime.Now);
            SwitchActivePanel(ReferencedSwitchCaseIds.qaqcRLS);
        }
        public void QaqcRLSSetReplaceComboBox(MainUI uiForm, RVTDocument doc)
        {
            var lineStyleSubCats = RVTGetElementsByCollection.DocumentLineStyles(uiApp);

            List<string> lineStyleNames = new List<string>();
            qaqcLineStyleDict = new SortedDictionary<string, Category>();
            foreach (Category lineStyle in lineStyleSubCats)
            {
                qaqcLineStyleDict[lineStyle.Name] = lineStyle;
                lineStyleNames.Add(lineStyle.Name);
                uiForm.qaqcRLSReplaceComboBox.Items.Add(lineStyle.Name);
            }
        }
        private void QaqcRLSReplaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.qaqcRLSReplaceWithComboBox.Items.Clear();
            try
            {
                foreach (string lineStyleName in qaqcLineStyleDict.Keys)
                {
                    if (lineStyleName != uiForm.qaqcRLSReplaceComboBox.SelectedItem.ToString())
                    {
                        uiForm.qaqcRLSReplaceWithComboBox.Items.Add(lineStyleName);
                    }
                }
            }
            catch (Exception f)
            { MessageBox.Show(f.ToString()); }

        }
        private void QaqcRLSRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.qaqcRLS);
        }
        private void QaqcRLSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.qaqcRLSDataGridView;
            if (dgv.Rows.Count > 0 && dgv.SelectedCells[0].ColumnIndex == 0)
            {
                int elemIdNumber = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value.ToString());
                ElementId elemId = new ElementId(elemIdNumber);

                ICollection<ElementId> idCollections = new List<ElementId>
                {
                    elemId
                };
                uiApp.ActiveUIDocument.ShowElements(idCollections);
            }

        }
        #endregion qaqcRLS

        #region qaqcRFSP   
        public List<string> qaqcRFSPFamilyFiles = new List<string>();
        private void QaqcRFSPButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.qaqcRFSPParametersListBox.Items.Clear();
            SwitchActivePanel(ReferencedSwitchCaseIds.qaqcRFSP);
        }
        private void QaqcRFSPSelectFamilyButton_Click(object sender, EventArgs e)
        {
            string directory = GeneralOperations.GetDirectory();
            qaqcRFSPFamilyFiles = GeneralOperations.GetAllRvtFamilies(directory,false);
            BARevitTools.Application.thisApp.newMainUi.qaqcRFSPParametersListBox.Items.Clear();
            BARevitTools.Application.thisApp.newMainUi.qaqcRFSPSFamilyLabel.Text = directory;
        }
        private void QaqcRFSPRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.qaqcRFSP);
        }
        #endregion qaqcRFSP

        #region setupCWS
        private void SetupCWSButton_Click(object sender, EventArgs e)
        {
            SwitchActivePanel(ReferencedSwitchCaseIds.setupCWS);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.setupCWSguid, setupCWSButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void SetupCWSRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.setupCWS);
        }
        private void SetupCWSUserDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (e.Button == MouseButtons.Right)
            {
                uiForm.mgmtSetupCWSUserContextMenu.Show(uiForm.setupCWSUserDataGridView, e.Location);
                uiForm.mgmtSetupCWSUserContextMenu.Show(Cursor.Position);
            }
        }
        private void SetupCWSRowDeleteTool_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.setupCWSUserDataGridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    BARevitTools.Application.thisApp.newMainUi.setupCWSUserDataGridView.Rows.RemoveAt(row.Index);
                }
            }
        }
        #endregion setupCWS

        #region setupUP
        private void SetupUPButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;

            uiForm.setupUPUpgradingToRevitLabel.Text = uiApp.Application.VersionNumber;
            uiForm.setupUPUpgradedFilePathSetTextBox.Text = "";
            uiForm.setupUPUpgradedFilePathUserTextBox.Text = "";
            uiForm.setupUPOriginalFilePathTextBox.Text = "";
            uiForm.setupUPDataGridView.DataBindings.Clear();
            uiForm.setupUPDataGridView.Columns.Clear();
            uiForm.setupUPUpgradingFromRevitLabel.Text = "<Unknown>";
            uiForm.setupUPOriginalFilePathTextBox.BackColor = DefaultBackColor;
            uiForm.setupUPProgressBar.Value = 0;
            uiForm.setupUPProgressBar.Visible = false;
            SwitchActivePanel(ReferencedSwitchCaseIds.setupUP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.setupUPguid, setupUPButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void SetupUPOriginalPathSelectButton_Click(object sender, EventArgs e)
        {

            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string projectFile = RVTOperations.GetProjectFile();
            if (projectFile != String.Empty)
            {
                uiForm.setupUPUpgradedFilePathUserTextBox.Text = "";
                uiForm.setupUPUpgradedFilePathSetTextBox.Text = "<Upgraded File Path>";
                uiForm.setupUPUpgradingFromRevitLabel.ForeColor = System.Drawing.Color.Black;

                int projectRevitNumber = RVTOperations.GetRevitNumber(projectFile);
                if (RVTOperations.RevitVersionUpgradeCheck(uiApp, projectFile))
                {
                    uiForm.setupUPOriginalFilePathTextBox.Text = projectFile;
                    uiForm.setupUPUpgradingFromRevitLabel.Text = Convert.ToString(projectRevitNumber);
                }
                else
                {
                    uiForm.setupUPOriginalFilePathTextBox.Text = "Error: This cannot upgrade versions equal to or greater than the version running.";
                    uiForm.setupUPUpgradingFromRevitLabel.Text = Convert.ToString(projectRevitNumber);
                    uiForm.setupUPUpgradingFromRevitLabel.ForeColor = System.Drawing.Color.Red;
                }
                this.SetupUPCreateLinksTable(projectFile);
            }
        }
        private void SetupUPUpgradePathSelectButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.setupUPOriginalFilePathTextBox.BackColor = DefaultBackColor;
            if (uiForm.setupUPOriginalFilePathTextBox.Text != "<File to Upgrade>" && uiForm.setupUPOriginalFilePathTextBox.Text != "" && !uiForm.setupUPOriginalFilePathTextBox.Text.Contains("Error"))
            {
                string directory = GeneralOperations.GetDirectory();
                uiForm.setupUPUpgradedFilePathSetTextBox.Text = directory;
                string newName = RVTOperations.SetProjectUpgradeName(uiApp, uiForm.setupUPOriginalFilePathTextBox.Text);
                if (uiForm.setupUPUpgradedFilePathUserTextBox.Text == "")
                {
                    uiForm.setupUPUpgradedFilePathUserTextBox.Text = newName;
                }
            }
            else
            {
                MessageBox.Show("Pick a file to upgrade first.");
            }

        }
        private void SetupUPOriginalDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (uiForm.setupUPOriginalFilePathTextBox.Text != "<File to Upgrade>" && uiForm.setupUPOriginalFilePathTextBox.Text != "" && !uiForm.setupUPOriginalFilePathTextBox.Text.Contains("Error"))
            {
                string directory = System.IO.Path.GetDirectoryName(uiForm.setupUPOriginalFilePathTextBox.Text);
                uiForm.setupUPUpgradedFilePathSetTextBox.Text = directory;
                string newName = RVTOperations.SetProjectUpgradeName(uiApp, uiForm.setupUPOriginalFilePathTextBox.Text);
                if (uiForm.setupUPUpgradedFilePathUserTextBox.Text == "")
                {
                    uiForm.setupUPUpgradedFilePathUserTextBox.Text = newName;
                }

            }
            else
            {
                MessageBox.Show("Pick a file to upgrade first.");
            }
        }
        private void SetupUPCreateLinksTable(string projectFile)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            dgv.DataBindings.Clear();
            dgv.Columns.Clear();

            DataTable dt = new DataTable();
            DataColumn linksOriginalNameColumn = dt.Columns.Add("Original Name", typeof(String));
            DataColumn linksNewNameColumn = dt.Columns.Add("New Name", typeof(String));
            DataColumn linksNewDirectoryColumn = dt.Columns.Add("Directory", typeof(String));
            DataColumn linksOriginalPathColumn = dt.Columns.Add("Original Path", typeof(String));
            DataColumn linksNewPathColumn = dt.Columns.Add("New Path", typeof(String));
            DataColumn linksAllowUpgradeColumn = dt.Columns.Add("Allow Upgrade", typeof(Boolean));
            DataColumn linksUpgradeResultColumn = dt.Columns.Add("Upgrade Result", typeof(Boolean));

            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(projectFile);
            TransmissionData transData = TransmissionData.ReadTransmissionData(modelPath);
            if (transData != null && !uiForm.setupUPOriginalFilePathTextBox.Text.Contains("Error"))
            {
                DataGridViewCheckBoxColumn checkUpgradeColumn = new DataGridViewCheckBoxColumn();
                checkUpgradeColumn.HeaderText = "Upgrade";
                checkUpgradeColumn.Width = 60;
                checkUpgradeColumn.Name = "Upgrade";
                dgv.Columns.Add(checkUpgradeColumn);

                ICollection<ElementId> externalReferenceIds = transData.GetAllExternalFileReferenceIds();
                foreach (ElementId id in externalReferenceIds)
                {
                    ExternalFileReference externalFileReference = transData.GetDesiredReferenceData(id);
                    if (externalFileReference.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink && externalFileReference.GetLinkedFileStatus().ToString() != "NotFound")
                    {
                        DataRow row = dt.NewRow();
                        string linkPath = ModelPathUtils.ConvertModelPathToUserVisiblePath(externalFileReference.GetAbsolutePath());
                        string linkName = Path.GetFileNameWithoutExtension(linkPath);
                        string linkUpgradeName = "";
                        bool linkAllowUpgrade = false;
                        try
                        {
                            linkUpgradeName = RVTOperations.SetProjectUpgradeName(uiApp, linkPath);
                            linkAllowUpgrade = RVTOperations.RevitVersionUpgradeCheck(uiApp, linkPath);
                        }
                        catch
                        {
                            linkUpgradeName = "";
                            linkAllowUpgrade = false;
                        }
                        row["Original Name"] = linkName;
                        row["New Name"] = linkUpgradeName;
                        row["Directory"] = Path.GetDirectoryName(linkPath);
                        row["Original Path"] = linkPath;
                        row["New Path"] = linkPath.Replace(linkName, linkUpgradeName);
                        row["Allow Upgrade"] = linkAllowUpgrade;
                        row["Upgrade Result"] = false;

                        dt.Rows.Add(row);
                    }
                }
                dt.DefaultView.Sort = "Original Name ASC";
                GeneralOperations.BindDataSourceToDataGridView(dgv, dt);

                DataGridViewButtonColumn selectNewDirectoryButtonColumn = new DataGridViewButtonColumn();
                selectNewDirectoryButtonColumn.Text = "...";
                selectNewDirectoryButtonColumn.HeaderText = "Change Save Location";
                selectNewDirectoryButtonColumn.Width = 95;
                selectNewDirectoryButtonColumn.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(selectNewDirectoryButtonColumn);

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["Allow Upgrade"].Value.ToString() == "False")
                    {
                        row.Cells["New Path"].Value = "";
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
                        row.ReadOnly = true;
                    }
                }

                dgv.Columns["Original Name"].ReadOnly = true;
                dgv.Columns["New Name"].Width = 200;
                dgv.Columns["Directory"].ReadOnly = true;
                dgv.Columns["Directory"].Visible = false;
                dgv.Columns["Original Path"].ReadOnly = true;
                dgv.Columns["Original Path"].Visible = false;
                dgv.Columns["New Path"].ReadOnly = true;
                dgv.Columns["New Path"].Visible = true;
                dgv.Columns["New Path"].HeaderText = "Save Path";
                dgv.Columns["New Path"].Width = 200;
                dgv.Columns["Allow Upgrade"].Visible = false;
                dgv.Columns["Upgrade Result"].Visible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.ScrollBars = ScrollBars.Both;
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dgv.RowHeadersVisible = false;
                dgv.Update();
                dgv.Refresh();
            }
        }
        private void SetupUPDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (uiForm.setupUPDataGridView.CurrentCell.ColumnIndex == 8 && uiForm.setupUPDataGridView.SelectedRows[0].Cells["Allow Upgrade"].Value.ToString() == "True")
            {
                try
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    folderBrowserDialog.ShowDialog();
                    string selectedDirectory = Path.GetFullPath(folderBrowserDialog.SelectedPath);
                    uiForm.setupUPDataGridView.Rows[uiForm.setupUPDataGridView.SelectedRows[0].Index].Cells["New Path"].Value = selectedDirectory + "\\" + uiForm.setupUPDataGridView.Rows[uiForm.setupUPDataGridView.SelectedRows[0].Index].Cells["New Name"].Value.ToString() + ".rvt";
                }
                catch {; }
                uiForm.setupUPDataGridView.Update();
                uiForm.setupUPDataGridView.Refresh();
            }
        }
        private void SetupUPDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            DataGridViewCell cell = uiForm.setupUPDataGridView.CurrentCell;
            DataGridViewColumn column = cell.OwningColumn;

            if (column.Name == "New Name" && dgv.SelectedRows[0].Cells["Allow Upgrade"].Value.ToString() == "True")
            {
                if (dgv.SelectedRows[0].Cells["New Name"].Value.ToString() != "")
                {
                    dgv.SelectedRows[0].Cells["New Path"].Value = Path.GetDirectoryName(dgv.SelectedRows[0].Cells["New Path"].Value.ToString()) + "\\" + dgv.SelectedRows[0].Cells["New Name"].Value.ToString() + ".rvt";
                    dgv.Update();
                    dgv.Refresh();
                }
            }
        }
        private void SetupUPDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.setupUPDataGridView;
            DataGridViewCell cell = uiForm.setupUPDataGridView.CurrentCell;
            DataGridViewColumn column = cell.OwningColumn;

            if (column.Name == "New Name" && dgv.SelectedRows[0].Cells["Allow Upgrade"].Value.ToString() == "True")
            {
                if (dgv.SelectedRows[0].Cells["New Name"].Value.ToString() != "")
                {
                    dgv.SelectedRows[0].Cells["New Path"].Value = Path.GetDirectoryName(dgv.SelectedRows[0].Cells["New Path"].Value.ToString()) + "\\" + dgv.SelectedRows[0].Cells["New Name"].Value.ToString() + ".rvt";
                    dgv.Update();
                    dgv.Refresh();
                }                
            }
        }
        private void SetupUPRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.setupUP);
        }
        #endregion setupUP

        // ADMIN TAB
        #region adminDataGFF
        public DataTable adminDataGFFExportTable = null;
        public List<Element> adminDataGFFElementList = null;
        public List<string> adminDataGFFStringList = null;
        public List<string> adminDataGFFFiles = null;
        public List<string> adminDataGFFItemsToCollect = null;
        public DataTable adminDataGFFDataTable = null;
        private void AdminDataGFFButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            adminDataGFFExportTable = new DataTable();
            adminDataGFFElementList = new List<Element>();
            adminDataGFFStringList = new List<string>();
            adminDataGFFFiles = new List<string>();
            adminDataGFFItemsToCollect = new List<string>();
            adminDataGFFDataTable = null;
            uiForm.adminDataGFFDataProgressBar.Visible = false;
            uiForm.adminDataGFFDataProgressBar.Value = 0;
            uiForm.adminDataGFFCollectDataWaitLabel.Visible = false;
            uiForm.adminDataGFFSearchDirectoryTextBox.Text = BARevitTools.Properties.Settings.Default.RevitBAFamilyLibraryPath;
            uiForm.adminDataGFFCsvExportNameTextBox.Text = "<File Export Name>";
            uiForm.adminDataGFFDatePicker.Value = DateTime.Now;
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminDataGFFguid, adminDataGFFButton.Text, Environment.UserName.ToString(), DateTime.Now);
            SqlConnection newConnection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
            if (newConnection != null)
            {
                List<string> dtNames = DatabaseOperations.SqlGetTableNames(newConnection);
                foreach (string name in dtNames)
                {                   
                        
                    uiForm.adminDataGFFSqlExportComboBox.Items.Add(name);
                    uiForm.adminDataGFFSqlExportComboBox.Text = BARevitTools.Properties.Settings.Default.SqlBARevitFamiliesDataTable;
                }
            }
            else
            {
                uiForm.adminDataGFFSqlExportComboBox.Enabled = false;
                uiForm.adminDataGFFSqlExportRunButton.Enabled = false;
                uiForm.adminDataGFFSqlExportComboBox.Text = "SQL Database Connection Failed";
                uiForm.Update();
            }            
            SwitchActivePanel(ReferencedSwitchCaseIds.adminDataGFF);
        }
        private void AdminDataGFFCollectionFastSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            bool checkedState = uiForm.adminDataGFFCollectionFastSelectAllCheckBox.Checked;
            for (int i = 0; i < uiForm.adminDataGFFCollectionFastCheckedListBox.Items.Count; i++)
            {
                uiForm.adminDataGFFCollectionFastCheckedListBox.SetItemChecked(i, checkedState);
            }
        }
        private void AdminDataGFFCollectionSlowSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            bool checkedState = uiForm.adminDataGFFCollectionSlowSelectAllCheckBox.Checked;
            for (int i = 0; i < uiForm.adminDataGFFCollectionSlowCheckedListBox.Items.Count; i++)
            {
                uiForm.adminDataGFFCollectionSlowCheckedListBox.SetItemChecked(i, checkedState);
            }
        }
        private void AdminDataGFFCollectionSlowestSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            bool checkedState = uiForm.adminDataGFFCollectionSlowestSelectAllCheckBox.Checked;
            for (int i = 0; i < uiForm.adminDataGFFCollectionSlowestCheckedListBox.Items.Count; i++)
            {
                uiForm.adminDataGFFCollectionSlowestCheckedListBox.SetItemChecked(i, checkedState);
            }
        }
        private void AdminDataGFFSearchDirectorySelectButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.ToString() != "")
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                uiForm.adminDataGFFSearchDirectoryTextBox.Text = Path.GetFullPath(selectedDirectory);
            }
        }
        private void AdminDataGFFCsvExportDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.ToString() != "")
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                uiForm.adminDataGFFCsvExportDirectoryTextBox.Text = Path.GetFullPath(selectedDirectory);
            }
        }
        private void AdminDataGFFCollectDataButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminDataGFFCollectDataWaitLabel.Text = "Please Wait...";
            uiForm.adminDataGFFCollectDataWaitLabel.Visible = true;
            if (uiForm.adminDataGFFSearchDirectoryTextBox.Text != "<Search Directory>" && uiForm.adminDataGFFSearchDirectoryTextBox.Text != "")
            {
                try
                {
                    uiForm.adminDataGFFFiles = BARevitTools.GeneralOperations.GetAllRvtFamilies(uiForm.adminDataGFFSearchDirectoryTextBox.Text, uiForm.adminDataGFFDatePicker.Value, uiForm.adminDataGFFDateCheckBox.Checked);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show(string.Format("Exception: {0}", e));
                }

                if (uiForm.adminDataGFFFiles.Count != 0)
                {
                    CheckedListBox fastList = uiForm.adminDataGFFCollectionFastCheckedListBox;
                    CheckedListBox slowList = uiForm.adminDataGFFCollectionSlowCheckedListBox;
                    CheckedListBox slowestList = uiForm.adminDataGFFCollectionSlowestCheckedListBox;

                    if (fastList.CheckedItems.Count != 0)
                    {
                        foreach (object item in fastList.CheckedItems)
                        {
                            adminDataGFFItemsToCollect.Add(item.ToString());
                        }
                    }
                    if (slowList.CheckedItems.Count != 0)
                    {
                        foreach (object item in slowList.CheckedItems)
                        {
                            adminDataGFFItemsToCollect.Add(item.ToString());
                        }
                    }
                    if (slowestList.CheckedItems.Count != 0)
                    {
                        foreach (object item in slowestList.CheckedItems)
                        {
                            adminDataGFFItemsToCollect.Add(item.ToString());
                        }
                    }
                    if (adminDataGFFItemsToCollect.Count != 0)
                    {
                        m_ExEvent.Raise();
                        MakeRequest(RequestId.adminDataGFF);
                    }
                }
                else { uiForm.adminDataGFFCollectDataWaitLabel.Text = "No Results"; }
            }
            else { MessageBox.Show("No directory selected"); }
        }
        private void AdminDataGFFSqlExportRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            bool confirmation = VerifySelectionDialog.VerifyDataTable(uiForm.adminDataGFFSqlExportComboBox.Text);
            if (confirmation == true)
            {
                SqlConnection connection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
                if (connection!=null)
                {
                    try
                    {                    
                        if (adminDataGFFDataTable.Rows.Count != 0)
                        {
                            try { DatabaseOperations.SqlWriteDataTable(uiForm.adminDataGFFSqlExportComboBox.Text, connection, adminDataGFFDataTable, false); MessageBox.Show("Successful export to database"); }
                            catch { MessageBox.Show("Export failed"); }
                        }
                    }
                    catch { ; }
                    finally { DatabaseOperations.SqlCloseConnection(connection); }
                }
                else
                {
                    MessageBox.Show("Could not write to a database because a connection could not be made");
                }                
            }            
        }
        private void AdminDataGFFCsvExportRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string saveName = uiForm.adminDataGFFCsvExportNameTextBox.Text;
            string saveDirectory = uiForm.adminDataGFFCsvExportDirectoryTextBox.Text;
            if (saveDirectory != "<Save Directory>" && saveDirectory != null && saveName != "<File Export Name>" && saveName != null && uiForm.adminDataGFFDataTable.Rows.Count != 0)
            {
                try { CsvOperations.CreateCSVFromDataTable(uiForm.adminDataGFFDataTable, saveName, saveDirectory); MessageBox.Show("Successful export to CSV"); }
                catch { MessageBox.Show("Export failed"); }
            }
            else if (saveDirectory != "<Save Directory>" || saveDirectory != null)
            { MessageBox.Show("CSV save directory is not set"); }
            else if (saveName != "<File Export Name>" || saveName != null)
            { MessageBox.Show("CSV save name is not set"); }
            else if (uiForm.adminDataGFFDataTable.Rows.Count == 0)
            { MessageBox.Show("No data was collected"); }
            else { MessageBox.Show("Something unaccounted for created an error."); }
        }
        #endregion adminDataGFF

        #region adminDataGBDV
        public DataTable adminDataGBDVDataTable = null;
        private void AdminDataGBDV_Click(object sender, EventArgs e)
        {
            if(Application.thisApp.CadDriveIsAccessible == false)
            {
                DisableUIFeatures.DisableControls(Application.thisApp.newMainUi.adminDataGBDVLayoutPanel.Controls, Properties.Settings.Default.RevitCadDrive);
            }
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminDataGBDVWaitLabel.Visible = false;
            uiForm.adminDataGBDVExportCsvDirectoryTextBox.Text = "<Save Directory>";
            uiForm.adminDataGBDVExportCsvTextBox.Text = "<File Export Name>";
            SqlConnection connection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
            if (connection == null)
            {
                uiForm.adminDataGBDVExportDbRunButton.Enabled = false;
                uiForm.Update();
            }
            else
            {
                DatabaseOperations.SqlCloseConnection(connection);
            }
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminDataGBDVguid, adminDataGBDVButton.Text, Environment.UserName.ToString(), DateTime.Now);
            SwitchActivePanel(ReferencedSwitchCaseIds.adminDataGBDV);
        }
        private void AdminDataGBDVCollectButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.adminDataGBDV);
        }
        private void AdminDataGBDVExportDbRunButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
            if (connection != null)
            {
                try
                {
                    if (adminDataGBDVDataTable.Rows.Count != 0)
                    {
                        //Write to the database by first dropping the BA Details SQL table
                        try { DatabaseOperations.SqlWriteDataTable(BARevitTools.Properties.Settings.Default.SqlBADetailsDataTable, connection, adminDataGBDVDataTable, true); MessageBox.Show("Successful export to database"); }
                        catch (Exception f) { MessageBox.Show(f.ToString()); }
                    }
                    else
                    {
                        MessageBox.Show("Could not write to a database because a connection could not be made");
                    }
                }
                catch {; }
                finally { DatabaseOperations.SqlCloseConnection(connection); }
            }
        }
        private void AdminDataGBDVExportCsvSelectDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string saveDirectory = GeneralOperations.GetDirectory();
            uiForm.adminDataGBDVExportCsvDirectoryTextBox.Text = saveDirectory;
        }
        private void AdminDataGBDVExportCsvRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            string saveName = uiForm.adminDataGBDVExportCsvTextBox.Text;
            string saveDirectory = uiForm.adminDataGBDVExportCsvDirectoryTextBox.Text;
            if (saveDirectory != "<Save Directory>" && saveDirectory != null && saveName != "<File Export Name>" && saveName != null && uiForm.adminDataGBDVDataTable.Rows.Count != 0)
            {
                try { CsvOperations.CreateCSVFromDataTable(uiForm.adminDataGBDVDataTable, saveName, saveDirectory); MessageBox.Show("Successful export to CSV"); }
                catch { MessageBox.Show("Export failed"); }
            }
            else if (saveDirectory != "<Save Directory>" || saveDirectory != null)
            { MessageBox.Show("CSV save directory is not set"); }
            else if (saveName != "<File Export Name>" || saveName != null)
            { MessageBox.Show("CSV save name is not set"); }
            else if (uiForm.adminDataGBDVDataTable.Rows.Count == 0)
            { MessageBox.Show("No data was collected"); }
            else { MessageBox.Show("Something unaccounted for created an error."); }
        }
        #endregion adminDataGBDV
        
        #region adminFamiliesUF
        private void AdminFamiliesUFButton_Click(object sender, EventArgs e)
        {
            if (Application.thisApp.CadDriveIsAccessible == false)
            {
                DisableUIFeatures.DisableControls(Application.thisApp.newMainUi.adminFamiliesUFLayoutPanel.Controls, Properties.Settings.Default.RevitCadDrive);
            }
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesUFguid, adminFamiliesUFButton.Text, Environment.UserName.ToString(), DateTime.Now);
            this.SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesUF);
        }
        private void AdminFamiliesUFRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.adminFamiliesUF);
        }
        #endregion adminFamiliesUF

        #region adminFamiliesBAP
        public string adminFamiliesBAPFamilyDirectory = "";
        private void AdminFamiliesBAPButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminFamiliesBAPFamiliesDGV.Columns.Clear();
            uiForm.adminFamiliesBAPParametersDGV.Columns.Clear();
            uiForm.adminFamiliesBAPDoneLabel.Visible = false;
            uiForm.adminFamiliesBAPProgressBar.Visible = false;

            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView pdgv = uiForm.adminFamiliesBAPParametersDGV;
            pdgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            pdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            pdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView fdgv = uiForm.adminFamiliesBAPFamiliesDGV;
            fdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            fdgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            fdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn paramIsSharedColumn = new DataGridViewCheckBoxColumn();
            paramIsSharedColumn.Name = "Parameter Is Shared";
            paramIsSharedColumn.Width = 100;
            paramIsSharedColumn.ReadOnly = true;


            DataGridViewTextBoxColumn paramNameColumn = new DataGridViewTextBoxColumn();
            paramNameColumn.Name = "Parameter Name";
            paramNameColumn.HeaderText = "Name";
            paramNameColumn.Width = 150;

            DataGridViewComboBoxColumn paramTypeColumn = new DataGridViewComboBoxColumn();
            paramTypeColumn.Name = "Parameter Type";
            paramTypeColumn.HeaderText = "Type";
            paramTypeColumn.Width = 125;
            paramTypeColumn.Items.AddRange("Text", "Integer", "Number", "Length", "Area", "Volume", "Angle", "Slope",
                "Currencey", "Mass Density", "URL", "Material", "Image", "Yes/No", "Multiline Text", "<Family Type...>");

            DataGridViewComboBoxColumn paramGroupColumn = new DataGridViewComboBoxColumn();
            paramGroupColumn.Name = "Parameter Group";
            paramGroupColumn.HeaderText = "Group";
            paramGroupColumn.Width = 150;
            paramGroupColumn.Items.AddRange("Analysis Results", "Analytical Alignment", "Analytical Model",
                "Constraints", "Construction", "Data", "Dimensions", "Division Geometry", "Electrical",
                "Electrical - Circuiting", "Electrical - Lighting", "Electrical - Loads", "Electrical Engineering",
                "Energy Analysis", "Fire Protection", "Forces", "General", "Graphics", "Green Building Properties",
                "Identity Data", "IFC Parameters", "Materials and Finishes", "Mechanical", "Mechanical - Flow",
                "Mechanical - Loads", "Model Properties", "Moments", "Other", "Overall Legend", "Phasing", "Photometrics",
                "Plumbing", "Primary End", "Rebar Set", "Releases / Member Forces", "Secondary End", "Segments and Fittings",
                "Slab Shape Edit", "Structural", "Structural Analysis", "Text", "Title Text", "Visibility");

            DataGridViewCheckBoxColumn paramIsInstanceColumn = new DataGridViewCheckBoxColumn();
            paramIsInstanceColumn.Name = "Parameter Is Instance";
            paramIsInstanceColumn.HeaderText = "Instance?";
            paramIsInstanceColumn.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.GreenYellow;

            DataGridViewTextBoxColumn paramValueColumn = new DataGridViewTextBoxColumn();
            paramValueColumn.Name = "Parameter Value";
            paramValueColumn.HeaderText = "Value";
            paramValueColumn.Width = 150;

            DataGridViewCheckBoxColumn famSelectColumn = new DataGridViewCheckBoxColumn();
            famSelectColumn.Name = "Family Select";
            famSelectColumn.HeaderText = "Select";
            famSelectColumn.Width = 45;

            DataGridViewTextBoxColumn famNameColumn = new DataGridViewTextBoxColumn();
            famNameColumn.Name = "Family Name";
            famNameColumn.HeaderText = "Name";
            famNameColumn.Width = 250;

            DataGridViewTextBoxColumn famPathColumn = new DataGridViewTextBoxColumn();
            famPathColumn.Name = "Family Path";
            famPathColumn.Visible = false;

            pdgv.Columns.AddRange(paramIsSharedColumn, paramNameColumn, paramTypeColumn, paramGroupColumn, paramIsInstanceColumn, paramValueColumn);
            pdgv.ColumnCount = pdgv.Columns.Count;
            fdgv.Columns.AddRange(famSelectColumn, famNameColumn, famPathColumn);
            fdgv.ColumnCount = fdgv.Columns.Count;            
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesBAPguid, adminFamiliesBAPButton.Text, Environment.UserName.ToString(), DateTime.Now);
            SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesBAP);

        }
        private void AdminFamiliesBAPParametersDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (e.Button == MouseButtons.Right)
            {
                uiForm.dataFamiliesBAPParametersContextMenu.Show(uiForm.adminFamiliesBAPParametersDGV, e.Location);
                uiForm.dataFamiliesBAPParametersContextMenu.Show(Cursor.Position);
            }
        }
        private void AdminFamiliesBAPSelectDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesBAPFamiliesDGV;
            dgv.Rows.Clear();
            adminFamiliesBAPFamilyDirectory = GeneralOperations.GetDirectory();
            if (adminFamiliesBAPFamilyDirectory != "")
            {
                List<string> files = GeneralOperations.GetAllRvtFamilies(adminFamiliesBAPFamilyDirectory, new DateTime(1, 1, 1, 0, 0, 0), false);
                if (files.Count != 0)
                {
                    foreach (string filePath in files)
                    {
                        dgv.Rows.Add(false, Path.GetFileNameWithoutExtension(filePath), filePath);
                        dgv.Sort(dgv.Columns["Family Name"], ListSortDirection.Ascending);
                    }
                }                
                dgv.Update();
            }
        }
        private void AdminFamiliesBAPFamiliesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesBAPFamiliesDGV;
            if (dgv.Rows.Count > 0)
            {
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void AdminFamiliesBAPSharedParametersButton_Click(object sender, EventArgs e)
        {
            bool accessibleSPFile = false;
            try
            {
                uiApp.Application.OpenSharedParameterFile();
                accessibleSPFile = true;
            }
            catch
            {
                accessibleSPFile = false;
            }

            if (accessibleSPFile == true)
            {
                try
                {
                    BARevitTools.Application.thisApp.newSPUi = new SharedParametersUI(uiApp);
                    BARevitTools.Application.thisApp.newSPUi.Show();
                    BARevitTools.Application.thisApp.newSPUi.UpdateFields();
                }
                catch { MessageBox.Show("Error updating shard parameters or launching UI"); }

            }
            else { MessageBox.Show("Please first set the shared parameter file for this document"); }

        }
        private void AdminFamiliesBAPParametersRowDeleteTool_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBAPParametersDGV.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    BARevitTools.Application.thisApp.newMainUi.adminFamiliesBAPParametersDGV.Rows.RemoveAt(row.Index);
                }
            }
        }
        private void AdminFamiliesBAPParametersDGV_MouseUp(object sender, MouseEventArgs e)
        {
            MainUI uiForm = Application.thisApp.newMainUi;
            if (e.Button == MouseButtons.Right)
            {
                uiForm.dataFamiliesBAPParametersContextMenu.Show(uiForm.adminFamiliesBAPFamiliesDGV, e.Location);
                uiForm.dataFamiliesBAPParametersContextMenu.Show(Cursor.Position);
            }
        }
        private void AdminFamiliesBAPSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBAPFamiliesDGV.Rows)
            {
                row.Cells[0].Value = true;
            }
        }
        private void AdminFamiliesBAPSelectNoneButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBAPFamiliesDGV.Rows)
            {
                row.Cells[0].Value = false;
            }
        }
        private void AdminFamiliesBAPRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.adminFamiliesBAP);
        }
        #endregion adminFamiliesBAP

        #region adminFamiliesBRP
        public string adminFamiliesBRPFamilyDirectory = "";
        private void AdminFamiliesBRPButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminFamiliesBRPFamiliesDGV.Columns.Clear();
            uiForm.adminFamiliesBRPParametersDGV.Columns.Clear();

            RVTDocument doc = uiApp.ActiveUIDocument.Document;
            DataGridView pdgv = uiForm.adminFamiliesBRPParametersDGV;
            pdgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            pdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            pdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView fdgv = uiForm.adminFamiliesBRPFamiliesDGV;
            fdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            fdgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            fdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumn paramNameColumn = new DataGridViewTextBoxColumn();
            paramNameColumn.Name = "Parameter Name";
            paramNameColumn.Width = 200;

            DataGridViewCheckBoxColumn famSelectColumn = new DataGridViewCheckBoxColumn();
            famSelectColumn.Name = "Family Select";
            famSelectColumn.HeaderText = "Select";
            famSelectColumn.Width = 45;

            DataGridViewTextBoxColumn famNameColumn = new DataGridViewTextBoxColumn();
            famNameColumn.Name = "Family Name";
            famNameColumn.HeaderText = "Name";
            famNameColumn.Width = 250;

            DataGridViewTextBoxColumn famPathColumn = new DataGridViewTextBoxColumn();
            famPathColumn.Name = "Family Path";
            famPathColumn.Visible = false;

            pdgv.Columns.AddRange(paramNameColumn);
            pdgv.ColumnCount = pdgv.Columns.Count;
            fdgv.Columns.AddRange(famSelectColumn, famNameColumn, famPathColumn);
            fdgv.ColumnCount = fdgv.Columns.Count;

            SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesBRP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesBRPguid, adminFamiliesBRPButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void AdminFamiliesBRPParametersDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (e.Button == MouseButtons.Right)
            {
                uiForm.dataFamiliesBRPParametersContextMenu.Show(uiForm.adminFamiliesBRPParametersDGV, e.Location);
                uiForm.dataFamiliesBRPParametersContextMenu.Show(Cursor.Position);
            }
        }
        private void AdminFamiliesBRPParametersRowDeleteTool_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBRPParametersDGV.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    BARevitTools.Application.thisApp.newMainUi.adminFamiliesBRPParametersDGV.Rows.RemoveAt(row.Index);
                }
            }
        }
        private void AdminFamiliesBRPDirectorySelectButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesBRPFamiliesDGV;
            dgv.Rows.Clear();
            adminFamiliesBRPFamilyDirectory = GeneralOperations.GetDirectory();
            if (adminFamiliesBRPFamilyDirectory != "")
            {
                List<string> files = GeneralOperations.GetAllRvtFamilies(adminFamiliesBRPFamilyDirectory, new DateTime(1, 1, 1, 0, 0, 0), false);
                if (files.Count != 0)
                {
                    foreach (string filePath in files)
                    {
                        dgv.Rows.Add(false, Path.GetFileNameWithoutExtension(filePath), filePath);
                        dgv.Sort(dgv.Columns["Family Name"], ListSortDirection.Ascending);
                    }
                }
                dgv.Update();
                dgv.Refresh();
            }
        }
        private void AdminFamiliesBRPSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBRPFamiliesDGV.Rows)
            {
                row.Cells[0].Value = true;
            }
        }
        private void AdminFamiliesBRPSelectNoneButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesBRPFamiliesDGV.Rows)
            {
                row.Cells[0].Value = false;
            }
        }
        private void AdminFamiliesBRPFamiliesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesBRPFamiliesDGV;
            if (dgv.Rows.Count > 0)
            {
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void AdminFamiliesBRPRunButton_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
            MakeRequest(RequestId.adminFamiliesBRP);
        }
        #endregion adminFamiliesBRP

        #region adminFamiliesDFB
        private void AdminFamiliesDFBButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesDFBFamiliesDGV;
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.Name = "Select";
            selectColumn.Width = 45;
            DataGridViewTextBoxColumn familyNameColumn = new DataGridViewTextBoxColumn();
            familyNameColumn.Name = "Family Name";
            familyNameColumn.Width = dgv.Width - selectColumn.Width;
            familyNameColumn.ReadOnly = true;
            DataGridViewTextBoxColumn familyPathColumn = new DataGridViewTextBoxColumn();
            familyPathColumn.Name = "Family Path";
            familyPathColumn.ReadOnly = true;
            familyPathColumn.Visible = false;

            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns.AddRange(selectColumn, familyNameColumn, familyPathColumn);
            dgv.ColumnCount = dgv.Columns.Count;

            SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesDFB);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesDFBguid, adminFamiliesDFBButton.Text, Environment.UserName.ToString(), DateTime.Now);
        }
        private void AdminFamiliesDFBSelectDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesDFBFamiliesDGV;
            dgv.Rows.Clear();
            string adminFamiliesDFBFamilyDirectory = GeneralOperations.GetDirectory();
            if (adminFamiliesDFBFamilyDirectory != null)
            {
                List<string> files = GeneralOperations.GetAllRvtBackupFamilies(adminFamiliesDFBFamilyDirectory,true);

                if (files.Count != 0)
                {
                    foreach (string filePath in files)
                    {
                        dgv.Rows.Add(false, Path.GetFileNameWithoutExtension(filePath), filePath);
                    }
                }
                dgv.Sort(dgv.Columns["Family Name"], ListSortDirection.Ascending);
                dgv.Update();
                dgv.Refresh();
            }
        }
        private void AdminFamiliesDBFSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesDFBFamiliesDGV.Rows)
            {
                row.Cells[0].Value = true;
            }
        }
        private void AdminFamiliesDBFSelectNoneButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BARevitTools.Application.thisApp.newMainUi.adminFamiliesDFBFamiliesDGV.Rows)
            {
                row.Cells[0].Value = false;
            }
        }
        private void AdminFamiliesDFBFamiliesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            DataGridView dgv = uiForm.adminFamiliesDFBFamiliesDGV;
            if (dgv.Rows.Count > 0)
            {
                var rowValue = dgv.CurrentCell.Value.ToString();
                int columnIndex = dgv.CurrentCell.ColumnIndex;
                if (columnIndex == 0)
                {
                    if (rowValue == "")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else if (rowValue.ToString() == "True")
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = false;
                            row.Cells[columnIndex].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int rowIndex = row.Index;
                            row.Cells[columnIndex].Value = true;
                            row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                }
            }
            dgv.Update();
            dgv.Refresh();
        }
        private void AdminFamiliesDFBRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            List<string> filesToDelete = new List<string>();
            DataGridView dgv = uiForm.adminFamiliesDFBFamiliesDGV;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    filesToDelete.Add(row.Cells[2].Value.ToString());
                }
            }
            GeneralOperations.DeleteFiles(filesToDelete);
            uiForm.adminFamiliesDFBFamiliesDGV.Rows.Clear();
        }
        #endregion adminFamiliesDFB

        #region adminFamiliesUFVP
        private void AdminFamiliesUFVPButton_Click(object sender, EventArgs e)
        {
            if (Application.thisApp.CadDriveIsAccessible == false)
            {
                DisableUIFeatures.DisableControls(Application.thisApp.newMainUi.adminFamiliesUFVPLayoutPanel.Controls, Properties.Settings.Default.RevitCadDrive);
            }
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            uiForm.adminFamiliesUFVPProgressBar.Visible = false;
            uiForm.adminFamiliesUFVPProgressBar.Value = 0;
            uiForm.adminFamiliesUFVPDatePicker.Value = DateTime.Today;
            uiForm.adminFamiliesUFVPDirectoryTextBox.Text = Properties.Settings.Default.RevitBAFamilyLibraryPath;

            SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesUFVP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesUFVPguid, bulkUpdatePublishVersionToolStripMenuItem.Text, Environment.UserName.ToString(), DateTime.Now);

        }
        private void AdminFamiliesUFVPRunButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = BARevitTools.Application.thisApp.newMainUi;
            if (uiForm.adminFamiliesUFVPDirectoryTextBox.Text!= "No Directory Set")
            {
                m_ExEvent.Raise();
                MakeRequest(RequestId.adminFamiliesUFVP);
            }
            else
            {
                MessageBox.Show("No directory to search was set");
            }
        }
        private void AdminFamiliesUFVPDirectoryButton_Click(object sender, EventArgs e)
        {
            MainUI uiForm = Application.thisApp.newMainUi;
            string directory = GeneralOperations.GetDirectory();
            if (directory != "")
            {
                uiForm.adminFamiliesUFVPDirectoryTextBox.Text = directory;
            }
            else
            {
                uiForm.adminFamiliesUFVPDirectoryTextBox.Text = "No Directory Set";
            }
        }
        #endregion adminFamiliesUFVP

        #region adminFamiliesSRCP
        private void AdminFamiliesSRCP_Click(object sender, EventArgs e)
        {
            adminFamiliesSRCPDirectoryTextBox.Text = "";
            adminFamiliesSRCPListBox.Items.Clear();
            SwitchActivePanel(ReferencedSwitchCaseIds.adminFamiliesSRCP);
            DatabaseOperations.CollectUserInputData(ReferencedGuids.adminFamiliesSRCPguid, adminFamiliesSRCPButton.Text, Environment.UserName.ToString(), DateTime.Now);
            SqlConnection newConnection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
        }

        private void AdminFamiliesSRCPSelectDirectoryButton_Click(object sender, EventArgs e)
        {
            adminFamiliesSRCPDirectoryTextBox.Text = GeneralOperations.GetDirectory();
        }

        private void AdminFamiliesSRCPRunButton_Click(object sender, EventArgs e)
        {
            if (adminFamiliesSRCPDirectoryTextBox.Text == "")
            {
                MessageBox.Show("Please select a directory");
            }
            else
            {
                m_ExEvent.Raise();
                MakeRequest(RequestId.adminFamiliesSRCP);
            }
        }
        #endregion adminFamiliesSRCP

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Need something for the options when they are done.
        }        
    }
}
