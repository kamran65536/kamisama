using System;
using System.Linq;
using KamiSama.Configs.EntityFramework.Models;
using KamiSama.Extenders;
using Newtonsoft.Json;

namespace KamiSama.Configs.EntityFramework
{
	public class DbConfigProvider<_ConfigType> : IConfigProvider<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		public string ConfigProfile { get; }
		public ConfigDbSettings Settings { get; }

		public DbConfigProvider()
			: this(null, null)
		{
		}
		public DbConfigProvider(ConfigDbSettings settings, string profile)
		{
			this.ConfigProfile = profile ?? "Default";
			this.Settings = settings ?? ConfigDbSettings.Instance;
		}

		public _ConfigType Load()
		{
			var contextKey = typeof(_ConfigType).Name.ToLower();

			using (var db = new ConfigDbContext(Settings))
			{
				var row = db.ConfigRows.FirstOrDefault(x =>
					(x.ProfileName.ToLower() == ConfigProfile.ToLower()) &&
					(x.ConfigContextKey == contextKey));

				if (string.IsNullOrWhiteSpace(row?.Text))
					return Activator.CreateInstance<_ConfigType>();
				else
					return row.Text.DeserializeFromJson<_ConfigType>();
			}
		}

		public void Save(_ConfigType instance)
		{
			var contextKey = typeof(_ConfigType).Name;

			using (var db = new ConfigDbContext(Settings))
			{
				var row = db.ConfigRows.FirstOrDefault(x =>
					(x.ProfileName.ToLower() == ConfigProfile.ToLower()) &&
					(x.ConfigContextKey == contextKey));

				if (row == null)
					db.ConfigRows.Add(new ConfigRow
					{
						ProfileName = ConfigProfile,
						ConfigContextKey = contextKey,
						Text = instance?.SerializeToJson(Formatting.Indented)
					});
				else
					row.Text = instance?.SerializeToJson(Formatting.Indented);

				db.SaveChanges();
			}
		}

	}
}