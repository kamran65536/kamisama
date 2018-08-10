using System;
using System.Collections.Generic;
using System.IO;

namespace KamiSama.Paths
{
	public class Paths
	{ 
		private Dictionary<string, string> pathRegistrations { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

		public void Register(string pathName, string path)
		{
			pathRegistrations[pathName] = Map(path);
		}

		public Paths(string rootPath = "./", string dataPath = "{root-path}/data", string configsPath = "{root-path}/configs")
		{
			Register("root-path", rootPath);
			Register("data-path", dataPath);
			Register("configs-path", configsPath);
			Register("config-path", configsPath);
		}

		public string Map(string relativePath)
		{
			foreach (var path in pathRegistrations)
				relativePath = relativePath.Replace("{" + path.Key + "}", path.Value); 

			relativePath = relativePath.Replace("//", "/");

			return Path.GetFullPath(relativePath);
		}
	}
}
