using System;
using ElearningPortal.Controllers;
using ElearningPortal.Services;
using ElearningPortalTests.MockData;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;

namespace ElearningPortalTests.Systems.Controllers
{
	public class TestCourseController
	{
        [Fact]
        public async Task ListCourse_SuccessStatus()
        {
            var courseService = new Mock<ICourseService>();
            courseService.Setup(x => x.ListCourse()).Returns(CourseMockData.GetCourses());
            var sut = new CourseController(courseService.Object);

            var result = (OkObjectResult)await sut.ListCourse();

            result.StatusCode.Should().Be(200);
        }
    }
}

