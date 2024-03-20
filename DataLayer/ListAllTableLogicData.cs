using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ListAllTableLogicData
    {
        public static DataTable GetTableData(out string error, string table)
        {
            DataTable dataTable = null;
            error = string.Empty;
            string connectionString = Properties.Settings.Default.ConnectionString;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM" + ' ' + table;
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        dataTable = new DataTable();
                        dataTable.Load(dataReader);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return dataTable;
        }
    }
}
