using System;
using System.Data;
using System.Security.Claims;
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

        public string payloadData()
        {
            var payloadData = HttpContext.User;

            Console.WriteLine(this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == ClaimTypes.Role)); 
            Console.WriteLine(ClaimTypes.Role); 
            var ID = "";
            if (payloadData?.Claims != null)
            {
                foreach (var claim in payloadData.Claims)
                {
                    ID = claim.Value;
                    break;
                }
            }
            return ID;
        }

        [HttpPost]
        [Route("api/createcourse"), Authorize(Policy = "RequireAdministratorRole")]
        public Task<string> Create([FromBody] Course course)
        {
            Console.WriteLine("payloaddata...."+payloadData()); 
            var response = _createCourseService.CreateCourse(course);
            return response;
        }
    }
}


