using System;
using System.Data;
using System.Security.Claims;
using ElearningPortal.Controllers;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPortal.Controllers;

	public class CourseController : Controller
	{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="course"></param>
    /// <returns></returns>
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
    public async Task<IActionResult> ListCourse()
    {
        var response = await _courseService.ListCourse();
        if (response.Count == 0)
        {
            return NoContent();
        }
        return Ok(response);
    }

    [HttpGet]
    [Route("/course/{CourseId}")]
    public Task<Course> ListCourseById(int courseId)
    {
        return _courseService.ListCourseById(courseId);
    }

    [HttpPut]
    [Route("/course/{CourseId}"), Authorize(Roles = "admin,trainingadmin")]
    public Task<string> UpdateCourse(int courseId, [FromBody] Course course)
    {
        var response = _courseService.UpdateCourse(courseId, course);
        return response;
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


