namespace ExampleCore.Repositories.Database;

[ExcludeFromCodeCoverage]
public class ExampleCoreDbContext : DbContext
{
	//#if (IncludeEntities)
	public virtual DbSet<SampleEntity> SampleEntities { get; set; }
	//#endif

	public ExampleCoreDbContext(DbContextOptions<ExampleCoreDbContext> options) : base(options)
	{
	}

	protected ExampleCoreDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
