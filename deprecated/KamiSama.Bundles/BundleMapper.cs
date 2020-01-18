using System;
using System.Collections.Generic;
using System.Linq;

namespace KamiSama.Bundles
{
	public static class BundleMapper
    {
		public static _BundleType MapTo<_BundleType>(BundleItem[] items, string culture = "", string prefix = "")
			=> (_BundleType)MapTo(items, typeof(_BundleType), culture, prefix);
		public static _BundleType MapTo<_BundleType>(this IBundleSource bundleSource, string culture = "", string prefix = "")
			=> MapTo<_BundleType>(bundleSource.GetAll(), culture, prefix);
		public static object MapTo(BundleItem[] items, Type bundleType, string culture = "", string prefix = "")
		{
			var tmp = items.Where(x =>
				x.Key.StartsWith(prefix) &&
				((x.Culture + "") == culture))
				.ToArray();

			var bundle = Activator.CreateInstance(bundleType);

			var groups = tmp
				.Select(x => (Arr: x.Key.Substring(prefix.Length).TrimStart('.').Split('.'), Bundle: x))
				.GroupBy(x => x.Item1[0]);

			foreach (var g in groups)
			{
				var first = g.FirstOrDefault();
				var prop = bundleType.GetProperty(g.Key);
				if (prop == null)
					continue;

				if (first.Arr.Length == 1)
					prop.SetValue(bundle, Convert.ChangeType(first.Bundle.Value, prop.PropertyType));
				else
				{
					var obj = MapTo(tmp, prop.PropertyType, culture, prefix + g.Key);

					prop.SetValue(bundle, obj);
				}
			}

			return bundle;
		}
		public static IEnumerable<BundleItem> GetBundlesFrom(object obj, string culture = "", string prefix = "")
		{
			if (obj == null)
				yield break;

			foreach (var prop in obj.GetType().GetProperties())
			{
				if ((prop.PropertyType == typeof(string)) || prop.PropertyType.IsValueType)
					yield return new BundleItem
					{
						Culture = culture,
						Key = (prefix + "." + prop.Name).TrimStart('.'),
						Value = prop.GetValue(obj) + "",
					};
				else
					foreach (var b in GetBundlesFrom(prop.GetValue(obj), culture, (prefix + "." + prop.Name).TrimStart('.')))
						yield return b;
			}
		}
    }
}
