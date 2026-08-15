using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KamiSama.Modules.Identity.Repositories.Database;

/// <summary>
/// Stores Identity users, roles, claims, tokens, and revocable <see cref="ApplicationSession"/> rows in the provider selected at startup.
/// The module's post-build phase can migrate this context before the application starts serving requests.
/// </summary>
public class KamiSamaIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
	/// <summary>Gets or sets the session entity set.</summary>
	public virtual DbSet<ApplicationSession> ApplicationSessions { get; set; }

	/// <summary>Initializes a context for a derived provider-specific context.</summary>
	/// <param name="options">The non-generic options supplied by the concrete provider context.</param>
	protected KamiSamaIdentityDbContext(DbContextOptions options) : base(options)
	{
	}
	/// <summary>Initializes the directly configured base context.</summary>
	/// <param name="options">The options for this context type.</param>
	public KamiSamaIdentityDbContext(DbContextOptions<KamiSamaIdentityDbContext> options) : base(options)
	{
	}

	/// <summary>Configures the unique session-key index, user relationship, cascade deletion, and assembly configurations.</summary>
	/// <param name="modelBuilder">The model builder supplied by Entity Framework Core.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ApplicationSession>()
			.HasIndex(x => x.SessionKey)
			.IsUnique();

		modelBuilder.Entity<ApplicationSession>()
			.HasOne(x => x.User)
			.WithMany(x => x.Sessions)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(KamiSamaIdentityDbContext).Assembly);
	}
}

