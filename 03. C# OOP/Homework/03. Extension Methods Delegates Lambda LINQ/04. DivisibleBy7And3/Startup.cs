namespace DivisibleBy7And3
{
	using System;
	using System.Linq;

	class Startup
	{
		static void Main()
		{
			int[] nums = new int[] { 15, 21, 25, 13, 42, 18, 63, 105 };

			var numsLambda = nums.Where(num => num % 3 == 0 && num % 7 == 0).ToArray();
			Console.WriteLine("Lambda:");
			Console.WriteLine(string.Join(", ", numsLambda));

			var numsLinq = (from num in nums
						   where num % 3 == 0 && num % 7 == 0
						   select num).ToArray();
			Console.WriteLine("\nLinq:");
			Console.WriteLine(string.Join(", ", numsLinq));
		}
	}
}