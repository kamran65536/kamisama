using System;

namespace KamiSama.Configs
{
	public class InMemoryConfigProvider<_ConfigType> : IConfigProvider<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		public _ConfigType Config { get; private set; }

		public InMemoryConfigProvider(_ConfigType config = null)
		{
			this.Config = config ?? Activator.CreateInstance<_ConfigType>();
		}

		public _ConfigType Load() => Config;

		public void Save(_ConfigType instance)
		{
			Config = instance;
		}
	}
}