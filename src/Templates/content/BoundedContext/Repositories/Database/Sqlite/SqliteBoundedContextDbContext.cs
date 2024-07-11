namespace Project.Repositories.Database.Sqlite;

internal class SqliteBoundedContextDbContext(DbContextOptions<SqliteBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
