using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	[Serializable]
	[ExcludeFromCodeCoverage]
    public class IsoMessageReadException : Exception
	{
		public IsoMessageReadException(string message, Exception innerException = null)
			: base(message, innerException)
		{
		}
    }
}
