using System;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		Console.WriteLine(SumOFIntegers(input));
	}
	static ulong SumOFIntegers(string str)
	{
		ulong sum = 0;
		string[] nums = str.Split(' ');
		for (int i = 0; i < nums.Length; i++)
		{
			sum += ulong.Parse(nums[i]);
		}
		return sum;
	}
}