using System;
using System.IO;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols
{
	public abstract class IsoProtocolBase : IIsoProtocol
	{
		public Func<MemoryStream, byte[]> GenerateMacFunc { get; }

		public IsoProtocolBase(Func<MemoryStream, byte[]> generateMacFunc)
		{
			this.GenerateMacFunc = generateMacFunc;
		}

		public IsoMessage Read(Stream stream)
		{
			ReaderHeader(stream, out MemoryStream memoryStream, out IsoMessage message);

			using (memoryStream)
			{
				for (int fieldNo = 0; fieldNo <= 128; fieldNo++)
					if ((fieldNo == 0) || message.Has(fieldNo))
						ReadField(memoryStream, fieldNo, message);

				VerifyMac(message, memoryStream);				
			}

			return message;
		}

		protected virtual void VerifyMac(IsoMessage message, MemoryStream memoryStream)
		{
			if (GenerateMacFunc == null)
				return;
			var messageMac = (message[64] ?? message[128]) as BinaryIsoField;

			var newMacHex = GenerateMacFunc(memoryStream)?.ToHex() + "";
			var messageMacHex = messageMac?.Data?.ToHex() + "";

			if (messageMacHex != newMacHex)
				throw new MacVerificationFailedException(messageMacHex, newMacHex);
		}

		public void Write(Stream stream, IsoMessage message)
		{
			using (var memoryStream = new MemoryStream())
			{
				for (int fieldNo = 0; fieldNo < 128; fieldNo++)
					if (fieldNo != 64)
						WriteField(memoryStream, fieldNo, message);

				WriteMac(memoryStream, message);

				WrtieHeader(stream, memoryStream, message);
			}

		}

		protected virtual void WriteMac(MemoryStream memoryStream, IsoMessage message)
		{
			if (GenerateMacFunc == null)
				return;

			var mac = GenerateMacFunc(memoryStream);

			if (message.SecondaryBitmap != null)
				message[128] = mac;
			else
				message[64] = mac;
		}

		protected abstract void WrtieHeader(Stream stream, MemoryStream messageData, IsoMessage message);
		protected abstract void WriteField(MemoryStream messageData, int fieldNo, IsoMessage message);
		protected abstract void ReaderHeader(Stream stream, out MemoryStream memoryStream, out IsoMessage message);
		protected abstract void ReadField(MemoryStream memoryStream, int fieldNo, IsoMessage message);
	}
}