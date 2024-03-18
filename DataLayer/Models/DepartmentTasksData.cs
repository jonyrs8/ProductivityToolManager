using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO EXTRACT DATA FROM VIEW:
    /// NAME: DEPARTMENT_TASKS_VIEW
    /// COLUNS: AREA, TASKS_NUMBER (NUMBER OF TASKS DONE BY DEPARTMENT)
    /// </summary>
    public class DepartmentTasksData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM DEPARTMENT TASKS DATA
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetDepartmentTasksData(out string error)
        {
            DataTable dataTable = null;
            error = string.Empty;
            string connectionString = Properties.Settings.Default.ConnectionString;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                //TRANFORMAR ISTO EM VIEW
                string query = "SELECT AREA, COUNT(TASK_ID) AS TASKS_NUMBER FROM TASKS GROUP BY AREA;";

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
