using System;
using System.IO;
using System.Security.Cryptography;

namespace KamiSama.Extenders
{
	public static class CryptoExtender
	{
		#region Generic Encryption/Decryption
		public static byte[] Encrypt(this byte[] data, SymmetricAlgorithm algorithm, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			algorithm.Key = key;
			algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
			algorithm.Mode = cipherMode;
			algorithm.Padding = padding;

			using (var memoryStream = new MemoryStream())
			{
				using (var transform = algorithm.CreateEncryptor())
				{
					
					using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(data, 0, data.Length);

						return memoryStream.ToArray();
					}
				}
			}
		}
		public static byte[] Encrypt(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			using (var algorithm = algorithmFactory())
				return data.Encrypt(algorithm, key, iv, cipherMode, padding);
		}
		public static byte[] Decrypt(this byte[] cipher, SymmetricAlgorithm algorithm, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			byte[] result = new byte[cipher.Length];

			algorithm.Key = key;
			algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
			algorithm.Mode = cipherMode;
			algorithm.Padding = padding;

			using (var memoryStream = new MemoryStream(cipher))
			{
				using (var transform = algorithm.CreateDecryptor())
				{
					using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(result, 0, cipher.Length);

						return result;
					}
				}
			}

		}
		public static byte[] Decrypt(this byte[] cipher, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		{
			using (var algorithm = algorithmFactory())
				return cipher.Decrypt(algorithm, key, iv, cipherMode, padding);
		}
		#endregion
		#region DES
		public static byte[] DesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(DES.Create, key, iv, cipherMode, padding);
		public static byte[] DesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(DES.Create, key, iv, cipherMode, padding);
		#endregion
		#region TripleDES
		public static byte[] TripleDesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(TripleDES.Create, key, iv, cipherMode, padding);
		public static byte[] TripleDesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(TripleDES.Create, key, iv, cipherMode, padding);
		#endregion
		#region AES
		public static byte[] AesEncrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Encrypt(Aes.Create, key, iv, cipherMode, padding);
		public static byte[] AesDecrypt(this byte[] data, byte[] key, byte[] iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
			=> data.Decrypt(Aes.Create, key, iv, cipherMode, padding);
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
