using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class Timesheet
    {

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 24)]
        public int Hours { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
