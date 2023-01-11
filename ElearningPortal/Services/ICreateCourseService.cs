using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface ICreateCourseService
	{
        public Task<string> CreateCourse(Course course);
    }
}

