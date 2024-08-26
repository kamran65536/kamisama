using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;

namespace KamiSama.Extensions.DependencyInjection.Tests;

[TestClass]
public class ServiceCollectionExtensionsTests
{
	[TestMethod]
	public void AutoAddDependencies_must_add_dependencies_based_on_InjectAttribute()
	{
		var array = new Assembly[]?[]
		{
			null,
			[],
			[Assembly.GetExecutingAssembly()]
		};
		foreach (var assemblies in array)
		{
			var services = new ServiceCollection();
			services.AutoAddDependencies(assemblies);

			var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface));

			Assert.AreEqual(ServiceLifetime.Singleton, descriptor!.Lifetime);
			Assert.AreEqual(typeof(InjectedImplementation), descriptor.ImplementationType);
		}
	}
	[TestMethod]
	public void AutoAddDependencies_TAssembly_must_add_dependencies_based_on_InjectAttribute()
	{
		var services = new ServiceCollection();
		services.AutoAddDependenciesFrom<ISampleInterface>();

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface));

		Assert.AreEqual(ServiceLifetime.Singleton, descriptor!.Lifetime);
		Assert.AreEqual(typeof(InjectedImplementation), descriptor.ImplementationType);
	}
	[TestMethod]
	public void AutoAddDependencies_TAssembly1_TAssembly2_must_add_dependencies_based_on_InjectAttribute()
	{
		var services = new ServiceCollection();
		services.AutoAddDependenciesFrom<ISampleInterface, ISampleInterface2>();

		var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface));

		Assert.AreEqual(ServiceLifetime.Singleton, descriptor!.Lifetime);
		Assert.AreEqual(typeof(InjectedImplementation), descriptor.ImplementationType);

		var descriptor2 = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface2));

		Assert.AreEqual(ServiceLifetime.Singleton, descriptor2!.Lifetime);
		Assert.AreEqual(typeof(InjectedImplementation2), descriptor2.ImplementationType);
	}
}
