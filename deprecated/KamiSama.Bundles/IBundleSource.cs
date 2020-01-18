using System.Collections.Generic;

namespace KamiSama.Bundles
{
	public interface IBundleSource
    {
		BundleItem this[string key, string culture = null] { get; set; }

		BundleItem[] GetAll();
		void Load();
		void Save();
		void Clear();
		void InitializeWith(BundleItem[] bundles);
	}
}
