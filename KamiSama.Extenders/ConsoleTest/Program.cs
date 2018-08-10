using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Paths;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Paths p = new Paths();

			Console.WriteLine(p.Map("{data-path2}/data.txt"));
		}
	}
}
