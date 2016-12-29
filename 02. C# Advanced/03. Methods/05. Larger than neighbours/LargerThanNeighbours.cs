using System;

class LargerThanNeighbours
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

	static int LargerThan(int[] arr)
	{
		int counter = 0;
		for (int i = 1; i < arr.Length - 1; i++)
		{
			if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
				counter++;
		}
		return counter;
	}

	static void Main()
	{
		Console.ReadLine();
		int[] arr = IntArrFromStr(Console.ReadLine());

		Console.WriteLine(LargerThan(arr));
	}
}
