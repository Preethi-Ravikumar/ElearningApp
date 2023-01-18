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
	public class CourseController : Controller
	{
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("/course"), Authorize(Policy = "RequireAdministratorRole")]
        public Task<string> CreateCourse([FromBody] Course course)
        {
            if ((User.FindFirst(ClaimTypes.Role).Value == "trainer") || (User.FindFirst(ClaimTypes.Role).Value == "user"))
            {
                Console.WriteLine("Role if block");
                course.isVerified = 0;
            }
            
            var response = _courseService.CreateCourse(course);
            return response;
        }

        [HttpGet]
        [Route("/course")]
        public List<Course> ListCourse()
        {
            return _courseService.ListCourse();
        }

        [HttpGet]
        [Route("/course/{CourseId}")]
        public Task<Course> ListCourseById(int courseId)
        {
            return _courseService.ListCourseById(courseId);
        }

        [HttpDelete]
        [Route("/course/{CourseId}"), Authorize(Roles = "admin")]
        public Task<string> DeleteUser(int courseId)
        {
            var reponse = _courseService.DeleteCourse(courseId);
            return reponse;
        }

        [HttpGet]
        [Route("/course/toapprove"), Authorize(Roles = "admin, trainingadmin")]
        public List<Course> CourseToApprove()
        {
            return _courseService.CourseToApprove();
        }

        [HttpPost]
        [Route("/course/toapprove"), Authorize(Roles = "admin, trainingadmin")]
        public Task<string> Publish([FromBody] PublishCourse publishCourse)
        {
            if ((User.FindFirst(ClaimTypes.Role).Value == "trainer") || (User.FindFirst(ClaimTypes.Role).Value == "user"))
            {
                Console.WriteLine("Role if block");
                publishCourse.isVerified = 0;
            }
            return _courseService.Publish(publishCourse);
        }

    }
}


