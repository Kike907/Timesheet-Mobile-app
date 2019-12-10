using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApi.Models;
using TimesheetApi.Interfaces;

namespace TimesheetApi.Services
{
    public class TimesheetRepository : ITimesheetRespository
    {
        private readonly TimesheetApiContext _timesheetDb;

        public TimesheetRepository(TimesheetApiContext timesheetApiContext)
        {
            _timesheetDb = timesheetApiContext;
        }

        public IEnumerable<Timesheet> GetAll
        {
            get { return _timesheetDb.Timesheets.ToList(); }
        }

        public bool DoesTimesheetExist(int id)
        {
            return _timesheetDb.Timesheets.Any(t => t.Id == id);
        }

        public Timesheet Find(int id)
        {
            return _timesheetDb.Timesheets.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Timesheet timesheet)
        {
            _timesheetDb.Timesheets.Add(timesheet);
            _timesheetDb.SaveChanges();
        }

        public void Update(Timesheet timesheet)
        {
            var model = Find(timesheet.Id);
            model.Description = timesheet.Description;
            model.Date = timesheet.Date;
            model.Hours = timesheet.Hours;
            _timesheetDb.SaveChanges();
        }

        public  void Delete(int id)
        {
            _timesheetDb.Timesheets.Remove(this.Find(id));
            _timesheetDb.SaveChanges();
        }

    }
}
