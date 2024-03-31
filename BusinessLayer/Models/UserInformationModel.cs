using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO USER INFORMATION
    /// </summary>
    public class UserInformationModel
    {
        #region PROPERTIES
        public int TasksDone { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        #endregion
    }
}
