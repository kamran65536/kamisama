using System.Security.Cryptography;

namespace KamiSama.SecureModule.LocalSsm.Algorithms
{
	public interface ISecurityAlgorithm
    {
		byte[] Encrypt(byte[] key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Decrypt(byte[] key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
	}
}
