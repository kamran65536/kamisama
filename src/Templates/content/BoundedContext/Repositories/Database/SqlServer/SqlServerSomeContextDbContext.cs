namespace Example.BoundedContext.Repositories.Database.SqlServer;

internal class SqlServerBoundedContextDbContext(DbContextOptions<SqlServerBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
