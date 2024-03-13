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
    public class TaskCollection : List<TaskModel>
    {
        public TaskCollection() { }

        public TaskCollection(DataTable tasks)
            : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                TaskModel task = new TaskModel();
                task.TaskID = datarow.Field<int>("TASK_ID");
                task.TaskName = datarow.Field<string>("TASK_NAME");
                task.TimeIn = datarow.Field<DateTime>("TIME_IN");
                task.TimeOut = datarow.Field<DateTime>("TIME_OUT");
                task.ExpectedTimeOut = datarow.Field<DateTime>("EXPECTED_TIME_OUT");
                task.Area = datarow.Field<string>("AREA");

                this.Add(task); // Adiciona a tarefa individualmente à coleção
            }
        }

        public static TaskCollection ListAllTasks()
        {

            string erro = string.Empty;

            DataTable dataTable = TaskData.GetAllTasks(out erro);

            TaskCollection task = new TaskCollection(dataTable);

            return task;

        }
    }
}
