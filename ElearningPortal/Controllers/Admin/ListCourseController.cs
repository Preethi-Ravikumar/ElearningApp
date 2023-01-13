using System;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPortal.Controllers.Admin
{
	public class ListCourseController : Controller
	{
        private readonly IListCourseService _listCourseService;

        public ListCourseController(IListCourseService listCourseService)
        {
            _listCourseService = listCourseService;
        }
        [HttpGet]
        [Route("api/displaycourse"), Authorize(Policy = "RequireAdministratorRole")]
        public List<Course> ListCourse()
		{
            return _listCourseService.ListCourse();
		}
		
    }
}

