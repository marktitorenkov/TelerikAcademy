using System;

class SayHello
{
	static void AskName()
	{
		string name = Console.ReadLine();
		Console.WriteLine("Hello, {0}!", name);
	}

	static void Main()
	{
		AskName();
	}
}
