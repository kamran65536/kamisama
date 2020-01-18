using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KamiSama.Bundles.Json
{
	public class JsonBundleSource : BundleSourceBase
	{
		public string FileName { get; }
		public JsonBundleSource(string filename, string defaultCulture = "")
			: base(defaultCulture)
		{
			this.FileName = filename;
		}
		private string MapDefaultCulture(string culture)
		{
			if (string.IsNullOrWhiteSpace(culture))
				return DefaultCulture;
			else
				return culture;
		}
		protected override IEnumerable<BundleItem> LoadBundles()
		{
			var text = File.ReadAllText(FileName);

			var bundles = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(text);

			return bundles.SelectMany(kv1 => kv1.Value.Select(kv2 => new BundleItem
			{
				Culture = MapDefaultCulture(kv1.Key),
				Key = kv2.Key,
				Value = kv2.Value
			}));
		}

		protected override void SaveBundles(BundleItem[] bundleItems)
		{
			var dic = bundleItems
				.GroupBy(x => x.Culture)
				.Select(g => new { g.Key, CultureDic = g.ToDictionary(x => x.Key, x => x.Value) })
				.ToDictionary(x => x.Key, x => x.CultureDic);

			File.WriteAllText(FileName, JsonConvert.SerializeObject(dic, Formatting.Indented));
		}
	}
}
