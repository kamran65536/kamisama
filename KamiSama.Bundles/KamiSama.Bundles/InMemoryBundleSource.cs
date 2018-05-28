using System.Collections.Generic;
using System.Linq;

namespace KamiSama.Bundles
{
	public class InMemoryBundleSource : BundleSourceBase
	{
		public BundleItem[] BundleItems { get; private set; }
		public InMemoryBundleSource(BundleItem[] items, string defaultCulture = "")
			: base(defaultCulture)
		{
			InitializeWith(items);
		}

		protected override IEnumerable<BundleItem> LoadBundles()
			=> BundleItems;

		protected override void SaveBundles(BundleItem[] items)
			=> BundleItems = items.Select(x => x.Clone() as BundleItem).ToArray();
	}
}
