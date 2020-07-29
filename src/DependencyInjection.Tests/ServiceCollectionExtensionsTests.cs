using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KamiSama.Extensions.DependencyInjection.Tests
{
	[TestClass]
	public class ServiceCollectionExtensionsTests
	{
		[TestMethod]
		public void AddNamed_must_add_factory_to_ServiceCollection_if_it_does_not_exist()
		{
			const string sampleName = "test";
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddNamed(sampleName, typeof(SampleInteface), typeof(SampleImplementation1));

			var factoryDescriptor = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<SampleInteface>));
			var factory = factoryDescriptor.ImplementationInstance as NamedFactory<SampleInteface>;

			Assert.IsNotNull(factory);
			Assert.AreEqual(typeof(SampleImplementation1), factory.namedTypes[sampleName]);
		}
		[TestMethod]
		public void AddNamed_must_reuse_factory_to_ServiceCollection_if_it_already_exists()
		{
			const string sampleName = "test";
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddNamed(sampleName, typeof(SampleInteface), typeof(SampleImplementation1));

			var factoryDescriptor1 = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<SampleInteface>));
			var factory1 = factoryDescriptor1.ImplementationInstance as NamedFactory<SampleInteface>;
		
			serviceCollection.AddNamed(sampleName, typeof(SampleInteface), typeof(SampleImplementation2));
			var factoryDescriptor2 = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<SampleInteface>));
			var factory2 = factoryDescriptor1.ImplementationInstance as NamedFactory<SampleInteface>;

			Assert.AreSame(factory1, factory2);
		}
		[TestMethod]
		public void AddLifetimeSpecific_injects_all_specific_services()
		{
			var services = new ServiceCollection();

			services.AddLifetimeSpecific<SampleInteface, SampleImplementation1>();

			var provider = services.BuildServiceProvider();

			using (var scope = provider.CreateScope())
			{
				var instance1 = scope.ServiceProvider.GetService<SampleInteface>();
				var instance2 = scope.ServiceProvider.GetService<SampleInteface>();

				var transient1 = scope.ServiceProvider.GetService<SampleInteface>();
				var transient2 = scope.ServiceProvider.GetService<SampleInteface>();

				var scoped1 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();
				var scoped2 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();

				Assert.IsNotNull(transient1);
				Assert.IsNotNull(transient2);
				Assert.IsNotNull(instance1);
				Assert.IsNotNull(instance2);
				Assert.IsNotNull(scoped1);
				Assert.IsNotNull(scoped2);

				Assert.AreNotSame(transient1, transient2);
				Assert.AreNotSame(instance1, instance2);
				Assert.AreSame(scoped1, scoped2);
			}

			var singleton1 = provider.GetService<ISingleton<SampleInteface>>();
			var singleton2 = provider.GetService<ISingleton<SampleInteface>>();
			var transient3 = provider.GetService<SampleInteface>();
			var transient4 = provider.GetService<SampleInteface>();

			Assert.IsNotNull(transient3);
			Assert.IsNotNull(transient4);
			Assert.IsNotNull(singleton1);
			Assert.IsNotNull(singleton2);

			Assert.AreNotSame(transient3, transient4);
			Assert.AreSame(singleton1, singleton2);
		}
		[TestMethod]
		public void AddLifetimeSpecific_injects_all_specific_services2()
		{
			var services = new ServiceCollection();

			services.AddLifetimeSpecific<SampleInteface>(sp => new SampleImplementation1());

			var provider = services.BuildServiceProvider();

			using (var scope = provider.CreateScope())
			{
				var instance1 = scope.ServiceProvider.GetService<SampleInteface>();
				var instance2 = scope.ServiceProvider.GetService<SampleInteface>();

				var transient1 = scope.ServiceProvider.GetService<SampleInteface>();
				var transient2 = scope.ServiceProvider.GetService<SampleInteface>();

				var scoped1 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();
				var scoped2 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();

				Assert.IsNotNull(transient1);
				Assert.IsNotNull(transient2);
				Assert.IsNotNull(instance1);
				Assert.IsNotNull(instance2);
				Assert.IsNotNull(scoped1);
				Assert.IsNotNull(scoped2);

				Assert.AreNotSame(transient1, transient2);
				Assert.AreNotSame(instance1, instance2);
				Assert.AreSame(scoped1, scoped2);
			}

			var singleton1 = provider.GetService<ISingleton<SampleInteface>>();
			var singleton2 = provider.GetService<ISingleton<SampleInteface>>();
			var transient3 = provider.GetService<SampleInteface>();
			var transient4 = provider.GetService<SampleInteface>();

			Assert.IsNotNull(transient3);
			Assert.IsNotNull(transient4);
			Assert.IsNotNull(singleton1);
			Assert.IsNotNull(singleton2);

			Assert.AreNotSame(transient3, transient4);
			Assert.AreSame(singleton1, singleton2);
		}
	}
}
