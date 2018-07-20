using System.Security.Cryptography;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule
{
	public abstract class SecureModuleBase<_KeyType> : ISecureModule<_KeyType>
		where _KeyType : class, IKey
	{
		public abstract IKeySerializer<_KeyType> KeySerializer { get; }

		IKeySerializer ISecureModule.KeySerializer => this.KeySerializer;

		public abstract byte[] Decrypt(_KeyType key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] ISecureModule.Decrypt(IKey key, byte[] cipher, byte[] iv, CipherMode cipherMode, PaddingMode padding) => Decrypt((_KeyType) key, cipher, iv, cipherMode, padding);
		public abstract byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] ISecureModule.Encrypt(IKey key, byte[] cipher, byte[] iv, CipherMode cipherMode, PaddingMode padding) => Encrypt((_KeyType) key, cipher, iv, cipherMode, padding);
		public abstract _KeyType GenerateKeyObject(KeyGenerationSettings settings);
		IKey ISecureModule.GenerateKeyObject(KeyGenerationSettings settings) => GenerateKeyObject(settings);
		IKeyStore ISecureModule.GetKeyStore(string name) => this.GetKeyStore(name);
		public abstract IKeyStore<_KeyType> GetKeyStore(string name);

		public abstract byte[] Sign(_KeyType key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7);
		byte[] ISecureModule.Sign(IKey key, byte[] data, byte[] iv,  PaddingMode padding)
			=> Sign(key as _KeyType, data, iv, padding);
	}
}
