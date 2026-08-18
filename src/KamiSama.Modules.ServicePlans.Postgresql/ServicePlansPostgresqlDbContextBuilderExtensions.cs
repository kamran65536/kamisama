using KamiSama.Modules.ServicePlans.Repositories.Database;
using KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.ServicePlans;

/// <summary>
/// Registers the PostgreSQL ServicePlans context with the multi-provider context builder.
/// </summary>
public static class ServicePlansPostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="PostgresqlServicePlansDbContext"/> under the exact <c>postgresql</c> keyed base-context service.
	/// </summary>
	/// <param name="builder">The ServicePlans multi-provider context builder.</param>
	/// <returns>The same builder for fluent provider configuration.</returns>
	public static IMultiProviderDbContextBuilder<ServicePlansDbContext> AddPostgresql(
		this IMultiProviderDbContextBuilder<ServicePlansDbContext> builder)
	{
		builder.AddPostgresql<ServicePlansDbContext, PostgresqlServicePlansDbContext>();
		return builder;
	}
}
