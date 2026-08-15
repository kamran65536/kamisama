namespace KamiSama.Extensions;

/// <summary>
/// Provides extension methods for converting byte arrays to text, hexadecimal strings, and Base64 strings.
/// Use them to prepare binary data for display, storage, or transport.
/// </summary>
public static class ByteArrayExtensions
{
	/// <summary>
	/// Converts the byte array to an uppercase hexadecimal string, optionally separating each byte.
	/// </summary>
	/// <param name="arr">the byte array to be converted to hex</param>
	/// <param name="separator">the separator to be used between hexadecimal digits</param>
	/// <returns></returns>
	public static string ToHex(this byte[] arr, string? separator = null)
		=> string.Join(separator ?? "", arr.Select(x => x.ToString("X2")));
	/// <summary>
	/// Decodes the byte array using the specified encoding, or UTF-8 when no encoding is supplied.
	/// </summary>
	/// <param name="arr">the byte array to be decoded to string</param>
	/// <param name="encoding">the encoding, null means default encoding (Encoding.UTF8) </param>
	/// <returns></returns>
	public static string GetString(this byte[] arr, Encoding? encoding = null)
		=> (encoding ?? Encoding.UTF8).GetString(arr);
	/// <summary>
	/// Converts the byte array to its Base64 string representation.
	/// </summary>
	/// <param name="arr">the byte array to be converted to base 64</param>
	/// <returns></returns>
	public static string ToBase64(this byte[] arr)
		=> Convert.ToBase64String(arr);
}
