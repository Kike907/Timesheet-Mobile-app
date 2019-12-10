using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApi.Models;

namespace TimesheetApi.Interfaces
{
    public interface ITimesheetRespository
    {
       bool DoesTimesheetExist(int id);
        IEnumerable<Timesheet> GetAll { get; }
        Timesheet Find(int id);
        void Insert(Timesheet timesheet);
        void Update(Timesheet timesheet);
        void Delete(int id);
    }
}
