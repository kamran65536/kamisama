using System;
using KamiSama.Paths;
using KamiSama.Extenders;
using System.Globalization;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//Paths p = new Paths(dataPath: "{root-path}/{system-name}/data");

			//p.Register("system-name", "ddd");

			//Console.WriteLine(p.Map("{data-path}/data.txt"));
			//Console.WriteLine(p.Map("{root-path}"));
			//Console.WriteLine(p.Map("{data-path}"));
			//Console.WriteLine(p.Map("{config-path}"));
			//Console.WriteLine(p.Map("{configs-path}//1"));

			var dt = new DateTime(1, 1, 1, 13, 0, 0, new PersianCalendar());

			Console.WriteLine(dt.ToPersianString("yyyy/MM/dd HH:mm:ss"));
		}
	}
}
