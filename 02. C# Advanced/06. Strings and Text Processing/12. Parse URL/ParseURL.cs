using System;

class Program
{
	static void Main()
	{
		string url = Console.ReadLine();

		string protocol;
		string server;
		string resource;

		int p = url.IndexOf(':');
		protocol = url.Substring(0, p);
		url = url.Substring(p + 3);

		int s = url.IndexOf('/');
		server = url.Substring(0, s);
		url = url.Substring(s);

		resource = url;

		Console.WriteLine("[protocol] = {0}", protocol);
		Console.WriteLine("[server] = {0}", server);
		Console.WriteLine("[resource] = {0}", resource);
	}
}