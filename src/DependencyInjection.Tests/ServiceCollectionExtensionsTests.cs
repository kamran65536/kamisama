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

			var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInteface));

			Assert.AreEqual(ServiceLifetime.Singleton, descriptor!.Lifetime);
			Assert.AreEqual(typeof(InjectedImplementation), descriptor.ImplementationType);
		}
	}
}
