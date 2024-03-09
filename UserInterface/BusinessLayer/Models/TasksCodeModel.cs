using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    //THIS CLASS SHOULD ONLY USE FOR CREATING OBJETCTS TASKSCODE.
    public class TasksCodeModel
    {
        public string TaskCode { get; set; }

        public TimeSpan TaskDuration { get; set; }
    }
}
