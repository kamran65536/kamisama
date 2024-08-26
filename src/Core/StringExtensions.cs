namespace KamiSama.Extensions;

/// <summary>
/// String Extensions
/// </summary>
public static class StringExtensions
{
	/// <summary>
	/// Converts string to byte array using specified encoding
	/// </summary>
	/// <param name="str">the string to be converted</param>
	/// <param name="encoding">encoding, default is Encoding.UTF8</param>
	/// <returns></returns>
	public static byte[] ToBytes(this string? str, Encoding? encoding = null)
		=> (encoding ?? Encoding.UTF8).GetBytes(str ?? "");
	/// <summary>
	/// Converts hexadecimal string to byte array
	/// </summary>
	/// <param name="hex">hexadecimal string</param>
	/// <returns>equivalent byte array</returns>
	public static byte[] FromHex(this string? hex)
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
	/// <summary>
	/// Converts base 64 string to byte array
	/// </summary>
	/// <param name="base64">base 64 string</param>
	/// <returns>byte array</returns>
	public static byte[] FromBase64(this string base64)
		=> Convert.FromBase64String(base64);
}
