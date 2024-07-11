namespace Project.Repositories.Database.SqlServer;

internal class PostgresqlBoundedContextDbContext(DbContextOptions<PostgresqlBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
