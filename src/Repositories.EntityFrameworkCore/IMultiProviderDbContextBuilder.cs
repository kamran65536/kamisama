using KamiSama.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore;

/// <summary>
/// Defines the provider-neutral state needed to register a DbContext for multiple database providers.
/// </summary>
/// <remarks>Provider extensions add scoped concrete contexts and keyed scoped aliases for <see cref="BaseContextType"/>.</remarks>
public interface IMultiProviderDbContextBuilder
{
	/// <summary>
	/// Gets the service collection receiving DbContext registrations.
	/// </summary>
	/// <value>The service collection supplied to multi-provider registration.</value>
	IServiceCollection Services { get; }

	/// <summary>
	/// Gets the selected provider and connection string.
	/// </summary>
	/// <value>The configuration values bound by <c>AddMultiProviderDbContext</c>.</value>
	ConnectionStringOption ConnectionStringOption { get; }

	/// <summary>
	/// Gets or sets the EF Core migrations history table used by provider registrations.
	/// </summary>
	/// <value>The provider migration-history table name.</value>
	string MigrationHistoryTable { get; set; }

	/// <summary>
	/// Gets the base DbContext type resolved by consumers.
	/// </summary>
	/// <value>The application-facing DbContext base type.</value>
	Type BaseContextType { get; }
}

/// <summary>
/// Defines provider-neutral DbContext registration for a base context type.
/// </summary>
/// <typeparam name="TBaseContext">The base DbContext type consumed by repositories and modules.</typeparam>
/// <remarks>Install provider packages and call their generic registration methods with concrete derived contexts.</remarks>
public interface IMultiProviderDbContextBuilder<TBaseContext> : IMultiProviderDbContextBuilder
	where TBaseContext : DbContext
{
	/// <summary>
	/// Sets the EF Core migrations history table used by provider registrations.
	/// </summary>
	/// <param name="migrationHistoryTable">The exact migrations history table name passed to each provider registration.</param>
	/// <returns>The same builder, enabling provider registration chaining.</returns>
	IMultiProviderDbContextBuilder<TBaseContext> WithMigrationHistoryTable(string migrationHistoryTable)
	{
		MigrationHistoryTable = migrationHistoryTable;
		return this;
	}
}
