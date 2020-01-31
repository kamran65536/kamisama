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
	}
}
