using System;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	[Serializable]
    public class IsoMessageReadException : Exception
	{
		public IsoMessageReadException(string message, Exception innerException = null)
			: base(message, innerException)
		{
		}
    }
}
