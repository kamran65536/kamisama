using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Extenders;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeySerializers.Bson;
using KamiSama.SecureModule.KeyStores.InMemory;
using KamiSama.SecureModule.LocalSsm;
using KamiSama.SecureModule.LocalSsm.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.KS_SecureModule_KeyStores
{
	[ExcludeFromCodeCoverage]
	[TestCategory("KS.SecureModule.KeyStoreBase")]
	[TestClass]
	public class KeyStoreBaseTests
	{
		private LocalSoftwareSecureModule ssm;
		private IKeyStore<SsmKey> genericKeyStore;
		private IKeyStore keyStore;

		public KeyStoreBaseTests()
		{
			ssm = new LocalSoftwareSecureModule(new LocalSsmSettings
			{
				MasterKey = "6DC9E96A273CAFF2543B706011161E39".FromHex(),
				MasterKeyAlgorithm = Algorithm.Aes
			});
			genericKeyStore = new InMemoryKeyStore<SsmKey>(ssm, new BsonKeySerializer<SsmKey>(), new SsmKeyFactory());
			keyStore = genericKeyStore;
		}

		[TestMethod]
		public void SecureModule_must_be_the_same_as_IKeyStore_SecureModule()
		{
			Assert.AreEqual(keyStore.SecureModule, genericKeyStore.SecureModule);
		}
		[TestMethod]
		public void ExportKey_must_do_the_same_as_IKeyStore_ExportKey()
		{
			var key = SsmKey.CreatePlainKey(Algorithm.Aes, "6DC9E96A273CAFF2543B706011161E39".FromHex());
			var result1 = genericKeyStore.ExportKey(key, new ExportKeyProperties());
			var result2 = keyStore.ExportKey(key, new ExportKeyProperties());

			Assert.AreEqual(result1.ToHex(), result2.ToHex());
		}
		[TestMethod]
		public void ImportKey_must_do_the_same_as_IKeyStore_ImportKey()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var key1 = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportButNotStore, Name = "key1" });
			var key2 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportButNotStore, Name = "key2" }) as SsmKey;

			Assert.IsNotNull(key2);
			Assert.AreEqual(key1.Algorithm, key2.Algorithm);
			Assert.AreEqual(key1.KeyData.ToHex(), key2.KeyData.ToHex());
			Assert.AreEqual(key1.IsPlainKey, key2.IsPlainKey);
		}
		[TestMethod]
		public void FindKey_must_return_the_key()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1" });

			var key1 = genericKeyStore.FindKey(new KeySearchProperties { Name = "key1" });
			var key2 = keyStore.FindKey(new KeySearchProperties { Name = "key1" }) as SsmKey;

			Assert.AreEqual(key1, key2);
		}
		[TestMethod]
		public void FindKeys_must_return_the_same_keys()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			var k2 = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key2", Group = "G" });

			var keys1 = genericKeyStore.FindKeys(new KeySearchProperties { Group = "G" });
			var keys2 = keyStore.FindKeys(new KeySearchProperties { Group = "G" }) as SsmKey[];

			keys1 = keys1.OrderBy(x => x.GetHashCode()).ToArray();
			keys2 = keys2.OrderBy(x => x.GetHashCode()).ToArray();

			Assert.AreEqual(keys1.Length, keys2.Length);
			Assert.AreEqual(keys1[0], keys2[0]);
			Assert.AreEqual(keys1[1], keys2[1]);

			genericKeyStore.DeleteKey(k1);
			genericKeyStore.DeleteKey(k2);
		}
		[TestMethod]
		public void DeleteKey_must_do_the_same_as_IKeyStore()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();
			var k = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			
			var inmemKeyStore = genericKeyStore as InMemoryKeyStore<SsmKey>;
			var record = inmemKeyStore.Keys[0];

			genericKeyStore.DeleteKey(k);

			Assert.AreEqual(0, inmemKeyStore.Keys.Count);

			inmemKeyStore.Keys.Add(record);
			keyStore.DeleteKey(k);

			Assert.AreEqual(0, inmemKeyStore.Keys.Count);
		}
		[TestMethod]
		public void InjectKey_must_do_the_same_as_IKeyStore()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();
			var key = genericKeyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportButNotStore, Name = "key1", Group = "G" });
			var inmemKeyStore = genericKeyStore as InMemoryKeyStore<SsmKey>;

			genericKeyStore.InjectKey(key, new KeyInjectionProperties { Name = "key1" });

			Assert.AreEqual(key, inmemKeyStore.Keys[0].Key);
			Assert.AreEqual("key1", inmemKeyStore.Keys[0].Name);

			inmemKeyStore.Keys.Clear();

			keyStore.InjectKey(key, new KeyInjectionProperties { Name = "key1" });

			Assert.AreEqual(key, inmemKeyStore.Keys[0].Key);
			Assert.AreEqual("key1", inmemKeyStore.Keys[0].Name);
		}
	}
}
