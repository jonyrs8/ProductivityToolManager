using BusinessLayer.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class DepartmentEfficienceModel
    {
        public DepartmentEfficienceModel() { }
        public string Area { get; set; }
        public int RealTasksTime { get; set; } //OUT - IN
        public int TheoricalTasksTime { get; set; }
        public double Efficience { get; set; } //HARDCODE
        public int TotalDepartmentEfficience { get; set; } //HARDCODE

    }
}
