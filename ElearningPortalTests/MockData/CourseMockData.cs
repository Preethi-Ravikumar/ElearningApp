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
					Price=499
				},
                new Course
                {
                    CourseId=2,
                    CourseName="C",
                    InstructorName="Henry",
                    CourseDuration="3hr 30mins",
                    Description="This course introduces computer programming using the C programming language.",
                    Price=499
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
    }
}

