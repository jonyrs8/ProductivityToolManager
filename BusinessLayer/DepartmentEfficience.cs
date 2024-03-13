using BusinessLayer.Collections;
using BusinessLayer.Model;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DepartmentEfficience
    {
        public static IEnumerable<TaskModel> GetTasksRealTime(TaskCollection TasksList) 
        {

                  var result = TasksList.GroupBy(t => t.Area)
                  .Select(g => new TaskModel {
                      Area = g.Key,
                      TeoricalTimeInTasks = g.Sum(t => (t.ExpectedTimeOut - t.TimeIn).TotalMinutes)
                  });

            return result;
        }
    }
}
