using System;
using System.Collections.Generic;
using System.Linq;

namespace KamiSama.Bundles
{
	public abstract class BundleSourceBase : IBundleSource
	{
		public string DefaultCulture { get; }

		public BundleSourceBase(string defaultCulture)
		{
			this.DefaultCulture = defaultCulture;
		}

		private Dictionary<string, BundleItem> bundles = new Dictionary<string, BundleItem>(StringComparer.InvariantCultureIgnoreCase);
		private bool isLoaded = false;
		public BundleItem[] GetAll() => bundles.Select(x => x.Value).ToArray();
		public virtual BundleItem this[string key, string culture = null]
		{
			get
			{
				if (!isLoaded)
					Load();

				var dicKey = $"{culture ?? DefaultCulture}-{key ?? ""}";

				if (bundles.TryGetValue(dicKey, out BundleItem item))
					return item;
				else
					return null;
			}
			set
			{
				if (!isLoaded)
					Load();

				var dicKey = $"{culture ?? ""}-{key ?? ""}";

				if (bundles.ContainsKey(dicKey))
					bundles[dicKey] = value;
				else
					bundles.Add(dicKey, value);
			}
		}

		public virtual void Load()
		{
			isLoaded = true;
			foreach (var item in LoadBundles())
				this[item.Key, item.Culture] = item;
		}
		protected abstract IEnumerable<BundleItem> LoadBundles();
		public virtual void Save() => SaveBundles(GetAll());
		protected abstract void SaveBundles(BundleItem[] bundleItem);
		public void InitializeWith(BundleItem[] items)
		{
			SaveBundles(items);
			Load();
		}

		public void Clear() =>bundles.Clear();
	}
}
