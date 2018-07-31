using System;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Protocols.Generic
{
	[Serializable]
	public class FixedIsoField : GenericIsoProtocolField
	{
		[XmlAttribute("length")]
		public int Length { get; set; }

		protected internal override void Read(MemoryStream memoryStream, int fieldNo, IsoMessage message)
		{
			var data = memoryStream.ReadComplete(Length);
			message[fieldNo] = GetDataTypeHandler(true).ConvertToIsoField(data, GetEncoding());

			data = null;
		}
		protected internal override void Write(MemoryStream messageStream, int fieldNo, IsoMessage message)
		{
			var data = GetDataTypeHandler(false).ConvertToByteArray(message[fieldNo], GetEncoding());

			messageStream.Write(data);
			data = null;
		}
	}
}