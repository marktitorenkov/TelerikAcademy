using System;

public class SimpleMathExam: Exam
{
	private const int MinSolvedProblems = 0;
	private const int MaxSolvedProblems = 2;

	private int problemsSolved;

	public SimpleMathExam(int problemsSolved)
	{
		this.ProblemsSolved = problemsSolved;
	}

	public int ProblemsSolved
	{
		get
		{
			return this.problemsSolved;
		}

		private set
		{
			if (value < MinSolvedProblems || value > MaxSolvedProblems)
			{
				throw new ArgumentOutOfRangeException(string.Format("Solved problems must be between {0} and {1}.", MinSolvedProblems, MaxSolvedProblems));
			}

			if (value.GetType() != typeof(int))
			{
				throw new ArgumentException("Solved problems must be a whole number.");
			}

			this.problemsSolved = value;
		}
	}

	public override ExamResult Check()
	{
		if (this.problemsSolved == 0)
		{
			return new ExamResult(2, 2, 6, "Bad result: nothing done.");
		}
		else if (this.problemsSolved == 1)
		{
			return new ExamResult(4, 2, 6, "Average result: 1 task done");
		}
		else
		{
			return new ExamResult(6, 2, 6, "Average result: all tasks done.");
		}
	}
}