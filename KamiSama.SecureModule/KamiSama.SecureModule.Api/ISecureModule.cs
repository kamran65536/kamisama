using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	public interface ISecureModule
	{
		IKeyStore InternalKeyStore { get; }
		byte[] Encrypt(IKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Decrypt(IKey key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Sign(IKey key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7);

		IKey GenerateKey(KeyGenerationSettings settings);
	}

	public interface ISecureModule<_KeyType> : ISecureModule
		where _KeyType : IKey
	{
		new IKeyStore<_KeyType> InternalKeyStore { get; }
		byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Decrypt(_KeyType key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Sign(_KeyType key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7);
		new _KeyType GenerateKey(KeyGenerationSettings settings);
	}
}
