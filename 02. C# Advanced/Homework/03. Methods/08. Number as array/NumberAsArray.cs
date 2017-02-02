using System;

class NumberAsArray
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

	static int[] SumOfArrays(int[] arr1, int[] arr2)
	{
		int longer = Math.Max(arr1.Length, arr2.Length);

		int[] result = new int[longer + 1];
		for (int i = 0; i < longer; i++)
		{
			int a = 0, b = 0;
			if (i < arr1.Length)
				a = arr1[i];

			if (i < arr2.Length)
				b = arr2[i];

			result[i] += a + b;
			if (result[i] > 9)
			{
				result[i] %= 10;
				result[i + 1] += 1;
			}
		}
		return result;
	}

	static void PrintWithoutLeadingZero(int[] arr)
	{
		for (int i = 0; i < arr.Length - 1; i++)
		{
			Console.Write("{0} ", arr[i]);
		}
		if (arr[arr.Length - 1] != 0)
		{
			Console.WriteLine(1);
		}
	}

	static void Main()
	{
		string[] line1 = Console.ReadLine().Split(' ');
		int arr1Length = int.Parse(line1[0]);
		int arr2Length = int.Parse(line1[1]);
		int[] arr1 = IntArrFromStr(Console.ReadLine());
		int[] arr2 = IntArrFromStr(Console.ReadLine());

		int[] sum = SumOfArrays(arr1, arr2);
		PrintWithoutLeadingZero(sum);
	}
}