using KamiSama.Modules.Identity.Repositories.Database;
using KamiSama.Modules.Identity.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Identity;

public static class IdentitySqliteDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> AddSqliteIdentityDbContext(
		this IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> builder)
	{
		builder.AddSqlite<SqliteKamiSamaIdentityDbContext>();
		return builder;
	}
}
