using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface ICourseService
	{
        public Task<string> CreateCourse(Course course);
        public List<Course> ListCourse();
        public Task<Course> ListCourseById(int courseId);
        public Task<string> DeleteCourse(int id);
        public List<Course> CourseToApprove();
        public Task<string> Publish(PublishCourse publishCourse);
    }
}

