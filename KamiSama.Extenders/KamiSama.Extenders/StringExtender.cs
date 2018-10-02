using System;
using System.Text;

namespace KamiSama.Extenders
{
	public static class StringExtender
	{
		public static byte[] ToBytes(this string str, Encoding encoding = null)
			=> (encoding ?? Encoding.UTF8).GetBytes(str ?? "");

		public static byte[] FromHex(this string hex)
		{
			var org = hex;
			try
			{
				hex = (hex ?? "")
				.Replace(" ", "")
				.Replace("\t", "")
				.Replace("\r", "")
				.Replace("\n", "");

				if (hex.Length % 2 != 0)
					hex = "0" + hex;

				var result = new byte[hex.Length / 2];

				for (int i = 0; i < result.Length; i++)
					result[i] = Convert.ToByte(hex.Substring(2 * i, 2), 16);

				return result;
			}
			catch
			{
				throw new Exception($"Invalid hex string: {org}");
			}
		}

		public static byte[] FromBase64(this string base64)
			=> Convert.FromBase64String(base64);
	}
}
