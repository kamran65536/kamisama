using System;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.LocalSsm.Algorithms;

namespace KamiSama.SecureModule.LocalSsm
{
	public class SsmKey : IKey, ICloneable
	{
		public Algorithm Algorithm { get; set; }
		public byte[] KeyData { get; set; }
		public bool IsPlainKey { get; set; }
		internal byte[] DecryptedKey { get; set; }

		public object Clone()
		{
			return new SsmKey
			{
				Algorithm = Algorithm,
				KeyData = KeyData.Clone() as byte[],
				IsPlainKey = IsPlainKey,
			};
		}

		public static SsmKey CreatePlainKey(Algorithm algorithm, byte[] key)
		{
			return new SsmKey
			{
				Algorithm = algorithm,
				KeyData = key,
				IsPlainKey = true
			};
		}
	}
}
