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
			var data = "0102030405060708090A".FromHex();
			var key = "0001020304050607".FromHex();

			data = data.Pad(len => len % 8 == 0);

			var encrypted = data
				.DesEncrypt(key, cipherMode: CipherMode.CBC, padding: PaddingMode.Zeros);

			var result = "6ACC204F8EFBCCC75FF64314F9525653".FromHex();

			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.DesDecrypt(key,  cipherMode: CipherMode.CBC, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);
		}
		[TestMethod]
		public void TripleDesTest()
		{
			var data = "0102030405060708090A".FromHex();
			var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

			data = data.Pad(len => len % 8 == 0);

			var encrypted = data
				.TripleDesEncrypt(key, padding: PaddingMode.Zeros);

			var result = "8E86D9125D3E074162590514AE98EF15".FromHex();

			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.TripleDesDecrypt(key, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);
		}
		[TestMethod]
		public void AesTest()
		{
			var data = "0102030405060708090A".FromHex();
			var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

			data = data.Pad(len => len % 8 == 0);

			var encrypted = data
				.AesEncrypt(key, padding: PaddingMode.Zeros);

			var result = "F4EF9101CA3BE93007E916A4C75CBA2B".FromHex();

			AssertEx.AreEqual(result, encrypted);

			var decrypted = result
				.AesDecrypt(key, padding: PaddingMode.None);

			AssertEx.AreEqual(data, decrypted);
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
