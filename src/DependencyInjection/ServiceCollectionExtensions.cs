using System.Reflection;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Service Collection Extension for named implementations
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
	/// </summary>
	/// <param name="services"></param>
	/// <param name="assemblies">list of assemblies to search, null means all assemblies</param>
	/// <returns></returns>
	public static IServiceCollection AutoAddDependencies(this IServiceCollection services, params Assembly[]? assemblies)
	{
		if ((assemblies == null) || (assemblies.Length == 0))
			assemblies = AppDomain.CurrentDomain.GetAssemblies();

		var types = assemblies
			.SelectMany(x => x.DefinedTypes)
			.ToArray();

		foreach (var type in types)
		{
			var attrs = type.GetCustomAttributes<AutoInjectAttributeBase>();

			foreach (var attr in attrs)
				attr.TryAddInjection(services, type);
		}

		return services;
	}
	/// <summary>
	/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
	/// </summary>
	/// <returns></returns>
	public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType>(this IServiceCollection services)
		=> services.AutoAddDependencies(typeof(TAssemblyType).Assembly);
	/// <summary>
	/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
	/// </summary>
	/// <returns></returns>
	public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services)
		=> services.AutoAddDependencies(typeof(TAssemblyType1).Assembly, typeof(TAssemblyType2).Assembly);
}