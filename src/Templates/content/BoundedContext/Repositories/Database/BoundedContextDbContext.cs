namespace Example.BoundedContext.Repositories;

public abstract class BoundedContextDbContext : DbContext
{
	public virtual DbSet<SampleEntity> SampleEntities { get; set; }

	protected BoundedContextDbContext(DbContextOptions options) : base(options)
	{
	}
	public BoundedContextDbContext(DbContextOptions<BoundedContextDbContext> options) : base(options)
	{
	}
}
