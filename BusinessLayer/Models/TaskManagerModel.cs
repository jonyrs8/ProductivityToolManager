using BusinessLayer.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer.Model
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO TASKS MANAGER OBJECTS
    /// </summary>
    public class TaskManagerModel
    {
        #region PROPERTIES
        public int TaskID { get; set; }
        public int DepartmentID { get; set; }
        public string UserID { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime ExpectedTimeOut { get; set; }
        public double TeoricalTimeInTasks { get; set; }
        #endregion
    }
}
