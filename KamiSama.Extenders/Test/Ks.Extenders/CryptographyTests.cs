using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Properties;

namespace Test.Ks.Extenders
{
	[TestClass]
	[TestCategory("KS.Ex.Cryptography")]
	[ExcludeFromCodeCoverage]
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

			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.DesDecrypt(key,  cipherMode: CipherMode.CBC, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);
			
			var sign = data.DesSign(key);

			AssertEx.AreEqual("9FBC1B9AC763E51B".FromHex(), sign);
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
			
			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.TripleDesDecrypt(key, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);

			var sign = data.TripleDesSign(key);

			AssertEx.AreEqual("B17312AA9D593ABC".FromHex(), sign);
		}
		[TestMethod]
		public void AesTest()
		{
			var data = "01020304050607080102030405060708090A".FromHex();
			var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

			data = data.Pad(len => len % 16 == 0);

			var encrypted = data
				.AesEncrypt(key, padding: PaddingMode.Zeros);

			var result = "8610E13D3226A4B578107EAAAEA9F730EE6E65D03AFB0C94719FDF414D78BAFA".FromHex();

			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.AesDecrypt(key, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);

			var sign = data.AesSign(key);

			AssertEx.AreEqual("EE6E65D03AFB0C94719FDF414D78BAFA".FromHex(), sign);
		}
		[TestMethod]
		public void RsaTest()
		{
			var key = Resources.RsaKey;
			var data = "Salaam".ToBytes();
			var encrypted = data.RsaEncrypt(key, RSAEncryptionPadding.Pkcs1);
			var decrypted = encrypted
				.RsaDecrypt(key, RSAEncryptionPadding.Pkcs1)
				.GetString();
		}
	}
}
