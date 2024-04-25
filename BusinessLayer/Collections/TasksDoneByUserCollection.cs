using BusinessLayer.Model;
using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Collections
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE TASKS DONE BY USER COLLECTION
    /// </summary>
    public class TasksDoneByUserCollection : List<TasksDoneByUserModel>
    {
        #region CONSTRUCTORS
        public TasksDoneByUserCollection() { }

        public TasksDoneByUserCollection(DataTable users)
            : this()
        {
            foreach (DataRow datarow in users.Rows)
            {
                TasksDoneByUserModel user = new TasksDoneByUserModel();
                user.UserID = datarow.Field<string>("USER_ID");
                user.TasksNumber = datarow.Field<int>("TASKS_NUMBER");;

                this.Add(user); // Adiciona a tarefa individualmente à coleção
            }
        }
        #endregion

        #region METHODS
        public static TasksDoneByUserCollection ListNumberOfTasksDoneByUser()
        {
            string erro = string.Empty;

            DataTable dataTable = TasksDoneByUserData.GetTasksDoneByUserData(out erro);

            TasksDoneByUserCollection user = new TasksDoneByUserCollection(dataTable);

            return user;
        }

        public static IOrderedEnumerable<TasksDoneByUserModel> ListNumberOfTasksDoneByUserOrdered()
        {
            TasksDoneByUserCollection tasks = ListNumberOfTasksDoneByUser();

            // Ordena as tarefas por número de tarefas concluídas por usuário
            IOrderedEnumerable<TasksDoneByUserModel> result = tasks.OrderByDescending(task => task.TasksNumber);

            return result;
        }

        public static int GetTasksNumber(string userID) 
        {
            TasksDoneByUserCollection tasks = ListNumberOfTasksDoneByUser();

            int result = (from task in tasks
                             where task.UserID == userID
                             select task.TasksNumber).FirstOrDefault();

            return result;
        }
        #endregion
    }
}
