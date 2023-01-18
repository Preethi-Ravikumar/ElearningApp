using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningPortal.Models
{
	public class Enrollment
	{
        [Key]
        public int EnrollmentId { get; set; }
        [ForeignKey("UserData")]
        public int? UserId { get; set; }
        public virtual UserData UserData { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int? Score { get; set; }

    }
}

