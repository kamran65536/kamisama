using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	public interface ISecureModule
    {
		IKeySerializer KeySerializer { get; }

		IKeyStore GetKeyStore(string name);
		byte[] Encrypt(IKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Decrypt(IKey key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		IKey GenerateKeyObject(KeyGenerationSettings settings);
    }
	public interface ISecureModule<_KeyType> : ISecureModule
		where _KeyType : class, IKey
	{
		new IKeySerializer<_KeyType> KeySerializer { get; }

		new IKeyStore<_KeyType> GetKeyStore(string name);
		byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] Decrypt(_KeyType key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		new _KeyType GenerateKeyObject(KeyGenerationSettings settings);
	}
}
