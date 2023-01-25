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

            var result = sut.ListCourse();

            result.Should().HaveCount(CourseMockData.GetCourses().Count);
        }

        [Fact]
        public async Task CreateCourse_AddNewCourse()
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

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}

