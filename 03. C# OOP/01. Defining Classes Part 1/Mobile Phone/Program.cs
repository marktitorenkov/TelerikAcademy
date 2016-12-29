using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("GSM TEST");
		GSMTest.Start();

		Console.WriteLine();
		Console.WriteLine(new string('=', 50));
		Console.WriteLine();

		Console.WriteLine("CALL HISTORY TEST");
		GSMCallHistoryTest.Start();
	}
}