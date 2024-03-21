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
    public class DepartmentTaskData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM DEPARTMENT TASKS DATA
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetDepartmentTasksData(out string error)
        {
            string table = "DEPARTMENT_TASKS_VIEW";
            DataTable dataTable = ListAllTableLogicData.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
