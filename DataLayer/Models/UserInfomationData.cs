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
    /// NAME: USER_INFORMATION_VIEW
    /// COLUNS: USER_ID, TASKS_NUMBER (SUM TASKS), DEPARTMENT_NAME
    /// </summary>
    public class UserInfomationData
    {
        #region METHODS
        /// <summary>
        /// METHOD TO EXTRACT ALL DATA FROM  USER INFORMATION VIEW
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DataTable GetUserInfomationData(out string error)
        {
            string table = "USER_INFORMATION_VIEW";
            DataTable dataTable = DatabaseConnection.GetTableData(out error, table);
            return dataTable;
        }
        #endregion
    }
}
