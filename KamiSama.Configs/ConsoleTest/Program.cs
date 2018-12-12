using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Configs;
using KamiSama.Configs.EntityFramework;
using KamiSama.Extenders;

namespace ConsoleTest
{
	public class InnerConfig
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class MyConfig : ConfigData<MyConfig>
	{
		public int X { get; set; } = 33;
		public InnerConfig InnerConfig { get; set; }
		public int[] Arr { get; set; } = { 10, 11, 12 };
	}

	class Program
	{
		static void Main(string[] args)
		{
			MyConfig.Instance.UseSqlDatabase("Data Source=.;Initial Catalog=ConfigDb;Integrated Security=True;", "Sample");

			Console.WriteLine(MyConfig.Instance.SerializeToJson(Newtonsoft.Json.Formatting.Indented));

			MyConfig.Save();


		}
	}
}
