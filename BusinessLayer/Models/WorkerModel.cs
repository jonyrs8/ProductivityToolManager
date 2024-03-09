using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    //THIS CLASS ONLY SHOULD MAKE WORKER OBJECTS
    public class WorkerModel
    {
        public int Worker_ID { get; set; } //COMPOSTO POR PRIMEIRO E ULTIMO NOME

        public string FirstName { get; set; }
        public int LastName { get; set; }
        public int Department { get; set; }

    }
}
