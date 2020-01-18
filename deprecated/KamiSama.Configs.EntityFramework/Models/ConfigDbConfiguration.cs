using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.History;
using KamiSama.Extenders.EntityFramework;

namespace KamiSama.Configs.EntityFramework.Models
{
	public class ConfigDbConfiguration : DbMigrationsConfiguration<ConfigDbContext>
	{
		public ConfigDbConfiguration()
		{
			AutomaticMigrationsEnabled = true;

			this.UseMigrationContext(ConfigDbSettings.Instance.DbProviderName, modelBuilder =>
			{
				modelBuilder.Entity<HistoryRow>().ToTable("_ConfigsMigrationHistory");
			});
		}
	}
}
