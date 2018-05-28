using System.Security.Cryptography;
using KamiSama.Extenders;

namespace KamiSama.SecureModule.LocalSsm.Algorithms
{
	public class AesAlgorithm : ISecurityAlgorithm
    {
		public byte[] Encrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.AesEncrypt(key, iv, cipherMode, padding);

		public byte[] Decrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.AesDecrypt(key, iv, cipherMode, padding);
	}
}
