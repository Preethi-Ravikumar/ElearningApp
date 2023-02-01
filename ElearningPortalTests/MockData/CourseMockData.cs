using System;
using ElearningPortal.Models;
namespace ElearningPortalTests.MockData
{
	public class CourseMockData
	{
		public static List<Course> GetCourses()
		{
			return new List<Course>
			{
				new Course
				{
					CourseId=1,
					CourseName="Java",
					InstructorName="Sam",
					CourseDuration="3hr 30mins",
					Description="This course introduces computer programming using the JAVA programming language with object-oriented programming principles.",
					Price=499,
                    isVerified=1
				},
                new Course
                {
                    CourseId=2,
                    CourseName="C",
                    InstructorName="Henry",
                    CourseDuration="3hr 30mins",
                    Description="This course introduces computer programming using the C programming language.",
                    Price=499,
                    isVerified=1
                }
            };
		}

		public static List<Course> GetEmptyCourses()
		{
			return new List<Course>();
        }

        public static Course NewCourse()
        {
            return new Course
            {
                CourseId = 0,
                CourseName = "C#",
                InstructorName = "Sam",
                CourseDuration = "3hr 30mins",
                Description="This course introduces computer programming using the C# programming language.",
                Price=499
            };
        }

        public static Course EmptyCourseName()
        {
            return new Course
            {
                CourseName = "",
                InstructorName = "Sam",
                CourseDuration = "3hr 30mins",
                Description = "This course introduces computer programming using the C# programming language.",
                Price = 499
            };
        }

        public static Course EmptyInstructorName()
        {
            return new Course
            {
                CourseName = "Java",
                InstructorName = "",
                CourseDuration = "3hr 30mins",
                Description = "This course introduces computer programming using the C# programming language.",
                Price = 499
            };
        }

        public static Course EmptyCourseDuration()
        {
            return new Course
            {
                CourseName = "Java",
                InstructorName = "Sam",
                CourseDuration = "",
                Description = "This course introduces computer programming using the C# programming language.",
                Price = 499
            };
        }

        public static Course EmptyDescription()
        {
            return new Course
            {
                CourseName = "Java",
                InstructorName = "Sam",
                CourseDuration = "3hrs 30 mins",
                Description = "",
                Price = 499
            };
        }

        public static Course InsufficientDescription()
        {
            return new Course
            {
                CourseName = "C",
                InstructorName = "Sam",
                CourseDuration = "3hrs 30mins",
                Description = "C course",
                Price = 499
            };
        }
    }
}

