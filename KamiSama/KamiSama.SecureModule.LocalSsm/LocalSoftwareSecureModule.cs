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

		public override SsmKey GenerateKeyObject(string algorithm, byte[] key, SsmKey parentKey = null)
		{
			parentKey = parentKey ?? MasterKey;

			return new SsmKey
			{
				Algorithm = algorithm,
				KeyData = Encrypt(parentKey, key, null, CipherMode.CBC, PaddingMode.PKCS7),
				IsPlainKey = false,
			};
		}

		protected override IKeyStore<SsmKey> CreateKeyStore(string name)
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
