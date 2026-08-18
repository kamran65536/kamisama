using KamiSama.Modules.Contents.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Contents.Repositories.Database.Postgresql;

/// <summary>
/// Provides the concrete PostgreSQL EF Core context used by Contents repositories.
/// </summary>
/// <param name="options">The PostgreSQL options configured by <c>AddPostgresqlContentsDbContext</c>.</param>
public class PostgresqlContentsDbContext(DbContextOptions<PostgresqlContentsDbContext> options)
	: ContentsDbContext(options)
{
}
