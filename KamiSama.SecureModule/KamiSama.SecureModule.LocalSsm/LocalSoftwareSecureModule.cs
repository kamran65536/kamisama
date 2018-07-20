using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeySerializers.Bson;
using KamiSama.SecureModule.KeyStores;
using KamiSama.SecureModule.LocalSsm.Algorithms;

namespace KamiSama.SecureModule.LocalSsm
{

	public class LocalSoftwareSecureModule : SecureModuleBase<SsmKey>
	{
		public override IKeySerializer<SsmKey> KeySerializer { get; }

		protected LocalSsmSettings Settings { get; }
		public Dictionary<string, ISecurityAlgorithm> Algorithms { get; }
		protected SsmKey MasterKey { get; private set; }

		public LocalSoftwareSecureModule(LocalSsmSettings settings)
		{
			settings = settings ?? LocalSsmSettings.Instance;

			this.MasterKey = SsmKey.CreatePlainKey(settings.MasterKeyAlgorithm, settings.MasterKey);
			this.KeySerializer = new BsonKeySerializer<SsmKey>(this);

			this.Algorithms = new Dictionary<string, ISecurityAlgorithm>(StringComparer.InvariantCultureIgnoreCase)
			{
				{ "des" ,  new DesAlgorithm() },
				{ "3des" ,  new TripleDesAlgorithm() },
				{ "tdes" ,  new TripleDesAlgorithm() },
				{ "tripledes" ,  new TripleDesAlgorithm() },
				{ "triple-des" ,  new TripleDesAlgorithm() },
				{ "aes" ,  new AesAlgorithm() },
			};
		}
		public LocalSoftwareSecureModule()
			: this(null)
		{
		}

		public override byte[] Encrypt(SsmKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			if (key.DecryptedKey == null)
				if (key.IsPlainKey)
					key.DecryptedKey = key.KeyData;
				else
					key.DecryptedKey = Decrypt(MasterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			return algorithm.Encrypt(key.DecryptedKey, data, iv, cipherMode, padding);
		}
		public override byte[] Decrypt(SsmKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			if (key.DecryptedKey == null)
				if (key.IsPlainKey)
					key.DecryptedKey = key.KeyData;
				else
					key.DecryptedKey = Decrypt(MasterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			return algorithm.Decrypt(key.DecryptedKey, data, iv, cipherMode, padding);
		}
		public override byte[] Sign(SsmKey key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			if (key.DecryptedKey == null)
				if (key.IsPlainKey)
					key.DecryptedKey = key.KeyData;
				else
					key.DecryptedKey = Decrypt(MasterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			return algorithm.Sign(key.DecryptedKey, data, iv, padding);
		}
		public override SsmKey GenerateKeyObject(KeyGenerationSettings settings)
		{
			if (settings == null)
				throw new Exception("Settings cannot be null.");

			if (settings.ExpiryDate.HasValue)
				throw new NotSupportedException("Expiry date is not supported.");
			if (settings.Group != null)
				throw new NotSupportedException("Key Grouping is not supported.");

			var parentKey = ((SsmKey)settings.ParentKey) ?? MasterKey;

			var key = new SsmKey
			{
				Algorithm = settings.Algorithm,
				KeyData = Encrypt(parentKey, settings.KeyData, null, CipherMode.CBC, PaddingMode.PKCS7),
				IsPlainKey = false,
			};

			if (!settings.IsExternalKey)
			{
				var keyStore = GetKeyStore(settings.KeyStoreName);

				if (keyStore == null)
					throw new Exception($"No Key store is found, name: {settings.KeyStoreName}");

				if (string.IsNullOrWhiteSpace(settings.KeyName))
					throw new Exception($"No key name is set.");

				keyStore.SaveKey(settings.KeyName, key);
			}

			return key;
		}

		public override IKeyStore<SsmKey> GetKeyStore(string name)
		{
			switch (name?.ToLower())
			{
				default:
				case "":
				case "inmemory":
					return new InMemoryKeyStore<SsmKey>(this);
				case "filebased":
					return new FileBasedKeyStore<SsmKey>(Settings.FileBasedKeyStorePath, this);
			}
		}


	}
}
