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

		protected internal override void Read(Stream stream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			try
			{
				var data = stream.ReadComplete(Length, retryCount);
				message[fieldNo] = GetDataTypeHandler(true).ConvertToIsoField(data, GetEncoding());

				data = null;
			}
			catch (Exception ex) when (!(ex is IsoMessageReadException))
			{
				throw new IsoMessageReadException($"Problem in reading field no {fieldNo}.", ex);
			}
		}
		protected internal override void Write(Stream stream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			try
			{
				var data = GetDataTypeHandler(false).ConvertToByteArray(message[fieldNo], GetEncoding());

				if (data.Length != Length)
					throw new IsoMessageWriteException($"Cannot write iso field no {fieldNo} because the length of the input is not valid");

				stream.Write(data);
				data = null;
			}
			catch (Exception ex) when (!(ex is IsoMessageWriteException))
			{
				throw new IsoMessageWriteException($"Cannot write iso field {fieldNo}.", ex);
			}
			
		}
	}
}