using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public string Department { get; set; }
        public string TaskCode { get; set; }
        public int WorkerID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
