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
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE YEAR OBJECTIVES COLLECTION
    /// </summary>
    public class TaskYearObjectivesCollection : List<TaskYearObjectivesModel>
    {
        #region CONSTRUCTORS
        public TaskYearObjectivesCollection() { }

        public TaskYearObjectivesCollection(DataTable tasks)
            : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                TaskYearObjectivesModel task = new TaskYearObjectivesModel();
                task.Year = datarow.Field<int>("YEAR");
                task.Tasks_Objective = datarow.Field<int>("TASKS_OBJECTIVES");;

                this.Add(task); // Adiciona a tarefa individualmente à coleção
            }
        }
        #endregion

        #region METHODS
        public static TaskYearObjectivesCollection ListAllTasksYearObjectives()
        {
            string erro = string.Empty;

            DataTable dataTable = TaskYearObjectivesData.GetTasksYearObjectivesData(out erro);

            TaskYearObjectivesCollection task = new TaskYearObjectivesCollection(dataTable);

            return task;
        }

        public static int YearObjective(int year, TaskYearObjectivesCollection tasks)
        {

            int objective = (from task in tasks
                             where task.Year == year
                             select task.Tasks_Objective).FirstOrDefault();

            return objective;
        }
        #endregion
    }
}
