using KamiSama.Extensions.Core.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace KamiSama.Extensions.Core.Tests
{
	[TestClass]
	public class CryptographyTests
	{
		[TestMethod]
		public void DesTest()
		{
			var data = "01020304050607080102030405060708090A".FromHex();
			var key = "0001020304050607".FromHex();

			data = data.Pad(len => len % 8 == 0);

			var encrypted = data
				.DesEncrypt(key, cipherMode: CipherMode.CBC, padding: PaddingMode.Zeros);

			var result = "6ACC204F8EFBCCC7A2099E1EEB445D9A9FBC1B9AC763E51B".FromHex();

			CollectionAssert.AreEqual(result, encrypted);

			var decrypted = result
				.DesDecrypt(key,  cipherMode: CipherMode.CBC, padding: PaddingMode.None);

			CollectionAssert.AreEqual(data, decrypted);
			
			var sign = data.DesSign(key);

			CollectionAssert.AreEqual("9FBC1B9AC763E51B".FromHex(), sign);
		}
		[TestMethod]
		public void TripleDesTest()
		{
			var data = "01020304050607080102030405060708090A".FromHex();
			var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

			data = data.Pad(len => len % 8 == 0);

			var encrypted = data
				.TripleDesEncrypt(key, padding: PaddingMode.Zeros, cipherMode: CipherMode.CBC);
			var result = "8E86D9125D3E07413286D13A197DCDD2B17312AA9D593ABC".FromHex();

			CollectionAssert.AreEqual(result, encrypted);

			var decrypted = result
				.TripleDesDecrypt(key, padding: PaddingMode.None);

			CollectionAssert.AreEqual(data, decrypted);

			var sign = data.TripleDesSign(key);

			CollectionAssert.AreEqual("B17312AA9D593ABC".FromHex(), sign);
		}
		[TestMethod]
		public void AesTest()
		{
			var data = "01020304050607080102030405060708090A".FromHex();
			var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

			data = data.Pad(len => len % 16 == 0);

			var encrypted = data
				.AesEncrypt(key, padding: PaddingMode.Zeros);

			var result = "E30F86A64FD1BD77137E07DBE1E592583975CD440B3B29B608E9F56EFB779DA0".FromHex();

			CollectionAssert.AreEqual(result, encrypted);

			var decrypted = encrypted
				.AesDecrypt(key, padding: PaddingMode.None);

			CollectionAssert.AreEqual(data, decrypted);

			var sign = data.AesSign(key);

			CollectionAssert.AreEqual("3975CD440B3B29B608E9F56EFB779DA0".FromHex(), sign);
		}
		[TestMethod]
		public void RsaTest()
		{
			var key = Resources.RsaKey;
			var data = "Salaam".ToBytes();
			var encrypted = data.RsaEncrypt(key, RSAEncryptionPadding.Pkcs1);
			var decrypted = encrypted.RsaDecrypt(key, RSAEncryptionPadding.Pkcs1);

			CollectionAssert.AreEqual(data, decrypted);
		}
	}
}
