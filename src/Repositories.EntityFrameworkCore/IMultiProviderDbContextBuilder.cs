using KamiSama.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore;

/// <summary>
/// Defines the provider-neutral state needed to register a DbContext for multiple database providers.
/// </summary>
public interface IMultiProviderDbContextBuilder
{
	/// <summary>
	/// Gets the service collection receiving DbContext registrations.
	/// </summary>
	IServiceCollection Services { get; }

	/// <summary>
	/// Gets the selected provider and connection string.
	/// </summary>
	ConnectionStringOption ConnectionStringOption { get; }

	/// <summary>
	/// Gets or sets the EF Core migrations history table used by provider registrations.
	/// </summary>
	string MigrationHistoryTable { get; set; }

	/// <summary>
	/// Gets the base DbContext type resolved by consumers.
	/// </summary>
	Type BaseContextType { get; }
}

/// <summary>
/// Defines provider-neutral DbContext registration for a base context type.
/// </summary>
/// <typeparam name="TBaseContext">The base DbContext type consumed by repositories and modules.</typeparam>
public interface IMultiProviderDbContextBuilder<TBaseContext> : IMultiProviderDbContextBuilder
	where TBaseContext : DbContext
{
	/// <summary>
	/// Sets the EF Core migrations history table used by provider registrations.
	/// </summary>
	/// <param name="migrationHistoryTable">The migrations history table name.</param>
	/// <returns>The current builder.</returns>
	IMultiProviderDbContextBuilder<TBaseContext> WithMigrationHistoryTable(string migrationHistoryTable)
	{
		MigrationHistoryTable = migrationHistoryTable;
		return this;
	}
}
