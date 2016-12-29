using System;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		try
		{
			double a = double.Parse(input);
			if (a > 0)
				Console.WriteLine("{0:F3}", Math.Sqrt(a));
			else
				throw new Exception();
		}
		catch (Exception)
		{
			Console.WriteLine("Invalid number");
		}
		finally
		{
			Console.WriteLine("Good bye");
		}
	}
}