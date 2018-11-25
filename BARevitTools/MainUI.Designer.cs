using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BARevitTools
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage adminTab;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            System.Windows.Forms.ToolStrip roomsToolStrip;
            this.adminManagementTabControl = new System.Windows.Forms.TabControl();
            this.adminAboutTab = new System.Windows.Forms.TabPage();
            this.adminAboutReservedLabel = new System.Windows.Forms.Label();
            this.adminAboutTitleLabel = new System.Windows.Forms.Label();
            this.adminDataTab = new System.Windows.Forms.TabPage();
            this.adminDataTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminDataToolStrip = new System.Windows.Forms.ToolStrip();
            this.adminDataGFFButton = new System.Windows.Forms.ToolStripButton();
            this.adminDataSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.adminDataGPFButton = new System.Windows.Forms.ToolStripButton();
            this.adminDataSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.adminDataGBDVButton = new System.Windows.Forms.ToolStripButton();
            this.adminDataToolsPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminDataGFFCollectDataPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectDataWaitLabel = new System.Windows.Forms.Label();
            this.adminDataGFFDataProgressBar = new System.Windows.Forms.ProgressBar();
            this.adminDataGFFCollectDataButton = new System.Windows.Forms.Button();
            this.adminDataGFFSqlExportPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFSqlExportRunButton = new System.Windows.Forms.Button();
            this.adminDataGFFSqlExportLabel = new System.Windows.Forms.Label();
            this.adminDataGFFCsvExportPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCsvExportDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.adminDataGFFCsvExportRunButton = new System.Windows.Forms.Button();
            this.adminDataGFFCsvExportNameTextBox = new System.Windows.Forms.TextBox();
            this.adminDataGFFCsvExportLabel = new System.Windows.Forms.Label();
            this.adminDataGFFCsvExportDirectoryButton = new System.Windows.Forms.Button();
            this.adminDataGFFCollectionPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminDataGFFCollectionFastLabelPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionFastLabel = new System.Windows.Forms.Label();
            this.adminDataGFFCollectionFastSelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.adminDataGFFCollectionSlowLabelPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionSlowLabel = new System.Windows.Forms.Label();
            this.adminDataGFFCollectionSlowSelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.adminDataGFFCollectionSlowestLabelPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionSlowestLabel = new System.Windows.Forms.Label();
            this.adminDataGFFCollectionSlowestSelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.adminDataGFFCollectionsFastCheckedListPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionFastCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.adminDataGFFCollectionsSlowCheckedListPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionSlowCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.adminDataGFFCollectionsSlowestCheckedListPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFCollectionSlowestCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.adminDataGFFSearchDirectoryPanel = new System.Windows.Forms.Panel();
            this.adminDataGFFSearchDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.adminDataGFFSearchDirectorySelectButton = new System.Windows.Forms.Button();
            this.adminDataGFFDatePanel = new System.Windows.Forms.Panel();
            this.adminDataGFFDatePicker = new System.Windows.Forms.DateTimePicker();
            this.adminDataGFFDateCheckBox = new System.Windows.Forms.CheckBox();
            this.adminDataGBDVLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminDataGBDVCollectPanel = new System.Windows.Forms.Panel();
            this.adminDataGBDVWaitLabel = new System.Windows.Forms.Label();
            this.adminDataGBDVCollectButton = new System.Windows.Forms.Button();
            this.adminDataGBDVExportDbPanel = new System.Windows.Forms.Panel();
            this.adminDataGBDVExportDbRunButton = new System.Windows.Forms.Button();
            this.adminDataGBDVExportDbLabel = new System.Windows.Forms.Label();
            this.adminDataGBDVExportCsvPanel = new System.Windows.Forms.Panel();
            this.adminDataGBDVExportCsvDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.adminDataGBDVExportCsvSelectDirectoryButton = new System.Windows.Forms.Button();
            this.adminDataGBDVExportCsvRunButton = new System.Windows.Forms.Button();
            this.adminDataGBDVExportCsvTextBox = new System.Windows.Forms.TextBox();
            this.adminDataGBDVExportCsvLabel = new System.Windows.Forms.Label();
            this.adminFamiliesTab = new System.Windows.Forms.TabPage();
            this.adminFamiliesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesToolStrip = new System.Windows.Forms.ToolStrip();
            this.adminFamiliesUFButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.adminFamiliesDFBButton = new System.Windows.Forms.ToolStripButton();
            this.adminFamiliesSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.adminFamiliesParametersDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.adminFamiliesBAPButton = new System.Windows.Forms.ToolStripMenuItem();
            this.adminFamiliesBRPButton = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkUpdatePublishVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.adminFamiliesToolsPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBAPLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBAPRunPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBAPDoneLabel = new System.Windows.Forms.Label();
            this.adminFamiliesBAPProgressBar = new System.Windows.Forms.ProgressBar();
            this.adminFamiliesBAPRunButton = new System.Windows.Forms.Button();
            this.adminFamiliesBAPSplitPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBAPSplitContainer = new System.Windows.Forms.SplitContainer();
            this.adminFamiliesBAPParametersLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBAPParametersDGV = new System.Windows.Forms.DataGridView();
            this.adminFamiliesBAPSharedParametersPanel = new System.Windows.Forms.Panel();
            this.BIMFamiliesBAPSharedParametersButton = new System.Windows.Forms.Button();
            this.adminFamiliesBAPSelectLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBAPSelectPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBAPSelectNoneButton = new System.Windows.Forms.Button();
            this.adminFamiliesBAPSelectAllButton = new System.Windows.Forms.Button();
            this.adminFamiliesBAPFamiliesDGV = new System.Windows.Forms.DataGridView();
            this.adminFamiliesBAPFamiliesDirectoryPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBAPDirectorySelectButton = new System.Windows.Forms.Button();
            this.adminFamiliesUFLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesUFFullSyncPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesUFFullSyncCheckbox = new System.Windows.Forms.CheckBox();
            this.adminFamiliesUFUpgradedFamiliesListBox = new System.Windows.Forms.ListBox();
            this.adminFamiliesUFDeletedFamiliesListBox = new System.Windows.Forms.ListBox();
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesUFUpgradedFamiliesTextBox = new System.Windows.Forms.TextBox();
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesUFDeletedFamiliesTextBox = new System.Windows.Forms.TextBox();
            this.adminFamiliesUFRunPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesUFRunButton = new System.Windows.Forms.Button();
            this.adminFamiliesBRPLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBRPRunPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBRPProgressBar = new System.Windows.Forms.ProgressBar();
            this.adminFamiliesBRPRunButton = new System.Windows.Forms.Button();
            this.adminFamiliesBRPSplitPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBRPSplitContainer = new System.Windows.Forms.SplitContainer();
            this.adminFamiliesBRPParametersLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBRPParametersDGV = new System.Windows.Forms.DataGridView();
            this.adminFamiliesBRPParametersPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBPRSFamiliesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesBRPFamiliesDGV = new System.Windows.Forms.DataGridView();
            this.adminFamiliesBRPSelectPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBRPSelectNoneButton = new System.Windows.Forms.Button();
            this.adminFamiliesBRPSelectAllButton = new System.Windows.Forms.Button();
            this.adminFamiliesBRPCsvDirectoryPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesBRPDirectorySelectButton = new System.Windows.Forms.Button();
            this.adminFamiliesDFBLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminFamiliesDFBSelectPanel = new System.Windows.Forms.Panel();
            this.adminFamiliesDBFSelectNoneButton = new System.Windows.Forms.Button();
            this.adminFamiliesDBFSelectAllButton = new System.Windows.Forms.Button();
            this.adminFamiliesDFBSelectDirectoryButton = new System.Windows.Forms.Button();
            this.adminFamiliesDFBFamiliesDGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminFamiliesDFBRunButton = new System.Windows.Forms.Button();
            this.adminTemplateTab = new System.Windows.Forms.TabPage();
            this.adminTemplateLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminTemplateToolStrip = new System.Windows.Forms.ToolStrip();
            this.adminTemplatePMButton = new System.Windows.Forms.ToolStripButton();
            this.adminTemplateToolsPanel = new System.Windows.Forms.Panel();
            this.adminTemplatePMLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminTemplatePMPickPackagePanel = new System.Windows.Forms.Panel();
            this.adminTemplatePMDeletePackateButton = new System.Windows.Forms.Button();
            this.adminTemplatePMPickPackageLabel = new System.Windows.Forms.Label();
            this.adminTemplatePMPickPackageComboBox = new System.Windows.Forms.ComboBox();
            this.adminTemplateSavePackagePanel = new System.Windows.Forms.Panel();
            this.adminTemplateSavePackagePublishButton = new System.Windows.Forms.Button();
            this.adminTemplateSavePackageComboBox = new System.Windows.Forms.ComboBox();
            this.adminTemplateSavePackageLabel = new System.Windows.Forms.Label();
            this.adminTemplatePMTreeView = new System.Windows.Forms.TreeView();
            this.sandBoxTab = new System.Windows.Forms.TabPage();
            this.sandBoxLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sandBoxElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.sandBoxToolStrip = new System.Windows.Forms.ToolStrip();
            this.sandBoxTestButton1 = new System.Windows.Forms.ToolStripButton();
            this.roomsSRNNButton = new System.Windows.Forms.ToolStripButton();
            this.roomsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.roomsCDRTButton = new System.Windows.Forms.ToolStripButton();
            this.mgmtSetupCWSUserContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setupCWSRowDeleteTool = new System.Windows.Forms.ToolStripMenuItem();
            this.UIFormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.aboutTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.aboutTabHeaderPanel = new System.Windows.Forms.Panel();
            this.aboutTabDevelopmentLinkURLLabel = new System.Windows.Forms.LinkLabel();
            this.aboutTabDevelopmentLinkLabel = new System.Windows.Forms.Label();
            this.aboutTabLearningLinkURLLabel = new System.Windows.Forms.LinkLabel();
            this.aboutTabLearningLinkLabel = new System.Windows.Forms.Label();
            this.aboutTabLogo = new System.Windows.Forms.PictureBox();
            this.aboutPublishLabel = new System.Windows.Forms.Label();
            this.aboutTabVersionLabel = new System.Windows.Forms.Label();
            this.aboutTabTitleLabel = new System.Windows.Forms.Label();
            this.aboutTabFooterPanel = new System.Windows.Forms.Panel();
            this.aboutCreditLabel = new System.Windows.Forms.Label();
            this.aboutTabUpdatesTextBox = new System.Windows.Forms.RichTextBox();
            this.analysisTab = new System.Windows.Forms.TabPage();
            this.analysisTabControl = new System.Windows.Forms.TabControl();
            this.sightTab = new System.Windows.Forms.TabPage();
            this.modelingTab = new System.Windows.Forms.TabPage();
            this.modelingTabControl = new System.Windows.Forms.TabControl();
            this.multiCatTab = new System.Windows.Forms.TabPage();
            this.multiCatLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.multiCatToolStrip = new System.Windows.Forms.ToolStrip();
            this.multiCatCFFEButton = new System.Windows.Forms.ToolStripButton();
            this.multiCatSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.multiCatRE = new System.Windows.Forms.ToolStripButton();
            this.multiCatToolsPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFSplitContainer = new System.Windows.Forms.SplitContainer();
            this.multiCatCFFEExcelSplitContainer = new System.Windows.Forms.SplitContainer();
            this.multiCatCFFECreateExcelLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.multiCatCFFECreateExcelLabel = new System.Windows.Forms.Label();
            this.multiCatCFFECreateExcelInstructions = new System.Windows.Forms.TextBox();
            this.multiCatCFFECreateExcelLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.multiCatCFFEExcelDGV = new System.Windows.Forms.DataGridView();
            this.multiCatCFFEExcelRunPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFEExcelStatusLabel = new System.Windows.Forms.Label();
            this.multiCatCFFEExcelRunButton = new System.Windows.Forms.Button();
            this.multiCatCFFEDirectoryPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFEDirectorySelectButton = new System.Windows.Forms.Button();
            this.multiCatCFFEDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.multiCatCFFESelectFamilyPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFESelectFamilyButton = new System.Windows.Forms.Button();
            this.multiCatCFFESelectFamilyTextBox = new System.Windows.Forms.TextBox();
            this.multiCatCFFEFamiliesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.multiCatCFFECreateFamiliesLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.multiCatCFFECreateFamiliesLabel = new System.Windows.Forms.Label();
            this.multiCatCFFECreateFamiliesInstructions = new System.Windows.Forms.TextBox();
            this.multiCatCFFECreateFamiliesLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.multiCatCFFEFamiliesDGV = new System.Windows.Forms.DataGridView();
            this.multiCatCFFEFamiliesExcelPanel = new System.Windows.Forms.Panel();
            this.allCATCFFEFamiliesSaveDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.multiCatCFFEFamiliesSaveDirectoryButton = new System.Windows.Forms.Button();
            this.multiCatCFFEExcelSelectButton = new System.Windows.Forms.Button();
            this.multiCatCFFEFamiliesRunPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFEFamiliesProgressBar = new System.Windows.Forms.ProgressBar();
            this.multiCatCFFEFamiliesRunButton = new System.Windows.Forms.Button();
            this.multiCatCFFEFamilyCreationPanel = new System.Windows.Forms.Panel();
            this.multiCatCFFEFamilyCreationLabel = new System.Windows.Forms.Label();
            this.multiCatCFFEFamilyCreationComboBox = new System.Windows.Forms.ComboBox();
            this.doorsTab = new System.Windows.Forms.TabPage();
            this.electricalTab = new System.Windows.Forms.TabPage();
            this.electricalLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.electricalToolStrip = new System.Windows.Forms.ToolStrip();
            this.electricalCEOEButton = new System.Windows.Forms.ToolStripButton();
            this.electricalToolsPanel = new System.Windows.Forms.Panel();
            this.electricalCEOELayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.electricalCEOETextBox = new System.Windows.Forms.TextBox();
            this.electricalCEOEControlsPanel = new System.Windows.Forms.Panel();
            this.electricalCEOERunButton = new System.Windows.Forms.Button();
            this.floorsTab = new System.Windows.Forms.TabPage();
            this.floorsTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.floorsToolsPanel = new System.Windows.Forms.Panel();
            this.floorsCFBRLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.floorsCFBRInstructionsPanel = new System.Windows.Forms.Panel();
            this.floorsCFBRInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.floorsCFBRControlsPanel = new System.Windows.Forms.Panel();
            this.floorsCFBROffsetFinishFloorCheckBox = new System.Windows.Forms.CheckBox();
            this.floorsCFBRSelectFloorTypeLabel = new System.Windows.Forms.Label();
            this.floorsCFBRSelectRoomsLabel = new System.Windows.Forms.Label();
            this.floorsCFBRSelectFloorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.floorsCFBRRunButton = new System.Windows.Forms.Button();
            this.floorsCFBRSelectRoomsButton = new System.Windows.Forms.Button();
            this.floorsToolStrip = new System.Windows.Forms.ToolStrip();
            this.floorsCFBRButton = new System.Windows.Forms.ToolStripButton();
            this.massesTab = new System.Windows.Forms.TabPage();
            this.materialsTab = new System.Windows.Forms.TabPage();
            this.materialsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialsToolStrip = new System.Windows.Forms.ToolStrip();
            this.materialsCMSButton = new System.Windows.Forms.ToolStripButton();
            this.materialsToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.materialsAMLButton = new System.Windows.Forms.ToolStripButton();
            this.materialsToolsPanel = new System.Windows.Forms.Panel();
            this.materialsAMLLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialsAMLHeaderPanel = new System.Windows.Forms.Panel();
            this.materialsAMLHeaderLabel = new System.Windows.Forms.Label();
            this.materialsAMLInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.materialsAMLDataGridView = new System.Windows.Forms.DataGridView();
            this.materialsAMLLaunchPanel = new System.Windows.Forms.Panel();
            this.materialsAMLLaunchPaletteButton = new System.Windows.Forms.Button();
            this.materialsCMSExcelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialsCMSExcelExportPanel = new System.Windows.Forms.Panel();
            this.materialsCMSExcelCreateSpreadsheetButton = new System.Windows.Forms.Button();
            this.materialsCMSExcelSpreadsheetNameTextBox = new System.Windows.Forms.TextBox();
            this.materialsCMSExcelSelectSaveDirectoryButton = new System.Windows.Forms.Button();
            this.materialsCMSExcelExportLabel = new System.Windows.Forms.Label();
            this.materialsCMSExcelRunPanel = new System.Windows.Forms.Panel();
            this.materialsCMSExcelCreateSymbolsProgressBar = new System.Windows.Forms.ProgressBar();
            this.materialsCMSExcelCreateSymbolsButton = new System.Windows.Forms.Button();
            this.materialsCMSExcelImportPanel = new System.Windows.Forms.Panel();
            this.materialsCMSSetViewNameTextBox = new System.Windows.Forms.TextBox();
            this.materialsCMSSetViewNameLabel = new System.Windows.Forms.Label();
            this.materialsCMSExcelImportLabel = new System.Windows.Forms.Label();
            this.materialsCMSExcelSelectImportFileButton = new System.Windows.Forms.Button();
            this.materialsCMSExcelDataGridView = new System.Windows.Forms.DataGridView();
            this.materialsCMSExcelInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.roomsTab = new System.Windows.Forms.TabPage();
            this.roomsTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.roomsToolsPanel = new System.Windows.Forms.Panel();
            this.roomsCDRTLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.roomsCDRTInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.roomsCDRTControlsPanel = new System.Windows.Forms.Panel();
            this.roomsCDRTRunButton = new System.Windows.Forms.Button();
            this.roomsSRNNLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.roomsSRNNInstructions = new System.Windows.Forms.Label();
            this.roomsSRNNPanel = new System.Windows.Forms.Panel();
            this.roomsSRNNRunButton = new System.Windows.Forms.Button();
            this.roomsSRRNUrlPanel = new System.Windows.Forms.Panel();
            this.roomsSRRNUrlLabel = new System.Windows.Forms.Label();
            this.roomsSRRNUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.wallsTab = new System.Windows.Forms.TabPage();
            this.wallsTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.wallsToolStrip = new System.Windows.Forms.ToolStrip();
            this.wallsMPWButton = new System.Windows.Forms.ToolStripButton();
            this.wallsToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.wallsDPButton = new System.Windows.Forms.ToolStripButton();
            this.wallsToolsPanel = new System.Windows.Forms.Panel();
            this.wallsDPLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.wallsDPInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wallsDPRunButton = new System.Windows.Forms.Button();
            this.wallsMPWLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.wallsMPWControlsPanel = new System.Windows.Forms.Panel();
            this.wallsMPWLabelSelectWall = new System.Windows.Forms.Label();
            this.wallsMPWNumericUpDownWallHeightIn = new System.Windows.Forms.NumericUpDown();
            this.wallsMPWLabelSetWall = new System.Windows.Forms.Label();
            this.wallsMPWNumericUpDownWallHeightFt = new System.Windows.Forms.NumericUpDown();
            this.wallsMPWLabelWallHtFtTxt = new System.Windows.Forms.Label();
            this.wallsMPWButtonRun = new System.Windows.Forms.Button();
            this.wallsMPWLabelWallHtInTxt = new System.Windows.Forms.Label();
            this.wallsMPWComboBoxWall = new System.Windows.Forms.ComboBox();
            this.wallsMPWInstructionsPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.documentationTab = new System.Windows.Forms.TabPage();
            this.documentationTabControl = new System.Windows.Forms.TabControl();
            this.sheetsTab = new System.Windows.Forms.TabPage();
            this.sheetsTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sheetsToolStrip = new System.Windows.Forms.ToolStrip();
            this.sheetsCSLButton = new System.Windows.Forms.ToolStripButton();
            this.sheetsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sheetsISFLButton = new System.Windows.Forms.ToolStripButton();
            this.sheetsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sheetsSheetSetsButton = new System.Windows.Forms.ToolStripSplitButton();
            this.sheetsCSSFSButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetsOSSButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetsToolsPanel = new System.Windows.Forms.Panel();
            this.sheetsCSLLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sheetsCLSRunButton = new System.Windows.Forms.Button();
            this.sheetsCSLDataGridView = new System.Windows.Forms.DataGridView();
            this.sheetsCSLControlsPanel = new System.Windows.Forms.Panel();
            this.sheetsCSLFilterConditionComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsCSLFilterTextBox = new System.Windows.Forms.TextBox();
            this.sheetsCSLCopyFromLabel = new System.Windows.Forms.Label();
            this.sheetsCSLCopyToLabel = new System.Windows.Forms.Label();
            this.sheetsCSLComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsCSLInstructionsPanel = new System.Windows.Forms.Panel();
            this.sheetsCSLInstructionsLabel = new System.Windows.Forms.Label();
            this.sheetsOSSLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sheetsOSSDataGridView = new System.Windows.Forms.DataGridView();
            this.sheetsOSSInstructionsPanel = new System.Windows.Forms.Panel();
            this.sheetsOSSInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.sheetsOSSFilterPanel = new System.Windows.Forms.Panel();
            this.sheetsOSSFilterFieldComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsOSSFilterTextBox = new System.Windows.Forms.TextBox();
            this.sheetsOSSFilterConditionComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsOSSFilterLabel = new System.Windows.Forms.Label();
            this.sheetsOSSNewSetPanel = new System.Windows.Forms.Panel();
            this.sheetsOSSNewSetButton = new System.Windows.Forms.Button();
            this.sheetsOSSNewSetLabel = new System.Windows.Forms.Label();
            this.sheetsOSSNewSetTextBox = new System.Windows.Forms.TextBox();
            this.sheetsOSSControlsPanel = new System.Windows.Forms.Panel();
            this.sheetsOSSRunButton = new System.Windows.Forms.Button();
            this.sheetsOSSRunLabel = new System.Windows.Forms.Label();
            this.sheetsISFLLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sheetsISFLInstructionsPanel = new System.Windows.Forms.Panel();
            this.sheetsISFLInstructionsLabel = new System.Windows.Forms.Label();
            this.sheetsISFLRunButton = new System.Windows.Forms.Button();
            this.sheetsISFLDataGridView = new System.Windows.Forms.DataGridView();
            this.sheetsISFLControlsPanel = new System.Windows.Forms.Panel();
            this.sheetsISFLComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsISFLLabel1 = new System.Windows.Forms.Label();
            this.sheetsISFLLabel2 = new System.Windows.Forms.Label();
            this.sheetsIFSLDisciplinePanel = new System.Windows.Forms.Panel();
            this.sheetsISFLDisciplineUpdateButton = new System.Windows.Forms.Button();
            this.sheetsISFLDisciplineComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsISFLDisciplineLabel = new System.Windows.Forms.Label();
            this.sheetsCSSFSLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sheetsCSSFSInstructionsPanel = new System.Windows.Forms.Panel();
            this.sheetsCSSFSInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.sheetsCSSFSControlsPanel = new System.Windows.Forms.Panel();
            this.sheetsCSSFSSScheduleLabel = new System.Windows.Forms.Label();
            this.sheetsCSSFSSetNameLabel = new System.Windows.Forms.Label();
            this.sheetsCSSFSSetNameTextBox = new System.Windows.Forms.TextBox();
            this.sheetsCSSFSScheduleComboBox = new System.Windows.Forms.ComboBox();
            this.sheetsCSSFSRunButton = new System.Windows.Forms.Button();
            this.viewsTab = new System.Windows.Forms.TabPage();
            this.viewsTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.viewsToolStrip = new System.Windows.Forms.ToolStrip();
            this.viewsCEPRButton = new System.Windows.Forms.ToolStripButton();
            this.viewsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewsInteriorCropButton = new System.Windows.Forms.ToolStripSplitButton();
            this.viewsOICBButton = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsHNIECButton = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolsPanel = new System.Windows.Forms.Panel();
            this.viewsCEPRLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.viewsCEPRControlsPanel = new System.Windows.Forms.Panel();
            this.viewsCEPRRunButton = new System.Windows.Forms.Button();
            this.viewsCEPROverrideCheckBox = new System.Windows.Forms.CheckBox();
            this.viewsCEPRCropCheckBox = new System.Windows.Forms.CheckBox();
            this.viewsCEPRElevationComboBox = new System.Windows.Forms.ComboBox();
            this.viewsCEPRInstructionsPanel = new System.Windows.Forms.Panel();
            this.viewsCEPRInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.viewsCEPRUrlPanel = new System.Windows.Forms.Panel();
            this.viewsCEPRUrlLabel = new System.Windows.Forms.Label();
            this.viewsCEPRUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.viewsHNIECLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.viewsHNIECInstructionsPanel = new System.Windows.Forms.Panel();
            this.viewsHNIECBInstructions = new System.Windows.Forms.Label();
            this.viewsHNIECControlsPanel = new System.Windows.Forms.Panel();
            this.viewsHNIECBRunButton = new System.Windows.Forms.Button();
            this.viewsOICBLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.viewsOICBInstructionsPanel = new System.Windows.Forms.Panel();
            this.viewsOICBInstructionsLabel = new System.Windows.Forms.Label();
            this.viewsOICBControlsPanel = new System.Windows.Forms.Panel();
            this.elemViewsOCIBRunButton = new System.Windows.Forms.Button();
            this.managementTab = new System.Windows.Forms.TabPage();
            this.managmentTabControl = new System.Windows.Forms.TabControl();
            this.dataTab = new System.Windows.Forms.TabPage();
            this.dataTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataToolStrip = new System.Windows.Forms.ToolStrip();
            this.dataEPIButton = new System.Windows.Forms.ToolStripButton();
            this.dataSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataToolsPanel = new System.Windows.Forms.Panel();
            this.dataEPILayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataEPIInstructionsPanel = new System.Windows.Forms.Panel();
            this.dataEPIInstructionsLabel = new System.Windows.Forms.Label();
            this.dataEPIControlsPanel = new System.Windows.Forms.Panel();
            this.dataEPIDPIComboBox = new System.Windows.Forms.ComboBox();
            this.dataEPIDirectorySelectedLabel = new System.Windows.Forms.Label();
            this.dataEPISaveTextBox = new System.Windows.Forms.TextBox();
            this.dataEPIRunButton = new System.Windows.Forms.Button();
            this.dataEPIDirectoryButton = new System.Windows.Forms.Button();
            this.dataEPIDPILabel = new System.Windows.Forms.Label();
            this.dataEPIDirectoryLabel = new System.Windows.Forms.Label();
            this.dataEPINameLabel = new System.Windows.Forms.Label();
            this.documentsTab = new System.Windows.Forms.TabPage();
            this.documentsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.documentsToolStrip = new System.Windows.Forms.ToolStrip();
            this.documentsCTSButton = new System.Windows.Forms.ToolStripButton();
            this.documentsToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.documentsPRP = new System.Windows.Forms.ToolStripButton();
            this.documentsToolsPanel = new System.Windows.Forms.Panel();
            this.documentsCTSPanel = new System.Windows.Forms.Panel();
            this.documentsCTSRun = new System.Windows.Forms.Button();
            this.documentsCTSInstructions = new System.Windows.Forms.Label();
            this.graphicsTab = new System.Windows.Forms.TabPage();
            this.miscTab = new System.Windows.Forms.TabPage();
            this.miscToolsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.miscToolStrip = new System.Windows.Forms.ToolStrip();
            this.miscEDVButton = new System.Windows.Forms.ToolStripButton();
            this.miscSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miscEEVButton = new System.Windows.Forms.ToolStripButton();
            this.miscToolsPanel = new System.Windows.Forms.Panel();
            this.miscEDVLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.miscEDVInstructionsPanel = new System.Windows.Forms.Panel();
            this.miscEDVInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.miscEDVRunPanel = new System.Windows.Forms.Panel();
            this.miscEDVProgressBar = new System.Windows.Forms.ProgressBar();
            this.miscEDVRunButton = new System.Windows.Forms.Button();
            this.miscEDVDirectoryPanel = new System.Windows.Forms.Panel();
            this.miscEDVSelectDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.miscEDVSelectDirectoryButton = new System.Windows.Forms.Button();
            this.miscEDVDataGridView = new System.Windows.Forms.DataGridView();
            this.miscEDVControlsPanel = new System.Windows.Forms.Panel();
            this.miscEDVFilterLabel = new System.Windows.Forms.Label();
            this.miscEDVFilterStringTextBox = new System.Windows.Forms.TextBox();
            this.miscEDVFilterConditionComboBox = new System.Windows.Forms.ComboBox();
            this.miscEDVSelectNoneButton = new System.Windows.Forms.Button();
            this.miscEDVSelectAllButton = new System.Windows.Forms.Button();
            this.qaqcTab = new System.Windows.Forms.TabPage();
            this.qaqcLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.qaqcToolStrip = new System.Windows.Forms.ToolStrip();
            this.qaqcCapitalizeValuesButton = new System.Windows.Forms.ToolStripSplitButton();
            this.capitalizeSheetViewNamesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.capitalizeScheduleValuesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.qaqcToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.qaqcDRNPButtton = new System.Windows.Forms.ToolStripButton();
            this.qaqcToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.qaqcRLSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.qaqcRFSPButton = new System.Windows.Forms.ToolStripButton();
            this.qaqcToolsPanel = new System.Windows.Forms.Panel();
            this.qaqcRFSPLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.qaqcRFSPInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.qaqcRFSPParametersListBox = new System.Windows.Forms.ListBox();
            this.qaqcRFSPToolsPanel = new System.Windows.Forms.Panel();
            this.qaqcRFSPSFamilyLabel = new System.Windows.Forms.Label();
            this.qaqcRFSPRunButton = new System.Windows.Forms.Button();
            this.qaqcRFSPSelectFamilyButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.qaqcRLSLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.qaqcRLSRunPanel = new System.Windows.Forms.Panel();
            this.qaqcRLSRunButton = new System.Windows.Forms.Button();
            this.qaqcRLSInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.qaqcRLSDataGridView = new System.Windows.Forms.DataGridView();
            this.qaqcRLSControlsPanel = new System.Windows.Forms.Panel();
            this.qaqcRLSReplaceWithLabel = new System.Windows.Forms.Label();
            this.qaqcRLSReplaceLabel = new System.Windows.Forms.Label();
            this.qaqcRLSReplaceWithComboBox = new System.Windows.Forms.ComboBox();
            this.qaqcRLSDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.qaqcRLSReplaceComboBox = new System.Windows.Forms.ComboBox();
            this.qaqcRLSUnswitchablePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.qaqcCSVNPanel = new System.Windows.Forms.Panel();
            this.qaqcCSVNRun = new System.Windows.Forms.Button();
            this.qaqcCTVNInstructions = new System.Windows.Forms.Label();
            this.qaqcCSVLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.qaqcCSVControlsPanel = new System.Windows.Forms.Panel();
            this.qaqcCSVRunButton = new System.Windows.Forms.Button();
            this.qaqcCSVInstructionsPanel = new System.Windows.Forms.Panel();
            this.qaqcCSVInstructionsLabel = new System.Windows.Forms.Label();
            this.qaqcDRNPPanel = new System.Windows.Forms.Panel();
            this.qaqcDRNPInstructions = new System.Windows.Forms.Label();
            this.qaqcDRNPRun = new System.Windows.Forms.Button();
            this.setupTab = new System.Windows.Forms.TabPage();
            this.setupLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setupToolStrip = new System.Windows.Forms.ToolStrip();
            this.setupCWSButton = new System.Windows.Forms.ToolStripButton();
            this.setupSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setupUPButton = new System.Windows.Forms.ToolStripButton();
            this.setupToolsPanel = new System.Windows.Forms.Panel();
            this.setupUPLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setupUPInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.setupUPDataGridView = new System.Windows.Forms.DataGridView();
            this.setupUPLinkedModelsLabel = new System.Windows.Forms.Label();
            this.setupUPControlsPanel1 = new System.Windows.Forms.Panel();
            this.setupUPOriginalPathSelectButton = new System.Windows.Forms.Button();
            this.setupUPOriginalFilePathTextBox = new System.Windows.Forms.TextBox();
            this.setupUPOriginalFilePathLabel = new System.Windows.Forms.Label();
            this.setupUPRunPanel = new System.Windows.Forms.Panel();
            this.setupUPRunButton = new System.Windows.Forms.Button();
            this.setupUPControlsPanel2 = new System.Windows.Forms.Panel();
            this.setupUPUpgradePathSelectButton = new System.Windows.Forms.Button();
            this.setupUPOriginalDirectoryButton = new System.Windows.Forms.Button();
            this.setupUPUpgradedFilePathLabel = new System.Windows.Forms.Label();
            this.setupUPSlashLabel = new System.Windows.Forms.Label();
            this.setupUPUpgradedFilePathUserTextBox = new System.Windows.Forms.TextBox();
            this.setupUPUpgradedFilePathSetTextBox = new System.Windows.Forms.TextBox();
            this.setupUPControlsPanel3 = new System.Windows.Forms.Panel();
            this.setupUPUpgradingToLabel = new System.Windows.Forms.Label();
            this.setupUPUpgradingToRevitLabel = new System.Windows.Forms.Label();
            this.setupUPUpgradingFromRevitLabel = new System.Windows.Forms.Label();
            this.setupUPUpgradingFromLabel = new System.Windows.Forms.Label();
            this.setupCWSLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setupCWSDefinedLabel = new System.Windows.Forms.Label();
            this.setupCWSExtendedListBox = new System.Windows.Forms.CheckedListBox();
            this.setupCWSExtendedLabel = new System.Windows.Forms.Label();
            this.setupCWSInstructionsPanel = new System.Windows.Forms.Panel();
            this.setupCWSInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.setupCWSDefaultLabel = new System.Windows.Forms.Label();
            this.setupCWSDefaultListBox = new System.Windows.Forms.ListBox();
            this.setupCWSUserDataGridView = new System.Windows.Forms.DataGridView();
            this.WorksetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setupCWSRunPanel = new System.Windows.Forms.Panel();
            this.setupCWSRunButton = new System.Windows.Forms.Button();
            this.UIFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFamiliesBAPParametersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.familiesBAPParametersRowDeleteTool = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFamiliesBRPParametersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataFamiliesBRPParametersRowDeleteTool = new System.Windows.Forms.ToolStripMenuItem();
            adminTab = new System.Windows.Forms.TabPage();
            roomsToolStrip = new System.Windows.Forms.ToolStrip();
            adminTab.SuspendLayout();
            this.adminManagementTabControl.SuspendLayout();
            this.adminAboutTab.SuspendLayout();
            this.adminDataTab.SuspendLayout();
            this.adminDataTabLayoutPanel.SuspendLayout();
            this.adminDataToolStrip.SuspendLayout();
            this.adminDataToolsPanel.SuspendLayout();
            this.adminDataGFFLayoutPanel.SuspendLayout();
            this.adminDataGFFCollectDataPanel.SuspendLayout();
            this.adminDataGFFSqlExportPanel.SuspendLayout();
            this.adminDataGFFCsvExportPanel.SuspendLayout();
            this.adminDataGFFCollectionPanel.SuspendLayout();
            this.adminDataGFFCollectionLayoutPanel.SuspendLayout();
            this.adminDataGFFCollectionFastLabelPanel.SuspendLayout();
            this.adminDataGFFCollectionSlowLabelPanel.SuspendLayout();
            this.adminDataGFFCollectionSlowestLabelPanel.SuspendLayout();
            this.adminDataGFFCollectionsFastCheckedListPanel.SuspendLayout();
            this.adminDataGFFCollectionsSlowCheckedListPanel.SuspendLayout();
            this.adminDataGFFCollectionsSlowestCheckedListPanel.SuspendLayout();
            this.adminDataGFFSearchDirectoryPanel.SuspendLayout();
            this.adminDataGFFDatePanel.SuspendLayout();
            this.adminDataGBDVLayoutPanel.SuspendLayout();
            this.adminDataGBDVCollectPanel.SuspendLayout();
            this.adminDataGBDVExportDbPanel.SuspendLayout();
            this.adminDataGBDVExportCsvPanel.SuspendLayout();
            this.adminFamiliesTab.SuspendLayout();
            this.adminFamiliesLayoutPanel.SuspendLayout();
            this.adminFamiliesToolStrip.SuspendLayout();
            this.adminFamiliesToolsPanel.SuspendLayout();
            this.adminFamiliesBAPLayoutPanel.SuspendLayout();
            this.adminFamiliesBAPRunPanel.SuspendLayout();
            this.adminFamiliesBAPSplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPSplitContainer)).BeginInit();
            this.adminFamiliesBAPSplitContainer.Panel1.SuspendLayout();
            this.adminFamiliesBAPSplitContainer.Panel2.SuspendLayout();
            this.adminFamiliesBAPSplitContainer.SuspendLayout();
            this.adminFamiliesBAPParametersLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPParametersDGV)).BeginInit();
            this.adminFamiliesBAPSharedParametersPanel.SuspendLayout();
            this.adminFamiliesBAPSelectLayoutPanel.SuspendLayout();
            this.adminFamiliesBAPSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPFamiliesDGV)).BeginInit();
            this.adminFamiliesBAPFamiliesDirectoryPanel.SuspendLayout();
            this.adminFamiliesUFLayoutPanel.SuspendLayout();
            this.adminFamiliesUFFullSyncPanel.SuspendLayout();
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.SuspendLayout();
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.SuspendLayout();
            this.adminFamiliesUFRunPanel.SuspendLayout();
            this.adminFamiliesBRPLayoutPanel.SuspendLayout();
            this.adminFamiliesBRPRunPanel.SuspendLayout();
            this.adminFamiliesBRPSplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPSplitContainer)).BeginInit();
            this.adminFamiliesBRPSplitContainer.Panel1.SuspendLayout();
            this.adminFamiliesBRPSplitContainer.Panel2.SuspendLayout();
            this.adminFamiliesBRPSplitContainer.SuspendLayout();
            this.adminFamiliesBRPParametersLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPParametersDGV)).BeginInit();
            this.adminFamiliesBPRSFamiliesLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPFamiliesDGV)).BeginInit();
            this.adminFamiliesBRPSelectPanel.SuspendLayout();
            this.adminFamiliesBRPCsvDirectoryPanel.SuspendLayout();
            this.adminFamiliesDFBLayoutPanel.SuspendLayout();
            this.adminFamiliesDFBSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesDFBFamiliesDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.adminTemplateTab.SuspendLayout();
            this.adminTemplateLayoutPanel.SuspendLayout();
            this.adminTemplateToolStrip.SuspendLayout();
            this.adminTemplateToolsPanel.SuspendLayout();
            this.adminTemplatePMLayoutPanel.SuspendLayout();
            this.adminTemplatePMPickPackagePanel.SuspendLayout();
            this.adminTemplateSavePackagePanel.SuspendLayout();
            this.sandBoxTab.SuspendLayout();
            this.sandBoxLayoutPanel.SuspendLayout();
            this.sandBoxToolStrip.SuspendLayout();
            roomsToolStrip.SuspendLayout();
            this.mgmtSetupCWSUserContextMenu.SuspendLayout();
            this.UIFormTableLayoutPanel.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.aboutTabLayoutPanel.SuspendLayout();
            this.aboutTabHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutTabLogo)).BeginInit();
            this.aboutTabFooterPanel.SuspendLayout();
            this.analysisTab.SuspendLayout();
            this.analysisTabControl.SuspendLayout();
            this.modelingTab.SuspendLayout();
            this.modelingTabControl.SuspendLayout();
            this.multiCatTab.SuspendLayout();
            this.multiCatLayoutPanel.SuspendLayout();
            this.multiCatToolStrip.SuspendLayout();
            this.multiCatToolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFSplitContainer)).BeginInit();
            this.multiCatCFFSplitContainer.Panel1.SuspendLayout();
            this.multiCatCFFSplitContainer.Panel2.SuspendLayout();
            this.multiCatCFFSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEExcelSplitContainer)).BeginInit();
            this.multiCatCFFEExcelSplitContainer.Panel1.SuspendLayout();
            this.multiCatCFFEExcelSplitContainer.Panel2.SuspendLayout();
            this.multiCatCFFEExcelSplitContainer.SuspendLayout();
            this.multiCatCFFECreateExcelLayoutPanel1.SuspendLayout();
            this.multiCatCFFECreateExcelLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEExcelDGV)).BeginInit();
            this.multiCatCFFEExcelRunPanel.SuspendLayout();
            this.multiCatCFFEDirectoryPanel.SuspendLayout();
            this.multiCatCFFESelectFamilyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEFamiliesSplitContainer)).BeginInit();
            this.multiCatCFFEFamiliesSplitContainer.Panel1.SuspendLayout();
            this.multiCatCFFEFamiliesSplitContainer.Panel2.SuspendLayout();
            this.multiCatCFFEFamiliesSplitContainer.SuspendLayout();
            this.multiCatCFFECreateFamiliesLayoutPanel1.SuspendLayout();
            this.multiCatCFFECreateFamiliesLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEFamiliesDGV)).BeginInit();
            this.multiCatCFFEFamiliesExcelPanel.SuspendLayout();
            this.multiCatCFFEFamiliesRunPanel.SuspendLayout();
            this.multiCatCFFEFamilyCreationPanel.SuspendLayout();
            this.electricalTab.SuspendLayout();
            this.electricalLayoutPanel.SuspendLayout();
            this.electricalToolStrip.SuspendLayout();
            this.electricalToolsPanel.SuspendLayout();
            this.electricalCEOELayoutPanel.SuspendLayout();
            this.electricalCEOEControlsPanel.SuspendLayout();
            this.floorsTab.SuspendLayout();
            this.floorsTabLayoutPanel.SuspendLayout();
            this.floorsToolsPanel.SuspendLayout();
            this.floorsCFBRLayoutPanel.SuspendLayout();
            this.floorsCFBRInstructionsPanel.SuspendLayout();
            this.floorsCFBRControlsPanel.SuspendLayout();
            this.floorsToolStrip.SuspendLayout();
            this.materialsTab.SuspendLayout();
            this.materialsLayoutPanel.SuspendLayout();
            this.materialsToolStrip.SuspendLayout();
            this.materialsToolsPanel.SuspendLayout();
            this.materialsAMLLayoutPanel.SuspendLayout();
            this.materialsAMLHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsAMLDataGridView)).BeginInit();
            this.materialsAMLLaunchPanel.SuspendLayout();
            this.materialsCMSExcelLayoutPanel.SuspendLayout();
            this.materialsCMSExcelExportPanel.SuspendLayout();
            this.materialsCMSExcelRunPanel.SuspendLayout();
            this.materialsCMSExcelImportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsCMSExcelDataGridView)).BeginInit();
            this.roomsTab.SuspendLayout();
            this.roomsTabLayoutPanel.SuspendLayout();
            this.roomsToolsPanel.SuspendLayout();
            this.roomsCDRTLayoutPanel.SuspendLayout();
            this.roomsCDRTControlsPanel.SuspendLayout();
            this.roomsSRNNLayoutPanel.SuspendLayout();
            this.roomsSRNNPanel.SuspendLayout();
            this.roomsSRRNUrlPanel.SuspendLayout();
            this.wallsTab.SuspendLayout();
            this.wallsTabLayoutPanel.SuspendLayout();
            this.wallsToolStrip.SuspendLayout();
            this.wallsToolsPanel.SuspendLayout();
            this.wallsDPLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.wallsMPWLayoutPanel.SuspendLayout();
            this.wallsMPWControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wallsMPWNumericUpDownWallHeightIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallsMPWNumericUpDownWallHeightFt)).BeginInit();
            this.wallsMPWInstructionsPanel.SuspendLayout();
            this.documentationTab.SuspendLayout();
            this.documentationTabControl.SuspendLayout();
            this.sheetsTab.SuspendLayout();
            this.sheetsTabLayoutPanel.SuspendLayout();
            this.sheetsToolStrip.SuspendLayout();
            this.sheetsToolsPanel.SuspendLayout();
            this.sheetsCSLLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsCSLDataGridView)).BeginInit();
            this.sheetsCSLControlsPanel.SuspendLayout();
            this.sheetsCSLInstructionsPanel.SuspendLayout();
            this.sheetsOSSLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsOSSDataGridView)).BeginInit();
            this.sheetsOSSInstructionsPanel.SuspendLayout();
            this.sheetsOSSFilterPanel.SuspendLayout();
            this.sheetsOSSNewSetPanel.SuspendLayout();
            this.sheetsOSSControlsPanel.SuspendLayout();
            this.sheetsISFLLayoutPanel.SuspendLayout();
            this.sheetsISFLInstructionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsISFLDataGridView)).BeginInit();
            this.sheetsISFLControlsPanel.SuspendLayout();
            this.sheetsIFSLDisciplinePanel.SuspendLayout();
            this.sheetsCSSFSLayoutPanel.SuspendLayout();
            this.sheetsCSSFSInstructionsPanel.SuspendLayout();
            this.sheetsCSSFSControlsPanel.SuspendLayout();
            this.viewsTab.SuspendLayout();
            this.viewsTabLayoutPanel.SuspendLayout();
            this.viewsToolStrip.SuspendLayout();
            this.viewsToolsPanel.SuspendLayout();
            this.viewsCEPRLayoutPanel.SuspendLayout();
            this.viewsCEPRControlsPanel.SuspendLayout();
            this.viewsCEPRInstructionsPanel.SuspendLayout();
            this.viewsCEPRUrlPanel.SuspendLayout();
            this.viewsHNIECLayoutPanel.SuspendLayout();
            this.viewsHNIECInstructionsPanel.SuspendLayout();
            this.viewsHNIECControlsPanel.SuspendLayout();
            this.viewsOICBLayoutPanel.SuspendLayout();
            this.viewsOICBInstructionsPanel.SuspendLayout();
            this.viewsOICBControlsPanel.SuspendLayout();
            this.managementTab.SuspendLayout();
            this.managmentTabControl.SuspendLayout();
            this.dataTab.SuspendLayout();
            this.dataTabLayoutPanel.SuspendLayout();
            this.dataToolStrip.SuspendLayout();
            this.dataToolsPanel.SuspendLayout();
            this.dataEPILayoutPanel.SuspendLayout();
            this.dataEPIInstructionsPanel.SuspendLayout();
            this.dataEPIControlsPanel.SuspendLayout();
            this.documentsTab.SuspendLayout();
            this.documentsLayoutPanel.SuspendLayout();
            this.documentsToolStrip.SuspendLayout();
            this.documentsToolsPanel.SuspendLayout();
            this.documentsCTSPanel.SuspendLayout();
            this.miscTab.SuspendLayout();
            this.miscToolsLayoutPanel.SuspendLayout();
            this.miscToolStrip.SuspendLayout();
            this.miscToolsPanel.SuspendLayout();
            this.miscEDVLayoutPanel.SuspendLayout();
            this.miscEDVInstructionsPanel.SuspendLayout();
            this.miscEDVRunPanel.SuspendLayout();
            this.miscEDVDirectoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miscEDVDataGridView)).BeginInit();
            this.miscEDVControlsPanel.SuspendLayout();
            this.qaqcTab.SuspendLayout();
            this.qaqcLayoutPanel.SuspendLayout();
            this.qaqcToolStrip.SuspendLayout();
            this.qaqcToolsPanel.SuspendLayout();
            this.qaqcRFSPLayoutPanel.SuspendLayout();
            this.qaqcRFSPToolsPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.qaqcRLSLayoutPanel.SuspendLayout();
            this.qaqcRLSRunPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qaqcRLSDataGridView)).BeginInit();
            this.qaqcRLSControlsPanel.SuspendLayout();
            this.qaqcRLSUnswitchablePanel.SuspendLayout();
            this.qaqcCSVNPanel.SuspendLayout();
            this.qaqcCSVLayoutPanel.SuspendLayout();
            this.qaqcCSVControlsPanel.SuspendLayout();
            this.qaqcCSVInstructionsPanel.SuspendLayout();
            this.qaqcDRNPPanel.SuspendLayout();
            this.setupTab.SuspendLayout();
            this.setupLayoutPanel.SuspendLayout();
            this.setupToolStrip.SuspendLayout();
            this.setupToolsPanel.SuspendLayout();
            this.setupUPLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setupUPDataGridView)).BeginInit();
            this.setupUPControlsPanel1.SuspendLayout();
            this.setupUPRunPanel.SuspendLayout();
            this.setupUPControlsPanel2.SuspendLayout();
            this.setupUPControlsPanel3.SuspendLayout();
            this.setupCWSLayoutPanel.SuspendLayout();
            this.setupCWSInstructionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setupCWSUserDataGridView)).BeginInit();
            this.setupCWSRunPanel.SuspendLayout();
            this.UIFormMenuStrip.SuspendLayout();
            this.dataFamiliesBAPParametersContextMenu.SuspendLayout();
            this.dataFamiliesBRPParametersContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminTab
            // 
            adminTab.Controls.Add(this.adminManagementTabControl);
            adminTab.Location = new System.Drawing.Point(25, 4);
            adminTab.Margin = new System.Windows.Forms.Padding(0);
            adminTab.Name = "adminTab";
            adminTab.Padding = new System.Windows.Forms.Padding(3);
            adminTab.Size = new System.Drawing.Size(734, 437);
            adminTab.TabIndex = 3;
            adminTab.Text = "Admin";
            adminTab.UseVisualStyleBackColor = true;
            // 
            // adminManagementTabControl
            // 
            this.adminManagementTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.adminManagementTabControl.Controls.Add(this.adminAboutTab);
            this.adminManagementTabControl.Controls.Add(this.adminDataTab);
            this.adminManagementTabControl.Controls.Add(this.adminFamiliesTab);
            this.adminManagementTabControl.Controls.Add(this.adminTemplateTab);
            this.adminManagementTabControl.Controls.Add(this.sandBoxTab);
            this.adminManagementTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminManagementTabControl.Location = new System.Drawing.Point(3, 3);
            this.adminManagementTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.adminManagementTabControl.Name = "adminManagementTabControl";
            this.adminManagementTabControl.SelectedIndex = 0;
            this.adminManagementTabControl.Size = new System.Drawing.Size(728, 431);
            this.adminManagementTabControl.TabIndex = 0;
            this.adminManagementTabControl.Click += new System.EventHandler(this.AllowBIMManagementTab);
            // 
            // adminAboutTab
            // 
            this.adminAboutTab.BackColor = System.Drawing.SystemColors.Control;
            this.adminAboutTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminAboutTab.Controls.Add(this.adminAboutReservedLabel);
            this.adminAboutTab.Controls.Add(this.adminAboutTitleLabel);
            this.adminAboutTab.Location = new System.Drawing.Point(4, 25);
            this.adminAboutTab.Margin = new System.Windows.Forms.Padding(0);
            this.adminAboutTab.Name = "adminAboutTab";
            this.adminAboutTab.Size = new System.Drawing.Size(720, 402);
            this.adminAboutTab.TabIndex = 3;
            this.adminAboutTab.Text = "About";
            this.adminAboutTab.Click += new System.EventHandler(this.AllowBIMManagementTab);
            // 
            // adminAboutReservedLabel
            // 
            this.adminAboutReservedLabel.AutoSize = true;
            this.adminAboutReservedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAboutReservedLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.adminAboutReservedLabel.Location = new System.Drawing.Point(8, 35);
            this.adminAboutReservedLabel.Name = "adminAboutReservedLabel";
            this.adminAboutReservedLabel.Size = new System.Drawing.Size(344, 18);
            this.adminAboutReservedLabel.TabIndex = 1;
            this.adminAboutReservedLabel.Text = "Section Reserved for BIM Management Operations";
            // 
            // adminAboutTitleLabel
            // 
            this.adminAboutTitleLabel.AutoSize = true;
            this.adminAboutTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.adminAboutTitleLabel.Location = new System.Drawing.Point(5, 4);
            this.adminAboutTitleLabel.Name = "adminAboutTitleLabel";
            this.adminAboutTitleLabel.Size = new System.Drawing.Size(300, 31);
            this.adminAboutTitleLabel.TabIndex = 0;
            this.adminAboutTitleLabel.Text = "BIM Management Tools";
            // 
            // adminDataTab
            // 
            this.adminDataTab.BackColor = System.Drawing.SystemColors.Control;
            this.adminDataTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminDataTab.Controls.Add(this.adminDataTabLayoutPanel);
            this.adminDataTab.Location = new System.Drawing.Point(4, 25);
            this.adminDataTab.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataTab.Name = "adminDataTab";
            this.adminDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminDataTab.Size = new System.Drawing.Size(720, 402);
            this.adminDataTab.TabIndex = 0;
            this.adminDataTab.Text = "Data";
            // 
            // adminDataTabLayoutPanel
            // 
            this.adminDataTabLayoutPanel.ColumnCount = 1;
            this.adminDataTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataTabLayoutPanel.Controls.Add(this.adminDataToolStrip, 0, 0);
            this.adminDataTabLayoutPanel.Controls.Add(this.adminDataToolsPanel, 0, 1);
            this.adminDataTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.adminDataTabLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataTabLayoutPanel.Name = "adminDataTabLayoutPanel";
            this.adminDataTabLayoutPanel.RowCount = 2;
            this.adminDataTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.adminDataTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.adminDataTabLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.adminDataTabLayoutPanel.TabIndex = 0;
            // 
            // adminDataToolStrip
            // 
            this.adminDataToolStrip.AutoSize = false;
            this.adminDataToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.adminDataToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.adminDataToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminDataGFFButton,
            this.adminDataSeparator1,
            this.adminDataGPFButton,
            this.adminDataSeparator2,
            this.adminDataGBDVButton});
            this.adminDataToolStrip.Location = new System.Drawing.Point(0, 0);
            this.adminDataToolStrip.Name = "adminDataToolStrip";
            this.adminDataToolStrip.Size = new System.Drawing.Size(710, 53);
            this.adminDataToolStrip.TabIndex = 0;
            this.adminDataToolStrip.Text = "BIMMgmtDataToolStrip";
            // 
            // adminDataGFFButton
            // 
            this.adminDataGFFButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDataGFFButton.Image")));
            this.adminDataGFFButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminDataGFFButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminDataGFFButton.Name = "adminDataGFFButton";
            this.adminDataGFFButton.Size = new System.Drawing.Size(93, 50);
            this.adminDataGFFButton.Text = "Get Family Files";
            this.adminDataGFFButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminDataGFFButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminDataGFFButton.ToolTipText = "Get Family Files: Collects data about family files in a directory";
            this.adminDataGFFButton.Click += new System.EventHandler(this.AdminDataGFFButton_Click);
            // 
            // adminDataSeparator1
            // 
            this.adminDataSeparator1.Name = "adminDataSeparator1";
            this.adminDataSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // adminDataGPFButton
            // 
            this.adminDataGPFButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDataGPFButton.Image")));
            this.adminDataGPFButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminDataGPFButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminDataGPFButton.Name = "adminDataGPFButton";
            this.adminDataGPFButton.Size = new System.Drawing.Size(95, 50);
            this.adminDataGPFButton.Text = "Get Project Files";
            this.adminDataGPFButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminDataGPFButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminDataGPFButton.ToolTipText = "Get Project Files: Collect data about project files from a directory";
            // 
            // adminDataSeparator2
            // 
            this.adminDataSeparator2.Name = "adminDataSeparator2";
            this.adminDataSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // adminDataGBDVButton
            // 
            this.adminDataGBDVButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDataGBDVButton.Image")));
            this.adminDataGBDVButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminDataGBDVButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminDataGBDVButton.Name = "adminDataGBDVButton";
            this.adminDataGBDVButton.Size = new System.Drawing.Size(85, 50);
            this.adminDataGBDVButton.Text = "Get BA Details";
            this.adminDataGBDVButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminDataGBDVButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminDataGBDVButton.ToolTipText = "Get BA Details: Gets the views from the BA Details and publishes the list.";
            this.adminDataGBDVButton.Click += new System.EventHandler(this.AdminDataGBDV_Click);
            // 
            // adminDataToolsPanel
            // 
            this.adminDataToolsPanel.Controls.Add(this.adminDataGFFLayoutPanel);
            this.adminDataToolsPanel.Controls.Add(this.adminDataGBDVLayoutPanel);
            this.adminDataToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.adminDataToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataToolsPanel.Name = "adminDataToolsPanel";
            this.adminDataToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.adminDataToolsPanel.TabIndex = 2;
            // 
            // adminDataGFFLayoutPanel
            // 
            this.adminDataGFFLayoutPanel.ColumnCount = 2;
            this.adminDataGFFLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminDataGFFLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFCollectDataPanel, 0, 2);
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFSqlExportPanel, 0, 3);
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFCsvExportPanel, 1, 3);
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFCollectionPanel, 0, 0);
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFSearchDirectoryPanel, 0, 1);
            this.adminDataGFFLayoutPanel.Controls.Add(this.adminDataGFFDatePanel, 1, 1);
            this.adminDataGFFLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFLayoutPanel.Name = "adminDataGFFLayoutPanel";
            this.adminDataGFFLayoutPanel.RowCount = 4;
            this.adminDataGFFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataGFFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminDataGFFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminDataGFFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.adminDataGFFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.adminDataGFFLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminDataGFFLayoutPanel.TabIndex = 4;
            this.adminDataGFFLayoutPanel.Visible = false;
            // 
            // adminDataGFFCollectDataPanel
            // 
            this.adminDataGFFCollectDataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFLayoutPanel.SetColumnSpan(this.adminDataGFFCollectDataPanel, 2);
            this.adminDataGFFCollectDataPanel.Controls.Add(this.adminDataGFFCollectDataWaitLabel);
            this.adminDataGFFCollectDataPanel.Controls.Add(this.adminDataGFFDataProgressBar);
            this.adminDataGFFCollectDataPanel.Controls.Add(this.adminDataGFFCollectDataButton);
            this.adminDataGFFCollectDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectDataPanel.Location = new System.Drawing.Point(0, 154);
            this.adminDataGFFCollectDataPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectDataPanel.Name = "adminDataGFFCollectDataPanel";
            this.adminDataGFFCollectDataPanel.Size = new System.Drawing.Size(710, 35);
            this.adminDataGFFCollectDataPanel.TabIndex = 4;
            // 
            // adminDataGFFCollectDataWaitLabel
            // 
            this.adminDataGFFCollectDataWaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCollectDataWaitLabel.BackColor = System.Drawing.Color.Transparent;
            this.adminDataGFFCollectDataWaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFCollectDataWaitLabel.Location = new System.Drawing.Point(140, 7);
            this.adminDataGFFCollectDataWaitLabel.Name = "adminDataGFFCollectDataWaitLabel";
            this.adminDataGFFCollectDataWaitLabel.Size = new System.Drawing.Size(88, 19);
            this.adminDataGFFCollectDataWaitLabel.TabIndex = 5;
            this.adminDataGFFCollectDataWaitLabel.Text = "Please Wait...";
            this.adminDataGFFCollectDataWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminDataGFFCollectDataWaitLabel.Visible = false;
            // 
            // adminDataGFFDataProgressBar
            // 
            this.adminDataGFFDataProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFDataProgressBar.BackColor = System.Drawing.Color.White;
            this.adminDataGFFDataProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.adminDataGFFDataProgressBar.Location = new System.Drawing.Point(251, 5);
            this.adminDataGFFDataProgressBar.Name = "adminDataGFFDataProgressBar";
            this.adminDataGFFDataProgressBar.Size = new System.Drawing.Size(452, 22);
            this.adminDataGFFDataProgressBar.TabIndex = 5;
            this.adminDataGFFDataProgressBar.Visible = false;
            // 
            // adminDataGFFCollectDataButton
            // 
            this.adminDataGFFCollectDataButton.Location = new System.Drawing.Point(1, 5);
            this.adminDataGFFCollectDataButton.Name = "adminDataGFFCollectDataButton";
            this.adminDataGFFCollectDataButton.Size = new System.Drawing.Size(133, 23);
            this.adminDataGFFCollectDataButton.TabIndex = 4;
            this.adminDataGFFCollectDataButton.Text = "COLLECT DATA";
            this.adminDataGFFCollectDataButton.UseVisualStyleBackColor = true;
            this.adminDataGFFCollectDataButton.Click += new System.EventHandler(this.AdminDataGFFCollectDataButton_Click);
            // 
            // adminDataGFFSqlExportPanel
            // 
            this.adminDataGFFSqlExportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFSqlExportPanel.Controls.Add(this.adminDataGFFSqlExportRunButton);
            this.adminDataGFFSqlExportPanel.Controls.Add(this.adminDataGFFSqlExportLabel);
            this.adminDataGFFSqlExportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFSqlExportPanel.Location = new System.Drawing.Point(0, 189);
            this.adminDataGFFSqlExportPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFSqlExportPanel.Name = "adminDataGFFSqlExportPanel";
            this.adminDataGFFSqlExportPanel.Size = new System.Drawing.Size(355, 150);
            this.adminDataGFFSqlExportPanel.TabIndex = 5;
            // 
            // adminDataGFFSqlExportRunButton
            // 
            this.adminDataGFFSqlExportRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFSqlExportRunButton.Location = new System.Drawing.Point(287, 30);
            this.adminDataGFFSqlExportRunButton.Name = "adminDataGFFSqlExportRunButton";
            this.adminDataGFFSqlExportRunButton.Size = new System.Drawing.Size(60, 25);
            this.adminDataGFFSqlExportRunButton.TabIndex = 2;
            this.adminDataGFFSqlExportRunButton.Text = "RUN";
            this.adminDataGFFSqlExportRunButton.UseVisualStyleBackColor = true;
            this.adminDataGFFSqlExportRunButton.Click += new System.EventHandler(this.AdminDataGFFSqlExportRunButton_Click);
            // 
            // adminDataGFFSqlExportLabel
            // 
            this.adminDataGFFSqlExportLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFSqlExportLabel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminDataGFFSqlExportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFSqlExportLabel.Location = new System.Drawing.Point(2, 7);
            this.adminDataGFFSqlExportLabel.Name = "adminDataGFFSqlExportLabel";
            this.adminDataGFFSqlExportLabel.Size = new System.Drawing.Size(345, 20);
            this.adminDataGFFSqlExportLabel.TabIndex = 4;
            this.adminDataGFFSqlExportLabel.Text = "EXPORT TO DATABASE";
            this.adminDataGFFSqlExportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminDataGFFCsvExportPanel
            // 
            this.adminDataGFFCsvExportPanel.BackColor = System.Drawing.SystemColors.Control;
            this.adminDataGFFCsvExportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFCsvExportPanel.Controls.Add(this.adminDataGFFCsvExportDirectoryTextBox);
            this.adminDataGFFCsvExportPanel.Controls.Add(this.adminDataGFFCsvExportRunButton);
            this.adminDataGFFCsvExportPanel.Controls.Add(this.adminDataGFFCsvExportNameTextBox);
            this.adminDataGFFCsvExportPanel.Controls.Add(this.adminDataGFFCsvExportLabel);
            this.adminDataGFFCsvExportPanel.Controls.Add(this.adminDataGFFCsvExportDirectoryButton);
            this.adminDataGFFCsvExportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCsvExportPanel.Location = new System.Drawing.Point(355, 189);
            this.adminDataGFFCsvExportPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCsvExportPanel.Name = "adminDataGFFCsvExportPanel";
            this.adminDataGFFCsvExportPanel.Size = new System.Drawing.Size(355, 150);
            this.adminDataGFFCsvExportPanel.TabIndex = 6;
            // 
            // adminDataGFFCsvExportDirectoryTextBox
            // 
            this.adminDataGFFCsvExportDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCsvExportDirectoryTextBox.Location = new System.Drawing.Point(143, 56);
            this.adminDataGFFCsvExportDirectoryTextBox.Name = "adminDataGFFCsvExportDirectoryTextBox";
            this.adminDataGFFCsvExportDirectoryTextBox.ReadOnly = true;
            this.adminDataGFFCsvExportDirectoryTextBox.Size = new System.Drawing.Size(207, 20);
            this.adminDataGFFCsvExportDirectoryTextBox.TabIndex = 1;
            this.adminDataGFFCsvExportDirectoryTextBox.Text = "<Save Directory>";
            // 
            // adminDataGFFCsvExportRunButton
            // 
            this.adminDataGFFCsvExportRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCsvExportRunButton.Location = new System.Drawing.Point(293, 120);
            this.adminDataGFFCsvExportRunButton.Name = "adminDataGFFCsvExportRunButton";
            this.adminDataGFFCsvExportRunButton.Size = new System.Drawing.Size(60, 25);
            this.adminDataGFFCsvExportRunButton.TabIndex = 3;
            this.adminDataGFFCsvExportRunButton.Text = "RUN";
            this.adminDataGFFCsvExportRunButton.UseVisualStyleBackColor = true;
            this.adminDataGFFCsvExportRunButton.Click += new System.EventHandler(this.AdminDataGFFCsvExportRunButton_Click);
            // 
            // adminDataGFFCsvExportNameTextBox
            // 
            this.adminDataGFFCsvExportNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCsvExportNameTextBox.Location = new System.Drawing.Point(3, 29);
            this.adminDataGFFCsvExportNameTextBox.Name = "adminDataGFFCsvExportNameTextBox";
            this.adminDataGFFCsvExportNameTextBox.Size = new System.Drawing.Size(347, 20);
            this.adminDataGFFCsvExportNameTextBox.TabIndex = 6;
            this.adminDataGFFCsvExportNameTextBox.Text = "<File Export Name>";
            // 
            // adminDataGFFCsvExportLabel
            // 
            this.adminDataGFFCsvExportLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCsvExportLabel.BackColor = System.Drawing.Color.YellowGreen;
            this.adminDataGFFCsvExportLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminDataGFFCsvExportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFCsvExportLabel.Location = new System.Drawing.Point(3, 6);
            this.adminDataGFFCsvExportLabel.Name = "adminDataGFFCsvExportLabel";
            this.adminDataGFFCsvExportLabel.Size = new System.Drawing.Size(347, 21);
            this.adminDataGFFCsvExportLabel.TabIndex = 5;
            this.adminDataGFFCsvExportLabel.Text = "EXPORT TO CSV";
            this.adminDataGFFCsvExportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminDataGFFCsvExportDirectoryButton
            // 
            this.adminDataGFFCsvExportDirectoryButton.Location = new System.Drawing.Point(3, 53);
            this.adminDataGFFCsvExportDirectoryButton.Name = "adminDataGFFCsvExportDirectoryButton";
            this.adminDataGFFCsvExportDirectoryButton.Size = new System.Drawing.Size(134, 23);
            this.adminDataGFFCsvExportDirectoryButton.TabIndex = 4;
            this.adminDataGFFCsvExportDirectoryButton.Text = "Select Export Location";
            this.adminDataGFFCsvExportDirectoryButton.UseVisualStyleBackColor = true;
            this.adminDataGFFCsvExportDirectoryButton.Click += new System.EventHandler(this.AdminDataGFFCsvExportDirectoryButton_Click);
            // 
            // adminDataGFFCollectionPanel
            // 
            this.adminDataGFFCollectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFCollectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFLayoutPanel.SetColumnSpan(this.adminDataGFFCollectionPanel, 2);
            this.adminDataGFFCollectionPanel.Controls.Add(this.adminDataGFFCollectionLayoutPanel);
            this.adminDataGFFCollectionPanel.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionPanel.Name = "adminDataGFFCollectionPanel";
            this.adminDataGFFCollectionPanel.Size = new System.Drawing.Size(710, 119);
            this.adminDataGFFCollectionPanel.TabIndex = 3;
            // 
            // adminDataGFFCollectionLayoutPanel
            // 
            this.adminDataGFFCollectionLayoutPanel.ColumnCount = 3;
            this.adminDataGFFCollectionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.adminDataGFFCollectionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.adminDataGFFCollectionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionFastLabelPanel, 0, 0);
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionSlowLabelPanel, 1, 0);
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionSlowestLabelPanel, 2, 0);
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionsFastCheckedListPanel, 0, 1);
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionsSlowCheckedListPanel, 1, 1);
            this.adminDataGFFCollectionLayoutPanel.Controls.Add(this.adminDataGFFCollectionsSlowestCheckedListPanel, 2, 1);
            this.adminDataGFFCollectionLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionLayoutPanel.Name = "adminDataGFFCollectionLayoutPanel";
            this.adminDataGFFCollectionLayoutPanel.RowCount = 2;
            this.adminDataGFFCollectionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.adminDataGFFCollectionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataGFFCollectionLayoutPanel.Size = new System.Drawing.Size(708, 117);
            this.adminDataGFFCollectionLayoutPanel.TabIndex = 5;
            // 
            // adminDataGFFCollectionFastLabelPanel
            // 
            this.adminDataGFFCollectionFastLabelPanel.BackColor = System.Drawing.Color.SpringGreen;
            this.adminDataGFFCollectionFastLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFCollectionFastLabelPanel.Controls.Add(this.adminDataGFFCollectionFastLabel);
            this.adminDataGFFCollectionFastLabelPanel.Controls.Add(this.adminDataGFFCollectionFastSelectAllCheckBox);
            this.adminDataGFFCollectionFastLabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionFastLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionFastLabelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionFastLabelPanel.Name = "adminDataGFFCollectionFastLabelPanel";
            this.adminDataGFFCollectionFastLabelPanel.Size = new System.Drawing.Size(175, 25);
            this.adminDataGFFCollectionFastLabelPanel.TabIndex = 0;
            // 
            // adminDataGFFCollectionFastLabel
            // 
            this.adminDataGFFCollectionFastLabel.AutoSize = true;
            this.adminDataGFFCollectionFastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFCollectionFastLabel.Location = new System.Drawing.Point(2, 6);
            this.adminDataGFFCollectionFastLabel.Name = "adminDataGFFCollectionFastLabel";
            this.adminDataGFFCollectionFastLabel.Size = new System.Drawing.Size(119, 13);
            this.adminDataGFFCollectionFastLabel.TabIndex = 3;
            this.adminDataGFFCollectionFastLabel.Text = "FAST COLLECTION";
            this.adminDataGFFCollectionFastLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // adminDataGFFCollectionFastSelectAllCheckBox
            // 
            this.adminDataGFFCollectionFastSelectAllCheckBox.AutoSize = true;
            this.adminDataGFFCollectionFastSelectAllCheckBox.Location = new System.Drawing.Point(127, 6);
            this.adminDataGFFCollectionFastSelectAllCheckBox.Name = "adminDataGFFCollectionFastSelectAllCheckBox";
            this.adminDataGFFCollectionFastSelectAllCheckBox.Size = new System.Drawing.Size(15, 14);
            this.adminDataGFFCollectionFastSelectAllCheckBox.TabIndex = 4;
            this.adminDataGFFCollectionFastSelectAllCheckBox.UseVisualStyleBackColor = true;
            this.adminDataGFFCollectionFastSelectAllCheckBox.CheckedChanged += new System.EventHandler(this.AdminDataGFFCollectionFastSelectAllCheckBox_CheckedChanged);
            // 
            // adminDataGFFCollectionSlowLabelPanel
            // 
            this.adminDataGFFCollectionSlowLabelPanel.BackColor = System.Drawing.Color.Gold;
            this.adminDataGFFCollectionSlowLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFCollectionSlowLabelPanel.Controls.Add(this.adminDataGFFCollectionSlowLabel);
            this.adminDataGFFCollectionSlowLabelPanel.Controls.Add(this.adminDataGFFCollectionSlowSelectAllCheckBox);
            this.adminDataGFFCollectionSlowLabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionSlowLabelPanel.Location = new System.Drawing.Point(175, 0);
            this.adminDataGFFCollectionSlowLabelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionSlowLabelPanel.Name = "adminDataGFFCollectionSlowLabelPanel";
            this.adminDataGFFCollectionSlowLabelPanel.Size = new System.Drawing.Size(178, 25);
            this.adminDataGFFCollectionSlowLabelPanel.TabIndex = 1;
            // 
            // adminDataGFFCollectionSlowLabel
            // 
            this.adminDataGFFCollectionSlowLabel.AutoSize = true;
            this.adminDataGFFCollectionSlowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFCollectionSlowLabel.Location = new System.Drawing.Point(3, 6);
            this.adminDataGFFCollectionSlowLabel.Name = "adminDataGFFCollectionSlowLabel";
            this.adminDataGFFCollectionSlowLabel.Size = new System.Drawing.Size(141, 13);
            this.adminDataGFFCollectionSlowLabel.TabIndex = 3;
            this.adminDataGFFCollectionSlowLabel.Text = "SLOWER COLLECTION";
            this.adminDataGFFCollectionSlowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // adminDataGFFCollectionSlowSelectAllCheckBox
            // 
            this.adminDataGFFCollectionSlowSelectAllCheckBox.AutoSize = true;
            this.adminDataGFFCollectionSlowSelectAllCheckBox.Location = new System.Drawing.Point(150, 6);
            this.adminDataGFFCollectionSlowSelectAllCheckBox.Name = "adminDataGFFCollectionSlowSelectAllCheckBox";
            this.adminDataGFFCollectionSlowSelectAllCheckBox.Size = new System.Drawing.Size(15, 14);
            this.adminDataGFFCollectionSlowSelectAllCheckBox.TabIndex = 4;
            this.adminDataGFFCollectionSlowSelectAllCheckBox.UseVisualStyleBackColor = true;
            this.adminDataGFFCollectionSlowSelectAllCheckBox.CheckedChanged += new System.EventHandler(this.AdminDataGFFCollectionSlowSelectAllCheckBox_CheckedChanged);
            // 
            // adminDataGFFCollectionSlowestLabelPanel
            // 
            this.adminDataGFFCollectionSlowestLabelPanel.BackColor = System.Drawing.Color.Firebrick;
            this.adminDataGFFCollectionSlowestLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFCollectionSlowestLabelPanel.Controls.Add(this.adminDataGFFCollectionSlowestLabel);
            this.adminDataGFFCollectionSlowestLabelPanel.Controls.Add(this.adminDataGFFCollectionSlowestSelectAllCheckBox);
            this.adminDataGFFCollectionSlowestLabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionSlowestLabelPanel.Location = new System.Drawing.Point(353, 0);
            this.adminDataGFFCollectionSlowestLabelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionSlowestLabelPanel.Name = "adminDataGFFCollectionSlowestLabelPanel";
            this.adminDataGFFCollectionSlowestLabelPanel.Size = new System.Drawing.Size(355, 25);
            this.adminDataGFFCollectionSlowestLabelPanel.TabIndex = 2;
            // 
            // adminDataGFFCollectionSlowestLabel
            // 
            this.adminDataGFFCollectionSlowestLabel.AutoSize = true;
            this.adminDataGFFCollectionSlowestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGFFCollectionSlowestLabel.Location = new System.Drawing.Point(4, 6);
            this.adminDataGFFCollectionSlowestLabel.Name = "adminDataGFFCollectionSlowestLabel";
            this.adminDataGFFCollectionSlowestLabel.Size = new System.Drawing.Size(148, 13);
            this.adminDataGFFCollectionSlowestLabel.TabIndex = 3;
            this.adminDataGFFCollectionSlowestLabel.Text = "SLOWEST COLLECTION";
            this.adminDataGFFCollectionSlowestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // adminDataGFFCollectionSlowestSelectAllCheckBox
            // 
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.AutoSize = true;
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.Location = new System.Drawing.Point(156, 5);
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.Name = "adminDataGFFCollectionSlowestSelectAllCheckBox";
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.Size = new System.Drawing.Size(15, 14);
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.TabIndex = 4;
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.UseVisualStyleBackColor = true;
            this.adminDataGFFCollectionSlowestSelectAllCheckBox.CheckedChanged += new System.EventHandler(this.AdminDataGFFCollectionSlowestSelectAllCheckBox_CheckedChanged);
            // 
            // adminDataGFFCollectionsFastCheckedListPanel
            // 
            this.adminDataGFFCollectionsFastCheckedListPanel.Controls.Add(this.adminDataGFFCollectionFastCheckedListBox);
            this.adminDataGFFCollectionsFastCheckedListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionsFastCheckedListPanel.Location = new System.Drawing.Point(0, 25);
            this.adminDataGFFCollectionsFastCheckedListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionsFastCheckedListPanel.Name = "adminDataGFFCollectionsFastCheckedListPanel";
            this.adminDataGFFCollectionsFastCheckedListPanel.Size = new System.Drawing.Size(175, 92);
            this.adminDataGFFCollectionsFastCheckedListPanel.TabIndex = 3;
            // 
            // adminDataGFFCollectionFastCheckedListBox
            // 
            this.adminDataGFFCollectionFastCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionFastCheckedListBox.FormattingEnabled = true;
            this.adminDataGFFCollectionFastCheckedListBox.Items.AddRange(new object[] {
            "Family Name",
            "Family Size",
            "Date Last Modified"});
            this.adminDataGFFCollectionFastCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionFastCheckedListBox.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionFastCheckedListBox.Name = "adminDataGFFCollectionFastCheckedListBox";
            this.adminDataGFFCollectionFastCheckedListBox.Size = new System.Drawing.Size(175, 92);
            this.adminDataGFFCollectionFastCheckedListBox.TabIndex = 1;
            this.adminDataGFFCollectionFastCheckedListBox.ThreeDCheckBoxes = true;
            this.adminDataGFFCollectionFastCheckedListBox.UseTabStops = false;
            // 
            // adminDataGFFCollectionsSlowCheckedListPanel
            // 
            this.adminDataGFFCollectionsSlowCheckedListPanel.Controls.Add(this.adminDataGFFCollectionSlowCheckedListBox);
            this.adminDataGFFCollectionsSlowCheckedListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionsSlowCheckedListPanel.Location = new System.Drawing.Point(175, 25);
            this.adminDataGFFCollectionsSlowCheckedListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionsSlowCheckedListPanel.Name = "adminDataGFFCollectionsSlowCheckedListPanel";
            this.adminDataGFFCollectionsSlowCheckedListPanel.Size = new System.Drawing.Size(178, 92);
            this.adminDataGFFCollectionsSlowCheckedListPanel.TabIndex = 4;
            // 
            // adminDataGFFCollectionSlowCheckedListBox
            // 
            this.adminDataGFFCollectionSlowCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionSlowCheckedListBox.FormattingEnabled = true;
            this.adminDataGFFCollectionSlowCheckedListBox.Items.AddRange(new object[] {
            "Revit Version",
            "Family Category"});
            this.adminDataGFFCollectionSlowCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionSlowCheckedListBox.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionSlowCheckedListBox.MultiColumn = true;
            this.adminDataGFFCollectionSlowCheckedListBox.Name = "adminDataGFFCollectionSlowCheckedListBox";
            this.adminDataGFFCollectionSlowCheckedListBox.Size = new System.Drawing.Size(178, 92);
            this.adminDataGFFCollectionSlowCheckedListBox.TabIndex = 2;
            this.adminDataGFFCollectionSlowCheckedListBox.ThreeDCheckBoxes = true;
            this.adminDataGFFCollectionSlowCheckedListBox.UseTabStops = false;
            // 
            // adminDataGFFCollectionsSlowestCheckedListPanel
            // 
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Controls.Add(this.adminDataGFFCollectionSlowestCheckedListBox);
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Location = new System.Drawing.Point(353, 25);
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Name = "adminDataGFFCollectionsSlowestCheckedListPanel";
            this.adminDataGFFCollectionsSlowestCheckedListPanel.Size = new System.Drawing.Size(355, 92);
            this.adminDataGFFCollectionsSlowestCheckedListPanel.TabIndex = 5;
            // 
            // adminDataGFFCollectionSlowestCheckedListBox
            // 
            this.adminDataGFFCollectionSlowestCheckedListBox.ColumnWidth = 250;
            this.adminDataGFFCollectionSlowestCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFCollectionSlowestCheckedListBox.FormattingEnabled = true;
            this.adminDataGFFCollectionSlowestCheckedListBox.Items.AddRange(new object[] {
            "Family Types",
            "Parameter Group",
            "Parameter GUID",
            "Parameter Is Instance",
            "Parameter Is Shared",
            "Parameter Name",
            "Parameter Type",
            "Parameter Value"});
            this.adminDataGFFCollectionSlowestCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.adminDataGFFCollectionSlowestCheckedListBox.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFCollectionSlowestCheckedListBox.MultiColumn = true;
            this.adminDataGFFCollectionSlowestCheckedListBox.Name = "adminDataGFFCollectionSlowestCheckedListBox";
            this.adminDataGFFCollectionSlowestCheckedListBox.Size = new System.Drawing.Size(355, 92);
            this.adminDataGFFCollectionSlowestCheckedListBox.TabIndex = 2;
            this.adminDataGFFCollectionSlowestCheckedListBox.ThreeDCheckBoxes = true;
            this.adminDataGFFCollectionSlowestCheckedListBox.UseTabStops = false;
            // 
            // adminDataGFFSearchDirectoryPanel
            // 
            this.adminDataGFFSearchDirectoryPanel.BackColor = System.Drawing.SystemColors.Control;
            this.adminDataGFFSearchDirectoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFSearchDirectoryPanel.Controls.Add(this.adminDataGFFSearchDirectoryTextBox);
            this.adminDataGFFSearchDirectoryPanel.Controls.Add(this.adminDataGFFSearchDirectorySelectButton);
            this.adminDataGFFSearchDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFSearchDirectoryPanel.Location = new System.Drawing.Point(0, 119);
            this.adminDataGFFSearchDirectoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFSearchDirectoryPanel.Name = "adminDataGFFSearchDirectoryPanel";
            this.adminDataGFFSearchDirectoryPanel.Size = new System.Drawing.Size(355, 35);
            this.adminDataGFFSearchDirectoryPanel.TabIndex = 7;
            // 
            // adminDataGFFSearchDirectoryTextBox
            // 
            this.adminDataGFFSearchDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGFFSearchDirectoryTextBox.Location = new System.Drawing.Point(141, 7);
            this.adminDataGFFSearchDirectoryTextBox.Name = "adminDataGFFSearchDirectoryTextBox";
            this.adminDataGFFSearchDirectoryTextBox.ReadOnly = true;
            this.adminDataGFFSearchDirectoryTextBox.Size = new System.Drawing.Size(205, 20);
            this.adminDataGFFSearchDirectoryTextBox.TabIndex = 1;
            this.adminDataGFFSearchDirectoryTextBox.Text = "<Search Directory>";
            // 
            // adminDataGFFSearchDirectorySelectButton
            // 
            this.adminDataGFFSearchDirectorySelectButton.Location = new System.Drawing.Point(3, 5);
            this.adminDataGFFSearchDirectorySelectButton.Name = "adminDataGFFSearchDirectorySelectButton";
            this.adminDataGFFSearchDirectorySelectButton.Size = new System.Drawing.Size(132, 23);
            this.adminDataGFFSearchDirectorySelectButton.TabIndex = 0;
            this.adminDataGFFSearchDirectorySelectButton.Text = "SELECT DIRECTORY";
            this.adminDataGFFSearchDirectorySelectButton.UseVisualStyleBackColor = true;
            this.adminDataGFFSearchDirectorySelectButton.Click += new System.EventHandler(this.AdminDataGFFSearchDirectorySelectButton_Click);
            // 
            // adminDataGFFDatePanel
            // 
            this.adminDataGFFDatePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGFFDatePanel.Controls.Add(this.adminDataGFFDatePicker);
            this.adminDataGFFDatePanel.Controls.Add(this.adminDataGFFDateCheckBox);
            this.adminDataGFFDatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGFFDatePanel.Location = new System.Drawing.Point(355, 119);
            this.adminDataGFFDatePanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminDataGFFDatePanel.Name = "adminDataGFFDatePanel";
            this.adminDataGFFDatePanel.Size = new System.Drawing.Size(355, 35);
            this.adminDataGFFDatePanel.TabIndex = 8;
            // 
            // adminDataGFFDatePicker
            // 
            this.adminDataGFFDatePicker.Checked = false;
            this.adminDataGFFDatePicker.Location = new System.Drawing.Point(143, 7);
            this.adminDataGFFDatePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.adminDataGFFDatePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.adminDataGFFDatePicker.Name = "adminDataGFFDatePicker";
            this.adminDataGFFDatePicker.Size = new System.Drawing.Size(208, 20);
            this.adminDataGFFDatePicker.TabIndex = 6;
            this.adminDataGFFDatePicker.Value = new System.DateTime(2018, 7, 7, 0, 0, 0, 0);
            // 
            // adminDataGFFDateCheckBox
            // 
            this.adminDataGFFDateCheckBox.AutoSize = true;
            this.adminDataGFFDateCheckBox.Location = new System.Drawing.Point(2, 9);
            this.adminDataGFFDateCheckBox.Name = "adminDataGFFDateCheckBox";
            this.adminDataGFFDateCheckBox.Size = new System.Drawing.Size(106, 17);
            this.adminDataGFFDateCheckBox.TabIndex = 7;
            this.adminDataGFFDateCheckBox.Text = "Use Date Range";
            this.adminDataGFFDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // adminDataGBDVLayoutPanel
            // 
            this.adminDataGBDVLayoutPanel.ColumnCount = 2;
            this.adminDataGBDVLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminDataGBDVLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminDataGBDVLayoutPanel.Controls.Add(this.adminDataGBDVCollectPanel, 0, 0);
            this.adminDataGBDVLayoutPanel.Controls.Add(this.adminDataGBDVExportDbPanel, 0, 1);
            this.adminDataGBDVLayoutPanel.Controls.Add(this.adminDataGBDVExportCsvPanel, 1, 1);
            this.adminDataGBDVLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGBDVLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminDataGBDVLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVLayoutPanel.Name = "adminDataGBDVLayoutPanel";
            this.adminDataGBDVLayoutPanel.RowCount = 2;
            this.adminDataGBDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.adminDataGBDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminDataGBDVLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminDataGBDVLayoutPanel.TabIndex = 7;
            this.adminDataGBDVLayoutPanel.Visible = false;
            // 
            // adminDataGBDVCollectPanel
            // 
            this.adminDataGBDVCollectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGBDVLayoutPanel.SetColumnSpan(this.adminDataGBDVCollectPanel, 2);
            this.adminDataGBDVCollectPanel.Controls.Add(this.adminDataGBDVWaitLabel);
            this.adminDataGBDVCollectPanel.Controls.Add(this.adminDataGBDVCollectButton);
            this.adminDataGBDVCollectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGBDVCollectPanel.Location = new System.Drawing.Point(2, 2);
            this.adminDataGBDVCollectPanel.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVCollectPanel.Name = "adminDataGBDVCollectPanel";
            this.adminDataGBDVCollectPanel.Size = new System.Drawing.Size(706, 32);
            this.adminDataGBDVCollectPanel.TabIndex = 0;
            // 
            // adminDataGBDVWaitLabel
            // 
            this.adminDataGBDVWaitLabel.AutoSize = true;
            this.adminDataGBDVWaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGBDVWaitLabel.Location = new System.Drawing.Point(104, 9);
            this.adminDataGBDVWaitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adminDataGBDVWaitLabel.Name = "adminDataGBDVWaitLabel";
            this.adminDataGBDVWaitLabel.Size = new System.Drawing.Size(87, 13);
            this.adminDataGBDVWaitLabel.TabIndex = 1;
            this.adminDataGBDVWaitLabel.Text = "Please Wait...";
            this.adminDataGBDVWaitLabel.Visible = false;
            // 
            // adminDataGBDVCollectButton
            // 
            this.adminDataGBDVCollectButton.AutoSize = true;
            this.adminDataGBDVCollectButton.Location = new System.Drawing.Point(3, 5);
            this.adminDataGBDVCollectButton.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVCollectButton.Name = "adminDataGBDVCollectButton";
            this.adminDataGBDVCollectButton.Size = new System.Drawing.Size(97, 23);
            this.adminDataGBDVCollectButton.TabIndex = 0;
            this.adminDataGBDVCollectButton.Text = "COLLECT DATA";
            this.adminDataGBDVCollectButton.UseVisualStyleBackColor = true;
            this.adminDataGBDVCollectButton.Click += new System.EventHandler(this.AdminDataGBDVCollectButton_Click);
            // 
            // adminDataGBDVExportDbPanel
            // 
            this.adminDataGBDVExportDbPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGBDVExportDbPanel.Controls.Add(this.adminDataGBDVExportDbRunButton);
            this.adminDataGBDVExportDbPanel.Controls.Add(this.adminDataGBDVExportDbLabel);
            this.adminDataGBDVExportDbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGBDVExportDbPanel.Location = new System.Drawing.Point(2, 38);
            this.adminDataGBDVExportDbPanel.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVExportDbPanel.Name = "adminDataGBDVExportDbPanel";
            this.adminDataGBDVExportDbPanel.Size = new System.Drawing.Size(351, 299);
            this.adminDataGBDVExportDbPanel.TabIndex = 1;
            // 
            // adminDataGBDVExportDbRunButton
            // 
            this.adminDataGBDVExportDbRunButton.Location = new System.Drawing.Point(3, 23);
            this.adminDataGBDVExportDbRunButton.Name = "adminDataGBDVExportDbRunButton";
            this.adminDataGBDVExportDbRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminDataGBDVExportDbRunButton.TabIndex = 2;
            this.adminDataGBDVExportDbRunButton.Text = "RUN";
            this.adminDataGBDVExportDbRunButton.UseVisualStyleBackColor = true;
            this.adminDataGBDVExportDbRunButton.Click += new System.EventHandler(this.AdminDataGBDVExportDbRunButton_Click);
            // 
            // adminDataGBDVExportDbLabel
            // 
            this.adminDataGBDVExportDbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGBDVExportDbLabel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminDataGBDVExportDbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGBDVExportDbLabel.Location = new System.Drawing.Point(3, 0);
            this.adminDataGBDVExportDbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adminDataGBDVExportDbLabel.Name = "adminDataGBDVExportDbLabel";
            this.adminDataGBDVExportDbLabel.Size = new System.Drawing.Size(342, 20);
            this.adminDataGBDVExportDbLabel.TabIndex = 0;
            this.adminDataGBDVExportDbLabel.Text = "EXPORT TO DATABASE";
            this.adminDataGBDVExportDbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminDataGBDVExportCsvPanel
            // 
            this.adminDataGBDVExportCsvPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminDataGBDVExportCsvPanel.Controls.Add(this.adminDataGBDVExportCsvDirectoryTextBox);
            this.adminDataGBDVExportCsvPanel.Controls.Add(this.adminDataGBDVExportCsvSelectDirectoryButton);
            this.adminDataGBDVExportCsvPanel.Controls.Add(this.adminDataGBDVExportCsvRunButton);
            this.adminDataGBDVExportCsvPanel.Controls.Add(this.adminDataGBDVExportCsvTextBox);
            this.adminDataGBDVExportCsvPanel.Controls.Add(this.adminDataGBDVExportCsvLabel);
            this.adminDataGBDVExportCsvPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminDataGBDVExportCsvPanel.Location = new System.Drawing.Point(357, 38);
            this.adminDataGBDVExportCsvPanel.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVExportCsvPanel.Name = "adminDataGBDVExportCsvPanel";
            this.adminDataGBDVExportCsvPanel.Size = new System.Drawing.Size(351, 299);
            this.adminDataGBDVExportCsvPanel.TabIndex = 2;
            // 
            // adminDataGBDVExportCsvDirectoryTextBox
            // 
            this.adminDataGBDVExportCsvDirectoryTextBox.Location = new System.Drawing.Point(141, 49);
            this.adminDataGBDVExportCsvDirectoryTextBox.Name = "adminDataGBDVExportCsvDirectoryTextBox";
            this.adminDataGBDVExportCsvDirectoryTextBox.ReadOnly = true;
            this.adminDataGBDVExportCsvDirectoryTextBox.Size = new System.Drawing.Size(205, 20);
            this.adminDataGBDVExportCsvDirectoryTextBox.TabIndex = 4;
            this.adminDataGBDVExportCsvDirectoryTextBox.Text = "<Save Directory>";
            // 
            // adminDataGBDVExportCsvSelectDirectoryButton
            // 
            this.adminDataGBDVExportCsvSelectDirectoryButton.Location = new System.Drawing.Point(3, 47);
            this.adminDataGBDVExportCsvSelectDirectoryButton.Name = "adminDataGBDVExportCsvSelectDirectoryButton";
            this.adminDataGBDVExportCsvSelectDirectoryButton.Size = new System.Drawing.Size(132, 23);
            this.adminDataGBDVExportCsvSelectDirectoryButton.TabIndex = 3;
            this.adminDataGBDVExportCsvSelectDirectoryButton.Text = "Select Export Location";
            this.adminDataGBDVExportCsvSelectDirectoryButton.UseVisualStyleBackColor = true;
            this.adminDataGBDVExportCsvSelectDirectoryButton.Click += new System.EventHandler(this.AdminDataGBDVExportCsvSelectDirectoryButton_Click);
            // 
            // adminDataGBDVExportCsvRunButton
            // 
            this.adminDataGBDVExportCsvRunButton.Location = new System.Drawing.Point(3, 76);
            this.adminDataGBDVExportCsvRunButton.Name = "adminDataGBDVExportCsvRunButton";
            this.adminDataGBDVExportCsvRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminDataGBDVExportCsvRunButton.TabIndex = 2;
            this.adminDataGBDVExportCsvRunButton.Text = "RUN";
            this.adminDataGBDVExportCsvRunButton.UseVisualStyleBackColor = true;
            this.adminDataGBDVExportCsvRunButton.Click += new System.EventHandler(this.AdminDataGBDVExportCsvRunButton_Click);
            // 
            // adminDataGBDVExportCsvTextBox
            // 
            this.adminDataGBDVExportCsvTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGBDVExportCsvTextBox.Location = new System.Drawing.Point(3, 22);
            this.adminDataGBDVExportCsvTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.adminDataGBDVExportCsvTextBox.Name = "adminDataGBDVExportCsvTextBox";
            this.adminDataGBDVExportCsvTextBox.Size = new System.Drawing.Size(342, 20);
            this.adminDataGBDVExportCsvTextBox.TabIndex = 1;
            this.adminDataGBDVExportCsvTextBox.Text = "<File Export Name>";
            // 
            // adminDataGBDVExportCsvLabel
            // 
            this.adminDataGBDVExportCsvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGBDVExportCsvLabel.BackColor = System.Drawing.Color.YellowGreen;
            this.adminDataGBDVExportCsvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminDataGBDVExportCsvLabel.Location = new System.Drawing.Point(3, 0);
            this.adminDataGBDVExportCsvLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adminDataGBDVExportCsvLabel.Name = "adminDataGBDVExportCsvLabel";
            this.adminDataGBDVExportCsvLabel.Size = new System.Drawing.Size(342, 20);
            this.adminDataGBDVExportCsvLabel.TabIndex = 0;
            this.adminDataGBDVExportCsvLabel.Text = "EXPORT TO CSV";
            this.adminDataGBDVExportCsvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminFamiliesTab
            // 
            this.adminFamiliesTab.BackColor = System.Drawing.SystemColors.Control;
            this.adminFamiliesTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesTab.Controls.Add(this.adminFamiliesLayoutPanel);
            this.adminFamiliesTab.Location = new System.Drawing.Point(4, 25);
            this.adminFamiliesTab.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesTab.Name = "adminFamiliesTab";
            this.adminFamiliesTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminFamiliesTab.Size = new System.Drawing.Size(720, 402);
            this.adminFamiliesTab.TabIndex = 1;
            this.adminFamiliesTab.Text = "Families";
            // 
            // adminFamiliesLayoutPanel
            // 
            this.adminFamiliesLayoutPanel.ColumnCount = 1;
            this.adminFamiliesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesLayoutPanel.Controls.Add(this.adminFamiliesToolStrip, 0, 0);
            this.adminFamiliesLayoutPanel.Controls.Add(this.adminFamiliesToolsPanel, 0, 1);
            this.adminFamiliesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.adminFamiliesLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesLayoutPanel.Name = "adminFamiliesLayoutPanel";
            this.adminFamiliesLayoutPanel.RowCount = 2;
            this.adminFamiliesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.adminFamiliesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.adminFamiliesLayoutPanel.TabIndex = 0;
            // 
            // adminFamiliesToolStrip
            // 
            this.adminFamiliesToolStrip.AutoSize = false;
            this.adminFamiliesToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.adminFamiliesToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.adminFamiliesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminFamiliesUFButton,
            this.toolStripSeparator3,
            this.adminFamiliesDFBButton,
            this.adminFamiliesSeparator1,
            this.adminFamiliesParametersDropDownButton,
            this.toolStripSeparator1});
            this.adminFamiliesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesToolStrip.Name = "adminFamiliesToolStrip";
            this.adminFamiliesToolStrip.Size = new System.Drawing.Size(710, 53);
            this.adminFamiliesToolStrip.TabIndex = 0;
            this.adminFamiliesToolStrip.Text = "BIMFamiliesToolStrip";
            // 
            // adminFamiliesUFButton
            // 
            this.adminFamiliesUFButton.Image = ((System.Drawing.Image)(resources.GetObject("adminFamiliesUFButton.Image")));
            this.adminFamiliesUFButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.adminFamiliesUFButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminFamiliesUFButton.Name = "adminFamiliesUFButton";
            this.adminFamiliesUFButton.Size = new System.Drawing.Size(102, 50);
            this.adminFamiliesUFButton.Text = "Upgrade Families";
            this.adminFamiliesUFButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminFamiliesUFButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminFamiliesUFButton.Click += new System.EventHandler(this.AdminFamiliesUFButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // adminFamiliesDFBButton
            // 
            this.adminFamiliesDFBButton.Image = ((System.Drawing.Image)(resources.GetObject("adminFamiliesDFBButton.Image")));
            this.adminFamiliesDFBButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminFamiliesDFBButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminFamiliesDFBButton.Name = "adminFamiliesDFBButton";
            this.adminFamiliesDFBButton.Size = new System.Drawing.Size(129, 50);
            this.adminFamiliesDFBButton.Text = "Delete Family Backups";
            this.adminFamiliesDFBButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminFamiliesDFBButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminFamiliesDFBButton.Click += new System.EventHandler(this.AdminFamiliesDFBButton_Click);
            // 
            // adminFamiliesSeparator1
            // 
            this.adminFamiliesSeparator1.AutoSize = false;
            this.adminFamiliesSeparator1.Name = "adminFamiliesSeparator1";
            this.adminFamiliesSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // adminFamiliesParametersDropDownButton
            // 
            this.adminFamiliesParametersDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminFamiliesBAPButton,
            this.adminFamiliesBRPButton,
            this.bulkUpdatePublishVersionToolStripMenuItem});
            this.adminFamiliesParametersDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("adminFamiliesParametersDropDownButton.Image")));
            this.adminFamiliesParametersDropDownButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminFamiliesParametersDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminFamiliesParametersDropDownButton.Name = "adminFamiliesParametersDropDownButton";
            this.adminFamiliesParametersDropDownButton.Size = new System.Drawing.Size(79, 50);
            this.adminFamiliesParametersDropDownButton.Text = "Parameters";
            this.adminFamiliesParametersDropDownButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminFamiliesParametersDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // adminFamiliesBAPButton
            // 
            this.adminFamiliesBAPButton.Image = global::BARevitTools.Properties.Resources.bimFamiliesBAPIcon;
            this.adminFamiliesBAPButton.Name = "adminFamiliesBAPButton";
            this.adminFamiliesBAPButton.Size = new System.Drawing.Size(221, 22);
            this.adminFamiliesBAPButton.Text = "Bulk Add Parameters";
            this.adminFamiliesBAPButton.Click += new System.EventHandler(this.AdminFamiliesBAPButton_Click);
            // 
            // adminFamiliesBRPButton
            // 
            this.adminFamiliesBRPButton.Image = global::BARevitTools.Properties.Resources.bimFamiliesBRPIcon;
            this.adminFamiliesBRPButton.Name = "adminFamiliesBRPButton";
            this.adminFamiliesBRPButton.Size = new System.Drawing.Size(221, 22);
            this.adminFamiliesBRPButton.Text = "Bulk Remove Parameters";
            this.adminFamiliesBRPButton.Click += new System.EventHandler(this.AdminFamiliesBRPButton_Click);
            // 
            // bulkUpdatePublishVersionToolStripMenuItem
            // 
            this.bulkUpdatePublishVersionToolStripMenuItem.Name = "bulkUpdatePublishVersionToolStripMenuItem";
            this.bulkUpdatePublishVersionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.bulkUpdatePublishVersionToolStripMenuItem.Text = "Bulk Update Publish Version";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // adminFamiliesToolsPanel
            // 
            this.adminFamiliesToolsPanel.Controls.Add(this.adminFamiliesBAPLayoutPanel);
            this.adminFamiliesToolsPanel.Controls.Add(this.adminFamiliesUFLayoutPanel);
            this.adminFamiliesToolsPanel.Controls.Add(this.adminFamiliesBRPLayoutPanel);
            this.adminFamiliesToolsPanel.Controls.Add(this.adminFamiliesDFBLayoutPanel);
            this.adminFamiliesToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.adminFamiliesToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesToolsPanel.Name = "adminFamiliesToolsPanel";
            this.adminFamiliesToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.adminFamiliesToolsPanel.TabIndex = 1;
            // 
            // adminFamiliesBAPLayoutPanel
            // 
            this.adminFamiliesBAPLayoutPanel.ColumnCount = 2;
            this.adminFamiliesBAPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.adminFamiliesBAPLayoutPanel.Controls.Add(this.adminFamiliesBAPRunPanel, 0, 2);
            this.adminFamiliesBAPLayoutPanel.Controls.Add(this.adminFamiliesBAPSplitPanel, 0, 1);
            this.adminFamiliesBAPLayoutPanel.Controls.Add(this.adminFamiliesBAPFamiliesDirectoryPanel, 0, 0);
            this.adminFamiliesBAPLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPLayoutPanel.Name = "adminFamiliesBAPLayoutPanel";
            this.adminFamiliesBAPLayoutPanel.RowCount = 3;
            this.adminFamiliesBAPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBAPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBAPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.adminFamiliesBAPLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminFamiliesBAPLayoutPanel.TabIndex = 2;
            this.adminFamiliesBAPLayoutPanel.Visible = false;
            // 
            // adminFamiliesBAPRunPanel
            // 
            this.adminFamiliesBAPLayoutPanel.SetColumnSpan(this.adminFamiliesBAPRunPanel, 2);
            this.adminFamiliesBAPRunPanel.Controls.Add(this.adminFamiliesBAPDoneLabel);
            this.adminFamiliesBAPRunPanel.Controls.Add(this.adminFamiliesBAPProgressBar);
            this.adminFamiliesBAPRunPanel.Controls.Add(this.adminFamiliesBAPRunButton);
            this.adminFamiliesBAPRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPRunPanel.Location = new System.Drawing.Point(0, 304);
            this.adminFamiliesBAPRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPRunPanel.Name = "adminFamiliesBAPRunPanel";
            this.adminFamiliesBAPRunPanel.Size = new System.Drawing.Size(710, 35);
            this.adminFamiliesBAPRunPanel.TabIndex = 5;
            // 
            // adminFamiliesBAPDoneLabel
            // 
            this.adminFamiliesBAPDoneLabel.AutoSize = true;
            this.adminFamiliesBAPDoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminFamiliesBAPDoneLabel.Location = new System.Drawing.Point(89, 9);
            this.adminFamiliesBAPDoneLabel.Name = "adminFamiliesBAPDoneLabel";
            this.adminFamiliesBAPDoneLabel.Size = new System.Drawing.Size(41, 13);
            this.adminFamiliesBAPDoneLabel.TabIndex = 2;
            this.adminFamiliesBAPDoneLabel.Text = "Done!";
            this.adminFamiliesBAPDoneLabel.Visible = false;
            // 
            // adminFamiliesBAPProgressBar
            // 
            this.adminFamiliesBAPProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesBAPProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.adminFamiliesBAPProgressBar.Location = new System.Drawing.Point(136, 6);
            this.adminFamiliesBAPProgressBar.Name = "adminFamiliesBAPProgressBar";
            this.adminFamiliesBAPProgressBar.Size = new System.Drawing.Size(571, 23);
            this.adminFamiliesBAPProgressBar.TabIndex = 1;
            this.adminFamiliesBAPProgressBar.Visible = false;
            // 
            // adminFamiliesBAPRunButton
            // 
            this.adminFamiliesBAPRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.adminFamiliesBAPRunButton.Location = new System.Drawing.Point(7, 5);
            this.adminFamiliesBAPRunButton.Name = "adminFamiliesBAPRunButton";
            this.adminFamiliesBAPRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBAPRunButton.TabIndex = 0;
            this.adminFamiliesBAPRunButton.Text = "RUN";
            this.adminFamiliesBAPRunButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBAPRunButton.Click += new System.EventHandler(this.AdminFamiliesBAPRunButton_Click);
            // 
            // adminFamiliesBAPSplitPanel
            // 
            this.adminFamiliesBAPLayoutPanel.SetColumnSpan(this.adminFamiliesBAPSplitPanel, 2);
            this.adminFamiliesBAPSplitPanel.Controls.Add(this.adminFamiliesBAPSplitContainer);
            this.adminFamiliesBAPSplitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPSplitPanel.Location = new System.Drawing.Point(3, 38);
            this.adminFamiliesBAPSplitPanel.Name = "adminFamiliesBAPSplitPanel";
            this.adminFamiliesBAPSplitPanel.Size = new System.Drawing.Size(704, 263);
            this.adminFamiliesBAPSplitPanel.TabIndex = 6;
            // 
            // adminFamiliesBAPSplitContainer
            // 
            this.adminFamiliesBAPSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPSplitContainer.Name = "adminFamiliesBAPSplitContainer";
            // 
            // adminFamiliesBAPSplitContainer.Panel1
            // 
            this.adminFamiliesBAPSplitContainer.Panel1.Controls.Add(this.adminFamiliesBAPParametersLayoutPanel);
            // 
            // adminFamiliesBAPSplitContainer.Panel2
            // 
            this.adminFamiliesBAPSplitContainer.Panel2.Controls.Add(this.adminFamiliesBAPSelectLayoutPanel);
            this.adminFamiliesBAPSplitContainer.Size = new System.Drawing.Size(704, 263);
            this.adminFamiliesBAPSplitContainer.SplitterDistance = 364;
            this.adminFamiliesBAPSplitContainer.TabIndex = 0;
            // 
            // adminFamiliesBAPParametersLayoutPanel
            // 
            this.adminFamiliesBAPParametersLayoutPanel.ColumnCount = 1;
            this.adminFamiliesBAPParametersLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPParametersLayoutPanel.Controls.Add(this.adminFamiliesBAPParametersDGV, 0, 1);
            this.adminFamiliesBAPParametersLayoutPanel.Controls.Add(this.adminFamiliesBAPSharedParametersPanel, 0, 0);
            this.adminFamiliesBAPParametersLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPParametersLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPParametersLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPParametersLayoutPanel.Name = "adminFamiliesBAPParametersLayoutPanel";
            this.adminFamiliesBAPParametersLayoutPanel.RowCount = 2;
            this.adminFamiliesBAPParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBAPParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPParametersLayoutPanel.Size = new System.Drawing.Size(364, 263);
            this.adminFamiliesBAPParametersLayoutPanel.TabIndex = 4;
            // 
            // adminFamiliesBAPParametersDGV
            // 
            this.adminFamiliesBAPParametersDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesBAPParametersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminFamiliesBAPParametersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPParametersDGV.Location = new System.Drawing.Point(0, 35);
            this.adminFamiliesBAPParametersDGV.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPParametersDGV.Name = "adminFamiliesBAPParametersDGV";
            this.adminFamiliesBAPParametersDGV.RowHeadersWidth = 15;
            this.adminFamiliesBAPParametersDGV.Size = new System.Drawing.Size(364, 228);
            this.adminFamiliesBAPParametersDGV.TabIndex = 0;
            // 
            // adminFamiliesBAPSharedParametersPanel
            // 
            this.adminFamiliesBAPSharedParametersPanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminFamiliesBAPSharedParametersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBAPSharedParametersPanel.Controls.Add(this.BIMFamiliesBAPSharedParametersButton);
            this.adminFamiliesBAPSharedParametersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPSharedParametersPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPSharedParametersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPSharedParametersPanel.Name = "adminFamiliesBAPSharedParametersPanel";
            this.adminFamiliesBAPSharedParametersPanel.Size = new System.Drawing.Size(364, 35);
            this.adminFamiliesBAPSharedParametersPanel.TabIndex = 3;
            // 
            // BIMFamiliesBAPSharedParametersButton
            // 
            this.BIMFamiliesBAPSharedParametersButton.AutoSize = true;
            this.BIMFamiliesBAPSharedParametersButton.Location = new System.Drawing.Point(3, 1);
            this.BIMFamiliesBAPSharedParametersButton.Margin = new System.Windows.Forms.Padding(0);
            this.BIMFamiliesBAPSharedParametersButton.Name = "BIMFamiliesBAPSharedParametersButton";
            this.BIMFamiliesBAPSharedParametersButton.Size = new System.Drawing.Size(182, 30);
            this.BIMFamiliesBAPSharedParametersButton.TabIndex = 2;
            this.BIMFamiliesBAPSharedParametersButton.Text = "Add Shared Parameter";
            this.BIMFamiliesBAPSharedParametersButton.UseVisualStyleBackColor = true;
            this.BIMFamiliesBAPSharedParametersButton.Click += new System.EventHandler(this.AdminFamiliesBAPSharedParametersButton_Click);
            // 
            // adminFamiliesBAPSelectLayoutPanel
            // 
            this.adminFamiliesBAPSelectLayoutPanel.ColumnCount = 1;
            this.adminFamiliesBAPSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPSelectLayoutPanel.Controls.Add(this.adminFamiliesBAPSelectPanel, 0, 0);
            this.adminFamiliesBAPSelectLayoutPanel.Controls.Add(this.adminFamiliesBAPFamiliesDGV, 0, 1);
            this.adminFamiliesBAPSelectLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPSelectLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPSelectLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPSelectLayoutPanel.Name = "adminFamiliesBAPSelectLayoutPanel";
            this.adminFamiliesBAPSelectLayoutPanel.RowCount = 2;
            this.adminFamiliesBAPSelectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBAPSelectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBAPSelectLayoutPanel.Size = new System.Drawing.Size(336, 263);
            this.adminFamiliesBAPSelectLayoutPanel.TabIndex = 5;
            // 
            // adminFamiliesBAPSelectPanel
            // 
            this.adminFamiliesBAPSelectPanel.BackColor = System.Drawing.Color.YellowGreen;
            this.adminFamiliesBAPSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBAPSelectPanel.Controls.Add(this.adminFamiliesBAPSelectNoneButton);
            this.adminFamiliesBAPSelectPanel.Controls.Add(this.adminFamiliesBAPSelectAllButton);
            this.adminFamiliesBAPSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPSelectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPSelectPanel.Name = "adminFamiliesBAPSelectPanel";
            this.adminFamiliesBAPSelectPanel.Size = new System.Drawing.Size(336, 35);
            this.adminFamiliesBAPSelectPanel.TabIndex = 4;
            // 
            // adminFamiliesBAPSelectNoneButton
            // 
            this.adminFamiliesBAPSelectNoneButton.Location = new System.Drawing.Point(84, 4);
            this.adminFamiliesBAPSelectNoneButton.Name = "adminFamiliesBAPSelectNoneButton";
            this.adminFamiliesBAPSelectNoneButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBAPSelectNoneButton.TabIndex = 0;
            this.adminFamiliesBAPSelectNoneButton.Text = "Select None";
            this.adminFamiliesBAPSelectNoneButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBAPSelectNoneButton.Click += new System.EventHandler(this.AdminFamiliesBAPSelectNoneButton_Click);
            // 
            // adminFamiliesBAPSelectAllButton
            // 
            this.adminFamiliesBAPSelectAllButton.Location = new System.Drawing.Point(3, 4);
            this.adminFamiliesBAPSelectAllButton.Name = "adminFamiliesBAPSelectAllButton";
            this.adminFamiliesBAPSelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBAPSelectAllButton.TabIndex = 0;
            this.adminFamiliesBAPSelectAllButton.Text = "Select All";
            this.adminFamiliesBAPSelectAllButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBAPSelectAllButton.Click += new System.EventHandler(this.AdminFamiliesBAPSelectAllButton_Click);
            // 
            // adminFamiliesBAPFamiliesDGV
            // 
            this.adminFamiliesBAPFamiliesDGV.AllowUserToAddRows = false;
            this.adminFamiliesBAPFamiliesDGV.AllowUserToDeleteRows = false;
            this.adminFamiliesBAPFamiliesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesBAPFamiliesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminFamiliesBAPFamiliesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPFamiliesDGV.Location = new System.Drawing.Point(0, 35);
            this.adminFamiliesBAPFamiliesDGV.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPFamiliesDGV.Name = "adminFamiliesBAPFamiliesDGV";
            this.adminFamiliesBAPFamiliesDGV.RowHeadersVisible = false;
            this.adminFamiliesBAPFamiliesDGV.Size = new System.Drawing.Size(336, 228);
            this.adminFamiliesBAPFamiliesDGV.TabIndex = 1;
            this.adminFamiliesBAPFamiliesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdminFamiliesBAPFamiliesDGV_CellContentClick);
            // 
            // adminFamiliesBAPFamiliesDirectoryPanel
            // 
            this.adminFamiliesBAPFamiliesDirectoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBAPLayoutPanel.SetColumnSpan(this.adminFamiliesBAPFamiliesDirectoryPanel, 2);
            this.adminFamiliesBAPFamiliesDirectoryPanel.Controls.Add(this.adminFamiliesBAPDirectorySelectButton);
            this.adminFamiliesBAPFamiliesDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBAPFamiliesDirectoryPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBAPFamiliesDirectoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBAPFamiliesDirectoryPanel.Name = "adminFamiliesBAPFamiliesDirectoryPanel";
            this.adminFamiliesBAPFamiliesDirectoryPanel.Size = new System.Drawing.Size(710, 35);
            this.adminFamiliesBAPFamiliesDirectoryPanel.TabIndex = 7;
            // 
            // adminFamiliesBAPDirectorySelectButton
            // 
            this.adminFamiliesBAPDirectorySelectButton.Location = new System.Drawing.Point(3, 4);
            this.adminFamiliesBAPDirectorySelectButton.Name = "adminFamiliesBAPDirectorySelectButton";
            this.adminFamiliesBAPDirectorySelectButton.Size = new System.Drawing.Size(124, 23);
            this.adminFamiliesBAPDirectorySelectButton.TabIndex = 0;
            this.adminFamiliesBAPDirectorySelectButton.Text = "Select Directory";
            this.adminFamiliesBAPDirectorySelectButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBAPDirectorySelectButton.Click += new System.EventHandler(this.AdminFamiliesBAPSelectDirectoryButton_Click);
            // 
            // adminFamiliesUFLayoutPanel
            // 
            this.adminFamiliesUFLayoutPanel.ColumnCount = 2;
            this.adminFamiliesUFLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminFamiliesUFLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFFullSyncPanel, 0, 0);
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFUpgradedFamiliesListBox, 0, 2);
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFDeletedFamiliesListBox, 1, 2);
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFUpgradedFamiliesTextBoxPanel, 0, 1);
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFDeletedFamiliesTextBoxPanel, 1, 1);
            this.adminFamiliesUFLayoutPanel.Controls.Add(this.adminFamiliesUFRunPanel, 0, 3);
            this.adminFamiliesUFLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesUFLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesUFLayoutPanel.Name = "adminFamiliesUFLayoutPanel";
            this.adminFamiliesUFLayoutPanel.RowCount = 4;
            this.adminFamiliesUFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.adminFamiliesUFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesUFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesUFLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.adminFamiliesUFLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminFamiliesUFLayoutPanel.TabIndex = 1;
            this.adminFamiliesUFLayoutPanel.Visible = false;
            // 
            // adminFamiliesUFFullSyncPanel
            // 
            this.adminFamiliesUFLayoutPanel.SetColumnSpan(this.adminFamiliesUFFullSyncPanel, 2);
            this.adminFamiliesUFFullSyncPanel.Controls.Add(this.adminFamiliesUFFullSyncCheckbox);
            this.adminFamiliesUFFullSyncPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFFullSyncPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesUFFullSyncPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesUFFullSyncPanel.Name = "adminFamiliesUFFullSyncPanel";
            this.adminFamiliesUFFullSyncPanel.Size = new System.Drawing.Size(710, 30);
            this.adminFamiliesUFFullSyncPanel.TabIndex = 0;
            // 
            // adminFamiliesUFFullSyncCheckbox
            // 
            this.adminFamiliesUFFullSyncCheckbox.AutoSize = true;
            this.adminFamiliesUFFullSyncCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminFamiliesUFFullSyncCheckbox.Location = new System.Drawing.Point(3, 7);
            this.adminFamiliesUFFullSyncCheckbox.Name = "adminFamiliesUFFullSyncCheckbox";
            this.adminFamiliesUFFullSyncCheckbox.Size = new System.Drawing.Size(109, 17);
            this.adminFamiliesUFFullSyncCheckbox.TabIndex = 0;
            this.adminFamiliesUFFullSyncCheckbox.Text = "Full Library Sync?";
            this.adminFamiliesUFFullSyncCheckbox.UseVisualStyleBackColor = true;
            // 
            // adminFamiliesUFUpgradedFamiliesListBox
            // 
            this.adminFamiliesUFUpgradedFamiliesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFUpgradedFamiliesListBox.FormattingEnabled = true;
            this.adminFamiliesUFUpgradedFamiliesListBox.Location = new System.Drawing.Point(0, 65);
            this.adminFamiliesUFUpgradedFamiliesListBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.adminFamiliesUFUpgradedFamiliesListBox.Name = "adminFamiliesUFUpgradedFamiliesListBox";
            this.adminFamiliesUFUpgradedFamiliesListBox.Size = new System.Drawing.Size(352, 244);
            this.adminFamiliesUFUpgradedFamiliesListBox.TabIndex = 1;
            // 
            // adminFamiliesUFDeletedFamiliesListBox
            // 
            this.adminFamiliesUFDeletedFamiliesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFDeletedFamiliesListBox.FormattingEnabled = true;
            this.adminFamiliesUFDeletedFamiliesListBox.Location = new System.Drawing.Point(358, 65);
            this.adminFamiliesUFDeletedFamiliesListBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.adminFamiliesUFDeletedFamiliesListBox.Name = "adminFamiliesUFDeletedFamiliesListBox";
            this.adminFamiliesUFDeletedFamiliesListBox.Size = new System.Drawing.Size(352, 244);
            this.adminFamiliesUFDeletedFamiliesListBox.TabIndex = 2;
            // 
            // adminFamiliesUFUpgradedFamiliesTextBoxPanel
            // 
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Controls.Add(this.adminFamiliesUFUpgradedFamiliesTextBox);
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Location = new System.Drawing.Point(0, 30);
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Name = "adminFamiliesUFUpgradedFamiliesTextBoxPanel";
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.Size = new System.Drawing.Size(352, 35);
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.TabIndex = 3;
            // 
            // adminFamiliesUFUpgradedFamiliesTextBox
            // 
            this.adminFamiliesUFUpgradedFamiliesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesUFUpgradedFamiliesTextBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminFamiliesUFUpgradedFamiliesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adminFamiliesUFUpgradedFamiliesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminFamiliesUFUpgradedFamiliesTextBox.Location = new System.Drawing.Point(-1, 9);
            this.adminFamiliesUFUpgradedFamiliesTextBox.Multiline = true;
            this.adminFamiliesUFUpgradedFamiliesTextBox.Name = "adminFamiliesUFUpgradedFamiliesTextBox";
            this.adminFamiliesUFUpgradedFamiliesTextBox.Size = new System.Drawing.Size(352, 20);
            this.adminFamiliesUFUpgradedFamiliesTextBox.TabIndex = 0;
            this.adminFamiliesUFUpgradedFamiliesTextBox.Text = "FAMILIES UPGRADED";
            this.adminFamiliesUFUpgradedFamiliesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // adminFamiliesUFDeletedFamiliesTextBoxPanel
            // 
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.BackColor = System.Drawing.Color.GreenYellow;
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Controls.Add(this.adminFamiliesUFDeletedFamiliesTextBox);
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Location = new System.Drawing.Point(358, 30);
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Name = "adminFamiliesUFDeletedFamiliesTextBoxPanel";
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.Size = new System.Drawing.Size(352, 35);
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.TabIndex = 4;
            // 
            // adminFamiliesUFDeletedFamiliesTextBox
            // 
            this.adminFamiliesUFDeletedFamiliesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesUFDeletedFamiliesTextBox.BackColor = System.Drawing.Color.GreenYellow;
            this.adminFamiliesUFDeletedFamiliesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adminFamiliesUFDeletedFamiliesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminFamiliesUFDeletedFamiliesTextBox.Location = new System.Drawing.Point(0, 10);
            this.adminFamiliesUFDeletedFamiliesTextBox.Multiline = true;
            this.adminFamiliesUFDeletedFamiliesTextBox.Name = "adminFamiliesUFDeletedFamiliesTextBox";
            this.adminFamiliesUFDeletedFamiliesTextBox.Size = new System.Drawing.Size(351, 22);
            this.adminFamiliesUFDeletedFamiliesTextBox.TabIndex = 0;
            this.adminFamiliesUFDeletedFamiliesTextBox.Text = "FAMILIES DELETED";
            this.adminFamiliesUFDeletedFamiliesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // adminFamiliesUFRunPanel
            // 
            this.adminFamiliesUFLayoutPanel.SetColumnSpan(this.adminFamiliesUFRunPanel, 2);
            this.adminFamiliesUFRunPanel.Controls.Add(this.adminFamiliesUFRunButton);
            this.adminFamiliesUFRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesUFRunPanel.Location = new System.Drawing.Point(0, 309);
            this.adminFamiliesUFRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesUFRunPanel.Name = "adminFamiliesUFRunPanel";
            this.adminFamiliesUFRunPanel.Size = new System.Drawing.Size(710, 30);
            this.adminFamiliesUFRunPanel.TabIndex = 5;
            // 
            // adminFamiliesUFRunButton
            // 
            this.adminFamiliesUFRunButton.Location = new System.Drawing.Point(3, 4);
            this.adminFamiliesUFRunButton.Name = "adminFamiliesUFRunButton";
            this.adminFamiliesUFRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesUFRunButton.TabIndex = 0;
            this.adminFamiliesUFRunButton.Text = "RUN";
            this.adminFamiliesUFRunButton.UseVisualStyleBackColor = true;
            this.adminFamiliesUFRunButton.Click += new System.EventHandler(this.AdminFamiliesUFRunButton_Click);
            // 
            // adminFamiliesBRPLayoutPanel
            // 
            this.adminFamiliesBRPLayoutPanel.ColumnCount = 2;
            this.adminFamiliesBRPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBRPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.adminFamiliesBRPLayoutPanel.Controls.Add(this.adminFamiliesBRPRunPanel, 0, 2);
            this.adminFamiliesBRPLayoutPanel.Controls.Add(this.adminFamiliesBRPSplitPanel, 0, 1);
            this.adminFamiliesBRPLayoutPanel.Controls.Add(this.adminFamiliesBRPCsvDirectoryPanel, 0, 0);
            this.adminFamiliesBRPLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPLayoutPanel.Name = "adminFamiliesBRPLayoutPanel";
            this.adminFamiliesBRPLayoutPanel.RowCount = 3;
            this.adminFamiliesBRPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBRPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBRPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBRPLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminFamiliesBRPLayoutPanel.TabIndex = 3;
            this.adminFamiliesBRPLayoutPanel.Visible = false;
            // 
            // adminFamiliesBRPRunPanel
            // 
            this.adminFamiliesBRPLayoutPanel.SetColumnSpan(this.adminFamiliesBRPRunPanel, 2);
            this.adminFamiliesBRPRunPanel.Controls.Add(this.adminFamiliesBRPProgressBar);
            this.adminFamiliesBRPRunPanel.Controls.Add(this.adminFamiliesBRPRunButton);
            this.adminFamiliesBRPRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPRunPanel.Location = new System.Drawing.Point(0, 304);
            this.adminFamiliesBRPRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPRunPanel.Name = "adminFamiliesBRPRunPanel";
            this.adminFamiliesBRPRunPanel.Size = new System.Drawing.Size(710, 35);
            this.adminFamiliesBRPRunPanel.TabIndex = 5;
            // 
            // adminFamiliesBRPProgressBar
            // 
            this.adminFamiliesBRPProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesBRPProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.adminFamiliesBRPProgressBar.Location = new System.Drawing.Point(7, 6);
            this.adminFamiliesBRPProgressBar.Name = "adminFamiliesBRPProgressBar";
            this.adminFamiliesBRPProgressBar.Size = new System.Drawing.Size(619, 23);
            this.adminFamiliesBRPProgressBar.TabIndex = 1;
            this.adminFamiliesBRPProgressBar.Visible = false;
            // 
            // adminFamiliesBRPRunButton
            // 
            this.adminFamiliesBRPRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesBRPRunButton.Location = new System.Drawing.Point(633, 6);
            this.adminFamiliesBRPRunButton.Name = "adminFamiliesBRPRunButton";
            this.adminFamiliesBRPRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBRPRunButton.TabIndex = 0;
            this.adminFamiliesBRPRunButton.Text = "RUN";
            this.adminFamiliesBRPRunButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBRPRunButton.Click += new System.EventHandler(this.AdminFamiliesBRPRunButton_Click);
            // 
            // adminFamiliesBRPSplitPanel
            // 
            this.adminFamiliesBRPLayoutPanel.SetColumnSpan(this.adminFamiliesBRPSplitPanel, 2);
            this.adminFamiliesBRPSplitPanel.Controls.Add(this.adminFamiliesBRPSplitContainer);
            this.adminFamiliesBRPSplitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPSplitPanel.Location = new System.Drawing.Point(3, 38);
            this.adminFamiliesBRPSplitPanel.Name = "adminFamiliesBRPSplitPanel";
            this.adminFamiliesBRPSplitPanel.Size = new System.Drawing.Size(704, 263);
            this.adminFamiliesBRPSplitPanel.TabIndex = 6;
            // 
            // adminFamiliesBRPSplitContainer
            // 
            this.adminFamiliesBRPSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPSplitContainer.Name = "adminFamiliesBRPSplitContainer";
            // 
            // adminFamiliesBRPSplitContainer.Panel1
            // 
            this.adminFamiliesBRPSplitContainer.Panel1.Controls.Add(this.adminFamiliesBRPParametersLayoutPanel);
            // 
            // adminFamiliesBRPSplitContainer.Panel2
            // 
            this.adminFamiliesBRPSplitContainer.Panel2.Controls.Add(this.adminFamiliesBPRSFamiliesLayoutPanel);
            this.adminFamiliesBRPSplitContainer.Size = new System.Drawing.Size(704, 263);
            this.adminFamiliesBRPSplitContainer.SplitterDistance = 336;
            this.adminFamiliesBRPSplitContainer.TabIndex = 0;
            // 
            // adminFamiliesBRPParametersLayoutPanel
            // 
            this.adminFamiliesBRPParametersLayoutPanel.ColumnCount = 1;
            this.adminFamiliesBRPParametersLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBRPParametersLayoutPanel.Controls.Add(this.adminFamiliesBRPParametersDGV, 0, 1);
            this.adminFamiliesBRPParametersLayoutPanel.Controls.Add(this.adminFamiliesBRPParametersPanel, 0, 0);
            this.adminFamiliesBRPParametersLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPParametersLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPParametersLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPParametersLayoutPanel.Name = "adminFamiliesBRPParametersLayoutPanel";
            this.adminFamiliesBRPParametersLayoutPanel.RowCount = 2;
            this.adminFamiliesBRPParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBRPParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBRPParametersLayoutPanel.Size = new System.Drawing.Size(336, 263);
            this.adminFamiliesBRPParametersLayoutPanel.TabIndex = 4;
            // 
            // adminFamiliesBRPParametersDGV
            // 
            this.adminFamiliesBRPParametersDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesBRPParametersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminFamiliesBRPParametersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPParametersDGV.Location = new System.Drawing.Point(0, 35);
            this.adminFamiliesBRPParametersDGV.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPParametersDGV.Name = "adminFamiliesBRPParametersDGV";
            this.adminFamiliesBRPParametersDGV.RowHeadersWidth = 15;
            this.adminFamiliesBRPParametersDGV.Size = new System.Drawing.Size(336, 228);
            this.adminFamiliesBRPParametersDGV.TabIndex = 0;
            this.adminFamiliesBRPParametersDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AdminFamiliesBRPParametersDGV_CellMouseUp);
            // 
            // adminFamiliesBRPParametersPanel
            // 
            this.adminFamiliesBRPParametersPanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.adminFamiliesBRPParametersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBRPParametersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPParametersPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPParametersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPParametersPanel.Name = "adminFamiliesBRPParametersPanel";
            this.adminFamiliesBRPParametersPanel.Size = new System.Drawing.Size(336, 35);
            this.adminFamiliesBRPParametersPanel.TabIndex = 3;
            // 
            // adminFamiliesBPRSFamiliesLayoutPanel
            // 
            this.adminFamiliesBPRSFamiliesLayoutPanel.ColumnCount = 1;
            this.adminFamiliesBPRSFamiliesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBPRSFamiliesLayoutPanel.Controls.Add(this.adminFamiliesBRPFamiliesDGV, 0, 1);
            this.adminFamiliesBPRSFamiliesLayoutPanel.Controls.Add(this.adminFamiliesBRPSelectPanel, 0, 0);
            this.adminFamiliesBPRSFamiliesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBPRSFamiliesLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBPRSFamiliesLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBPRSFamiliesLayoutPanel.Name = "adminFamiliesBPRSFamiliesLayoutPanel";
            this.adminFamiliesBPRSFamiliesLayoutPanel.RowCount = 2;
            this.adminFamiliesBPRSFamiliesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesBPRSFamiliesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesBPRSFamiliesLayoutPanel.Size = new System.Drawing.Size(364, 263);
            this.adminFamiliesBPRSFamiliesLayoutPanel.TabIndex = 4;
            // 
            // adminFamiliesBRPFamiliesDGV
            // 
            this.adminFamiliesBRPFamiliesDGV.AllowUserToAddRows = false;
            this.adminFamiliesBRPFamiliesDGV.AllowUserToDeleteRows = false;
            this.adminFamiliesBRPFamiliesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesBRPFamiliesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminFamiliesBRPFamiliesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPFamiliesDGV.Location = new System.Drawing.Point(0, 35);
            this.adminFamiliesBRPFamiliesDGV.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPFamiliesDGV.Name = "adminFamiliesBRPFamiliesDGV";
            this.adminFamiliesBRPFamiliesDGV.RowHeadersVisible = false;
            this.adminFamiliesBRPFamiliesDGV.Size = new System.Drawing.Size(364, 228);
            this.adminFamiliesBRPFamiliesDGV.TabIndex = 1;
            this.adminFamiliesBRPFamiliesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdminFamiliesBRPFamiliesDGV_CellContentClick);
            // 
            // adminFamiliesBRPSelectPanel
            // 
            this.adminFamiliesBRPSelectPanel.BackColor = System.Drawing.Color.YellowGreen;
            this.adminFamiliesBRPSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBRPSelectPanel.Controls.Add(this.adminFamiliesBRPSelectNoneButton);
            this.adminFamiliesBRPSelectPanel.Controls.Add(this.adminFamiliesBRPSelectAllButton);
            this.adminFamiliesBRPSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPSelectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPSelectPanel.Name = "adminFamiliesBRPSelectPanel";
            this.adminFamiliesBRPSelectPanel.Size = new System.Drawing.Size(364, 35);
            this.adminFamiliesBRPSelectPanel.TabIndex = 4;
            // 
            // adminFamiliesBRPSelectNoneButton
            // 
            this.adminFamiliesBRPSelectNoneButton.Location = new System.Drawing.Point(84, 3);
            this.adminFamiliesBRPSelectNoneButton.Name = "adminFamiliesBRPSelectNoneButton";
            this.adminFamiliesBRPSelectNoneButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBRPSelectNoneButton.TabIndex = 0;
            this.adminFamiliesBRPSelectNoneButton.Text = "Select None";
            this.adminFamiliesBRPSelectNoneButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBRPSelectNoneButton.Click += new System.EventHandler(this.AdminFamiliesBRPSelectNoneButton_Click);
            // 
            // adminFamiliesBRPSelectAllButton
            // 
            this.adminFamiliesBRPSelectAllButton.Location = new System.Drawing.Point(3, 3);
            this.adminFamiliesBRPSelectAllButton.Name = "adminFamiliesBRPSelectAllButton";
            this.adminFamiliesBRPSelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesBRPSelectAllButton.TabIndex = 0;
            this.adminFamiliesBRPSelectAllButton.Text = "Select All";
            this.adminFamiliesBRPSelectAllButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBRPSelectAllButton.Click += new System.EventHandler(this.AdminFamiliesBRPSelectAllButton_Click);
            // 
            // adminFamiliesBRPCsvDirectoryPanel
            // 
            this.adminFamiliesBRPCsvDirectoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesBRPLayoutPanel.SetColumnSpan(this.adminFamiliesBRPCsvDirectoryPanel, 2);
            this.adminFamiliesBRPCsvDirectoryPanel.Controls.Add(this.adminFamiliesBRPDirectorySelectButton);
            this.adminFamiliesBRPCsvDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesBRPCsvDirectoryPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesBRPCsvDirectoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesBRPCsvDirectoryPanel.Name = "adminFamiliesBRPCsvDirectoryPanel";
            this.adminFamiliesBRPCsvDirectoryPanel.Size = new System.Drawing.Size(710, 35);
            this.adminFamiliesBRPCsvDirectoryPanel.TabIndex = 7;
            // 
            // adminFamiliesBRPDirectorySelectButton
            // 
            this.adminFamiliesBRPDirectorySelectButton.Location = new System.Drawing.Point(3, 6);
            this.adminFamiliesBRPDirectorySelectButton.Name = "adminFamiliesBRPDirectorySelectButton";
            this.adminFamiliesBRPDirectorySelectButton.Size = new System.Drawing.Size(124, 23);
            this.adminFamiliesBRPDirectorySelectButton.TabIndex = 0;
            this.adminFamiliesBRPDirectorySelectButton.Text = "Select Directory";
            this.adminFamiliesBRPDirectorySelectButton.UseVisualStyleBackColor = true;
            this.adminFamiliesBRPDirectorySelectButton.Click += new System.EventHandler(this.AdminFamiliesBRPDirectorySelectButton_Click);
            // 
            // adminFamiliesDFBLayoutPanel
            // 
            this.adminFamiliesDFBLayoutPanel.ColumnCount = 1;
            this.adminFamiliesDFBLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesDFBLayoutPanel.Controls.Add(this.adminFamiliesDFBSelectPanel, 0, 0);
            this.adminFamiliesDFBLayoutPanel.Controls.Add(this.adminFamiliesDFBFamiliesDGV, 0, 1);
            this.adminFamiliesDFBLayoutPanel.Controls.Add(this.panel1, 0, 2);
            this.adminFamiliesDFBLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesDFBLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesDFBLayoutPanel.Name = "adminFamiliesDFBLayoutPanel";
            this.adminFamiliesDFBLayoutPanel.RowCount = 3;
            this.adminFamiliesDFBLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesDFBLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminFamiliesDFBLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminFamiliesDFBLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.adminFamiliesDFBLayoutPanel.TabIndex = 5;
            this.adminFamiliesDFBLayoutPanel.Visible = false;
            // 
            // adminFamiliesDFBSelectPanel
            // 
            this.adminFamiliesDFBSelectPanel.BackColor = System.Drawing.SystemColors.Control;
            this.adminFamiliesDFBSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminFamiliesDFBSelectPanel.Controls.Add(this.adminFamiliesDBFSelectNoneButton);
            this.adminFamiliesDFBSelectPanel.Controls.Add(this.adminFamiliesDBFSelectAllButton);
            this.adminFamiliesDFBSelectPanel.Controls.Add(this.adminFamiliesDFBSelectDirectoryButton);
            this.adminFamiliesDFBSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesDFBSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.adminFamiliesDFBSelectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesDFBSelectPanel.Name = "adminFamiliesDFBSelectPanel";
            this.adminFamiliesDFBSelectPanel.Size = new System.Drawing.Size(710, 35);
            this.adminFamiliesDFBSelectPanel.TabIndex = 0;
            // 
            // adminFamiliesDBFSelectNoneButton
            // 
            this.adminFamiliesDBFSelectNoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesDBFSelectNoneButton.BackColor = System.Drawing.SystemColors.Control;
            this.adminFamiliesDBFSelectNoneButton.Location = new System.Drawing.Point(628, 4);
            this.adminFamiliesDBFSelectNoneButton.Name = "adminFamiliesDBFSelectNoneButton";
            this.adminFamiliesDBFSelectNoneButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesDBFSelectNoneButton.TabIndex = 1;
            this.adminFamiliesDBFSelectNoneButton.Text = "Select None";
            this.adminFamiliesDBFSelectNoneButton.UseVisualStyleBackColor = false;
            this.adminFamiliesDBFSelectNoneButton.Click += new System.EventHandler(this.AdminFamiliesDBFSelectNoneButton_Click);
            // 
            // adminFamiliesDBFSelectAllButton
            // 
            this.adminFamiliesDBFSelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesDBFSelectAllButton.BackColor = System.Drawing.SystemColors.Control;
            this.adminFamiliesDBFSelectAllButton.Location = new System.Drawing.Point(544, 4);
            this.adminFamiliesDBFSelectAllButton.Name = "adminFamiliesDBFSelectAllButton";
            this.adminFamiliesDBFSelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesDBFSelectAllButton.TabIndex = 1;
            this.adminFamiliesDBFSelectAllButton.Text = "Select All";
            this.adminFamiliesDBFSelectAllButton.UseVisualStyleBackColor = false;
            this.adminFamiliesDBFSelectAllButton.Click += new System.EventHandler(this.AdminFamiliesDBFSelectAllButton_Click);
            // 
            // adminFamiliesDFBSelectDirectoryButton
            // 
            this.adminFamiliesDFBSelectDirectoryButton.Location = new System.Drawing.Point(5, 4);
            this.adminFamiliesDFBSelectDirectoryButton.Name = "adminFamiliesDFBSelectDirectoryButton";
            this.adminFamiliesDFBSelectDirectoryButton.Size = new System.Drawing.Size(124, 23);
            this.adminFamiliesDFBSelectDirectoryButton.TabIndex = 0;
            this.adminFamiliesDFBSelectDirectoryButton.Text = "Select Directory";
            this.adminFamiliesDFBSelectDirectoryButton.UseVisualStyleBackColor = true;
            this.adminFamiliesDFBSelectDirectoryButton.Click += new System.EventHandler(this.AdminFamiliesDFBSelectDirectoryButton_Click);
            // 
            // adminFamiliesDFBFamiliesDGV
            // 
            this.adminFamiliesDFBFamiliesDGV.AllowUserToAddRows = false;
            this.adminFamiliesDFBFamiliesDGV.AllowUserToDeleteRows = false;
            this.adminFamiliesDFBFamiliesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminFamiliesDFBFamiliesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminFamiliesDFBFamiliesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminFamiliesDFBFamiliesDGV.Location = new System.Drawing.Point(0, 35);
            this.adminFamiliesDFBFamiliesDGV.Margin = new System.Windows.Forms.Padding(0);
            this.adminFamiliesDFBFamiliesDGV.Name = "adminFamiliesDFBFamiliesDGV";
            this.adminFamiliesDFBFamiliesDGV.RowHeadersVisible = false;
            this.adminFamiliesDFBFamiliesDGV.Size = new System.Drawing.Size(710, 269);
            this.adminFamiliesDFBFamiliesDGV.TabIndex = 1;
            this.adminFamiliesDFBFamiliesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdminFamiliesDFBFamiliesDGV_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.adminFamiliesDFBRunButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 35);
            this.panel1.TabIndex = 2;
            // 
            // adminFamiliesDFBRunButton
            // 
            this.adminFamiliesDFBRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adminFamiliesDFBRunButton.Location = new System.Drawing.Point(633, 6);
            this.adminFamiliesDFBRunButton.Name = "adminFamiliesDFBRunButton";
            this.adminFamiliesDFBRunButton.Size = new System.Drawing.Size(75, 23);
            this.adminFamiliesDFBRunButton.TabIndex = 1;
            this.adminFamiliesDFBRunButton.Text = "RUN";
            this.adminFamiliesDFBRunButton.UseVisualStyleBackColor = true;
            this.adminFamiliesDFBRunButton.Click += new System.EventHandler(this.AdminFamiliesDFBRunButton_Click);
            // 
            // adminTemplateTab
            // 
            this.adminTemplateTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.adminTemplateTab.Controls.Add(this.adminTemplateLayoutPanel);
            this.adminTemplateTab.Location = new System.Drawing.Point(4, 25);
            this.adminTemplateTab.Margin = new System.Windows.Forms.Padding(0);
            this.adminTemplateTab.Name = "adminTemplateTab";
            this.adminTemplateTab.Size = new System.Drawing.Size(720, 402);
            this.adminTemplateTab.TabIndex = 2;
            this.adminTemplateTab.Text = "Templates";
            // 
            // adminTemplateLayoutPanel
            // 
            this.adminTemplateLayoutPanel.ColumnCount = 1;
            this.adminTemplateLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminTemplateLayoutPanel.Controls.Add(this.adminTemplateToolStrip, 0, 0);
            this.adminTemplateLayoutPanel.Controls.Add(this.adminTemplateToolsPanel, 0, 1);
            this.adminTemplateLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplateLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adminTemplateLayoutPanel.Name = "adminTemplateLayoutPanel";
            this.adminTemplateLayoutPanel.RowCount = 2;
            this.adminTemplateLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.adminTemplateLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminTemplateLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.adminTemplateLayoutPanel.TabIndex = 0;
            // 
            // adminTemplateToolStrip
            // 
            this.adminTemplateToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplateToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.adminTemplateToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.adminTemplateToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminTemplatePMButton});
            this.adminTemplateToolStrip.Location = new System.Drawing.Point(0, 0);
            this.adminTemplateToolStrip.Name = "adminTemplateToolStrip";
            this.adminTemplateToolStrip.Size = new System.Drawing.Size(716, 53);
            this.adminTemplateToolStrip.TabIndex = 0;
            this.adminTemplateToolStrip.Text = "toolStrip1";
            // 
            // adminTemplatePMButton
            // 
            this.adminTemplatePMButton.Image = ((System.Drawing.Image)(resources.GetObject("adminTemplatePMButton.Image")));
            this.adminTemplatePMButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminTemplatePMButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminTemplatePMButton.Name = "adminTemplatePMButton";
            this.adminTemplatePMButton.Size = new System.Drawing.Size(105, 50);
            this.adminTemplatePMButton.Text = "Package Manager";
            this.adminTemplatePMButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.adminTemplatePMButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.adminTemplatePMButton.ToolTipText = "Package Manager: Manages packages of families and details to load into a project";
            this.adminTemplatePMButton.Click += new System.EventHandler(this.AdminTemplatePMButton_Click);
            // 
            // adminTemplateToolsPanel
            // 
            this.adminTemplateToolsPanel.Controls.Add(this.adminTemplatePMLayoutPanel);
            this.adminTemplateToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplateToolsPanel.Location = new System.Drawing.Point(3, 56);
            this.adminTemplateToolsPanel.Name = "adminTemplateToolsPanel";
            this.adminTemplateToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.adminTemplateToolsPanel.TabIndex = 1;
            // 
            // adminTemplatePMLayoutPanel
            // 
            this.adminTemplatePMLayoutPanel.ColumnCount = 1;
            this.adminTemplatePMLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminTemplatePMLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.adminTemplatePMLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.adminTemplatePMLayoutPanel.Controls.Add(this.adminTemplatePMPickPackagePanel, 0, 0);
            this.adminTemplatePMLayoutPanel.Controls.Add(this.adminTemplateSavePackagePanel, 0, 2);
            this.adminTemplatePMLayoutPanel.Controls.Add(this.adminTemplatePMTreeView, 0, 1);
            this.adminTemplatePMLayoutPanel.Location = new System.Drawing.Point(3, 0);
            this.adminTemplatePMLayoutPanel.Name = "adminTemplatePMLayoutPanel";
            this.adminTemplatePMLayoutPanel.RowCount = 3;
            this.adminTemplatePMLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminTemplatePMLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adminTemplatePMLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.adminTemplatePMLayoutPanel.Size = new System.Drawing.Size(708, 338);
            this.adminTemplatePMLayoutPanel.TabIndex = 1;
            // 
            // adminTemplatePMPickPackagePanel
            // 
            this.adminTemplatePMPickPackagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminTemplatePMPickPackagePanel.Controls.Add(this.adminTemplatePMDeletePackateButton);
            this.adminTemplatePMPickPackagePanel.Controls.Add(this.adminTemplatePMPickPackageLabel);
            this.adminTemplatePMPickPackagePanel.Controls.Add(this.adminTemplatePMPickPackageComboBox);
            this.adminTemplatePMPickPackagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplatePMPickPackagePanel.Location = new System.Drawing.Point(0, 0);
            this.adminTemplatePMPickPackagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminTemplatePMPickPackagePanel.Name = "adminTemplatePMPickPackagePanel";
            this.adminTemplatePMPickPackagePanel.Size = new System.Drawing.Size(708, 35);
            this.adminTemplatePMPickPackagePanel.TabIndex = 2;
            // 
            // adminTemplatePMDeletePackateButton
            // 
            this.adminTemplatePMDeletePackateButton.Location = new System.Drawing.Point(331, 6);
            this.adminTemplatePMDeletePackateButton.Name = "adminTemplatePMDeletePackateButton";
            this.adminTemplatePMDeletePackateButton.Size = new System.Drawing.Size(111, 23);
            this.adminTemplatePMDeletePackateButton.TabIndex = 2;
            this.adminTemplatePMDeletePackateButton.Text = "DELETE PACKAGE";
            this.adminTemplatePMDeletePackateButton.UseVisualStyleBackColor = true;
            // 
            // adminTemplatePMPickPackageLabel
            // 
            this.adminTemplatePMPickPackageLabel.AutoSize = true;
            this.adminTemplatePMPickPackageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTemplatePMPickPackageLabel.Location = new System.Drawing.Point(3, 11);
            this.adminTemplatePMPickPackageLabel.Name = "adminTemplatePMPickPackageLabel";
            this.adminTemplatePMPickPackageLabel.Size = new System.Drawing.Size(143, 13);
            this.adminTemplatePMPickPackageLabel.TabIndex = 0;
            this.adminTemplatePMPickPackageLabel.Text = "Package To Reference:";
            // 
            // adminTemplatePMPickPackageComboBox
            // 
            this.adminTemplatePMPickPackageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminTemplatePMPickPackageComboBox.FormattingEnabled = true;
            this.adminTemplatePMPickPackageComboBox.Location = new System.Drawing.Point(152, 8);
            this.adminTemplatePMPickPackageComboBox.Name = "adminTemplatePMPickPackageComboBox";
            this.adminTemplatePMPickPackageComboBox.Size = new System.Drawing.Size(171, 21);
            this.adminTemplatePMPickPackageComboBox.TabIndex = 1;
            this.adminTemplatePMPickPackageComboBox.SelectedIndexChanged += new System.EventHandler(this.AdminTemplatePMPickPackageComboBox_SelectedIndexChanged);
            // 
            // adminTemplateSavePackagePanel
            // 
            this.adminTemplateSavePackagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminTemplateSavePackagePanel.Controls.Add(this.adminTemplateSavePackagePublishButton);
            this.adminTemplateSavePackagePanel.Controls.Add(this.adminTemplateSavePackageComboBox);
            this.adminTemplateSavePackagePanel.Controls.Add(this.adminTemplateSavePackageLabel);
            this.adminTemplateSavePackagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplateSavePackagePanel.Location = new System.Drawing.Point(0, 303);
            this.adminTemplateSavePackagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.adminTemplateSavePackagePanel.Name = "adminTemplateSavePackagePanel";
            this.adminTemplateSavePackagePanel.Size = new System.Drawing.Size(708, 35);
            this.adminTemplateSavePackagePanel.TabIndex = 3;
            // 
            // adminTemplateSavePackagePublishButton
            // 
            this.adminTemplateSavePackagePublishButton.Location = new System.Drawing.Point(331, 6);
            this.adminTemplateSavePackagePublishButton.Name = "adminTemplateSavePackagePublishButton";
            this.adminTemplateSavePackagePublishButton.Size = new System.Drawing.Size(75, 23);
            this.adminTemplateSavePackagePublishButton.TabIndex = 4;
            this.adminTemplateSavePackagePublishButton.Text = "PUBLISH";
            this.adminTemplateSavePackagePublishButton.UseVisualStyleBackColor = true;
            // 
            // adminTemplateSavePackageComboBox
            // 
            this.adminTemplateSavePackageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminTemplateSavePackageComboBox.FormattingEnabled = true;
            this.adminTemplateSavePackageComboBox.Location = new System.Drawing.Point(142, 8);
            this.adminTemplateSavePackageComboBox.Name = "adminTemplateSavePackageComboBox";
            this.adminTemplateSavePackageComboBox.Size = new System.Drawing.Size(181, 21);
            this.adminTemplateSavePackageComboBox.TabIndex = 3;
            // 
            // adminTemplateSavePackageLabel
            // 
            this.adminTemplateSavePackageLabel.AutoSize = true;
            this.adminTemplateSavePackageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTemplateSavePackageLabel.Location = new System.Drawing.Point(4, 11);
            this.adminTemplateSavePackageLabel.Name = "adminTemplateSavePackageLabel";
            this.adminTemplateSavePackageLabel.Size = new System.Drawing.Size(132, 13);
            this.adminTemplateSavePackageLabel.TabIndex = 2;
            this.adminTemplateSavePackageLabel.Text = "Package To Save To:";
            // 
            // adminTemplatePMTreeView
            // 
            this.adminTemplatePMTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTemplatePMTreeView.Location = new System.Drawing.Point(3, 38);
            this.adminTemplatePMTreeView.Name = "adminTemplatePMTreeView";
            this.adminTemplatePMTreeView.Size = new System.Drawing.Size(702, 262);
            this.adminTemplatePMTreeView.TabIndex = 4;
            // 
            // sandBoxTab
            // 
            this.sandBoxTab.Controls.Add(this.sandBoxLayoutPanel);
            this.sandBoxTab.Location = new System.Drawing.Point(4, 25);
            this.sandBoxTab.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.sandBoxTab.Name = "sandBoxTab";
            this.sandBoxTab.Size = new System.Drawing.Size(720, 402);
            this.sandBoxTab.TabIndex = 4;
            this.sandBoxTab.Text = "DevSandBox";
            this.sandBoxTab.UseVisualStyleBackColor = true;
            // 
            // sandBoxLayoutPanel
            // 
            this.sandBoxLayoutPanel.ColumnCount = 1;
            this.sandBoxLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sandBoxLayoutPanel.Controls.Add(this.sandBoxElementHost, 0, 1);
            this.sandBoxLayoutPanel.Controls.Add(this.sandBoxToolStrip, 0, 0);
            this.sandBoxLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sandBoxLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sandBoxLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sandBoxLayoutPanel.Name = "sandBoxLayoutPanel";
            this.sandBoxLayoutPanel.RowCount = 2;
            this.sandBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.sandBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sandBoxLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.sandBoxLayoutPanel.Size = new System.Drawing.Size(720, 402);
            this.sandBoxLayoutPanel.TabIndex = 0;
            // 
            // sandBoxElementHost
            // 
            this.sandBoxElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sandBoxElementHost.Location = new System.Drawing.Point(2, 54);
            this.sandBoxElementHost.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.sandBoxElementHost.Name = "sandBoxElementHost";
            this.sandBoxElementHost.Size = new System.Drawing.Size(716, 347);
            this.sandBoxElementHost.TabIndex = 0;
            this.sandBoxElementHost.Text = "elementHost1";
            this.sandBoxElementHost.Child = null;
            // 
            // sandBoxToolStrip
            // 
            this.sandBoxToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sandBoxToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sandBoxToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sandBoxToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sandBoxTestButton1});
            this.sandBoxToolStrip.Location = new System.Drawing.Point(0, 0);
            this.sandBoxToolStrip.Name = "sandBoxToolStrip";
            this.sandBoxToolStrip.Size = new System.Drawing.Size(720, 53);
            this.sandBoxToolStrip.TabIndex = 1;
            this.sandBoxToolStrip.Text = "toolStrip1";
            // 
            // sandBoxTestButton1
            // 
            this.sandBoxTestButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sandBoxTestButton1.Image = ((System.Drawing.Image)(resources.GetObject("sandBoxTestButton1.Image")));
            this.sandBoxTestButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sandBoxTestButton1.Name = "sandBoxTestButton1";
            this.sandBoxTestButton1.Size = new System.Drawing.Size(37, 50);
            this.sandBoxTestButton1.Text = "TEST";
            this.sandBoxTestButton1.Click += new System.EventHandler(this.SandBoxTestButton1_Click);
            // 
            // roomsToolStrip
            // 
            roomsToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            roomsToolStrip.AutoSize = false;
            roomsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            roomsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            roomsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            roomsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsSRNNButton,
            this.roomsSeparator1,
            this.roomsCDRTButton});
            roomsToolStrip.Location = new System.Drawing.Point(0, 0);
            roomsToolStrip.Name = "roomsToolStrip";
            roomsToolStrip.Size = new System.Drawing.Size(716, 53);
            roomsToolStrip.Stretch = true;
            roomsToolStrip.TabIndex = 0;
            roomsToolStrip.Text = "toolStrip1";
            // 
            // roomsSRNNButton
            // 
            this.roomsSRNNButton.Image = ((System.Drawing.Image)(resources.GetObject("roomsSRNNButton.Image")));
            this.roomsSRNNButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.roomsSRNNButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roomsSRNNButton.Name = "roomsSRNNButton";
            this.roomsSRNNButton.Size = new System.Drawing.Size(123, 50);
            this.roomsSRNNButton.Text = "Swap Name/Number";
            this.roomsSRNNButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.roomsSRNNButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roomsSRNNButton.ToolTipText = "Swap Room Name  Number: Swap the room name and number for ease of export in Blueb" +
    "eam";
            this.roomsSRNNButton.Click += new System.EventHandler(this.RoomsSRNNButton_Click);
            // 
            // roomsSeparator1
            // 
            this.roomsSeparator1.Name = "roomsSeparator1";
            this.roomsSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // roomsCDRTButton
            // 
            this.roomsCDRTButton.Image = ((System.Drawing.Image)(resources.GetObject("roomsCDRTButton.Image")));
            this.roomsCDRTButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.roomsCDRTButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roomsCDRTButton.Name = "roomsCDRTButton";
            this.roomsCDRTButton.Size = new System.Drawing.Size(142, 50);
            this.roomsCDRTButton.Text = "Create Demo Room Tags";
            this.roomsCDRTButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.roomsCDRTButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roomsCDRTButton.ToolTipText = "Create Demo Room Tags: Places room tag symbols where rooms exist in a previous ph" +
    "ase, but do not exist in the current phase. This is intended for Demo Plans";
            this.roomsCDRTButton.Click += new System.EventHandler(this.RoomsCDRTButton_Click);
            // 
            // mgmtSetupCWSUserContextMenu
            // 
            this.mgmtSetupCWSUserContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mgmtSetupCWSUserContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupCWSRowDeleteTool});
            this.mgmtSetupCWSUserContextMenu.Name = "mgmtSetupCWSUserContextMenu";
            this.mgmtSetupCWSUserContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // setupCWSRowDeleteTool
            // 
            this.setupCWSRowDeleteTool.Name = "setupCWSRowDeleteTool";
            this.setupCWSRowDeleteTool.Size = new System.Drawing.Size(107, 22);
            this.setupCWSRowDeleteTool.Text = "Delete";
            this.setupCWSRowDeleteTool.Click += new System.EventHandler(this.SetupCWSRowDeleteTool_Click);
            // 
            // UIFormTableLayoutPanel
            // 
            this.UIFormTableLayoutPanel.ColumnCount = 1;
            this.UIFormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UIFormTableLayoutPanel.Controls.Add(this.mainTabControl, 0, 1);
            this.UIFormTableLayoutPanel.Controls.Add(this.UIFormMenuStrip, 0, 0);
            this.UIFormTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UIFormTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.UIFormTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UIFormTableLayoutPanel.Name = "UIFormTableLayoutPanel";
            this.UIFormTableLayoutPanel.RowCount = 2;
            this.UIFormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.UIFormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UIFormTableLayoutPanel.Size = new System.Drawing.Size(769, 451);
            this.UIFormTableLayoutPanel.TabIndex = 2;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainTabControl.Controls.Add(this.aboutTab);
            this.mainTabControl.Controls.Add(this.analysisTab);
            this.mainTabControl.Controls.Add(this.modelingTab);
            this.mainTabControl.Controls.Add(this.documentationTab);
            this.mainTabControl.Controls.Add(this.managementTab);
            this.mainTabControl.Controls.Add(adminTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.ItemSize = new System.Drawing.Size(42, 21);
            this.mainTabControl.Location = new System.Drawing.Point(3, 3);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(763, 445);
            this.mainTabControl.TabIndex = 1;
            this.mainTabControl.Click += new System.EventHandler(this.AllowBIMManagementTab);
            // 
            // aboutTab
            // 
            this.aboutTab.BackColor = System.Drawing.SystemColors.Control;
            this.aboutTab.Controls.Add(this.aboutTabLayoutPanel);
            this.aboutTab.Location = new System.Drawing.Point(25, 4);
            this.aboutTab.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(734, 437);
            this.aboutTab.TabIndex = 4;
            // 
            // aboutTabLayoutPanel
            // 
            this.aboutTabLayoutPanel.ColumnCount = 1;
            this.aboutTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.aboutTabLayoutPanel.Controls.Add(this.aboutTabHeaderPanel, 0, 0);
            this.aboutTabLayoutPanel.Controls.Add(this.aboutTabFooterPanel, 0, 2);
            this.aboutTabLayoutPanel.Controls.Add(this.aboutTabUpdatesTextBox, 0, 1);
            this.aboutTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTabLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.aboutTabLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aboutTabLayoutPanel.Name = "aboutTabLayoutPanel";
            this.aboutTabLayoutPanel.RowCount = 3;
            this.aboutTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.aboutTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.aboutTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.aboutTabLayoutPanel.Size = new System.Drawing.Size(734, 437);
            this.aboutTabLayoutPanel.TabIndex = 6;
            // 
            // aboutTabHeaderPanel
            // 
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabDevelopmentLinkURLLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabDevelopmentLinkLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabLearningLinkURLLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabLearningLinkLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabLogo);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutPublishLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabVersionLabel);
            this.aboutTabHeaderPanel.Controls.Add(this.aboutTabTitleLabel);
            this.aboutTabHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTabHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.aboutTabHeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabHeaderPanel.Name = "aboutTabHeaderPanel";
            this.aboutTabHeaderPanel.Size = new System.Drawing.Size(734, 120);
            this.aboutTabHeaderPanel.TabIndex = 0;
            // 
            // aboutTabDevelopmentLinkURLLabel
            // 
            this.aboutTabDevelopmentLinkURLLabel.AutoSize = true;
            this.aboutTabDevelopmentLinkURLLabel.Location = new System.Drawing.Point(370, 84);
            this.aboutTabDevelopmentLinkURLLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabDevelopmentLinkURLLabel.Name = "aboutTabDevelopmentLinkURLLabel";
            this.aboutTabDevelopmentLinkURLLabel.Size = new System.Drawing.Size(101, 13);
            this.aboutTabDevelopmentLinkURLLabel.TabIndex = 6;
            this.aboutTabDevelopmentLinkURLLabel.TabStop = true;
            this.aboutTabDevelopmentLinkURLLabel.Text = "Development Board\r\n";
            this.aboutTabDevelopmentLinkURLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutTabDevelopmentLinkURLLabel_LinkClicked);
            // 
            // aboutTabDevelopmentLinkLabel
            // 
            this.aboutTabDevelopmentLinkLabel.AutoSize = true;
            this.aboutTabDevelopmentLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutTabDevelopmentLinkLabel.Location = new System.Drawing.Point(130, 84);
            this.aboutTabDevelopmentLinkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabDevelopmentLinkLabel.Name = "aboutTabDevelopmentLinkLabel";
            this.aboutTabDevelopmentLinkLabel.Size = new System.Drawing.Size(231, 13);
            this.aboutTabDevelopmentLinkLabel.TabIndex = 7;
            this.aboutTabDevelopmentLinkLabel.Text = "Track development and make tool suggestions:";
            // 
            // aboutTabLearningLinkURLLabel
            // 
            this.aboutTabLearningLinkURLLabel.AutoSize = true;
            this.aboutTabLearningLinkURLLabel.Location = new System.Drawing.Point(310, 103);
            this.aboutTabLearningLinkURLLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabLearningLinkURLLabel.Name = "aboutTabLearningLinkURLLabel";
            this.aboutTabLearningLinkURLLabel.Size = new System.Drawing.Size(49, 13);
            this.aboutTabLearningLinkURLLabel.TabIndex = 6;
            this.aboutTabLearningLinkURLLabel.TabStop = true;
            this.aboutTabLearningLinkURLLabel.Text = "BIMhaus\r\n";
            this.aboutTabLearningLinkURLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutTabLearningLinkURLLabel_LinkClicked);
            // 
            // aboutTabLearningLinkLabel
            // 
            this.aboutTabLearningLinkLabel.AutoSize = true;
            this.aboutTabLearningLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutTabLearningLinkLabel.Location = new System.Drawing.Point(130, 103);
            this.aboutTabLearningLinkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabLearningLinkLabel.Name = "aboutTabLearningLinkLabel";
            this.aboutTabLearningLinkLabel.Size = new System.Drawing.Size(168, 13);
            this.aboutTabLearningLinkLabel.TabIndex = 7;
            this.aboutTabLearningLinkLabel.Text = "Learn more about the BART tools:";
            // 
            // aboutTabLogo
            // 
            this.aboutTabLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutTabLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aboutTabLogo.Image = ((System.Drawing.Image)(resources.GetObject("aboutTabLogo.Image")));
            this.aboutTabLogo.Location = new System.Drawing.Point(3, 3);
            this.aboutTabLogo.Name = "aboutTabLogo";
            this.aboutTabLogo.Size = new System.Drawing.Size(119, 114);
            this.aboutTabLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aboutTabLogo.TabIndex = 1;
            this.aboutTabLogo.TabStop = false;
            // 
            // aboutPublishLabel
            // 
            this.aboutPublishLabel.AutoSize = true;
            this.aboutPublishLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutPublishLabel.Location = new System.Drawing.Point(130, 60);
            this.aboutPublishLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutPublishLabel.Name = "aboutPublishLabel";
            this.aboutPublishLabel.Size = new System.Drawing.Size(65, 13);
            this.aboutPublishLabel.TabIndex = 5;
            this.aboutPublishLabel.Text = "11/09/2018";
            // 
            // aboutTabVersionLabel
            // 
            this.aboutTabVersionLabel.AutoSize = true;
            this.aboutTabVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutTabVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutTabVersionLabel.Location = new System.Drawing.Point(128, 40);
            this.aboutTabVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabVersionLabel.Name = "aboutTabVersionLabel";
            this.aboutTabVersionLabel.Size = new System.Drawing.Size(102, 20);
            this.aboutTabVersionLabel.TabIndex = 0;
            this.aboutTabVersionLabel.Text = "Version 1.0.3";
            // 
            // aboutTabTitleLabel
            // 
            this.aboutTabTitleLabel.AutoSize = true;
            this.aboutTabTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutTabTitleLabel.Font = new System.Drawing.Font("Calibri", 22F);
            this.aboutTabTitleLabel.Location = new System.Drawing.Point(127, 3);
            this.aboutTabTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabTitleLabel.Name = "aboutTabTitleLabel";
            this.aboutTabTitleLabel.Size = new System.Drawing.Size(277, 37);
            this.aboutTabTitleLabel.TabIndex = 0;
            this.aboutTabTitleLabel.Text = "BA Revit Tools (BART)";
            // 
            // aboutTabFooterPanel
            // 
            this.aboutTabFooterPanel.Controls.Add(this.aboutCreditLabel);
            this.aboutTabFooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTabFooterPanel.Location = new System.Drawing.Point(0, 414);
            this.aboutTabFooterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTabFooterPanel.Name = "aboutTabFooterPanel";
            this.aboutTabFooterPanel.Size = new System.Drawing.Size(734, 23);
            this.aboutTabFooterPanel.TabIndex = 1;
            // 
            // aboutCreditLabel
            // 
            this.aboutCreditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutCreditLabel.AutoSize = true;
            this.aboutCreditLabel.Location = new System.Drawing.Point(2, 6);
            this.aboutCreditLabel.Name = "aboutCreditLabel";
            this.aboutCreditLabel.Size = new System.Drawing.Size(208, 13);
            this.aboutCreditLabel.TabIndex = 4;
            this.aboutCreditLabel.Text = "Created By: Carlo Licea and Lots of Coffee";
            // 
            // aboutTabUpdatesTextBox
            // 
            this.aboutTabUpdatesTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.aboutTabUpdatesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTabUpdatesTextBox.Location = new System.Drawing.Point(2, 121);
            this.aboutTabUpdatesTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.aboutTabUpdatesTextBox.Name = "aboutTabUpdatesTextBox";
            this.aboutTabUpdatesTextBox.ReadOnly = true;
            this.aboutTabUpdatesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.aboutTabUpdatesTextBox.Size = new System.Drawing.Size(730, 292);
            this.aboutTabUpdatesTextBox.TabIndex = 2;
            this.aboutTabUpdatesTextBox.Text = resources.GetString("aboutTabUpdatesTextBox.Text");
            // 
            // analysisTab
            // 
            this.analysisTab.BackColor = System.Drawing.SystemColors.Control;
            this.analysisTab.Controls.Add(this.analysisTabControl);
            this.analysisTab.Location = new System.Drawing.Point(25, 4);
            this.analysisTab.Margin = new System.Windows.Forms.Padding(0);
            this.analysisTab.Name = "analysisTab";
            this.analysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.analysisTab.Size = new System.Drawing.Size(734, 437);
            this.analysisTab.TabIndex = 1;
            this.analysisTab.Text = "Analysis";
            // 
            // analysisTabControl
            // 
            this.analysisTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.analysisTabControl.Controls.Add(this.sightTab);
            this.analysisTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analysisTabControl.Location = new System.Drawing.Point(3, 3);
            this.analysisTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.analysisTabControl.Name = "analysisTabControl";
            this.analysisTabControl.SelectedIndex = 0;
            this.analysisTabControl.Size = new System.Drawing.Size(728, 431);
            this.analysisTabControl.TabIndex = 0;
            // 
            // sightTab
            // 
            this.sightTab.Location = new System.Drawing.Point(4, 25);
            this.sightTab.Name = "sightTab";
            this.sightTab.Padding = new System.Windows.Forms.Padding(3);
            this.sightTab.Size = new System.Drawing.Size(720, 402);
            this.sightTab.TabIndex = 0;
            this.sightTab.Text = "Sight";
            this.sightTab.UseVisualStyleBackColor = true;
            // 
            // modelingTab
            // 
            this.modelingTab.BackColor = System.Drawing.SystemColors.Control;
            this.modelingTab.Controls.Add(this.modelingTabControl);
            this.modelingTab.Location = new System.Drawing.Point(25, 4);
            this.modelingTab.Margin = new System.Windows.Forms.Padding(0);
            this.modelingTab.Name = "modelingTab";
            this.modelingTab.Padding = new System.Windows.Forms.Padding(3);
            this.modelingTab.Size = new System.Drawing.Size(734, 437);
            this.modelingTab.TabIndex = 0;
            this.modelingTab.Text = "Modeling";
            // 
            // modelingTabControl
            // 
            this.modelingTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.modelingTabControl.Controls.Add(this.multiCatTab);
            this.modelingTabControl.Controls.Add(this.doorsTab);
            this.modelingTabControl.Controls.Add(this.electricalTab);
            this.modelingTabControl.Controls.Add(this.floorsTab);
            this.modelingTabControl.Controls.Add(this.massesTab);
            this.modelingTabControl.Controls.Add(this.materialsTab);
            this.modelingTabControl.Controls.Add(this.roomsTab);
            this.modelingTabControl.Controls.Add(this.wallsTab);
            this.modelingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelingTabControl.ItemSize = new System.Drawing.Size(45, 21);
            this.modelingTabControl.Location = new System.Drawing.Point(3, 3);
            this.modelingTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.modelingTabControl.Multiline = true;
            this.modelingTabControl.Name = "modelingTabControl";
            this.modelingTabControl.SelectedIndex = 0;
            this.modelingTabControl.Size = new System.Drawing.Size(728, 431);
            this.modelingTabControl.TabIndex = 0;
            // 
            // multiCatTab
            // 
            this.multiCatTab.Controls.Add(this.multiCatLayoutPanel);
            this.multiCatTab.Location = new System.Drawing.Point(4, 25);
            this.multiCatTab.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatTab.Name = "multiCatTab";
            this.multiCatTab.Size = new System.Drawing.Size(720, 402);
            this.multiCatTab.TabIndex = 9;
            this.multiCatTab.Text = "Multi-category";
            this.multiCatTab.UseVisualStyleBackColor = true;
            // 
            // multiCatLayoutPanel
            // 
            this.multiCatLayoutPanel.ColumnCount = 1;
            this.multiCatLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatLayoutPanel.Controls.Add(this.multiCatToolStrip, 0, 0);
            this.multiCatLayoutPanel.Controls.Add(this.multiCatToolsPanel, 0, 1);
            this.multiCatLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.multiCatLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatLayoutPanel.Name = "multiCatLayoutPanel";
            this.multiCatLayoutPanel.RowCount = 2;
            this.multiCatLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.multiCatLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatLayoutPanel.Size = new System.Drawing.Size(720, 402);
            this.multiCatLayoutPanel.TabIndex = 1;
            // 
            // multiCatToolStrip
            // 
            this.multiCatToolStrip.AutoSize = false;
            this.multiCatToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.multiCatToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.multiCatToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.multiCatToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiCatCFFEButton,
            this.multiCatSeparator1,
            this.multiCatRE});
            this.multiCatToolStrip.Location = new System.Drawing.Point(0, 0);
            this.multiCatToolStrip.Name = "multiCatToolStrip";
            this.multiCatToolStrip.Size = new System.Drawing.Size(720, 53);
            this.multiCatToolStrip.TabIndex = 0;
            this.multiCatToolStrip.Text = "toolStrip1";
            // 
            // multiCatCFFEButton
            // 
            this.multiCatCFFEButton.Image = ((System.Drawing.Image)(resources.GetObject("multiCatCFFEButton.Image")));
            this.multiCatCFFEButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.multiCatCFFEButton.Name = "multiCatCFFEButton";
            this.multiCatCFFEButton.Size = new System.Drawing.Size(151, 50);
            this.multiCatCFFEButton.Text = "Create Families From Excel";
            this.multiCatCFFEButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.multiCatCFFEButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.multiCatCFFEButton.ToolTipText = "Create Families From Excel: From the template generated reading the paramters of " +
    "a family, fill in the Excel file to import and make new family types.";
            this.multiCatCFFEButton.Click += new System.EventHandler(this.AllCatCFFEButton_Click);
            // 
            // multiCatSeparator1
            // 
            this.multiCatSeparator1.Name = "multiCatSeparator1";
            this.multiCatSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // multiCatRE
            // 
            this.multiCatRE.Image = ((System.Drawing.Image)(resources.GetObject("multiCatRE.Image")));
            this.multiCatRE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.multiCatRE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.multiCatRE.Name = "multiCatRE";
            this.multiCatRE.Size = new System.Drawing.Size(117, 50);
            this.multiCatRE.Text = "Renumber Elements";
            this.multiCatRE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.multiCatRE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.multiCatRE.ToolTipText = "Renumber Elements: Renumbers elements in  the order picked.";
            this.multiCatRE.Visible = false;
            // 
            // multiCatToolsPanel
            // 
            this.multiCatToolsPanel.Controls.Add(this.multiCatCFFSplitContainer);
            this.multiCatToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.multiCatToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatToolsPanel.Name = "multiCatToolsPanel";
            this.multiCatToolsPanel.Size = new System.Drawing.Size(720, 349);
            this.multiCatToolsPanel.TabIndex = 1;
            // 
            // multiCatCFFSplitContainer
            // 
            this.multiCatCFFSplitContainer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.multiCatCFFSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFSplitContainer.Name = "multiCatCFFSplitContainer";
            // 
            // multiCatCFFSplitContainer.Panel1
            // 
            this.multiCatCFFSplitContainer.Panel1.Controls.Add(this.multiCatCFFEExcelSplitContainer);
            this.multiCatCFFSplitContainer.Panel1MinSize = 90;
            // 
            // multiCatCFFSplitContainer.Panel2
            // 
            this.multiCatCFFSplitContainer.Panel2.Controls.Add(this.multiCatCFFEFamiliesSplitContainer);
            this.multiCatCFFSplitContainer.Panel2MinSize = 90;
            this.multiCatCFFSplitContainer.Size = new System.Drawing.Size(720, 349);
            this.multiCatCFFSplitContainer.SplitterDistance = 316;
            this.multiCatCFFSplitContainer.TabIndex = 0;
            this.multiCatCFFSplitContainer.Visible = false;
            // 
            // multiCatCFFEExcelSplitContainer
            // 
            this.multiCatCFFEExcelSplitContainer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.multiCatCFFEExcelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEExcelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFEExcelSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEExcelSplitContainer.Name = "multiCatCFFEExcelSplitContainer";
            this.multiCatCFFEExcelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // multiCatCFFEExcelSplitContainer.Panel1
            // 
            this.multiCatCFFEExcelSplitContainer.Panel1.Controls.Add(this.multiCatCFFECreateExcelLayoutPanel1);
            this.multiCatCFFEExcelSplitContainer.Panel1MinSize = 45;
            // 
            // multiCatCFFEExcelSplitContainer.Panel2
            // 
            this.multiCatCFFEExcelSplitContainer.Panel2.Controls.Add(this.multiCatCFFECreateExcelLayoutPanel2);
            this.multiCatCFFEExcelSplitContainer.Panel2MinSize = 45;
            this.multiCatCFFEExcelSplitContainer.Size = new System.Drawing.Size(316, 349);
            this.multiCatCFFEExcelSplitContainer.SplitterDistance = 114;
            this.multiCatCFFEExcelSplitContainer.TabIndex = 2;
            // 
            // multiCatCFFECreateExcelLayoutPanel1
            // 
            this.multiCatCFFECreateExcelLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.multiCatCFFECreateExcelLayoutPanel1.ColumnCount = 1;
            this.multiCatCFFECreateExcelLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateExcelLayoutPanel1.Controls.Add(this.multiCatCFFECreateExcelLabel, 0, 0);
            this.multiCatCFFECreateExcelLayoutPanel1.Controls.Add(this.multiCatCFFECreateExcelInstructions, 0, 1);
            this.multiCatCFFECreateExcelLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiCatCFFECreateExcelLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateExcelLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFECreateExcelLayoutPanel1.Name = "multiCatCFFECreateExcelLayoutPanel1";
            this.multiCatCFFECreateExcelLayoutPanel1.RowCount = 2;
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel1.Size = new System.Drawing.Size(316, 114);
            this.multiCatCFFECreateExcelLayoutPanel1.TabIndex = 1;
            // 
            // multiCatCFFECreateExcelLabel
            // 
            this.multiCatCFFECreateExcelLabel.AutoSize = true;
            this.multiCatCFFECreateExcelLabel.BackColor = System.Drawing.Color.GreenYellow;
            this.multiCatCFFECreateExcelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.multiCatCFFECreateExcelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateExcelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiCatCFFECreateExcelLabel.Location = new System.Drawing.Point(1, 1);
            this.multiCatCFFECreateExcelLabel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFECreateExcelLabel.Name = "multiCatCFFECreateExcelLabel";
            this.multiCatCFFECreateExcelLabel.Size = new System.Drawing.Size(314, 35);
            this.multiCatCFFECreateExcelLabel.TabIndex = 3;
            this.multiCatCFFECreateExcelLabel.Text = "Step 1 - Create Excel Template";
            this.multiCatCFFECreateExcelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // multiCatCFFECreateExcelInstructions
            // 
            this.multiCatCFFECreateExcelInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.multiCatCFFECreateExcelInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateExcelInstructions.Location = new System.Drawing.Point(1, 37);
            this.multiCatCFFECreateExcelInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFECreateExcelInstructions.Multiline = true;
            this.multiCatCFFECreateExcelInstructions.Name = "multiCatCFFECreateExcelInstructions";
            this.multiCatCFFECreateExcelInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.multiCatCFFECreateExcelInstructions.Size = new System.Drawing.Size(314, 76);
            this.multiCatCFFECreateExcelInstructions.TabIndex = 4;
            this.multiCatCFFECreateExcelInstructions.Text = resources.GetString("multiCatCFFECreateExcelInstructions.Text");
            // 
            // multiCatCFFECreateExcelLayoutPanel2
            // 
            this.multiCatCFFECreateExcelLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.multiCatCFFECreateExcelLayoutPanel2.ColumnCount = 1;
            this.multiCatCFFECreateExcelLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateExcelLayoutPanel2.Controls.Add(this.multiCatCFFEExcelDGV, 0, 2);
            this.multiCatCFFECreateExcelLayoutPanel2.Controls.Add(this.multiCatCFFEExcelRunPanel, 0, 3);
            this.multiCatCFFECreateExcelLayoutPanel2.Controls.Add(this.multiCatCFFEDirectoryPanel, 0, 0);
            this.multiCatCFFECreateExcelLayoutPanel2.Controls.Add(this.multiCatCFFESelectFamilyPanel, 0, 1);
            this.multiCatCFFECreateExcelLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiCatCFFECreateExcelLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateExcelLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFECreateExcelLayoutPanel2.Name = "multiCatCFFECreateExcelLayoutPanel2";
            this.multiCatCFFECreateExcelLayoutPanel2.RowCount = 4;
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateExcelLayoutPanel2.Size = new System.Drawing.Size(316, 231);
            this.multiCatCFFECreateExcelLayoutPanel2.TabIndex = 1;
            // 
            // multiCatCFFEExcelDGV
            // 
            this.multiCatCFFEExcelDGV.AllowUserToAddRows = false;
            this.multiCatCFFEExcelDGV.AllowUserToDeleteRows = false;
            this.multiCatCFFEExcelDGV.AllowUserToOrderColumns = true;
            this.multiCatCFFEExcelDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.multiCatCFFEExcelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.multiCatCFFEExcelDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEExcelDGV.Location = new System.Drawing.Point(1, 73);
            this.multiCatCFFEExcelDGV.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEExcelDGV.Name = "multiCatCFFEExcelDGV";
            this.multiCatCFFEExcelDGV.Size = new System.Drawing.Size(314, 121);
            this.multiCatCFFEExcelDGV.TabIndex = 1;
            this.multiCatCFFEExcelDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllCatCFFEExcelDGV_CellContentClick);
            // 
            // multiCatCFFEExcelRunPanel
            // 
            this.multiCatCFFEExcelRunPanel.Controls.Add(this.multiCatCFFEExcelStatusLabel);
            this.multiCatCFFEExcelRunPanel.Controls.Add(this.multiCatCFFEExcelRunButton);
            this.multiCatCFFEExcelRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEExcelRunPanel.Location = new System.Drawing.Point(1, 195);
            this.multiCatCFFEExcelRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEExcelRunPanel.Name = "multiCatCFFEExcelRunPanel";
            this.multiCatCFFEExcelRunPanel.Size = new System.Drawing.Size(314, 35);
            this.multiCatCFFEExcelRunPanel.TabIndex = 2;
            // 
            // multiCatCFFEExcelStatusLabel
            // 
            this.multiCatCFFEExcelStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFEExcelStatusLabel.AutoSize = true;
            this.multiCatCFFEExcelStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiCatCFFEExcelStatusLabel.Location = new System.Drawing.Point(142, 12);
            this.multiCatCFFEExcelStatusLabel.Name = "multiCatCFFEExcelStatusLabel";
            this.multiCatCFFEExcelStatusLabel.Size = new System.Drawing.Size(41, 13);
            this.multiCatCFFEExcelStatusLabel.TabIndex = 1;
            this.multiCatCFFEExcelStatusLabel.Text = "Done!";
            this.multiCatCFFEExcelStatusLabel.Visible = false;
            // 
            // multiCatCFFEExcelRunButton
            // 
            this.multiCatCFFEExcelRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFEExcelRunButton.Location = new System.Drawing.Point(188, 6);
            this.multiCatCFFEExcelRunButton.Name = "multiCatCFFEExcelRunButton";
            this.multiCatCFFEExcelRunButton.Size = new System.Drawing.Size(123, 23);
            this.multiCatCFFEExcelRunButton.TabIndex = 0;
            this.multiCatCFFEExcelRunButton.Text = "CREATE TEMPLATE";
            this.multiCatCFFEExcelRunButton.UseVisualStyleBackColor = true;
            this.multiCatCFFEExcelRunButton.Click += new System.EventHandler(this.AllCatCFFEExcelRunButton_Click);
            // 
            // multiCatCFFEDirectoryPanel
            // 
            this.multiCatCFFEDirectoryPanel.Controls.Add(this.multiCatCFFEDirectorySelectButton);
            this.multiCatCFFEDirectoryPanel.Controls.Add(this.multiCatCFFEDirectoryTextBox);
            this.multiCatCFFEDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEDirectoryPanel.Location = new System.Drawing.Point(1, 1);
            this.multiCatCFFEDirectoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEDirectoryPanel.Name = "multiCatCFFEDirectoryPanel";
            this.multiCatCFFEDirectoryPanel.Size = new System.Drawing.Size(314, 35);
            this.multiCatCFFEDirectoryPanel.TabIndex = 1;
            // 
            // multiCatCFFEDirectorySelectButton
            // 
            this.multiCatCFFEDirectorySelectButton.Location = new System.Drawing.Point(0, 6);
            this.multiCatCFFEDirectorySelectButton.Name = "multiCatCFFEDirectorySelectButton";
            this.multiCatCFFEDirectorySelectButton.Size = new System.Drawing.Size(130, 23);
            this.multiCatCFFEDirectorySelectButton.TabIndex = 1;
            this.multiCatCFFEDirectorySelectButton.Text = "Select Save Directory";
            this.multiCatCFFEDirectorySelectButton.UseVisualStyleBackColor = true;
            this.multiCatCFFEDirectorySelectButton.Click += new System.EventHandler(this.AllCatCFFEDirectorySelectButton_Click);
            // 
            // multiCatCFFEDirectoryTextBox
            // 
            this.multiCatCFFEDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFEDirectoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.multiCatCFFEDirectoryTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.multiCatCFFEDirectoryTextBox.Location = new System.Drawing.Point(136, 12);
            this.multiCatCFFEDirectoryTextBox.Name = "multiCatCFFEDirectoryTextBox";
            this.multiCatCFFEDirectoryTextBox.ReadOnly = true;
            this.multiCatCFFEDirectoryTextBox.Size = new System.Drawing.Size(175, 13);
            this.multiCatCFFEDirectoryTextBox.TabIndex = 3;
            // 
            // multiCatCFFESelectFamilyPanel
            // 
            this.multiCatCFFESelectFamilyPanel.Controls.Add(this.multiCatCFFESelectFamilyButton);
            this.multiCatCFFESelectFamilyPanel.Controls.Add(this.multiCatCFFESelectFamilyTextBox);
            this.multiCatCFFESelectFamilyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFESelectFamilyPanel.Location = new System.Drawing.Point(1, 37);
            this.multiCatCFFESelectFamilyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFESelectFamilyPanel.Name = "multiCatCFFESelectFamilyPanel";
            this.multiCatCFFESelectFamilyPanel.Size = new System.Drawing.Size(314, 35);
            this.multiCatCFFESelectFamilyPanel.TabIndex = 5;
            // 
            // multiCatCFFESelectFamilyButton
            // 
            this.multiCatCFFESelectFamilyButton.Location = new System.Drawing.Point(0, 6);
            this.multiCatCFFESelectFamilyButton.Name = "multiCatCFFESelectFamilyButton";
            this.multiCatCFFESelectFamilyButton.Size = new System.Drawing.Size(130, 23);
            this.multiCatCFFESelectFamilyButton.TabIndex = 1;
            this.multiCatCFFESelectFamilyButton.Text = "Select Family File";
            this.multiCatCFFESelectFamilyButton.UseVisualStyleBackColor = true;
            this.multiCatCFFESelectFamilyButton.Click += new System.EventHandler(this.AllCatCFFESelectFamilyButton_Click);
            // 
            // multiCatCFFESelectFamilyTextBox
            // 
            this.multiCatCFFESelectFamilyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFESelectFamilyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.multiCatCFFESelectFamilyTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.multiCatCFFESelectFamilyTextBox.Location = new System.Drawing.Point(136, 12);
            this.multiCatCFFESelectFamilyTextBox.Name = "multiCatCFFESelectFamilyTextBox";
            this.multiCatCFFESelectFamilyTextBox.ReadOnly = true;
            this.multiCatCFFESelectFamilyTextBox.Size = new System.Drawing.Size(176, 13);
            this.multiCatCFFESelectFamilyTextBox.TabIndex = 3;
            // 
            // multiCatCFFEFamiliesSplitContainer
            // 
            this.multiCatCFFEFamiliesSplitContainer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.multiCatCFFEFamiliesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEFamiliesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFEFamiliesSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEFamiliesSplitContainer.Name = "multiCatCFFEFamiliesSplitContainer";
            this.multiCatCFFEFamiliesSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // multiCatCFFEFamiliesSplitContainer.Panel1
            // 
            this.multiCatCFFEFamiliesSplitContainer.Panel1.Controls.Add(this.multiCatCFFECreateFamiliesLayoutPanel1);
            this.multiCatCFFEFamiliesSplitContainer.Panel1MinSize = 45;
            // 
            // multiCatCFFEFamiliesSplitContainer.Panel2
            // 
            this.multiCatCFFEFamiliesSplitContainer.Panel2.Controls.Add(this.multiCatCFFECreateFamiliesLayoutPanel2);
            this.multiCatCFFEFamiliesSplitContainer.Panel2MinSize = 45;
            this.multiCatCFFEFamiliesSplitContainer.Size = new System.Drawing.Size(400, 349);
            this.multiCatCFFEFamiliesSplitContainer.SplitterDistance = 114;
            this.multiCatCFFEFamiliesSplitContainer.TabIndex = 0;
            // 
            // multiCatCFFECreateFamiliesLayoutPanel1
            // 
            this.multiCatCFFECreateFamiliesLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.multiCatCFFECreateFamiliesLayoutPanel1.ColumnCount = 1;
            this.multiCatCFFECreateFamiliesLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.Controls.Add(this.multiCatCFFECreateFamiliesLabel, 0, 0);
            this.multiCatCFFECreateFamiliesLayoutPanel1.Controls.Add(this.multiCatCFFECreateFamiliesInstructions, 0, 1);
            this.multiCatCFFECreateFamiliesLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiCatCFFECreateFamiliesLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateFamiliesLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFECreateFamiliesLayoutPanel1.Name = "multiCatCFFECreateFamiliesLayoutPanel1";
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowCount = 2;
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel1.Size = new System.Drawing.Size(400, 114);
            this.multiCatCFFECreateFamiliesLayoutPanel1.TabIndex = 2;
            // 
            // multiCatCFFECreateFamiliesLabel
            // 
            this.multiCatCFFECreateFamiliesLabel.AutoSize = true;
            this.multiCatCFFECreateFamiliesLabel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.multiCatCFFECreateFamiliesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.multiCatCFFECreateFamiliesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateFamiliesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiCatCFFECreateFamiliesLabel.Location = new System.Drawing.Point(1, 1);
            this.multiCatCFFECreateFamiliesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFECreateFamiliesLabel.Name = "multiCatCFFECreateFamiliesLabel";
            this.multiCatCFFECreateFamiliesLabel.Size = new System.Drawing.Size(398, 35);
            this.multiCatCFFECreateFamiliesLabel.TabIndex = 3;
            this.multiCatCFFECreateFamiliesLabel.Text = "Step 2 - Create Revit Families";
            this.multiCatCFFECreateFamiliesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // multiCatCFFECreateFamiliesInstructions
            // 
            this.multiCatCFFECreateFamiliesInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.multiCatCFFECreateFamiliesInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateFamiliesInstructions.Location = new System.Drawing.Point(1, 37);
            this.multiCatCFFECreateFamiliesInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFECreateFamiliesInstructions.Multiline = true;
            this.multiCatCFFECreateFamiliesInstructions.Name = "multiCatCFFECreateFamiliesInstructions";
            this.multiCatCFFECreateFamiliesInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.multiCatCFFECreateFamiliesInstructions.Size = new System.Drawing.Size(398, 76);
            this.multiCatCFFECreateFamiliesInstructions.TabIndex = 4;
            this.multiCatCFFECreateFamiliesInstructions.Text = resources.GetString("multiCatCFFECreateFamiliesInstructions.Text");
            // 
            // multiCatCFFECreateFamiliesLayoutPanel2
            // 
            this.multiCatCFFECreateFamiliesLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.multiCatCFFECreateFamiliesLayoutPanel2.ColumnCount = 1;
            this.multiCatCFFECreateFamiliesLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.Controls.Add(this.multiCatCFFEFamiliesDGV, 0, 2);
            this.multiCatCFFECreateFamiliesLayoutPanel2.Controls.Add(this.multiCatCFFEFamiliesExcelPanel, 0, 0);
            this.multiCatCFFECreateFamiliesLayoutPanel2.Controls.Add(this.multiCatCFFEFamiliesRunPanel, 0, 3);
            this.multiCatCFFECreateFamiliesLayoutPanel2.Controls.Add(this.multiCatCFFEFamilyCreationPanel, 0, 1);
            this.multiCatCFFECreateFamiliesLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiCatCFFECreateFamiliesLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFECreateFamiliesLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.multiCatCFFECreateFamiliesLayoutPanel2.Name = "multiCatCFFECreateFamiliesLayoutPanel2";
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowCount = 4;
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.multiCatCFFECreateFamiliesLayoutPanel2.Size = new System.Drawing.Size(400, 231);
            this.multiCatCFFECreateFamiliesLayoutPanel2.TabIndex = 2;
            // 
            // multiCatCFFEFamiliesDGV
            // 
            this.multiCatCFFEFamiliesDGV.AllowUserToAddRows = false;
            this.multiCatCFFEFamiliesDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.multiCatCFFEFamiliesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.multiCatCFFEFamiliesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEFamiliesDGV.Location = new System.Drawing.Point(1, 73);
            this.multiCatCFFEFamiliesDGV.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEFamiliesDGV.Name = "multiCatCFFEFamiliesDGV";
            this.multiCatCFFEFamiliesDGV.RowHeadersVisible = false;
            this.multiCatCFFEFamiliesDGV.RowHeadersWidth = 45;
            this.multiCatCFFEFamiliesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.multiCatCFFEFamiliesDGV.Size = new System.Drawing.Size(398, 121);
            this.multiCatCFFEFamiliesDGV.TabIndex = 1;
            // 
            // multiCatCFFEFamiliesExcelPanel
            // 
            this.multiCatCFFEFamiliesExcelPanel.Controls.Add(this.allCATCFFEFamiliesSaveDirectoryTextBox);
            this.multiCatCFFEFamiliesExcelPanel.Controls.Add(this.multiCatCFFEFamiliesSaveDirectoryButton);
            this.multiCatCFFEFamiliesExcelPanel.Controls.Add(this.multiCatCFFEExcelSelectButton);
            this.multiCatCFFEFamiliesExcelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEFamiliesExcelPanel.Location = new System.Drawing.Point(1, 1);
            this.multiCatCFFEFamiliesExcelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEFamiliesExcelPanel.Name = "multiCatCFFEFamiliesExcelPanel";
            this.multiCatCFFEFamiliesExcelPanel.Size = new System.Drawing.Size(398, 35);
            this.multiCatCFFEFamiliesExcelPanel.TabIndex = 1;
            // 
            // allCATCFFEFamiliesSaveDirectoryTextBox
            // 
            this.allCATCFFEFamiliesSaveDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allCATCFFEFamiliesSaveDirectoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.allCATCFFEFamiliesSaveDirectoryTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.allCATCFFEFamiliesSaveDirectoryTextBox.Location = new System.Drawing.Point(259, 12);
            this.allCATCFFEFamiliesSaveDirectoryTextBox.Name = "allCATCFFEFamiliesSaveDirectoryTextBox";
            this.allCATCFFEFamiliesSaveDirectoryTextBox.ReadOnly = true;
            this.allCATCFFEFamiliesSaveDirectoryTextBox.Size = new System.Drawing.Size(130, 13);
            this.allCATCFFEFamiliesSaveDirectoryTextBox.TabIndex = 4;
            // 
            // multiCatCFFEFamiliesSaveDirectoryButton
            // 
            this.multiCatCFFEFamiliesSaveDirectoryButton.Location = new System.Drawing.Point(123, 6);
            this.multiCatCFFEFamiliesSaveDirectoryButton.Name = "multiCatCFFEFamiliesSaveDirectoryButton";
            this.multiCatCFFEFamiliesSaveDirectoryButton.Size = new System.Drawing.Size(130, 23);
            this.multiCatCFFEFamiliesSaveDirectoryButton.TabIndex = 1;
            this.multiCatCFFEFamiliesSaveDirectoryButton.Text = "Select Save Directory";
            this.multiCatCFFEFamiliesSaveDirectoryButton.UseVisualStyleBackColor = true;
            this.multiCatCFFEFamiliesSaveDirectoryButton.Click += new System.EventHandler(this.AllCatCFFEFamiliesSaveDirectoryButton_Click);
            // 
            // multiCatCFFEExcelSelectButton
            // 
            this.multiCatCFFEExcelSelectButton.Location = new System.Drawing.Point(0, 6);
            this.multiCatCFFEExcelSelectButton.Name = "multiCatCFFEExcelSelectButton";
            this.multiCatCFFEExcelSelectButton.Size = new System.Drawing.Size(117, 23);
            this.multiCatCFFEExcelSelectButton.TabIndex = 1;
            this.multiCatCFFEExcelSelectButton.Text = "Select Excel File";
            this.multiCatCFFEExcelSelectButton.UseVisualStyleBackColor = true;
            this.multiCatCFFEExcelSelectButton.Click += new System.EventHandler(this.AllCatCFFEExcelSelectButton_Click);
            // 
            // multiCatCFFEFamiliesRunPanel
            // 
            this.multiCatCFFEFamiliesRunPanel.Controls.Add(this.multiCatCFFEFamiliesProgressBar);
            this.multiCatCFFEFamiliesRunPanel.Controls.Add(this.multiCatCFFEFamiliesRunButton);
            this.multiCatCFFEFamiliesRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEFamiliesRunPanel.Location = new System.Drawing.Point(1, 195);
            this.multiCatCFFEFamiliesRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEFamiliesRunPanel.Name = "multiCatCFFEFamiliesRunPanel";
            this.multiCatCFFEFamiliesRunPanel.Size = new System.Drawing.Size(398, 35);
            this.multiCatCFFEFamiliesRunPanel.TabIndex = 2;
            // 
            // multiCatCFFEFamiliesProgressBar
            // 
            this.multiCatCFFEFamiliesProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFEFamiliesProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.multiCatCFFEFamiliesProgressBar.Location = new System.Drawing.Point(4, 6);
            this.multiCatCFFEFamiliesProgressBar.Name = "multiCatCFFEFamiliesProgressBar";
            this.multiCatCFFEFamiliesProgressBar.Size = new System.Drawing.Size(262, 23);
            this.multiCatCFFEFamiliesProgressBar.Step = 1;
            this.multiCatCFFEFamiliesProgressBar.TabIndex = 1;
            this.multiCatCFFEFamiliesProgressBar.Visible = false;
            // 
            // multiCatCFFEFamiliesRunButton
            // 
            this.multiCatCFFEFamiliesRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.multiCatCFFEFamiliesRunButton.Location = new System.Drawing.Point(273, 6);
            this.multiCatCFFEFamiliesRunButton.Name = "multiCatCFFEFamiliesRunButton";
            this.multiCatCFFEFamiliesRunButton.Size = new System.Drawing.Size(123, 23);
            this.multiCatCFFEFamiliesRunButton.TabIndex = 0;
            this.multiCatCFFEFamiliesRunButton.Text = "CREATE FAMILIES";
            this.multiCatCFFEFamiliesRunButton.UseVisualStyleBackColor = true;
            this.multiCatCFFEFamiliesRunButton.Click += new System.EventHandler(this.AllCatCFFEFamiliesRunButton_Click);
            // 
            // multiCatCFFEFamilyCreationPanel
            // 
            this.multiCatCFFEFamilyCreationPanel.Controls.Add(this.multiCatCFFEFamilyCreationLabel);
            this.multiCatCFFEFamilyCreationPanel.Controls.Add(this.multiCatCFFEFamilyCreationComboBox);
            this.multiCatCFFEFamilyCreationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCatCFFEFamilyCreationPanel.Location = new System.Drawing.Point(1, 37);
            this.multiCatCFFEFamilyCreationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.multiCatCFFEFamilyCreationPanel.Name = "multiCatCFFEFamilyCreationPanel";
            this.multiCatCFFEFamilyCreationPanel.Size = new System.Drawing.Size(398, 35);
            this.multiCatCFFEFamilyCreationPanel.TabIndex = 5;
            // 
            // multiCatCFFEFamilyCreationLabel
            // 
            this.multiCatCFFEFamilyCreationLabel.AutoSize = true;
            this.multiCatCFFEFamilyCreationLabel.Location = new System.Drawing.Point(3, 12);
            this.multiCatCFFEFamilyCreationLabel.Name = "multiCatCFFEFamilyCreationLabel";
            this.multiCatCFFEFamilyCreationLabel.Size = new System.Drawing.Size(114, 13);
            this.multiCatCFFEFamilyCreationLabel.TabIndex = 1;
            this.multiCatCFFEFamilyCreationLabel.Text = "Save Family Types As:";
            // 
            // multiCatCFFEFamilyCreationComboBox
            // 
            this.multiCatCFFEFamilyCreationComboBox.FormattingEnabled = true;
            this.multiCatCFFEFamilyCreationComboBox.Items.AddRange(new object[] {
            "Combine Types (1 File)",
            "1 Family Per Type (Multiple Files)"});
            this.multiCatCFFEFamilyCreationComboBox.Location = new System.Drawing.Point(123, 8);
            this.multiCatCFFEFamilyCreationComboBox.Name = "multiCatCFFEFamilyCreationComboBox";
            this.multiCatCFFEFamilyCreationComboBox.Size = new System.Drawing.Size(259, 21);
            this.multiCatCFFEFamilyCreationComboBox.TabIndex = 0;
            this.multiCatCFFEFamilyCreationComboBox.Text = "<Select Creation Method>";
            // 
            // doorsTab
            // 
            this.doorsTab.BackColor = System.Drawing.SystemColors.Control;
            this.doorsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.doorsTab.Location = new System.Drawing.Point(4, 25);
            this.doorsTab.Margin = new System.Windows.Forms.Padding(0);
            this.doorsTab.Name = "doorsTab";
            this.doorsTab.Size = new System.Drawing.Size(720, 402);
            this.doorsTab.TabIndex = 8;
            this.doorsTab.Text = "Doors";
            // 
            // electricalTab
            // 
            this.electricalTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.electricalTab.Controls.Add(this.electricalLayoutPanel);
            this.electricalTab.Location = new System.Drawing.Point(4, 25);
            this.electricalTab.Margin = new System.Windows.Forms.Padding(0);
            this.electricalTab.Name = "electricalTab";
            this.electricalTab.Size = new System.Drawing.Size(720, 402);
            this.electricalTab.TabIndex = 5;
            this.electricalTab.Text = "Electrical";
            this.electricalTab.UseVisualStyleBackColor = true;
            // 
            // electricalLayoutPanel
            // 
            this.electricalLayoutPanel.ColumnCount = 1;
            this.electricalLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.electricalLayoutPanel.Controls.Add(this.electricalToolStrip, 0, 0);
            this.electricalLayoutPanel.Controls.Add(this.electricalToolsPanel, 0, 1);
            this.electricalLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.electricalLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.electricalLayoutPanel.Name = "electricalLayoutPanel";
            this.electricalLayoutPanel.RowCount = 2;
            this.electricalLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.electricalLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.electricalLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.electricalLayoutPanel.TabIndex = 0;
            // 
            // electricalToolStrip
            // 
            this.electricalToolStrip.AutoSize = false;
            this.electricalToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.electricalToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.electricalToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electricalCEOEButton});
            this.electricalToolStrip.Location = new System.Drawing.Point(0, 0);
            this.electricalToolStrip.Name = "electricalToolStrip";
            this.electricalToolStrip.Size = new System.Drawing.Size(716, 53);
            this.electricalToolStrip.TabIndex = 0;
            this.electricalToolStrip.Text = "toolStrip1";
            // 
            // electricalCEOEButton
            // 
            this.electricalCEOEButton.Image = ((System.Drawing.Image)(resources.GetObject("electricalCEOEButton.Image")));
            this.electricalCEOEButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.electricalCEOEButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.electricalCEOEButton.Name = "electricalCEOEButton";
            this.electricalCEOEButton.Size = new System.Drawing.Size(134, 50);
            this.electricalCEOEButton.Text = "Correct Elec Outlet Elev";
            this.electricalCEOEButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.electricalCEOEButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.electricalCEOEButton.ToolTipText = "Correct Elec Outlet Elev: Fixes outlet elevations that were moved up instead of u" +
    "sing the Mounting Height parameter";
            this.electricalCEOEButton.Click += new System.EventHandler(this.ElectricalCEOEButton_Click);
            // 
            // electricalToolsPanel
            // 
            this.electricalToolsPanel.Controls.Add(this.electricalCEOELayoutPanel);
            this.electricalToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.electricalToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.electricalToolsPanel.Name = "electricalToolsPanel";
            this.electricalToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.electricalToolsPanel.TabIndex = 1;
            // 
            // electricalCEOELayoutPanel
            // 
            this.electricalCEOELayoutPanel.ColumnCount = 1;
            this.electricalCEOELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.electricalCEOELayoutPanel.Controls.Add(this.electricalCEOETextBox, 0, 0);
            this.electricalCEOELayoutPanel.Controls.Add(this.electricalCEOEControlsPanel, 0, 1);
            this.electricalCEOELayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalCEOELayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.electricalCEOELayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.electricalCEOELayoutPanel.Name = "electricalCEOELayoutPanel";
            this.electricalCEOELayoutPanel.RowCount = 2;
            this.electricalCEOELayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.electricalCEOELayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.electricalCEOELayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.electricalCEOELayoutPanel.TabIndex = 0;
            this.electricalCEOELayoutPanel.Visible = false;
            // 
            // electricalCEOETextBox
            // 
            this.electricalCEOETextBox.BackColor = System.Drawing.SystemColors.Control;
            this.electricalCEOETextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalCEOETextBox.Location = new System.Drawing.Point(0, 0);
            this.electricalCEOETextBox.Margin = new System.Windows.Forms.Padding(0);
            this.electricalCEOETextBox.Multiline = true;
            this.electricalCEOETextBox.Name = "electricalCEOETextBox";
            this.electricalCEOETextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.electricalCEOETextBox.Size = new System.Drawing.Size(716, 45);
            this.electricalCEOETextBox.TabIndex = 0;
            this.electricalCEOETextBox.Text = resources.GetString("electricalCEOETextBox.Text");
            // 
            // electricalCEOEControlsPanel
            // 
            this.electricalCEOEControlsPanel.Controls.Add(this.electricalCEOERunButton);
            this.electricalCEOEControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalCEOEControlsPanel.Location = new System.Drawing.Point(0, 45);
            this.electricalCEOEControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.electricalCEOEControlsPanel.Name = "electricalCEOEControlsPanel";
            this.electricalCEOEControlsPanel.Size = new System.Drawing.Size(716, 300);
            this.electricalCEOEControlsPanel.TabIndex = 1;
            // 
            // electricalCEOERunButton
            // 
            this.electricalCEOERunButton.Location = new System.Drawing.Point(3, 3);
            this.electricalCEOERunButton.Name = "electricalCEOERunButton";
            this.electricalCEOERunButton.Size = new System.Drawing.Size(75, 23);
            this.electricalCEOERunButton.TabIndex = 0;
            this.electricalCEOERunButton.Text = "RUN";
            this.electricalCEOERunButton.UseVisualStyleBackColor = true;
            this.electricalCEOERunButton.Click += new System.EventHandler(this.ElectricalCEOERunButton_Click);
            // 
            // floorsTab
            // 
            this.floorsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.floorsTab.Controls.Add(this.floorsTabLayoutPanel);
            this.floorsTab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorsTab.Location = new System.Drawing.Point(4, 25);
            this.floorsTab.Margin = new System.Windows.Forms.Padding(0);
            this.floorsTab.Name = "floorsTab";
            this.floorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.floorsTab.Size = new System.Drawing.Size(720, 402);
            this.floorsTab.TabIndex = 1;
            this.floorsTab.Text = "Floors";
            this.floorsTab.UseVisualStyleBackColor = true;
            // 
            // floorsTabLayoutPanel
            // 
            this.floorsTabLayoutPanel.ColumnCount = 1;
            this.floorsTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorsTabLayoutPanel.Controls.Add(this.floorsToolsPanel, 0, 1);
            this.floorsTabLayoutPanel.Controls.Add(this.floorsToolStrip, 0, 0);
            this.floorsTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.floorsTabLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.floorsTabLayoutPanel.Name = "floorsTabLayoutPanel";
            this.floorsTabLayoutPanel.RowCount = 2;
            this.floorsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.floorsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.floorsTabLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.floorsTabLayoutPanel.TabIndex = 0;
            // 
            // floorsToolsPanel
            // 
            this.floorsToolsPanel.Controls.Add(this.floorsCFBRLayoutPanel);
            this.floorsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.floorsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.floorsToolsPanel.Name = "floorsToolsPanel";
            this.floorsToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.floorsToolsPanel.TabIndex = 4;
            // 
            // floorsCFBRLayoutPanel
            // 
            this.floorsCFBRLayoutPanel.ColumnCount = 1;
            this.floorsCFBRLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorsCFBRLayoutPanel.Controls.Add(this.floorsCFBRInstructionsPanel, 0, 0);
            this.floorsCFBRLayoutPanel.Controls.Add(this.floorsCFBRControlsPanel, 0, 1);
            this.floorsCFBRLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsCFBRLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.floorsCFBRLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.floorsCFBRLayoutPanel.Name = "floorsCFBRLayoutPanel";
            this.floorsCFBRLayoutPanel.RowCount = 2;
            this.floorsCFBRLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.floorsCFBRLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorsCFBRLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.floorsCFBRLayoutPanel.TabIndex = 1;
            this.floorsCFBRLayoutPanel.Visible = false;
            // 
            // floorsCFBRInstructionsPanel
            // 
            this.floorsCFBRInstructionsPanel.Controls.Add(this.floorsCFBRInstructionsTextBox);
            this.floorsCFBRInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsCFBRInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.floorsCFBRInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.floorsCFBRInstructionsPanel.Name = "floorsCFBRInstructionsPanel";
            this.floorsCFBRInstructionsPanel.Size = new System.Drawing.Size(710, 175);
            this.floorsCFBRInstructionsPanel.TabIndex = 0;
            // 
            // floorsCFBRInstructionsTextBox
            // 
            this.floorsCFBRInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.floorsCFBRInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsCFBRInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.floorsCFBRInstructionsTextBox.Multiline = true;
            this.floorsCFBRInstructionsTextBox.Name = "floorsCFBRInstructionsTextBox";
            this.floorsCFBRInstructionsTextBox.ReadOnly = true;
            this.floorsCFBRInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.floorsCFBRInstructionsTextBox.Size = new System.Drawing.Size(710, 175);
            this.floorsCFBRInstructionsTextBox.TabIndex = 4;
            this.floorsCFBRInstructionsTextBox.Text = resources.GetString("floorsCFBRInstructionsTextBox.Text");
            // 
            // floorsCFBRControlsPanel
            // 
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBROffsetFinishFloorCheckBox);
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBRSelectFloorTypeLabel);
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBRSelectRoomsLabel);
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBRSelectFloorTypeComboBox);
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBRRunButton);
            this.floorsCFBRControlsPanel.Controls.Add(this.floorsCFBRSelectRoomsButton);
            this.floorsCFBRControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsCFBRControlsPanel.Location = new System.Drawing.Point(0, 175);
            this.floorsCFBRControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.floorsCFBRControlsPanel.Name = "floorsCFBRControlsPanel";
            this.floorsCFBRControlsPanel.Size = new System.Drawing.Size(710, 164);
            this.floorsCFBRControlsPanel.TabIndex = 1;
            // 
            // floorsCFBROffsetFinishFloorCheckBox
            // 
            this.floorsCFBROffsetFinishFloorCheckBox.AutoSize = true;
            this.floorsCFBROffsetFinishFloorCheckBox.Location = new System.Drawing.Point(110, 65);
            this.floorsCFBROffsetFinishFloorCheckBox.Name = "floorsCFBROffsetFinishFloorCheckBox";
            this.floorsCFBROffsetFinishFloorCheckBox.Size = new System.Drawing.Size(122, 17);
            this.floorsCFBROffsetFinishFloorCheckBox.TabIndex = 3;
            this.floorsCFBROffsetFinishFloorCheckBox.Text = "Offset Finish Floor";
            this.floorsCFBROffsetFinishFloorCheckBox.UseVisualStyleBackColor = true;
            // 
            // floorsCFBRSelectFloorTypeLabel
            // 
            this.floorsCFBRSelectFloorTypeLabel.AutoSize = true;
            this.floorsCFBRSelectFloorTypeLabel.Location = new System.Drawing.Point(5, 40);
            this.floorsCFBRSelectFloorTypeLabel.Name = "floorsCFBRSelectFloorTypeLabel";
            this.floorsCFBRSelectFloorTypeLabel.Size = new System.Drawing.Size(95, 13);
            this.floorsCFBRSelectFloorTypeLabel.TabIndex = 2;
            this.floorsCFBRSelectFloorTypeLabel.Text = "Select Floor Type:";
            // 
            // floorsCFBRSelectRoomsLabel
            // 
            this.floorsCFBRSelectRoomsLabel.AutoSize = true;
            this.floorsCFBRSelectRoomsLabel.Location = new System.Drawing.Point(5, 10);
            this.floorsCFBRSelectRoomsLabel.Name = "floorsCFBRSelectRoomsLabel";
            this.floorsCFBRSelectRoomsLabel.Size = new System.Drawing.Size(78, 13);
            this.floorsCFBRSelectRoomsLabel.TabIndex = 2;
            this.floorsCFBRSelectRoomsLabel.Text = "Select Rooms:";
            // 
            // floorsCFBRSelectFloorTypeComboBox
            // 
            this.floorsCFBRSelectFloorTypeComboBox.FormattingEnabled = true;
            this.floorsCFBRSelectFloorTypeComboBox.Location = new System.Drawing.Point(110, 35);
            this.floorsCFBRSelectFloorTypeComboBox.Name = "floorsCFBRSelectFloorTypeComboBox";
            this.floorsCFBRSelectFloorTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.floorsCFBRSelectFloorTypeComboBox.TabIndex = 1;
            this.floorsCFBRSelectFloorTypeComboBox.Text = "<Floor Type>";
            // 
            // floorsCFBRRunButton
            // 
            this.floorsCFBRRunButton.Location = new System.Drawing.Point(5, 95);
            this.floorsCFBRRunButton.Name = "floorsCFBRRunButton";
            this.floorsCFBRRunButton.Size = new System.Drawing.Size(75, 23);
            this.floorsCFBRRunButton.TabIndex = 0;
            this.floorsCFBRRunButton.Text = "RUN";
            this.floorsCFBRRunButton.UseVisualStyleBackColor = true;
            this.floorsCFBRRunButton.Click += new System.EventHandler(this.FloorsCFBRRunButton_Click);
            // 
            // floorsCFBRSelectRoomsButton
            // 
            this.floorsCFBRSelectRoomsButton.Location = new System.Drawing.Point(110, 5);
            this.floorsCFBRSelectRoomsButton.Name = "floorsCFBRSelectRoomsButton";
            this.floorsCFBRSelectRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.floorsCFBRSelectRoomsButton.TabIndex = 0;
            this.floorsCFBRSelectRoomsButton.Text = "SELECT";
            this.floorsCFBRSelectRoomsButton.UseVisualStyleBackColor = true;
            this.floorsCFBRSelectRoomsButton.Click += new System.EventHandler(this.FloorsCFBRSelectRoomsButton_Click);
            // 
            // floorsToolStrip
            // 
            this.floorsToolStrip.AutoSize = false;
            this.floorsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.floorsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.floorsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floorsCFBRButton});
            this.floorsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.floorsToolStrip.Name = "floorsToolStrip";
            this.floorsToolStrip.Size = new System.Drawing.Size(710, 53);
            this.floorsToolStrip.TabIndex = 0;
            // 
            // floorsCFBRButton
            // 
            this.floorsCFBRButton.Image = ((System.Drawing.Image)(resources.GetObject("floorsCFBRButton.Image")));
            this.floorsCFBRButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.floorsCFBRButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.floorsCFBRButton.Name = "floorsCFBRButton";
            this.floorsCFBRButton.Size = new System.Drawing.Size(129, 50);
            this.floorsCFBRButton.Text = "Create Floor By  Room";
            this.floorsCFBRButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.floorsCFBRButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.floorsCFBRButton.ToolTipText = "Create Floor By  Room: Creates floors for the selected rooms using the room bound" +
    "aries.";
            this.floorsCFBRButton.Click += new System.EventHandler(this.FloorsCFBRButton_Click);
            // 
            // massesTab
            // 
            this.massesTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.massesTab.Location = new System.Drawing.Point(4, 25);
            this.massesTab.Margin = new System.Windows.Forms.Padding(0);
            this.massesTab.Name = "massesTab";
            this.massesTab.Size = new System.Drawing.Size(720, 402);
            this.massesTab.TabIndex = 7;
            this.massesTab.Text = "Masses";
            this.massesTab.UseVisualStyleBackColor = true;
            // 
            // materialsTab
            // 
            this.materialsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialsTab.Controls.Add(this.materialsLayoutPanel);
            this.materialsTab.Location = new System.Drawing.Point(4, 25);
            this.materialsTab.Margin = new System.Windows.Forms.Padding(0);
            this.materialsTab.Name = "materialsTab";
            this.materialsTab.Size = new System.Drawing.Size(720, 402);
            this.materialsTab.TabIndex = 6;
            this.materialsTab.Text = "Materials";
            this.materialsTab.UseVisualStyleBackColor = true;
            // 
            // materialsLayoutPanel
            // 
            this.materialsLayoutPanel.ColumnCount = 1;
            this.materialsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsLayoutPanel.Controls.Add(this.materialsToolStrip, 0, 0);
            this.materialsLayoutPanel.Controls.Add(this.materialsToolsPanel, 0, 1);
            this.materialsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.materialsLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsLayoutPanel.Name = "materialsLayoutPanel";
            this.materialsLayoutPanel.RowCount = 2;
            this.materialsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.materialsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.materialsLayoutPanel.TabIndex = 0;
            // 
            // materialsToolStrip
            // 
            this.materialsToolStrip.AutoSize = false;
            this.materialsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.materialsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.materialsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialsCMSButton,
            this.materialsToolStripSeparator1,
            this.materialsAMLButton});
            this.materialsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.materialsToolStrip.Name = "materialsToolStrip";
            this.materialsToolStrip.Size = new System.Drawing.Size(716, 53);
            this.materialsToolStrip.TabIndex = 0;
            this.materialsToolStrip.Text = "toolStrip1";
            // 
            // materialsCMSButton
            // 
            this.materialsCMSButton.Image = ((System.Drawing.Image)(resources.GetObject("materialsCMSButton.Image")));
            this.materialsCMSButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.materialsCMSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.materialsCMSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.materialsCMSButton.Name = "materialsCMSButton";
            this.materialsCMSButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.materialsCMSButton.Size = new System.Drawing.Size(139, 50);
            this.materialsCMSButton.Text = "Create Material Symbols";
            this.materialsCMSButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.materialsCMSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.materialsCMSButton.ToolTipText = "Create Material Symbols: Creates the material symbol families for documentation f" +
    "rom an Excel spreadsheet.";
            this.materialsCMSButton.Click += new System.EventHandler(this.MaterialsCMS_Click);
            // 
            // materialsToolStripSeparator1
            // 
            this.materialsToolStripSeparator1.Name = "materialsToolStripSeparator1";
            this.materialsToolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // materialsAMLButton
            // 
            this.materialsAMLButton.Image = ((System.Drawing.Image)(resources.GetObject("materialsAMLButton.Image")));
            this.materialsAMLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.materialsAMLButton.Name = "materialsAMLButton";
            this.materialsAMLButton.Size = new System.Drawing.Size(124, 50);
            this.materialsAMLButton.Text = "Accent Material Lines";
            this.materialsAMLButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.materialsAMLButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.materialsAMLButton.ToolTipText = "Accent Material Lines: Creates lines along the wall for indicating accent materia" +
    "ls.";
            this.materialsAMLButton.Click += new System.EventHandler(this.MaterialsAMLButton_Click);
            // 
            // materialsToolsPanel
            // 
            this.materialsToolsPanel.Controls.Add(this.materialsAMLLayoutPanel);
            this.materialsToolsPanel.Controls.Add(this.materialsCMSExcelLayoutPanel);
            this.materialsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.materialsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsToolsPanel.Name = "materialsToolsPanel";
            this.materialsToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.materialsToolsPanel.TabIndex = 1;
            // 
            // materialsAMLLayoutPanel
            // 
            this.materialsAMLLayoutPanel.ColumnCount = 2;
            this.materialsAMLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 487F));
            this.materialsAMLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsAMLLayoutPanel.Controls.Add(this.materialsAMLHeaderPanel, 0, 0);
            this.materialsAMLLayoutPanel.Controls.Add(this.materialsAMLInstructionsTextBox, 1, 0);
            this.materialsAMLLayoutPanel.Controls.Add(this.materialsAMLDataGridView, 0, 1);
            this.materialsAMLLayoutPanel.Controls.Add(this.materialsAMLLaunchPanel, 0, 2);
            this.materialsAMLLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsAMLLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.materialsAMLLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsAMLLayoutPanel.Name = "materialsAMLLayoutPanel";
            this.materialsAMLLayoutPanel.RowCount = 3;
            this.materialsAMLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.materialsAMLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsAMLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.materialsAMLLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.materialsAMLLayoutPanel.TabIndex = 3;
            this.materialsAMLLayoutPanel.Visible = false;
            // 
            // materialsAMLHeaderPanel
            // 
            this.materialsAMLHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsAMLHeaderPanel.Controls.Add(this.materialsAMLHeaderLabel);
            this.materialsAMLHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsAMLHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.materialsAMLHeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsAMLHeaderPanel.Name = "materialsAMLHeaderPanel";
            this.materialsAMLHeaderPanel.Size = new System.Drawing.Size(487, 30);
            this.materialsAMLHeaderPanel.TabIndex = 0;
            // 
            // materialsAMLHeaderLabel
            // 
            this.materialsAMLHeaderLabel.AutoSize = true;
            this.materialsAMLHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialsAMLHeaderLabel.Location = new System.Drawing.Point(4, 9);
            this.materialsAMLHeaderLabel.Name = "materialsAMLHeaderLabel";
            this.materialsAMLHeaderLabel.Size = new System.Drawing.Size(150, 13);
            this.materialsAMLHeaderLabel.TabIndex = 0;
            this.materialsAMLHeaderLabel.Text = "Materials For Line Types:";
            // 
            // materialsAMLInstructionsTextBox
            // 
            this.materialsAMLInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.materialsAMLInstructionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsAMLInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsAMLInstructionsTextBox.Location = new System.Drawing.Point(487, 0);
            this.materialsAMLInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.materialsAMLInstructionsTextBox.Multiline = true;
            this.materialsAMLInstructionsTextBox.Name = "materialsAMLInstructionsTextBox";
            this.materialsAMLLayoutPanel.SetRowSpan(this.materialsAMLInstructionsTextBox, 3);
            this.materialsAMLInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.materialsAMLInstructionsTextBox.Size = new System.Drawing.Size(229, 345);
            this.materialsAMLInstructionsTextBox.TabIndex = 1;
            this.materialsAMLInstructionsTextBox.Text = resources.GetString("materialsAMLInstructionsTextBox.Text");
            // 
            // materialsAMLDataGridView
            // 
            this.materialsAMLDataGridView.AllowUserToAddRows = false;
            this.materialsAMLDataGridView.AllowUserToDeleteRows = false;
            this.materialsAMLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialsAMLDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsAMLDataGridView.Location = new System.Drawing.Point(3, 33);
            this.materialsAMLDataGridView.Name = "materialsAMLDataGridView";
            this.materialsAMLDataGridView.Size = new System.Drawing.Size(481, 276);
            this.materialsAMLDataGridView.TabIndex = 3;
            this.materialsAMLDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialsAMLDataGridView_CellContentClick);
            // 
            // materialsAMLLaunchPanel
            // 
            this.materialsAMLLaunchPanel.Controls.Add(this.materialsAMLLaunchPaletteButton);
            this.materialsAMLLaunchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsAMLLaunchPanel.Location = new System.Drawing.Point(0, 312);
            this.materialsAMLLaunchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsAMLLaunchPanel.Name = "materialsAMLLaunchPanel";
            this.materialsAMLLaunchPanel.Size = new System.Drawing.Size(487, 33);
            this.materialsAMLLaunchPanel.TabIndex = 4;
            // 
            // materialsAMLLaunchPaletteButton
            // 
            this.materialsAMLLaunchPaletteButton.AutoSize = true;
            this.materialsAMLLaunchPaletteButton.Location = new System.Drawing.Point(5, 3);
            this.materialsAMLLaunchPaletteButton.Name = "materialsAMLLaunchPaletteButton";
            this.materialsAMLLaunchPaletteButton.Size = new System.Drawing.Size(148, 30);
            this.materialsAMLLaunchPaletteButton.TabIndex = 2;
            this.materialsAMLLaunchPaletteButton.Text = "LAUNCH PICKER";
            this.materialsAMLLaunchPaletteButton.UseVisualStyleBackColor = true;
            this.materialsAMLLaunchPaletteButton.Click += new System.EventHandler(this.MaterialsAMLLaunchPaletteButton_Click);
            // 
            // materialsCMSExcelLayoutPanel
            // 
            this.materialsCMSExcelLayoutPanel.ColumnCount = 2;
            this.materialsCMSExcelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsCMSExcelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.materialsCMSExcelLayoutPanel.Controls.Add(this.materialsCMSExcelExportPanel, 0, 0);
            this.materialsCMSExcelLayoutPanel.Controls.Add(this.materialsCMSExcelRunPanel, 0, 3);
            this.materialsCMSExcelLayoutPanel.Controls.Add(this.materialsCMSExcelImportPanel, 0, 1);
            this.materialsCMSExcelLayoutPanel.Controls.Add(this.materialsCMSExcelDataGridView, 0, 2);
            this.materialsCMSExcelLayoutPanel.Controls.Add(this.materialsCMSExcelInstructionsTextBox, 1, 0);
            this.materialsCMSExcelLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.materialsCMSExcelLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsCMSExcelLayoutPanel.Name = "materialsCMSExcelLayoutPanel";
            this.materialsCMSExcelLayoutPanel.RowCount = 4;
            this.materialsCMSExcelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.materialsCMSExcelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.materialsCMSExcelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.materialsCMSExcelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.materialsCMSExcelLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.materialsCMSExcelLayoutPanel.TabIndex = 2;
            this.materialsCMSExcelLayoutPanel.Visible = false;
            // 
            // materialsCMSExcelExportPanel
            // 
            this.materialsCMSExcelExportPanel.BackColor = System.Drawing.SystemColors.Control;
            this.materialsCMSExcelExportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsCMSExcelExportPanel.Controls.Add(this.materialsCMSExcelCreateSpreadsheetButton);
            this.materialsCMSExcelExportPanel.Controls.Add(this.materialsCMSExcelSpreadsheetNameTextBox);
            this.materialsCMSExcelExportPanel.Controls.Add(this.materialsCMSExcelSelectSaveDirectoryButton);
            this.materialsCMSExcelExportPanel.Controls.Add(this.materialsCMSExcelExportLabel);
            this.materialsCMSExcelExportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelExportPanel.Location = new System.Drawing.Point(0, 0);
            this.materialsCMSExcelExportPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsCMSExcelExportPanel.Name = "materialsCMSExcelExportPanel";
            this.materialsCMSExcelExportPanel.Size = new System.Drawing.Size(549, 51);
            this.materialsCMSExcelExportPanel.TabIndex = 0;
            // 
            // materialsCMSExcelCreateSpreadsheetButton
            // 
            this.materialsCMSExcelCreateSpreadsheetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsCMSExcelCreateSpreadsheetButton.Location = new System.Drawing.Point(421, 21);
            this.materialsCMSExcelCreateSpreadsheetButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelCreateSpreadsheetButton.Name = "materialsCMSExcelCreateSpreadsheetButton";
            this.materialsCMSExcelCreateSpreadsheetButton.Size = new System.Drawing.Size(124, 23);
            this.materialsCMSExcelCreateSpreadsheetButton.TabIndex = 0;
            this.materialsCMSExcelCreateSpreadsheetButton.Text = "Create Spreadsheet";
            this.materialsCMSExcelCreateSpreadsheetButton.UseVisualStyleBackColor = true;
            this.materialsCMSExcelCreateSpreadsheetButton.Click += new System.EventHandler(this.MaterialsCMSExcelCreateSpreadsheetButton_Click);
            // 
            // materialsCMSExcelSpreadsheetNameTextBox
            // 
            this.materialsCMSExcelSpreadsheetNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsCMSExcelSpreadsheetNameTextBox.Location = new System.Drawing.Point(162, 23);
            this.materialsCMSExcelSpreadsheetNameTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 10, 1);
            this.materialsCMSExcelSpreadsheetNameTextBox.Name = "materialsCMSExcelSpreadsheetNameTextBox";
            this.materialsCMSExcelSpreadsheetNameTextBox.Size = new System.Drawing.Size(249, 20);
            this.materialsCMSExcelSpreadsheetNameTextBox.TabIndex = 2;
            this.materialsCMSExcelSpreadsheetNameTextBox.Text = "<Excel Spreadsheet Name>";
            this.materialsCMSExcelSpreadsheetNameTextBox.WordWrap = false;
            // 
            // materialsCMSExcelSelectSaveDirectoryButton
            // 
            this.materialsCMSExcelSelectSaveDirectoryButton.Location = new System.Drawing.Point(2, 21);
            this.materialsCMSExcelSelectSaveDirectoryButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelSelectSaveDirectoryButton.Name = "materialsCMSExcelSelectSaveDirectoryButton";
            this.materialsCMSExcelSelectSaveDirectoryButton.Size = new System.Drawing.Size(152, 23);
            this.materialsCMSExcelSelectSaveDirectoryButton.TabIndex = 1;
            this.materialsCMSExcelSelectSaveDirectoryButton.Text = "Select Save Directory";
            this.materialsCMSExcelSelectSaveDirectoryButton.UseVisualStyleBackColor = true;
            this.materialsCMSExcelSelectSaveDirectoryButton.Click += new System.EventHandler(this.MaterialsCMSExcelSelectSaveDirectoryButton_Click);
            // 
            // materialsCMSExcelExportLabel
            // 
            this.materialsCMSExcelExportLabel.AutoSize = true;
            this.materialsCMSExcelExportLabel.Location = new System.Drawing.Point(2, 3);
            this.materialsCMSExcelExportLabel.Margin = new System.Windows.Forms.Padding(3);
            this.materialsCMSExcelExportLabel.Name = "materialsCMSExcelExportLabel";
            this.materialsCMSExcelExportLabel.Size = new System.Drawing.Size(134, 13);
            this.materialsCMSExcelExportLabel.TabIndex = 0;
            this.materialsCMSExcelExportLabel.Text = "Export the Excel Template:";
            // 
            // materialsCMSExcelRunPanel
            // 
            this.materialsCMSExcelRunPanel.BackColor = System.Drawing.SystemColors.Control;
            this.materialsCMSExcelRunPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsCMSExcelRunPanel.Controls.Add(this.materialsCMSExcelCreateSymbolsProgressBar);
            this.materialsCMSExcelRunPanel.Controls.Add(this.materialsCMSExcelCreateSymbolsButton);
            this.materialsCMSExcelRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelRunPanel.Location = new System.Drawing.Point(0, 315);
            this.materialsCMSExcelRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsCMSExcelRunPanel.Name = "materialsCMSExcelRunPanel";
            this.materialsCMSExcelRunPanel.Size = new System.Drawing.Size(549, 30);
            this.materialsCMSExcelRunPanel.TabIndex = 1;
            // 
            // materialsCMSExcelCreateSymbolsProgressBar
            // 
            this.materialsCMSExcelCreateSymbolsProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsCMSExcelCreateSymbolsProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.materialsCMSExcelCreateSymbolsProgressBar.Location = new System.Drawing.Point(146, 5);
            this.materialsCMSExcelCreateSymbolsProgressBar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelCreateSymbolsProgressBar.Name = "materialsCMSExcelCreateSymbolsProgressBar";
            this.materialsCMSExcelCreateSymbolsProgressBar.Size = new System.Drawing.Size(399, 19);
            this.materialsCMSExcelCreateSymbolsProgressBar.TabIndex = 1;
            // 
            // materialsCMSExcelCreateSymbolsButton
            // 
            this.materialsCMSExcelCreateSymbolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialsCMSExcelCreateSymbolsButton.Location = new System.Drawing.Point(2, 2);
            this.materialsCMSExcelCreateSymbolsButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelCreateSymbolsButton.Name = "materialsCMSExcelCreateSymbolsButton";
            this.materialsCMSExcelCreateSymbolsButton.Size = new System.Drawing.Size(140, 25);
            this.materialsCMSExcelCreateSymbolsButton.TabIndex = 0;
            this.materialsCMSExcelCreateSymbolsButton.Text = "Create Material Symbols";
            this.materialsCMSExcelCreateSymbolsButton.UseVisualStyleBackColor = true;
            this.materialsCMSExcelCreateSymbolsButton.Click += new System.EventHandler(this.MaterialsCMSExcelCreateSymbolsButton_Click);
            // 
            // materialsCMSExcelImportPanel
            // 
            this.materialsCMSExcelImportPanel.BackColor = System.Drawing.SystemColors.Control;
            this.materialsCMSExcelImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialsCMSExcelImportPanel.Controls.Add(this.materialsCMSSetViewNameTextBox);
            this.materialsCMSExcelImportPanel.Controls.Add(this.materialsCMSSetViewNameLabel);
            this.materialsCMSExcelImportPanel.Controls.Add(this.materialsCMSExcelImportLabel);
            this.materialsCMSExcelImportPanel.Controls.Add(this.materialsCMSExcelSelectImportFileButton);
            this.materialsCMSExcelImportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelImportPanel.Location = new System.Drawing.Point(0, 51);
            this.materialsCMSExcelImportPanel.Margin = new System.Windows.Forms.Padding(0);
            this.materialsCMSExcelImportPanel.Name = "materialsCMSExcelImportPanel";
            this.materialsCMSExcelImportPanel.Size = new System.Drawing.Size(549, 51);
            this.materialsCMSExcelImportPanel.TabIndex = 2;
            // 
            // materialsCMSSetViewNameTextBox
            // 
            this.materialsCMSSetViewNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsCMSSetViewNameTextBox.Location = new System.Drawing.Point(162, 26);
            this.materialsCMSSetViewNameTextBox.Name = "materialsCMSSetViewNameTextBox";
            this.materialsCMSSetViewNameTextBox.Size = new System.Drawing.Size(249, 20);
            this.materialsCMSSetViewNameTextBox.TabIndex = 2;
            // 
            // materialsCMSSetViewNameLabel
            // 
            this.materialsCMSSetViewNameLabel.Location = new System.Drawing.Point(3, 26);
            this.materialsCMSSetViewNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.materialsCMSSetViewNameLabel.Name = "materialsCMSSetViewNameLabel";
            this.materialsCMSSetViewNameLabel.Size = new System.Drawing.Size(151, 20);
            this.materialsCMSSetViewNameLabel.TabIndex = 0;
            this.materialsCMSSetViewNameLabel.Text = "*Optional* Set View Name:";
            // 
            // materialsCMSExcelImportLabel
            // 
            this.materialsCMSExcelImportLabel.Location = new System.Drawing.Point(3, 5);
            this.materialsCMSExcelImportLabel.Margin = new System.Windows.Forms.Padding(3);
            this.materialsCMSExcelImportLabel.Name = "materialsCMSExcelImportLabel";
            this.materialsCMSExcelImportLabel.Size = new System.Drawing.Size(151, 18);
            this.materialsCMSExcelImportLabel.TabIndex = 0;
            this.materialsCMSExcelImportLabel.Text = "Import the Excel Template:";
            // 
            // materialsCMSExcelSelectImportFileButton
            // 
            this.materialsCMSExcelSelectImportFileButton.Location = new System.Drawing.Point(162, 0);
            this.materialsCMSExcelSelectImportFileButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelSelectImportFileButton.Name = "materialsCMSExcelSelectImportFileButton";
            this.materialsCMSExcelSelectImportFileButton.Size = new System.Drawing.Size(137, 23);
            this.materialsCMSExcelSelectImportFileButton.TabIndex = 1;
            this.materialsCMSExcelSelectImportFileButton.Text = "Select Excel File";
            this.materialsCMSExcelSelectImportFileButton.UseVisualStyleBackColor = true;
            this.materialsCMSExcelSelectImportFileButton.Click += new System.EventHandler(this.MaterialsCMSExcelSelectImportFileButton_Click);
            // 
            // materialsCMSExcelDataGridView
            // 
            this.materialsCMSExcelDataGridView.AllowUserToAddRows = false;
            this.materialsCMSExcelDataGridView.AllowUserToDeleteRows = false;
            this.materialsCMSExcelDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialsCMSExcelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialsCMSExcelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelDataGridView.Location = new System.Drawing.Point(0, 102);
            this.materialsCMSExcelDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.materialsCMSExcelDataGridView.Name = "materialsCMSExcelDataGridView";
            this.materialsCMSExcelDataGridView.RowTemplate.Height = 28;
            this.materialsCMSExcelDataGridView.Size = new System.Drawing.Size(549, 213);
            this.materialsCMSExcelDataGridView.TabIndex = 3;
            // 
            // materialsCMSExcelInstructionsTextBox
            // 
            this.materialsCMSExcelInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsCMSExcelInstructionsTextBox.Location = new System.Drawing.Point(551, 1);
            this.materialsCMSExcelInstructionsTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.materialsCMSExcelInstructionsTextBox.Multiline = true;
            this.materialsCMSExcelInstructionsTextBox.Name = "materialsCMSExcelInstructionsTextBox";
            this.materialsCMSExcelInstructionsTextBox.ReadOnly = true;
            this.materialsCMSExcelLayoutPanel.SetRowSpan(this.materialsCMSExcelInstructionsTextBox, 4);
            this.materialsCMSExcelInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.materialsCMSExcelInstructionsTextBox.Size = new System.Drawing.Size(163, 343);
            this.materialsCMSExcelInstructionsTextBox.TabIndex = 4;
            this.materialsCMSExcelInstructionsTextBox.Text = resources.GetString("materialsCMSExcelInstructionsTextBox.Text");
            // 
            // roomsTab
            // 
            this.roomsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.roomsTab.Controls.Add(this.roomsTabLayoutPanel);
            this.roomsTab.Location = new System.Drawing.Point(4, 25);
            this.roomsTab.Margin = new System.Windows.Forms.Padding(0);
            this.roomsTab.Name = "roomsTab";
            this.roomsTab.Size = new System.Drawing.Size(720, 402);
            this.roomsTab.TabIndex = 2;
            this.roomsTab.Text = "Rooms";
            this.roomsTab.UseVisualStyleBackColor = true;
            // 
            // roomsTabLayoutPanel
            // 
            this.roomsTabLayoutPanel.ColumnCount = 1;
            this.roomsTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roomsTabLayoutPanel.Controls.Add(roomsToolStrip, 0, 0);
            this.roomsTabLayoutPanel.Controls.Add(this.roomsToolsPanel, 0, 1);
            this.roomsTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsTabLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.roomsTabLayoutPanel.Name = "roomsTabLayoutPanel";
            this.roomsTabLayoutPanel.RowCount = 2;
            this.roomsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.roomsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roomsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.roomsTabLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.roomsTabLayoutPanel.TabIndex = 2;
            // 
            // roomsToolsPanel
            // 
            this.roomsToolsPanel.Controls.Add(this.roomsCDRTLayoutPanel);
            this.roomsToolsPanel.Controls.Add(this.roomsSRNNLayoutPanel);
            this.roomsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsToolsPanel.Location = new System.Drawing.Point(3, 56);
            this.roomsToolsPanel.Name = "roomsToolsPanel";
            this.roomsToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.roomsToolsPanel.TabIndex = 1;
            // 
            // roomsCDRTLayoutPanel
            // 
            this.roomsCDRTLayoutPanel.ColumnCount = 1;
            this.roomsCDRTLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.roomsCDRTLayoutPanel.Controls.Add(this.roomsCDRTInstructionsTextBox, 0, 0);
            this.roomsCDRTLayoutPanel.Controls.Add(this.roomsCDRTControlsPanel, 0, 1);
            this.roomsCDRTLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsCDRTLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.roomsCDRTLayoutPanel.Name = "roomsCDRTLayoutPanel";
            this.roomsCDRTLayoutPanel.RowCount = 2;
            this.roomsCDRTLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.57396F));
            this.roomsCDRTLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.42604F));
            this.roomsCDRTLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.roomsCDRTLayoutPanel.TabIndex = 16;
            this.roomsCDRTLayoutPanel.Visible = false;
            // 
            // roomsCDRTInstructionsTextBox
            // 
            this.roomsCDRTInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.roomsCDRTInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsCDRTInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.roomsCDRTInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.roomsCDRTInstructionsTextBox.Multiline = true;
            this.roomsCDRTInstructionsTextBox.Name = "roomsCDRTInstructionsTextBox";
            this.roomsCDRTInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.roomsCDRTInstructionsTextBox.Size = new System.Drawing.Size(710, 127);
            this.roomsCDRTInstructionsTextBox.TabIndex = 0;
            this.roomsCDRTInstructionsTextBox.Text = resources.GetString("roomsCDRTInstructionsTextBox.Text");
            // 
            // roomsCDRTControlsPanel
            // 
            this.roomsCDRTControlsPanel.Controls.Add(this.roomsCDRTRunButton);
            this.roomsCDRTControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsCDRTControlsPanel.Location = new System.Drawing.Point(0, 127);
            this.roomsCDRTControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.roomsCDRTControlsPanel.Name = "roomsCDRTControlsPanel";
            this.roomsCDRTControlsPanel.Size = new System.Drawing.Size(710, 212);
            this.roomsCDRTControlsPanel.TabIndex = 1;
            // 
            // roomsCDRTRunButton
            // 
            this.roomsCDRTRunButton.Location = new System.Drawing.Point(3, 3);
            this.roomsCDRTRunButton.Name = "roomsCDRTRunButton";
            this.roomsCDRTRunButton.Size = new System.Drawing.Size(75, 23);
            this.roomsCDRTRunButton.TabIndex = 0;
            this.roomsCDRTRunButton.Text = "RUN";
            this.roomsCDRTRunButton.UseVisualStyleBackColor = true;
            this.roomsCDRTRunButton.Click += new System.EventHandler(this.RoomsCDRTRunButton_Click);
            // 
            // roomsSRNNLayoutPanel
            // 
            this.roomsSRNNLayoutPanel.ColumnCount = 1;
            this.roomsSRNNLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roomsSRNNLayoutPanel.Controls.Add(this.roomsSRNNInstructions, 0, 0);
            this.roomsSRNNLayoutPanel.Controls.Add(this.roomsSRNNPanel, 0, 2);
            this.roomsSRNNLayoutPanel.Controls.Add(this.roomsSRRNUrlPanel, 0, 1);
            this.roomsSRNNLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsSRNNLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.roomsSRNNLayoutPanel.Name = "roomsSRNNLayoutPanel";
            this.roomsSRNNLayoutPanel.RowCount = 3;
            this.roomsSRNNLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.roomsSRNNLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.roomsSRNNLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roomsSRNNLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.roomsSRNNLayoutPanel.TabIndex = 2;
            this.roomsSRNNLayoutPanel.Visible = false;
            // 
            // roomsSRNNInstructions
            // 
            this.roomsSRNNInstructions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.roomsSRNNInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsSRNNInstructions.Location = new System.Drawing.Point(0, 0);
            this.roomsSRNNInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.roomsSRNNInstructions.Name = "roomsSRNNInstructions";
            this.roomsSRNNInstructions.Padding = new System.Windows.Forms.Padding(5);
            this.roomsSRNNInstructions.Size = new System.Drawing.Size(710, 30);
            this.roomsSRNNInstructions.TabIndex = 14;
            this.roomsSRNNInstructions.Text = "This will swap the room name and numbers for better sorting with a Bluebeam PDF p" +
    "rint. Swap back after printing.";
            // 
            // roomsSRNNPanel
            // 
            this.roomsSRNNPanel.Controls.Add(this.roomsSRNNRunButton);
            this.roomsSRNNPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsSRNNPanel.Location = new System.Drawing.Point(0, 60);
            this.roomsSRNNPanel.Margin = new System.Windows.Forms.Padding(0);
            this.roomsSRNNPanel.Name = "roomsSRNNPanel";
            this.roomsSRNNPanel.Size = new System.Drawing.Size(710, 279);
            this.roomsSRNNPanel.TabIndex = 1;
            // 
            // roomsSRNNRunButton
            // 
            this.roomsSRNNRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsSRNNRunButton.Location = new System.Drawing.Point(5, 5);
            this.roomsSRNNRunButton.Name = "roomsSRNNRunButton";
            this.roomsSRNNRunButton.Size = new System.Drawing.Size(65, 25);
            this.roomsSRNNRunButton.TabIndex = 15;
            this.roomsSRNNRunButton.Text = "RUN";
            this.roomsSRNNRunButton.UseVisualStyleBackColor = true;
            this.roomsSRNNRunButton.Click += new System.EventHandler(this.RoomsSRNNRunButton_Click);
            // 
            // roomsSRRNUrlPanel
            // 
            this.roomsSRRNUrlPanel.Controls.Add(this.roomsSRRNUrlLabel);
            this.roomsSRRNUrlPanel.Controls.Add(this.roomsSRRNUrlLinkLabel);
            this.roomsSRRNUrlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsSRRNUrlPanel.Location = new System.Drawing.Point(0, 30);
            this.roomsSRRNUrlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.roomsSRRNUrlPanel.Name = "roomsSRRNUrlPanel";
            this.roomsSRRNUrlPanel.Size = new System.Drawing.Size(710, 30);
            this.roomsSRRNUrlPanel.TabIndex = 15;
            // 
            // roomsSRRNUrlLabel
            // 
            this.roomsSRRNUrlLabel.AutoSize = true;
            this.roomsSRRNUrlLabel.Location = new System.Drawing.Point(156, 5);
            this.roomsSRRNUrlLabel.Margin = new System.Windows.Forms.Padding(5);
            this.roomsSRRNUrlLabel.Name = "roomsSRRNUrlLabel";
            this.roomsSRRNUrlLabel.Size = new System.Drawing.Size(221, 13);
            this.roomsSRRNUrlLabel.TabIndex = 1;
            this.roomsSRRNUrlLabel.Text = "(Covers the same process that used Dynamo)";
            // 
            // roomsSRRNUrlLinkLabel
            // 
            this.roomsSRRNUrlLinkLabel.AutoSize = true;
            this.roomsSRRNUrlLinkLabel.Location = new System.Drawing.Point(2, 5);
            this.roomsSRRNUrlLinkLabel.Margin = new System.Windows.Forms.Padding(5);
            this.roomsSRRNUrlLinkLabel.Name = "roomsSRRNUrlLinkLabel";
            this.roomsSRRNUrlLinkLabel.Size = new System.Drawing.Size(144, 13);
            this.roomsSRRNUrlLinkLabel.TabIndex = 0;
            this.roomsSRRNUrlLinkLabel.TabStop = true;
            this.roomsSRRNUrlLinkLabel.Text = "Bluebeam Spaces from Revit";
            this.roomsSRRNUrlLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RoomsSRRNUrlLinkLabel_LinkClicked);
            // 
            // wallsTab
            // 
            this.wallsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wallsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wallsTab.Controls.Add(this.wallsTabLayoutPanel);
            this.wallsTab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallsTab.Location = new System.Drawing.Point(4, 25);
            this.wallsTab.Margin = new System.Windows.Forms.Padding(0);
            this.wallsTab.Name = "wallsTab";
            this.wallsTab.Size = new System.Drawing.Size(720, 402);
            this.wallsTab.TabIndex = 0;
            this.wallsTab.Text = "Walls";
            this.wallsTab.UseVisualStyleBackColor = true;
            // 
            // wallsTabLayoutPanel
            // 
            this.wallsTabLayoutPanel.ColumnCount = 1;
            this.wallsTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsTabLayoutPanel.Controls.Add(this.wallsToolStrip, 0, 0);
            this.wallsTabLayoutPanel.Controls.Add(this.wallsToolsPanel, 0, 1);
            this.wallsTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsTabLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.wallsTabLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wallsTabLayoutPanel.Name = "wallsTabLayoutPanel";
            this.wallsTabLayoutPanel.RowCount = 2;
            this.wallsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.wallsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsTabLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.wallsTabLayoutPanel.TabIndex = 8;
            // 
            // wallsToolStrip
            // 
            this.wallsToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wallsToolStrip.AutoSize = false;
            this.wallsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.wallsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.wallsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.wallsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wallsMPWButton,
            this.wallsToolStripSeparator1,
            this.wallsDPButton});
            this.wallsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.wallsToolStrip.Name = "wallsToolStrip";
            this.wallsToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.wallsToolStrip.Size = new System.Drawing.Size(716, 53);
            this.wallsToolStrip.Stretch = true;
            this.wallsToolStrip.TabIndex = 0;
            this.wallsToolStrip.Text = "toolStrip1";
            // 
            // wallsMPWButton
            // 
            this.wallsMPWButton.Image = ((System.Drawing.Image)(resources.GetObject("wallsMPWButton.Image")));
            this.wallsMPWButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.wallsMPWButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wallsMPWButton.Name = "wallsMPWButton";
            this.wallsMPWButton.Size = new System.Drawing.Size(93, 50);
            this.wallsMPWButton.Text = "Perimeter Walls";
            this.wallsMPWButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.wallsMPWButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.wallsMPWButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.wallsMPWButton.ToolTipText = "Make Perimeter Walls: Creates walls around the room boundaries and tries to join " +
    "them to adjacent walls";
            this.wallsMPWButton.Click += new System.EventHandler(this.WallsMPWButton_Click);
            // 
            // wallsToolStripSeparator1
            // 
            this.wallsToolStripSeparator1.Name = "wallsToolStripSeparator1";
            this.wallsToolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // wallsDPButton
            // 
            this.wallsDPButton.Image = ((System.Drawing.Image)(resources.GetObject("wallsDPButton.Image")));
            this.wallsDPButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.wallsDPButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.wallsDPButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wallsDPButton.Name = "wallsDPButton";
            this.wallsDPButton.Size = new System.Drawing.Size(73, 50);
            this.wallsDPButton.Text = "Delete Parts";
            this.wallsDPButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.wallsDPButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.wallsDPButton.ToolTipText = "Delete Parts: Deletes the parts associated with a wall made into parts";
            this.wallsDPButton.Click += new System.EventHandler(this.WallsDPButton_Click);
            // 
            // wallsToolsPanel
            // 
            this.wallsToolsPanel.Controls.Add(this.wallsDPLayoutPanel);
            this.wallsToolsPanel.Controls.Add(this.wallsMPWLayoutPanel);
            this.wallsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.wallsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wallsToolsPanel.Name = "wallsToolsPanel";
            this.wallsToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.wallsToolsPanel.TabIndex = 1;
            // 
            // wallsDPLayoutPanel
            // 
            this.wallsDPLayoutPanel.ColumnCount = 1;
            this.wallsDPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsDPLayoutPanel.Controls.Add(this.wallsDPInstructionsTextBox, 0, 0);
            this.wallsDPLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.wallsDPLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsDPLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.wallsDPLayoutPanel.Name = "wallsDPLayoutPanel";
            this.wallsDPLayoutPanel.RowCount = 2;
            this.wallsDPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.wallsDPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsDPLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.wallsDPLayoutPanel.TabIndex = 8;
            this.wallsDPLayoutPanel.Visible = false;
            // 
            // wallsDPInstructionsTextBox
            // 
            this.wallsDPInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.wallsDPInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsDPInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.wallsDPInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.wallsDPInstructionsTextBox.Multiline = true;
            this.wallsDPInstructionsTextBox.Name = "wallsDPInstructionsTextBox";
            this.wallsDPInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wallsDPInstructionsTextBox.Size = new System.Drawing.Size(716, 100);
            this.wallsDPInstructionsTextBox.TabIndex = 0;
            this.wallsDPInstructionsTextBox.Text = resources.GetString("wallsDPInstructionsTextBox.Text");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wallsDPRunButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 245);
            this.panel2.TabIndex = 1;
            // 
            // wallsDPRunButton
            // 
            this.wallsDPRunButton.Location = new System.Drawing.Point(3, 3);
            this.wallsDPRunButton.Name = "wallsDPRunButton";
            this.wallsDPRunButton.Size = new System.Drawing.Size(75, 23);
            this.wallsDPRunButton.TabIndex = 0;
            this.wallsDPRunButton.Text = "RUN";
            this.wallsDPRunButton.UseVisualStyleBackColor = true;
            this.wallsDPRunButton.Click += new System.EventHandler(this.WallsDPRunButton_Click);
            // 
            // wallsMPWLayoutPanel
            // 
            this.wallsMPWLayoutPanel.ColumnCount = 1;
            this.wallsMPWLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsMPWLayoutPanel.Controls.Add(this.wallsMPWControlsPanel, 0, 1);
            this.wallsMPWLayoutPanel.Controls.Add(this.wallsMPWInstructionsPanel, 0, 0);
            this.wallsMPWLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsMPWLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.wallsMPWLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wallsMPWLayoutPanel.Name = "wallsMPWLayoutPanel";
            this.wallsMPWLayoutPanel.RowCount = 2;
            this.wallsMPWLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.wallsMPWLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.wallsMPWLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.wallsMPWLayoutPanel.TabIndex = 0;
            this.wallsMPWLayoutPanel.Visible = false;
            // 
            // wallsMPWControlsPanel
            // 
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWLabelSelectWall);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWNumericUpDownWallHeightIn);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWLabelSetWall);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWNumericUpDownWallHeightFt);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWLabelWallHtFtTxt);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWButtonRun);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWLabelWallHtInTxt);
            this.wallsMPWControlsPanel.Controls.Add(this.wallsMPWComboBoxWall);
            this.wallsMPWControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsMPWControlsPanel.Location = new System.Drawing.Point(0, 179);
            this.wallsMPWControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wallsMPWControlsPanel.Name = "wallsMPWControlsPanel";
            this.wallsMPWControlsPanel.Size = new System.Drawing.Size(716, 166);
            this.wallsMPWControlsPanel.TabIndex = 0;
            // 
            // wallsMPWLabelSelectWall
            // 
            this.wallsMPWLabelSelectWall.AutoSize = true;
            this.wallsMPWLabelSelectWall.Location = new System.Drawing.Point(3, 9);
            this.wallsMPWLabelSelectWall.Name = "wallsMPWLabelSelectWall";
            this.wallsMPWLabelSelectWall.Size = new System.Drawing.Size(91, 13);
            this.wallsMPWLabelSelectWall.TabIndex = 0;
            this.wallsMPWLabelSelectWall.Text = "Select Wall Type:";
            // 
            // wallsMPWNumericUpDownWallHeightIn
            // 
            this.wallsMPWNumericUpDownWallHeightIn.DecimalPlaces = 3;
            this.wallsMPWNumericUpDownWallHeightIn.Location = new System.Drawing.Point(167, 34);
            this.wallsMPWNumericUpDownWallHeightIn.Name = "wallsMPWNumericUpDownWallHeightIn";
            this.wallsMPWNumericUpDownWallHeightIn.Size = new System.Drawing.Size(53, 22);
            this.wallsMPWNumericUpDownWallHeightIn.TabIndex = 7;
            // 
            // wallsMPWLabelSetWall
            // 
            this.wallsMPWLabelSetWall.AutoSize = true;
            this.wallsMPWLabelSetWall.Location = new System.Drawing.Point(3, 36);
            this.wallsMPWLabelSetWall.Name = "wallsMPWLabelSetWall";
            this.wallsMPWLabelSetWall.Size = new System.Drawing.Size(71, 13);
            this.wallsMPWLabelSetWall.TabIndex = 0;
            this.wallsMPWLabelSetWall.Text = "Wall Height:";
            // 
            // wallsMPWNumericUpDownWallHeightFt
            // 
            this.wallsMPWNumericUpDownWallHeightFt.Location = new System.Drawing.Point(103, 34);
            this.wallsMPWNumericUpDownWallHeightFt.Name = "wallsMPWNumericUpDownWallHeightFt";
            this.wallsMPWNumericUpDownWallHeightFt.Size = new System.Drawing.Size(39, 22);
            this.wallsMPWNumericUpDownWallHeightFt.TabIndex = 7;
            // 
            // wallsMPWLabelWallHtFtTxt
            // 
            this.wallsMPWLabelWallHtFtTxt.AutoSize = true;
            this.wallsMPWLabelWallHtFtTxt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallsMPWLabelWallHtFtTxt.Location = new System.Drawing.Point(141, 32);
            this.wallsMPWLabelWallHtFtTxt.Name = "wallsMPWLabelWallHtFtTxt";
            this.wallsMPWLabelWallHtFtTxt.Size = new System.Drawing.Size(27, 20);
            this.wallsMPWLabelWallHtFtTxt.TabIndex = 0;
            this.wallsMPWLabelWallHtFtTxt.Text = "\' - ";
            // 
            // wallsMPWButtonRun
            // 
            this.wallsMPWButtonRun.Location = new System.Drawing.Point(3, 64);
            this.wallsMPWButtonRun.Name = "wallsMPWButtonRun";
            this.wallsMPWButtonRun.Size = new System.Drawing.Size(65, 25);
            this.wallsMPWButtonRun.TabIndex = 6;
            this.wallsMPWButtonRun.Text = "RUN";
            this.wallsMPWButtonRun.UseVisualStyleBackColor = true;
            this.wallsMPWButtonRun.Click += new System.EventHandler(this.WallsMPWRun_Click);
            // 
            // wallsMPWLabelWallHtInTxt
            // 
            this.wallsMPWLabelWallHtInTxt.AutoSize = true;
            this.wallsMPWLabelWallHtInTxt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallsMPWLabelWallHtInTxt.Location = new System.Drawing.Point(220, 34);
            this.wallsMPWLabelWallHtInTxt.Name = "wallsMPWLabelWallHtInTxt";
            this.wallsMPWLabelWallHtInTxt.Size = new System.Drawing.Size(16, 20);
            this.wallsMPWLabelWallHtInTxt.TabIndex = 0;
            this.wallsMPWLabelWallHtInTxt.Text = "\"";
            // 
            // wallsMPWComboBoxWall
            // 
            this.wallsMPWComboBoxWall.FormattingEnabled = true;
            this.wallsMPWComboBoxWall.Location = new System.Drawing.Point(103, 9);
            this.wallsMPWComboBoxWall.Name = "wallsMPWComboBoxWall";
            this.wallsMPWComboBoxWall.Size = new System.Drawing.Size(258, 21);
            this.wallsMPWComboBoxWall.TabIndex = 2;
            this.wallsMPWComboBoxWall.Text = "<Wall Type>";
            // 
            // wallsMPWInstructionsPanel
            // 
            this.wallsMPWInstructionsPanel.Controls.Add(this.textBox1);
            this.wallsMPWInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallsMPWInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.wallsMPWInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wallsMPWInstructionsPanel.Name = "wallsMPWInstructionsPanel";
            this.wallsMPWInstructionsPanel.Size = new System.Drawing.Size(716, 179);
            this.wallsMPWInstructionsPanel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(716, 179);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // documentationTab
            // 
            this.documentationTab.BackColor = System.Drawing.SystemColors.Control;
            this.documentationTab.Controls.Add(this.documentationTabControl);
            this.documentationTab.Location = new System.Drawing.Point(25, 4);
            this.documentationTab.Margin = new System.Windows.Forms.Padding(0);
            this.documentationTab.Name = "documentationTab";
            this.documentationTab.Padding = new System.Windows.Forms.Padding(3);
            this.documentationTab.Size = new System.Drawing.Size(734, 437);
            this.documentationTab.TabIndex = 5;
            this.documentationTab.Text = "Documentation";
            // 
            // documentationTabControl
            // 
            this.documentationTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.documentationTabControl.Controls.Add(this.sheetsTab);
            this.documentationTabControl.Controls.Add(this.viewsTab);
            this.documentationTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentationTabControl.Location = new System.Drawing.Point(3, 3);
            this.documentationTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.documentationTabControl.Name = "documentationTabControl";
            this.documentationTabControl.SelectedIndex = 0;
            this.documentationTabControl.Size = new System.Drawing.Size(728, 431);
            this.documentationTabControl.TabIndex = 0;
            // 
            // sheetsTab
            // 
            this.sheetsTab.BackColor = System.Drawing.Color.Transparent;
            this.sheetsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheetsTab.Controls.Add(this.sheetsTabLayoutPanel);
            this.sheetsTab.Location = new System.Drawing.Point(4, 25);
            this.sheetsTab.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsTab.Name = "sheetsTab";
            this.sheetsTab.Padding = new System.Windows.Forms.Padding(3);
            this.sheetsTab.Size = new System.Drawing.Size(720, 402);
            this.sheetsTab.TabIndex = 0;
            this.sheetsTab.Text = "Sheets";
            // 
            // sheetsTabLayoutPanel
            // 
            this.sheetsTabLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.sheetsTabLayoutPanel.ColumnCount = 1;
            this.sheetsTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsTabLayoutPanel.Controls.Add(this.sheetsToolStrip, 0, 0);
            this.sheetsTabLayoutPanel.Controls.Add(this.sheetsToolsPanel, 0, 1);
            this.sheetsTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.sheetsTabLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsTabLayoutPanel.Name = "sheetsTabLayoutPanel";
            this.sheetsTabLayoutPanel.RowCount = 2;
            this.sheetsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.sheetsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sheetsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sheetsTabLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.sheetsTabLayoutPanel.TabIndex = 4;
            // 
            // sheetsToolStrip
            // 
            this.sheetsToolStrip.AutoSize = false;
            this.sheetsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.sheetsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sheetsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sheetsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sheetsCSLButton,
            this.sheetsSeparator1,
            this.sheetsISFLButton,
            this.sheetsSeparator2,
            this.sheetsSheetSetsButton});
            this.sheetsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.sheetsToolStrip.Name = "sheetsToolStrip";
            this.sheetsToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.sheetsToolStrip.Size = new System.Drawing.Size(710, 53);
            this.sheetsToolStrip.Stretch = true;
            this.sheetsToolStrip.TabIndex = 0;
            this.sheetsToolStrip.Text = "toolStrip1";
            // 
            // sheetsCSLButton
            // 
            this.sheetsCSLButton.Image = ((System.Drawing.Image)(resources.GetObject("sheetsCSLButton.Image")));
            this.sheetsCSLButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sheetsCSLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sheetsCSLButton.Name = "sheetsCSLButton";
            this.sheetsCSLButton.Size = new System.Drawing.Size(118, 50);
            this.sheetsCSLButton.Text = "Copy Sheet Legends";
            this.sheetsCSLButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sheetsCSLButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sheetsCSLButton.ToolTipText = "Copy Sheet Legends: Copies legends from the specified sheet to selected sheets";
            this.sheetsCSLButton.Click += new System.EventHandler(this.SheetsCSLButton_Click);
            // 
            // sheetsSeparator1
            // 
            this.sheetsSeparator1.Name = "sheetsSeparator1";
            this.sheetsSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // sheetsISFLButton
            // 
            this.sheetsISFLButton.Image = ((System.Drawing.Image)(resources.GetObject("sheetsISFLButton.Image")));
            this.sheetsISFLButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sheetsISFLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sheetsISFLButton.Name = "sheetsISFLButton";
            this.sheetsISFLButton.Size = new System.Drawing.Size(133, 50);
            this.sheetsISFLButton.Text = "Insert Sheets From Link";
            this.sheetsISFLButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sheetsISFLButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sheetsISFLButton.ToolTipText = "Insert Sheets From Link: Inserts placeholder sheets from a list of sheets in a li" +
    "nked file";
            this.sheetsISFLButton.Click += new System.EventHandler(this.SheetsISFLButton_Click);
            // 
            // sheetsSeparator2
            // 
            this.sheetsSeparator2.Name = "sheetsSeparator2";
            this.sheetsSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // sheetsSheetSetsButton
            // 
            this.sheetsSheetSetsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sheetsCSSFSButton,
            this.sheetsOSSButton});
            this.sheetsSheetSetsButton.Image = ((System.Drawing.Image)(resources.GetObject("sheetsSheetSetsButton.Image")));
            this.sheetsSheetSetsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sheetsSheetSetsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sheetsSheetSetsButton.Name = "sheetsSheetSetsButton";
            this.sheetsSheetSetsButton.Size = new System.Drawing.Size(76, 50);
            this.sheetsSheetSetsButton.Text = "Sheet Sets";
            this.sheetsSheetSetsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sheetsSheetSetsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sheetsSheetSetsButton.ToolTipText = "Sheet Sets Tools";
            // 
            // sheetsCSSFSButton
            // 
            this.sheetsCSSFSButton.Image = ((System.Drawing.Image)(resources.GetObject("sheetsCSSFSButton.Image")));
            this.sheetsCSSFSButton.Name = "sheetsCSSFSButton";
            this.sheetsCSSFSButton.Size = new System.Drawing.Size(257, 38);
            this.sheetsCSSFSButton.Text = "Create Sheet Set From Schedule";
            this.sheetsCSSFSButton.ToolTipText = "Create Sheet Set From Schedule: Creates new sheets print sets from a sheet schedu" +
    "le\'s visible sheets.";
            this.sheetsCSSFSButton.Click += new System.EventHandler(this.SheetsCSSFSButton_Click);
            // 
            // sheetsOSSButton
            // 
            this.sheetsOSSButton.Image = ((System.Drawing.Image)(resources.GetObject("sheetsOSSButton.Image")));
            this.sheetsOSSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sheetsOSSButton.Name = "sheetsOSSButton";
            this.sheetsOSSButton.Size = new System.Drawing.Size(257, 38);
            this.sheetsOSSButton.Text = "Organize Sheet Sets";
            this.sheetsOSSButton.ToolTipText = "Organize Sheet Sets: Control which print sets sheets belong to, and create additi" +
    "onal sets.";
            this.sheetsOSSButton.Click += new System.EventHandler(this.SheetsOSSButton_Click);
            // 
            // sheetsToolsPanel
            // 
            this.sheetsToolsPanel.Controls.Add(this.sheetsCSLLayoutPanel);
            this.sheetsToolsPanel.Controls.Add(this.sheetsOSSLayoutPanel);
            this.sheetsToolsPanel.Controls.Add(this.sheetsISFLLayoutPanel);
            this.sheetsToolsPanel.Controls.Add(this.sheetsCSSFSLayoutPanel);
            this.sheetsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.sheetsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsToolsPanel.Name = "sheetsToolsPanel";
            this.sheetsToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.sheetsToolsPanel.TabIndex = 0;
            // 
            // sheetsCSLLayoutPanel
            // 
            this.sheetsCSLLayoutPanel.ColumnCount = 1;
            this.sheetsCSLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sheetsCSLLayoutPanel.Controls.Add(this.sheetsCLSRunButton, 0, 3);
            this.sheetsCSLLayoutPanel.Controls.Add(this.sheetsCSLDataGridView, 0, 2);
            this.sheetsCSLLayoutPanel.Controls.Add(this.sheetsCSLControlsPanel, 0, 1);
            this.sheetsCSLLayoutPanel.Controls.Add(this.sheetsCSLInstructionsPanel, 0, 0);
            this.sheetsCSLLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSLLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSLLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSLLayoutPanel.Name = "sheetsCSLLayoutPanel";
            this.sheetsCSLLayoutPanel.RowCount = 4;
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sheetsCSLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sheetsCSLLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.sheetsCSLLayoutPanel.TabIndex = 1;
            this.sheetsCSLLayoutPanel.Visible = false;
            // 
            // sheetsCLSRunButton
            // 
            this.sheetsCLSRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sheetsCLSRunButton.Location = new System.Drawing.Point(3, 313);
            this.sheetsCLSRunButton.Name = "sheetsCLSRunButton";
            this.sheetsCLSRunButton.Size = new System.Drawing.Size(65, 23);
            this.sheetsCLSRunButton.TabIndex = 2;
            this.sheetsCLSRunButton.Text = "RUN";
            this.sheetsCLSRunButton.UseVisualStyleBackColor = true;
            this.sheetsCLSRunButton.Click += new System.EventHandler(this.SheetsCSLRunButton_Click);
            // 
            // sheetsCSLDataGridView
            // 
            this.sheetsCSLDataGridView.AllowUserToAddRows = false;
            this.sheetsCSLDataGridView.AllowUserToDeleteRows = false;
            this.sheetsCSLDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheetsCSLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sheetsCSLDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSLDataGridView.Location = new System.Drawing.Point(3, 98);
            this.sheetsCSLDataGridView.Name = "sheetsCSLDataGridView";
            this.sheetsCSLDataGridView.Size = new System.Drawing.Size(704, 209);
            this.sheetsCSLDataGridView.TabIndex = 1;
            this.sheetsCSLDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsCSLDataGridView_CellContentClick);
            // 
            // sheetsCSLControlsPanel
            // 
            this.sheetsCSLControlsPanel.Controls.Add(this.sheetsCSLFilterConditionComboBox);
            this.sheetsCSLControlsPanel.Controls.Add(this.sheetsCSLFilterTextBox);
            this.sheetsCSLControlsPanel.Controls.Add(this.sheetsCSLCopyFromLabel);
            this.sheetsCSLControlsPanel.Controls.Add(this.sheetsCSLCopyToLabel);
            this.sheetsCSLControlsPanel.Controls.Add(this.sheetsCSLComboBox);
            this.sheetsCSLControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSLControlsPanel.Location = new System.Drawing.Point(0, 42);
            this.sheetsCSLControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSLControlsPanel.Name = "sheetsCSLControlsPanel";
            this.sheetsCSLControlsPanel.Size = new System.Drawing.Size(710, 53);
            this.sheetsCSLControlsPanel.TabIndex = 3;
            // 
            // sheetsCSLFilterConditionComboBox
            // 
            this.sheetsCSLFilterConditionComboBox.FormattingEnabled = true;
            this.sheetsCSLFilterConditionComboBox.Items.AddRange(new object[] {
            "CONTAINS",
            "DOES NOT CONTAIN"});
            this.sheetsCSLFilterConditionComboBox.Location = new System.Drawing.Point(155, 27);
            this.sheetsCSLFilterConditionComboBox.Name = "sheetsCSLFilterConditionComboBox";
            this.sheetsCSLFilterConditionComboBox.Size = new System.Drawing.Size(133, 21);
            this.sheetsCSLFilterConditionComboBox.TabIndex = 3;
            this.sheetsCSLFilterConditionComboBox.Text = "<Condition>";
            this.sheetsCSLFilterConditionComboBox.SelectedIndexChanged += new System.EventHandler(this.SheetsCSLFilterConditionComboBox_SelectedIndexChanged);
            // 
            // sheetsCSLFilterTextBox
            // 
            this.sheetsCSLFilterTextBox.Location = new System.Drawing.Point(294, 28);
            this.sheetsCSLFilterTextBox.Name = "sheetsCSLFilterTextBox";
            this.sheetsCSLFilterTextBox.Size = new System.Drawing.Size(236, 20);
            this.sheetsCSLFilterTextBox.TabIndex = 2;
            this.sheetsCSLFilterTextBox.Text = "<Search String>";
            this.sheetsCSLFilterTextBox.TextChanged += new System.EventHandler(this.SheetsCSLFilterTextBox_TextChanged);
            // 
            // sheetsCSLCopyFromLabel
            // 
            this.sheetsCSLCopyFromLabel.AutoSize = true;
            this.sheetsCSLCopyFromLabel.Location = new System.Drawing.Point(3, 7);
            this.sheetsCSLCopyFromLabel.Name = "sheetsCSLCopyFromLabel";
            this.sheetsCSLCopyFromLabel.Size = new System.Drawing.Size(136, 13);
            this.sheetsCSLCopyFromLabel.TabIndex = 0;
            this.sheetsCSLCopyFromLabel.Text = "Select Sheet to Copy From:";
            // 
            // sheetsCSLCopyToLabel
            // 
            this.sheetsCSLCopyToLabel.AutoSize = true;
            this.sheetsCSLCopyToLabel.Location = new System.Drawing.Point(3, 30);
            this.sheetsCSLCopyToLabel.Name = "sheetsCSLCopyToLabel";
            this.sheetsCSLCopyToLabel.Size = new System.Drawing.Size(131, 13);
            this.sheetsCSLCopyToLabel.TabIndex = 0;
            this.sheetsCSLCopyToLabel.Text = "Select Sheets to Copy To:";
            // 
            // sheetsCSLComboBox
            // 
            this.sheetsCSLComboBox.FormattingEnabled = true;
            this.sheetsCSLComboBox.Location = new System.Drawing.Point(155, 4);
            this.sheetsCSLComboBox.Name = "sheetsCSLComboBox";
            this.sheetsCSLComboBox.Size = new System.Drawing.Size(133, 21);
            this.sheetsCSLComboBox.TabIndex = 1;
            this.sheetsCSLComboBox.Text = "<Originating Sheet>";
            this.sheetsCSLComboBox.TextChanged += new System.EventHandler(this.SheetsCSLComboBox_TextChanged);
            // 
            // sheetsCSLInstructionsPanel
            // 
            this.sheetsCSLInstructionsPanel.Controls.Add(this.sheetsCSLInstructionsLabel);
            this.sheetsCSLInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSLInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSLInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSLInstructionsPanel.Name = "sheetsCSLInstructionsPanel";
            this.sheetsCSLInstructionsPanel.Size = new System.Drawing.Size(710, 42);
            this.sheetsCSLInstructionsPanel.TabIndex = 4;
            // 
            // sheetsCSLInstructionsLabel
            // 
            this.sheetsCSLInstructionsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.sheetsCSLInstructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheetsCSLInstructionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSLInstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSLInstructionsLabel.Name = "sheetsCSLInstructionsLabel";
            this.sheetsCSLInstructionsLabel.Size = new System.Drawing.Size(710, 42);
            this.sheetsCSLInstructionsLabel.TabIndex = 0;
            this.sheetsCSLInstructionsLabel.Text = "Instructions:\r\n1) Select the sheet to copy legends from; 2) Select the sheets to " +
    "copy legends to; 3) Click RUN to copy the legends.";
            // 
            // sheetsOSSLayoutPanel
            // 
            this.sheetsOSSLayoutPanel.ColumnCount = 2;
            this.sheetsOSSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsOSSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.sheetsOSSLayoutPanel.Controls.Add(this.sheetsOSSDataGridView, 0, 2);
            this.sheetsOSSLayoutPanel.Controls.Add(this.sheetsOSSInstructionsPanel, 0, 0);
            this.sheetsOSSLayoutPanel.Controls.Add(this.sheetsOSSFilterPanel, 0, 1);
            this.sheetsOSSLayoutPanel.Controls.Add(this.sheetsOSSNewSetPanel, 1, 1);
            this.sheetsOSSLayoutPanel.Controls.Add(this.sheetsOSSControlsPanel, 0, 3);
            this.sheetsOSSLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsOSSLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSLayoutPanel.Name = "sheetsOSSLayoutPanel";
            this.sheetsOSSLayoutPanel.RowCount = 4;
            this.sheetsOSSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.sheetsOSSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.sheetsOSSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsOSSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.sheetsOSSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.sheetsOSSLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.sheetsOSSLayoutPanel.TabIndex = 1;
            this.sheetsOSSLayoutPanel.Visible = false;
            // 
            // sheetsOSSDataGridView
            // 
            this.sheetsOSSDataGridView.AllowUserToAddRows = false;
            this.sheetsOSSDataGridView.AllowUserToDeleteRows = false;
            this.sheetsOSSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sheetsOSSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSDataGridView.Location = new System.Drawing.Point(0, 114);
            this.sheetsOSSDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSDataGridView.Name = "sheetsOSSDataGridView";
            this.sheetsOSSDataGridView.RowHeadersVisible = false;
            this.sheetsOSSDataGridView.Size = new System.Drawing.Size(529, 195);
            this.sheetsOSSDataGridView.TabIndex = 0;
            this.sheetsOSSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsOSSDataGridView_CellContentClick);
            // 
            // sheetsOSSInstructionsPanel
            // 
            this.sheetsOSSLayoutPanel.SetColumnSpan(this.sheetsOSSInstructionsPanel, 2);
            this.sheetsOSSInstructionsPanel.Controls.Add(this.sheetsOSSInstructionsTextBox);
            this.sheetsOSSInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsOSSInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSInstructionsPanel.Name = "sheetsOSSInstructionsPanel";
            this.sheetsOSSInstructionsPanel.Size = new System.Drawing.Size(710, 79);
            this.sheetsOSSInstructionsPanel.TabIndex = 1;
            // 
            // sheetsOSSInstructionsTextBox
            // 
            this.sheetsOSSInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.sheetsOSSInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.sheetsOSSInstructionsTextBox.Multiline = true;
            this.sheetsOSSInstructionsTextBox.Name = "sheetsOSSInstructionsTextBox";
            this.sheetsOSSInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sheetsOSSInstructionsTextBox.Size = new System.Drawing.Size(710, 79);
            this.sheetsOSSInstructionsTextBox.TabIndex = 0;
            this.sheetsOSSInstructionsTextBox.Text = resources.GetString("sheetsOSSInstructionsTextBox.Text");
            // 
            // sheetsOSSFilterPanel
            // 
            this.sheetsOSSFilterPanel.Controls.Add(this.sheetsOSSFilterFieldComboBox);
            this.sheetsOSSFilterPanel.Controls.Add(this.sheetsOSSFilterTextBox);
            this.sheetsOSSFilterPanel.Controls.Add(this.sheetsOSSFilterConditionComboBox);
            this.sheetsOSSFilterPanel.Controls.Add(this.sheetsOSSFilterLabel);
            this.sheetsOSSFilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSFilterPanel.Location = new System.Drawing.Point(0, 79);
            this.sheetsOSSFilterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSFilterPanel.Name = "sheetsOSSFilterPanel";
            this.sheetsOSSFilterPanel.Size = new System.Drawing.Size(529, 35);
            this.sheetsOSSFilterPanel.TabIndex = 4;
            // 
            // sheetsOSSFilterFieldComboBox
            // 
            this.sheetsOSSFilterFieldComboBox.FormattingEnabled = true;
            this.sheetsOSSFilterFieldComboBox.Items.AddRange(new object[] {
            "NUMBER",
            "NAME"});
            this.sheetsOSSFilterFieldComboBox.Location = new System.Drawing.Point(48, 7);
            this.sheetsOSSFilterFieldComboBox.Name = "sheetsOSSFilterFieldComboBox";
            this.sheetsOSSFilterFieldComboBox.Size = new System.Drawing.Size(72, 21);
            this.sheetsOSSFilterFieldComboBox.TabIndex = 4;
            this.sheetsOSSFilterFieldComboBox.Text = "<Field>";
            this.sheetsOSSFilterFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.SheetsOSSFilterFieldComboBox_SelectedIndexChanged);
            // 
            // sheetsOSSFilterTextBox
            // 
            this.sheetsOSSFilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsOSSFilterTextBox.Location = new System.Drawing.Point(265, 7);
            this.sheetsOSSFilterTextBox.Name = "sheetsOSSFilterTextBox";
            this.sheetsOSSFilterTextBox.Size = new System.Drawing.Size(201, 20);
            this.sheetsOSSFilterTextBox.TabIndex = 3;
            this.sheetsOSSFilterTextBox.Text = "<Search String>";
            this.sheetsOSSFilterTextBox.TextChanged += new System.EventHandler(this.SheetsOSSFilterTextBox_TextChanged);
            // 
            // sheetsOSSFilterConditionComboBox
            // 
            this.sheetsOSSFilterConditionComboBox.FormattingEnabled = true;
            this.sheetsOSSFilterConditionComboBox.Items.AddRange(new object[] {
            "CONTAINS",
            "DOES NOT CONTAIN"});
            this.sheetsOSSFilterConditionComboBox.Location = new System.Drawing.Point(126, 7);
            this.sheetsOSSFilterConditionComboBox.Name = "sheetsOSSFilterConditionComboBox";
            this.sheetsOSSFilterConditionComboBox.Size = new System.Drawing.Size(133, 21);
            this.sheetsOSSFilterConditionComboBox.TabIndex = 2;
            this.sheetsOSSFilterConditionComboBox.Text = "<Condition>";
            this.sheetsOSSFilterConditionComboBox.SelectedIndexChanged += new System.EventHandler(this.SheetsOSSFilterConditionComboBox_SelectedIndexChanged);
            // 
            // sheetsOSSFilterLabel
            // 
            this.sheetsOSSFilterLabel.AutoSize = true;
            this.sheetsOSSFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetsOSSFilterLabel.Location = new System.Drawing.Point(3, 12);
            this.sheetsOSSFilterLabel.Name = "sheetsOSSFilterLabel";
            this.sheetsOSSFilterLabel.Size = new System.Drawing.Size(39, 13);
            this.sheetsOSSFilterLabel.TabIndex = 1;
            this.sheetsOSSFilterLabel.Text = "Filter:";
            // 
            // sheetsOSSNewSetPanel
            // 
            this.sheetsOSSNewSetPanel.Controls.Add(this.sheetsOSSNewSetButton);
            this.sheetsOSSNewSetPanel.Controls.Add(this.sheetsOSSNewSetLabel);
            this.sheetsOSSNewSetPanel.Controls.Add(this.sheetsOSSNewSetTextBox);
            this.sheetsOSSNewSetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSNewSetPanel.Location = new System.Drawing.Point(529, 79);
            this.sheetsOSSNewSetPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSNewSetPanel.Name = "sheetsOSSNewSetPanel";
            this.sheetsOSSLayoutPanel.SetRowSpan(this.sheetsOSSNewSetPanel, 2);
            this.sheetsOSSNewSetPanel.Size = new System.Drawing.Size(181, 230);
            this.sheetsOSSNewSetPanel.TabIndex = 3;
            // 
            // sheetsOSSNewSetButton
            // 
            this.sheetsOSSNewSetButton.Location = new System.Drawing.Point(102, 60);
            this.sheetsOSSNewSetButton.Name = "sheetsOSSNewSetButton";
            this.sheetsOSSNewSetButton.Size = new System.Drawing.Size(75, 23);
            this.sheetsOSSNewSetButton.TabIndex = 2;
            this.sheetsOSSNewSetButton.Text = "Add Set";
            this.sheetsOSSNewSetButton.UseVisualStyleBackColor = true;
            this.sheetsOSSNewSetButton.Click += new System.EventHandler(this.SheetsOSSNewSetButton_Click);
            // 
            // sheetsOSSNewSetLabel
            // 
            this.sheetsOSSNewSetLabel.AutoSize = true;
            this.sheetsOSSNewSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetsOSSNewSetLabel.Location = new System.Drawing.Point(5, 12);
            this.sheetsOSSNewSetLabel.Name = "sheetsOSSNewSetLabel";
            this.sheetsOSSNewSetLabel.Size = new System.Drawing.Size(85, 13);
            this.sheetsOSSNewSetLabel.TabIndex = 1;
            this.sheetsOSSNewSetLabel.Text = "Add New Set:";
            // 
            // sheetsOSSNewSetTextBox
            // 
            this.sheetsOSSNewSetTextBox.Location = new System.Drawing.Point(5, 34);
            this.sheetsOSSNewSetTextBox.Name = "sheetsOSSNewSetTextBox";
            this.sheetsOSSNewSetTextBox.Size = new System.Drawing.Size(173, 20);
            this.sheetsOSSNewSetTextBox.TabIndex = 0;
            this.sheetsOSSNewSetTextBox.Text = "<New Set Name>";
            // 
            // sheetsOSSControlsPanel
            // 
            this.sheetsOSSLayoutPanel.SetColumnSpan(this.sheetsOSSControlsPanel, 2);
            this.sheetsOSSControlsPanel.Controls.Add(this.sheetsOSSRunButton);
            this.sheetsOSSControlsPanel.Controls.Add(this.sheetsOSSRunLabel);
            this.sheetsOSSControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsOSSControlsPanel.Location = new System.Drawing.Point(0, 309);
            this.sheetsOSSControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsOSSControlsPanel.Name = "sheetsOSSControlsPanel";
            this.sheetsOSSControlsPanel.Size = new System.Drawing.Size(710, 30);
            this.sheetsOSSControlsPanel.TabIndex = 2;
            // 
            // sheetsOSSRunButton
            // 
            this.sheetsOSSRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsOSSRunButton.Location = new System.Drawing.Point(631, 4);
            this.sheetsOSSRunButton.Name = "sheetsOSSRunButton";
            this.sheetsOSSRunButton.Size = new System.Drawing.Size(75, 23);
            this.sheetsOSSRunButton.TabIndex = 1;
            this.sheetsOSSRunButton.Text = "RUN";
            this.sheetsOSSRunButton.UseVisualStyleBackColor = true;
            this.sheetsOSSRunButton.Click += new System.EventHandler(this.SheetsOSSRunButton_Click);
            // 
            // sheetsOSSRunLabel
            // 
            this.sheetsOSSRunLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsOSSRunLabel.AutoSize = true;
            this.sheetsOSSRunLabel.Location = new System.Drawing.Point(557, 9);
            this.sheetsOSSRunLabel.Name = "sheetsOSSRunLabel";
            this.sheetsOSSRunLabel.Size = new System.Drawing.Size(69, 13);
            this.sheetsOSSRunLabel.TabIndex = 0;
            this.sheetsOSSRunLabel.Text = "Update Sets:";
            // 
            // sheetsISFLLayoutPanel
            // 
            this.sheetsISFLLayoutPanel.ColumnCount = 2;
            this.sheetsISFLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsISFLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224F));
            this.sheetsISFLLayoutPanel.Controls.Add(this.sheetsISFLInstructionsPanel, 0, 0);
            this.sheetsISFLLayoutPanel.Controls.Add(this.sheetsISFLRunButton, 0, 3);
            this.sheetsISFLLayoutPanel.Controls.Add(this.sheetsISFLDataGridView, 0, 2);
            this.sheetsISFLLayoutPanel.Controls.Add(this.sheetsISFLControlsPanel, 0, 1);
            this.sheetsISFLLayoutPanel.Controls.Add(this.sheetsIFSLDisciplinePanel, 1, 2);
            this.sheetsISFLLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsISFLLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsISFLLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsISFLLayoutPanel.Name = "sheetsISFLLayoutPanel";
            this.sheetsISFLLayoutPanel.RowCount = 4;
            this.sheetsISFLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.sheetsISFLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.sheetsISFLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sheetsISFLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.sheetsISFLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.sheetsISFLLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.sheetsISFLLayoutPanel.TabIndex = 3;
            this.sheetsISFLLayoutPanel.Visible = false;
            // 
            // sheetsISFLInstructionsPanel
            // 
            this.sheetsISFLLayoutPanel.SetColumnSpan(this.sheetsISFLInstructionsPanel, 2);
            this.sheetsISFLInstructionsPanel.Controls.Add(this.sheetsISFLInstructionsLabel);
            this.sheetsISFLInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsISFLInstructionsPanel.Location = new System.Drawing.Point(3, 3);
            this.sheetsISFLInstructionsPanel.Name = "sheetsISFLInstructionsPanel";
            this.sheetsISFLInstructionsPanel.Size = new System.Drawing.Size(704, 55);
            this.sheetsISFLInstructionsPanel.TabIndex = 5;
            // 
            // sheetsISFLInstructionsLabel
            // 
            this.sheetsISFLInstructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheetsISFLInstructionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsISFLInstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.sheetsISFLInstructionsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsISFLInstructionsLabel.Name = "sheetsISFLInstructionsLabel";
            this.sheetsISFLInstructionsLabel.Size = new System.Drawing.Size(704, 55);
            this.sheetsISFLInstructionsLabel.TabIndex = 0;
            this.sheetsISFLInstructionsLabel.Text = resources.GetString("sheetsISFLInstructionsLabel.Text");
            // 
            // sheetsISFLRunButton
            // 
            this.sheetsISFLRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sheetsISFLRunButton.Location = new System.Drawing.Point(3, 313);
            this.sheetsISFLRunButton.Name = "sheetsISFLRunButton";
            this.sheetsISFLRunButton.Size = new System.Drawing.Size(65, 23);
            this.sheetsISFLRunButton.TabIndex = 2;
            this.sheetsISFLRunButton.Text = "RUN";
            this.sheetsISFLRunButton.UseVisualStyleBackColor = true;
            this.sheetsISFLRunButton.Click += new System.EventHandler(this.SheetsISFLRunButton_Click);
            // 
            // sheetsISFLDataGridView
            // 
            this.sheetsISFLDataGridView.AllowUserToAddRows = false;
            this.sheetsISFLDataGridView.AllowUserToDeleteRows = false;
            this.sheetsISFLDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sheetsISFLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sheetsISFLDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsISFLDataGridView.Location = new System.Drawing.Point(0, 119);
            this.sheetsISFLDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsISFLDataGridView.Name = "sheetsISFLDataGridView";
            this.sheetsISFLDataGridView.Size = new System.Drawing.Size(486, 191);
            this.sheetsISFLDataGridView.TabIndex = 1;
            this.sheetsISFLDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SheetsISFLDataGridView_CellContentClick);
            // 
            // sheetsISFLControlsPanel
            // 
            this.sheetsISFLLayoutPanel.SetColumnSpan(this.sheetsISFLControlsPanel, 2);
            this.sheetsISFLControlsPanel.Controls.Add(this.sheetsISFLComboBox);
            this.sheetsISFLControlsPanel.Controls.Add(this.sheetsISFLLabel1);
            this.sheetsISFLControlsPanel.Controls.Add(this.sheetsISFLLabel2);
            this.sheetsISFLControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsISFLControlsPanel.Location = new System.Drawing.Point(0, 61);
            this.sheetsISFLControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsISFLControlsPanel.Name = "sheetsISFLControlsPanel";
            this.sheetsISFLControlsPanel.Size = new System.Drawing.Size(710, 58);
            this.sheetsISFLControlsPanel.TabIndex = 4;
            // 
            // sheetsISFLComboBox
            // 
            this.sheetsISFLComboBox.FormattingEnabled = true;
            this.sheetsISFLComboBox.Location = new System.Drawing.Point(137, 4);
            this.sheetsISFLComboBox.Name = "sheetsISFLComboBox";
            this.sheetsISFLComboBox.Size = new System.Drawing.Size(250, 21);
            this.sheetsISFLComboBox.TabIndex = 1;
            this.sheetsISFLComboBox.Text = "<Originating Link>";
            this.sheetsISFLComboBox.TextChanged += new System.EventHandler(this.SheetsISFLComboBox_TextChanged);
            // 
            // sheetsISFLLabel1
            // 
            this.sheetsISFLLabel1.AutoSize = true;
            this.sheetsISFLLabel1.Location = new System.Drawing.Point(3, 7);
            this.sheetsISFLLabel1.Name = "sheetsISFLLabel1";
            this.sheetsISFLLabel1.Size = new System.Drawing.Size(128, 13);
            this.sheetsISFLLabel1.TabIndex = 0;
            this.sheetsISFLLabel1.Text = "Select Link to Copy From:";
            // 
            // sheetsISFLLabel2
            // 
            this.sheetsISFLLabel2.AutoSize = true;
            this.sheetsISFLLabel2.Location = new System.Drawing.Point(3, 39);
            this.sheetsISFLLabel2.Name = "sheetsISFLLabel2";
            this.sheetsISFLLabel2.Size = new System.Drawing.Size(117, 13);
            this.sheetsISFLLabel2.TabIndex = 0;
            this.sheetsISFLLabel2.Text = "Select Sheets to Insert:";
            // 
            // sheetsIFSLDisciplinePanel
            // 
            this.sheetsIFSLDisciplinePanel.Controls.Add(this.sheetsISFLDisciplineUpdateButton);
            this.sheetsIFSLDisciplinePanel.Controls.Add(this.sheetsISFLDisciplineComboBox);
            this.sheetsIFSLDisciplinePanel.Controls.Add(this.sheetsISFLDisciplineLabel);
            this.sheetsIFSLDisciplinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsIFSLDisciplinePanel.Location = new System.Drawing.Point(486, 119);
            this.sheetsIFSLDisciplinePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsIFSLDisciplinePanel.Name = "sheetsIFSLDisciplinePanel";
            this.sheetsISFLLayoutPanel.SetRowSpan(this.sheetsIFSLDisciplinePanel, 2);
            this.sheetsIFSLDisciplinePanel.Size = new System.Drawing.Size(224, 220);
            this.sheetsIFSLDisciplinePanel.TabIndex = 2;
            // 
            // sheetsISFLDisciplineUpdateButton
            // 
            this.sheetsISFLDisciplineUpdateButton.Location = new System.Drawing.Point(3, 49);
            this.sheetsISFLDisciplineUpdateButton.Name = "sheetsISFLDisciplineUpdateButton";
            this.sheetsISFLDisciplineUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.sheetsISFLDisciplineUpdateButton.TabIndex = 2;
            this.sheetsISFLDisciplineUpdateButton.Text = "UPDATE";
            this.sheetsISFLDisciplineUpdateButton.UseVisualStyleBackColor = true;
            this.sheetsISFLDisciplineUpdateButton.Click += new System.EventHandler(this.SheetsISFLDisciplineUpdateButton_Click);
            // 
            // sheetsISFLDisciplineComboBox
            // 
            this.sheetsISFLDisciplineComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsISFLDisciplineComboBox.FormattingEnabled = true;
            this.sheetsISFLDisciplineComboBox.Location = new System.Drawing.Point(3, 22);
            this.sheetsISFLDisciplineComboBox.Name = "sheetsISFLDisciplineComboBox";
            this.sheetsISFLDisciplineComboBox.Size = new System.Drawing.Size(217, 21);
            this.sheetsISFLDisciplineComboBox.TabIndex = 1;
            this.sheetsISFLDisciplineComboBox.Tag = "";
            this.sheetsISFLDisciplineComboBox.Text = "<Select BA Discipline>";
            // 
            // sheetsISFLDisciplineLabel
            // 
            this.sheetsISFLDisciplineLabel.AutoSize = true;
            this.sheetsISFLDisciplineLabel.Location = new System.Drawing.Point(4, 4);
            this.sheetsISFLDisciplineLabel.Name = "sheetsISFLDisciplineLabel";
            this.sheetsISFLDisciplineLabel.Size = new System.Drawing.Size(117, 13);
            this.sheetsISFLDisciplineLabel.TabIndex = 0;
            this.sheetsISFLDisciplineLabel.Text = "BA Discipline To Apply:";
            // 
            // sheetsCSSFSLayoutPanel
            // 
            this.sheetsCSSFSLayoutPanel.ColumnCount = 1;
            this.sheetsCSSFSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sheetsCSSFSLayoutPanel.Controls.Add(this.sheetsCSSFSInstructionsPanel, 0, 0);
            this.sheetsCSSFSLayoutPanel.Controls.Add(this.sheetsCSSFSControlsPanel, 0, 1);
            this.sheetsCSSFSLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSSFSLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSSFSLayoutPanel.Name = "sheetsCSSFSLayoutPanel";
            this.sheetsCSSFSLayoutPanel.RowCount = 2;
            this.sheetsCSSFSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.91931F));
            this.sheetsCSSFSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.08069F));
            this.sheetsCSSFSLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.sheetsCSSFSLayoutPanel.TabIndex = 1;
            this.sheetsCSSFSLayoutPanel.Visible = false;
            // 
            // sheetsCSSFSInstructionsPanel
            // 
            this.sheetsCSSFSInstructionsPanel.Controls.Add(this.sheetsCSSFSInstructionsTextBox);
            this.sheetsCSSFSInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSSFSInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSSFSInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSSFSInstructionsPanel.Name = "sheetsCSSFSInstructionsPanel";
            this.sheetsCSSFSInstructionsPanel.Size = new System.Drawing.Size(710, 81);
            this.sheetsCSSFSInstructionsPanel.TabIndex = 0;
            // 
            // sheetsCSSFSInstructionsTextBox
            // 
            this.sheetsCSSFSInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.sheetsCSSFSInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSSFSInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.sheetsCSSFSInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSSFSInstructionsTextBox.Multiline = true;
            this.sheetsCSSFSInstructionsTextBox.Name = "sheetsCSSFSInstructionsTextBox";
            this.sheetsCSSFSInstructionsTextBox.Size = new System.Drawing.Size(710, 81);
            this.sheetsCSSFSInstructionsTextBox.TabIndex = 0;
            this.sheetsCSSFSInstructionsTextBox.Text = "Instructions:\r\n1) Set the sheet set name\r\n2) Select the sheet schedule to make th" +
    "e set from\r\n\r\nThis script will make new sheet sets using the visible sheets in a" +
    " sheet schedule.";
            // 
            // sheetsCSSFSControlsPanel
            // 
            this.sheetsCSSFSControlsPanel.Controls.Add(this.sheetsCSSFSSScheduleLabel);
            this.sheetsCSSFSControlsPanel.Controls.Add(this.sheetsCSSFSSetNameLabel);
            this.sheetsCSSFSControlsPanel.Controls.Add(this.sheetsCSSFSSetNameTextBox);
            this.sheetsCSSFSControlsPanel.Controls.Add(this.sheetsCSSFSScheduleComboBox);
            this.sheetsCSSFSControlsPanel.Controls.Add(this.sheetsCSSFSRunButton);
            this.sheetsCSSFSControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetsCSSFSControlsPanel.Location = new System.Drawing.Point(0, 81);
            this.sheetsCSSFSControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sheetsCSSFSControlsPanel.Name = "sheetsCSSFSControlsPanel";
            this.sheetsCSSFSControlsPanel.Size = new System.Drawing.Size(710, 258);
            this.sheetsCSSFSControlsPanel.TabIndex = 1;
            // 
            // sheetsCSSFSSScheduleLabel
            // 
            this.sheetsCSSFSSScheduleLabel.AutoSize = true;
            this.sheetsCSSFSSScheduleLabel.Location = new System.Drawing.Point(3, 38);
            this.sheetsCSSFSSScheduleLabel.Name = "sheetsCSSFSSScheduleLabel";
            this.sheetsCSSFSSScheduleLabel.Size = new System.Drawing.Size(93, 13);
            this.sheetsCSSFSSScheduleLabel.TabIndex = 4;
            this.sheetsCSSFSSScheduleLabel.Text = "Schedule To Use:";
            // 
            // sheetsCSSFSSetNameLabel
            // 
            this.sheetsCSSFSSetNameLabel.AutoSize = true;
            this.sheetsCSSFSSetNameLabel.Location = new System.Drawing.Point(3, 12);
            this.sheetsCSSFSSetNameLabel.Name = "sheetsCSSFSSetNameLabel";
            this.sheetsCSSFSSetNameLabel.Size = new System.Drawing.Size(88, 13);
            this.sheetsCSSFSSetNameLabel.TabIndex = 4;
            this.sheetsCSSFSSetNameLabel.Text = "Sheet Set Name:";
            // 
            // sheetsCSSFSSetNameTextBox
            // 
            this.sheetsCSSFSSetNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsCSSFSSetNameTextBox.Location = new System.Drawing.Point(102, 8);
            this.sheetsCSSFSSetNameTextBox.Name = "sheetsCSSFSSetNameTextBox";
            this.sheetsCSSFSSetNameTextBox.Size = new System.Drawing.Size(479, 20);
            this.sheetsCSSFSSetNameTextBox.TabIndex = 3;
            this.sheetsCSSFSSetNameTextBox.Text = "<Sheet Set Name>";
            // 
            // sheetsCSSFSScheduleComboBox
            // 
            this.sheetsCSSFSScheduleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetsCSSFSScheduleComboBox.FormattingEnabled = true;
            this.sheetsCSSFSScheduleComboBox.Location = new System.Drawing.Point(102, 35);
            this.sheetsCSSFSScheduleComboBox.Name = "sheetsCSSFSScheduleComboBox";
            this.sheetsCSSFSScheduleComboBox.Size = new System.Drawing.Size(479, 21);
            this.sheetsCSSFSScheduleComboBox.TabIndex = 2;
            this.sheetsCSSFSScheduleComboBox.Text = "<Schedule Name>";
            // 
            // sheetsCSSFSRunButton
            // 
            this.sheetsCSSFSRunButton.Location = new System.Drawing.Point(3, 74);
            this.sheetsCSSFSRunButton.Name = "sheetsCSSFSRunButton";
            this.sheetsCSSFSRunButton.Size = new System.Drawing.Size(75, 23);
            this.sheetsCSSFSRunButton.TabIndex = 1;
            this.sheetsCSSFSRunButton.Text = "RUN";
            this.sheetsCSSFSRunButton.UseVisualStyleBackColor = true;
            this.sheetsCSSFSRunButton.Click += new System.EventHandler(this.SheetsCSSFSRunButton_Click);
            // 
            // viewsTab
            // 
            this.viewsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewsTab.Controls.Add(this.viewsTabLayoutPanel);
            this.viewsTab.Location = new System.Drawing.Point(4, 25);
            this.viewsTab.Margin = new System.Windows.Forms.Padding(0);
            this.viewsTab.Name = "viewsTab";
            this.viewsTab.Padding = new System.Windows.Forms.Padding(3);
            this.viewsTab.Size = new System.Drawing.Size(720, 402);
            this.viewsTab.TabIndex = 1;
            this.viewsTab.Text = "Views";
            this.viewsTab.UseVisualStyleBackColor = true;
            // 
            // viewsTabLayoutPanel
            // 
            this.viewsTabLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.viewsTabLayoutPanel.ColumnCount = 1;
            this.viewsTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsTabLayoutPanel.Controls.Add(this.viewsToolStrip, 0, 0);
            this.viewsTabLayoutPanel.Controls.Add(this.viewsToolsPanel, 0, 1);
            this.viewsTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.viewsTabLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsTabLayoutPanel.Name = "viewsTabLayoutPanel";
            this.viewsTabLayoutPanel.RowCount = 2;
            this.viewsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.viewsTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsTabLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.viewsTabLayoutPanel.TabIndex = 14;
            // 
            // viewsToolStrip
            // 
            this.viewsToolStrip.AutoSize = false;
            this.viewsToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.viewsToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.viewsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewsCEPRButton,
            this.viewsSeparator1,
            this.viewsInteriorCropButton});
            this.viewsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.viewsToolStrip.Name = "viewsToolStrip";
            this.viewsToolStrip.Size = new System.Drawing.Size(710, 53);
            this.viewsToolStrip.Stretch = true;
            this.viewsToolStrip.TabIndex = 1;
            this.viewsToolStrip.Text = "toolStrip1";
            // 
            // viewsCEPRButton
            // 
            this.viewsCEPRButton.Image = ((System.Drawing.Image)(resources.GetObject("viewsCEPRButton.Image")));
            this.viewsCEPRButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewsCEPRButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewsCEPRButton.Name = "viewsCEPRButton";
            this.viewsCEPRButton.Size = new System.Drawing.Size(101, 50);
            this.viewsCEPRButton.Text = "Create Elevations";
            this.viewsCEPRButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.viewsCEPRButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.viewsCEPRButton.ToolTipText = "Create Elevations Per Room: Create elevations by selecting rooms";
            this.viewsCEPRButton.Click += new System.EventHandler(this.ViewsCEPR_Click);
            // 
            // viewsSeparator1
            // 
            this.viewsSeparator1.Name = "viewsSeparator1";
            this.viewsSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // viewsInteriorCropButton
            // 
            this.viewsInteriorCropButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewsOICBButton,
            this.viewsHNIECButton});
            this.viewsInteriorCropButton.Image = ((System.Drawing.Image)(resources.GetObject("viewsInteriorCropButton.Image")));
            this.viewsInteriorCropButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewsInteriorCropButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewsInteriorCropButton.Name = "viewsInteriorCropButton";
            this.viewsInteriorCropButton.Size = new System.Drawing.Size(121, 50);
            this.viewsInteriorCropButton.Text = "Interior Crop Tools";
            this.viewsInteriorCropButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.viewsInteriorCropButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.viewsInteriorCropButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // viewsOICBButton
            // 
            this.viewsOICBButton.Image = ((System.Drawing.Image)(resources.GetObject("viewsOICBButton.Image")));
            this.viewsOICBButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewsOICBButton.Name = "viewsOICBButton";
            this.viewsOICBButton.Size = new System.Drawing.Size(264, 38);
            this.viewsOICBButton.Text = "Override Interior Crop Boundary";
            this.viewsOICBButton.ToolTipText = "Override Interior Crop Boundary: Overrides the interior elevation crop boundaries" +
    " with the standard line weight";
            this.viewsOICBButton.Click += new System.EventHandler(this.ViewsOICBButton_Click);
            // 
            // viewsHNIECButton
            // 
            this.viewsHNIECButton.Image = ((System.Drawing.Image)(resources.GetObject("viewsHNIECButton.Image")));
            this.viewsHNIECButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewsHNIECButton.Name = "viewsHNIECButton";
            this.viewsHNIECButton.Size = new System.Drawing.Size(264, 38);
            this.viewsHNIECButton.Text = "Hide Non-Interior Elevation Crop";
            this.viewsHNIECButton.ToolTipText = "Hide Non-Interior Elevation Crop: Hides the crop boundaries of elevation views th" +
    "at don\'t contain \"Interior\" in the type name.";
            this.viewsHNIECButton.Click += new System.EventHandler(this.ViewsHNIECButton_Click);
            // 
            // viewsToolsPanel
            // 
            this.viewsToolsPanel.Controls.Add(this.viewsCEPRLayoutPanel);
            this.viewsToolsPanel.Controls.Add(this.viewsHNIECLayoutPanel);
            this.viewsToolsPanel.Controls.Add(this.viewsOICBLayoutPanel);
            this.viewsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.viewsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsToolsPanel.Name = "viewsToolsPanel";
            this.viewsToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.viewsToolsPanel.TabIndex = 2;
            // 
            // viewsCEPRLayoutPanel
            // 
            this.viewsCEPRLayoutPanel.ColumnCount = 1;
            this.viewsCEPRLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsCEPRLayoutPanel.Controls.Add(this.viewsCEPRControlsPanel, 0, 2);
            this.viewsCEPRLayoutPanel.Controls.Add(this.viewsCEPRInstructionsPanel, 0, 0);
            this.viewsCEPRLayoutPanel.Controls.Add(this.viewsCEPRUrlPanel, 0, 1);
            this.viewsCEPRLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsCEPRLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsCEPRLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsCEPRLayoutPanel.Name = "viewsCEPRLayoutPanel";
            this.viewsCEPRLayoutPanel.RowCount = 3;
            this.viewsCEPRLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsCEPRLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.viewsCEPRLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.viewsCEPRLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.viewsCEPRLayoutPanel.TabIndex = 6;
            this.viewsCEPRLayoutPanel.Visible = false;
            // 
            // viewsCEPRControlsPanel
            // 
            this.viewsCEPRControlsPanel.Controls.Add(this.viewsCEPRRunButton);
            this.viewsCEPRControlsPanel.Controls.Add(this.viewsCEPROverrideCheckBox);
            this.viewsCEPRControlsPanel.Controls.Add(this.viewsCEPRCropCheckBox);
            this.viewsCEPRControlsPanel.Controls.Add(this.viewsCEPRElevationComboBox);
            this.viewsCEPRControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsCEPRControlsPanel.Location = new System.Drawing.Point(0, 214);
            this.viewsCEPRControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsCEPRControlsPanel.Name = "viewsCEPRControlsPanel";
            this.viewsCEPRControlsPanel.Size = new System.Drawing.Size(710, 125);
            this.viewsCEPRControlsPanel.TabIndex = 2;
            // 
            // viewsCEPRRunButton
            // 
            this.viewsCEPRRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsCEPRRunButton.Location = new System.Drawing.Point(5, 79);
            this.viewsCEPRRunButton.Name = "viewsCEPRRunButton";
            this.viewsCEPRRunButton.Size = new System.Drawing.Size(65, 25);
            this.viewsCEPRRunButton.TabIndex = 13;
            this.viewsCEPRRunButton.Text = "RUN";
            this.viewsCEPRRunButton.UseVisualStyleBackColor = true;
            this.viewsCEPRRunButton.Click += new System.EventHandler(this.ViewsCEPRRunButton_Click);
            // 
            // viewsCEPROverrideCheckBox
            // 
            this.viewsCEPROverrideCheckBox.AutoSize = true;
            this.viewsCEPROverrideCheckBox.Location = new System.Drawing.Point(5, 55);
            this.viewsCEPROverrideCheckBox.Name = "viewsCEPROverrideCheckBox";
            this.viewsCEPROverrideCheckBox.Size = new System.Drawing.Size(158, 17);
            this.viewsCEPROverrideCheckBox.TabIndex = 12;
            this.viewsCEPROverrideCheckBox.Text = "Override Viewport Boundary";
            this.viewsCEPROverrideCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewsCEPRCropCheckBox
            // 
            this.viewsCEPRCropCheckBox.AutoSize = true;
            this.viewsCEPRCropCheckBox.Location = new System.Drawing.Point(5, 30);
            this.viewsCEPRCropCheckBox.Name = "viewsCEPRCropCheckBox";
            this.viewsCEPRCropCheckBox.Size = new System.Drawing.Size(140, 17);
            this.viewsCEPRCropCheckBox.TabIndex = 12;
            this.viewsCEPRCropCheckBox.Text = "Crop Viewport Boundary";
            this.viewsCEPRCropCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewsCEPRElevationComboBox
            // 
            this.viewsCEPRElevationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewsCEPRElevationComboBox.FormattingEnabled = true;
            this.viewsCEPRElevationComboBox.Location = new System.Drawing.Point(5, 5);
            this.viewsCEPRElevationComboBox.MinimumSize = new System.Drawing.Size(150, 0);
            this.viewsCEPRElevationComboBox.Name = "viewsCEPRElevationComboBox";
            this.viewsCEPRElevationComboBox.Size = new System.Drawing.Size(153, 21);
            this.viewsCEPRElevationComboBox.TabIndex = 10;
            this.viewsCEPRElevationComboBox.Text = "<Select Elevation Type>";
            // 
            // viewsCEPRInstructionsPanel
            // 
            this.viewsCEPRInstructionsPanel.Controls.Add(this.viewsCEPRInstructionsTextBox);
            this.viewsCEPRInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsCEPRInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsCEPRInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsCEPRInstructionsPanel.Name = "viewsCEPRInstructionsPanel";
            this.viewsCEPRInstructionsPanel.Size = new System.Drawing.Size(710, 184);
            this.viewsCEPRInstructionsPanel.TabIndex = 0;
            // 
            // viewsCEPRInstructionsTextBox
            // 
            this.viewsCEPRInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.viewsCEPRInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsCEPRInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.viewsCEPRInstructionsTextBox.Multiline = true;
            this.viewsCEPRInstructionsTextBox.Name = "viewsCEPRInstructionsTextBox";
            this.viewsCEPRInstructionsTextBox.ReadOnly = true;
            this.viewsCEPRInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewsCEPRInstructionsTextBox.Size = new System.Drawing.Size(710, 184);
            this.viewsCEPRInstructionsTextBox.TabIndex = 14;
            this.viewsCEPRInstructionsTextBox.Text = resources.GetString("viewsCEPRInstructionsTextBox.Text");
            // 
            // viewsCEPRUrlPanel
            // 
            this.viewsCEPRUrlPanel.Controls.Add(this.viewsCEPRUrlLabel);
            this.viewsCEPRUrlPanel.Controls.Add(this.viewsCEPRUrlLinkLabel);
            this.viewsCEPRUrlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsCEPRUrlPanel.Location = new System.Drawing.Point(0, 184);
            this.viewsCEPRUrlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsCEPRUrlPanel.Name = "viewsCEPRUrlPanel";
            this.viewsCEPRUrlPanel.Size = new System.Drawing.Size(710, 30);
            this.viewsCEPRUrlPanel.TabIndex = 3;
            // 
            // viewsCEPRUrlLabel
            // 
            this.viewsCEPRUrlLabel.AutoSize = true;
            this.viewsCEPRUrlLabel.Location = new System.Drawing.Point(152, 8);
            this.viewsCEPRUrlLabel.Name = "viewsCEPRUrlLabel";
            this.viewsCEPRUrlLabel.Size = new System.Drawing.Size(393, 13);
            this.viewsCEPRUrlLabel.TabIndex = 1;
            this.viewsCEPRUrlLabel.Text = "(Video showing how to use the Dynamo version of this tool. Same principles apply)" +
    "";
            // 
            // viewsCEPRUrlLinkLabel
            // 
            this.viewsCEPRUrlLinkLabel.AutoSize = true;
            this.viewsCEPRUrlLinkLabel.Location = new System.Drawing.Point(5, 8);
            this.viewsCEPRUrlLinkLabel.Margin = new System.Windows.Forms.Padding(5);
            this.viewsCEPRUrlLinkLabel.Name = "viewsCEPRUrlLinkLabel";
            this.viewsCEPRUrlLinkLabel.Size = new System.Drawing.Size(139, 13);
            this.viewsCEPRUrlLinkLabel.TabIndex = 0;
            this.viewsCEPRUrlLinkLabel.TabStop = true;
            this.viewsCEPRUrlLinkLabel.Text = "Automate Interior Elevations";
            this.viewsCEPRUrlLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewsCEPRUrlLinkLabel_LinkClicked);
            // 
            // viewsHNIECLayoutPanel
            // 
            this.viewsHNIECLayoutPanel.ColumnCount = 1;
            this.viewsHNIECLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsHNIECLayoutPanel.Controls.Add(this.viewsHNIECInstructionsPanel, 0, 0);
            this.viewsHNIECLayoutPanel.Controls.Add(this.viewsHNIECControlsPanel, 0, 1);
            this.viewsHNIECLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsHNIECLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsHNIECLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsHNIECLayoutPanel.Name = "viewsHNIECLayoutPanel";
            this.viewsHNIECLayoutPanel.RowCount = 2;
            this.viewsHNIECLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.viewsHNIECLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsHNIECLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.viewsHNIECLayoutPanel.TabIndex = 15;
            this.viewsHNIECLayoutPanel.Visible = false;
            // 
            // viewsHNIECInstructionsPanel
            // 
            this.viewsHNIECInstructionsPanel.Controls.Add(this.viewsHNIECBInstructions);
            this.viewsHNIECInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsHNIECInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsHNIECInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsHNIECInstructionsPanel.Name = "viewsHNIECInstructionsPanel";
            this.viewsHNIECInstructionsPanel.Size = new System.Drawing.Size(710, 40);
            this.viewsHNIECInstructionsPanel.TabIndex = 0;
            // 
            // viewsHNIECBInstructions
            // 
            this.viewsHNIECBInstructions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewsHNIECBInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsHNIECBInstructions.Location = new System.Drawing.Point(0, 0);
            this.viewsHNIECBInstructions.Margin = new System.Windows.Forms.Padding(5);
            this.viewsHNIECBInstructions.Name = "viewsHNIECBInstructions";
            this.viewsHNIECBInstructions.Padding = new System.Windows.Forms.Padding(5);
            this.viewsHNIECBInstructions.Size = new System.Drawing.Size(710, 40);
            this.viewsHNIECBInstructions.TabIndex = 8;
            this.viewsHNIECBInstructions.Text = "This script will turn off the crop boundaries of elevation views without \"Interio" +
    "r\" in their viewport type name.";
            // 
            // viewsHNIECControlsPanel
            // 
            this.viewsHNIECControlsPanel.Controls.Add(this.viewsHNIECBRunButton);
            this.viewsHNIECControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsHNIECControlsPanel.Location = new System.Drawing.Point(0, 40);
            this.viewsHNIECControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsHNIECControlsPanel.Name = "viewsHNIECControlsPanel";
            this.viewsHNIECControlsPanel.Size = new System.Drawing.Size(710, 299);
            this.viewsHNIECControlsPanel.TabIndex = 1;
            // 
            // viewsHNIECBRunButton
            // 
            this.viewsHNIECBRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsHNIECBRunButton.Location = new System.Drawing.Point(5, 5);
            this.viewsHNIECBRunButton.Name = "viewsHNIECBRunButton";
            this.viewsHNIECBRunButton.Size = new System.Drawing.Size(65, 25);
            this.viewsHNIECBRunButton.TabIndex = 13;
            this.viewsHNIECBRunButton.Text = "RUN";
            this.viewsHNIECBRunButton.UseVisualStyleBackColor = true;
            this.viewsHNIECBRunButton.Click += new System.EventHandler(this.ViewsHNIECBRunButton_Click);
            // 
            // viewsOICBLayoutPanel
            // 
            this.viewsOICBLayoutPanel.ColumnCount = 1;
            this.viewsOICBLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsOICBLayoutPanel.Controls.Add(this.viewsOICBInstructionsPanel, 0, 0);
            this.viewsOICBLayoutPanel.Controls.Add(this.viewsOICBControlsPanel, 0, 1);
            this.viewsOICBLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsOICBLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsOICBLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsOICBLayoutPanel.Name = "viewsOICBLayoutPanel";
            this.viewsOICBLayoutPanel.RowCount = 2;
            this.viewsOICBLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.viewsOICBLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsOICBLayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.viewsOICBLayoutPanel.TabIndex = 6;
            this.viewsOICBLayoutPanel.Visible = false;
            // 
            // viewsOICBInstructionsPanel
            // 
            this.viewsOICBInstructionsPanel.Controls.Add(this.viewsOICBInstructionsLabel);
            this.viewsOICBInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsOICBInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.viewsOICBInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsOICBInstructionsPanel.Name = "viewsOICBInstructionsPanel";
            this.viewsOICBInstructionsPanel.Size = new System.Drawing.Size(710, 40);
            this.viewsOICBInstructionsPanel.TabIndex = 0;
            // 
            // viewsOICBInstructionsLabel
            // 
            this.viewsOICBInstructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewsOICBInstructionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsOICBInstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.viewsOICBInstructionsLabel.Margin = new System.Windows.Forms.Padding(5);
            this.viewsOICBInstructionsLabel.Name = "viewsOICBInstructionsLabel";
            this.viewsOICBInstructionsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.viewsOICBInstructionsLabel.Size = new System.Drawing.Size(710, 40);
            this.viewsOICBInstructionsLabel.TabIndex = 8;
            this.viewsOICBInstructionsLabel.Text = "This script will override the crop boundary of Interior Elevation type viewports " +
    "to match the standard.";
            // 
            // viewsOICBControlsPanel
            // 
            this.viewsOICBControlsPanel.Controls.Add(this.elemViewsOCIBRunButton);
            this.viewsOICBControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewsOICBControlsPanel.Location = new System.Drawing.Point(0, 40);
            this.viewsOICBControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewsOICBControlsPanel.Name = "viewsOICBControlsPanel";
            this.viewsOICBControlsPanel.Size = new System.Drawing.Size(710, 299);
            this.viewsOICBControlsPanel.TabIndex = 1;
            // 
            // elemViewsOCIBRunButton
            // 
            this.elemViewsOCIBRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elemViewsOCIBRunButton.Location = new System.Drawing.Point(5, 5);
            this.elemViewsOCIBRunButton.Name = "elemViewsOCIBRunButton";
            this.elemViewsOCIBRunButton.Size = new System.Drawing.Size(65, 25);
            this.elemViewsOCIBRunButton.TabIndex = 13;
            this.elemViewsOCIBRunButton.Text = "RUN";
            this.elemViewsOCIBRunButton.UseVisualStyleBackColor = true;
            this.elemViewsOCIBRunButton.Click += new System.EventHandler(this.ViewsOCIBRunButton_Click);
            // 
            // managementTab
            // 
            this.managementTab.BackColor = System.Drawing.SystemColors.Control;
            this.managementTab.Controls.Add(this.managmentTabControl);
            this.managementTab.Location = new System.Drawing.Point(25, 4);
            this.managementTab.Margin = new System.Windows.Forms.Padding(0);
            this.managementTab.Name = "managementTab";
            this.managementTab.Padding = new System.Windows.Forms.Padding(3);
            this.managementTab.Size = new System.Drawing.Size(734, 437);
            this.managementTab.TabIndex = 2;
            this.managementTab.Text = "Management";
            // 
            // managmentTabControl
            // 
            this.managmentTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.managmentTabControl.Controls.Add(this.dataTab);
            this.managmentTabControl.Controls.Add(this.documentsTab);
            this.managmentTabControl.Controls.Add(this.graphicsTab);
            this.managmentTabControl.Controls.Add(this.miscTab);
            this.managmentTabControl.Controls.Add(this.qaqcTab);
            this.managmentTabControl.Controls.Add(this.setupTab);
            this.managmentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managmentTabControl.Location = new System.Drawing.Point(3, 3);
            this.managmentTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.managmentTabControl.Name = "managmentTabControl";
            this.managmentTabControl.SelectedIndex = 0;
            this.managmentTabControl.Size = new System.Drawing.Size(728, 431);
            this.managmentTabControl.TabIndex = 0;
            // 
            // dataTab
            // 
            this.dataTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataTab.Controls.Add(this.dataTabLayoutPanel);
            this.dataTab.Location = new System.Drawing.Point(4, 25);
            this.dataTab.Margin = new System.Windows.Forms.Padding(0);
            this.dataTab.Name = "dataTab";
            this.dataTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataTab.Size = new System.Drawing.Size(720, 402);
            this.dataTab.TabIndex = 0;
            this.dataTab.Text = "Data";
            this.dataTab.UseVisualStyleBackColor = true;
            // 
            // dataTabLayoutPanel
            // 
            this.dataTabLayoutPanel.ColumnCount = 1;
            this.dataTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataTabLayoutPanel.Controls.Add(this.dataToolStrip, 0, 0);
            this.dataTabLayoutPanel.Controls.Add(this.dataToolsPanel, 0, 1);
            this.dataTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.dataTabLayoutPanel.Name = "dataTabLayoutPanel";
            this.dataTabLayoutPanel.RowCount = 2;
            this.dataTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.dataTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataTabLayoutPanel.Size = new System.Drawing.Size(710, 392);
            this.dataTabLayoutPanel.TabIndex = 0;
            // 
            // dataToolStrip
            // 
            this.dataToolStrip.AutoSize = false;
            this.dataToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.dataToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.dataToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataEPIButton,
            this.dataSeparator1});
            this.dataToolStrip.Location = new System.Drawing.Point(0, 0);
            this.dataToolStrip.Name = "dataToolStrip";
            this.dataToolStrip.Size = new System.Drawing.Size(710, 53);
            this.dataToolStrip.TabIndex = 0;
            this.dataToolStrip.Text = "toolStrip1";
            // 
            // dataEPIButton
            // 
            this.dataEPIButton.Image = ((System.Drawing.Image)(resources.GetObject("dataEPIButton.Image")));
            this.dataEPIButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dataEPIButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dataEPIButton.Name = "dataEPIButton";
            this.dataEPIButton.Size = new System.Drawing.Size(106, 50);
            this.dataEPIButton.Text = "Export Plan Image";
            this.dataEPIButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dataEPIButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.dataEPIButton.ToolTipText = "Export Plan Image: Exports a plan as a JPG with minimum (X,Y) and maximum (X,Y) c" +
    "oordinates in image name.";
            this.dataEPIButton.Click += new System.EventHandler(this.DataEPIButton_Click);
            // 
            // dataSeparator1
            // 
            this.dataSeparator1.Name = "dataSeparator1";
            this.dataSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // dataToolsPanel
            // 
            this.dataToolsPanel.Controls.Add(this.dataEPILayoutPanel);
            this.dataToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.dataToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataToolsPanel.Name = "dataToolsPanel";
            this.dataToolsPanel.Size = new System.Drawing.Size(710, 339);
            this.dataToolsPanel.TabIndex = 1;
            // 
            // dataEPILayoutPanel
            // 
            this.dataEPILayoutPanel.ColumnCount = 1;
            this.dataEPILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataEPILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataEPILayoutPanel.Controls.Add(this.dataEPIInstructionsPanel, 0, 0);
            this.dataEPILayoutPanel.Controls.Add(this.dataEPIControlsPanel, 0, 1);
            this.dataEPILayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEPILayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dataEPILayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataEPILayoutPanel.Name = "dataEPILayoutPanel";
            this.dataEPILayoutPanel.RowCount = 2;
            this.dataEPILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.49856F));
            this.dataEPILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.50144F));
            this.dataEPILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataEPILayoutPanel.Size = new System.Drawing.Size(710, 339);
            this.dataEPILayoutPanel.TabIndex = 14;
            this.dataEPILayoutPanel.Visible = false;
            // 
            // dataEPIInstructionsPanel
            // 
            this.dataEPIInstructionsPanel.Controls.Add(this.dataEPIInstructionsLabel);
            this.dataEPIInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEPIInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.dataEPIInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataEPIInstructionsPanel.Name = "dataEPIInstructionsPanel";
            this.dataEPIInstructionsPanel.Size = new System.Drawing.Size(710, 140);
            this.dataEPIInstructionsPanel.TabIndex = 0;
            // 
            // dataEPIInstructionsLabel
            // 
            this.dataEPIInstructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataEPIInstructionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEPIInstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.dataEPIInstructionsLabel.Name = "dataEPIInstructionsLabel";
            this.dataEPIInstructionsLabel.Size = new System.Drawing.Size(710, 140);
            this.dataEPIInstructionsLabel.TabIndex = 0;
            this.dataEPIInstructionsLabel.Text = resources.GetString("dataEPIInstructionsLabel.Text");
            // 
            // dataEPIControlsPanel
            // 
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIDPIComboBox);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIDirectorySelectedLabel);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPISaveTextBox);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIRunButton);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIDirectoryButton);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIDPILabel);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPIDirectoryLabel);
            this.dataEPIControlsPanel.Controls.Add(this.dataEPINameLabel);
            this.dataEPIControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEPIControlsPanel.Location = new System.Drawing.Point(0, 140);
            this.dataEPIControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataEPIControlsPanel.Name = "dataEPIControlsPanel";
            this.dataEPIControlsPanel.Size = new System.Drawing.Size(710, 199);
            this.dataEPIControlsPanel.TabIndex = 1;
            // 
            // dataEPIDPIComboBox
            // 
            this.dataEPIDPIComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataEPIDPIComboBox.FormattingEnabled = true;
            this.dataEPIDPIComboBox.Items.AddRange(new object[] {
            "150",
            "300",
            "600"});
            this.dataEPIDPIComboBox.Location = new System.Drawing.Point(143, 64);
            this.dataEPIDPIComboBox.Name = "dataEPIDPIComboBox";
            this.dataEPIDPIComboBox.Size = new System.Drawing.Size(75, 21);
            this.dataEPIDPIComboBox.TabIndex = 5;
            // 
            // dataEPIDirectorySelectedLabel
            // 
            this.dataEPIDirectorySelectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataEPIDirectorySelectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataEPIDirectorySelectedLabel.Location = new System.Drawing.Point(224, 35);
            this.dataEPIDirectorySelectedLabel.Name = "dataEPIDirectorySelectedLabel";
            this.dataEPIDirectorySelectedLabel.Size = new System.Drawing.Size(363, 23);
            this.dataEPIDirectorySelectedLabel.TabIndex = 4;
            // 
            // dataEPISaveTextBox
            // 
            this.dataEPISaveTextBox.Location = new System.Drawing.Point(143, 7);
            this.dataEPISaveTextBox.Name = "dataEPISaveTextBox";
            this.dataEPISaveTextBox.Size = new System.Drawing.Size(444, 20);
            this.dataEPISaveTextBox.TabIndex = 3;
            // 
            // dataEPIRunButton
            // 
            this.dataEPIRunButton.Location = new System.Drawing.Point(7, 92);
            this.dataEPIRunButton.Name = "dataEPIRunButton";
            this.dataEPIRunButton.Size = new System.Drawing.Size(75, 23);
            this.dataEPIRunButton.TabIndex = 2;
            this.dataEPIRunButton.Text = "RUN";
            this.dataEPIRunButton.UseVisualStyleBackColor = true;
            this.dataEPIRunButton.Click += new System.EventHandler(this.DataEPIRunButton_Click);
            // 
            // dataEPIDirectoryButton
            // 
            this.dataEPIDirectoryButton.Location = new System.Drawing.Point(143, 34);
            this.dataEPIDirectoryButton.Name = "dataEPIDirectoryButton";
            this.dataEPIDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.dataEPIDirectoryButton.TabIndex = 2;
            this.dataEPIDirectoryButton.Text = "SELECT";
            this.dataEPIDirectoryButton.UseVisualStyleBackColor = true;
            this.dataEPIDirectoryButton.Click += new System.EventHandler(this.DataEPIDirectoryButton_Click);
            // 
            // dataEPIDPILabel
            // 
            this.dataEPIDPILabel.AutoSize = true;
            this.dataEPIDPILabel.Location = new System.Drawing.Point(7, 64);
            this.dataEPIDPILabel.Name = "dataEPIDPILabel";
            this.dataEPIDPILabel.Size = new System.Drawing.Size(96, 13);
            this.dataEPIDPILabel.TabIndex = 1;
            this.dataEPIDPILabel.Text = "Set the image DPI:";
            // 
            // dataEPIDirectoryLabel
            // 
            this.dataEPIDirectoryLabel.AutoSize = true;
            this.dataEPIDirectoryLabel.Location = new System.Drawing.Point(7, 35);
            this.dataEPIDirectoryLabel.Name = "dataEPIDirectoryLabel";
            this.dataEPIDirectoryLabel.Size = new System.Drawing.Size(113, 13);
            this.dataEPIDirectoryLabel.TabIndex = 1;
            this.dataEPIDirectoryLabel.Text = "Set the save directory:";
            // 
            // dataEPINameLabel
            // 
            this.dataEPINameLabel.AutoSize = true;
            this.dataEPINameLabel.Location = new System.Drawing.Point(7, 10);
            this.dataEPINameLabel.Name = "dataEPINameLabel";
            this.dataEPINameLabel.Size = new System.Drawing.Size(130, 13);
            this.dataEPINameLabel.TabIndex = 0;
            this.dataEPINameLabel.Text = "Set the image save name:";
            // 
            // documentsTab
            // 
            this.documentsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.documentsTab.Controls.Add(this.documentsLayoutPanel);
            this.documentsTab.Location = new System.Drawing.Point(4, 25);
            this.documentsTab.Margin = new System.Windows.Forms.Padding(0);
            this.documentsTab.Name = "documentsTab";
            this.documentsTab.Size = new System.Drawing.Size(720, 402);
            this.documentsTab.TabIndex = 1;
            this.documentsTab.Text = "Documents";
            this.documentsTab.UseVisualStyleBackColor = true;
            // 
            // documentsLayoutPanel
            // 
            this.documentsLayoutPanel.ColumnCount = 1;
            this.documentsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.documentsLayoutPanel.Controls.Add(this.documentsToolStrip, 0, 0);
            this.documentsLayoutPanel.Controls.Add(this.documentsToolsPanel, 0, 1);
            this.documentsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.documentsLayoutPanel.Name = "documentsLayoutPanel";
            this.documentsLayoutPanel.RowCount = 2;
            this.documentsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.documentsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.documentsLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.documentsLayoutPanel.TabIndex = 0;
            // 
            // documentsToolStrip
            // 
            this.documentsToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentsToolStrip.AutoSize = false;
            this.documentsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.documentsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.documentsToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.documentsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentsCTSButton,
            this.documentsToolStripSeparator1,
            this.documentsPRP});
            this.documentsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.documentsToolStrip.Name = "documentsToolStrip";
            this.documentsToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.documentsToolStrip.Size = new System.Drawing.Size(716, 53);
            this.documentsToolStrip.Stretch = true;
            this.documentsToolStrip.TabIndex = 2;
            this.documentsToolStrip.Text = "mgmtGraphicsToolStrip";
            // 
            // documentsCTSButton
            // 
            this.documentsCTSButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.documentsCTSButton.Image = ((System.Drawing.Image)(resources.GetObject("documentsCTSButton.Image")));
            this.documentsCTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.documentsCTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.documentsCTSButton.Name = "documentsCTSButton";
            this.documentsCTSButton.Size = new System.Drawing.Size(100, 50);
            this.documentsCTSButton.Text = "Convert Text Size";
            this.documentsCTSButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.documentsCTSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.documentsCTSButton.ToolTipText = "Convert Text Size: Converts text for projects in Revit 2016 and earlier to equiva" +
    "lent scales in Revit 2017 and later.";
            this.documentsCTSButton.Click += new System.EventHandler(this.DocumentsCTSButton_Click);
            // 
            // documentsToolStripSeparator1
            // 
            this.documentsToolStripSeparator1.Name = "documentsToolStripSeparator1";
            this.documentsToolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // documentsPRP
            // 
            this.documentsPRP.Image = ((System.Drawing.Image)(resources.GetObject("documentsPRP.Image")));
            this.documentsPRP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.documentsPRP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.documentsPRP.Name = "documentsPRP";
            this.documentsPRP.Size = new System.Drawing.Size(124, 50);
            this.documentsPRP.Text = "Package Revit Project";
            this.documentsPRP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.documentsPRP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.documentsPRP.ToolTipText = "Package Revit Project: Collects and packages files to transmit to consultants";
            this.documentsPRP.Visible = false;
            // 
            // documentsToolsPanel
            // 
            this.documentsToolsPanel.Controls.Add(this.documentsCTSPanel);
            this.documentsToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentsToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.documentsToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.documentsToolsPanel.Name = "documentsToolsPanel";
            this.documentsToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.documentsToolsPanel.TabIndex = 3;
            // 
            // documentsCTSPanel
            // 
            this.documentsCTSPanel.Controls.Add(this.documentsCTSRun);
            this.documentsCTSPanel.Controls.Add(this.documentsCTSInstructions);
            this.documentsCTSPanel.Location = new System.Drawing.Point(-5, -4);
            this.documentsCTSPanel.Margin = new System.Windows.Forms.Padding(0);
            this.documentsCTSPanel.Name = "documentsCTSPanel";
            this.documentsCTSPanel.Size = new System.Drawing.Size(726, 350);
            this.documentsCTSPanel.TabIndex = 3;
            this.documentsCTSPanel.Visible = false;
            // 
            // documentsCTSRun
            // 
            this.documentsCTSRun.Location = new System.Drawing.Point(10, 62);
            this.documentsCTSRun.Name = "documentsCTSRun";
            this.documentsCTSRun.Size = new System.Drawing.Size(65, 23);
            this.documentsCTSRun.TabIndex = 9;
            this.documentsCTSRun.Text = "RUN";
            this.documentsCTSRun.UseVisualStyleBackColor = true;
            this.documentsCTSRun.Click += new System.EventHandler(this.DocumentsCTSRun_Click);
            // 
            // documentsCTSInstructions
            // 
            this.documentsCTSInstructions.BackColor = System.Drawing.Color.Orange;
            this.documentsCTSInstructions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.documentsCTSInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.documentsCTSInstructions.Location = new System.Drawing.Point(0, 0);
            this.documentsCTSInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.documentsCTSInstructions.Name = "documentsCTSInstructions";
            this.documentsCTSInstructions.Padding = new System.Windows.Forms.Padding(5);
            this.documentsCTSInstructions.Size = new System.Drawing.Size(726, 59);
            this.documentsCTSInstructions.TabIndex = 8;
            this.documentsCTSInstructions.Text = resources.GetString("documentsCTSInstructions.Text");
            // 
            // graphicsTab
            // 
            this.graphicsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphicsTab.Location = new System.Drawing.Point(4, 25);
            this.graphicsTab.Margin = new System.Windows.Forms.Padding(0);
            this.graphicsTab.Name = "graphicsTab";
            this.graphicsTab.Size = new System.Drawing.Size(720, 402);
            this.graphicsTab.TabIndex = 2;
            this.graphicsTab.Text = "Graphics";
            this.graphicsTab.UseVisualStyleBackColor = true;
            // 
            // miscTab
            // 
            this.miscTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.miscTab.Controls.Add(this.miscToolsLayoutPanel);
            this.miscTab.Location = new System.Drawing.Point(4, 25);
            this.miscTab.Margin = new System.Windows.Forms.Padding(0);
            this.miscTab.Name = "miscTab";
            this.miscTab.Size = new System.Drawing.Size(720, 402);
            this.miscTab.TabIndex = 3;
            this.miscTab.Text = "Misc";
            this.miscTab.UseVisualStyleBackColor = true;
            // 
            // miscToolsLayoutPanel
            // 
            this.miscToolsLayoutPanel.ColumnCount = 1;
            this.miscToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.miscToolsLayoutPanel.Controls.Add(this.miscToolStrip, 0, 0);
            this.miscToolsLayoutPanel.Controls.Add(this.miscToolsPanel, 0, 1);
            this.miscToolsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscToolsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.miscToolsLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscToolsLayoutPanel.Name = "miscToolsLayoutPanel";
            this.miscToolsLayoutPanel.RowCount = 2;
            this.miscToolsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.miscToolsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.miscToolsLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.miscToolsLayoutPanel.TabIndex = 0;
            // 
            // miscToolStrip
            // 
            this.miscToolStrip.AutoSize = false;
            this.miscToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miscToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.miscToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miscEDVButton,
            this.miscSeparator1,
            this.miscEEVButton});
            this.miscToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miscToolStrip.Name = "miscToolStrip";
            this.miscToolStrip.Size = new System.Drawing.Size(716, 53);
            this.miscToolStrip.TabIndex = 0;
            this.miscToolStrip.Text = "toolStrip1";
            // 
            // miscEDVButton
            // 
            this.miscEDVButton.Image = ((System.Drawing.Image)(resources.GetObject("miscEDVButton.Image")));
            this.miscEDVButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miscEDVButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miscEDVButton.Name = "miscEDVButton";
            this.miscEDVButton.Size = new System.Drawing.Size(123, 50);
            this.miscEDVButton.Text = "Export Drafting Views";
            this.miscEDVButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.miscEDVButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.miscEDVButton.ToolTipText = "Export Drafting Views: Exports all selected drafting views from a project into in" +
    "dividual project files for use later.";
            this.miscEDVButton.Click += new System.EventHandler(this.MiscEDVButton_Click);
            // 
            // miscSeparator1
            // 
            this.miscSeparator1.Name = "miscSeparator1";
            this.miscSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // miscEEVButton
            // 
            this.miscEEVButton.Image = ((System.Drawing.Image)(resources.GetObject("miscEEVButton.Image")));
            this.miscEEVButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miscEEVButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miscEEVButton.Name = "miscEEVButton";
            this.miscEEVButton.Size = new System.Drawing.Size(131, 50);
            this.miscEEVButton.Text = "External Elements View";
            this.miscEEVButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.miscEEVButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.miscEEVButton.ToolTipText = "External Elements View: Prepares a 3D view to only show exterior building geometr" +
    "y";
            this.miscEEVButton.Visible = false;
            // 
            // miscToolsPanel
            // 
            this.miscToolsPanel.Controls.Add(this.miscEDVLayoutPanel);
            this.miscToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.miscToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscToolsPanel.Name = "miscToolsPanel";
            this.miscToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.miscToolsPanel.TabIndex = 1;
            // 
            // miscEDVLayoutPanel
            // 
            this.miscEDVLayoutPanel.ColumnCount = 2;
            this.miscEDVLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.miscEDVLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.miscEDVLayoutPanel.Controls.Add(this.miscEDVInstructionsPanel, 0, 0);
            this.miscEDVLayoutPanel.Controls.Add(this.miscEDVRunPanel, 0, 3);
            this.miscEDVLayoutPanel.Controls.Add(this.miscEDVDirectoryPanel, 0, 1);
            this.miscEDVLayoutPanel.Controls.Add(this.miscEDVDataGridView, 0, 2);
            this.miscEDVLayoutPanel.Controls.Add(this.miscEDVControlsPanel, 1, 2);
            this.miscEDVLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.miscEDVLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVLayoutPanel.Name = "miscEDVLayoutPanel";
            this.miscEDVLayoutPanel.RowCount = 4;
            this.miscEDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.miscEDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.miscEDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.miscEDVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.miscEDVLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.miscEDVLayoutPanel.TabIndex = 6;
            this.miscEDVLayoutPanel.Visible = false;
            // 
            // miscEDVInstructionsPanel
            // 
            this.miscEDVLayoutPanel.SetColumnSpan(this.miscEDVInstructionsPanel, 2);
            this.miscEDVInstructionsPanel.Controls.Add(this.miscEDVInstructionsTextBox);
            this.miscEDVInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.miscEDVInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVInstructionsPanel.Name = "miscEDVInstructionsPanel";
            this.miscEDVInstructionsPanel.Size = new System.Drawing.Size(716, 75);
            this.miscEDVInstructionsPanel.TabIndex = 0;
            // 
            // miscEDVInstructionsTextBox
            // 
            this.miscEDVInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.miscEDVInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.miscEDVInstructionsTextBox.Multiline = true;
            this.miscEDVInstructionsTextBox.Name = "miscEDVInstructionsTextBox";
            this.miscEDVInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.miscEDVInstructionsTextBox.Size = new System.Drawing.Size(716, 75);
            this.miscEDVInstructionsTextBox.TabIndex = 0;
            this.miscEDVInstructionsTextBox.Text = resources.GetString("miscEDVInstructionsTextBox.Text");
            // 
            // miscEDVRunPanel
            // 
            this.miscEDVLayoutPanel.SetColumnSpan(this.miscEDVRunPanel, 2);
            this.miscEDVRunPanel.Controls.Add(this.miscEDVProgressBar);
            this.miscEDVRunPanel.Controls.Add(this.miscEDVRunButton);
            this.miscEDVRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVRunPanel.Location = new System.Drawing.Point(0, 310);
            this.miscEDVRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVRunPanel.Name = "miscEDVRunPanel";
            this.miscEDVRunPanel.Size = new System.Drawing.Size(716, 35);
            this.miscEDVRunPanel.TabIndex = 1;
            // 
            // miscEDVProgressBar
            // 
            this.miscEDVProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miscEDVProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.miscEDVProgressBar.Location = new System.Drawing.Point(3, 6);
            this.miscEDVProgressBar.Name = "miscEDVProgressBar";
            this.miscEDVProgressBar.Size = new System.Drawing.Size(629, 23);
            this.miscEDVProgressBar.TabIndex = 1;
            this.miscEDVProgressBar.Visible = false;
            // 
            // miscEDVRunButton
            // 
            this.miscEDVRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miscEDVRunButton.Location = new System.Drawing.Point(637, 6);
            this.miscEDVRunButton.Name = "miscEDVRunButton";
            this.miscEDVRunButton.Size = new System.Drawing.Size(75, 23);
            this.miscEDVRunButton.TabIndex = 0;
            this.miscEDVRunButton.Text = "RUN";
            this.miscEDVRunButton.UseVisualStyleBackColor = true;
            this.miscEDVRunButton.Click += new System.EventHandler(this.MiscEDVRunButton_Click);
            // 
            // miscEDVDirectoryPanel
            // 
            this.miscEDVLayoutPanel.SetColumnSpan(this.miscEDVDirectoryPanel, 2);
            this.miscEDVDirectoryPanel.Controls.Add(this.miscEDVSelectDirectoryTextBox);
            this.miscEDVDirectoryPanel.Controls.Add(this.miscEDVSelectDirectoryButton);
            this.miscEDVDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVDirectoryPanel.Location = new System.Drawing.Point(0, 75);
            this.miscEDVDirectoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVDirectoryPanel.Name = "miscEDVDirectoryPanel";
            this.miscEDVDirectoryPanel.Size = new System.Drawing.Size(716, 35);
            this.miscEDVDirectoryPanel.TabIndex = 2;
            // 
            // miscEDVSelectDirectoryTextBox
            // 
            this.miscEDVSelectDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miscEDVSelectDirectoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miscEDVSelectDirectoryTextBox.Location = new System.Drawing.Point(109, 9);
            this.miscEDVSelectDirectoryTextBox.Name = "miscEDVSelectDirectoryTextBox";
            this.miscEDVSelectDirectoryTextBox.ReadOnly = true;
            this.miscEDVSelectDirectoryTextBox.Size = new System.Drawing.Size(603, 20);
            this.miscEDVSelectDirectoryTextBox.TabIndex = 1;
            // 
            // miscEDVSelectDirectoryButton
            // 
            this.miscEDVSelectDirectoryButton.Location = new System.Drawing.Point(3, 7);
            this.miscEDVSelectDirectoryButton.Name = "miscEDVSelectDirectoryButton";
            this.miscEDVSelectDirectoryButton.Size = new System.Drawing.Size(100, 23);
            this.miscEDVSelectDirectoryButton.TabIndex = 0;
            this.miscEDVSelectDirectoryButton.Text = "Select Directory";
            this.miscEDVSelectDirectoryButton.UseVisualStyleBackColor = true;
            this.miscEDVSelectDirectoryButton.Click += new System.EventHandler(this.MiscEDVSelectDirectoryButton_Click);
            // 
            // miscEDVDataGridView
            // 
            this.miscEDVDataGridView.AllowUserToAddRows = false;
            this.miscEDVDataGridView.AllowUserToDeleteRows = false;
            this.miscEDVDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.miscEDVDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.miscEDVDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVDataGridView.Location = new System.Drawing.Point(0, 110);
            this.miscEDVDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVDataGridView.Name = "miscEDVDataGridView";
            this.miscEDVDataGridView.RowHeadersVisible = false;
            this.miscEDVDataGridView.Size = new System.Drawing.Size(545, 200);
            this.miscEDVDataGridView.TabIndex = 3;
            this.miscEDVDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MiscEDVDataGridView_CellContentClick);
            // 
            // miscEDVControlsPanel
            // 
            this.miscEDVControlsPanel.Controls.Add(this.miscEDVFilterLabel);
            this.miscEDVControlsPanel.Controls.Add(this.miscEDVFilterStringTextBox);
            this.miscEDVControlsPanel.Controls.Add(this.miscEDVFilterConditionComboBox);
            this.miscEDVControlsPanel.Controls.Add(this.miscEDVSelectNoneButton);
            this.miscEDVControlsPanel.Controls.Add(this.miscEDVSelectAllButton);
            this.miscEDVControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscEDVControlsPanel.Location = new System.Drawing.Point(545, 110);
            this.miscEDVControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.miscEDVControlsPanel.Name = "miscEDVControlsPanel";
            this.miscEDVControlsPanel.Size = new System.Drawing.Size(171, 200);
            this.miscEDVControlsPanel.TabIndex = 4;
            // 
            // miscEDVFilterLabel
            // 
            this.miscEDVFilterLabel.AutoSize = true;
            this.miscEDVFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miscEDVFilterLabel.Location = new System.Drawing.Point(3, 47);
            this.miscEDVFilterLabel.Name = "miscEDVFilterLabel";
            this.miscEDVFilterLabel.Size = new System.Drawing.Size(39, 13);
            this.miscEDVFilterLabel.TabIndex = 8;
            this.miscEDVFilterLabel.Text = "Filter:";
            // 
            // miscEDVFilterStringTextBox
            // 
            this.miscEDVFilterStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miscEDVFilterStringTextBox.Location = new System.Drawing.Point(6, 92);
            this.miscEDVFilterStringTextBox.Name = "miscEDVFilterStringTextBox";
            this.miscEDVFilterStringTextBox.Size = new System.Drawing.Size(162, 20);
            this.miscEDVFilterStringTextBox.TabIndex = 7;
            this.miscEDVFilterStringTextBox.Text = "<Search String>";
            this.miscEDVFilterStringTextBox.TextChanged += new System.EventHandler(this.MiscEDVFilterStringTextBox_TextChanged);
            // 
            // miscEDVFilterConditionComboBox
            // 
            this.miscEDVFilterConditionComboBox.FormattingEnabled = true;
            this.miscEDVFilterConditionComboBox.Items.AddRange(new object[] {
            "CONTAINS",
            "DOES NOT CONTAIN"});
            this.miscEDVFilterConditionComboBox.Location = new System.Drawing.Point(6, 66);
            this.miscEDVFilterConditionComboBox.Name = "miscEDVFilterConditionComboBox";
            this.miscEDVFilterConditionComboBox.Size = new System.Drawing.Size(162, 21);
            this.miscEDVFilterConditionComboBox.TabIndex = 6;
            this.miscEDVFilterConditionComboBox.SelectedIndexChanged += new System.EventHandler(this.MiscEDVFilterConditionComboBox_SelectedIndexChanged);
            // 
            // miscEDVSelectNoneButton
            // 
            this.miscEDVSelectNoneButton.Location = new System.Drawing.Point(93, 3);
            this.miscEDVSelectNoneButton.Name = "miscEDVSelectNoneButton";
            this.miscEDVSelectNoneButton.Size = new System.Drawing.Size(75, 23);
            this.miscEDVSelectNoneButton.TabIndex = 0;
            this.miscEDVSelectNoneButton.Text = "Select None";
            this.miscEDVSelectNoneButton.UseVisualStyleBackColor = true;
            this.miscEDVSelectNoneButton.Click += new System.EventHandler(this.MiscEDVSelectNoneButton_Click);
            // 
            // miscEDVSelectAllButton
            // 
            this.miscEDVSelectAllButton.Location = new System.Drawing.Point(6, 3);
            this.miscEDVSelectAllButton.Name = "miscEDVSelectAllButton";
            this.miscEDVSelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.miscEDVSelectAllButton.TabIndex = 0;
            this.miscEDVSelectAllButton.Text = "Select All";
            this.miscEDVSelectAllButton.UseVisualStyleBackColor = true;
            this.miscEDVSelectAllButton.Click += new System.EventHandler(this.MiscEDVSelectAllButton_Click);
            // 
            // qaqcTab
            // 
            this.qaqcTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcTab.Controls.Add(this.qaqcLayoutPanel);
            this.qaqcTab.Location = new System.Drawing.Point(4, 25);
            this.qaqcTab.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcTab.Name = "qaqcTab";
            this.qaqcTab.Size = new System.Drawing.Size(720, 402);
            this.qaqcTab.TabIndex = 4;
            this.qaqcTab.Text = "QA/QC";
            this.qaqcTab.UseVisualStyleBackColor = true;
            // 
            // qaqcLayoutPanel
            // 
            this.qaqcLayoutPanel.ColumnCount = 1;
            this.qaqcLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qaqcLayoutPanel.Controls.Add(this.qaqcToolStrip, 0, 0);
            this.qaqcLayoutPanel.Controls.Add(this.qaqcToolsPanel, 0, 1);
            this.qaqcLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcLayoutPanel.Name = "qaqcLayoutPanel";
            this.qaqcLayoutPanel.RowCount = 2;
            this.qaqcLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.qaqcLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qaqcLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.qaqcLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.qaqcLayoutPanel.TabIndex = 12;
            // 
            // qaqcToolStrip
            // 
            this.qaqcToolStrip.AutoSize = false;
            this.qaqcToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.qaqcToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.qaqcToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qaqcCapitalizeValuesButton,
            this.qaqcToolStripSeparator1,
            this.qaqcDRNPButtton,
            this.qaqcToolStripSeparator2,
            this.qaqcRLSButton,
            this.toolStripSeparator2,
            this.qaqcRFSPButton});
            this.qaqcToolStrip.Location = new System.Drawing.Point(0, 0);
            this.qaqcToolStrip.Name = "qaqcToolStrip";
            this.qaqcToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.qaqcToolStrip.Size = new System.Drawing.Size(716, 53);
            this.qaqcToolStrip.Stretch = true;
            this.qaqcToolStrip.TabIndex = 2;
            this.qaqcToolStrip.Text = "mgmtQAQCToolStrip";
            // 
            // qaqcCapitalizeValuesButton
            // 
            this.qaqcCapitalizeValuesButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capitalizeSheetViewNamesButton,
            this.capitalizeScheduleValuesButton});
            this.qaqcCapitalizeValuesButton.Image = ((System.Drawing.Image)(resources.GetObject("qaqcCapitalizeValuesButton.Image")));
            this.qaqcCapitalizeValuesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.qaqcCapitalizeValuesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.qaqcCapitalizeValuesButton.Name = "qaqcCapitalizeValuesButton";
            this.qaqcCapitalizeValuesButton.Size = new System.Drawing.Size(110, 50);
            this.qaqcCapitalizeValuesButton.Text = "Capitalize Values";
            this.qaqcCapitalizeValuesButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.qaqcCapitalizeValuesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.qaqcCapitalizeValuesButton.ButtonClick += new System.EventHandler(this.QaqcCapitalizeValuesButton_ButtonClick);
            // 
            // capitalizeSheetViewNamesButton
            // 
            this.capitalizeSheetViewNamesButton.Image = ((System.Drawing.Image)(resources.GetObject("capitalizeSheetViewNamesButton.Image")));
            this.capitalizeSheetViewNamesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.capitalizeSheetViewNamesButton.Name = "capitalizeSheetViewNamesButton";
            this.capitalizeSheetViewNamesButton.Size = new System.Drawing.Size(243, 38);
            this.capitalizeSheetViewNamesButton.Text = "Capitalize Sheet/View Names";
            this.capitalizeSheetViewNamesButton.ToolTipText = "Capitalize Title & Sheet Names: Capitalizes all sheet names and names of views on" +
    " sheets.";
            this.capitalizeSheetViewNamesButton.Click += new System.EventHandler(this.QaqcCSVN_Click);
            // 
            // capitalizeScheduleValuesButton
            // 
            this.capitalizeScheduleValuesButton.Image = ((System.Drawing.Image)(resources.GetObject("capitalizeScheduleValuesButton.Image")));
            this.capitalizeScheduleValuesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.capitalizeScheduleValuesButton.Name = "capitalizeScheduleValuesButton";
            this.capitalizeScheduleValuesButton.Size = new System.Drawing.Size(243, 38);
            this.capitalizeScheduleValuesButton.Text = "Capitalize Schedule Values";
            this.capitalizeScheduleValuesButton.ToolTipText = "Capitalize Schedule Values: Capitalizes all text values  visible in a schedule.";
            this.capitalizeScheduleValuesButton.Click += new System.EventHandler(this.QaqcCSVButton_Click);
            // 
            // qaqcToolStripSeparator1
            // 
            this.qaqcToolStripSeparator1.Name = "qaqcToolStripSeparator1";
            this.qaqcToolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // qaqcDRNPButtton
            // 
            this.qaqcDRNPButtton.Image = ((System.Drawing.Image)(resources.GetObject("qaqcDRNPButtton.Image")));
            this.qaqcDRNPButtton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.qaqcDRNPButtton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.qaqcDRNPButtton.Name = "qaqcDRNPButtton";
            this.qaqcDRNPButtton.Size = new System.Drawing.Size(103, 50);
            this.qaqcDRNPButtton.Text = "Delete NP Rooms";
            this.qaqcDRNPButtton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.qaqcDRNPButtton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.qaqcDRNPButtton.ToolTipText = "Delete Not Placed Rooms: Deletes not placed rooms - use with caution if rooms are" +
    " to be reused after they were deleted.";
            this.qaqcDRNPButtton.Click += new System.EventHandler(this.QaqcDRNPButton_Click);
            // 
            // qaqcToolStripSeparator2
            // 
            this.qaqcToolStripSeparator2.Name = "qaqcToolStripSeparator2";
            this.qaqcToolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // qaqcRLSButton
            // 
            this.qaqcRLSButton.Image = ((System.Drawing.Image)(resources.GetObject("qaqcRLSButton.Image")));
            this.qaqcRLSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.qaqcRLSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.qaqcRLSButton.Name = "qaqcRLSButton";
            this.qaqcRLSButton.Size = new System.Drawing.Size(110, 50);
            this.qaqcRLSButton.Text = "Replace Line Styles";
            this.qaqcRLSButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.qaqcRLSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.qaqcRLSButton.ToolTipText = "Replace Line Styles: Automates the replacement and removal of line styles in a pr" +
    "oject.";
            this.qaqcRLSButton.Click += new System.EventHandler(this.QaqcRLSButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // qaqcRFSPButton
            // 
            this.qaqcRFSPButton.Image = ((System.Drawing.Image)(resources.GetObject("qaqcRFSPButton.Image")));
            this.qaqcRFSPButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.qaqcRFSPButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.qaqcRFSPButton.Name = "qaqcRFSPButton";
            this.qaqcRFSPButton.Size = new System.Drawing.Size(108, 50);
            this.qaqcRFSPButton.Text = "Remove Family SP";
            this.qaqcRFSPButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.qaqcRFSPButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.qaqcRFSPButton.ToolTipText = "Remove Family Shared Parameters: Converts shared parameters in the family file to" +
    " family parameters";
            this.qaqcRFSPButton.Click += new System.EventHandler(this.QaqcRFSPButton_Click);
            // 
            // qaqcToolsPanel
            // 
            this.qaqcToolsPanel.Controls.Add(this.qaqcRFSPLayoutPanel);
            this.qaqcToolsPanel.Controls.Add(this.qaqcRLSLayoutPanel);
            this.qaqcToolsPanel.Controls.Add(this.qaqcCSVNPanel);
            this.qaqcToolsPanel.Controls.Add(this.qaqcCSVLayoutPanel);
            this.qaqcToolsPanel.Controls.Add(this.qaqcDRNPPanel);
            this.qaqcToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.qaqcToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcToolsPanel.Name = "qaqcToolsPanel";
            this.qaqcToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcToolsPanel.TabIndex = 3;
            // 
            // qaqcRFSPLayoutPanel
            // 
            this.qaqcRFSPLayoutPanel.ColumnCount = 2;
            this.qaqcRFSPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.qaqcRFSPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.qaqcRFSPLayoutPanel.Controls.Add(this.qaqcRFSPInstructionsTextBox, 0, 0);
            this.qaqcRFSPLayoutPanel.Controls.Add(this.qaqcRFSPParametersListBox, 1, 2);
            this.qaqcRFSPLayoutPanel.Controls.Add(this.qaqcRFSPToolsPanel, 0, 1);
            this.qaqcRFSPLayoutPanel.Controls.Add(this.panel5, 1, 1);
            this.qaqcRFSPLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRFSPLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcRFSPLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.qaqcRFSPLayoutPanel.Name = "qaqcRFSPLayoutPanel";
            this.qaqcRFSPLayoutPanel.RowCount = 3;
            this.qaqcRFSPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.qaqcRFSPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.qaqcRFSPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qaqcRFSPLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcRFSPLayoutPanel.TabIndex = 4;
            this.qaqcRFSPLayoutPanel.Visible = false;
            // 
            // qaqcRFSPInstructionsTextBox
            // 
            this.qaqcRFSPInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.qaqcRFSPLayoutPanel.SetColumnSpan(this.qaqcRFSPInstructionsTextBox, 2);
            this.qaqcRFSPInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRFSPInstructionsTextBox.Location = new System.Drawing.Point(3, 3);
            this.qaqcRFSPInstructionsTextBox.Multiline = true;
            this.qaqcRFSPInstructionsTextBox.Name = "qaqcRFSPInstructionsTextBox";
            this.qaqcRFSPInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.qaqcRFSPInstructionsTextBox.Size = new System.Drawing.Size(710, 54);
            this.qaqcRFSPInstructionsTextBox.TabIndex = 1;
            this.qaqcRFSPInstructionsTextBox.Text = resources.GetString("qaqcRFSPInstructionsTextBox.Text");
            // 
            // qaqcRFSPParametersListBox
            // 
            this.qaqcRFSPParametersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRFSPParametersListBox.FormattingEnabled = true;
            this.qaqcRFSPParametersListBox.Location = new System.Drawing.Point(361, 88);
            this.qaqcRFSPParametersListBox.Name = "qaqcRFSPParametersListBox";
            this.qaqcRFSPParametersListBox.Size = new System.Drawing.Size(352, 254);
            this.qaqcRFSPParametersListBox.TabIndex = 2;
            // 
            // qaqcRFSPToolsPanel
            // 
            this.qaqcRFSPToolsPanel.Controls.Add(this.qaqcRFSPSFamilyLabel);
            this.qaqcRFSPToolsPanel.Controls.Add(this.qaqcRFSPRunButton);
            this.qaqcRFSPToolsPanel.Controls.Add(this.qaqcRFSPSelectFamilyButton);
            this.qaqcRFSPToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRFSPToolsPanel.Location = new System.Drawing.Point(0, 60);
            this.qaqcRFSPToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRFSPToolsPanel.Name = "qaqcRFSPToolsPanel";
            this.qaqcRFSPLayoutPanel.SetRowSpan(this.qaqcRFSPToolsPanel, 2);
            this.qaqcRFSPToolsPanel.Size = new System.Drawing.Size(358, 285);
            this.qaqcRFSPToolsPanel.TabIndex = 0;
            // 
            // qaqcRFSPSFamilyLabel
            // 
            this.qaqcRFSPSFamilyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qaqcRFSPSFamilyLabel.Location = new System.Drawing.Point(115, 7);
            this.qaqcRFSPSFamilyLabel.Name = "qaqcRFSPSFamilyLabel";
            this.qaqcRFSPSFamilyLabel.Size = new System.Drawing.Size(240, 23);
            this.qaqcRFSPSFamilyLabel.TabIndex = 1;
            this.qaqcRFSPSFamilyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qaqcRFSPRunButton
            // 
            this.qaqcRFSPRunButton.Location = new System.Drawing.Point(5, 36);
            this.qaqcRFSPRunButton.Name = "qaqcRFSPRunButton";
            this.qaqcRFSPRunButton.Size = new System.Drawing.Size(75, 23);
            this.qaqcRFSPRunButton.TabIndex = 0;
            this.qaqcRFSPRunButton.Text = "RUN";
            this.qaqcRFSPRunButton.UseVisualStyleBackColor = true;
            this.qaqcRFSPRunButton.Click += new System.EventHandler(this.QaqcRFSPRunButton_Click);
            // 
            // qaqcRFSPSelectFamilyButton
            // 
            this.qaqcRFSPSelectFamilyButton.Location = new System.Drawing.Point(5, 7);
            this.qaqcRFSPSelectFamilyButton.Name = "qaqcRFSPSelectFamilyButton";
            this.qaqcRFSPSelectFamilyButton.Size = new System.Drawing.Size(104, 23);
            this.qaqcRFSPSelectFamilyButton.TabIndex = 0;
            this.qaqcRFSPSelectFamilyButton.Text = "Select Family";
            this.qaqcRFSPSelectFamilyButton.UseVisualStyleBackColor = true;
            this.qaqcRFSPSelectFamilyButton.Click += new System.EventHandler(this.QaqcRFSPSelectFamilyButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(358, 60);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(358, 25);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Shared Parameters Evaluated:";
            // 
            // qaqcRLSLayoutPanel
            // 
            this.qaqcRLSLayoutPanel.ColumnCount = 2;
            this.qaqcRLSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.qaqcRLSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 482F));
            this.qaqcRLSLayoutPanel.Controls.Add(this.qaqcRLSRunPanel, 0, 3);
            this.qaqcRLSLayoutPanel.Controls.Add(this.qaqcRLSInstructionsTextBox, 0, 0);
            this.qaqcRLSLayoutPanel.Controls.Add(this.qaqcRLSDataGridView, 1, 2);
            this.qaqcRLSLayoutPanel.Controls.Add(this.qaqcRLSControlsPanel, 0, 1);
            this.qaqcRLSLayoutPanel.Controls.Add(this.qaqcRLSUnswitchablePanel, 1, 1);
            this.qaqcRLSLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRLSLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcRLSLayoutPanel.Name = "qaqcRLSLayoutPanel";
            this.qaqcRLSLayoutPanel.RowCount = 4;
            this.qaqcRLSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.qaqcRLSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.qaqcRLSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qaqcRLSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.qaqcRLSLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcRLSLayoutPanel.TabIndex = 10;
            this.qaqcRLSLayoutPanel.Visible = false;
            // 
            // qaqcRLSRunPanel
            // 
            this.qaqcRLSRunPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qaqcRLSLayoutPanel.SetColumnSpan(this.qaqcRLSRunPanel, 2);
            this.qaqcRLSRunPanel.Controls.Add(this.qaqcRLSRunButton);
            this.qaqcRLSRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRLSRunPanel.Location = new System.Drawing.Point(0, 310);
            this.qaqcRLSRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRLSRunPanel.Name = "qaqcRLSRunPanel";
            this.qaqcRLSRunPanel.Size = new System.Drawing.Size(732, 35);
            this.qaqcRLSRunPanel.TabIndex = 1;
            // 
            // qaqcRLSRunButton
            // 
            this.qaqcRLSRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.qaqcRLSRunButton.Location = new System.Drawing.Point(3, 5);
            this.qaqcRLSRunButton.Name = "qaqcRLSRunButton";
            this.qaqcRLSRunButton.Size = new System.Drawing.Size(75, 23);
            this.qaqcRLSRunButton.TabIndex = 4;
            this.qaqcRLSRunButton.Text = "RUN";
            this.qaqcRLSRunButton.UseVisualStyleBackColor = true;
            this.qaqcRLSRunButton.Click += new System.EventHandler(this.QaqcRLSRunButton_Click);
            // 
            // qaqcRLSInstructionsTextBox
            // 
            this.qaqcRLSLayoutPanel.SetColumnSpan(this.qaqcRLSInstructionsTextBox, 2);
            this.qaqcRLSInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRLSInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.qaqcRLSInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRLSInstructionsTextBox.Multiline = true;
            this.qaqcRLSInstructionsTextBox.Name = "qaqcRLSInstructionsTextBox";
            this.qaqcRLSInstructionsTextBox.ReadOnly = true;
            this.qaqcRLSInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.qaqcRLSInstructionsTextBox.Size = new System.Drawing.Size(732, 150);
            this.qaqcRLSInstructionsTextBox.TabIndex = 2;
            this.qaqcRLSInstructionsTextBox.Text = resources.GetString("qaqcRLSInstructionsTextBox.Text");
            // 
            // qaqcRLSDataGridView
            // 
            this.qaqcRLSDataGridView.AllowUserToAddRows = false;
            this.qaqcRLSDataGridView.AllowUserToDeleteRows = false;
            this.qaqcRLSDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcRLSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qaqcRLSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRLSDataGridView.Location = new System.Drawing.Point(250, 180);
            this.qaqcRLSDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRLSDataGridView.Name = "qaqcRLSDataGridView";
            this.qaqcRLSDataGridView.ReadOnly = true;
            this.qaqcRLSDataGridView.Size = new System.Drawing.Size(482, 130);
            this.qaqcRLSDataGridView.TabIndex = 3;
            this.qaqcRLSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QaqcRLSDataGridView_CellContentClick);
            // 
            // qaqcRLSControlsPanel
            // 
            this.qaqcRLSControlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qaqcRLSControlsPanel.Controls.Add(this.qaqcRLSReplaceWithLabel);
            this.qaqcRLSControlsPanel.Controls.Add(this.qaqcRLSReplaceLabel);
            this.qaqcRLSControlsPanel.Controls.Add(this.qaqcRLSReplaceWithComboBox);
            this.qaqcRLSControlsPanel.Controls.Add(this.qaqcRLSDeleteCheckBox);
            this.qaqcRLSControlsPanel.Controls.Add(this.qaqcRLSReplaceComboBox);
            this.qaqcRLSControlsPanel.Location = new System.Drawing.Point(0, 150);
            this.qaqcRLSControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRLSControlsPanel.Name = "qaqcRLSControlsPanel";
            this.qaqcRLSLayoutPanel.SetRowSpan(this.qaqcRLSControlsPanel, 2);
            this.qaqcRLSControlsPanel.Size = new System.Drawing.Size(250, 152);
            this.qaqcRLSControlsPanel.TabIndex = 0;
            // 
            // qaqcRLSReplaceWithLabel
            // 
            this.qaqcRLSReplaceWithLabel.AutoSize = true;
            this.qaqcRLSReplaceWithLabel.Location = new System.Drawing.Point(3, 60);
            this.qaqcRLSReplaceWithLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.qaqcRLSReplaceWithLabel.Name = "qaqcRLSReplaceWithLabel";
            this.qaqcRLSReplaceWithLabel.Padding = new System.Windows.Forms.Padding(3);
            this.qaqcRLSReplaceWithLabel.Size = new System.Drawing.Size(177, 19);
            this.qaqcRLSReplaceWithLabel.TabIndex = 3;
            this.qaqcRLSReplaceWithLabel.Text = "Select Line Style To Replace WIth";
            // 
            // qaqcRLSReplaceLabel
            // 
            this.qaqcRLSReplaceLabel.AutoSize = true;
            this.qaqcRLSReplaceLabel.Location = new System.Drawing.Point(3, 6);
            this.qaqcRLSReplaceLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.qaqcRLSReplaceLabel.Name = "qaqcRLSReplaceLabel";
            this.qaqcRLSReplaceLabel.Size = new System.Drawing.Size(165, 13);
            this.qaqcRLSReplaceLabel.TabIndex = 3;
            this.qaqcRLSReplaceLabel.Text = "Select Line Style Being Replaced";
            // 
            // qaqcRLSReplaceWithComboBox
            // 
            this.qaqcRLSReplaceWithComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qaqcRLSReplaceWithComboBox.FormattingEnabled = true;
            this.qaqcRLSReplaceWithComboBox.Location = new System.Drawing.Point(4, 90);
            this.qaqcRLSReplaceWithComboBox.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.qaqcRLSReplaceWithComboBox.Name = "qaqcRLSReplaceWithComboBox";
            this.qaqcRLSReplaceWithComboBox.Size = new System.Drawing.Size(239, 21);
            this.qaqcRLSReplaceWithComboBox.Sorted = true;
            this.qaqcRLSReplaceWithComboBox.TabIndex = 2;
            this.qaqcRLSReplaceWithComboBox.Text = "<With>";
            // 
            // qaqcRLSDeleteCheckBox
            // 
            this.qaqcRLSDeleteCheckBox.AutoSize = true;
            this.qaqcRLSDeleteCheckBox.Location = new System.Drawing.Point(6, 129);
            this.qaqcRLSDeleteCheckBox.Name = "qaqcRLSDeleteCheckBox";
            this.qaqcRLSDeleteCheckBox.Size = new System.Drawing.Size(191, 17);
            this.qaqcRLSDeleteCheckBox.TabIndex = 1;
            this.qaqcRLSDeleteCheckBox.Text = "Delete Line Style Being Replaced?";
            this.qaqcRLSDeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // qaqcRLSReplaceComboBox
            // 
            this.qaqcRLSReplaceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qaqcRLSReplaceComboBox.FormattingEnabled = true;
            this.qaqcRLSReplaceComboBox.Location = new System.Drawing.Point(6, 29);
            this.qaqcRLSReplaceComboBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.qaqcRLSReplaceComboBox.Name = "qaqcRLSReplaceComboBox";
            this.qaqcRLSReplaceComboBox.Size = new System.Drawing.Size(239, 21);
            this.qaqcRLSReplaceComboBox.Sorted = true;
            this.qaqcRLSReplaceComboBox.TabIndex = 0;
            this.qaqcRLSReplaceComboBox.Text = "<Replace>";
            this.qaqcRLSReplaceComboBox.SelectedIndexChanged += new System.EventHandler(this.QaqcRLSReplaceComboBox_SelectedIndexChanged);
            // 
            // qaqcRLSUnswitchablePanel
            // 
            this.qaqcRLSUnswitchablePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcRLSUnswitchablePanel.Controls.Add(this.label1);
            this.qaqcRLSUnswitchablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcRLSUnswitchablePanel.Location = new System.Drawing.Point(250, 150);
            this.qaqcRLSUnswitchablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcRLSUnswitchablePanel.Name = "qaqcRLSUnswitchablePanel";
            this.qaqcRLSUnswitchablePanel.Size = new System.Drawing.Size(482, 30);
            this.qaqcRLSUnswitchablePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "The Following Groups Have Lines That Could Not Be Switched:";
            // 
            // qaqcCSVNPanel
            // 
            this.qaqcCSVNPanel.Controls.Add(this.qaqcCSVNRun);
            this.qaqcCSVNPanel.Controls.Add(this.qaqcCTVNInstructions);
            this.qaqcCSVNPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcCSVNPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcCSVNPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcCSVNPanel.Name = "qaqcCSVNPanel";
            this.qaqcCSVNPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcCSVNPanel.TabIndex = 3;
            this.qaqcCSVNPanel.Visible = false;
            // 
            // qaqcCSVNRun
            // 
            this.qaqcCSVNRun.Location = new System.Drawing.Point(5, 62);
            this.qaqcCSVNRun.Name = "qaqcCSVNRun";
            this.qaqcCSVNRun.Size = new System.Drawing.Size(65, 23);
            this.qaqcCSVNRun.TabIndex = 9;
            this.qaqcCSVNRun.Text = "RUN";
            this.qaqcCSVNRun.UseVisualStyleBackColor = true;
            this.qaqcCSVNRun.Click += new System.EventHandler(this.QaqcCSVNRun_Click);
            // 
            // qaqcCTVNInstructions
            // 
            this.qaqcCTVNInstructions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcCTVNInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.qaqcCTVNInstructions.Location = new System.Drawing.Point(0, 0);
            this.qaqcCTVNInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcCTVNInstructions.Name = "qaqcCTVNInstructions";
            this.qaqcCTVNInstructions.Padding = new System.Windows.Forms.Padding(5);
            this.qaqcCTVNInstructions.Size = new System.Drawing.Size(716, 53);
            this.qaqcCTVNInstructions.TabIndex = 8;
            this.qaqcCTVNInstructions.Text = "This script will capitalize the names of sheets and views on sheets.";
            // 
            // qaqcCSVLayoutPanel
            // 
            this.qaqcCSVLayoutPanel.ColumnCount = 1;
            this.qaqcCSVLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.qaqcCSVLayoutPanel.Controls.Add(this.qaqcCSVControlsPanel, 0, 1);
            this.qaqcCSVLayoutPanel.Controls.Add(this.qaqcCSVInstructionsPanel, 0, 0);
            this.qaqcCSVLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcCSVLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcCSVLayoutPanel.Name = "qaqcCSVLayoutPanel";
            this.qaqcCSVLayoutPanel.RowCount = 2;
            this.qaqcCSVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.28045F));
            this.qaqcCSVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.71954F));
            this.qaqcCSVLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.qaqcCSVLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcCSVLayoutPanel.TabIndex = 11;
            this.qaqcCSVLayoutPanel.Visible = false;
            // 
            // qaqcCSVControlsPanel
            // 
            this.qaqcCSVControlsPanel.Controls.Add(this.qaqcCSVRunButton);
            this.qaqcCSVControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcCSVControlsPanel.Location = new System.Drawing.Point(0, 59);
            this.qaqcCSVControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcCSVControlsPanel.Name = "qaqcCSVControlsPanel";
            this.qaqcCSVControlsPanel.Size = new System.Drawing.Size(716, 286);
            this.qaqcCSVControlsPanel.TabIndex = 0;
            // 
            // qaqcCSVRunButton
            // 
            this.qaqcCSVRunButton.Location = new System.Drawing.Point(5, 5);
            this.qaqcCSVRunButton.Name = "qaqcCSVRunButton";
            this.qaqcCSVRunButton.Size = new System.Drawing.Size(75, 23);
            this.qaqcCSVRunButton.TabIndex = 0;
            this.qaqcCSVRunButton.Text = "RUN";
            this.qaqcCSVRunButton.UseVisualStyleBackColor = true;
            this.qaqcCSVRunButton.Click += new System.EventHandler(this.QaqcCSVRunButton_Click);
            // 
            // qaqcCSVInstructionsPanel
            // 
            this.qaqcCSVInstructionsPanel.Controls.Add(this.qaqcCSVInstructionsLabel);
            this.qaqcCSVInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcCSVInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcCSVInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcCSVInstructionsPanel.Name = "qaqcCSVInstructionsPanel";
            this.qaqcCSVInstructionsPanel.Size = new System.Drawing.Size(716, 59);
            this.qaqcCSVInstructionsPanel.TabIndex = 1;
            // 
            // qaqcCSVInstructionsLabel
            // 
            this.qaqcCSVInstructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcCSVInstructionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcCSVInstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.qaqcCSVInstructionsLabel.Name = "qaqcCSVInstructionsLabel";
            this.qaqcCSVInstructionsLabel.Size = new System.Drawing.Size(716, 59);
            this.qaqcCSVInstructionsLabel.TabIndex = 1;
            this.qaqcCSVInstructionsLabel.Text = resources.GetString("qaqcCSVInstructionsLabel.Text");
            // 
            // qaqcDRNPPanel
            // 
            this.qaqcDRNPPanel.Controls.Add(this.qaqcDRNPInstructions);
            this.qaqcDRNPPanel.Controls.Add(this.qaqcDRNPRun);
            this.qaqcDRNPPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaqcDRNPPanel.Location = new System.Drawing.Point(0, 0);
            this.qaqcDRNPPanel.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcDRNPPanel.Name = "qaqcDRNPPanel";
            this.qaqcDRNPPanel.Size = new System.Drawing.Size(716, 345);
            this.qaqcDRNPPanel.TabIndex = 10;
            this.qaqcDRNPPanel.Visible = false;
            // 
            // qaqcDRNPInstructions
            // 
            this.qaqcDRNPInstructions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qaqcDRNPInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.qaqcDRNPInstructions.Location = new System.Drawing.Point(0, 0);
            this.qaqcDRNPInstructions.Margin = new System.Windows.Forms.Padding(0);
            this.qaqcDRNPInstructions.Name = "qaqcDRNPInstructions";
            this.qaqcDRNPInstructions.Padding = new System.Windows.Forms.Padding(5);
            this.qaqcDRNPInstructions.Size = new System.Drawing.Size(716, 59);
            this.qaqcDRNPInstructions.TabIndex = 10;
            this.qaqcDRNPInstructions.Text = resources.GetString("qaqcDRNPInstructions.Text");
            // 
            // qaqcDRNPRun
            // 
            this.qaqcDRNPRun.Location = new System.Drawing.Point(5, 62);
            this.qaqcDRNPRun.Name = "qaqcDRNPRun";
            this.qaqcDRNPRun.Size = new System.Drawing.Size(65, 23);
            this.qaqcDRNPRun.TabIndex = 9;
            this.qaqcDRNPRun.Text = "RUN";
            this.qaqcDRNPRun.UseVisualStyleBackColor = true;
            this.qaqcDRNPRun.Click += new System.EventHandler(this.QaqcDRNPRun_Click);
            // 
            // setupTab
            // 
            this.setupTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.setupTab.Controls.Add(this.setupLayoutPanel);
            this.setupTab.Location = new System.Drawing.Point(4, 25);
            this.setupTab.Margin = new System.Windows.Forms.Padding(0);
            this.setupTab.Name = "setupTab";
            this.setupTab.Size = new System.Drawing.Size(720, 402);
            this.setupTab.TabIndex = 5;
            this.setupTab.Text = "Setup";
            this.setupTab.UseVisualStyleBackColor = true;
            // 
            // setupLayoutPanel
            // 
            this.setupLayoutPanel.ColumnCount = 1;
            this.setupLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.setupLayoutPanel.Controls.Add(this.setupToolStrip, 0, 0);
            this.setupLayoutPanel.Controls.Add(this.setupToolsPanel, 0, 1);
            this.setupLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.setupLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupLayoutPanel.Name = "setupLayoutPanel";
            this.setupLayoutPanel.RowCount = 2;
            this.setupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.setupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.setupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.setupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.setupLayoutPanel.Size = new System.Drawing.Size(716, 398);
            this.setupLayoutPanel.TabIndex = 0;
            // 
            // setupToolStrip
            // 
            this.setupToolStrip.AutoSize = false;
            this.setupToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.setupToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.setupToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupCWSButton,
            this.setupSeparator1,
            this.setupUPButton});
            this.setupToolStrip.Location = new System.Drawing.Point(0, 0);
            this.setupToolStrip.Name = "setupToolStrip";
            this.setupToolStrip.Size = new System.Drawing.Size(716, 53);
            this.setupToolStrip.TabIndex = 0;
            this.setupToolStrip.Text = "toolStrip2";
            // 
            // setupCWSButton
            // 
            this.setupCWSButton.Image = ((System.Drawing.Image)(resources.GetObject("setupCWSButton.Image")));
            this.setupCWSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.setupCWSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setupCWSButton.Name = "setupCWSButton";
            this.setupCWSButton.Size = new System.Drawing.Size(96, 50);
            this.setupCWSButton.Text = "Create Worksets";
            this.setupCWSButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.setupCWSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.setupCWSButton.ToolTipText = "Create Worksets: Create the default, extended, and user-defined worksets easily";
            this.setupCWSButton.Click += new System.EventHandler(this.SetupCWSButton_Click);
            // 
            // setupSeparator1
            // 
            this.setupSeparator1.Name = "setupSeparator1";
            this.setupSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // setupUPButton
            // 
            this.setupUPButton.Image = ((System.Drawing.Image)(resources.GetObject("setupUPButton.Image")));
            this.setupUPButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setupUPButton.Name = "setupUPButton";
            this.setupUPButton.Size = new System.Drawing.Size(101, 50);
            this.setupUPButton.Text = "Upgrade Projects";
            this.setupUPButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.setupUPButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.setupUPButton.ToolTipText = "Upgrade Projects: Upgrades project files to the currently running Revit version a" +
    "nd provides the ability to upgrade links.";
            this.setupUPButton.Click += new System.EventHandler(this.SetupUPButton_Click);
            // 
            // setupToolsPanel
            // 
            this.setupToolsPanel.Controls.Add(this.setupUPLayoutPanel);
            this.setupToolsPanel.Controls.Add(this.setupCWSLayoutPanel);
            this.setupToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupToolsPanel.Location = new System.Drawing.Point(0, 53);
            this.setupToolsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupToolsPanel.Name = "setupToolsPanel";
            this.setupToolsPanel.Size = new System.Drawing.Size(716, 345);
            this.setupToolsPanel.TabIndex = 1;
            // 
            // setupUPLayoutPanel
            // 
            this.setupUPLayoutPanel.ColumnCount = 2;
            this.setupUPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.setupUPLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.setupUPLayoutPanel.Controls.Add(this.setupUPInstructionsTextBox, 1, 0);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPDataGridView, 0, 4);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPLinkedModelsLabel, 0, 3);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPControlsPanel1, 0, 0);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPRunPanel, 0, 5);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPControlsPanel2, 0, 1);
            this.setupUPLayoutPanel.Controls.Add(this.setupUPControlsPanel3, 0, 2);
            this.setupUPLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.setupUPLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupUPLayoutPanel.Name = "setupUPLayoutPanel";
            this.setupUPLayoutPanel.RowCount = 6;
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.setupUPLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.setupUPLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.setupUPLayoutPanel.TabIndex = 2;
            this.setupUPLayoutPanel.Visible = false;
            // 
            // setupUPInstructionsTextBox
            // 
            this.setupUPInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPInstructionsTextBox.Location = new System.Drawing.Point(466, 0);
            this.setupUPInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.setupUPInstructionsTextBox.Multiline = true;
            this.setupUPInstructionsTextBox.Name = "setupUPInstructionsTextBox";
            this.setupUPInstructionsTextBox.ReadOnly = true;
            this.setupUPLayoutPanel.SetRowSpan(this.setupUPInstructionsTextBox, 3);
            this.setupUPInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.setupUPInstructionsTextBox.Size = new System.Drawing.Size(250, 178);
            this.setupUPInstructionsTextBox.TabIndex = 5;
            this.setupUPInstructionsTextBox.Text = resources.GetString("setupUPInstructionsTextBox.Text");
            // 
            // setupUPDataGridView
            // 
            this.setupUPDataGridView.AllowUserToAddRows = false;
            this.setupUPDataGridView.AllowUserToDeleteRows = false;
            this.setupUPDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.setupUPLayoutPanel.SetColumnSpan(this.setupUPDataGridView, 2);
            this.setupUPDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPDataGridView.Location = new System.Drawing.Point(2, 209);
            this.setupUPDataGridView.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPDataGridView.Name = "setupUPDataGridView";
            this.setupUPDataGridView.RowTemplate.Height = 28;
            this.setupUPDataGridView.Size = new System.Drawing.Size(712, 106);
            this.setupUPDataGridView.TabIndex = 0;
            this.setupUPDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetupUPDataGridView_CellContentClick);
            this.setupUPDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetupUPDataGridView_CellEndEdit);
            // 
            // setupUPLinkedModelsLabel
            // 
            this.setupUPLinkedModelsLabel.AutoSize = true;
            this.setupUPLinkedModelsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupUPLayoutPanel.SetColumnSpan(this.setupUPLinkedModelsLabel, 2);
            this.setupUPLinkedModelsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPLinkedModelsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPLinkedModelsLabel.Location = new System.Drawing.Point(0, 178);
            this.setupUPLinkedModelsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.setupUPLinkedModelsLabel.Name = "setupUPLinkedModelsLabel";
            this.setupUPLinkedModelsLabel.Size = new System.Drawing.Size(716, 30);
            this.setupUPLinkedModelsLabel.TabIndex = 2;
            this.setupUPLinkedModelsLabel.Text = "LINKED MODELS";
            this.setupUPLinkedModelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setupUPControlsPanel1
            // 
            this.setupUPControlsPanel1.Controls.Add(this.setupUPOriginalPathSelectButton);
            this.setupUPControlsPanel1.Controls.Add(this.setupUPOriginalFilePathTextBox);
            this.setupUPControlsPanel1.Controls.Add(this.setupUPOriginalFilePathLabel);
            this.setupUPControlsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPControlsPanel1.Location = new System.Drawing.Point(0, 0);
            this.setupUPControlsPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.setupUPControlsPanel1.Name = "setupUPControlsPanel1";
            this.setupUPControlsPanel1.Size = new System.Drawing.Size(466, 50);
            this.setupUPControlsPanel1.TabIndex = 3;
            // 
            // setupUPOriginalPathSelectButton
            // 
            this.setupUPOriginalPathSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setupUPOriginalPathSelectButton.BackColor = System.Drawing.Color.GreenYellow;
            this.setupUPOriginalPathSelectButton.Location = new System.Drawing.Point(433, 24);
            this.setupUPOriginalPathSelectButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPOriginalPathSelectButton.Name = "setupUPOriginalPathSelectButton";
            this.setupUPOriginalPathSelectButton.Size = new System.Drawing.Size(31, 20);
            this.setupUPOriginalPathSelectButton.TabIndex = 4;
            this.setupUPOriginalPathSelectButton.Text = "...";
            this.setupUPOriginalPathSelectButton.UseVisualStyleBackColor = false;
            this.setupUPOriginalPathSelectButton.Click += new System.EventHandler(this.SetupUPOriginalPathSelectButton_Click);
            // 
            // setupUPOriginalFilePathTextBox
            // 
            this.setupUPOriginalFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setupUPOriginalFilePathTextBox.Location = new System.Drawing.Point(5, 24);
            this.setupUPOriginalFilePathTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPOriginalFilePathTextBox.Name = "setupUPOriginalFilePathTextBox";
            this.setupUPOriginalFilePathTextBox.ReadOnly = true;
            this.setupUPOriginalFilePathTextBox.Size = new System.Drawing.Size(421, 20);
            this.setupUPOriginalFilePathTextBox.TabIndex = 1;
            this.setupUPOriginalFilePathTextBox.Text = "<File to Upgrade>";
            // 
            // setupUPOriginalFilePathLabel
            // 
            this.setupUPOriginalFilePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPOriginalFilePathLabel.Location = new System.Drawing.Point(2, 5);
            this.setupUPOriginalFilePathLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.setupUPOriginalFilePathLabel.Name = "setupUPOriginalFilePathLabel";
            this.setupUPOriginalFilePathLabel.Size = new System.Drawing.Size(104, 13);
            this.setupUPOriginalFilePathLabel.TabIndex = 0;
            this.setupUPOriginalFilePathLabel.Text = "Original File Path";
            // 
            // setupUPRunPanel
            // 
            this.setupUPLayoutPanel.SetColumnSpan(this.setupUPRunPanel, 2);
            this.setupUPRunPanel.Controls.Add(this.setupUPRunButton);
            this.setupUPRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPRunPanel.Location = new System.Drawing.Point(0, 316);
            this.setupUPRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupUPRunPanel.Name = "setupUPRunPanel";
            this.setupUPRunPanel.Size = new System.Drawing.Size(716, 29);
            this.setupUPRunPanel.TabIndex = 4;
            // 
            // setupUPRunButton
            // 
            this.setupUPRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setupUPRunButton.Location = new System.Drawing.Point(2, 2);
            this.setupUPRunButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPRunButton.Name = "setupUPRunButton";
            this.setupUPRunButton.Size = new System.Drawing.Size(60, 25);
            this.setupUPRunButton.TabIndex = 1;
            this.setupUPRunButton.Text = "RUN";
            this.setupUPRunButton.UseVisualStyleBackColor = true;
            this.setupUPRunButton.Click += new System.EventHandler(this.SetupUPRunButton_Click);
            // 
            // setupUPControlsPanel2
            // 
            this.setupUPControlsPanel2.Controls.Add(this.setupUPUpgradePathSelectButton);
            this.setupUPControlsPanel2.Controls.Add(this.setupUPOriginalDirectoryButton);
            this.setupUPControlsPanel2.Controls.Add(this.setupUPUpgradedFilePathLabel);
            this.setupUPControlsPanel2.Controls.Add(this.setupUPSlashLabel);
            this.setupUPControlsPanel2.Controls.Add(this.setupUPUpgradedFilePathUserTextBox);
            this.setupUPControlsPanel2.Controls.Add(this.setupUPUpgradedFilePathSetTextBox);
            this.setupUPControlsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPControlsPanel2.Location = new System.Drawing.Point(0, 55);
            this.setupUPControlsPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.setupUPControlsPanel2.Name = "setupUPControlsPanel2";
            this.setupUPControlsPanel2.Size = new System.Drawing.Size(466, 73);
            this.setupUPControlsPanel2.TabIndex = 7;
            // 
            // setupUPUpgradePathSelectButton
            // 
            this.setupUPUpgradePathSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setupUPUpgradePathSelectButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.setupUPUpgradePathSelectButton.Location = new System.Drawing.Point(433, 24);
            this.setupUPUpgradePathSelectButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPUpgradePathSelectButton.Name = "setupUPUpgradePathSelectButton";
            this.setupUPUpgradePathSelectButton.Size = new System.Drawing.Size(31, 20);
            this.setupUPUpgradePathSelectButton.TabIndex = 4;
            this.setupUPUpgradePathSelectButton.Text = "...";
            this.setupUPUpgradePathSelectButton.UseVisualStyleBackColor = false;
            this.setupUPUpgradePathSelectButton.Click += new System.EventHandler(this.SetupUPUpgradePathSelectButton_Click);
            // 
            // setupUPOriginalDirectoryButton
            // 
            this.setupUPOriginalDirectoryButton.Location = new System.Drawing.Point(5, 46);
            this.setupUPOriginalDirectoryButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPOriginalDirectoryButton.Name = "setupUPOriginalDirectoryButton";
            this.setupUPOriginalDirectoryButton.Size = new System.Drawing.Size(157, 21);
            this.setupUPOriginalDirectoryButton.TabIndex = 4;
            this.setupUPOriginalDirectoryButton.Text = "Use Original Path Directory";
            this.setupUPOriginalDirectoryButton.UseVisualStyleBackColor = true;
            this.setupUPOriginalDirectoryButton.Click += new System.EventHandler(this.SetupUPOriginalDirectoryButton_Click);
            // 
            // setupUPUpgradedFilePathLabel
            // 
            this.setupUPUpgradedFilePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPUpgradedFilePathLabel.Location = new System.Drawing.Point(2, 5);
            this.setupUPUpgradedFilePathLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.setupUPUpgradedFilePathLabel.Name = "setupUPUpgradedFilePathLabel";
            this.setupUPUpgradedFilePathLabel.Size = new System.Drawing.Size(116, 13);
            this.setupUPUpgradedFilePathLabel.TabIndex = 3;
            this.setupUPUpgradedFilePathLabel.Text = "Upgraded File Path";
            // 
            // setupUPSlashLabel
            // 
            this.setupUPSlashLabel.AutoSize = true;
            this.setupUPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPSlashLabel.Location = new System.Drawing.Point(166, 27);
            this.setupUPSlashLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.setupUPSlashLabel.Name = "setupUPSlashLabel";
            this.setupUPSlashLabel.Size = new System.Drawing.Size(13, 13);
            this.setupUPSlashLabel.TabIndex = 3;
            this.setupUPSlashLabel.Text = "\\";
            // 
            // setupUPUpgradedFilePathUserTextBox
            // 
            this.setupUPUpgradedFilePathUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setupUPUpgradedFilePathUserTextBox.Location = new System.Drawing.Point(183, 24);
            this.setupUPUpgradedFilePathUserTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPUpgradedFilePathUserTextBox.Name = "setupUPUpgradedFilePathUserTextBox";
            this.setupUPUpgradedFilePathUserTextBox.Size = new System.Drawing.Size(242, 20);
            this.setupUPUpgradedFilePathUserTextBox.TabIndex = 2;
            // 
            // setupUPUpgradedFilePathSetTextBox
            // 
            this.setupUPUpgradedFilePathSetTextBox.Location = new System.Drawing.Point(5, 24);
            this.setupUPUpgradedFilePathSetTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupUPUpgradedFilePathSetTextBox.Name = "setupUPUpgradedFilePathSetTextBox";
            this.setupUPUpgradedFilePathSetTextBox.ReadOnly = true;
            this.setupUPUpgradedFilePathSetTextBox.Size = new System.Drawing.Size(157, 20);
            this.setupUPUpgradedFilePathSetTextBox.TabIndex = 2;
            this.setupUPUpgradedFilePathSetTextBox.Text = "<Upgraded File Path>";
            // 
            // setupUPControlsPanel3
            // 
            this.setupUPControlsPanel3.Controls.Add(this.setupUPUpgradingToLabel);
            this.setupUPControlsPanel3.Controls.Add(this.setupUPUpgradingToRevitLabel);
            this.setupUPControlsPanel3.Controls.Add(this.setupUPUpgradingFromRevitLabel);
            this.setupUPControlsPanel3.Controls.Add(this.setupUPUpgradingFromLabel);
            this.setupUPControlsPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupUPControlsPanel3.Location = new System.Drawing.Point(0, 133);
            this.setupUPControlsPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.setupUPControlsPanel3.Name = "setupUPControlsPanel3";
            this.setupUPControlsPanel3.Size = new System.Drawing.Size(466, 40);
            this.setupUPControlsPanel3.TabIndex = 6;
            // 
            // setupUPUpgradingToLabel
            // 
            this.setupUPUpgradingToLabel.AutoSize = true;
            this.setupUPUpgradingToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPUpgradingToLabel.Location = new System.Drawing.Point(2, 23);
            this.setupUPUpgradingToLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.setupUPUpgradingToLabel.Name = "setupUPUpgradingToLabel";
            this.setupUPUpgradingToLabel.Size = new System.Drawing.Size(88, 13);
            this.setupUPUpgradingToLabel.TabIndex = 3;
            this.setupUPUpgradingToLabel.Text = "Upgrading To:";
            // 
            // setupUPUpgradingToRevitLabel
            // 
            this.setupUPUpgradingToRevitLabel.AutoSize = true;
            this.setupUPUpgradingToRevitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPUpgradingToRevitLabel.Location = new System.Drawing.Point(106, 23);
            this.setupUPUpgradingToRevitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.setupUPUpgradingToRevitLabel.Name = "setupUPUpgradingToRevitLabel";
            this.setupUPUpgradingToRevitLabel.Size = new System.Drawing.Size(31, 13);
            this.setupUPUpgradingToRevitLabel.TabIndex = 3;
            this.setupUPUpgradingToRevitLabel.Text = "2018";
            // 
            // setupUPUpgradingFromRevitLabel
            // 
            this.setupUPUpgradingFromRevitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPUpgradingFromRevitLabel.Location = new System.Drawing.Point(106, 5);
            this.setupUPUpgradingFromRevitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.setupUPUpgradingFromRevitLabel.Name = "setupUPUpgradingFromRevitLabel";
            this.setupUPUpgradingFromRevitLabel.Size = new System.Drawing.Size(73, 18);
            this.setupUPUpgradingFromRevitLabel.TabIndex = 3;
            this.setupUPUpgradingFromRevitLabel.Text = "<Unknown>";
            // 
            // setupUPUpgradingFromLabel
            // 
            this.setupUPUpgradingFromLabel.AutoSize = true;
            this.setupUPUpgradingFromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUPUpgradingFromLabel.Location = new System.Drawing.Point(2, 5);
            this.setupUPUpgradingFromLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.setupUPUpgradingFromLabel.Name = "setupUPUpgradingFromLabel";
            this.setupUPUpgradingFromLabel.Size = new System.Drawing.Size(100, 13);
            this.setupUPUpgradingFromLabel.TabIndex = 3;
            this.setupUPUpgradingFromLabel.Text = "Upgrading From:";
            // 
            // setupCWSLayoutPanel
            // 
            this.setupCWSLayoutPanel.AutoSize = true;
            this.setupCWSLayoutPanel.ColumnCount = 3;
            this.setupCWSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.setupCWSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.setupCWSLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSDefinedLabel, 2, 1);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSExtendedListBox, 1, 2);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSExtendedLabel, 1, 1);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSInstructionsPanel, 0, 0);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSDefaultLabel, 0, 1);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSDefaultListBox, 0, 2);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSUserDataGridView, 2, 2);
            this.setupCWSLayoutPanel.Controls.Add(this.setupCWSRunPanel, 0, 3);
            this.setupCWSLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.setupCWSLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSLayoutPanel.Name = "setupCWSLayoutPanel";
            this.setupCWSLayoutPanel.RowCount = 4;
            this.setupCWSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.setupCWSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.setupCWSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.setupCWSLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.setupCWSLayoutPanel.Size = new System.Drawing.Size(716, 345);
            this.setupCWSLayoutPanel.TabIndex = 1;
            this.setupCWSLayoutPanel.Visible = false;
            // 
            // setupCWSDefinedLabel
            // 
            this.setupCWSDefinedLabel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.setupCWSDefinedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupCWSDefinedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSDefinedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupCWSDefinedLabel.Location = new System.Drawing.Point(476, 110);
            this.setupCWSDefinedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSDefinedLabel.Name = "setupCWSDefinedLabel";
            this.setupCWSDefinedLabel.Size = new System.Drawing.Size(240, 35);
            this.setupCWSDefinedLabel.TabIndex = 1;
            this.setupCWSDefinedLabel.Text = "User Defined";
            this.setupCWSDefinedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setupCWSExtendedListBox
            // 
            this.setupCWSExtendedListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupCWSExtendedListBox.CheckOnClick = true;
            this.setupCWSExtendedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSExtendedListBox.FormattingEnabled = true;
            this.setupCWSExtendedListBox.Items.AddRange(new object[] {
            "LINK RVT A Site Control",
            "LINK RVT S Structural",
            "LINK RVT MEP Electrical",
            "LINK RVT MEP Mechanical",
            "LINK RVT MEP Plumbing"});
            this.setupCWSExtendedListBox.Location = new System.Drawing.Point(238, 145);
            this.setupCWSExtendedListBox.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSExtendedListBox.Name = "setupCWSExtendedListBox";
            this.setupCWSExtendedListBox.Size = new System.Drawing.Size(238, 165);
            this.setupCWSExtendedListBox.TabIndex = 1;
            // 
            // setupCWSExtendedLabel
            // 
            this.setupCWSExtendedLabel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.setupCWSExtendedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupCWSExtendedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSExtendedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupCWSExtendedLabel.Location = new System.Drawing.Point(238, 110);
            this.setupCWSExtendedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSExtendedLabel.Name = "setupCWSExtendedLabel";
            this.setupCWSExtendedLabel.Size = new System.Drawing.Size(238, 35);
            this.setupCWSExtendedLabel.TabIndex = 1;
            this.setupCWSExtendedLabel.Text = "BA Extended";
            this.setupCWSExtendedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setupCWSInstructionsPanel
            // 
            this.setupCWSLayoutPanel.SetColumnSpan(this.setupCWSInstructionsPanel, 3);
            this.setupCWSInstructionsPanel.Controls.Add(this.setupCWSInstructionsTextBox);
            this.setupCWSInstructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSInstructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.setupCWSInstructionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSInstructionsPanel.Name = "setupCWSInstructionsPanel";
            this.setupCWSInstructionsPanel.Size = new System.Drawing.Size(716, 110);
            this.setupCWSInstructionsPanel.TabIndex = 0;
            // 
            // setupCWSInstructionsTextBox
            // 
            this.setupCWSInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.setupCWSInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSInstructionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.setupCWSInstructionsTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setupCWSInstructionsTextBox.Multiline = true;
            this.setupCWSInstructionsTextBox.Name = "setupCWSInstructionsTextBox";
            this.setupCWSInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.setupCWSInstructionsTextBox.Size = new System.Drawing.Size(716, 110);
            this.setupCWSInstructionsTextBox.TabIndex = 0;
            this.setupCWSInstructionsTextBox.Text = resources.GetString("setupCWSInstructionsTextBox.Text");
            // 
            // setupCWSDefaultLabel
            // 
            this.setupCWSDefaultLabel.BackColor = System.Drawing.Color.GreenYellow;
            this.setupCWSDefaultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupCWSDefaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSDefaultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupCWSDefaultLabel.Location = new System.Drawing.Point(0, 110);
            this.setupCWSDefaultLabel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSDefaultLabel.Name = "setupCWSDefaultLabel";
            this.setupCWSDefaultLabel.Size = new System.Drawing.Size(238, 35);
            this.setupCWSDefaultLabel.TabIndex = 0;
            this.setupCWSDefaultLabel.Text = "BA Default";
            this.setupCWSDefaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setupCWSDefaultListBox
            // 
            this.setupCWSDefaultListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupCWSDefaultListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSDefaultListBox.FormattingEnabled = true;
            this.setupCWSDefaultListBox.Items.AddRange(new object[] {
            "Arch",
            "Shared Levels and Grids",
            "ID",
            "Life Safety"});
            this.setupCWSDefaultListBox.Location = new System.Drawing.Point(0, 145);
            this.setupCWSDefaultListBox.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSDefaultListBox.Name = "setupCWSDefaultListBox";
            this.setupCWSDefaultListBox.Size = new System.Drawing.Size(238, 165);
            this.setupCWSDefaultListBox.TabIndex = 0;
            // 
            // setupCWSUserDataGridView
            // 
            this.setupCWSUserDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.setupCWSUserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.setupCWSUserDataGridView.ColumnHeadersVisible = false;
            this.setupCWSUserDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorksetName});
            this.setupCWSUserDataGridView.ContextMenuStrip = this.mgmtSetupCWSUserContextMenu;
            this.setupCWSUserDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSUserDataGridView.Location = new System.Drawing.Point(476, 145);
            this.setupCWSUserDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSUserDataGridView.Name = "setupCWSUserDataGridView";
            this.setupCWSUserDataGridView.RowHeadersVisible = false;
            this.setupCWSUserDataGridView.RowHeadersWidth = 250;
            this.setupCWSUserDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.setupCWSUserDataGridView.Size = new System.Drawing.Size(240, 165);
            this.setupCWSUserDataGridView.TabIndex = 2;
            this.setupCWSUserDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SetupCWSUserDataGridView_CellMouseUp);
            // 
            // WorksetName
            // 
            this.WorksetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorksetName.HeaderText = "Workset Name";
            this.WorksetName.Name = "WorksetName";
            this.WorksetName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // setupCWSRunPanel
            // 
            this.setupCWSLayoutPanel.SetColumnSpan(this.setupCWSRunPanel, 3);
            this.setupCWSRunPanel.Controls.Add(this.setupCWSRunButton);
            this.setupCWSRunPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupCWSRunPanel.Location = new System.Drawing.Point(0, 310);
            this.setupCWSRunPanel.Margin = new System.Windows.Forms.Padding(0);
            this.setupCWSRunPanel.Name = "setupCWSRunPanel";
            this.setupCWSRunPanel.Size = new System.Drawing.Size(716, 35);
            this.setupCWSRunPanel.TabIndex = 6;
            // 
            // setupCWSRunButton
            // 
            this.setupCWSRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setupCWSRunButton.Location = new System.Drawing.Point(637, 6);
            this.setupCWSRunButton.Name = "setupCWSRunButton";
            this.setupCWSRunButton.Size = new System.Drawing.Size(75, 23);
            this.setupCWSRunButton.TabIndex = 0;
            this.setupCWSRunButton.Text = "RUN";
            this.setupCWSRunButton.UseVisualStyleBackColor = true;
            this.setupCWSRunButton.Click += new System.EventHandler(this.SetupCWSRunButton_Click);
            // 
            // UIFormMenuStrip
            // 
            this.UIFormMenuStrip.AutoSize = false;
            this.UIFormMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UIFormMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.UIFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.UIFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.UIFormMenuStrip.Name = "UIFormMenuStrip";
            this.UIFormMenuStrip.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.UIFormMenuStrip.Size = new System.Drawing.Size(769, 1);
            this.UIFormMenuStrip.TabIndex = 2;
            this.UIFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 0);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // dataFamiliesBAPParametersContextMenu
            // 
            this.dataFamiliesBAPParametersContextMenu.BackColor = System.Drawing.SystemColors.Control;
            this.dataFamiliesBAPParametersContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dataFamiliesBAPParametersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familiesBAPParametersRowDeleteTool});
            this.dataFamiliesBAPParametersContextMenu.Name = "BIMFamiliesBAPParametersContextMenu";
            this.dataFamiliesBAPParametersContextMenu.Size = new System.Drawing.Size(134, 26);
            // 
            // familiesBAPParametersRowDeleteTool
            // 
            this.familiesBAPParametersRowDeleteTool.Name = "familiesBAPParametersRowDeleteTool";
            this.familiesBAPParametersRowDeleteTool.Size = new System.Drawing.Size(133, 22);
            this.familiesBAPParametersRowDeleteTool.Text = "Delete Row";
            this.familiesBAPParametersRowDeleteTool.Click += new System.EventHandler(this.AdminFamiliesBAPParametersRowDeleteTool_Click);
            // 
            // dataFamiliesBRPParametersContextMenu
            // 
            this.dataFamiliesBRPParametersContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.dataFamiliesBRPParametersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataFamiliesBRPParametersRowDeleteTool});
            this.dataFamiliesBRPParametersContextMenu.Name = "BIMFamiliesBRPParametersContextMenu";
            this.dataFamiliesBRPParametersContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // dataFamiliesBRPParametersRowDeleteTool
            // 
            this.dataFamiliesBRPParametersRowDeleteTool.Name = "dataFamiliesBRPParametersRowDeleteTool";
            this.dataFamiliesBRPParametersRowDeleteTool.Size = new System.Drawing.Size(107, 22);
            this.dataFamiliesBRPParametersRowDeleteTool.Text = "Delete";
            this.dataFamiliesBRPParametersRowDeleteTool.Click += new System.EventHandler(this.AdminFamiliesBRPParametersRowDeleteTool_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(769, 451);
            this.Controls.Add(this.UIFormTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(429, 161);
            this.Name = "MainUI";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BART";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainUI_FormClosed);
            adminTab.ResumeLayout(false);
            this.adminManagementTabControl.ResumeLayout(false);
            this.adminAboutTab.ResumeLayout(false);
            this.adminAboutTab.PerformLayout();
            this.adminDataTab.ResumeLayout(false);
            this.adminDataTabLayoutPanel.ResumeLayout(false);
            this.adminDataToolStrip.ResumeLayout(false);
            this.adminDataToolStrip.PerformLayout();
            this.adminDataToolsPanel.ResumeLayout(false);
            this.adminDataGFFLayoutPanel.ResumeLayout(false);
            this.adminDataGFFCollectDataPanel.ResumeLayout(false);
            this.adminDataGFFSqlExportPanel.ResumeLayout(false);
            this.adminDataGFFCsvExportPanel.ResumeLayout(false);
            this.adminDataGFFCsvExportPanel.PerformLayout();
            this.adminDataGFFCollectionPanel.ResumeLayout(false);
            this.adminDataGFFCollectionLayoutPanel.ResumeLayout(false);
            this.adminDataGFFCollectionFastLabelPanel.ResumeLayout(false);
            this.adminDataGFFCollectionFastLabelPanel.PerformLayout();
            this.adminDataGFFCollectionSlowLabelPanel.ResumeLayout(false);
            this.adminDataGFFCollectionSlowLabelPanel.PerformLayout();
            this.adminDataGFFCollectionSlowestLabelPanel.ResumeLayout(false);
            this.adminDataGFFCollectionSlowestLabelPanel.PerformLayout();
            this.adminDataGFFCollectionsFastCheckedListPanel.ResumeLayout(false);
            this.adminDataGFFCollectionsSlowCheckedListPanel.ResumeLayout(false);
            this.adminDataGFFCollectionsSlowestCheckedListPanel.ResumeLayout(false);
            this.adminDataGFFSearchDirectoryPanel.ResumeLayout(false);
            this.adminDataGFFSearchDirectoryPanel.PerformLayout();
            this.adminDataGFFDatePanel.ResumeLayout(false);
            this.adminDataGFFDatePanel.PerformLayout();
            this.adminDataGBDVLayoutPanel.ResumeLayout(false);
            this.adminDataGBDVCollectPanel.ResumeLayout(false);
            this.adminDataGBDVCollectPanel.PerformLayout();
            this.adminDataGBDVExportDbPanel.ResumeLayout(false);
            this.adminDataGBDVExportCsvPanel.ResumeLayout(false);
            this.adminDataGBDVExportCsvPanel.PerformLayout();
            this.adminFamiliesTab.ResumeLayout(false);
            this.adminFamiliesLayoutPanel.ResumeLayout(false);
            this.adminFamiliesToolStrip.ResumeLayout(false);
            this.adminFamiliesToolStrip.PerformLayout();
            this.adminFamiliesToolsPanel.ResumeLayout(false);
            this.adminFamiliesBAPLayoutPanel.ResumeLayout(false);
            this.adminFamiliesBAPRunPanel.ResumeLayout(false);
            this.adminFamiliesBAPRunPanel.PerformLayout();
            this.adminFamiliesBAPSplitPanel.ResumeLayout(false);
            this.adminFamiliesBAPSplitContainer.Panel1.ResumeLayout(false);
            this.adminFamiliesBAPSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPSplitContainer)).EndInit();
            this.adminFamiliesBAPSplitContainer.ResumeLayout(false);
            this.adminFamiliesBAPParametersLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPParametersDGV)).EndInit();
            this.adminFamiliesBAPSharedParametersPanel.ResumeLayout(false);
            this.adminFamiliesBAPSharedParametersPanel.PerformLayout();
            this.adminFamiliesBAPSelectLayoutPanel.ResumeLayout(false);
            this.adminFamiliesBAPSelectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBAPFamiliesDGV)).EndInit();
            this.adminFamiliesBAPFamiliesDirectoryPanel.ResumeLayout(false);
            this.adminFamiliesUFLayoutPanel.ResumeLayout(false);
            this.adminFamiliesUFFullSyncPanel.ResumeLayout(false);
            this.adminFamiliesUFFullSyncPanel.PerformLayout();
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.ResumeLayout(false);
            this.adminFamiliesUFUpgradedFamiliesTextBoxPanel.PerformLayout();
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.ResumeLayout(false);
            this.adminFamiliesUFDeletedFamiliesTextBoxPanel.PerformLayout();
            this.adminFamiliesUFRunPanel.ResumeLayout(false);
            this.adminFamiliesBRPLayoutPanel.ResumeLayout(false);
            this.adminFamiliesBRPRunPanel.ResumeLayout(false);
            this.adminFamiliesBRPSplitPanel.ResumeLayout(false);
            this.adminFamiliesBRPSplitContainer.Panel1.ResumeLayout(false);
            this.adminFamiliesBRPSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPSplitContainer)).EndInit();
            this.adminFamiliesBRPSplitContainer.ResumeLayout(false);
            this.adminFamiliesBRPParametersLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPParametersDGV)).EndInit();
            this.adminFamiliesBPRSFamiliesLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesBRPFamiliesDGV)).EndInit();
            this.adminFamiliesBRPSelectPanel.ResumeLayout(false);
            this.adminFamiliesBRPCsvDirectoryPanel.ResumeLayout(false);
            this.adminFamiliesDFBLayoutPanel.ResumeLayout(false);
            this.adminFamiliesDFBSelectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminFamiliesDFBFamiliesDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.adminTemplateTab.ResumeLayout(false);
            this.adminTemplateLayoutPanel.ResumeLayout(false);
            this.adminTemplateLayoutPanel.PerformLayout();
            this.adminTemplateToolStrip.ResumeLayout(false);
            this.adminTemplateToolStrip.PerformLayout();
            this.adminTemplateToolsPanel.ResumeLayout(false);
            this.adminTemplatePMLayoutPanel.ResumeLayout(false);
            this.adminTemplatePMPickPackagePanel.ResumeLayout(false);
            this.adminTemplatePMPickPackagePanel.PerformLayout();
            this.adminTemplateSavePackagePanel.ResumeLayout(false);
            this.adminTemplateSavePackagePanel.PerformLayout();
            this.sandBoxTab.ResumeLayout(false);
            this.sandBoxLayoutPanel.ResumeLayout(false);
            this.sandBoxLayoutPanel.PerformLayout();
            this.sandBoxToolStrip.ResumeLayout(false);
            this.sandBoxToolStrip.PerformLayout();
            roomsToolStrip.ResumeLayout(false);
            roomsToolStrip.PerformLayout();
            this.mgmtSetupCWSUserContextMenu.ResumeLayout(false);
            this.UIFormTableLayoutPanel.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.aboutTab.ResumeLayout(false);
            this.aboutTabLayoutPanel.ResumeLayout(false);
            this.aboutTabHeaderPanel.ResumeLayout(false);
            this.aboutTabHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutTabLogo)).EndInit();
            this.aboutTabFooterPanel.ResumeLayout(false);
            this.aboutTabFooterPanel.PerformLayout();
            this.analysisTab.ResumeLayout(false);
            this.analysisTabControl.ResumeLayout(false);
            this.modelingTab.ResumeLayout(false);
            this.modelingTabControl.ResumeLayout(false);
            this.multiCatTab.ResumeLayout(false);
            this.multiCatLayoutPanel.ResumeLayout(false);
            this.multiCatToolStrip.ResumeLayout(false);
            this.multiCatToolStrip.PerformLayout();
            this.multiCatToolsPanel.ResumeLayout(false);
            this.multiCatCFFSplitContainer.Panel1.ResumeLayout(false);
            this.multiCatCFFSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFSplitContainer)).EndInit();
            this.multiCatCFFSplitContainer.ResumeLayout(false);
            this.multiCatCFFEExcelSplitContainer.Panel1.ResumeLayout(false);
            this.multiCatCFFEExcelSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEExcelSplitContainer)).EndInit();
            this.multiCatCFFEExcelSplitContainer.ResumeLayout(false);
            this.multiCatCFFECreateExcelLayoutPanel1.ResumeLayout(false);
            this.multiCatCFFECreateExcelLayoutPanel1.PerformLayout();
            this.multiCatCFFECreateExcelLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEExcelDGV)).EndInit();
            this.multiCatCFFEExcelRunPanel.ResumeLayout(false);
            this.multiCatCFFEExcelRunPanel.PerformLayout();
            this.multiCatCFFEDirectoryPanel.ResumeLayout(false);
            this.multiCatCFFEDirectoryPanel.PerformLayout();
            this.multiCatCFFESelectFamilyPanel.ResumeLayout(false);
            this.multiCatCFFESelectFamilyPanel.PerformLayout();
            this.multiCatCFFEFamiliesSplitContainer.Panel1.ResumeLayout(false);
            this.multiCatCFFEFamiliesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEFamiliesSplitContainer)).EndInit();
            this.multiCatCFFEFamiliesSplitContainer.ResumeLayout(false);
            this.multiCatCFFECreateFamiliesLayoutPanel1.ResumeLayout(false);
            this.multiCatCFFECreateFamiliesLayoutPanel1.PerformLayout();
            this.multiCatCFFECreateFamiliesLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiCatCFFEFamiliesDGV)).EndInit();
            this.multiCatCFFEFamiliesExcelPanel.ResumeLayout(false);
            this.multiCatCFFEFamiliesExcelPanel.PerformLayout();
            this.multiCatCFFEFamiliesRunPanel.ResumeLayout(false);
            this.multiCatCFFEFamilyCreationPanel.ResumeLayout(false);
            this.multiCatCFFEFamilyCreationPanel.PerformLayout();
            this.electricalTab.ResumeLayout(false);
            this.electricalLayoutPanel.ResumeLayout(false);
            this.electricalToolStrip.ResumeLayout(false);
            this.electricalToolStrip.PerformLayout();
            this.electricalToolsPanel.ResumeLayout(false);
            this.electricalCEOELayoutPanel.ResumeLayout(false);
            this.electricalCEOELayoutPanel.PerformLayout();
            this.electricalCEOEControlsPanel.ResumeLayout(false);
            this.floorsTab.ResumeLayout(false);
            this.floorsTabLayoutPanel.ResumeLayout(false);
            this.floorsToolsPanel.ResumeLayout(false);
            this.floorsCFBRLayoutPanel.ResumeLayout(false);
            this.floorsCFBRInstructionsPanel.ResumeLayout(false);
            this.floorsCFBRInstructionsPanel.PerformLayout();
            this.floorsCFBRControlsPanel.ResumeLayout(false);
            this.floorsCFBRControlsPanel.PerformLayout();
            this.floorsToolStrip.ResumeLayout(false);
            this.floorsToolStrip.PerformLayout();
            this.materialsTab.ResumeLayout(false);
            this.materialsLayoutPanel.ResumeLayout(false);
            this.materialsToolStrip.ResumeLayout(false);
            this.materialsToolStrip.PerformLayout();
            this.materialsToolsPanel.ResumeLayout(false);
            this.materialsAMLLayoutPanel.ResumeLayout(false);
            this.materialsAMLLayoutPanel.PerformLayout();
            this.materialsAMLHeaderPanel.ResumeLayout(false);
            this.materialsAMLHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsAMLDataGridView)).EndInit();
            this.materialsAMLLaunchPanel.ResumeLayout(false);
            this.materialsAMLLaunchPanel.PerformLayout();
            this.materialsCMSExcelLayoutPanel.ResumeLayout(false);
            this.materialsCMSExcelLayoutPanel.PerformLayout();
            this.materialsCMSExcelExportPanel.ResumeLayout(false);
            this.materialsCMSExcelExportPanel.PerformLayout();
            this.materialsCMSExcelRunPanel.ResumeLayout(false);
            this.materialsCMSExcelImportPanel.ResumeLayout(false);
            this.materialsCMSExcelImportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsCMSExcelDataGridView)).EndInit();
            this.roomsTab.ResumeLayout(false);
            this.roomsTabLayoutPanel.ResumeLayout(false);
            this.roomsToolsPanel.ResumeLayout(false);
            this.roomsCDRTLayoutPanel.ResumeLayout(false);
            this.roomsCDRTLayoutPanel.PerformLayout();
            this.roomsCDRTControlsPanel.ResumeLayout(false);
            this.roomsSRNNLayoutPanel.ResumeLayout(false);
            this.roomsSRNNPanel.ResumeLayout(false);
            this.roomsSRRNUrlPanel.ResumeLayout(false);
            this.roomsSRRNUrlPanel.PerformLayout();
            this.wallsTab.ResumeLayout(false);
            this.wallsTabLayoutPanel.ResumeLayout(false);
            this.wallsToolStrip.ResumeLayout(false);
            this.wallsToolStrip.PerformLayout();
            this.wallsToolsPanel.ResumeLayout(false);
            this.wallsDPLayoutPanel.ResumeLayout(false);
            this.wallsDPLayoutPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.wallsMPWLayoutPanel.ResumeLayout(false);
            this.wallsMPWControlsPanel.ResumeLayout(false);
            this.wallsMPWControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wallsMPWNumericUpDownWallHeightIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallsMPWNumericUpDownWallHeightFt)).EndInit();
            this.wallsMPWInstructionsPanel.ResumeLayout(false);
            this.wallsMPWInstructionsPanel.PerformLayout();
            this.documentationTab.ResumeLayout(false);
            this.documentationTabControl.ResumeLayout(false);
            this.sheetsTab.ResumeLayout(false);
            this.sheetsTabLayoutPanel.ResumeLayout(false);
            this.sheetsToolStrip.ResumeLayout(false);
            this.sheetsToolStrip.PerformLayout();
            this.sheetsToolsPanel.ResumeLayout(false);
            this.sheetsCSLLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sheetsCSLDataGridView)).EndInit();
            this.sheetsCSLControlsPanel.ResumeLayout(false);
            this.sheetsCSLControlsPanel.PerformLayout();
            this.sheetsCSLInstructionsPanel.ResumeLayout(false);
            this.sheetsOSSLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sheetsOSSDataGridView)).EndInit();
            this.sheetsOSSInstructionsPanel.ResumeLayout(false);
            this.sheetsOSSInstructionsPanel.PerformLayout();
            this.sheetsOSSFilterPanel.ResumeLayout(false);
            this.sheetsOSSFilterPanel.PerformLayout();
            this.sheetsOSSNewSetPanel.ResumeLayout(false);
            this.sheetsOSSNewSetPanel.PerformLayout();
            this.sheetsOSSControlsPanel.ResumeLayout(false);
            this.sheetsOSSControlsPanel.PerformLayout();
            this.sheetsISFLLayoutPanel.ResumeLayout(false);
            this.sheetsISFLInstructionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sheetsISFLDataGridView)).EndInit();
            this.sheetsISFLControlsPanel.ResumeLayout(false);
            this.sheetsISFLControlsPanel.PerformLayout();
            this.sheetsIFSLDisciplinePanel.ResumeLayout(false);
            this.sheetsIFSLDisciplinePanel.PerformLayout();
            this.sheetsCSSFSLayoutPanel.ResumeLayout(false);
            this.sheetsCSSFSInstructionsPanel.ResumeLayout(false);
            this.sheetsCSSFSInstructionsPanel.PerformLayout();
            this.sheetsCSSFSControlsPanel.ResumeLayout(false);
            this.sheetsCSSFSControlsPanel.PerformLayout();
            this.viewsTab.ResumeLayout(false);
            this.viewsTabLayoutPanel.ResumeLayout(false);
            this.viewsToolStrip.ResumeLayout(false);
            this.viewsToolStrip.PerformLayout();
            this.viewsToolsPanel.ResumeLayout(false);
            this.viewsCEPRLayoutPanel.ResumeLayout(false);
            this.viewsCEPRControlsPanel.ResumeLayout(false);
            this.viewsCEPRControlsPanel.PerformLayout();
            this.viewsCEPRInstructionsPanel.ResumeLayout(false);
            this.viewsCEPRInstructionsPanel.PerformLayout();
            this.viewsCEPRUrlPanel.ResumeLayout(false);
            this.viewsCEPRUrlPanel.PerformLayout();
            this.viewsHNIECLayoutPanel.ResumeLayout(false);
            this.viewsHNIECInstructionsPanel.ResumeLayout(false);
            this.viewsHNIECControlsPanel.ResumeLayout(false);
            this.viewsOICBLayoutPanel.ResumeLayout(false);
            this.viewsOICBInstructionsPanel.ResumeLayout(false);
            this.viewsOICBControlsPanel.ResumeLayout(false);
            this.managementTab.ResumeLayout(false);
            this.managmentTabControl.ResumeLayout(false);
            this.dataTab.ResumeLayout(false);
            this.dataTabLayoutPanel.ResumeLayout(false);
            this.dataToolStrip.ResumeLayout(false);
            this.dataToolStrip.PerformLayout();
            this.dataToolsPanel.ResumeLayout(false);
            this.dataEPILayoutPanel.ResumeLayout(false);
            this.dataEPIInstructionsPanel.ResumeLayout(false);
            this.dataEPIControlsPanel.ResumeLayout(false);
            this.dataEPIControlsPanel.PerformLayout();
            this.documentsTab.ResumeLayout(false);
            this.documentsLayoutPanel.ResumeLayout(false);
            this.documentsToolStrip.ResumeLayout(false);
            this.documentsToolStrip.PerformLayout();
            this.documentsToolsPanel.ResumeLayout(false);
            this.documentsCTSPanel.ResumeLayout(false);
            this.miscTab.ResumeLayout(false);
            this.miscToolsLayoutPanel.ResumeLayout(false);
            this.miscToolStrip.ResumeLayout(false);
            this.miscToolStrip.PerformLayout();
            this.miscToolsPanel.ResumeLayout(false);
            this.miscEDVLayoutPanel.ResumeLayout(false);
            this.miscEDVInstructionsPanel.ResumeLayout(false);
            this.miscEDVInstructionsPanel.PerformLayout();
            this.miscEDVRunPanel.ResumeLayout(false);
            this.miscEDVDirectoryPanel.ResumeLayout(false);
            this.miscEDVDirectoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miscEDVDataGridView)).EndInit();
            this.miscEDVControlsPanel.ResumeLayout(false);
            this.miscEDVControlsPanel.PerformLayout();
            this.qaqcTab.ResumeLayout(false);
            this.qaqcLayoutPanel.ResumeLayout(false);
            this.qaqcToolStrip.ResumeLayout(false);
            this.qaqcToolStrip.PerformLayout();
            this.qaqcToolsPanel.ResumeLayout(false);
            this.qaqcRFSPLayoutPanel.ResumeLayout(false);
            this.qaqcRFSPLayoutPanel.PerformLayout();
            this.qaqcRFSPToolsPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.qaqcRLSLayoutPanel.ResumeLayout(false);
            this.qaqcRLSLayoutPanel.PerformLayout();
            this.qaqcRLSRunPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qaqcRLSDataGridView)).EndInit();
            this.qaqcRLSControlsPanel.ResumeLayout(false);
            this.qaqcRLSControlsPanel.PerformLayout();
            this.qaqcRLSUnswitchablePanel.ResumeLayout(false);
            this.qaqcRLSUnswitchablePanel.PerformLayout();
            this.qaqcCSVNPanel.ResumeLayout(false);
            this.qaqcCSVLayoutPanel.ResumeLayout(false);
            this.qaqcCSVControlsPanel.ResumeLayout(false);
            this.qaqcCSVInstructionsPanel.ResumeLayout(false);
            this.qaqcDRNPPanel.ResumeLayout(false);
            this.setupTab.ResumeLayout(false);
            this.setupLayoutPanel.ResumeLayout(false);
            this.setupToolStrip.ResumeLayout(false);
            this.setupToolStrip.PerformLayout();
            this.setupToolsPanel.ResumeLayout(false);
            this.setupToolsPanel.PerformLayout();
            this.setupUPLayoutPanel.ResumeLayout(false);
            this.setupUPLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setupUPDataGridView)).EndInit();
            this.setupUPControlsPanel1.ResumeLayout(false);
            this.setupUPControlsPanel1.PerformLayout();
            this.setupUPRunPanel.ResumeLayout(false);
            this.setupUPControlsPanel2.ResumeLayout(false);
            this.setupUPControlsPanel2.PerformLayout();
            this.setupUPControlsPanel3.ResumeLayout(false);
            this.setupUPControlsPanel3.PerformLayout();
            this.setupCWSLayoutPanel.ResumeLayout(false);
            this.setupCWSInstructionsPanel.ResumeLayout(false);
            this.setupCWSInstructionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setupCWSUserDataGridView)).EndInit();
            this.setupCWSRunPanel.ResumeLayout(false);
            this.UIFormMenuStrip.ResumeLayout(false);
            this.UIFormMenuStrip.PerformLayout();
            this.dataFamiliesBAPParametersContextMenu.ResumeLayout(false);
            this.dataFamiliesBRPParametersContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion       
        private TableLayoutPanel UIFormTableLayoutPanel;
        private ContextMenuStrip dataFamiliesBAPParametersContextMenu;
        private ToolStripMenuItem familiesBAPParametersRowDeleteTool;
        private ContextMenuStrip dataFamiliesBRPParametersContextMenu;
        private ToolStripMenuItem dataFamiliesBRPParametersRowDeleteTool;
        private ContextMenuStrip mgmtSetupCWSUserContextMenu;
        private ToolStripMenuItem setupCWSRowDeleteTool;
        private TabControl mainTabControl;
        private TabPage aboutTab;
        private TableLayoutPanel aboutTabLayoutPanel;
        private Panel aboutTabHeaderPanel;
        private LinkLabel aboutTabDevelopmentLinkURLLabel;
        private Label aboutTabDevelopmentLinkLabel;
        private LinkLabel aboutTabLearningLinkURLLabel;
        private Label aboutTabLearningLinkLabel;
        private PictureBox aboutTabLogo;
        private Label aboutPublishLabel;
        private Label aboutTabVersionLabel;
        private Label aboutTabTitleLabel;
        private Panel aboutTabFooterPanel;
        private Label aboutCreditLabel;
        private RichTextBox aboutTabUpdatesTextBox;
        private TabPage analysisTab;
        private TabControl analysisTabControl;
        private TabPage sightTab;
        private TabPage modelingTab;
        private TabControl modelingTabControl;
        private TabPage multiCatTab;
        private TableLayoutPanel multiCatLayoutPanel;
        private ToolStrip multiCatToolStrip;
        public ToolStripButton multiCatCFFEButton;
        private ToolStripSeparator multiCatSeparator1;
        private ToolStripButton multiCatRE;
        private SplitContainer multiCatCFFSplitContainer;
        private SplitContainer multiCatCFFEExcelSplitContainer;
        private TableLayoutPanel multiCatCFFECreateExcelLayoutPanel1;
        private Label multiCatCFFECreateExcelLabel;
        private TextBox multiCatCFFECreateExcelInstructions;
        private TableLayoutPanel multiCatCFFECreateExcelLayoutPanel2;
        public DataGridView multiCatCFFEExcelDGV;
        private Panel multiCatCFFEExcelRunPanel;
        public Label multiCatCFFEExcelStatusLabel;
        private Button multiCatCFFEExcelRunButton;
        private Panel multiCatCFFEDirectoryPanel;
        private Button multiCatCFFEDirectorySelectButton;
        public TextBox multiCatCFFEDirectoryTextBox;
        private Panel multiCatCFFESelectFamilyPanel;
        private Button multiCatCFFESelectFamilyButton;
        public TextBox multiCatCFFESelectFamilyTextBox;
        private SplitContainer multiCatCFFEFamiliesSplitContainer;
        private TableLayoutPanel multiCatCFFECreateFamiliesLayoutPanel1;
        private Label multiCatCFFECreateFamiliesLabel;
        private TextBox multiCatCFFECreateFamiliesInstructions;
        private TableLayoutPanel multiCatCFFECreateFamiliesLayoutPanel2;
        public DataGridView multiCatCFFEFamiliesDGV;
        private Panel multiCatCFFEFamiliesExcelPanel;
        public TextBox allCATCFFEFamiliesSaveDirectoryTextBox;
        private Button multiCatCFFEFamiliesSaveDirectoryButton;
        private Button multiCatCFFEExcelSelectButton;
        private Panel multiCatCFFEFamiliesRunPanel;
        public ProgressBar multiCatCFFEFamiliesProgressBar;
        private Button multiCatCFFEFamiliesRunButton;
        private Panel multiCatCFFEFamilyCreationPanel;
        private Label multiCatCFFEFamilyCreationLabel;
        public ComboBox multiCatCFFEFamilyCreationComboBox;
        private TabPage doorsTab;
        private TabPage electricalTab;
        private TableLayoutPanel electricalLayoutPanel;
        private ToolStrip electricalToolStrip;
        private ToolStripButton electricalCEOEButton;
        private Panel electricalToolsPanel;
        private TableLayoutPanel electricalCEOELayoutPanel;
        private TextBox electricalCEOETextBox;
        private Panel electricalCEOEControlsPanel;
        private Button electricalCEOERunButton;
        private TabPage floorsTab;
        private TableLayoutPanel floorsTabLayoutPanel;
        private Panel floorsToolsPanel;
        private TableLayoutPanel floorsCFBRLayoutPanel;
        private Panel floorsCFBRInstructionsPanel;
        private TextBox floorsCFBRInstructionsTextBox;
        private Panel floorsCFBRControlsPanel;
        public CheckBox floorsCFBROffsetFinishFloorCheckBox;
        private Label floorsCFBRSelectFloorTypeLabel;
        private Label floorsCFBRSelectRoomsLabel;
        public ComboBox floorsCFBRSelectFloorTypeComboBox;
        private Button floorsCFBRRunButton;
        private Button floorsCFBRSelectRoomsButton;
        private ToolStrip floorsToolStrip;
        private ToolStripButton floorsCFBRButton;
        private TabPage massesTab;
        private TabPage materialsTab;
        private TableLayoutPanel materialsLayoutPanel;
        private ToolStrip materialsToolStrip;
        private ToolStripButton materialsCMSButton;
        private ToolStripSeparator materialsToolStripSeparator1;
        private ToolStripButton materialsAMLButton;
        private Panel materialsToolsPanel;
        public TableLayoutPanel materialsAMLLayoutPanel;
        private Panel materialsAMLHeaderPanel;
        private Label materialsAMLHeaderLabel;
        private TextBox materialsAMLInstructionsTextBox;
        public DataGridView materialsAMLDataGridView;
        private Panel materialsAMLLaunchPanel;
        private Button materialsAMLLaunchPaletteButton;
        private TableLayoutPanel materialsCMSExcelLayoutPanel;
        private Panel materialsCMSExcelExportPanel;
        private Button materialsCMSExcelCreateSpreadsheetButton;
        public TextBox materialsCMSExcelSpreadsheetNameTextBox;
        private Button materialsCMSExcelSelectSaveDirectoryButton;
        private Label materialsCMSExcelExportLabel;
        private Panel materialsCMSExcelRunPanel;
        public ProgressBar materialsCMSExcelCreateSymbolsProgressBar;
        private Button materialsCMSExcelCreateSymbolsButton;
        private Panel materialsCMSExcelImportPanel;
        public TextBox materialsCMSSetViewNameTextBox;
        private Label materialsCMSSetViewNameLabel;
        private Label materialsCMSExcelImportLabel;
        private Button materialsCMSExcelSelectImportFileButton;
        public DataGridView materialsCMSExcelDataGridView;
        private TextBox materialsCMSExcelInstructionsTextBox;
        private TabPage roomsTab;
        private TableLayoutPanel roomsTabLayoutPanel;
        private ToolStripButton roomsSRNNButton;
        private ToolStripSeparator roomsSeparator1;
        private ToolStripButton roomsCDRTButton;
        private Panel roomsToolsPanel;
        public TableLayoutPanel roomsCDRTLayoutPanel;
        private TextBox roomsCDRTInstructionsTextBox;
        private Panel roomsCDRTControlsPanel;
        private Button roomsCDRTRunButton;
        private TableLayoutPanel roomsSRNNLayoutPanel;
        private Label roomsSRNNInstructions;
        private Panel roomsSRNNPanel;
        private Button roomsSRNNRunButton;
        private Panel roomsSRRNUrlPanel;
        private Label roomsSRRNUrlLabel;
        private LinkLabel roomsSRRNUrlLinkLabel;
        private TabPage wallsTab;
        private TableLayoutPanel wallsTabLayoutPanel;
        private ToolStrip wallsToolStrip;
        private ToolStripButton wallsMPWButton;
        private ToolStripSeparator wallsToolStripSeparator1;
        private ToolStripButton wallsDPButton;
        private Panel wallsToolsPanel;
        private TableLayoutPanel wallsDPLayoutPanel;
        private TextBox wallsDPInstructionsTextBox;
        private Panel panel2;
        private Button wallsDPRunButton;
        private TableLayoutPanel wallsMPWLayoutPanel;
        private Panel wallsMPWControlsPanel;
        private Label wallsMPWLabelSelectWall;
        public NumericUpDown wallsMPWNumericUpDownWallHeightIn;
        private Label wallsMPWLabelSetWall;
        public NumericUpDown wallsMPWNumericUpDownWallHeightFt;
        private Label wallsMPWLabelWallHtFtTxt;
        public Button wallsMPWButtonRun;
        private Label wallsMPWLabelWallHtInTxt;
        public ComboBox wallsMPWComboBoxWall;
        private Panel wallsMPWInstructionsPanel;
        private TextBox textBox1;
        private TabPage documentationTab;
        private TabControl documentationTabControl;
        private TabPage sheetsTab;
        private TableLayoutPanel sheetsTabLayoutPanel;
        private ToolStrip sheetsToolStrip;
        private ToolStripButton sheetsCSLButton;
        private ToolStripSeparator sheetsSeparator1;
        private ToolStripButton sheetsISFLButton;
        private ToolStripSeparator sheetsSeparator2;
        private ToolStripSplitButton sheetsSheetSetsButton;
        private ToolStripMenuItem sheetsCSSFSButton;
        private ToolStripMenuItem sheetsOSSButton;
        private Panel sheetsToolsPanel;
        private TableLayoutPanel sheetsCSLLayoutPanel;
        private Button sheetsCLSRunButton;
        public DataGridView sheetsCSLDataGridView;
        private Panel sheetsCSLControlsPanel;
        public ComboBox sheetsCSLFilterConditionComboBox;
        public TextBox sheetsCSLFilterTextBox;
        private Label sheetsCSLCopyFromLabel;
        private Label sheetsCSLCopyToLabel;
        public ComboBox sheetsCSLComboBox;
        private Panel sheetsCSLInstructionsPanel;
        private Label sheetsCSLInstructionsLabel;
        private TableLayoutPanel sheetsOSSLayoutPanel;
        public DataGridView sheetsOSSDataGridView;
        private Panel sheetsOSSInstructionsPanel;
        private TextBox sheetsOSSInstructionsTextBox;
        private Panel sheetsOSSFilterPanel;
        public ComboBox sheetsOSSFilterFieldComboBox;
        public TextBox sheetsOSSFilterTextBox;
        public ComboBox sheetsOSSFilterConditionComboBox;
        private Label sheetsOSSFilterLabel;
        private Panel sheetsOSSNewSetPanel;
        private Button sheetsOSSNewSetButton;
        private Label sheetsOSSNewSetLabel;
        public TextBox sheetsOSSNewSetTextBox;
        private Panel sheetsOSSControlsPanel;
        private Button sheetsOSSRunButton;
        private Label sheetsOSSRunLabel;
        public TableLayoutPanel sheetsISFLLayoutPanel;
        private Panel sheetsISFLInstructionsPanel;
        private Label sheetsISFLInstructionsLabel;
        private Button sheetsISFLRunButton;
        public DataGridView sheetsISFLDataGridView;
        private Panel sheetsISFLControlsPanel;
        public ComboBox sheetsISFLComboBox;
        private Label sheetsISFLLabel1;
        private Label sheetsISFLLabel2;
        private Panel sheetsIFSLDisciplinePanel;
        private Button sheetsISFLDisciplineUpdateButton;
        private ComboBox sheetsISFLDisciplineComboBox;
        private Label sheetsISFLDisciplineLabel;
        private TableLayoutPanel sheetsCSSFSLayoutPanel;
        private Panel sheetsCSSFSInstructionsPanel;
        private TextBox sheetsCSSFSInstructionsTextBox;
        private Panel sheetsCSSFSControlsPanel;
        private Label sheetsCSSFSSScheduleLabel;
        private Label sheetsCSSFSSetNameLabel;
        public TextBox sheetsCSSFSSetNameTextBox;
        public ComboBox sheetsCSSFSScheduleComboBox;
        private Button sheetsCSSFSRunButton;
        private TabPage viewsTab;
        private TableLayoutPanel viewsTabLayoutPanel;
        private ToolStrip viewsToolStrip;
        private ToolStripButton viewsCEPRButton;
        private ToolStripSeparator viewsSeparator1;
        private ToolStripSplitButton viewsInteriorCropButton;
        private ToolStripMenuItem viewsOICBButton;
        private ToolStripMenuItem viewsHNIECButton;
        private Panel viewsToolsPanel;
        private TableLayoutPanel viewsCEPRLayoutPanel;
        private Panel viewsCEPRControlsPanel;
        private Button viewsCEPRRunButton;
        public CheckBox viewsCEPROverrideCheckBox;
        public CheckBox viewsCEPRCropCheckBox;
        public ComboBox viewsCEPRElevationComboBox;
        private Panel viewsCEPRInstructionsPanel;
        private TextBox viewsCEPRInstructionsTextBox;
        private Panel viewsCEPRUrlPanel;
        private Label viewsCEPRUrlLabel;
        private LinkLabel viewsCEPRUrlLinkLabel;
        private TableLayoutPanel viewsHNIECLayoutPanel;
        private Panel viewsHNIECInstructionsPanel;
        private Label viewsHNIECBInstructions;
        private Panel viewsHNIECControlsPanel;
        private Button viewsHNIECBRunButton;
        private TableLayoutPanel viewsOICBLayoutPanel;
        private Panel viewsOICBInstructionsPanel;
        private Label viewsOICBInstructionsLabel;
        private Panel viewsOICBControlsPanel;
        private Button elemViewsOCIBRunButton;
        private TabPage managementTab;
        private TabControl managmentTabControl;
        private TabPage dataTab;
        private TableLayoutPanel dataTabLayoutPanel;
        private ToolStrip dataToolStrip;
        private ToolStripButton dataEPIButton;
        private ToolStripSeparator dataSeparator1;
        private Panel dataToolsPanel;
        public TableLayoutPanel dataEPILayoutPanel;
        private Panel dataEPIInstructionsPanel;
        private Label dataEPIInstructionsLabel;
        private Panel dataEPIControlsPanel;
        public ComboBox dataEPIDPIComboBox;
        public Label dataEPIDirectorySelectedLabel;
        public TextBox dataEPISaveTextBox;
        private Button dataEPIRunButton;
        private Button dataEPIDirectoryButton;
        private Label dataEPIDPILabel;
        private Label dataEPIDirectoryLabel;
        private Label dataEPINameLabel;
        private TabPage documentsTab;
        private TableLayoutPanel documentsLayoutPanel;
        private ToolStrip documentsToolStrip;
        private ToolStripButton documentsCTSButton;
        private ToolStripSeparator documentsToolStripSeparator1;
        private ToolStripButton documentsPRP;
        private Panel documentsToolsPanel;
        private Panel documentsCTSPanel;
        public Button documentsCTSRun;
        private Label documentsCTSInstructions;
        private TabPage graphicsTab;
        private TabPage miscTab;
        private TableLayoutPanel miscToolsLayoutPanel;
        private ToolStrip miscToolStrip;
        private ToolStripButton miscEDVButton;
        private ToolStripSeparator miscSeparator1;
        private ToolStripButton miscEEVButton;
        private Panel miscToolsPanel;
        private TableLayoutPanel miscEDVLayoutPanel;
        private Panel miscEDVInstructionsPanel;
        private TextBox miscEDVInstructionsTextBox;
        private Panel miscEDVRunPanel;
        public ProgressBar miscEDVProgressBar;
        private Button miscEDVRunButton;
        private Panel miscEDVDirectoryPanel;
        public TextBox miscEDVSelectDirectoryTextBox;
        private Button miscEDVSelectDirectoryButton;
        public DataGridView miscEDVDataGridView;
        private Panel miscEDVControlsPanel;
        private Label miscEDVFilterLabel;
        public TextBox miscEDVFilterStringTextBox;
        public ComboBox miscEDVFilterConditionComboBox;
        private Button miscEDVSelectNoneButton;
        private Button miscEDVSelectAllButton;
        private TabPage qaqcTab;
        private TableLayoutPanel qaqcLayoutPanel;
        private ToolStrip qaqcToolStrip;
        private ToolStripSplitButton qaqcCapitalizeValuesButton;
        private ToolStripMenuItem capitalizeSheetViewNamesButton;
        private ToolStripMenuItem capitalizeScheduleValuesButton;
        private ToolStripSeparator qaqcToolStripSeparator1;
        private ToolStripButton qaqcDRNPButtton;
        private ToolStripSeparator qaqcToolStripSeparator2;
        private ToolStripButton qaqcRLSButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton qaqcRFSPButton;
        private Panel qaqcToolsPanel;
        private TableLayoutPanel qaqcRFSPLayoutPanel;
        private TextBox qaqcRFSPInstructionsTextBox;
        public ListBox qaqcRFSPParametersListBox;
        private Panel qaqcRFSPToolsPanel;
        public Label qaqcRFSPSFamilyLabel;
        private Button qaqcRFSPRunButton;
        private Button qaqcRFSPSelectFamilyButton;
        private Panel panel5;
        private Label label4;
        public TableLayoutPanel qaqcRLSLayoutPanel;
        private Panel qaqcRLSRunPanel;
        private Button qaqcRLSRunButton;
        private TextBox qaqcRLSInstructionsTextBox;
        public DataGridView qaqcRLSDataGridView;
        private Panel qaqcRLSControlsPanel;
        private Label qaqcRLSReplaceWithLabel;
        private Label qaqcRLSReplaceLabel;
        public ComboBox qaqcRLSReplaceWithComboBox;
        public CheckBox qaqcRLSDeleteCheckBox;
        public ComboBox qaqcRLSReplaceComboBox;
        private Panel qaqcRLSUnswitchablePanel;
        private Label label1;
        private Panel qaqcCSVNPanel;
        public Button qaqcCSVNRun;
        private Label qaqcCTVNInstructions;
        private TableLayoutPanel qaqcCSVLayoutPanel;
        private Panel qaqcCSVControlsPanel;
        private Button qaqcCSVRunButton;
        private Panel qaqcCSVInstructionsPanel;
        private Label qaqcCSVInstructionsLabel;
        private Panel qaqcDRNPPanel;
        private Label qaqcDRNPInstructions;
        public Button qaqcDRNPRun;
        private TabPage setupTab;
        private TableLayoutPanel setupLayoutPanel;
        private ToolStrip setupToolStrip;
        private ToolStripButton setupCWSButton;
        private ToolStripSeparator setupSeparator1;
        private ToolStripButton setupUPButton;
        private Panel setupToolsPanel;
        private TableLayoutPanel setupUPLayoutPanel;
        private TextBox setupUPInstructionsTextBox;
        public DataGridView setupUPDataGridView;
        private Label setupUPLinkedModelsLabel;
        private Panel setupUPControlsPanel1;
        private Button setupUPOriginalPathSelectButton;
        public TextBox setupUPOriginalFilePathTextBox;
        private Label setupUPOriginalFilePathLabel;
        private Panel setupUPRunPanel;
        private Button setupUPRunButton;
        private Panel setupUPControlsPanel2;
        private Button setupUPUpgradePathSelectButton;
        private Button setupUPOriginalDirectoryButton;
        private Label setupUPUpgradedFilePathLabel;
        private Label setupUPSlashLabel;
        public TextBox setupUPUpgradedFilePathUserTextBox;
        public TextBox setupUPUpgradedFilePathSetTextBox;
        private Panel setupUPControlsPanel3;
        private Label setupUPUpgradingToLabel;
        public Label setupUPUpgradingToRevitLabel;
        public Label setupUPUpgradingFromRevitLabel;
        private Label setupUPUpgradingFromLabel;
        private TableLayoutPanel setupCWSLayoutPanel;
        private Label setupCWSDefinedLabel;
        public CheckedListBox setupCWSExtendedListBox;
        private Label setupCWSExtendedLabel;
        private Panel setupCWSInstructionsPanel;
        private TextBox setupCWSInstructionsTextBox;
        private Label setupCWSDefaultLabel;
        public ListBox setupCWSDefaultListBox;
        public DataGridView setupCWSUserDataGridView;
        private DataGridViewTextBoxColumn WorksetName;
        private Panel setupCWSRunPanel;
        private Button setupCWSRunButton;
        private TabControl adminManagementTabControl;
        private TabPage adminAboutTab;
        private Label adminAboutReservedLabel;
        private Label adminAboutTitleLabel;
        private TabPage adminDataTab;
        private TableLayoutPanel adminDataTabLayoutPanel;
        private ToolStrip adminDataToolStrip;
        public ToolStripButton adminDataGFFButton;
        private ToolStripSeparator adminDataSeparator1;
        private ToolStripButton adminDataGPFButton;
        private ToolStripSeparator adminDataSeparator2;
        private ToolStripButton adminDataGBDVButton;
        private Panel adminDataToolsPanel;
        private TableLayoutPanel adminDataGFFLayoutPanel;
        private Panel adminDataGFFCollectDataPanel;
        public Label adminDataGFFCollectDataWaitLabel;
        public ProgressBar adminDataGFFDataProgressBar;
        private Button adminDataGFFCollectDataButton;
        private Panel adminDataGFFSqlExportPanel;
        private Button adminDataGFFSqlExportRunButton;
        private Label adminDataGFFSqlExportLabel;
        private Panel adminDataGFFCsvExportPanel;
        public TextBox adminDataGFFCsvExportDirectoryTextBox;
        private Button adminDataGFFCsvExportRunButton;
        public TextBox adminDataGFFCsvExportNameTextBox;
        private Label adminDataGFFCsvExportLabel;
        public Button adminDataGFFCsvExportDirectoryButton;
        private Panel adminDataGFFCollectionPanel;
        private TableLayoutPanel adminDataGFFCollectionLayoutPanel;
        private Panel adminDataGFFCollectionFastLabelPanel;
        private Label adminDataGFFCollectionFastLabel;
        public CheckBox adminDataGFFCollectionFastSelectAllCheckBox;
        private Panel adminDataGFFCollectionSlowLabelPanel;
        private Label adminDataGFFCollectionSlowLabel;
        public CheckBox adminDataGFFCollectionSlowSelectAllCheckBox;
        private Panel adminDataGFFCollectionSlowestLabelPanel;
        private Label adminDataGFFCollectionSlowestLabel;
        public CheckBox adminDataGFFCollectionSlowestSelectAllCheckBox;
        private Panel adminDataGFFCollectionsFastCheckedListPanel;
        public CheckedListBox adminDataGFFCollectionFastCheckedListBox;
        private Panel adminDataGFFCollectionsSlowCheckedListPanel;
        public CheckedListBox adminDataGFFCollectionSlowCheckedListBox;
        private Panel adminDataGFFCollectionsSlowestCheckedListPanel;
        public CheckedListBox adminDataGFFCollectionSlowestCheckedListBox;
        private Panel adminDataGFFSearchDirectoryPanel;
        public TextBox adminDataGFFSearchDirectoryTextBox;
        private Button adminDataGFFSearchDirectorySelectButton;
        private Panel adminDataGFFDatePanel;
        public DateTimePicker adminDataGFFDatePicker;
        public CheckBox adminDataGFFDateCheckBox;
        private TableLayoutPanel adminDataGBDVLayoutPanel;
        private Panel adminDataGBDVCollectPanel;
        public Label adminDataGBDVWaitLabel;
        private Button adminDataGBDVCollectButton;
        private Panel adminDataGBDVExportDbPanel;
        private Button adminDataGBDVExportDbRunButton;
        private Label adminDataGBDVExportDbLabel;
        private Panel adminDataGBDVExportCsvPanel;
        public TextBox adminDataGBDVExportCsvDirectoryTextBox;
        private Button adminDataGBDVExportCsvSelectDirectoryButton;
        private Button adminDataGBDVExportCsvRunButton;
        public TextBox adminDataGBDVExportCsvTextBox;
        private Label adminDataGBDVExportCsvLabel;
        private TabPage adminFamiliesTab;
        private TableLayoutPanel adminFamiliesLayoutPanel;
        private ToolStrip adminFamiliesToolStrip;
        private ToolStripButton adminFamiliesUFButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator adminFamiliesSeparator1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton adminFamiliesDFBButton;
        private Panel adminFamiliesToolsPanel;
        private TableLayoutPanel adminFamiliesUFLayoutPanel;
        private Panel adminFamiliesUFFullSyncPanel;
        private Panel adminFamiliesUFUpgradedFamiliesTextBoxPanel;
        private TextBox adminFamiliesUFUpgradedFamiliesTextBox;
        private Panel adminFamiliesUFDeletedFamiliesTextBoxPanel;
        private TextBox adminFamiliesUFDeletedFamiliesTextBox;
        private Panel adminFamiliesUFRunPanel;
        private Button adminFamiliesUFRunButton;
        private TableLayoutPanel adminFamiliesBAPLayoutPanel;
        private Panel adminFamiliesBAPRunPanel;
        public ProgressBar adminFamiliesBAPProgressBar;
        private Button adminFamiliesBAPRunButton;
        private Panel adminFamiliesBAPSplitPanel;
        private SplitContainer adminFamiliesBAPSplitContainer;
        private TableLayoutPanel adminFamiliesBAPParametersLayoutPanel;
        public DataGridView adminFamiliesBAPParametersDGV;
        private Panel adminFamiliesBAPSharedParametersPanel;
        private Button BIMFamiliesBAPSharedParametersButton;
        private TableLayoutPanel adminFamiliesBAPSelectLayoutPanel;
        private Panel adminFamiliesBAPSelectPanel;
        private Button adminFamiliesBAPSelectNoneButton;
        private Button adminFamiliesBAPSelectAllButton;
        public DataGridView adminFamiliesBAPFamiliesDGV;
        private Panel adminFamiliesBAPFamiliesDirectoryPanel;
        private Button adminFamiliesBAPDirectorySelectButton;
        private TableLayoutPanel adminFamiliesBRPLayoutPanel;
        private Panel adminFamiliesBRPRunPanel;
        public ProgressBar adminFamiliesBRPProgressBar;
        private Button adminFamiliesBRPRunButton;
        private Panel adminFamiliesBRPSplitPanel;
        private SplitContainer adminFamiliesBRPSplitContainer;
        private TableLayoutPanel adminFamiliesBRPParametersLayoutPanel;
        public DataGridView adminFamiliesBRPParametersDGV;
        private Panel adminFamiliesBRPParametersPanel;
        private TableLayoutPanel adminFamiliesBPRSFamiliesLayoutPanel;
        public DataGridView adminFamiliesBRPFamiliesDGV;
        private Panel adminFamiliesBRPSelectPanel;
        private Button adminFamiliesBRPSelectNoneButton;
        private Button adminFamiliesBRPSelectAllButton;
        private Panel adminFamiliesBRPCsvDirectoryPanel;
        private Button adminFamiliesBRPDirectorySelectButton;
        private TableLayoutPanel adminFamiliesDFBLayoutPanel;
        private Panel adminFamiliesDFBSelectPanel;
        private Button adminFamiliesDBFSelectNoneButton;
        private Button adminFamiliesDBFSelectAllButton;
        private Button adminFamiliesDFBSelectDirectoryButton;
        private DataGridView adminFamiliesDFBFamiliesDGV;
        private Panel panel1;
        private Button adminFamiliesDFBRunButton;
        private TabPage adminTemplateTab;
        private TableLayoutPanel adminTemplateLayoutPanel;
        private ToolStrip adminTemplateToolStrip;
        private ToolStripButton adminTemplatePMButton;
        private Panel adminTemplateToolsPanel;
        private TableLayoutPanel adminTemplatePMLayoutPanel;
        private Panel adminTemplatePMPickPackagePanel;
        private Button adminTemplatePMDeletePackateButton;
        private Label adminTemplatePMPickPackageLabel;
        public ComboBox adminTemplatePMPickPackageComboBox;
        private Panel adminTemplateSavePackagePanel;
        private Button adminTemplateSavePackagePublishButton;
        private ComboBox adminTemplateSavePackageComboBox;
        private Label adminTemplateSavePackageLabel;
        private TreeView adminTemplatePMTreeView;
        private TabPage sandBoxTab;
        private TableLayoutPanel sandBoxLayoutPanel;
        public System.Windows.Forms.Integration.ElementHost sandBoxElementHost;
        private ToolStrip sandBoxToolStrip;
        private ToolStripButton sandBoxTestButton1;
        private MenuStrip UIFormMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        public CheckBox adminFamiliesUFFullSyncCheckbox;
        public ListBox adminFamiliesUFUpgradedFamiliesListBox;
        public ListBox adminFamiliesUFDeletedFamiliesListBox;
        private ToolStripDropDownButton adminFamiliesParametersDropDownButton;
        private ToolStripMenuItem adminFamiliesBAPButton;
        private ToolStripMenuItem adminFamiliesBRPButton;
        private ToolStripMenuItem bulkUpdatePublishVersionToolStripMenuItem;
        public Panel multiCatToolsPanel;
        public Label adminFamiliesBAPDoneLabel;
    }
}

