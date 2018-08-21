using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KamiSama.Paths
{
	public class Paths
	{ 
		private Dictionary<string, string> pathRegistrations { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

		public void Register(string pathName, string path)
		{
			pathRegistrations[pathName] = Translate(path);

			foreach (var k in pathRegistrations.Keys.ToArray())
				pathRegistrations[k] = Translate(pathRegistrations[k]);
		}

		public Paths(string rootPath = "./", string dataPath = "{root-path}/data", string configsPath = "{root-path}/configs")
		{
			Register("root-path", rootPath);
			Register("data-path", dataPath);
			Register("configs-path", configsPath);
			Register("config-path", configsPath);
		}

		public string Translate(string relativePath)
		{
			foreach (var path in pathRegistrations)
				relativePath = relativePath.Replace("{" + path.Key + "}", path.Value);

			return relativePath
				.Replace(@"\","/")
				.Replace("//", "/");
		}

		public string Map(string relativePath)
			=> Path.GetFullPath(Translate(relativePath));
	}
}
