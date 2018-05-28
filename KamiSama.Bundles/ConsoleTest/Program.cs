using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Bundles;
using KamiSama.Bundles.Ini;
using KamiSama.Bundles.Json;
using Newtonsoft.Json;

namespace ConsoleTest
{
	class Program
	{
		public class Omid
		{
			public int C { get; set; }
		}
		public class Kamran
		{
			public int A { get; set; }
			public int B { get; set; }

			public Omid C { get; set; }
		}

		static void Main(string[] args)
		{
			var bundles = new BundleItem[]
			{
				new BundleItem{ Culture = "", Key = "A", Value = "10" },
				new BundleItem { Culture = "", Key = "B", Value = "11" },
				new BundleItem { Culture = "", Key = "C.C", Value = "12"}
			};

			//var jsonSource = new JsonBundleSource(@"D:\1.json");

			//Console.WriteLine(jsonSource["A", "en-us"]?.Value);
			//Console.WriteLine(jsonSource["B"]?.Value);
			//Console.WriteLine(jsonSource["C", "fa-ir"]?.Value);

			//var iniSource = new IniBundleSource(@"d:\1.ini", "en-US");

			//iniSource.InitializeWith(bundles);

			//iniSource.Save();

			//Console.WriteLine(iniSource["A", "en-us"]?.Value);
			//Console.WriteLine(iniSource["B"]?.Value);
			//Console.WriteLine(iniSource["C", "fa-ir"]?.Value);

			//var mem = new InMemoryBundleSource(bundles);

			//var kamran = new Kamran
			//{
			//	A = 10,
			//	B = 11,
			//	C = new Omid
			//	{
			//		C =  12,
			//	}
			//};

			//var bb = BundleMapper.GetBundlesFrom(kamran, "fa-IR").ToArray();

			//Console.WriteLine(JsonConvert.SerializeObject(bb, Formatting.Indented));

			var kamran = BundleMapper.MapTo<Kamran>(bundles);

			Console.WriteLine(JsonConvert.SerializeObject(kamran));
		}
	}
}
