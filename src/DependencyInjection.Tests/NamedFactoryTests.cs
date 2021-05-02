using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection.Tests
{
	[TestClass]
	public class NamedFactoryTests
	{
		
		[TestMethod]
		public void Register_must_add_or_update_namedTypes()
		{
			var factory = new NamedFactory(typeof(ISampleInteface));

			factory.Register("name", typeof(SampleImplementation1));

			Assert.AreEqual(typeof(SampleImplementation1), factory.namedTypes["name"]);
			Assert.AreEqual(typeof(SampleImplementation1), factory.namedTypes["Name"]);

			factory.Register<SampleImplementation2>("name");
			Assert.AreEqual(typeof(SampleImplementation2), factory.namedTypes["name"]);
			Assert.AreEqual(typeof(SampleImplementation2), factory.namedTypes["Name"]);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		[ExcludeFromCodeCoverage]
		public void GetByName_throws_exception_if_no_service_is_found_by_name()
		{
			var serviceProvider = Substitute.For<IServiceProvider>();

			var factory = new NamedFactory(typeof(ISampleInteface));

			factory.FindByName(serviceProvider, "wrong name");
		}
		[TestMethod]
		public void GetByName_returns_new_instance_by_name()
		{
			var serviceProvider = Substitute.For<IServiceProvider>();

			var factory = new NamedFactory(typeof(ISampleInteface));
			factory.Register<SampleImplementation1>("a");

			serviceProvider.GetService(typeof(SampleImplementation1)).Returns(new SampleImplementation1());

			var result = factory.FindByName(serviceProvider, "a");

			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void GenericNameFactory_is_equivalant_to_NameFactory_with_corresponing_ServiceType()
		{
			var factory = new NamedFactory<ISampleInteface>();

			Assert.AreEqual(typeof(ISampleInteface), factory.ServiceType);
		}
	}
}
