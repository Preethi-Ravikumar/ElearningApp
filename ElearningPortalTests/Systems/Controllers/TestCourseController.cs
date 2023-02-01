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

        //[Fact]
        //public async Task CreateCourse_AtleastOnce()
        //{
        //    /// Arrange
        //    var courseService = new Mock<ICourseService>();
        //    var newCourse = CourseMockData.NewCourse();
        //    var sut = new CourseController(courseService.Object);

        //    /// Act
        //    var result = await sut.CreateCourse(newCourse);

        //    /// Assert
        //    courseService.Verify(_ => _.CreateCourse(newCourse), Times.Exactly(1));
        //}

        [Fact]
        public async Task ListCourse_SuccessStatus()
        {
            /// Arrange
            var courseService = new Mock<ICourseService>();
            courseService.Setup(x => x.ListCourse()).ReturnsAsync(CourseMockData.GetCourses());
            var sut = new CourseController(courseService.Object);

            /// Act
            var result = (OkObjectResult)await sut.ListCourse();

            /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ListCourse_204NoContentStatus()
        {
            /// Arrange
            var courseService = new Mock<ICourseService>();
            courseService.Setup(x => x.ListCourse()).ReturnsAsync(CourseMockData.GetEmptyCourses());
            var sut = new CourseController(courseService.Object);

            /// Act
            var result = (NoContentResult)await sut.ListCourse();


            /// Assert
            result.StatusCode.Should().Be(204);
            courseService.Verify(_ => _.ListCourse(), Times.Exactly(1));
        }
    }
}

