using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols
{
	public abstract class IsoProtocolBase : IIsoProtocol
	{
		[XmlIgnore]
		public Func<MemoryStream, byte[]> GenerateMacFunc { get; set; }

		[ExcludeFromCodeCoverage]
		public IsoProtocolBase(Func<MemoryStream, byte[]> generateMacFunc)
		{
			this.GenerateMacFunc = generateMacFunc;
		}
		[ExcludeFromCodeCoverage]
		public IsoProtocolBase()
			: this(null)
		{
		}

		public IsoMessage Read(Stream stream, int retryCount)
		{
			ReadHeaderAndData(stream, out MemoryStream memoryStream, out IsoMessage message, retryCount);

			using (memoryStream)
			{
				for (int fieldNo = 0; fieldNo <= 128; fieldNo++)
					if ((fieldNo == 0) || message.Has(fieldNo))
						ReadField(memoryStream, fieldNo, message, retryCount);

				VerifyMac(message, memoryStream);				
			}

			return message;
		}

		protected internal virtual void VerifyMac(IsoMessage message, MemoryStream memoryStream)
		{
			if (GenerateMacFunc == null)
				return;
			var messageMac = (message[128] ?? message[64]) as BinaryIsoField;

			var newMacHex = GenerateMacFunc(memoryStream)?.ToHex() + "";
			var messageMacHex = messageMac?.Data?.ToHex() + "";

			if (messageMacHex.ToLower() != newMacHex.ToLower())
				throw new MacVerificationFailedException(messageMacHex, newMacHex);
		}

		public void Write(Stream stream, IsoMessage message, int retryCount)
		{
			using (var memoryStream = new MemoryStream())
			{
				for (int fieldNo = 0; fieldNo < 128; fieldNo++)
					if ((fieldNo != 64) && message.Has(fieldNo))
						WriteField(memoryStream, fieldNo, message, retryCount);

				WriteMac(memoryStream, message, retryCount);

				WrtieHeaderAndData(stream, memoryStream, message, retryCount);
			}
		}

		protected internal virtual void WriteMac(MemoryStream memoryStream, IsoMessage message, int retryCount)
		{
			if (GenerateMacFunc == null)
				return;

			var mac = GenerateMacFunc(memoryStream);

			if (message.SecondaryBitmap != null)
			{
				message[128] = mac;
				WriteField(memoryStream, 128, message, retryCount);
			}
			else
			{
				message[64] = mac;
				WriteField(memoryStream, 64, message, retryCount);
			}
		}

		protected internal abstract void WrtieHeaderAndData(Stream stream, MemoryStream messageData, IsoMessage message, int retryCount);
		protected internal abstract void WriteField(MemoryStream messageData, int fieldNo, IsoMessage message, int retryCount);
		protected internal abstract void ReadHeaderAndData(Stream stream, out MemoryStream memoryStream, out IsoMessage message, int retryCount);
		protected internal abstract void ReadField(MemoryStream memoryStream, int fieldNo, IsoMessage message, int retryCount);
	}
}