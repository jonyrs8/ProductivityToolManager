﻿using BusinessLayer.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer.Model
{
    public class TaskModel
    {
        #region Properties
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string UserID { get; set; }
        public string Area { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime ExpectedTimeOut { get; set; }
        public double TeoricalTimeInTasks { get; set; }
        #endregion

    }
}
