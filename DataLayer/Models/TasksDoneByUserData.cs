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
    /// NAME: USER_TASKS_VIEW
    /// COLUNS: USER_ID, TASKS_NUMBER (SUM TASKS)
    /// </summary>
    public class TasksDoneByUserData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM DEPARTMENT EFFICIENCY DATA
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetTasksDoneByUserData(out string error)
        {
            string table = "USER_TASKS_VIEW";
            DataTable dataTable = ListAllTableLogicData.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
