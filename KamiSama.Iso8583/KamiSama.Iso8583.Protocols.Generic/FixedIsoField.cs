using System;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic
{
	[Serializable]
	public class FixedIsoField : GenericIsoProtocolField
	{
		[XmlAttribute("length")]
		public int Length { get; set; }

		protected internal override void Read(MemoryStream memoryStream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			try
			{
				var data = memoryStream.ReadComplete(Length, retryCount);
				message[fieldNo] = GetDataTypeHandler(true).ConvertToIsoField(data, GetEncoding());

				data = null;
			}
			catch (Exception ex)
			{
				throw new IsoMessageReadException($"Problem in reading field no {fieldNo}.", ex);
			}
		}
		protected internal override void Write(MemoryStream messageStream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			var data = GetDataTypeHandler(false).ConvertToByteArray(message[fieldNo], GetEncoding());

			if (data.Length != Length)
				throw new IsoMessageWriteException($"Cannot write iso field no {fieldNo} because the length of the input is not valid");

			messageStream.Write(data);
			data = null;
		}
	}
}