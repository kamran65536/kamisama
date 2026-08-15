using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore.Postgresql;

/// <summary>
/// Registers PostgreSQL contexts with the KamiSama multi-provider DbContext workflow.
/// </summary>
public static class MultiProviderDbContextBuilderPostgresqlExtensions
{
	/// <summary>
	/// Registers a scoped PostgreSQL context and exposes it under the <c>postgresql</c> keyed base-context service.
	/// </summary>
	/// <typeparam name="TInheritedContext">The provider-specific DbContext implementation.</typeparam>
	/// <param name="builder">The builder containing services, connection settings, base context type, and history table.</param>
	/// <returns>The same builder, enabling additional provider registrations.</returns>
	/// <remarks>
	/// Enables lazy-loading proxies, uses the configured migration-history table, and sets
	/// <c>Npgsql.EnableLegacyTimestampBehavior</c> and <c>Npgsql.DisableDateTimeInfinityConversions</c> process-wide.
	/// Configure the provider as exactly <c>postgresql</c> (case-insensitive before key lookup). Registrations are scoped.
	/// </remarks>
	/// <exception cref="InvalidOperationException"><typeparamref name="TInheritedContext"/> does not derive from the builder base context.</exception>
	public static IMultiProviderDbContextBuilder AddPostgresql<TInheritedContext>(
		this IMultiProviderDbContextBuilder builder)
		where TInheritedContext : DbContext
	{
		if (!builder.BaseContextType.IsAssignableFrom(typeof(TInheritedContext)))
			throw new InvalidOperationException(
				$"{typeof(TInheritedContext).FullName} must inherit from {builder.BaseContextType.FullName}.");

		builder.Services.AddDbContext<TInheritedContext>((_, options) =>
		{
			options.UseLazyLoadingProxies();
			options.UseNpgsql(
				builder.ConnectionStringOption.ConnectionString,
				npgsql => npgsql.MigrationsHistoryTable(builder.MigrationHistoryTable));
		});
		builder.Services.AddKeyedScoped(
			builder.BaseContextType,
			"postgresql",
			(serviceProvider, _) => serviceProvider.GetRequiredService<TInheritedContext>());
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

		return builder;
	}
}
