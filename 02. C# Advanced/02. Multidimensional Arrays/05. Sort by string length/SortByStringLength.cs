using System;

class SortByStringLength
{
	static void Main()
	{
		Console.WriteLine("Enter array seperated by spaces: ");
		string[] stringarray = Console.ReadLine().Split(' ');

		SortByLength(stringarray);

		Console.WriteLine("Sorted array by length of strings: ");
		Console.WriteLine(String.Join(" ", stringarray));
	}
	static void SortByLength(string[] arr)
	{
		bool swaped = true;
		for (int j = 0; j < arr.Length && swaped; j++)
		{
			swaped = false;
			for (int i = 0; i < arr.Length - 1 - j; i++)
			{
				if (arr[i].Length > arr[i + 1].Length)
				{
					string temp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = temp;
					swaped = true;
				}
			}
		}
	}
}