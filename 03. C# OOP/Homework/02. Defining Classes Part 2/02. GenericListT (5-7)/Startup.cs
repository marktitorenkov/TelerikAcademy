namespace GenericListT
{
	using System;

	class Startup
	{
		static void Main()
		{
			var nums = new GenericList<int>(13);

			nums.Add(1);
			nums.Add(2);
			nums.Add(3);
			nums.Add(4);
			nums.Add(5);
			nums.Add(6);
			Console.WriteLine("Inital numbers:");
			Console.WriteLine(nums);

			nums.InsertAt(5555, 4);
			Console.WriteLine("\nInserting number at index 4:");
			Console.WriteLine(nums);

			nums.RemoveAt(0);
			Console.WriteLine("\nRemoving number at index 0:");
			Console.WriteLine(nums);

			Console.WriteLine($"\nIndex of '6': {nums.IndexOf(6)}");

			Console.WriteLine($"\nBiggest number is : {GenericList<int>.Max(nums)}");

			Console.WriteLine($"\nSmallest number is : {GenericList<int>.Min(nums)}");

			nums.Clear();
			Console.WriteLine("\nClearing list:");
			Console.WriteLine(nums);
		}
	}
}