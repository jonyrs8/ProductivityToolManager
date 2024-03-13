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
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE DEPARTMENT EFFICIENCE COLLECTION
    /// </summary>
    public class DepartmentEfficienceCollection : List<DepartmentEfficienceModel>
    {
        #region CONSTRUCTORES
        public DepartmentEfficienceCollection() { }

        private DepartmentEfficienceCollection(DataTable Departments)
            : this()
        {
            //THE OBJECTIVE OF THIS LOOP IS TO OBTAIN totalDepartmentEfficience VARIAVEL. 
            double totalDepartmentEfficience = 0;
            foreach (DataRow datarow in Departments.Rows)
            {
                //DEFINE NEEDED FIELDS OF THE OBJECT
                DepartmentEfficienceModel department = new DepartmentEfficienceModel();
                department.RealTasksTime = datarow.Field<int>("REAL_TIME_IN_TASKS");
                department.TheoricalTasksTime = datarow.Field<int>("THEORETICAL_TIME_IN_TASKS");
                //FORMULA
                department.Efficience = 100 * ((float)department.TheoricalTasksTime / department.RealTasksTime);
                department.Efficience = Math.Round(department.Efficience, 2);
                totalDepartmentEfficience = totalDepartmentEfficience + department.Efficience;
            }

            //THE OBJECTIVE OF THIS LOOP IS TO CONSTUCT A DEPARTMENTSEFFICIENCEMODEL OBJECTS WITH DATA
            foreach (DataRow datarow in Departments.Rows)
            {
                DepartmentEfficienceModel department = new DepartmentEfficienceModel();
                department.Area = datarow.Field<string>("AREA");
                department.RealTasksTime = datarow.Field<int>("REAL_TIME_IN_TASKS");
                department.TheoricalTasksTime = datarow.Field<int>("THEORETICAL_TIME_IN_TASKS");

                department.Efficience = ((((float)department.TheoricalTasksTime / department.RealTasksTime) * 100)
                    / totalDepartmentEfficience) * 100;
                department.Efficience = Math.Round(department.Efficience, 2);

                this.Add(department);
            }
        }
        #endregion

        #region METHODS
         /// <summary>
        /// CREATE A LIST OF DEPARTMENT EFFICIENT COLLECTION
        /// </summary>
        /// <returns>DEPARTMENTEFFICIENCECOLLECTION</returns>
        public static DepartmentEfficienceCollection ListDepartmentCollection()
        {
            string erro = string.Empty;
            DepartmentEfficienceCollection colection = new DepartmentEfficienceCollection
            (DepartmenteEfficienceData.GetDepartmentData(out erro));

            return colection;
        }
        #endregion
    }
}
