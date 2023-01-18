using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningPortal.Models
{
	public class Course
	{
        //public enum LevelType
        //{
        //    Beginner,
        //    Intermediate,
        //    Advanced
        //}
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string InstructorName { get; set; } = null!;
        public string CourseDuration { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StudentsEnrolled { get; set; }
        public string Level { get; set; } = "Beginner";
        public string Rating { get; set; } = null!;
        public int Price { get; set; }
        public byte isVerified { get; set; }
        //[ForeignKey("UserId")]
        //public int? UserId { get; set; }

        //public Course()
        //{
        //    this.Level = LevelType.Beginner;
        //}

    }
}

