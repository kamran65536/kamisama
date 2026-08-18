using KamiSama.Modules.Contents.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Contents.Repositories.Database.Sqlite;

/// <summary>
/// Provides the concrete SQLite EF Core context used by Contents repositories.
/// </summary>
/// <param name="options">The SQLite options configured by <c>AddSqliteContentsDbContext</c>.</param>
public class SqliteContentsDbContext(DbContextOptions<SqliteContentsDbContext> options)
	: ContentsDbContext(options)
{
}
