using System;

class MultiplicationSign
{
	static void Main()
	{
		bool positive = true;
		bool iszero = false;
		for (int i = 0; i < 3; i++)
		{
			double num = double.Parse(Console.ReadLine());
			if (num < 0)
			{
				positive = !positive;
			}
			else if (num == 0)
			{
				iszero = true;
				break;
			}
		}

		if (!iszero)
		{
			if (positive)
				Console.WriteLine("+");
			else
				Console.WriteLine("-");
		}
		else
		{
			Console.WriteLine("0");
		}
	}
}
