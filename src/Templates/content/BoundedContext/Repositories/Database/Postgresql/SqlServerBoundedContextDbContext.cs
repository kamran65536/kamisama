namespace Project.Repositories.Database.Postgresql;

internal class PostgresqlBoundedContextDbContext(DbContextOptions<PostgresqlBoundedContextDbContext> options) : BoundedContextDbContext(options)
{
}
