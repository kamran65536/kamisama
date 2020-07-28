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
		public void AddScopedEx_injects_IScoped_TService()
		{
			var services = new ServiceCollection();

			services.AddScopedEx<SampleInteface, SampleImplementation1>();

			var provider = services.BuildServiceProvider();

			using (var scope = provider.CreateScope())
			{
				var instance1 = scope.ServiceProvider.GetService<SampleInteface>();
				var instance2 = scope.ServiceProvider.GetService<SampleInteface>();

				var scoped1 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();
				var scoped2 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();

				Assert.IsNotNull(instance1);
				Assert.IsNotNull(instance2);
				Assert.IsNotNull(scoped1);
				Assert.IsNotNull(scoped2);

				Assert.AreNotSame(instance1, instance2);
				Assert.AreSame(scoped1, scoped2);
			}
		}
		[TestMethod]
		public void AddSingletonEx_injects_ISingleton_TService()
		{
			var services = new ServiceCollection();

			services.AddSingletonEx<SampleInteface, SampleImplementation1>();

			var provider = services.BuildServiceProvider();

			var instance1 = provider.GetService<SampleInteface>();
			var instance2 = provider.GetService<SampleInteface>();

			var singleton1 = provider.GetService<ISingleton<SampleInteface>>();
			var singleton2 = provider.GetService<ISingleton<SampleInteface>>();

			Assert.IsNotNull(instance1);
			Assert.IsNotNull(instance2);
			Assert.IsNotNull(singleton1);
			Assert.IsNotNull(singleton2);

			Assert.AreNotSame(instance1, instance2);
			Assert.AreSame(singleton1, singleton2);
		}
		[TestMethod]
		public void AddAllEx_injects_all_scoped_and_singleton_services()
		{
			var services = new ServiceCollection();

			services.AddAllEx<SampleInteface, SampleImplementation1>();

			var provider = services.BuildServiceProvider();

			using (var scope = provider.CreateScope())
			{
				var instance1 = scope.ServiceProvider.GetService<SampleInteface>();
				var instance2 = scope.ServiceProvider.GetService<SampleInteface>();

				var scoped1 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();
				var scoped2 = scope.ServiceProvider.GetService<IScoped<SampleInteface>>();

				Assert.IsNotNull(instance1);
				Assert.IsNotNull(instance2);
				Assert.IsNotNull(scoped1);
				Assert.IsNotNull(scoped2);

				Assert.AreNotSame(instance1, instance2);
				Assert.AreSame(scoped1, scoped2);
			}

			var singleton1 = provider.GetService<ISingleton<SampleInteface>>();
			var singleton2 = provider.GetService<ISingleton<SampleInteface>>();
			Assert.IsNotNull(singleton1);
			Assert.IsNotNull(singleton2);

			Assert.AreSame(singleton1, singleton2);
		}
	}
}
