using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.LocalSsm.Algorithms;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KamiSama.SecureModule.LocalSsm
{

	public class LocalSoftwareSecureModule : SecureModuleBase<SsmKey>
	{
		internal SsmKey masterKey;
		private JsonSerializer jsonSerializer;
		public Dictionary<string, ISecurityAlgorithm> Algorithms { get; }

		public LocalSoftwareSecureModule(SsmKey masterKey)
		{
			this.masterKey = masterKey;
			this.jsonSerializer = JsonSerializer.CreateDefault();
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

		#region Load/Store Key
		public override SsmKey LoadKey(byte[] keyData)
		{
			if (keyData == null)
				throw new NullReferenceException("Key data cannot be null.");

			using (var memStream = new MemoryStream(keyData))
			{
				using (var bsonReader = new BsonDataReader(memStream))
				{
					return jsonSerializer.Deserialize<SsmKey>(bsonReader);
				}
			}
		}

		public override byte[] StoreKey(SsmKey key)
		{
			if (key == null)
				throw new NullReferenceException("Key cannot be null.");

			using (var memStream = new MemoryStream())
			{
				using (var bsonWriter = new BsonDataWriter(memStream))
				{
					jsonSerializer.Serialize(bsonWriter, key);
				}

				return memStream.ToArray();
			}
		}
		#endregion
		public override byte[] Encrypt(SsmKey key, byte[] data, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.None)
		{
			if (!Algorithms.TryGetValue(key.Algorithm, out ISecurityAlgorithm algorithm))
				throw new Exception($"Algorithm {key.Algorithm} is not found.");

			if (key.DecryptedKey == null)
				if (key.IsPlainKey)
					key.DecryptedKey = key.KeyData;
				else
					key.DecryptedKey = Decrypt(masterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

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
					key.DecryptedKey = Decrypt(masterKey, key.KeyData, iv: null, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			return algorithm.Decrypt(key.DecryptedKey, data, iv, cipherMode, padding);
		}

	}
}
