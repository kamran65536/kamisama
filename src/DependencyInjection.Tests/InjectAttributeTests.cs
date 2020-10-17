using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace KamiSama.Extensions.DependencyInjection.Tests
{
	[TestClass]
	public class InjectAttributeTests
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TryAdd_must_throw_InvalidOperationException_if_multiple_default_interfaces_are_faound()
		{
			var services = new ServiceCollection();
			var attr = new InjectAttribute(serviceType: null, lifetime: ServiceLifetime.Singleton);

			attr.TryAddInjection(services, typeof(MultipleInterfacesImplementation));
		}
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TryAdd_must_throw_InvalidOperationException_if_no_default_interface_is_found()
		{
			var services = new ServiceCollection();
			var attr = new InjectAttribute(serviceType: null, lifetime: ServiceLifetime.Singleton);

			attr.TryAddInjection(services, typeof(NoImplementation));
		}
		[TestMethod]
		[DataRow(ServiceLifetime.Transient)]
		[DataRow(ServiceLifetime.Scoped)]
		[DataRow(ServiceLifetime.Singleton)]
		public void TryAdd_must_add_serviceDescriptor_based_on_lifetime(ServiceLifetime expectedLifetime)
		{
			var services = new ServiceCollection();
			var attr = new InjectAttribute(serviceType: typeof(SampleInteface), expectedLifetime);

			attr.TryAddInjection(services, typeof(SampleImplementation1));

			var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(SampleInteface));

			Assert.AreEqual(typeof(SampleImplementation1), descriptor.ImplementationType);
			Assert.AreEqual(expectedLifetime, descriptor.Lifetime);
		}
	}
}
