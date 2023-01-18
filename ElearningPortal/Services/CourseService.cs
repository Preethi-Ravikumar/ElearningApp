using System;
using ElearningPortal.Data;
using ElearningPortal.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<Course> ListCourseById(int courseId)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == courseId);
            if (courseFound != null)
            {
                return courseFound;
            }
            //else if(courseFound.isVerified == 0)
            //{
            //    return "Course not found";
            //}
            //else
            //{
            //    return "Course not found";
            //}
            
            return null;
        }
        
        public async Task<string> UpdateCourse(int courseId, Course course)
        {
            var courseFound = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == courseId);
            byte updated = 0;
            if (course.CourseName != null)
            {
                courseFound.CourseName = course.CourseName;
                updated = 1;
            }
            if (course.InstructorName != null)
            {
                courseFound.InstructorName = course.InstructorName;
                updated = 1;
            }
            if (course.CourseDuration != null)
            {
                courseFound.CourseDuration = course.CourseDuration;
                updated = 1;
            }
            if (course.Description != null)
            {
                courseFound.Description = course.Description;
                updated = 1;
            }
            if (course.Level != null)
            {
                courseFound.Level = course.Level;
                updated = 1;
            }
            if (course.Price != null)
            {
                courseFound.Price = course.Price;
                updated = 1;
            }
            if (updated == 0)
            {
                return "Nothing to update";
            }
            else
            {
                return "Updated successfully";
            }

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


