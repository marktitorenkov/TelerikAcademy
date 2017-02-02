using System;

class Age
{
	static void Main()
	{
		DateTime today = DateTime.Today;
		DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", null);

		int age = today.Year - birthday.Year;

		if (today < birthday.AddYears(age))
			age--;

		Console.WriteLine(age);
		Console.WriteLine(age + 10);
	}
}