namespace KamiSama.Configs
{
	public abstract class ConfigData<_ConfigType> 
		where _ConfigType : ConfigData<_ConfigType>
    {
		public static IConfigProvider<_ConfigType> Provider { get; set; }

		public static _ConfigType Instance { get; private set; } 

		static ConfigData()
		{
			Provider = new InMemoryConfigProvider<_ConfigType>();

			Load();
		}

		public static void Load() => Instance = Provider.Load();
		public static void Save() => Provider.Save(Instance);
    }
}
