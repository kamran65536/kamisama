using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Iso8583.Client.Exceptions
{
	[ExcludeFromCodeCoverage]
	public class ReceivingMessageFailedException : Exception
	{
		public ReceivingMessageFailedException()
		{
		}

		public ReceivingMessageFailedException(string message) : base(message)
		{
		}

		public ReceivingMessageFailedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ReceivingMessageFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
