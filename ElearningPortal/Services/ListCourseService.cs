using System;
using ElearningPortal.Data;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public class ListCourseService : IListCourseService
	{
        private readonly ApplicationDbContext context;
        public ListCourseService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Course> ListCourse()
        {
             return context.Courses.ToList();
        }
        
	}
}

