using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace KamiSama.Extenders.EntityFramework
{
	public static class DbMigrationConfigurationExtender
    {
		public static void UseMigrationContext<_ContextType>(this DbMigrationsConfiguration<_ContextType> configuration, string providerInvariantName, Action<DbModelBuilder> modelCustomizationBuilder)
			where _ContextType  : DbContext
		{
			configuration.SetHistoryContextFactory(providerInvariantName, (connection, defaultSchema) => new CustomHistoryContext(connection, defaultSchema, modelCustomizationBuilder));
		}
    }
}
