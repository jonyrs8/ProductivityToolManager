using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO TASKS OBJECTIVES
    /// </summary>
    public class TaskYearObjectivesModel
    {
        #region PROPERTIES
        public int Year { get; set; }
        public int Tasks_Objective { get; set; }
        #endregion
    }
}
