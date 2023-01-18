using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningPortal.Models
{
	public class Enrollment
	{
        [Key]
        public int EnrollmentId { get; set; }
        public int? UserId { get; set; }
		public int CourseId { get; set; }
        public int? Score { get; set; }

    }
}

