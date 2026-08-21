using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore.Oracle;

/// <summary>
/// Registers Oracle contexts with the KamiSama multi-provider DbContext workflow.
/// </summary>
public static class MultiProviderDbContextBuilderOracleExtensions
{
	/// <param name="builder">The builder containing services, connection settings, base context type, and history table.</param>
	extension<TContext>(IMultiProviderDbContextBuilder<TContext> builder)
		where TContext : DbContext
	{
		/// <summary>
		/// Registers a scoped Oracle context and exposes it under the <c>oracle</c> keyed base-context service.
		/// </summary>
		/// <typeparam name="TInheritedContext">The provider-specific DbContext implementation.</typeparam>
		/// <returns>The same builder, enabling additional provider registrations.</returns>
		/// <remarks>
		/// Enables lazy-loading proxies and uses the configured migration-history table. Configure the provider as exactly
		/// <c>oracle</c> (case-insensitive before key lookup). Registrations are scoped.
		/// </remarks>
		/// <exception cref="InvalidOperationException"><typeparamref name="TInheritedContext"/> does not derive from the builder base context.</exception>
		public IMultiProviderDbContextBuilder<TContext> AddOracle<TInheritedContext>()
			where TInheritedContext : TContext
		{
			if (!builder.BaseContextType.IsAssignableFrom(typeof(TInheritedContext)))
				throw new InvalidOperationException(
					$"{typeof(TInheritedContext).FullName} must inherit from {builder.BaseContextType.FullName}.");

			builder.Services.AddDbContext<TInheritedContext>((_, options) =>
			{
				options.UseLazyLoadingProxies();
				options.UseOracle(
					builder.ConnectionStringOption.ConnectionString,
					oracle => oracle.MigrationsHistoryTable(builder.MigrationHistoryTable));
			});
			builder.Services.AddKeyedScoped(
				builder.BaseContextType,
				"oracle",
				(serviceProvider, _) => serviceProvider.GetRequiredService<TInheritedContext>());

			return builder;
		}
	}
}
