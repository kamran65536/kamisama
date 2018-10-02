using System;
using System.Collections.Generic;
using System.Linq;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeySerializers;

namespace KamiSama.SecureModule.KeyStores.InMemory
{
	public class InMemoryKeyStore<_KeyType> : KeyStoreBase<_KeyType>
		where _KeyType : class, IKey
	{
		protected internal List<InMemoryKeyRecord<_KeyType>> Keys { get; }
		private IKeySerializer<_KeyType> keySerialier;
		private IKeyFactory<_KeyType> keyFactory;

		public InMemoryKeyStore(
			ISecureModule<_KeyType> securityModule,
			IKeySerializer<_KeyType> keySerializer,
			IKeyFactory<_KeyType> keyFactory)
			: base(securityModule)
		{
			this.Keys = new List<InMemoryKeyRecord<_KeyType>>();
			this.keySerialier = keySerializer;
			this.keyFactory = keyFactory;
		}
		public override _KeyType[] FindKeys(KeySearchProperties keySearchProperties)
		{
			IEnumerable<InMemoryKeyRecord<_KeyType>> result = Keys;

			if (keySearchProperties == null)
				throw new Exception($"KeySearchProperties object is null.");

			if (keySearchProperties.Name != null)
				result = result.Where(x => x.Name.ToLower() == keySearchProperties.Name.ToLower());
			if (keySearchProperties.Group != null)
				result = result.Where(x => x?.Group.ToLower() == keySearchProperties.Group.ToLower());
			if (keySearchProperties.Algorithm != null)
				result = result.Where(x => x.Algorithm == keySearchProperties.Algorithm);

			return result.Select(x => x.Key).ToArray();
		}
		public override _KeyType FindKey(KeySearchProperties keySearchProperties)
		{
			var result = FindKeys(keySearchProperties);

			if (result.Length == 0)
				return default(_KeyType);

			if (result.Length > 1)
				throw new Exception($"More than one key is found.");

			return result[0];
		}
		public override byte[] ExportKey(_KeyType key, ExportKeyProperties exportKeyProperties)
		{
			if (exportKeyProperties == null)
				throw new Exception($"Export properties is null.");
			if (key == null)
				throw new Exception($"key is null.");

			byte[] keyBlob;

			switch (exportKeyProperties.KeyBlobType)
			{
				default:
				case KeyBlobType.SimpleBlob:
					keyBlob = keySerialier.SerializeKey(key);
					break;
				case KeyBlobType.RawKeyData:
					throw new NotSupportedException($"Currently it is not supported.");
			}


			if (exportKeyProperties.ParentKey != null)
				keyBlob = SecureModule.Encrypt(exportKeyProperties.ParentKey, keyBlob, padding: exportKeyProperties.KeyBlobPaddingMode, cipherMode: exportKeyProperties.KeyBlobCipherMode);


			return keyBlob;
		}
		public override _KeyType ImportKey(byte[] keyBlob, ImportKeyProperties importKeyProperties)
		{
			if (importKeyProperties == null)
				throw new Exception($"Export properties is null.");
			if (importKeyProperties.Name == null)
				throw new Exception($"Key name cannot be null.");


			if (importKeyProperties.ParentKey != null)
				keyBlob = SecureModule.Decrypt(importKeyProperties.ParentKey, keyBlob, padding: importKeyProperties.KeyBlobPaddingMode, cipherMode: importKeyProperties.KeyBlobCipherMode);
			_KeyType key;

			switch (importKeyProperties.KeyBlobType)
			{
				default:
				case KeyBlobType.SimpleBlob:
					key = keySerialier.DeserializeKey(keyBlob);
					break;
				case KeyBlobType.RawKeyData:
					key = keyFactory.CreateKeyFrom(importKeyProperties.Algorithm, keyBlob);
					break;
			}

			var record = Keys.FirstOrDefault(x => x.Name.ToLower() == importKeyProperties.Name.ToLower());

			if (importKeyProperties.ImportKeyStoreType == ImportKeyStoreType.ImportButNotStore)
				return key;

			if (record != null)
				if (importKeyProperties.ImportKeyStoreType == ImportKeyStoreType.OverwriteExisting)
				{
					record.Algorithm = importKeyProperties.Algorithm;
					record.Group = importKeyProperties.Group;
					record.Name = importKeyProperties.Name;
					record.Key = key;
				}
				else
					throw new Exception($"Key with name {importKeyProperties.Name} already exists.");
			else
				Keys.Add(new InMemoryKeyRecord<_KeyType>
				{
					Algorithm = importKeyProperties.Algorithm,
					Group = importKeyProperties.Group,
					Name = importKeyProperties.Name,
					Key = key,
				});

			return key;
		}

		public override void DeleteKey(_KeyType key)
		{
			var record = Keys.FirstOrDefault(x => object.ReferenceEquals(key, x.Key));

			if (record == null)
				throw new Exception($"key is not found.");

			Keys.Remove(record);
		}
		public override void InjectKey(_KeyType key, KeyInjectionProperties keyInjectionProperties)
		{
			if (keyInjectionProperties == null)
				throw new Exception($"KeyInjectionProperties object is null.");

			if (keyInjectionProperties.Name == null)
				throw new Exception($"Key name cannot be null.");

			if (FindKey(new KeySearchProperties { Name = keyInjectionProperties.Name }) != null)
				throw new Exception($"Key already exists.");

			var record = new InMemoryKeyRecord<_KeyType>
			{
				Algorithm = keyInjectionProperties.Algorithm,
				Name = keyInjectionProperties.Name,
				Group = keyInjectionProperties.Group,
				Key = key
			};

			Keys.Add(record);
		}

		public override string[] ListKeyNames(KeySearchProperties keySearchProperties)
		{
			IEnumerable<InMemoryKeyRecord<_KeyType>> result = Keys;

			if (keySearchProperties == null)
				throw new Exception($"KeySearchProperties object is null.");

			if (keySearchProperties.Name != null)
				result = result.Where(x => x.Name.ToLower() == keySearchProperties.Name.ToLower());
			if (keySearchProperties.Group != null)
				result = result.Where(x => x?.Group.ToLower() == keySearchProperties.Group.ToLower());
			if (keySearchProperties.Algorithm != null)
				result = result.Where(x => x.Algorithm == keySearchProperties.Algorithm);

			return result.Select(x => x.Name).ToArray();
		}
	}
}
