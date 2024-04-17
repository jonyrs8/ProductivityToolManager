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
    /// THIS CLASS SHOULD ONLY BE USED TO EXTRACT DATA FROM TABLE - TASK_MANAGER
    /// NAME: TASK_MANAGER
    /// COLUNS: TASK_ID, DEPARTMENT_ID, TIME_IN, TIME_OUT, USER_ID, EXPECTED_TIME_OUT
    /// </summary>
    public class TaskManagerData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DE DATA FROM TASK_MANAGER TABLE!
        /// </summary>
        public static DataTable GetAllTasks (out string error)
        {
            string table = "TASK_MANAGER"; //PRECISA SER TASK_MANAGER !!!!!!!!!
            DataTable dataTable = DatabaseConnection.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
