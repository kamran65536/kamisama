namespace KamiSama.Extensions;

/// <summary>
/// Byte Array Extensions
/// </summary>
public static class ByteArrayExtensions
{
	/// <summary>
	/// converts an byte array to hexadecimal string
	/// </summary>
	/// <param name="arr">the byte array to be converted to hex</param>
	/// <param name="separator">the separator to be used between hexadecimal digits</param>
	/// <returns></returns>
	public static string ToHex(this byte[] arr, string? separator = null)
		=> string.Join(separator ?? "", arr.Select(x => x.ToString("X2")));
	/// <summary>
	/// converts an byte array to string using the specified encoding
	/// </summary>
	/// <param name="arr">the byte array to be decoded to string</param>
	/// <param name="encoding">the encoding, null means default encoding (Encoding.UTF8) </param>
	/// <returns></returns>
	public static string GetString(this byte[] arr, Encoding? encoding = null)
		=> (encoding ?? Encoding.UTF8).GetString(arr);
	/// <summary>
	/// converts an byte array to base 64 string
	/// </summary>
	/// <param name="arr">the byte array to be converted to base 64</param>
	/// <returns></returns>
	public static string ToBase64(this byte[] arr)
		=> Convert.ToBase64String(arr);
}