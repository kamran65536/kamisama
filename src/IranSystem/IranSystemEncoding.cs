using System.Text;

namespace KamiSama.IranSystem;

/// <summary>
/// Provides a <see cref="Encoding" /> implementation for legacy single-byte Iran System Persian data.
/// Use its complete-buffer string methods when exchanging data with legacy Persian systems.
/// </summary>
/// <remarks>
/// Iran System stores contextual Persian glyph shapes. Decoding therefore produces Arabic presentation-form
/// characters, and encoding expects those exact presentation-form code points rather than normalized Persian text.
/// </remarks>
/// <example>
/// <code>
/// var encoding = new IranSystemEncoding();
/// string text = encoding.GetString([0x80, 0x81, 0x82]);
/// byte[] bytes = encoding.GetBytes(text);
/// </code>
/// </example>
public class IranSystemEncoding : Encoding
{
	/// <summary>
	/// mapping of bytes to char
	/// </summary>
	private static readonly char[] byteToChar;
	/// <summary>
	/// mapping of char to bytes
	/// </summary>
	private static readonly byte[][] charToByte;
	/// <summary>
	/// static constructor
	/// </summary>
	static IranSystemEncoding()
	{
		var iranSystem = new int[] { 0x06F0, 0x06F1, 0x06F2, 0x06F3, 0x06F4, 0x06F5, 0x06F6, 0x06F7, 0x06F8, 0x06F9, 0x060C, 0x0640, 0x061F, 0xFE81, 0xFE8B, 0x0621, 0xFE8D, 0xFE8E, 0xFE8F, 0xFE91, 0xFB56, 0xFB58, 0xFE95, 0xFE97, 0xFE99, 0xFE9B, 0xFE9D, 0xFE9F, 0xFB7C, 0xFB7C, 0xFEA1, 0xFEA3, 0xFEA5, 0xFEA7, 0x062F, 0x0630, 0x0631, 0x0632, 0x0698, 0xFEB1, 0xFEB3, 0xFEB5, 0xFEB7, 0xFEB9, 0xFEBB, 0xFEBD, 0xFEBF, 0x0637, 0x2591, 0x2592, 0x2593, 0x2502, 0x2524, 0x2561, 0x2562, 0x2556, 0x2555, 0x2563, 0x2551, 0x2557, 0x255D, 0x255C, 0x255B, 0x2510, 0x2514, 0x2534, 0x252C, 0x251C, 0x2500, 0x253C, 0x255E, 0x255F, 0x255A, 0x2554, 0x2569, 0x2566, 0x2560, 0x2550, 0x256C, 0x2567, 0x2568, 0x2564, 0x2565, 0x2559, 0x2558, 0x2552, 0x2553, 0x256B, 0x256A, 0x2518, 0x250C, 0x2588, 0x2584, 0x258C, 0x2590, 0x2580, 0x0638, 0xFEC9, 0xFECA, 0xFECC, 0xFECB, 0xFECD, 0xFECE, 0xFED0, 0xFECF, 0xFED1, 0xFED3, 0xFED5, 0xFED7, 0xFB8E, 0xFB90, 0xFB92, 0xFB94, 0xFEDD, 0xFEFB, 0xFEDF, 0xFEE1, 0xFEE3, 0xFEE5, 0xFEE7, 0x0648, 0xFEE9, 0xFEEC, 0xFEEB, 0xFBFD, 0xFBFC, 0xFBFE, 0x00A0 };
		byteToChar = new char[256];
		// ascii first
		for (int i = 0; i < 128; i++) byteToChar[i] = (char)i;
		// non-ascii
		for (int i = 128; i < 256; i++) byteToChar[i] = (char)iranSystem[i - 128];

		// ok now reverse
		charToByte = new byte[256][];
		for (int i = 0; i < 256; i++)
		{
			char ch = (char)byteToChar[i];
			var low = ch & 0xff;
			var high = ch >> 8 & 0xff;

			var lowCharToByte = charToByte[high];
			if (lowCharToByte == null)
			{
				lowCharToByte = new byte[256];
				charToByte[high] = lowCharToByte;
			}
			lowCharToByte[low] = (byte)(i);
		}
	}
	/// <summary>
	/// Decodes every byte in the supplied array using the Iran System byte-to-character table.
	/// Each input byte produces exactly one output character.
	/// </summary>
	/// <param name="bytes">The complete Iran System byte sequence to decode.</param>
	/// <returns>A string containing ASCII characters or the mapped Persian glyph presentation forms.</returns>
	public override string GetString(byte[] bytes)
	{
		var sb = new StringBuilder();
		foreach (var b in bytes)
		{
			sb.Append(byteToChar[b]);
		}
		return sb.ToString();
	}
	/// <summary>
	/// Encodes every character in the supplied string using the Iran System character-to-byte table.
	/// Each input character produces exactly one output byte.
	/// </summary>
	/// <param name="str">The string containing ASCII or mapped Persian presentation-form characters to encode.</param>
	/// <returns>An array containing one Iran System byte for each input character.</returns>
	/// <remarks>
	/// Characters absent from the mapping, including normalized Persian letters and the null character, are emitted
	/// as <c>0xFF</c>. The <c>0xFF</c> byte decodes as a non-breaking space and is not a round-trip replacement marker.
	/// </remarks>
	public override byte[] GetBytes(string str)
	{
		var mem = new MemoryStream();
		foreach (var ch in str)
		{
			var high = ch >> 8 & 0xff;
			var lowCharToByte = charToByte[high];
			byte res = 0;
			if (lowCharToByte != null)
			{
				var low = ch & 0xff;
				res = lowCharToByte[low];
			}
			if (res == 0) res = 0xff;
			mem.WriteByte(res);
		}
		return mem.ToArray();
	}
	/// <summary>
	/// Returns the requested character count because this encoding uses one byte per character.
	/// This method reports the supplied count without examining the requested range.
	/// </summary>
	/// <param name="chars">The character array that would be measured.</param>
	/// <param name="index">The nominal starting index in <c>chars</c>.</param>
	/// <param name="count">The number of characters requested.</param>
	/// <returns>The supplied <c>count</c> value.</returns>
	/// <remarks>The current implementation does not inspect the array, index, or character values.</remarks>
	public override int GetByteCount(char[] chars, int index, int count) => count;
	/// <summary>
	/// Returns the requested character count without encoding or writing to the destination byte array.
	/// Do not use this overload when output bytes are required.
	/// </summary>
	/// <param name="chars">The character array that is currently not read.</param>
	/// <param name="charIndex">The nominal starting index in <c>chars</c>.</param>
	/// <param name="charCount">The number returned as though that many characters had been encoded.</param>
	/// <param name="bytes">The destination array that is currently left unchanged.</param>
	/// <param name="byteIndex">The nominal starting index in <c>bytes</c>.</param>
	/// <returns>The supplied <c>charCount</c> value, although no bytes are written.</returns>
	/// <remarks>This overload currently reports success without reading, validating, encoding, or writing any data.</remarks>
	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) => charCount;
	/// <summary>
	/// Returns the requested byte count because this encoding maps each byte to one character.
	/// This method reports the supplied count without examining the requested range.
	/// </summary>
	/// <param name="bytes">The byte array that would be measured.</param>
	/// <param name="index">The nominal starting index in <c>bytes</c>.</param>
	/// <param name="count">The number of bytes requested.</param>
	/// <returns>The supplied <c>count</c> value.</returns>
	/// <remarks>The current implementation does not inspect the array, index, or byte values.</remarks>
	public override int GetCharCount(byte[] bytes, int index, int count) => count;
	/// <summary>
	/// Returns the requested byte count without decoding or writing to the destination character array.
	/// Do not use this overload when output characters are required.
	/// </summary>
	/// <param name="bytes">The byte array that is currently not read.</param>
	/// <param name="byteIndex">The nominal starting index in <c>bytes</c>.</param>
	/// <param name="byteCount">The number returned as though that many bytes had been decoded.</param>
	/// <param name="chars">The destination array that is currently left unchanged.</param>
	/// <param name="charIndex">The nominal starting index in <c>chars</c>.</param>
	/// <returns>The supplied <c>byteCount</c> value, although no characters are written.</returns>
	/// <remarks>This overload currently reports success without reading, validating, decoding, or writing any data.</remarks>
	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) => byteCount;
	/// <summary>
	/// Returns the supplied character count as the maximum byte count for this single-byte encoding.
	/// No fallback expansion is included in the result.
	/// </summary>
	/// <param name="charCount">The number of characters to size for.</param>
	/// <returns>The supplied <c>charCount</c> value.</returns>
	public override int GetMaxByteCount(int charCount) => charCount;
	/// <summary>
	/// Returns the supplied byte count as the maximum character count for this single-byte encoding.
	/// Every encoded byte corresponds to one table entry.
	/// </summary>
	/// <param name="byteCount">The number of bytes to size for.</param>
	/// <returns>The supplied <c>byteCount</c> value.</returns>
	public override int GetMaxCharCount(int byteCount) => byteCount;
}
