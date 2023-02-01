using System;
using ElearningPortal.Data;
using ElearningPortal.Services;
using ElearningPortalTests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortalTests.Systems.Services
{
	public class TestCourseService : IDisposable
	{
		private readonly ApplicationDbContext _context;

        public TestCourseService()
		{
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task ListCourse_ReturnCourseCollection()
        {
            _context.Courses.AddRange(MockData.CourseMockData.GetCourses());
            _context.SaveChanges();
            var sut = new CourseService(_context);
            var result = await sut.ListCourse();
            result.Should().HaveCount(CourseMockData.GetCourses().Count);
        }

        [Fact]
        public async Task CreateCourse_SuccessStatus()
        {
            /// Arrange
            var newCourse = CourseMockData.NewCourse();
            _context.Courses.AddRange(MockData.CourseMockData.GetCourses());
            _context.SaveChanges();

            var sut = new CourseService(_context);

            /// Act
            await sut.CreateCourse(newCourse);

            ///Assert
            int expectedRecordCount = (CourseMockData.GetCourses().Count() + 1);
            _context.Courses.Count().Should().Be(expectedRecordCount);
        }

        [Fact]
        public async Task CreateCourse_EmptyCourseName()
        {
            var newCourse = CourseMockData.EmptyCourseName();
            var sut = new CourseService(_context);
            var result=await sut.CreateCourse(newCourse);
            Assert.Same("Course name cannot be empty", result);
        }

        [Fact]
        public async Task CreateCourse_EmptyInstructorName()
        {
            var newCourse = CourseMockData.EmptyInstructorName();
            var sut = new CourseService(_context);
            var result = await sut.CreateCourse(newCourse);
            Assert.Same("Instructor name cannot be empty", result);
        }

        [Fact]
        public async Task CreateCourse_EmptyCourseDuration()
        {
            var newCourse = CourseMockData.EmptyCourseDuration();
            var sut = new CourseService(_context);
            var result = await sut.CreateCourse(newCourse);
            Assert.Same("Course duration cannot be empty", result);
        }

        [Fact]
        public async Task CreateCourse_EmptyDescription()
        {
            var newCourse = CourseMockData.EmptyDescription();
            var sut = new CourseService(_context);
            var result = await sut.CreateCourse(newCourse);
            Assert.Same("Course description cannot be empty", result);
        }

        [Fact]
        public async Task CreateCourse_InsufficientDescription()
        {
            var newCourse = CourseMockData.InsufficientDescription();
            var sut = new CourseService(_context);
            var result = await sut.CreateCourse(newCourse);
            Assert.Same("Course description should have atleast 10 characters", result);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}

