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
    public class DepartmentTasksCollection : List<DepartmentTasksModel>
    {
        #region CONSTRUCTORES
        DepartmentTasksCollection() { }
        public DepartmentTasksCollection(DataTable tasks)
        : this()
        {
            foreach (DataRow datarow in tasks.Rows)
            {
                DepartmentTasksModel task = new DepartmentTasksModel();
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
        public static DepartmentTasksCollection ListDepartmentTasksCollection()
        {
            string erro = string.Empty;
            DepartmentTasksCollection colection = new DepartmentTasksCollection
            (DataLayer.Models.DepartmentTasksData.GetDepartmentTasksData(out erro));

            return colection;
        }
        #endregion
    }
}
