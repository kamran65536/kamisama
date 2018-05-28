namespace KamiSama.Configs
{
	public interface IConfigProvider<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		_ConfigType Load();
		void Save(_ConfigType instance);
	}
}