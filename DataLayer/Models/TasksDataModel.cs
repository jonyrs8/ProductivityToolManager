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
    //THIS CLASS SHOULD ONLY HAVE ALL THE METHODS TO MANAGE ALL THE DATA FROM TASKS TABEL


    /// <summary>
    /// METHOD TO EXTRACT ALL DE DATA FROM TASKS TABLE!
    /// </summary>
    public class TasksDataModel
    {
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
//        SELECT
//    AREA,
//    SUM(DATEDIFF(MINUTE, time_in, time_out)) AS REAL_TIME_IN_TASKS,
//    SUM(DATEDIFF(MINUTE, time_in, EXPECTED_TIME_OUT)) AS THEORETICAL_TIME_IN_TASKS
//FROM
//    tasks
//GROUP BY
//    AREA;
    }
}
