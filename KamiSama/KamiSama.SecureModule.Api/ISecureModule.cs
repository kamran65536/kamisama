using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	public interface ISecureModule
	{
		IKeyReference LoadKey(byte[] keyData);
		byte[] StoreKey(IKeyReference key);

		byte[] Encrypt(IKeyReference key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None);
		byte[] Decrypt(IKeyReference key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None);
	}
}
