using System;
using ElearningPortal.Models;

namespace ElearningPortal.Models
{
	public class CourseEditor
    {
        public string? CourseName { get; set; } = null!;
        public string? InstructorName { get; set; } = null!;
        public string? CourseDuration { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Level { get; set; } = "Beginner";
        public int? Price { get; set; }
		
	}
}

