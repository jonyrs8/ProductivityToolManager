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
    /// NAME: DEPARTMENT_EFFICIENCY_VIEW
    /// COLUNS: AREA, REAL_TIME_IN_TASKS (SUM OF TOTAL TIME WASTE IN TASKS), THEORETICAL_TIME_IN_TASKS (SUM OF TOTAL THEORICAL TIME TASKS NEEDED)
    /// </summary>
    public class DepartmentEfficiencyData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM DEPARTMENT EFFICIENCY DATA
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetDepartmentEfficiencyData(out string error)
        {
            string table = "DEPARTMENT_EFFICIENCY_VIEW";
            DataTable dataTable = ListAllTableLogicData.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
