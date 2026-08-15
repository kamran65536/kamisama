namespace KamiSama.Extensions;

/// <summary>
/// Provides hash-computation helpers for byte arrays and strings, including hexadecimal MD5 and SHA-1 output.
/// Prefer a modern hash algorithm for new security-sensitive applications.
/// </summary>
public static class HashExtensions
{
	private static readonly MD5 md5 = MD5.Create();
	private static readonly SHA1 sha1 = SHA1.Create();

	#region Generic Hashing
	/// <summary>
	/// Computes the hash of the byte array using the specified algorithm.
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <returns></returns>
	public static byte[] ComputeHash(this byte[] data, HashAlgorithm algorithm)
		=> algorithm.ComputeHash(data);
	/// <summary>
	/// Computes the hash of the byte array and returns it as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <returns>hexadecimal hashed data</returns>
	public static string ComputeHashHex(this byte[] data, HashAlgorithm algorithm)
		=> data.ComputeHash(algorithm).ToHex();
	/// <summary>
	/// Encodes the string and computes its hash using the specified algorithm.
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] ComputeHash(this string data, HashAlgorithm algorithm, Encoding? encoding = null)
		=> data.ToBytes(encoding ?? Encoding.UTF8).ComputeHash(algorithm);
	/// <summary>
	/// Encodes the string, computes its hash, and returns the result as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns>hexadecimal hashed data</returns>
	public static string ComputeHashHex(this string data, HashAlgorithm algorithm, Encoding? encoding = null)
		=> data.ToBytes(encoding ?? Encoding.UTF8).ComputeHash(algorithm).ToHex();
	#endregion
	#region MD5
	/// <summary>
	/// Computes the MD5 hash of the byte array.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static byte[] GetMd5(this byte[] data)
		=> data.ComputeHash(md5);
	/// <summary>
	/// Computes the MD5 hash of the byte array and returns it as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static string GetMd5Hex(this byte[] data)
		=> data.ComputeHashHex(md5);
	/// <summary>
	/// Encodes the string and computes its MD5 hash.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] GetMd5(this string data, Encoding? encoding = null)
		=> data.ComputeHash(md5, encoding);
	/// <summary>
	/// Encodes the string and returns its MD5 hash as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static string GetMd5Hex(this string data, Encoding? encoding = null)
		=> data.ComputeHashHex(md5, encoding);
	#endregion
	#region Sha1
	/// <summary>
	/// Computes the SHA-1 hash of the byte array.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static byte[] GetSha1(this byte[] data)
		=> data.ComputeHash(sha1);
	/// <summary>
	/// Computes the SHA-1 hash of the byte array and returns it as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	public static string GetSha1Hex(this byte[] data)
		=> data.ComputeHashHex(sha1);
	/// <summary>
	/// Encodes the string and computes its SHA-1 hash.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] GetSha1(this string data, Encoding? encoding = null)
		=> data.ComputeHash(sha1, encoding);
	/// <summary>
	/// Encodes the string and returns its SHA-1 hash as an uppercase hexadecimal string.
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static string GetSha1Hex(this string data, Encoding? encoding = null)
		=> data.ComputeHashHex(sha1, encoding);
	#endregion
}
