﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DepartmenteEfficienceData
    {
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM DEPARTMENT EFFICIENCE DATA
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetDepartmentEfficienceData(out string error)
        {
            DataTable dataTable = null;
            error = string.Empty;
            string connectionString = Properties.Settings.Default.ConnectionString;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                //TRANFORMAR ISTO EM VIEW
                string query = "SELECT AREA, SUM(DATEDIFF(MINUTE, time_in, time_out)) AS REAL_TIME_IN_TASKS, " +
                    "SUM(DATEDIFF(MINUTE, time_in, EXPECTED_TIME_OUT)) AS THEORETICAL_TIME_IN_TASKS FROM tasks GROUP BY AREA;";

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

    }
}
