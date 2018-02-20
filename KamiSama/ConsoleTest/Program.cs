using System;
using System.IO;
using System.Linq;
using System.Reflection;
using KamiSama.Configs;
using KamiSama.Extenders;
using KamiSama.Extenders.Ninject;
using Newtonsoft.Json;
using Ninject.Planning.Bindings;

namespace ConsoleTest
{
	public class KamranBinding : Binding
	{
		public KamranBinding(Type service) : base(service)
		{
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//SampleSettings.Instance.UseInMemoryPrvider(new SampleSettings
			//{
			//	X = 10,
			//	Y = 11
			//});

			SampleSettings.Instance.UseXmlProvider(@"d:\sample.xml");

			Console.WriteLine(SampleSettings.Instance.X);

			//Container.ActiveProfiles.Add("Default");
			//Container.ActiveProfiles.Add("Runtime");

			//Container.Instance.ApplyBindToAttributes("ConsoleTest.*");

			//Console.WriteLine(Container.TryGet<Interface1>()?.GetType()?.Name);
		}
	}
}
