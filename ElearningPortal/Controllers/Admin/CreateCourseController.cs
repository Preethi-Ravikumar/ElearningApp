using System;
using System.Data;
using ElearningPortal.Controllers;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPortal.Controllers.Admin
{
	public class CreateCourseController : Controller
	{
        private readonly ICreateCourseService _createCourseService;

        public CreateCourseController(ICreateCourseService createCourseService)
        {
            _createCourseService = createCourseService;
        }
        [HttpPost]
        [Route("api/createcourse"), Authorize(Roles = "1")]
        public Task<string> Create([FromBody] Course course)
        {
            var response = _createCourseService.CreateCourse(course);
            return response;
        }
    }
}


