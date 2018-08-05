using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	[Serializable]
	[ExcludeFromCodeCoverage]
	public class IsoMessageWriteException : Exception
	{
		public IsoMessageWriteException(string message, Exception innerException = null)
			: base(message, innerException)
		{
		}
	}
}
