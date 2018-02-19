using System;
using System.Linq;
using System.Reflection;
using KamiSama.Extenders.Ninject;
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
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");

			Container.Instance.ApplyBindToAttributes("ConsoleTest.*");

			Console.WriteLine(Container.TryGet<Interface1>()?.GetType()?.Name);
		}
	}
}
