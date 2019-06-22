using KamiSama.Configs.EntityFrameworkCore.Models;

namespace KamiSama.Configs.EntityFrameworkCore
{

	public static class DbConfigProviderExtender
	{
		public static void UseDatabase<_ConfigType>(this _ConfigType instance, ConfigDbSettings settings, string profileName = "Default")
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseProvider(new DbConfigProvider<_ConfigType>(settings, profileName));
	}
}
