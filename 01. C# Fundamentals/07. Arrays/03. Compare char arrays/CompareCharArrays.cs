using System;

class CompareCharArrays
{
	static void Main()
	{
		char[] arr1 = Console.ReadLine().ToCharArray();
		char[] arr2 = Console.ReadLine().ToCharArray();

		int compare = 0;

		for (int i = 0; i < arr1.Length && i < arr2.Length && compare == 0; i++)
		{
			if (arr1[i] < arr2[i])
				compare = -1;
			else if (arr1[i] > arr2[i])
				compare = 1;
		}
		
		if (compare == -1)
			Console.WriteLine("<");
		else if (compare == 1)
			Console.WriteLine(">");
		else
		{
			if (arr1.Length < arr2.Length)
				Console.WriteLine("<");
			else if (arr1.Length > arr2.Length)
				Console.WriteLine(">");
			else
				Console.WriteLine("=");
		}
	}
}