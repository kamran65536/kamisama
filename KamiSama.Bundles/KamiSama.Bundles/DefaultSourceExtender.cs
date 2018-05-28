namespace KamiSama.Bundles
{
	public static class DefaultSourceExtender
    {
		public static _BundleType UseSource<_BundleType>(this _BundleType instance, IBundleSource source)
			where _BundleType : BundleData<_BundleType>
		{
			var type = typeof(BundleData<_BundleType>);

			var prop = type.GetProperty("Provider");
			prop.SetValue(null, source);

			var method = type.GetMethod("Load");
			method.Invoke(null, null);

			return instance;
		}
    }
}
