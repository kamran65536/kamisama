using System.IO;
using KamiSama.Extenders;

namespace KamiSama.Configs
{
	public class XmlConfigProvider<_ConfigType> : IConfigProvider<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		public string Path { get; }

		public XmlConfigProvider(string path)
		{
			this.Path = path;
		}

		public _ConfigType Load()
			=> File.ReadAllText(Path).Deserialize<_ConfigType>();
		public void Save(_ConfigType instance)
			=>	File.WriteAllText(Path, instance.Serialize(indented: true));
	}
}
