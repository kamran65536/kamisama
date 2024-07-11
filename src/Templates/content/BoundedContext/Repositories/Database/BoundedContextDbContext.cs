namespace Example.Repositories.Database;

public abstract class BoundedContextDbContext : DbContext
{
	protected BoundedContextDbContext(DbContextOptions options) : base(options)
	{
	}
	public BoundedContextDbContext(DbContextOptions<BoundedContextDbContext> options) : base(options)
	{
	}
}
