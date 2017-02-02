namespace Timer
{
	class Startup
	{
		static void Test()
		{
			System.Console.WriteLine("Test");
		}
		static void Main()
		{
			Timer t = new Timer(Test, 500);
		}
	}
}