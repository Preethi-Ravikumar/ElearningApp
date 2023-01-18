using System;
using ElearningPortal.Data;
using ElearningPortal.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortal.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext context;
        public CourseService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<string> CreateCourse(Course course)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == course.CourseId);
            if (courseFound != null)
            {
                Console.WriteLine("ClaimTypes.Role...." + ClaimTypes.Role);
                return "Course with this Id exixts already";
            }
            else
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();
                return "Course Added successfully";
            }
        }

        public List<Course> ListCourse()
        {
            return context.Courses.Where(x => x.isVerified == 1).ToList();
        }

        public Task<Course> ListCourseById(int courseId)
        {
            var courseFound = context.Courses.FirstOrDefaultAsync(x => x.CourseId == courseId);
            if (courseFound != null)
            {
                return courseFound;
            }
            return null;
        }

        public async Task<string> DeleteCourse(int id)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if (courseFound != null)
            {
                courseFound.isVerified = 0;
                await context.SaveChangesAsync();
                return "Course deleted";
            }
            return "Course not found";
        }

        public List<Course> CourseToApprove()
        {
            List<Course> courseFound = context.Courses.Where(x => x.isVerified == 0).ToList();
            return courseFound;
        }

        public async Task<string> Publish(PublishCourse publishCourse)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == publishCourse.CourseId);
            if (courseFound != null)
            {
                courseFound.isVerified = publishCourse.isVerified;
                await context.SaveChangesAsync();
                return "Course has been published";
            }
            return "Course not found";

        }
    }
}


