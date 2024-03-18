using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO DEPARTMENT TASKS OBJECTS
    /// </summary>
    public class DepartmentTasksModel
    {
        #region PROPERTIES
        public string Area { get; set; }
        public int TasksNumber { get; set; }
        #endregion
    }
}
