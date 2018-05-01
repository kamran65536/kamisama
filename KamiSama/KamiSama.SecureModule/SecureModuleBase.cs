using System.Collections.Generic;
using System.Security.Cryptography;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule
{
	public abstract class SecureModuleBase<_KeyType> : ISecureModule<_KeyType>
		where _KeyType : class, IKey
	{
		private Dictionary<string, IKeyStore<_KeyType>> keystores = new Dictionary<string, IKeyStore<_KeyType>>();

		public abstract IKeySerializer<_KeyType> KeySerializer { get; }

		IKeySerializer ISecureModule.KeySerializer => this.KeySerializer;

		public abstract byte[] Decrypt(_KeyType key, byte[] cipher, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] ISecureModule.Decrypt(IKey key, byte[] cipher, byte[] iv, CipherMode cipherMode, PaddingMode padding) => Decrypt((_KeyType) key, cipher, iv, cipherMode, padding);
		public abstract byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7);
		byte[] ISecureModule.Encrypt(IKey key, byte[] cipher, byte[] iv, CipherMode cipherMode, PaddingMode padding) => Encrypt((_KeyType) key, cipher, iv, cipherMode, padding);
		public abstract _KeyType GenerateKeyObject(string algorithm, byte[] key, _KeyType parentKey = null);
		IKey ISecureModule.GenerateKeyObject(string algorithm, byte[] key, IKey parentKey) => GenerateKeyObject(algorithm, key, (_KeyType) parentKey);
		IKeyStore ISecureModule.GetKeyStore(string name) => this.GetKeyStore(name);
		public IKeyStore<_KeyType> GetKeyStore(string name = null)
		{
			name = name ?? "";

			if (keystores.TryGetValue(name, out IKeyStore<_KeyType> keystore))
				return keystore;

			keystores.Add(name, keystore = CreateKeyStore(name));

			return keystore;
		}

		protected abstract IKeyStore<_KeyType> CreateKeyStore(string name);
	}
}
