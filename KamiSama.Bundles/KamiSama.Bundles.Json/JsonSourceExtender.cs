namespace KamiSama.Bundles.Json
{
	public static class JsonSourceExtender
    {
		public static _BundleType UseJsonSource<_BundleType>(this _BundleType instance, string path, string defaultCulture = "")
			where _BundleType : BundleData<_BundleType>
			=> instance.UseSource(new JsonBundleSource(path, defaultCulture));

    }
}
