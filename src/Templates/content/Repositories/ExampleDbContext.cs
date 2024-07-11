namespace Project.Repositories;

public class ExampleDbContext(DbContextOptions<ExampleDbContext> options) : DbContext(options)
{
///#if (AddSamples)
	public virtual DbSet<SampleEntity> SampleEntities { get; set; }
///#endif
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleDbContext).Assembly);
	}
}
