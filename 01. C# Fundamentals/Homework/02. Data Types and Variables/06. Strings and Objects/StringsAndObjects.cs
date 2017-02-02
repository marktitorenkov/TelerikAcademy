using System;

class StringsAndObjects
{
	static void Main()
	{
		string hello = "Hello";
		string world = "World";
		Object concat = hello + ' ' + world;
		string helloworld = (string)concat;
	}
}