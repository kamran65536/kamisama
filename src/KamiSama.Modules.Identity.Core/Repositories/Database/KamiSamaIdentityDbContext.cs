using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KamiSama.Modules.Identity.Repositories.Database;

public class KamiSamaIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
	public virtual DbSet<ApplicationSession> ApplicationSessions { get; set; }

	protected KamiSamaIdentityDbContext(DbContextOptions options) : base(options)
	{
	}
	public KamiSamaIdentityDbContext(DbContextOptions<KamiSamaIdentityDbContext> options) : base(options)
	{
	}

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

