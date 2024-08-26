namespace KamiSama.Extensions;

/// <summary>
/// Hashing Extensions
/// </summary>
public static class HashExtensions
{
	private static readonly MD5 md5 = MD5.Create();
	private static readonly SHA1 sha1 = SHA1.Create();

	#region Generic Hashing
	/// <summary>
	/// Computes hash for an hashing algorithm
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <returns></returns>
	public static byte[] ComputeHash(this byte[] data, HashAlgorithm algorithm)
		=> algorithm.ComputeHash(data);
	/// <summary>
	/// Computes hash and then converts it to hexadecimal
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <returns>hexadecimal hashed data</returns>
	public static string ComputeHashHex(this byte[] data, HashAlgorithm algorithm)
		=> data.ComputeHash(algorithm).ToHex();
	/// <summary>
	/// Computes hash for byte array equivalent string data
	/// </summary>
	/// <param name="data">the data to be hashed</param>
	/// <param name="algorithm">the hashing algorithm</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] ComputeHash(this string data, HashAlgorithm algorithm, Encoding? encoding = null)
		=> data.ToBytes(encoding ?? Encoding.UTF8).ComputeHash(algorithm);
	/// <summary>
	/// Computes hash for byte array equivalent string data and then converts it to hexadecimal
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
	/// returns MD5 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static byte[] GetMd5(this byte[] data)
		=> data.ComputeHash(md5);
	/// <summary>
	/// returns MD5 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static string GetMd5Hex(this byte[] data)
		=> data.ComputeHashHex(md5);
	/// <summary>
	/// returns MD5 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] GetMd5(this string data, Encoding? encoding = null)
		=> data.ComputeHash(md5, encoding);
	/// <summary>
	/// returns MD5 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static string GetMd5Hex(this string data, Encoding? encoding = null)
		=> data.ComputeHashHex(md5, encoding);
	#endregion
	#region Sha1
	/// <summary>
	/// returns SHA1 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <returns></returns>
	public static byte[] GetSha1(this byte[] data)
		=> data.ComputeHash(sha1);
	/// <summary>
	/// returns SHA1 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	public static string GetSha1Hex(this byte[] data)
		=> data.ComputeHashHex(sha1);
	/// <summary>
	/// returns SHA1 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static byte[] GetSha1(this string data, Encoding? encoding = null)
		=> data.ComputeHash(sha1, encoding);
	/// <summary>
	/// returns SHA1 hash for data
	/// </summary>
	/// <param name="data">data to be hashed</param>
	/// <param name="encoding">encoding used to convert string to byte array, default is UTF8</param>
	/// <returns></returns>
	public static string GetSha1Hex(this string data, Encoding? encoding = null)
		=> data.ComputeHashHex(sha1, encoding);
	#endregion
}
