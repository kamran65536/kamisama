using KamiSama.Modules.Identity.Repositories.Database;
using KamiSama.Modules.Identity.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Identity;

public static class IdentityPostgresqlDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> AddPostgresqlIdentityDbContext(
		this IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlKamiSamaIdentityDbContext>();
		return builder;
	}
}
