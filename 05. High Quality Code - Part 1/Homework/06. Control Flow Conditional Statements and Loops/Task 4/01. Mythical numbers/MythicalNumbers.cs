using System;

class MythicalNumbers
{
	static void Main()
	{
		string number = Console.ReadLine();
		float firstDigit = number[0] - '0';
		float secondDigit = number[1] - '0';
		float thirdDigit = number[2] - '0';

		float result;
		if (thirdDigit == 0)
		{
			result = firstDigit * secondDigit;
		}
		else if (thirdDigit > 0 && thirdDigit <= 5)
		{
			result = (firstDigit * secondDigit) / thirdDigit;
		}
		else // c > 5
		{
			result = (firstDigit + secondDigit) * thirdDigit;
		}

		Console.WriteLine($"{result:F2}");
	}
}
