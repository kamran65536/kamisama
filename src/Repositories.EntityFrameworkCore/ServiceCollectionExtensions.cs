using KamiSama.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore;

/// <summary>
/// Provides EF Core service registration extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds provider-neutral keyed DbContext resolution for a configured database provider.
	/// </summary>
	/// <typeparam name="TBaseContext">The base DbContext type consumed by application code.</typeparam>
	/// <param name="services">The service collection.</param>
	/// <param name="section">The configuration section containing provider and connection string values.</param>
	/// <returns>A builder that provider packages can extend.</returns>
	public static IMultiProviderDbContextBuilder<TBaseContext> AddMultiProviderDbContext<TBaseContext>(
		this IServiceCollection services,
		IConfigurationSection section)
		where TBaseContext : DbContext
	{
		var connectionStringOption = section.Get<ConnectionStringOption>();

		ArgumentNullException.ThrowIfNullOrWhiteSpace(
			connectionStringOption?.Provider,
			$"{section.Key} connection provider is not specified.");
		ArgumentNullException.ThrowIfNullOrWhiteSpace(
			connectionStringOption.ConnectionString,
			$"{section.Key} connection string is not specified.");

		services.AddScoped(sp =>
			sp.GetRequiredKeyedService<TBaseContext>(connectionStringOption.Provider.ToLowerInvariant()));

		return new MultiProviderDbContextBuilder<TBaseContext>(services, connectionStringOption);
	}
}
