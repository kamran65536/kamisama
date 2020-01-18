using System.Linq;

namespace KamiSama.Bundles
{
	public static class InMemorySourceExtender
    {
		public static _BundleType UseInMemorySource<_BundleType>(this _BundleType instance, _BundleType bundle)
			where _BundleType : BundleData<_BundleType>
		{
			var bundles = BundleMapper.GetBundlesFrom(bundle).ToArray();

			return instance.UseSource(new InMemoryBundleSource(bundles));
		}
    }
}
