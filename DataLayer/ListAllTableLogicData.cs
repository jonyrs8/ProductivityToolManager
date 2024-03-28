using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO EXTRACT DATA FROM DATABASE
    /// </summary>
    public class ListAllTableLogicData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA TABLE FROM DATABASE
        /// </summary>
        /// <param name="error"></param>
        /// <param name="table"></param>
        /// <returns></returns>
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
        #endregion
    }
}
