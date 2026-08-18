using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Contents.Repositories.Database;

/// <summary>
/// Defines the provider-neutral EF Core model and entity sets used by Contents repositories.
/// </summary>
/// <remarks>Install and register a concrete Contents provider context; application services consume this abstract context through keyed multi-provider resolution.</remarks>
public abstract class ContentsDbContext : DbContext
{
	/// <summary>Gets or sets the content files in the Contents database.</summary>
	/// <value>The tracked content file entity set.</value>
	public virtual DbSet<ContentFile> ContentFiles { get; set; }

	/// <summary>
	/// Initializes the base Contents context with options typed for direct base-context construction.
	/// </summary>
	/// <param name="options">The EF Core options for this base context.</param>
	public ContentsDbContext(DbContextOptions<ContentsDbContext> options) : base(options)
	{
	}

	/// <summary>
	/// Initializes a provider-specific derived context with non-generic EF Core options.
	/// </summary>
	/// <param name="options">The options configured by the concrete provider registration.</param>
	protected ContentsDbContext(DbContextOptions options) : base(options)
	{
	}

	/// <summary>
	/// Configures the Contents EF Core model.
	/// </summary>
	/// <param name="modelBuilder">The builder for the Contents EF Core model.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
