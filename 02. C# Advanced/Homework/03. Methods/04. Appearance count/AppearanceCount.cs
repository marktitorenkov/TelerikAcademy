using System;

class AppearanceCount
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

	static int CountInArray(int[] arr, int search)
	{
		int count = 0;
		foreach (int item in arr)
		{
			if (item == search)
				count++;
		}
		return count;
	}

	static void Main()
	{
		Console.ReadLine();
		int[] arr = IntArrFromStr(Console.ReadLine());
		int search = int.Parse(Console.ReadLine());
		
		Console.WriteLine(CountInArray(arr, search));
	}
}
