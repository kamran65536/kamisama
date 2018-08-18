using System.Security.Cryptography;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule
{
	public abstract class SecureModuleBase<_KeyType> : ISecureModule<_KeyType>
		where _KeyType : IKey
	{
		#region ISecureModule<_KeyType>
		public abstract IKeyStore<_KeyType> InternalKeyStore { get; }
		public abstract byte[] Decrypt(_KeyType key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		public abstract byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		public abstract _KeyType GenerateKey(KeyGenerationSettings settings);
		public abstract byte[] Sign(_KeyType key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7);
		#endregion
		#region ISecureModule
		IKeyStore ISecureModule.InternalKeyStore => this.InternalKeyStore;
		public byte[] Decrypt(IKey key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
			=> Decrypt((_KeyType)key, cipher, iv, cipherMode, padding);
		public byte[] Encrypt(IKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
			=> Encrypt((_KeyType)key, data, iv, cipherMode, padding);
		public byte[] Sign(IKey key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7)
			=> Sign((_KeyType)key, data, iv, padding);
		IKey ISecureModule.GenerateKey(KeyGenerationSettings settings)
			=> GenerateKey(settings);
		#endregion
	}
}
