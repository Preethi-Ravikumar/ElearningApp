using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface ICourseService
	{
        Task<string> CreateCourse(Course course);
        Task<List<Course>> ListCourse();
        Task<Course> ListCourseById(int courseId);
        Task<string> UpdateCourse(int courseId, Course course);
        Task<string> DeleteCourse(int id);
        List<Course> CourseToApprove();
        Task<string> Publish(PublishCourse publishCourse);
    }
}

