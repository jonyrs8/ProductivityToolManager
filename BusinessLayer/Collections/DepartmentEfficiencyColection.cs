using BusinessLayer.Interfaces;
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
    /// THIS CLASS SHOULD ONLY BE USED TO MANAGE DEPARTMENT EFFICIENCY COLLECTION
    /// </summary>
    public class DepartmentEfficiencyCollection : List<DepartmentEfficiencyModel>
    {
        #region CONSTRUCTORS
        public DepartmentEfficiencyCollection() { }

        private DepartmentEfficiencyCollection(DataTable Departments)
            : this()
        {
            //THE OBJECTIVE OF THIS LOOP IS TO CONSTUCT A DEPARTMENTSEFFICIENCYMODEL OBJECTS WITH DATA
            foreach (DataRow datarow in Departments.Rows)
            {
                DepartmentEfficiencyModel department = new DepartmentEfficiencyModel();
                department.Area = datarow.Field<string>("AREA");
                department.RealTasksTime = datarow.Field<int>("REAL_TIME_IN_TASKS");
                department.TheoricalTasksTime = datarow.Field<int>("THEORETICAL_TIME_IN_TASKS");
                department.Efficiency = (((float)department.TheoricalTasksTime / department.RealTasksTime) * 100);
                department.Efficiency = Math.Round(department.Efficiency, 2);

                this.Add(department);
            }
        }
        #endregion

        #region METHODS
         /// <summary>
        /// CREATE A LIST OF DEPARTMENT EFFICIENCY COLLECTION
        /// </summary>
        /// <returns>DEPARTMENTEFFICIENCYCOLLECTION</returns>
        public static DepartmentEfficiencyCollection ListDepartmentEfficiencyCollection()
        {
            string erro = string.Empty;
            DepartmentEfficiencyCollection colection = new DepartmentEfficiencyCollection
            (DepartmentEfficiencyData.GetDepartmentEfficiencyData(out erro));

            return colection;
        }

        public static double GetDepartmentEfficiency(string department, DepartmentEfficiencyCollection listOfDepartmentsEfficiency)
        {

            var result = (from departments in listOfDepartmentsEfficiency
                         where departments.Area == department
                         select departments.Efficiency).FirstOrDefault();

            return result;
        }
        #endregion
    }

}
