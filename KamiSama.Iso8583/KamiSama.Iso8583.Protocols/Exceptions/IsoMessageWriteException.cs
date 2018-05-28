using System;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	public class IsoMessageWriteException : Exception
	{
		public IsoMessageWriteException(string message, Exception innerException = null)
			: base(message, innerException)
		{
		}
	}
}
