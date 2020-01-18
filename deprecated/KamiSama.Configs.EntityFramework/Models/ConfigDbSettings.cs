namespace KamiSama.Configs.EntityFramework.Models
{
	public class ConfigDbSettings : ConfigData<ConfigDbSettings>
	{
		public string ConnectionString { get; set; } = "Data Source=.;Initial Catalog=ConfigDb;Integrated Security=True;";
		public string DbProviderName { get; set; } = "System.Data.SqlClient";
		public string SchemaName { get; set; } = "dbo";
		public string TableName { get; set; } = "Configs";
	}
}
