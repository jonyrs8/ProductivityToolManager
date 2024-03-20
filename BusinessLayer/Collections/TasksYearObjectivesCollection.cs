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
    public class TasksYearObjectivesCollection : List<TasksYearObjectivesModel>
    {
        #region CONSTRUCTORS
        public TasksYearObjectivesCollection() { }

        public TasksYearObjectivesCollection(DataTable tasks)
            : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                TasksYearObjectivesModel task = new TasksYearObjectivesModel();
                task.Year = datarow.Field<int>("YEAR");
                task.Tasks_Objective = datarow.Field<int>("TASKS_OBJECTIVES");;

                this.Add(task); // Adiciona a tarefa individualmente à coleção
            }
        }
        #endregion

        #region METHODS
        public static TasksYearObjectivesCollection ListAllTasksYearObjectives()
        {

            string erro = string.Empty;

            DataTable dataTable = TasksYearObjectivesData.GetTasksYearObjectivesData(out erro);

            TasksYearObjectivesCollection task = new TasksYearObjectivesCollection(dataTable);

            return task;
        }

        public static int YearObjective(int year, TasksYearObjectivesCollection tasks)
        {

            var objective = (from task in tasks
                             where task.Year == year
                             select task.Tasks_Objective).FirstOrDefault();

            return objective;
        }
        #endregion
    }
}
