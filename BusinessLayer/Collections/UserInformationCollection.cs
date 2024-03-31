using BusinessLayer.Model;
using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Collections
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE USER INFORMATION COLLECTION
    /// </summary>
    public class UserInformationCollection : List<UserInformationModel>
    {
        #region CONSTRUCTORS
        public UserInformationCollection() { }

        public UserInformationCollection(DataTable users)
            : this()
        {
            foreach (DataRow datarow in users.Rows)
            {
                UserInformationModel user = new UserInformationModel();
                user.FullName = datarow.Field<string>("FULL_NAME");
                user.TasksDone = datarow.Field<int>("TASK_COUNT");
                user.DepartmentName = datarow.Field<string>("DEPARTMENT_NAME");

                this.Add(user);
            }
        }
        #endregion

        #region METHODS
        public static UserInformationCollection ListUserInformation()
        {
            string erro = string.Empty;

            DataTable dataTable = UserInfomationData.GetUserInfomationData(out erro);

            UserInformationCollection user = new UserInformationCollection(dataTable);

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentsList"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public static IEnumerable<UserInformationModel> UsersByDepartment(List<string> departmentsList, UserInformationCollection tasks)
        {

            IEnumerable<UserInformationModel> result;

            if (departmentsList.Contains("GERAL"))
            {
                result = ListUserInformation();
                result = result.OrderByDescending(task => task.TasksDone); // Ordem descendente
            }
            else
            {
                // Filtra as tarefas para encontrar aquelas cujo departamento está na lista fornecida
                result = tasks.Where(task => departmentsList.Contains(task.DepartmentName));

                // Ordene o resultado pelo número de tarefas em ordem descendente
                result = result.OrderByDescending(task => task.TasksDone); // Ordem descendente
            }

            return result;
        }

        #endregion
    }
}
