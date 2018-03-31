using System;
using System.Security.Cryptography;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.LocalSsm
{
	public sealed class SsmKey : IKeyReference, ICloneable
    {
		public string Algorithm { get; set; }
		public byte[] KeyData { get; set; }
		public bool IsPlainKey { get; set; } = false;
		internal byte[] DecryptedKey { get; set; }
		

		public static SsmKey CreatePlainKey(string algorithm, byte[] key)
		{
			return new SsmKey
			{
				Algorithm = algorithm,
				KeyData = key,
				IsPlainKey = true,
			};
		}
		public static SsmKey CreateEncryptedKey(LocalSoftwareSecureModule secureModule, string algorithm, byte[] key)
		{
			return new SsmKey
			{
				KeyData = secureModule.Encrypt(secureModule.masterKey, key, padding: PaddingMode.PKCS7),
				Algorithm = algorithm,
				IsPlainKey = false,
			};
		}

		public object Clone()
		{
			return new SsmKey
			{
				Algorithm = Algorithm,
				KeyData = KeyData.Clone() as byte[],
				IsPlainKey = IsPlainKey,
			};
		}
	}
}
