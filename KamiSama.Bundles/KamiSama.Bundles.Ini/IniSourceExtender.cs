namespace KamiSama.Bundles.Ini
{
	public static class IniSourceExtender
    {
		public static _BundleType UseIniSource<_BundleType>(this _BundleType instance, string path, string defaultCulture = "", bool trimKeys = true)
			where _BundleType : BundleData<_BundleType>
			=> instance.UseSource(new IniBundleSource(path, defaultCulture, trimKeys));

    }
}
