using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    //THIS CLASS ONLY SHOULD MAKE TASKS OBJECTS
    public class TasksModel
    {
        public int TaskID { get; set; } //ID TAREFA -- PK TABELA TASKS

        public string TaskCode { get; set; } //CODIGO ASSOCIADO A TAREFA --FK TABELA TaskCode

        public string TaskStatus { get; set; } //STATUS DE CADA TAREFA (NS,IP,CO)

        public string WorkerID { get; set; } //ID DO TRABALHADOR

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan TaskDuration { get; set; } //HORA FINAL - HORA INICIAL

    }
}
