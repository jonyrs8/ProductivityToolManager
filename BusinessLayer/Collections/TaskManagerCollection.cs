using BusinessLayer.Model;
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
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE TASKS COLLECTION
    /// </summary>
    public class TaskManagerCollection : List<TaskManagerModel>
    {
        #region CONSTRUCTORS
        public TaskManagerCollection() { }

        public TaskManagerCollection(DataTable tasks)
            : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                TaskManagerModel task = new TaskManagerModel();
                task.TaskID = datarow.Field<int>("TASK_ID");
                task.DepartmentID = datarow.Field<int>("DEPARTMENT_ID");
                task.TimeIn = datarow.Field<DateTime>("TIME_IN");
                task.TimeOut = datarow.Field<DateTime>("TIME_OUT");
                task.UserID = datarow.Field<string>("USER_ID");
                task.ExpectedTimeOut = datarow.Field<DateTime>("EXPECTED_TIME_OUT");

                this.Add(task); // Adiciona a tarefa individualmente à coleção
            }
        }
        #endregion

        #region METHODS
        public static TaskManagerCollection ListAllTasks()
        {

            string erro = string.Empty;

            DataTable dataTable = TaskManagerData.GetAllTasks(out erro);

            TaskManagerCollection task = new TaskManagerCollection(dataTable);

            return task;

        }

        public static int TasksDoneInTheYear (int year, TaskManagerCollection tasks)
        {
            int result = (from task in tasks
                             where task.TimeOut.Year == year
                             select task.TaskID).Count();

            return result;
        }
        #endregion
    }
}
