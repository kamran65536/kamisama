using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database;

/// <summary>
/// Defines the provider-neutral EF Core model and entity sets used by Locations repositories.
/// </summary>
/// <remarks>Install and register a concrete Locations provider context; application services consume this abstract context through keyed multi-provider resolution.</remarks>
public abstract class LocationsDbContext : DbContext
{
	/// <summary>Gets or sets the provinces in the Locations database.</summary>
	/// <value>The tracked province entity set.</value>
	public virtual DbSet<Province> Provinces { get; set; }
	/// <summary>Gets or sets the cities in the Locations database.</summary>
	/// <value>The tracked city entity set.</value>
	public virtual DbSet<City> Cities { get; set; }

	/// <summary>
	/// Initializes a provider-specific derived context with non-generic EF Core options.
	/// </summary>
	/// <param name="options">The options configured by the concrete provider registration.</param>
	protected LocationsDbContext(DbContextOptions options) : base(options)
	{
	}
	/// <summary>
	/// Initializes the base Locations context with options typed for direct base-context construction.
	/// </summary>
	/// <param name="options">The EF Core options for this base context.</param>
	public LocationsDbContext(DbContextOptions<LocationsDbContext> options) : base(options)
	{
	}

	/// <summary>
	/// Configures the required city-to-province relationship and prevents cascading province deletion.
	/// </summary>
	/// <param name="modelBuilder">The builder for the Locations EF Core model.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<City>()
			.HasOne(x => x.Province)
			.WithMany(x => x.Cities)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
