using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore.Sqlite;

/// <summary>
/// Provides SQLite registrations for multi-provider DbContext builders.
/// </summary>
public static class MultiProviderDbContextBuilderSqliteExtensions
{
	/// <summary>
	/// Registers a SQLite DbContext implementation for the builder base context.
	/// </summary>
	/// <typeparam name="TInheritedContext">The provider-specific DbContext implementation.</typeparam>
	/// <param name="builder">The multi-provider DbContext builder.</param>
	/// <returns>The current builder.</returns>
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
