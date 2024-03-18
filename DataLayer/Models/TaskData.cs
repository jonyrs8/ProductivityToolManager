using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO EXTRACT DATA FROM TABLE - TASKS
    /// </summary>
    public class TaskData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DE DATA FROM TASKS TABLE!
        /// </summary>
        public static DataTable GetAllTasks (out string error)
        {
            DataTable dataTable = null;
            error = string.Empty;
            string connectionString = Properties.Settings.Default.ConnectionString;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                string query = "SELECT * FROM DBO.TASKS;";


                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlConnection.Close();
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
