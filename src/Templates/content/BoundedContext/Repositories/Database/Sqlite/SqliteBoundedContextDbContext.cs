namespace Example.Repositories.Database.Sqlite;

internal class SqliteBoundedContextDbContext(DbContextOptions<SqliteBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
