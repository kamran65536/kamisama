using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic
{
	[Serializable]
	[XmlRoot("iso-protocol")]
	public class GenericIsoProtocol : IsoProtocolBase
	{
		[XmlElement("fixed", typeof(FixedIsoField))]
		[XmlElement("variable", typeof(VariableIsoField))]
		public GenericIsoProtocolField[] Fields { get; set; }

		[ExcludeFromCodeCoverage]
		public GenericIsoProtocol(Func<MemoryStream, byte[]> generateMacFunc)
			: base(generateMacFunc)
		{
		}
		[ExcludeFromCodeCoverage]
		public GenericIsoProtocol()
			: base(null)
		{
		}

		protected override void ReadHeaderAndData(Stream stream, out MemoryStream memoryStream, out IsoMessage message, int retryCount)
		{
			string lenStr;
			try
			{
				lenStr = stream.ReadComplete(4, retryCount).GetString(Encoding.ASCII);
			}
			catch (Exception exp)
			{
				throw new IsoMessageReadException("Cannot read message length.", exp);
			}

			if (!int.TryParse(lenStr, out int len))
				throw new IsoMessageReadException($"Invalid iso message length: {lenStr}");

			try
			{
				var id = stream.ReadComplete(4, retryCount).GetString(Encoding.ASCII);
				message = new IsoMessage(id);
			}
			catch (Exception exp)
			{
				throw new IsoMessageReadException("Cannot read message MTI.", exp);
			}

			try
			{
				memoryStream = new MemoryStream(stream.ReadComplete(len - 4, retryCount));
			}
			catch (Exception exp)
			{
				throw new IsoMessageReadException($"Cannot read iso message completely, id: {message.Id}, length: {len}", exp);
			}
		}
		protected override void WrtieHeaderAndData(Stream stream, MemoryStream messageData, IsoMessage message, int retryCount)
		{
			var arr = messageData.ToArray();
			var len = arr.Length + 4;

			stream.Write(len.ToString("0000").ToBytes(Encoding.ASCII));
			stream.Write(message.Id.PadLeft(4, '0').ToBytes(Encoding.ASCII));

			stream.Write(arr);
		}
		protected override void ReadField(MemoryStream memoryStream, int fieldNo, IsoMessage message, int retryCount)
		{
			var field = Fields.FirstOrDefault(x => x.FieldNo == fieldNo);

			if (field == null)
				throw new IsoMessageReadException($"Cannot read field no {fieldNo}, no proper Field reader/writer is found.");

			field.Read(memoryStream, fieldNo, message, retryCount);
		}
		protected override void WriteField(MemoryStream messageData, int fieldNo, IsoMessage message, int retryCount)
		{
			var field = Fields.FirstOrDefault(x => x.FieldNo == fieldNo);

			if (field == null)
				throw new IsoMessageReadException($"Cannot writer field no {fieldNo}, no proper Field reader/writer is found.");

			field.Write(messageData, fieldNo, message, retryCount);
		}
	}
}
