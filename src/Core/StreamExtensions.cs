namespace KamiSama.Extensions;

/// <summary>
/// Stream Extensions
/// </summary>
public static class StreamExtensions
{
	/// <summary>
	/// Read exact bytes as specified
	/// </summary>
	/// <param name="stream">the stream</param>
	/// <param name="length">length of bytes to be read</param>
	/// <param name="maxTries">maximum tries default value is int.MaxValue</param>
	/// <returns></returns>
	public static byte[] ReadExact(this Stream stream, int length, int maxTries = int.MaxValue)
	{
		var buffer = new byte[length];

		int bytesRead = 0;

		var tries = 0;

		while ((tries < maxTries) && (bytesRead < length))
		{
			var b = stream.Read(buffer, bytesRead, length - bytesRead);

			b = Math.Max(0, b);

			bytesRead += b;
			tries++;
		}

		if (bytesRead < length)
			throw new Exception($"Failed to read from stream after {tries} tries.");

		return buffer;
	}
	/// <summary>
	/// Read exact bytes as specified
	/// </summary>
	/// <param name="stream">the stream</param>
	/// <param name="length">length of bytes to be read</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public static async Task<byte[]> ReadExactAsync(this Stream stream, int length, CancellationToken cancellationToken)
	{
		var buffer = new byte[length];

		int bytesRead = 0;

		var tries = 0;

		while ((bytesRead < length) && !cancellationToken.IsCancellationRequested)
		{
			var b = await stream.ReadAsync(buffer.AsMemory(bytesRead, length - bytesRead), cancellationToken);

			b = Math.Max(0, b);

			bytesRead += b;
			tries++;
		}

		if (bytesRead < length)
			throw new Exception($"Failed to read from stream after {tries} tries.");

		return buffer;
	}
}
