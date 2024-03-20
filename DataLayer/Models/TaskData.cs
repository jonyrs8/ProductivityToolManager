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
            string table = "TASKMANAGER"; //PRECISA SER TASK_MANAGER !!!!!!!!!
            DataTable dataTable = ListAllTableLogicData.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
