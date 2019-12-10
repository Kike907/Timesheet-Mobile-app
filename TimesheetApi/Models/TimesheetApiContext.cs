using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimesheetApi.Models
{
    public class TimesheetApiContext : DbContext
    {
        public TimesheetApiContext(DbContextOptions<TimesheetApiContext> options)
          : base(options)
        {
        }

        public DbSet<Timesheet> Timesheets { get; set; }
    }
}


