using KamiSama.Configs.EntityFramework.Models;

namespace KamiSama.Configs.EntityFramework
{
	public static class DbConfigProviderExtender
	{
		public static void UseDatabase<_ConfigType>(this _ConfigType instance, ConfigDbSettings settings = null, string profileName = "Default")
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseProvider(new DbConfigProvider<_ConfigType>(settings ?? ConfigDbSettings.Instance, profileName));

		public static void UseSqlDatabase<_ConfigType>(this _ConfigType instance, string connectionString, string profileName = "Default")
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseDatabase(new ConfigDbSettings
			{
				ConnectionString = connectionString,
				DbProviderName = "System.Data.SqlClient",
				Schema = "dbo"
			}, profileName);
		public static void UseOracleDatabase<_ConfigType>(this _ConfigType instance, string connectionString, string schemaName, string profileName = "Default")
		where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseDatabase(new ConfigDbSettings
			{
				ConnectionString = connectionString,
				DbProviderName = "Oracle.ManagedDataAccess.Client",
				Schema = schemaName,
			}, profileName);
	}
}
