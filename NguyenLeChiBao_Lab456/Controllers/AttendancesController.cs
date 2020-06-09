using Microsoft.AspNet.Identity;
using NguyenLeChiBao_Lab456.DTOs;
using NguyenLeChiBao_Lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace NguyenLeChiBao_Lab456.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Attend (AttendenceDto attendanceDto)
        {
            var usreId = User.Identity.GetUserId();
            if(_dbContext.Attendances.Any(a => a.AttendeeId == usreId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The Attendence alrealy exists");
            }
            var attendence = new Attendance()
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendances.Add(attendence);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
