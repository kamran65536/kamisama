namespace ExampleNamespace.Repositories.Database;

[ExcludeFromCodeCoverage]
public class ExampleContextDbContext : DbContext
{
	//#if (IncludeEntities)
	public virtual DbSet<SampleEntity> SampleEntities { get; set; }
	//#endif

	public ExampleContextDbContext(DbContextOptions<ExampleContextDbContext> options) : base(options)
	{
	}

	protected ExampleContextDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
