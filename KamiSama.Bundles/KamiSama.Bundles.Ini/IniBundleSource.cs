using System;
using System.Collections.Generic;

namespace KamiSama.Bundles.Ini
{

	public class IniBundleSource : BundleSourceBase
	{
		public string FileName { get; }
		public bool TrimKeys { get; }

		public IniBundleSource(string fileName, string defaultCulture = "", bool trimKeys = true)
			: base(defaultCulture)
		{
			this.FileName = fileName;
			this.TrimKeys = trimKeys;
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
			var file = new IniFile(FileName);

			foreach (var section in file.GetSections())
			{
				if (!section.ToLower().StartsWith("culture="))
					throw new Exception($"Invalid section: {section}. Sections must be in the form of culture=<culture>");

				var culture = section.Substring("culture=".Length);

				culture = MapDefaultCulture(culture);

				foreach (var key in file.GetKeys(section))
				{
					var tmp = TrimKeys ? key?.Trim() : key; 
					yield return new BundleItem { Culture = culture, Key = tmp, Value = file.GetValue(key, section) };
				}
			}
		}

		protected override void SaveBundles(BundleItem[] items)
		{
			var file = new IniFile(FileName);

			foreach (var item in items)
			{
				var culture = item.Culture ?? DefaultCulture;
				file.WriteValue(item.Key, "culture=" + culture, item.Value);
			}
			file.Save();
		}
	}
}
