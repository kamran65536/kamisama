using System.IO;
using KamiSama.Extenders;
using Newtonsoft.Json;

namespace KamiSama.Configs.Json
{
	public class JsonConfigProvider<_ConfigType> : IConfigProvider<_ConfigType>
		where _ConfigType : ConfigData<_ConfigType>
	{
		public string Path { get; }

		public JsonConfigProvider(string path)
		{
			this.Path = path;
		}

		public _ConfigType Load()
			=> File.ReadAllText(Path).DeserializeFromJson<_ConfigType>();
		public void Save(_ConfigType instance)
			=>	File.WriteAllText(Path, instance.SerializeToJson(Formatting.Indented));
	}
}
