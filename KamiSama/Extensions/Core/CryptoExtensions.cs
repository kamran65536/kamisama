using System;
using System.IO;
using System.Security.Cryptography;

namespace KamiSama.Extensions
{
	public static class CryptoExtensions
	{
		#region Generic Encryption/Decryption
		public static byte[] Encrypt(this byte[] data, SymmetricAlgorithm algorithm)
		{
			using (var memoryStream = new MemoryStream())
			{
				using (var transform = algorithm.CreateEncryptor())
				{
					using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(data, 0, data.Length);
					}
					return memoryStream.ToArray();
				}
			}
		}
		public static byte[] Encrypt(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			using (var algorithm = algorithmFactory())
			{
				algorithm.Key = key;
				algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
				algorithm.Padding = padding;
				algorithm.Mode = cipherMode;

				return data.Encrypt(algorithm);
			}
		}
		public static byte[] Decrypt(this byte[] cipher, SymmetricAlgorithm algorithm)
		{
			using (var memoryStream = new MemoryStream())
			{
				using (var transform = algorithm.CreateDecryptor())
				{
					using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(cipher, 0, cipher.Length);
					}

					return memoryStream.ToArray();
				}
			}
		}
		public static byte[] Decrypt(this byte[] cipher, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			using (var algorithm = algorithmFactory())
			{
				algorithm.Key = key;
				algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
				algorithm.Padding = padding;
				algorithm.Mode = cipherMode;
				return cipher.Decrypt(algorithm);
			}
		}
		public static byte[] Sign(this byte[] data, SymmetricAlgorithm algorithm)
		{
			var cipher = data.Encrypt(algorithm);
			var blockSize = algorithm.BlockSize / 8;

			byte[] result = new byte[blockSize];

			Array.Copy(cipher, cipher.Length - blockSize, result, 0, blockSize);

			return result;
		}
		public static byte[] Sign(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[] iv = null, PaddingMode padding = PaddingMode.Zeros)
		{
			using (var algorithm = algorithmFactory())
			{
				algorithm.Key = key;
				algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
				algorithm.Padding = padding;
				algorithm.Mode = CipherMode.CBC;

				return data.Sign(algorithm);
			}
		}
		#endregion
		#region DES
		public static byte[] DesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(DES.Create, key, iv, cipherMode, padding);
		public static byte[] DesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(DES.Create, key, iv, cipherMode, padding);
		public static byte[] DesSign(this byte[] data, byte[] key, byte[] iv = null, PaddingMode padding = PaddingMode.Zeros)
			=> data.Sign(DES.Create, key, iv, padding);
		#endregion
		#region TripleDES
		public static byte[] TripleDesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(TripleDES.Create, key, iv, cipherMode, padding);
		public static byte[] TripleDesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(TripleDES.Create, key, iv, cipherMode, padding);
		public static byte[] TripleDesSign(this byte[] data, byte[] key, byte[] iv = null, PaddingMode padding = PaddingMode.Zeros)
			=> data.Sign(TripleDES.Create, key, iv, padding);
		#endregion
		#region AES
		public static byte[] AesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(Aes.Create, key, iv, cipherMode, padding);
		public static byte[] AesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(Aes.Create, key, iv, cipherMode, padding);
		public static byte[] AesSign(this byte[] data, byte[] key, byte[] iv = null, PaddingMode padding = PaddingMode.Zeros)
			=> data.Sign(Aes.Create, key, iv, padding);
		#endregion
		#region RSA
		public static byte[] RsaEncrypt(this byte[] data, string xmlKey, RSAEncryptionPadding padding)
		{
			using (var algorithm = RSA.Create())
			{
				algorithm.FromXmlString(xmlKey);
				return algorithm.Encrypt(data, padding);
			}
		}
		public static byte[] RsaDecrypt(this byte[] data, string xmlKey, RSAEncryptionPadding padding)
		{
			using (var algorithm = RSA.Create())
			{
				algorithm.FromXmlString(xmlKey);

				return algorithm.Decrypt(data, padding);
			}
		}
		#endregion
	}
}
