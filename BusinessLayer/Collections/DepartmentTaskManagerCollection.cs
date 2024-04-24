using BusinessLayer.Interfaces;
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
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE DEPARTMENT TASKS COLLECTION
    /// </summary>
    public class DepartmentTaskManagerCollection : List<IAreaValue>
    {
        #region CONSTRUCTORS
        DepartmentTaskManagerCollection() { }
        public DepartmentTaskManagerCollection(DataTable tasks)
        : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                DepartmentTaskModel task = new DepartmentTaskModel();
                task.Area = datarow.Field<string>("AREA");
                task.TasksNumber = datarow.Field<int>("TASKS_NUMBER");
 

                this.Add(task); // Adiciona a tarefa individualmente à coleção
            }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// CREATE A LIST OF DEPARTMENT TASKS COLLECTION
        /// </summary>
        /// <returns>DEPARTMENTTASKSCOLLECTION</returns>
        public static DepartmentTaskManagerCollection ListDepartmentTasksCollection()
        {
            string erro = string.Empty;
            DepartmentTaskManagerCollection colection = new DepartmentTaskManagerCollection
            (DataLayer.Models.DepartmentTaskData.GetDepartmentTasksData(out erro));

            return colection;
        }

        public static IEnumerable<string> DistinctDepartments(DepartmentTaskManagerCollection tasks)
        {

            IEnumerable<string> result = (from task in tasks
                          select task.Area).Distinct();

            return result;
        }

        public static IEnumerable<string> DistinctUsers (TasksDoneByUserCollection tasks)
        {

            IEnumerable<string> result = (from task in tasks
                          select task.UserID).Distinct();

            return result;
        }
        #endregion
    }
}
