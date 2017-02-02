namespace Attrib
{
	using System;

	[VersionAttribute("1.01")]
	public class TestVersionAttribute
	{
		public static void Main()
		{
			Type type = typeof(TestVersionAttribute);
			DisplayTypeAttributes(type);
		}

		public static void DisplayTypeAttributes(Type type)
		{
			object[] attributes = type.GetCustomAttributes(false);

			foreach (var attribute in attributes)
			{
				Console.WriteLine(attribute);
			}
		}
	}
}