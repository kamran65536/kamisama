using System;
using System.Linq;

namespace KamiSama.Bundles
{
	public abstract class BundleData<_BundleType>
		where _BundleType : BundleData<_BundleType>
	{
		public static IBundleSource Source { get; set; }

		public static _BundleType Instance { get; private set; }

		static BundleData()
		{
			Instance.UseInMemorySource(Activator.CreateInstance<_BundleType>());
		}

		public static void Load()
		{
			Source.Load();

			Instance = Source.MapTo<_BundleType>();
		}
		public static void Save()
		{
			Source.Clear();
			Source.InitializeWith(BundleMapper.GetBundlesFrom(Instance).ToArray());

			Source.Save();
		}
	}
}
