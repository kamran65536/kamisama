using System;
using KamiSama.Paths;
using KamiSama.Extenders;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using KamiSama.Extenders.DependencyInjection;

namespace ConsoleTest
{
	public class A
	{
		public virtual void DoSomething() => Console.WriteLine("A");
	}
	public class B : A
	{
		public override void DoSomething() => Console.WriteLine("B");
	}
	public class C : A
	{
		public override void DoSomething() => Console.WriteLine("C");
	}
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

			//var dt = new DateTime(1, 1, 1, 13, 0, 0, new PersianCalendar());

			//Console.WriteLine(dt.ToPersianString("yyyy/MM/dd HH:mm:ss"));

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddScoped<A, B>("b");
			serviceCollection.AddScoped<A, C>("c");

			using (var provider = serviceCollection.BuildServiceProvider())
			{
				using (var scope = provider.CreateScope())
				{
					var serviceB = provider.GetService<A>("b");
					var serviceC = provider.GetService<A>("C");

					serviceB.DoSomething();
					serviceC.DoSomething();
				}
			}
		}
	}
}
