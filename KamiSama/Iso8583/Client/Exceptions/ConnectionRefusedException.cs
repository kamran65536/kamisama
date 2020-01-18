using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Iso8583.Client.Exceptions
{
	[ExcludeFromCodeCoverage]
	public class ConnectionRefusedException : Exception
	{
		public ConnectionRefusedException()
		{
		}

		public ConnectionRefusedException(string message) : base(message)
		{
		}

		public ConnectionRefusedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ConnectionRefusedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
