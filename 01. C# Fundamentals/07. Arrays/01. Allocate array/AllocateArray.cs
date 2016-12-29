using System;

class AllocateArray
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[] array = new int[n];

		for (int i = 0; i < n; i++)
		{
			array[i] = i * 5;
		}

		foreach (int item in array)
		{
			Console.WriteLine(item);
		}
	}
}