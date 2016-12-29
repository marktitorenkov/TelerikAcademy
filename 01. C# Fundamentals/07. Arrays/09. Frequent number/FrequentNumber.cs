using System;

class FrequentNumber
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] nums = new int[n];
		for (int i = 0; i < n; i++)
			nums[i] = int.Parse(Console.ReadLine());

		int fnumber = nums[0];
		int fnumberCount = 0;
		for (int i = 0; i < n; i++)
		{
			int currNumber = nums[i];
			int currCount = 0;
			for (int j = 0; j < n; j++)
			{
				if (currNumber == nums[j])
					currCount++;
			}
			if (currCount > fnumberCount)
			{
				fnumberCount = currCount;
				fnumber = currNumber;
			}
		}

		Console.WriteLine("{0} ({1} times)", fnumber, fnumberCount);
	}
}