using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

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

			serviceCollection.AddNamed(sampleName, typeof(ISampleInteface), typeof(SampleImplementation1));

			var factoryDescriptor = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<ISampleInteface>));
			var factory = factoryDescriptor.ImplementationInstance as NamedFactory<ISampleInteface>;

			Assert.IsNotNull(factory);
			Assert.AreEqual(typeof(SampleImplementation1), factory.namedTypes[sampleName]);
		}
		[TestMethod]
		public void AddNamed_must_reuse_factory_to_ServiceCollection_if_it_already_exists()
		{
			const string sampleName = "test";
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddNamed(sampleName, typeof(ISampleInteface), typeof(SampleImplementation1));

			var factoryDescriptor1 = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<ISampleInteface>));
			var factory1 = factoryDescriptor1.ImplementationInstance as NamedFactory<ISampleInteface>;
		
			serviceCollection.AddNamed(sampleName, typeof(ISampleInteface), typeof(SampleImplementation2));
			var factoryDescriptor2 = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(NamedFactory<ISampleInteface>));
			var factory2 = factoryDescriptor1.ImplementationInstance as NamedFactory<ISampleInteface>;

			Assert.AreSame(factory1, factory2);
		}
		[TestMethod]
		public void AutoAddDependencies_must_add_dependencies_based_on_InjectAttribute()
		{
			var array = new Assembly[][]
			{
				null,
				System.Array.Empty<Assembly>(),
				new Assembly[] { Assembly.GetExecutingAssembly() }
			};
			foreach (var assemblies in array)
			{
				var services = new ServiceCollection();
				services.AutoAddDependencies(assemblies);

				var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInteface));

				Assert.AreEqual(ServiceLifetime.Singleton, descriptor.Lifetime);
				Assert.AreEqual(typeof(InjectedImplementation), descriptor.ImplementationType);
			}
		}
	}
}
