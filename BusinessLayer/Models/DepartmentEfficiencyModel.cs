using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    /// <summary>
    /// THIS CLASS SHOULD ONLY BE USED TO SET PROPERTIES TO DEPARTMENT EFFICIENCY OBJECTS
    /// </summary>
    public class DepartmentEfficiencyModel : IAreaValue
    {
        #region PROPERTIES
        public DepartmentEfficiencyModel() { }
        public string Area { get; set; }
        public int RealTasksTime { get; set; } //OUT - IN
        public int TheoricalTasksTime { get; set; }
        public double Efficiency { get; set; } //HARDCODE
        public int TotalDepartmentEfficiency { get; set; } //HARDCODE
        public double Value { get { return this.Efficiency; } }
        #endregion

    }
}
