using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore.Postgresql;

/// <summary>
/// Provides PostgreSQL registrations for multi-provider DbContext builders.
/// </summary>
public static class MultiProviderDbContextBuilderPostgresqlExtensions
{
	/// <summary>
	/// Registers a PostgreSQL DbContext implementation for the builder base context.
	/// </summary>
	/// <typeparam name="TInheritedContext">The provider-specific DbContext implementation.</typeparam>
	/// <param name="builder">The multi-provider DbContext builder.</param>
	/// <returns>The current builder.</returns>
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
