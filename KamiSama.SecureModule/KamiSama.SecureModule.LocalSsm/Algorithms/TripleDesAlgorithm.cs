using System.Security.Cryptography;
using KamiSama.Extenders;

namespace KamiSama.SecureModule.LocalSsm.Algorithms
{
	public class TripleDesAlgorithm : ISecurityAlgorithm
    {
		public byte[] Encrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.TripleDesEncrypt(key, iv, cipherMode, padding);

		public byte[] Decrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.TripleDesDecrypt(key, iv, cipherMode, padding);

		public byte[] Sign(byte[] key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7)
			=> data.TripleDesSign(key, iv, padding);
	}
}
