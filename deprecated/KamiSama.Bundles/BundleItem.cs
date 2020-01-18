using System;

namespace KamiSama.Bundles
{
	public class BundleItem : ICloneable
	{
		public string Culture { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }

		public object Clone()
			=> this.MemberwiseClone();
	}
}