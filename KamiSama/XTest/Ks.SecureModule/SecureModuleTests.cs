using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using KamiSama.Configs;
using KamiSama.Extenders;
using KamiSama.SecureModule.LocalSsm;
using Xunit;


namespace XTest.Ks.SecureModule
{
	[Trait("Category", "KS.SecureModule")]
	[ExcludeFromCodeCoverage]
	public class SecureModuleTests
	{
		private LocalSoftwareSecureModule ssm;
		public SecureModuleTests()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			LocalSsmSettings.Instance.UseInMemoryPrvider(new LocalSsmSettings
			{
				MasterKey = aes.Key,
				MasterKeyAlgorithm = "aes",
			});

			ssm = new LocalSoftwareSecureModule();
		}
		[Fact(DisplayName = "Plain Key")]
		public void TestPlainKey()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			var masterKey = SsmKey.CreatePlainKey("aes", aes.Key);

			Assert.True(masterKey.IsPlainKey);
			Assert.Equal(masterKey.KeyData, aes.Key);
			Assert.Equal("aes", masterKey.Algorithm);
		}
		[Fact(DisplayName = "Clone Key")]
		public void TestCloneKey()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			var key = SsmKey.CreatePlainKey("aes", aes.Key);
			var key2 = key.Clone() as SsmKey;

			Assert.Equal(key.Algorithm, key2.Algorithm);
			Assert.Equal(key.IsPlainKey, key2.IsPlainKey);
			Assert.Equal(key.KeyData, key2.KeyData);

		}
		[Fact(DisplayName = "Plain Key")]
		public void TestEncryptedKey()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			var key = ssm.GenerateKeyObject("aes", aes.Key);

			Assert.False(key.IsPlainKey);

			var key2 = ssm.KeySerializer.DeserializeKey(ssm.KeySerializer.SerializeKey(key));

			Assert.Equal(key.Algorithm, key2.Algorithm);
			Assert.Equal(key.IsPlainKey, key2.IsPlainKey);
			Assert.Equal(key.KeyData, key2.KeyData);

		}
		[Fact(DisplayName = "Bad key")]
		public void TestBadKey()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			var key = ssm.GenerateKeyObject("aaa", aes.Key);

			var data = "Salaam".ToBytes();
			Assert.ThrowsAny<Exception>(() => ssm.Encrypt(key, data, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7));
			Assert.ThrowsAny<Exception>(() => ssm.Decrypt(key, data, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7));
			Assert.ThrowsAny<Exception>(() => ssm.GetKeyStore("InMemory").SaveKey("testbadkey", null));
			Assert.ThrowsAny<Exception>(() => ssm.GetKeyStore("InMemory").LoadKey(null));
		}

		[Fact(DisplayName = "AES encryption/decryption")]
		public void TestAes()
		{
			var aes = Aes.Create();
			aes.GenerateKey();

			var key = ssm.GenerateKeyObject("aes", aes.Key);

			var data = "Salaam".ToBytes();
			var cipher_ssm = ssm.Encrypt(key, data, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);
			var cipher_aes = data.AesEncrypt(aes.Key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			Assert.Equal(cipher_aes, cipher_ssm);

			Assert.Equal(data, ssm.Decrypt(key, cipher_ssm, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7));
		}
		[Fact(DisplayName = "DES encryption/decryption")]
		public void TestDes()
		{
			var des = DES.Create();
			des.GenerateKey();

			var key = SsmKey.CreatePlainKey("DES", des.Key);

			var data = "Salaam".ToBytes();
			var cipher_ssm = ssm.Encrypt(key, data, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);
			var cipher_des = data.DesEncrypt(des.Key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

			Assert.Equal(cipher_des, cipher_ssm);

			key = SsmKey.CreatePlainKey("Des", des.Key);

			Assert.Equal(data, ssm.Decrypt(key, cipher_ssm, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7));
		}
		[Fact(DisplayName = "Triple DES encryption/decryption")]
		public void TestTripleDes()
		{
			var tdes = TripleDES.Create();
			tdes.GenerateKey();

			var key = ssm.GenerateKeyObject("3des", tdes.Key);

			var data = "Salaam".ToBytes();
			var cipher_ssm = ssm.Encrypt(key, data, cipherMode: CipherMode.CBC, padding: PaddingMode.ANSIX923);
			var cipher_tdes = data.TripleDesEncrypt(tdes.Key, cipherMode: CipherMode.CBC, padding: PaddingMode.ANSIX923);

			Assert.Equal(cipher_tdes, cipher_ssm);
			key = ssm.GenerateKeyObject("3des", tdes.Key);

			Assert.Equal(data, ssm.Decrypt(key, cipher_ssm, cipherMode: CipherMode.CBC, padding: PaddingMode.ANSIX923));
		}
	}
}
