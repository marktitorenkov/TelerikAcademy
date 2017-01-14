namespace RangeExceptions
{
	using System;

	public class InvalidRangeException<T>: Exception
	{
		public InvalidRangeException(T start, T end)
		{
			this.Start = start;
			this.End = end;
		}

		public T Start { get; }
		public T End { get; }

		public override string Message
		{
			get
			{
				return $"Value must be between {this.Start} and {this.End}.";
			}
		}
	}
}