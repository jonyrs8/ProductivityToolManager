using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO TASKS DONE BY USER
    /// </summary>
    public class TasksDoneByUserModel
    {
        #region PROPERTIES
        public string UserID { get; set; }
        public int TasksNumber { get; set; }
        #endregion
    }
}
