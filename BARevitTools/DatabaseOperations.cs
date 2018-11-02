using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Autodesk.Revit.DB;
using RVTDocument = Autodesk.Revit.DB.Document;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace BARevitTools
{    
    public static class DatabaseOperations
    {
        private static string integratedSecurity = "False";
        private static string userId = BARevitTools.Properties.Settings.Default.SqlServerUser;
        private static string password = BARevitTools.Properties.Settings.Default.SqlServerPwd;
        private static string connectTimeout = "3";
        private static string encrypt = "False";
        private static string trustServerCertificate = "True";
        private static string applicationIntent = "ReadWrite";
        private static string multiSubnetFailover = "False";
        private static string dbServer = BARevitTools.Properties.Settings.Default.SqlServerName;
        private static string database = BARevitTools.Properties.Settings.Default.SqlBARevitToolsDbName;
        public static string adminDataSqlConnectionString = "Server=" + dbServer +
                                ";Database=" + database +
                                ";Integrated Security=" + integratedSecurity +
                                ";User Id=" + userId +
                                ";Password=" + password +
                                ";Connect Timeout=" + connectTimeout +
                                ";Encrypt=" + encrypt +
                                ";TrustServerCertificate=" + trustServerCertificate +
                                ";ApplicationIntent=" + applicationIntent +
                                ";MultiSubnetFailover=" + multiSubnetFailover;

        public static void MakeAppUseDataTable(DataTable dt)
        {         
            DataColumn AppGuidColumn = dt.Columns.Add("AppGUID", typeof(Guid));
            DataColumn AppButtonNameColumn = dt.Columns.Add("AppButton", typeof(String));
            DataColumn AppUserNameColumn = dt.Columns.Add("AppUser", typeof(String));
            DataColumn AppDateColumn = dt.Columns.Add("AppDate", typeof(DateTime));
        }
        public static void CollectUserInputData(Guid appGUID, string buttonName, string userName, DateTime dateTime)
        {
            DataTable dt = BARevitTools.Application.thisApp.appUseDataTable;
            DataRow row = dt.NewRow();
            row["AppGUID"] = appGUID;
            row["AppButton"] = buttonName;
            row["AppUser"] = userName;
            row["AppDate"] = dateTime;
            dt.Rows.Add(row);
        }
        public static SqlConnection SqlOpenConnection(string connectionString)
        {
            List<string> dataTableNames = new List<string>();
            SqlConnection sqlConnection;
            
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch
            {
                ;
            }
            return sqlConnection;
        }       
        public static void SqlCloseConnection(SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("Could not close SQL connection");
            }
        }
        public static void SqlLogWriter(string writtenTableName)
        {
            try
            {
                SqlConnection sqlConnection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
                DataTable dt = sqlConnection.GetSchema("Tables");

                List<string> existingTables = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    string tableName = (string)row[2];
                    existingTables.Add(tableName);
                }

                if (existingTables.Contains("BARevitTools_SQLWriterLog"))
                {
                    string commandString = "INSERT INTO [BARevitTools_SQLWriterLog] (UserName, TableName, WriteDate) VALUES (@userName, @tableName, @dateTime)";
                    using (SqlCommand sqlInsert = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlInsert.Parameters.AddWithValue("@userName", Environment.UserName);
                        sqlInsert.Parameters.AddWithValue("@tableName", writtenTableName);
                        sqlInsert.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        sqlInsert.ExecuteNonQuery();
                    }
                }
                else
                {
                    SqlCommand sqlCreateTable = new SqlCommand("CREATE TABLE BARevitTools_SQLWriterLog (UserName varchar(255), TableName varchar(255), WriteDate datetime)", sqlConnection);
                    sqlCreateTable.ExecuteNonQuery();
                    string commandString = "INSERT INTO [BARevitTools_SQLWriterLog] (UserName, TableName, WriteDate) VALUES (@userName, @tableName, @dateTime)";
                    using (SqlCommand sqlInsert = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlInsert.Parameters.AddWithValue("@userName", Environment.UserName);
                        sqlInsert.Parameters.AddWithValue("@tableName", writtenTableName);
                        sqlInsert.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        sqlInsert.ExecuteNonQuery();
                    }                       
                }
                DatabaseOperations.SqlCloseConnection(sqlConnection);
            }
            catch {; }
        }
        public static void SqlWriteDataTable(string tableName, SqlConnection sqlConnection, DataTable dataTable, bool dropTable)
        {
            foreach(var column in dataTable.Columns.Cast<DataColumn>().ToArray())
            {
                if (dataTable.AsEnumerable().All(dr => dr.IsNull(column) || dr[column].ToString() == "NA"))
                    dataTable.Columns.Remove(column);
            }
            if (dataTable.Columns.Count > 1000)
            {
                TaskDialog.Show("alert", "Column Count for " + tableName + " is greater than 1000");
                return;
            }

            string sqldrop = "IF OBJECT_ID('[dbo].[" + tableName + "]', 'U') IS NOT NULL DROP TABLE [" + tableName + "]";


            string sqlsc = "CREATE TABLE [" + tableName + "] (";
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                sqlsc += "\n [" + dataTable.Columns[i].ColumnName + "] ";
                string columnType = dataTable.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint ";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.Guid":
                        sqlsc += " uniqueidentifier ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar(255) ");
                        break;
                }
                if (dataTable.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + dataTable.Columns[i].AutoIncrementSeed.ToString() + "," + dataTable.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!dataTable.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            string sqlstring = sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";


            using (SqlConnection sqlconn = sqlConnection)
            {
                if(dropTable)
                {
                    SqlCommand sqlDrop = new SqlCommand(sqldrop, sqlconn);
                    sqlDrop.ExecuteNonQuery();
                }

                DataTable dt = sqlConnection.GetSchema("Tables");

                List<string> existingTables = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    string existingTableName = (string)row[2];
                    existingTables.Add(existingTableName);
                }

                SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;
                if (!existingTables.Contains(tableName))
                {

                    SqlCommand sqlCreate = new SqlCommand(sqlstring, sqlconn);
                    sqlCreate.ExecuteNonQuery();
                    try
                    {
                        using (SqlBulkCopy s = new SqlBulkCopy(sqlconn, options, null))
                        {
                            s.DestinationTableName = "[" + tableName + "]";
                            foreach (var column in dataTable.Columns)
                            {
                                s.ColumnMappings.Add(column.ToString(), column.ToString());
                            }                            
                            s.WriteToServer(dataTable);
                        }
                    }
                    catch { MessageBox.Show("Table already exists"); }
                }
                else
                {
                    try
                    {
                        using (SqlBulkCopy s = new SqlBulkCopy(sqlconn, options, null))
                        {
                            s.DestinationTableName = "[" + tableName + "]";
                            s.WriteToServer(dataTable);
                        }
                    }
                    catch { MessageBox.Show("Could not append"); }
                }
                
               
                SqlCloseConnection(sqlconn);
            }
            SqlLogWriter(tableName);
        }
        public static void SqlRecordAppUse()
        {
            try
            {
                SqlConnection sqlConnection = DatabaseOperations.SqlOpenConnection(DatabaseOperations.adminDataSqlConnectionString);
                DataTable dt = sqlConnection.GetSchema("Tables");

                List<string> existingTables = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    string tableName = (string)row[2];
                    existingTables.Add(tableName);
                }

                if (existingTables.Contains(Properties.Settings.Default.SqlAppUseTableName))
                {
                    SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;

                    using (SqlBulkCopy s = new SqlBulkCopy(sqlConnection, options, null))
                    {
                        s.DestinationTableName = "["+ Properties.Settings.Default.SqlAppUseTableName+"]";
                        foreach (DataColumn appColumn in BARevitTools.Application.thisApp.appUseDataTable.Columns)
                        {
                            s.ColumnMappings.Add(appColumn.ToString(), appColumn.ToString());
                        }
                        s.WriteToServer(BARevitTools.Application.thisApp.appUseDataTable);
                    }
                }
                else
                {
                    SqlCommand sqlCreateTable = new SqlCommand("CREATE TABLE " + Properties.Settings.Default.SqlAppUseTableName + " (AppGUID uniqueidentifier, AppButton varchar(255), AppUser varchar(255), AppDate datetime)", sqlConnection);
                    sqlCreateTable.ExecuteNonQuery();

                    SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;

                    using (SqlBulkCopy s = new SqlBulkCopy(sqlConnection, options, null))
                    {
                        s.DestinationTableName = "[" + Properties.Settings.Default.SqlAppUseTableName + "]";
                        foreach (DataColumn appColumn in BARevitTools.Application.thisApp.appUseDataTable.Columns)
                        {
                            s.ColumnMappings.Add(appColumn.ToString(), appColumn.ToString());
                        }
                        s.WriteToServer(BARevitTools.Application.thisApp.appUseDataTable);
                    }
                }
                DatabaseOperations.SqlCloseConnection(sqlConnection);
            }
            catch { ; }            
        }
    }          
}