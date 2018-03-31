using System;
using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	public abstract class SecureModuleBase<_KeyType> : ISecureModule
		where _KeyType : class, IKeyReference
	{
		private _KeyType CheckKeyType(IKeyReference _key)
		{
			if (!(_key is _KeyType key))
				throw new Exception($"Invalid key type: {_key?.GetType()}");

			return key;
		}

		byte[] ISecureModule.Decrypt(IKeyReference key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None)
			=> Decrypt(CheckKeyType(key), data, iv, cipherMode, padding);

		byte[] ISecureModule.Encrypt(IKeyReference key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None)
			=> Encrypt(CheckKeyType(key), data, iv, cipherMode, padding);


		IKeyReference ISecureModule.LoadKey(byte[] keyData)
			=> LoadKey(keyData);

		byte[] ISecureModule.StoreKey(IKeyReference key)
			=> StoreKey(CheckKeyType(key));

		public abstract byte[] Decrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None);
		public abstract byte[] Encrypt(_KeyType key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None);
		public abstract _KeyType LoadKey(byte[] keyData);
		public abstract byte[] StoreKey(_KeyType key);
	}
}
