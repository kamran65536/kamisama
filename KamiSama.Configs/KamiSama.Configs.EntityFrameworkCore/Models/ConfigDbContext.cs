using Microsoft.EntityFrameworkCore;

namespace KamiSama.Configs.EntityFrameworkCore.Models
{
	public class ConfigDbContext : DbContext
	{
		public DbSet<ConfigRow> ConfigRows { get; set; }
		private ConfigDbSettings Settings { get; }
		public ConfigDbContext(ConfigDbSettings settings)
		{
			this.Settings = settings;
		}
		public ConfigDbContext(DbContextOptions<ConfigDbContext> options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			if (!string.IsNullOrWhiteSpace(Settings.SchemaName))
				modelBuilder.HasDefaultSchema(Settings.SchemaName);

			modelBuilder.Entity<ConfigRow>().ToTable("Configs");
		}
	}
}
