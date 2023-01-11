﻿using System;
using System.ComponentModel.DataAnnotations;
namespace ElearningPortal.Models
{
	public class Course
	{
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string InstructorName { get; set; } = null!;
        public string CourseDuration { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StudentsEnrolled { get; set; } 
        public string Level { get; set; } = null!;
        public string Rating { get; set; } = null!;
        public int Price { get; set; }

    }
}

