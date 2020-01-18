using Microsoft.Extensions.Options;
using System;

namespace KamiSama.Configs.EntityFrameworkCore.Models
{
	public class ConfigDbSettings : ConfigData<ConfigDbSettings>
	{
		public string SchemaName { get; set; } = null;
		public string TableName { get; set; } = "Configs";
		public Action<OptionsBuilder<ConfigDbContext>> OptionsActions { get; set; }
	}
}
