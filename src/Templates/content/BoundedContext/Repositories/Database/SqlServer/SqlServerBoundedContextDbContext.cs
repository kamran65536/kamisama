namespace Project.Repositories.Database.SqlServer;

internal class SqliteBoundedContextDbContext(DbContextOptions<SqliteBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
