﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BARevitTools.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tableau\\\\sqlexpress,1433")]
        public string SqlServerName {
            get {
                return ((string)(this["SqlServerName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("db_BARevitTools")]
        public string SqlBARevitToolsDbName {
            get {
                return ((string)(this["SqlBARevitToolsDbName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string SqlServerUser {
            get {
                return ((string)(this["SqlServerUser"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Boulder4747")]
        public string SqlServerPwd {
            get {
                return ((string)(this["SqlServerPwd"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mzabritski,administrator,kfronczak,enightingale,mwhitcomb")]
        public string BARTBAAdminUsers {
            get {
                return ((string)(this["BARTBAAdminUsers"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://bimhaus.boulderassociates.com/bart")]
        public string UrlBARTLearning {
            get {
                return ((string)(this["UrlBARTLearning"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExcelWorksheetPwd {
            get {
                return ((string)(this["ExcelWorksheetPwd"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BARevitTools_AppUse")]
        public string SqlAppUseTableName {
            get {
                return ((string)(this["SqlAppUseTableName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("babim")]
        public string SqlBABimDbName {
            get {
                return ((string)(this["SqlBABimDbName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://www.youtube.com/watch?v=FKj5kopYC4w&feature=youtu.be")]
        public string UrlRoomsSRRN {
            get {
                return ((string)(this["UrlRoomsSRRN"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://www.youtube.com/watch?v=O4tEqu9wHLk")]
        public string UrlViewsCEPR {
            get {
                return ((string)(this["UrlViewsCEPR"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad\\Revit\\BA Families\\BA 2018\\Annotations\\Symbols\\SY" +
            "MB ID Material Schedule.rfa")]
        public string RevitFamilyMaterialsCMSSymbIdMaterialSchedule {
            get {
                return ((string)(this["RevitFamilyMaterialsCMSSymbIdMaterialSchedule"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2018")]
        public string BARTRevitFamilyCurrentYear {
            get {
                return ((string)(this["BARTRevitFamilyCurrentYear"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BARevitFamilies2018")]
        public string SqlBARevitFamiliesDataTable {
            get {
                return ((string)(this["SqlBARevitFamiliesDataTable"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BADetailsViews")]
        public string SqlBADetailsDataTable {
            get {
                return ((string)(this["SqlBADetailsDataTable"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BARevitPackages")]
        public string SqlBAPackagesDataTable {
            get {
                return ((string)(this["SqlBAPackagesDataTable"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad\\Revit\\BA Details\\BA Details A18.rvt")]
        public string RevitProjectBADetails {
            get {
                return ((string)(this["RevitProjectBADetails"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad\\Revit\\BA Families\\BA 2018")]
        public string RevitBAFamilyLibraryPath {
            get {
                return ((string)(this["RevitBAFamilyLibraryPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad\\Revit\\BA Families\\BA 2018\\Annotations\\Symbols\\SY" +
            "MB Room Name and Number.rfa")]
        public string RevitRoomTagSymbol {
            get {
                return ((string)(this["RevitRoomTagSymbol"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad\\Revit\\BA Families\\BA 2018\\Annotations\\Tags - ID " +
            "and Signage\\TAG ID Accent Mats.rfa")]
        public string RevitIDAccentMatTag {
            get {
                return ((string)(this["RevitIDAccentMatTag"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BAS Version")]
        public string RevitUFVPParameter {
            get {
                return ((string)(this["RevitUFVPParameter"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\boulderassociates.com\\corp\\cad")]
        public string RevitCadDrive {
            get {
                return ((string)(this["RevitCadDrive"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E1 Revit")]
        public string BAProjectCentralFolder {
            get {
                return ((string)(this["BAProjectCentralFolder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BA View Sort 1 Division")]
        public string BAViewSort1 {
            get {
                return ((string)(this["BAViewSort1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BA View Sort 2 Type")]
        public string BAViewSort2 {
            get {
                return ((string)(this["BAViewSort2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Name and Number")]
        public string RevitRoomTagSymbolType {
            get {
                return ((string)(this["RevitRoomTagSymbolType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BA Sheet Discipline")]
        public string BASheetDisciplineParameter {
            get {
                return ((string)(this["BASheetDisciplineParameter"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int RevitOverrideInteriorCropWeight {
            get {
                return ((int)(this["RevitOverrideInteriorCropWeight"]));
            }
        }
    }
}
