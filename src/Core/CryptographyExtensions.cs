namespace KamiSama.Extensions;

/// <summary>
/// Provides byte-array encryption, decryption, and CBC-based authentication helpers for symmetric algorithms, plus RSA encryption and decryption.
/// Legacy algorithms are included for interoperability; prefer modern authenticated encryption for new designs.
/// </summary>
public static class CryptographyExtensions
{
	#region Generic Encryption/Decryption
	/// <summary>
	/// Encrypts data using the configured symmetric algorithm.
	/// </summary>
	/// <param name="data">the byte data to be encrypted</param>
	/// <param name="algorithm">the encryption algorithm</param>
	/// <returns>the cipher byte array</returns>
	public static byte[] Encrypt(this byte[] data, SymmetricAlgorithm algorithm)
	{
		using var memoryStream = new MemoryStream();
		
		using var transform = algorithm.CreateEncryptor();

		using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
		{
			cryptoStream.Write(data, 0, data.Length);
		}
		return memoryStream.ToArray();
	}
	/// <summary>
	/// Configures a symmetric algorithm from the supplied factory and encrypts the data.
	/// </summary>
	/// <param name="data">the byte data to be encrypted</param>
	/// <param name="algorithmFactory">the function to generate symmetric algorithm</param>
	/// <param name="key">the algorithm's key</param>
	/// <param name="iv">initial value, default is zero vector</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] Encrypt(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
	{
		using var algorithm = algorithmFactory();
		
		algorithm.Key = key;
		algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
		algorithm.Padding = padding;
		algorithm.Mode = cipherMode;

		return data.Encrypt(algorithm);
	}
	/// <summary>
	/// Decrypts ciphertext using the configured symmetric algorithm.
	/// </summary>
	/// <param name="cipher">the cipher data</param>
	/// <param name="algorithm">the decryption algorithm</param>
	/// <returns></returns>
	public static byte[] Decrypt(this byte[] cipher, SymmetricAlgorithm algorithm)
	{
		using var memoryStream = new MemoryStream();

		using var transform = algorithm.CreateDecryptor();
		
		using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
		{
			cryptoStream.Write(cipher, 0, cipher.Length);
		}

		return memoryStream.ToArray();
	}
	/// <summary>
	/// Configures a symmetric algorithm from the supplied factory and decrypts the ciphertext.
	/// </summary>
	/// <param name="cipher">the cipher data</param>
	/// <param name="algorithmFactory">the function to generate symmetric algorithm</param>
	/// <param name="key">the algorithm's key</param>
	/// <param name="iv">initial value, default is zero vector</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] Decrypt(this byte[] cipher, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
	{
		using var algorithm = algorithmFactory();
		
		algorithm.Key = key;
		algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
		algorithm.Padding = padding;
		algorithm.Mode = cipherMode;
		
		return cipher.Decrypt(algorithm);
	}
	/// <summary>
	/// Computes a CBC-based message authentication value and returns the final encrypted block.
	/// </summary>
	/// <param name="data">the byte data to be signed</param>
	/// <param name="algorithm">the signing algorithm</param>
	/// <returns></returns>
	public static byte[] Sign(this byte[] data, SymmetricAlgorithm algorithm)
	{
		var cipher = data.Encrypt(algorithm);
		var blockSize = algorithm.BlockSize / 8;

		byte[] result = new byte[blockSize];

		Array.Copy(cipher, cipher.Length - blockSize, result, 0, blockSize);

		return result;
	}
	/// <summary>
	/// Computes a CBC-based message authentication value with the configured symmetric algorithm and returns the final encrypted block.
	/// </summary>
	/// <param name="data">the byte data to be signed</param>
	/// <param name="algorithmFactory">the function to generate symmetric algorithm</param>
	/// <param name="key">the algorithm's key</param>
	/// <param name="iv">initial value, default is zero vector</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] Sign(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros)
	{
		using var algorithm = algorithmFactory();
		
		algorithm.Key = key;
		algorithm.IV = iv ?? new byte[algorithm.BlockSize / 8];
		algorithm.Padding = padding;
		algorithm.Mode = CipherMode.CBC;

		return data.Sign(algorithm);
	}
	#endregion
	#region DES
	/// <summary>
	/// Encrypts using DES algorithm
	/// </summary>
	/// <param name="data">data to be encrypted</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] DesEncrypt(this byte[] data, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> data.Encrypt(DES.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Decrypts cipher data using DES algorithm
	/// </summary>
	/// <param name="cipher">Ciphertext to be decrypted.</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] DesDecrypt(this byte[] cipher, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> cipher.Decrypt(DES.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Computes a DES CBC-based message authentication value and returns the final encrypted block.
	/// </summary>
	/// <param name="data">the byte data to be signed</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] DesSign(this byte[] data, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros)
		=> data.Sign(DES.Create, key, iv, padding);
	#endregion
	#region TripleDES
	/// <summary>
	/// Encrypts using Triple DES (3DES) algorithm
	/// </summary>
	/// <param name="data">data to be encrypted</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] TripleDesEncrypt(this byte[] data, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> data.Encrypt(TripleDES.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Decrypts cipher data using Triple DES (3DES) algorithm
	/// </summary>
	/// <param name="cipher">Ciphertext to be decrypted.</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] TripleDesDecrypt(this byte[] cipher, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> cipher.Decrypt(TripleDES.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Computes a Triple DES CBC-based message authentication value and returns the final encrypted block.
	/// </summary>
	/// <param name="data">the byte data to be signed</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] TripleDesSign(this byte[] data, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros)
		=> data.Sign(TripleDES.Create, key, iv, padding);
	#endregion
	#region AES
	/// <summary>
	/// Encrypts using AES algorithm
	/// </summary>
	/// <param name="data">data to be encrypted</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] AesEncrypt(this byte[] data, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> data.Encrypt(Aes.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Decrypts cipher data using AES algorithm
	/// </summary>
	/// <param name="cipher">Ciphertext to be decrypted.</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="cipherMode">Cipher mode, such as CBC, ECB, or CFB.</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] AesDecrypt(this byte[] cipher, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
		=> cipher.Decrypt(Aes.Create, key, iv, cipherMode, padding);
	/// <summary>
	/// Computes an AES CBC-based message authentication value and returns the final encrypted block.
	/// </summary>
	/// <param name="data">the byte data to be signed</param>
	/// <param name="key">the encryption key</param>
	/// <param name="iv">initial value</param>
	/// <param name="padding">Padding mode, such as None, Zeros, or PKCS7.</param>
	/// <returns></returns>
	public static byte[] AesSign(this byte[] data, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros)
		=> data.Sign(Aes.Create, key, iv, padding);
	#endregion
	#region RSA
	/// <summary>
	/// Encrypts data using an RSA public key represented as XML.
	/// </summary>
	/// <param name="data">data to be encrypted</param>
	/// <param name="xmlKey">XML key used for encryption</param>
	/// <param name="padding">padding mode</param>
	/// <returns></returns>
	public static byte[] RsaEncrypt(this byte[] data, string xmlKey, RSAEncryptionPadding padding)
	{
		using var algorithm = RSA.Create();
		
		algorithm.FromXmlString(xmlKey);
		
		return algorithm.Encrypt(data, padding);
	}
	/// <summary>
	/// Decrypts ciphertext using an RSA private key represented as XML.
	/// </summary>
	/// <param name="cipher">Ciphertext to be decrypted.</param>
	/// <param name="xmlKey">XML key containing the private key material used for decryption.</param>
	/// <param name="padding">padding mode</param>
	/// <returns></returns>
	public static byte[] RsaDecrypt(this byte[] cipher, string xmlKey, RSAEncryptionPadding padding)
	{
		using var algorithm = RSA.Create();
		
		algorithm.FromXmlString(xmlKey);

		return algorithm.Decrypt(cipher, padding);
	}
	#endregion
}
