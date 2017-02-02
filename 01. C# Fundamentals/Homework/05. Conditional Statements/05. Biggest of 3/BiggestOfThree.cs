using System;

class BiggestOfThree
{
	static void Main()
	{
		float max = float.MinValue;
		for (int i = 0; i < 3; i++)
		{
			float num = float.Parse(Console.ReadLine());
			if (num > max)
				max = num;
		}
		Console.WriteLine(max);
	}
}