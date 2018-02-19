using System.Security.Cryptography;
using System.Text;
using static System.Security.Cryptography.SHA1;

namespace KamiSama.Extenders
{
	public static class HashExtender
	{
		private static readonly MD5 md5 = MD5.Create();
		private static readonly SHA1 sha1 = Create();

		#region Generic Hashing
		public static byte[] ComputeHash(this byte[] data, HashAlgorithm algorithm)
			=> algorithm.ComputeHash(data);

		public static string ComputeHashHex(this byte[] data, HashAlgorithm algorithm)
			=> data.ComputeHash(algorithm).ToHex();

		public static byte[] ComputeHash(this string data, HashAlgorithm algorithm, Encoding encoding = null)
			=> data.ToBytes(encoding ?? Encoding.UTF8).ComputeHash(algorithm);

		public static string ComputeHashHex(this string data, HashAlgorithm algorithm, Encoding encoding = null)
			=> data.ToBytes(encoding ?? Encoding.UTF8).ComputeHash(algorithm).ToHex();
		#endregion

		#region MD5

		public static byte[] GetMd5(this byte[] data)
			=> data.ComputeHash(md5);

		public static string GetMd5Hex(this byte[] data)
			=> data.ComputeHashHex(md5);

		public static byte[] GetMd5(this string data, Encoding encoding = null)
			=> data.ComputeHash(md5, encoding);

		public static string GetMd5Hex(this string data, Encoding encoding = null)
			=> data.ComputeHashHex(md5, encoding);
		#endregion
		#region Sha1

		public static byte[] GetSha1(this byte[] data)
			=> data.ComputeHash(sha1);

		public static string GetSha1Hex(this byte[] data)
			=> data.ComputeHashHex(sha1);

		public static byte[] GetSha1(this string data, Encoding encoding = null)
			=> data.ComputeHash(sha1, encoding);

		public static string GetSha1Hex(this string data, Encoding encoding = null)
			=> data.ComputeHashHex(sha1, encoding);
		#endregion
	}
}
