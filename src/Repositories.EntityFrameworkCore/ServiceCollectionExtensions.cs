using KamiSama.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore;

/// <summary>
/// Provides provider-neutral EF Core service registration extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Binds database settings and adds scoped resolution of a base DbContext through a configured keyed provider.
	/// </summary>
	/// <typeparam name="TBaseContext">The base DbContext type consumed by application code.</typeparam>
	/// <param name="services">The service collection.</param>
	/// <param name="section">The section containing the <c>provider</c> and <c>connection-string</c> keys.</param>
	/// <returns>A builder used to set the migration-history table and register one or more concrete provider contexts.</returns>
	/// <remarks>
	/// The configured provider is lowercased for keyed resolution. The installed provider extension must register that
	/// exact key. Both the base-context alias and provider contexts are scoped.
	/// </remarks>
	/// <exception cref="ArgumentNullException">The provider or connection string is null, empty, or whitespace.</exception>
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
