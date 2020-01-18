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
		public Func<byte[], byte[]> GenerateMacFunc { get; set; }

		[ExcludeFromCodeCoverage]
		public IsoProtocolBase(Func<byte[], byte[]> generateMacFunc)
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
			ReadHeaderAndData(stream, out MemoryStream messageStream, out IsoMessage message, retryCount);

			int macFieldPosition = -1;

			using (messageStream)
			{
				for (int fieldNo = 0; fieldNo <= 128; fieldNo++)
					if ((fieldNo == 0) || message.Has(fieldNo))
					{
						if ((fieldNo == 64) || (fieldNo == 128))
							macFieldPosition = (int)messageStream.Position;

						ReadField(messageStream, fieldNo, message, retryCount);
					}

				VerifyMac(message, messageStream, macFieldPosition);			
			}

			return message;
		}

		protected internal virtual void VerifyMac(IsoMessage message, MemoryStream messageStream, int macFieldPosition)
		{
			if (GenerateMacFunc == null)
				return;

			if (macFieldPosition < 0)
				throw new MacVerificationFailedException($"Mac is not found.");

			messageStream.Seek(0, SeekOrigin.Begin);
			var arr = messageStream.ReadComplete(macFieldPosition);

			var newMacHex = GenerateMacFunc(arr)?.ToHex() + "";
			var messageMac = (message[128] ?? message[64]) as StringIsoField;

			var messageMacHex = messageMac?.Data + "";

			if (messageMacHex.ToLower() != newMacHex.ToLower())
				throw new MacVerificationFailedException(messageMacHex, newMacHex);
		}

		public void Write(Stream stream, IsoMessage message, int retryCount)
		{
			using (var memoryStream = new MemoryStream())
			{
				WriteMessageId(memoryStream, message);
				if (GenerateMacFunc != null)
				{
					if (message.SecondaryBitmap != null)
						message.SecondaryBitmap[128] = true;
					else
						message.PrimaryBitmap[64] = true;
				}

				for (int fieldNo = 0; fieldNo < 128; fieldNo++)
					if ((fieldNo != 64) && message.Has(fieldNo))
						WriteField(memoryStream, fieldNo, message, retryCount);

				
				WriteMac(stream, message, memoryStream, retryCount);

				WriteHeaderAndData(stream, memoryStream, message, retryCount);
			}
		}


		protected internal virtual void WriteMac(Stream stream, IsoMessage message, MemoryStream msgStream, int retryCount)
		{
			if (GenerateMacFunc == null)
				return;

			var mac = GenerateMacFunc(msgStream.ToArray());

			if (message.SecondaryBitmap != null)
			{
				message[128] = mac.ToHex();
				WriteField(msgStream, 128, message, retryCount);
			}
			else
			{
				message[64] = mac.ToHex();
				WriteField(msgStream, 64, message, retryCount);
			}
		}

		protected internal abstract void WriteMessageId(MemoryStream memoryStream, IsoMessage message);
		protected internal abstract void WriteHeaderAndData(Stream stream, MemoryStream messageData, IsoMessage message, int retryCount);
		protected internal abstract void WriteField(Stream stream, int fieldNo, IsoMessage message, int retryCount);
		protected internal abstract void ReadHeaderAndData(Stream stream, out MemoryStream memoryStream, out IsoMessage message, int retryCount);
		protected internal abstract void ReadField(Stream stream, int fieldNo, IsoMessage message, int retryCount);
	}
}