using System;
using System.Collections.Generic;
using System.Linq;

namespace JediMeditation
{
	class Program
	{
		static void Main()
		{
			var m = new List<string>();
			var k = new List<string>();
			var p = new List<string>();

			Console.ReadLine();
			var jedis = Console.ReadLine().Split(' ').ToArray();

			foreach (var jedi in jedis)
			{
				if (jedi[0] == 'M')
				{
					m.Add(jedi);
				}
				else if (jedi[0] == 'K')
				{
					k.Add(jedi);
				}
				else
				{
					p.Add(jedi);
				}
			}

			m.AddRange(k);
			m.AddRange(p);
			Console.WriteLine(string.Join(" ", m));
		}
	}
}