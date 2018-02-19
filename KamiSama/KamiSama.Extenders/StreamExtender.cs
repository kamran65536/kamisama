using System;
using System.IO;

namespace KamiSama.Extenders
{
	public static class StreamExtender
	{
		public static byte[] ReadComplete(this Stream stream, int length, int maxTries = int.MaxValue)
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

		public static void Write(this Stream stream, byte[] buffer)
			=> stream.Write(buffer, 0, buffer.Length);
	}
}
