namespace KamiSama.Extensions.DependencyInjection.Tests;

[TestClass]
public class AutoInjectAttributeTests
{
	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void TryAdd_must_throw_InvalidOperationException_if_multiple_default_interfaces_are_found()
	{
		var services = new ServiceCollection();
		var attr = new AutoInjectAttribute
		{
			ServiceType = null,
			Lifetime = ServiceLifetime.Singleton
		};

		attr.ApplyInjection(services, typeof(MultipleInterfacesImplementation));
	}
	[TestMethod]
	public void TryAdd_injects_the_type_itself_if_no_default_interface_is_found()
	{
		var services = new ServiceCollection();
		var attr = new AutoInjectAttribute
		{
			ServiceType = null,
			Lifetime = ServiceLifetime.Singleton
		};

		attr.ApplyInjection(services, typeof(NoImplementation));

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(NoImplementation));

		Assert.IsNotNull(descriptor);
		Assert.AreEqual(typeof(NoImplementation), descriptor.ImplementationType);
	}
	[TestMethod]
	[DataRow(ServiceLifetime.Transient)]
	[DataRow(ServiceLifetime.Scoped)]
	[DataRow(ServiceLifetime.Singleton)]
	public void TryAdd_must_add_serviceDescriptor_based_on_lifetime(ServiceLifetime expectedLifetime)
	{
		var services = new ServiceCollection();
		var attr = new AutoInjectAttribute 
		{ 
			Lifetime = expectedLifetime
		};

		attr.ApplyInjection(services, typeof(SampleImplementation1));

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface))!;

		Assert.AreEqual(typeof(SampleImplementation1), descriptor.ImplementationType);
		Assert.AreEqual(expectedLifetime, descriptor.Lifetime);
		Assert.IsNull(descriptor.ServiceKey);
	}
	[TestMethod]
	[DataRow(ServiceLifetime.Transient)]
	[DataRow(ServiceLifetime.Scoped)]
	[DataRow(ServiceLifetime.Singleton)]
	public void TryAdd_must_add_serviceDescriptor_based_on_lifetime_for_ServiceKey(ServiceLifetime expectedLifetime)
	{
		var services = new ServiceCollection();
		var serviceKey = 10;
		var attr = new AutoInjectAttribute
		{
			ServiceKey = serviceKey,
			Lifetime = expectedLifetime
		};

		attr.ApplyInjection(services, typeof(SampleImplementation1));

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface))!;

		Assert.IsTrue(descriptor.IsKeyedService);
		Assert.AreEqual(typeof(SampleImplementation1), descriptor.KeyedImplementationType);
		Assert.AreEqual(expectedLifetime, descriptor.Lifetime);
		Assert.AreEqual(serviceKey, descriptor.ServiceKey);
	}
	[TestMethod]
	[DataRow(typeof(AutoInjectScopedAttribute), ServiceLifetime.Scoped)]
	[DataRow(typeof(AutoInjectTransientAttribute), ServiceLifetime.Transient)]
	[DataRow(typeof(AutoInjectSingletonAttribute), ServiceLifetime.Singleton)]
	public void TryAdd_must_add_serviceDescriptor_based_on_lifetime_for_custom_AutoInjectAttributes(Type autoInjectAttributeType, ServiceLifetime expectedLifetime)
	{
		var services = new ServiceCollection();
		var attr = Activator.CreateInstance(autoInjectAttributeType) as AutoInjectAttributeBase;

		attr!.ApplyInjection(services, typeof(SampleImplementation1));

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface))!;

		Assert.AreEqual(typeof(SampleImplementation1), descriptor.ImplementationType);
		Assert.AreEqual(expectedLifetime, descriptor.Lifetime);
		Assert.IsNull(descriptor.ServiceKey);
	}
}
