using System.Security.Cryptography;
using KamiSama.Extenders;

namespace KamiSama.SecureModule.LocalSsm.Algorithms
{
	public class DesAlgorithm : ISecurityAlgorithm
	{
		public byte[] Encrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.DesEncrypt(key, iv, cipherMode, padding);

		public byte[] Decrypt(byte[] key, byte[] data, byte[] iv, CipherMode cipherMode, PaddingMode padding)
			=> data.DesDecrypt(key, iv, cipherMode, padding);

		public byte[] Sign(byte[] key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7)
			=> data.DesSign(key, iv, padding);
	}
}
