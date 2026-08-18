using KamiSama.Modules.ServicePlans.Repositories.Database;
using KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.ServicePlans;

/// <summary>
/// Registers the SQLite ServicePlans context with the multi-provider context builder.
/// </summary>
public static class ServicePlansSqliteDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="SqliteServicePlansDbContext"/> under the exact <c>sqlite</c> keyed base-context service.
	/// </summary>
	/// <param name="builder">The ServicePlans multi-provider context builder.</param>
	/// <returns>The same builder for fluent provider configuration.</returns>
	public static IMultiProviderDbContextBuilder<ServicePlansDbContext> AddSqlite(
		this IMultiProviderDbContextBuilder<ServicePlansDbContext> builder)
	{
		builder.AddSqlite<ServicePlansDbContext, SqliteServicePlansDbContext>();
		return builder;
	}
}
