using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetApi.Interfaces;
using TimesheetApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimesheetApi.Controllers
{

    [Route("api/timesheet")]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetRespository _timesheetRepository;
        
        public TimesheetController(ITimesheetRespository timesheetRespository)
        {
            _timesheetRepository = timesheetRespository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_timesheetRepository.GetAll);
        }


        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] Timesheet timesheet)
        {
            try
            {
                if (timesheet == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TimesheetDescriptionAndHoursRequired.ToString());
                }

                bool timesheetExists = _timesheetRepository.DoesTimesheetExist(timesheet.Id);
                //if (timesheetExists)
                //{
                //    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TimesheetIdInUse.ToString());
                //}
                _timesheetRepository.Insert(timesheet);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateTimesheet.ToString());
            }
            return Ok(timesheet);
        }

        public enum ErrorCode
        {
            TimesheetDescriptionAndHoursRequired,
            TimesheetIdInUse,
            CouldNotCreateTimesheet,
            CouldNotUpdateTimesheet,
            CouldNotDeleteTimesheet,
            RecordNotFound
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Edit([FromBody]Timesheet timesheet)
        {
            try
            {
                if (timesheet == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TimesheetDescriptionAndHoursRequired.ToString());
                }
                var existingTimesheet = _timesheetRepository.Find(timesheet.Id);
                if (existingTimesheet == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _timesheetRepository.Update(timesheet);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateTimesheet.ToString());
            }
            return Ok(timesheet);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _timesheetRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _timesheetRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteTimesheet.ToString());
            }
            return NoContent();
        }
    }
}
