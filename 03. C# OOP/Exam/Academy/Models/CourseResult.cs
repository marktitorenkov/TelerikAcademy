namespace Academy.Models
{
	using System;
	using System.Text;
	using Contracts;
	using Enums;
	using Utils.Contracts;

	public class CourseResult: ICourseResult
	{
		private float examPoints;
		private float coursePoints;

		public CourseResult(ICourse course, float examPoints, float coursePoints)
		{
			this.Course = course;
			this.ExamPoints = examPoints;
			this.CoursePoints = coursePoints;
		}

		public ICourse Course { get; }

		public float ExamPoints
		{
			get { return this.examPoints; }
            private set
			{
				if (value < 0 || value > 1000)
				{
					throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
				}
				this.examPoints = value;
			}
		}

		public float CoursePoints
		{
			get { return this.coursePoints; }
			private set
			{
				if (value < 0 || value > 125)
				{
					throw new ArgumentException("Course result's course points should be between 0 and 125!");
				}
				this.coursePoints = value;
			}
		}

		public Grade Grade
		{
			get
			{
				if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
				{
					return Grade.Excellent;
				}
				else if (this.ExamPoints >= 30 || this.CoursePoints >= 45)
				{
					return Grade.Passed;
				}
				else
				{
					return Grade.Failed;
				}
			}
		}

		public override string ToString()
		{
			return $"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}";
        }
	}
}