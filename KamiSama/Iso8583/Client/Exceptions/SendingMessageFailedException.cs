using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Iso8583.Client.Exceptions
{
	[ExcludeFromCodeCoverage]
	public class SendingMessageFailedException : Exception
	{
		public SendingMessageFailedException()
		{
		}

		public SendingMessageFailedException(string message) : base(message)
		{
		}

		public SendingMessageFailedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected SendingMessageFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
