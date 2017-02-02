namespace RangeExceptions
{
	using System;

	class Startup
	{
		static void Main()
		{
			try
			{
				throw new InvalidRangeException<int>(2, 5);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			try
			{
				throw new InvalidRangeException<DateTime>(DateTime.Now, DateTime.Now.AddDays(5));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
