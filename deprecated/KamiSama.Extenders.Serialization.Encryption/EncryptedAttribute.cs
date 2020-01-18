using System;

namespace KamiSama.Extenders.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class EncryptedAttribute : Attribute
	{
		public static byte[] DefaultKey { get; set; } = { 0x57, 0x6D, 0x5A, 0x71, 0x34, 0x74, 0x37, 0x77, 0x21, 0x7A, 0x25, 0x43, 0x2A, 0x46, 0x2D, 0x4A };
		private readonly byte[] _key;

		public byte[] Key => _key ?? DefaultKey;

		public EncryptedAttribute(byte[] key = null)
		{
			this._key = key;
		}
	}
}
