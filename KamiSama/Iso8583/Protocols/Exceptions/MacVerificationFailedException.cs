using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	[Serializable]
	[ExcludeFromCodeCoverage]
	public class MacVerificationFailedException : Exception
	{
		public MacVerificationFailedException(string messageMacHex, string generatedMacHex)
			: this($"Mac verification fiald, Message MAC: {messageMacHex}, Generated MAC: {generatedMacHex}")
		{
		}
		public MacVerificationFailedException(string message, Exception innerException = null)
			: base(message, innerException)
		{
		}
	}
}