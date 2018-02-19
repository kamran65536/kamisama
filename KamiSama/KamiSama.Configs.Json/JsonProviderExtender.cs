using KamiSama.Configs.Json;

namespace KamiSama.Configs
{
	public static class JsonProviderExtender
    {
		public static void UseJsonProvider<_ConfigType>(this _ConfigType instance, string path)
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseProvider(new JsonConfigProvider<_ConfigType>(path));
    }
}
