using System;
using ElearningPortal.Data;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortal.Services
{
	public class CreateCourseService : ICreateCourseService
	{
        private readonly ApplicationDbContext context;
        public CreateCourseService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<string> CreateCourse(Course course)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == course.CourseId);
            if(courseFound != null)
            {
                return "Course with this Id exixts already";
            }
            else
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();
                return "Course Added successfully";
            }
        }
    }
}
