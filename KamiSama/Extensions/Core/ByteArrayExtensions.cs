using System;
using System.Linq;
using System.Text;

namespace KamiSama.Extensions
{
	public static class ByteArrayExtensions
	{
		public static string ToHex(this byte[] arr, string separator = null)
			=> string.Join(separator ?? "", arr.Select(x => x.ToString("X2")));

		public static string GetString(this byte[] arr, Encoding encoding = null)
			=> (encoding ?? Encoding.UTF8).GetString(arr);

		public static string ToBase64(this byte[] arr)
			=> Convert.ToBase64String(arr);


	}
}