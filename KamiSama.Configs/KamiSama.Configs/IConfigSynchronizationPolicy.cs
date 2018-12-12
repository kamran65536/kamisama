namespace KamiSama.Configs
{
	public interface IConfigSynchronizationPolicy<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		void Apply(_ConfigType config);
		void Stop(_ConfigType config);
	}
}
