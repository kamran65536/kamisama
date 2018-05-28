using System;
using System.IO;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeyStores;

namespace KamiSama.SecureModule.KeyStores
{
	public class FileBasedKeyStore<_KeyType> : KeyStoreBase<_KeyType>
		where _KeyType : class, IKey
	{
		public string DirectoryPath { get; }
		public string KeyFilenameFormat { get; }

		public FileBasedKeyStore(string directoryPath, string keyFilenameFormat, ISecureModule<_KeyType> securityModule) : base(securityModule)
		{
			this.DirectoryPath = directoryPath;
			this.KeyFilenameFormat = keyFilenameFormat;
		}
		public FileBasedKeyStore(string directoryPath, ISecureModule<_KeyType> securityModule)
			: this(directoryPath, "{0}.key", securityModule)
		{
		}

		public override _KeyType LoadKey(string name)
		{
			var filePath = Path.Combine(DirectoryPath, string.Format(KeyFilenameFormat, name));
			var keyData = File.ReadAllBytes(filePath);

			return base.SecurityModule.KeySerializer.DeserializeKey(keyData);
		}

		public override void SaveKey(string name, _KeyType key)
		{
			if (key == null)
				throw new NullReferenceException("Key cannot be null.");

			var filePath = Path.Combine(DirectoryPath, string.Format(KeyFilenameFormat, name));
			var keyData = base.SecurityModule.KeySerializer.SerializeKey(key);

			File.WriteAllBytes(filePath, keyData);
		}
	}
}
