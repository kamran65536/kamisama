using System;

namespace KamiSama.Iso8583.Protocols.Exceptions
{
	[Serializable]
	public class MacVerificationFailedException : Exception
	{
		public MacVerificationFailedException(string messageMacHex, string generatedMacHex)
			: base($"Mac verification fiald, Message MAC: {messageMacHex}, Generated MAC: {generatedMacHex}")
		{
		}
	}
}