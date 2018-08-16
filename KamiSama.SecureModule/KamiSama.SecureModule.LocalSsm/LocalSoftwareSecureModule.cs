using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeySerializers.Bson;
using KamiSama.SecureModule.KeyStores.InMemory;
using KamiSama.SecureModule.LocalSsm.Algorithms;

namespace KamiSama.SecureModule.LocalSsm
{

	public class LocalSoftwareSecureModule : SecureModuleBase<SsmKey>
	{
		public override IKeyStore<SsmKey> InternalKeyStore { get; }
		protected LocalSsmSettings Settings { get; }
		public Dictionary<Algorithm, ISecurityAlgorithm> Algorithms { get; }
		protected SsmKey MasterKey { get; private set; }
		private Random rand;
		public LocalSoftwareSecureModule(LocalSsmSettings settings)
		{
			settings = settings ?? LocalSsmSettings.Instance;
			this.MasterKey = SsmKey.CreatePlainKey(settings.MasterKeyAlgorithm, settings.MasterKey);
			InternalKeyStore = new InMemoryKeyStore<SsmKey>(this, new BsonKeySerializer<SsmKey>());
			this.rand = new Random();
			this.Algorithms = new Dictionary<Algorithm, ISecurityAlgorithm>
			{
				{ Algorithm.Des ,  new DesAlgorithm() },
				{ Algorithm.TripleDes,  new TripleDesAlgorithm() },
				{ Algorithm.Aes,  new AesAlgorithm() },
			};
		}
		public LocalSoftwareSecureModule()
			: this(null)
		{
		}
		private SsmKey TryDecryptKey(SsmKey key)
		{
			if (key.DecryptedKey == null)
				if (key.IsPlainKey)
					key.DecryptedKey = key.KeyData;
				else
					key.DecryptedKey = Decrypt(MasterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			return key;
		}
		public override byte[] Encrypt(SsmKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			return algorithm.Encrypt(TryDecryptKey(key).DecryptedKey, data, iv, cipherMode, padding);
		}
		public override byte[] Decrypt(SsmKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			return algorithm.Decrypt(TryDecryptKey(key).DecryptedKey, data, iv, cipherMode, padding);
		}
		public override byte[] Sign(SsmKey key, byte[] data, byte[] iv = null, PaddingMode padding = PaddingMode.PKCS7)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");
			return algorithm.Sign(TryDecryptKey(key).DecryptedKey, data, iv, padding);
		}
		public override SsmKey GenerateKey(KeyGenerationSettings keyGenerationSettings)
		{
			if (keyGenerationSettings == null)
				throw new Exception("Settings cannot be null.");

			if (keyGenerationSettings.ExpiryDate.HasValue)
				throw new NotSupportedException("Expiry date is not supported.");
			if (keyGenerationSettings.Group != null)
				throw new NotSupportedException("Key Grouping is not supported.");

			var keyData = new byte[keyGenerationSettings.KeySize];
			rand.NextBytes(keyData);
			var key = new SsmKey
			{
				Algorithm = (Algorithm) keyGenerationSettings.Algorithm,
				IsPlainKey = false,
			};
			if (Settings.MasterKey != null)
				keyData = Encrypt(MasterKey, keyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			key.KeyData = keyData;
			var keyInjectionProperties = new KeyInjectionProperties
			{
				Algorithm = keyGenerationSettings.Algorithm,
				Group = keyGenerationSettings.Group,
				KeySize = keyGenerationSettings.KeySize,
				Name = keyGenerationSettings.KeyName,
			};
			this.InternalKeyStore.InjectKey(key, keyInjectionProperties);

			return key;
		}
	}
}