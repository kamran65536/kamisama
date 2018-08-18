using System;
using System.Collections.Generic;
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
	[TestCategory("KS.SecureModule.KeyStores.InMemoryKeyStore")]
	[TestClass]
	public class InMemoryKeyStoreTests
	{
		private LocalSoftwareSecureModule ssm;
		private InMemoryKeyStore<SsmKey> keyStore;

		public InMemoryKeyStoreTests()
		{
			ssm = new LocalSoftwareSecureModule(new LocalSsmSettings
			{
				MasterKey = "6DC9E96A273CAFF2543B706011161E39".FromHex(),
				MasterKeyAlgorithm = Algorithm.Aes
			});
			keyStore = new InMemoryKeyStore<SsmKey>(ssm, new BsonKeySerializer<SsmKey>(), new SsmKeyFactory());
		}
		[TestMethod]
		public void FindKeys_must_return_keys_based_on_Group()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key2", Group = "G" });

			var keys = keyStore.FindKeys(new KeySearchProperties { Group = "G" });

			Assert.AreEqual(2, keys.Length);
			Assert.IsTrue(keys.Contains(k1));
			Assert.IsTrue(keys.Contains(k2));

			keyStore.DeleteKey(k1);
			keyStore.DeleteKey(k2);
		}
		[TestMethod]
		public void FindKeys_must_return_keys_based_on_Name()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key2", Group = "G" });

			var keys = keyStore.FindKeys(new KeySearchProperties { Name = "key1" });

			Assert.AreEqual(1, keys.Length);
			Assert.IsTrue(keys.Contains(k1));

			keyStore.DeleteKey(k1);
			keyStore.DeleteKey(k2);
		}
		[TestMethod]
		public void FindKeys_must_return_keys_based_on_Algorithm()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int) Algorithm.Aes,
				Name = "key1",
				Group = "G"
			});
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int)Algorithm.TripleDes,
				Name = "key2",
				Group = "G"
			});

			var keys = keyStore.FindKeys(new KeySearchProperties { Algorithm = (int) Algorithm.Aes });
			
			Assert.AreEqual(1, keys.Length);
			Assert.IsTrue(keys.Contains(k1));

			keyStore.DeleteKey(k1);
			keyStore.DeleteKey(k2);
		}
		[TestMethod]
		public void FindKeys_must_throw_Exception_on_null_KeySearchProperties()
		{
			Assert.ThrowsException<Exception>(() => keyStore.FindKeys(null));
		}
		[TestMethod]
		public void FindKey_must_return_the_key_based_on_Group()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key2", Group = "G2" });

			var key = keyStore.FindKey(new KeySearchProperties { Group = "G" });

			Assert.AreEqual(key, k1);

			keyStore.DeleteKey(k1);
		}
		[TestMethod]
		public void FindKey_must_return_the_key_based_on_Name()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key1", Group = "G" });
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties { ImportKeyStoreType = ImportKeyStoreType.ImportAndStore, Name = "key2", Group = "G2" });

			var key = keyStore.FindKey(new KeySearchProperties { Name = "key1" });

			Assert.AreEqual(key, k1);

			keyStore.DeleteKey(k1);
		}
		[TestMethod]
		public void FindKey_must_return_the_key_based_on_Algorithm()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int)Algorithm.Aes,
				Name = "key1",
				Group = "G"
			});
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int)Algorithm.TripleDes,
				Name = "key2",
				Group = "G"
			});
			var key = keyStore.FindKey(new KeySearchProperties { Algorithm = (int) Algorithm.Aes });

			Assert.AreEqual(key, k1);

			keyStore.DeleteKey(k1);
		}
		[TestMethod]
		public void FindKey_must_throw_Exception_on_multiple_results_found()
		{
			var keyData = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var k1 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int)Algorithm.Aes,
				Name = "key1",
				Group = "G"
			});
			var k2 = keyStore.ImportKey(keyData, new ImportKeyProperties
			{
				ImportKeyStoreType = ImportKeyStoreType.ImportAndStore,
				Algorithm = (int)Algorithm.TripleDes,
				Name = "key2",
				Group = "G"
			});
			Assert.ThrowsException<Exception>(() => keyStore.FindKey(new KeySearchProperties { Group = "G" }));

			keyStore.DeleteKey(k1);
		}
		[TestMethod]
		public void FindKey_must_return_null_if_nothing_is_found()
		{
			Assert.IsNull(keyStore.FindKey(new KeySearchProperties()));
		}
	}
}
