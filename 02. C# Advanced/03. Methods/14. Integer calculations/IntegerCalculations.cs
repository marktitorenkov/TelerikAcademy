using System;

class Program
{
	static int[] IntArrFromStr(string str)
	{
		string[] strarr = str.Split(' ');
		int[] arr = new int[strarr.Length];
		for (int i = 0; i < strarr.Length; i++)
		{
			arr[i] = int.Parse(strarr[i]);
		}
		return arr;
	}

	static int Minimum(params int[] nums)
	{
		int min = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] < min)
				min = nums[i];
		}
		return min;
	}

	static int Maximum(params int[] nums)
	{
		int max = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] > max)
				max = nums[i];
		}
		return max;
	}

	static int Sum(params int[] nums)
	{
		int sum = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			sum += nums[i];
		}
		return sum;
	}

	static double Average(params int[] nums)
	{
		return Sum(nums) / (double)nums.Length;
	}

	static long Product(params int[] nums)
	{
		long product = 1;
		for (int i = 0; i < nums.Length; i++)
		{
			product *= nums[i];
		}
		return product;
	}

	static void Main()
	{
		int[] nums = IntArrFromStr(Console.ReadLine());
		int a = nums[0];
		int b = nums[1];
		int c = nums[2];
		int d = nums[3];
		int e = nums[4];

		Console.WriteLine(Minimum(a, b, c, d, e));
		Console.WriteLine(Maximum(a, b, c, d, e));
		Console.WriteLine("{0:F2}", Average(a, b, c, d, e));
		Console.WriteLine(Sum(a, b, c, d, e));
		Console.WriteLine(Product(a, b, c, d, e));
	}
}