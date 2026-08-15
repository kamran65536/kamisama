using System.Reflection;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Provides assembly-scanning extensions that apply automatic injection attributes to a service collection.
/// Use these methods at application startup after decorating service implementation classes.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Scans the selected assemblies and applies every <see cref="AutoInjectAttributeBase"/> found on their declared types.
	/// When no assemblies are supplied, all assemblies currently loaded in the application domain are scanned.
	/// </summary>
	/// <param name="services">The service collection that receives registrations from discovered attributes.</param>
	/// <param name="assemblies">The assemblies to scan, or <see langword="null"/> or an empty array to scan all currently loaded assemblies.</param>
	/// <returns>The same service collection so additional registrations can be chained.</returns>
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
				attr.ApplyInjection(services, type);
		}

		return services;
	}
	/// <summary>
	/// Scans the assembly containing <typeparamref name="TAssemblyType"/> and applies automatic injection attributes.
	/// Use a marker type from the assembly whose attributed implementations should be registered.
	/// </summary>
	/// <typeparam name="TAssemblyType">A type contained in the assembly to scan.</typeparam>
	/// <param name="services">The service collection that receives registrations from discovered attributes.</param>
	/// <returns>The same service collection so additional registrations can be chained.</returns>
	public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType>(this IServiceCollection services)
		=> services.AutoAddDependencies(typeof(TAssemblyType).Assembly);
	/// <summary>
	/// Scans the assemblies containing both marker types and applies automatic injection attributes from each assembly.
	/// Use this overload when attributed implementations are split across two known assemblies.
	/// </summary>
	/// <typeparam name="TAssemblyType1">A type contained in the first assembly to scan.</typeparam>
	/// <typeparam name="TAssemblyType2">A type contained in the second assembly to scan.</typeparam>
	/// <param name="services">The service collection that receives registrations from discovered attributes.</param>
	/// <returns>The same service collection so additional registrations can be chained.</returns>
	public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services)
		=> services.AutoAddDependencies(typeof(TAssemblyType1).Assembly, typeof(TAssemblyType2).Assembly);
}
