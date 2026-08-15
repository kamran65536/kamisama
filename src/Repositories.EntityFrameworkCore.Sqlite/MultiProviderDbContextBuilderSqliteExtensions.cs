using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore.Sqlite;

/// <summary>
/// Registers SQLite contexts with the KamiSama multi-provider DbContext workflow.
/// </summary>
public static class MultiProviderDbContextBuilderSqliteExtensions
{
	/// <summary>
	/// Registers a scoped SQLite context and exposes it under the <c>sqlite</c> keyed base-context service.
	/// </summary>
	/// <typeparam name="TInheritedContext">The provider-specific DbContext implementation.</typeparam>
	/// <param name="builder">The builder containing services, connection settings, base context type, and history table.</param>
	/// <returns>The same builder, enabling additional provider registrations.</returns>
	/// <remarks>
	/// Enables lazy-loading proxies and uses the configured migration-history table. Configure the provider as exactly
	/// <c>sqlite</c> (case-insensitive before key lookup). Registrations are scoped.
	/// </remarks>
	/// <exception cref="InvalidOperationException"><typeparamref name="TInheritedContext"/> does not derive from the builder base context.</exception>
	public static IMultiProviderDbContextBuilder AddSqlite<TInheritedContext>(
		this IMultiProviderDbContextBuilder builder)
		where TInheritedContext : DbContext
	{
		if (!builder.BaseContextType.IsAssignableFrom(typeof(TInheritedContext)))
			throw new InvalidOperationException(
				$"{typeof(TInheritedContext).FullName} must inherit from {builder.BaseContextType.FullName}.");

		builder.Services.AddDbContext<TInheritedContext>((_, options) =>
		{
			options.UseLazyLoadingProxies();
			options.UseSqlite(
				builder.ConnectionStringOption.ConnectionString,
				sqlite => sqlite.MigrationsHistoryTable(builder.MigrationHistoryTable));
		});
		builder.Services.AddKeyedScoped(
			builder.BaseContextType,
			"sqlite",
			(serviceProvider, _) => serviceProvider.GetRequiredService<TInheritedContext>());

		return builder;
	}
}
