using System;

class CompareArrays
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[] arr1 = new int[n];
		int[] arr2 = new int[n];

		for (int i = 0; i < n; i++)
			arr1[i] = int.Parse(Console.ReadLine());

		for (int i = 0; i < n; i++)
			arr2[i] = int.Parse(Console.ReadLine());

		bool isEqual = true;
		for (int i = 0; i < n && isEqual; i++)
			isEqual = arr1[i] == arr2[i];

		Console.WriteLine(isEqual ? "Equal" : "Not equal");
	}
}