using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database;

public abstract class LocationsDbContext : DbContext
{
	public virtual DbSet<Province> Provinces { get; set; }
	public virtual DbSet<City> Cities { get; set; }

	protected LocationsDbContext(DbContextOptions options) : base(options)
	{
	}
	public LocationsDbContext(DbContextOptions<LocationsDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<City>()
			.HasOne(x => x.Province)
			.WithMany(x => x.Cities)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
