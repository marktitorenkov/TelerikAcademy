namespace SchoolClasses
{
	using Interfaces;

	class Discipline: IDiscipline, IComentable
	{
		public Discipline(string name, int lectureCount)
		{
			this.Name = name;
			this.LectureCount = lectureCount;
		}
		public Discipline(string name, int lectureCount, string comment)
			: this(name, lectureCount)
		{
			this.Comment = comment;
		}

		public string Name { get; }
		public int LectureCount { get; }
		public int ExerciseCount { get; }
		public string Comment { get; }
	}
}