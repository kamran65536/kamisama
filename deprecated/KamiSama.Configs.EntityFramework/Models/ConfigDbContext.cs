using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace KamiSama.Configs.EntityFramework.Models
{
	public class ConfigDbContext : DbContext
	{
		public ConfigDbSettings Settings { get; }

		public DbSet<ConfigRow> ConfigRows { get; set; }

		public ConfigDbContext()
			: this(ConfigDbSettings.Instance)
		{
			Database.SetInitializer<ConfigDbContext>(new MigrateDatabaseToLatestVersion<ConfigDbContext, ConfigDbConfiguration>());
		}

		public ConfigDbContext(ConfigDbSettings settings)
			: base(CreateConnection(settings.ConnectionString, settings.DbProviderName), true)
		{
			this.Settings = settings;
		}

		private static DbConnection CreateConnection(string connectionString, string providerName)
		{
			var provider = DbProviderFactories.GetFactory(providerName);

			var connection = provider.CreateConnection();

			connection.ConnectionString = connectionString;

			return connection;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			if (!string.IsNullOrWhiteSpace(Settings.SchemaName))
				modelBuilder.HasDefaultSchema(Settings.SchemaName);

			modelBuilder.Entity<ConfigRow>().ToTable();
		}
	}
}
