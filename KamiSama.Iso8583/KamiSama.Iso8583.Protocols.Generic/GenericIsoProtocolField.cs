using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;

namespace KamiSama.Iso8583.Protocols.Generic
{
	[Serializable]
	public abstract class GenericIsoProtocolField
	{
		public static Dictionary<string, IsoDataTypeHandler> DataTypeHandlers { get; }

		static GenericIsoProtocolField()
		{
			DataTypeHandlers = new Dictionary<string, IsoDataTypeHandler>(StringComparer.InvariantCultureIgnoreCase);

			DataTypeHandlers.Add("txt", new TextDataTypeHandler());
			DataTypeHandlers.Add("text", new TextDataTypeHandler());
			DataTypeHandlers.Add("bin", new BinaryDataTypeHandler());
			DataTypeHandlers.Add("binary", new BinaryDataTypeHandler());
			DataTypeHandlers.Add("bcd", new BcdDataTypeHandler());
			DataTypeHandlers.Add("bitmap", new BitmapDataTypeHandler());
			DataTypeHandlers.Add("bmp", new BitmapDataTypeHandler());
			DataTypeHandlers.Add("hex-bitmap", new HexBitmapDataTypeHandler());
			DataTypeHandlers.Add("bitmap-hex", new HexBitmapDataTypeHandler());
			DataTypeHandlers.Add("bmp-hex", new HexBitmapDataTypeHandler());
			DataTypeHandlers.Add("hex-bmp", new HexBitmapDataTypeHandler());
		}

		[XmlAttribute("no")]
		public int FieldNo { get; set; }
		[XmlAttribute("data-type")]
		public string DataType { get; set; }
		[XmlAttribute("encoding")]
		public string Encoding { get; set; } = "utf-8";

		private IsoDataTypeHandler dataTypeHandler;

		protected internal IsoDataTypeHandler GetDataTypeHandler(bool readOrWrite)
		{
			if (dataTypeHandler != null)
				return dataTypeHandler;
			else if (!DataTypeHandlers.TryGetValue(DataType, out dataTypeHandler))
				if (readOrWrite)
					throw new IsoMessageReadException($"Cannot find data type handler for data type: {DataType}. Please add it from GenericIsoProtocolField.DataTypeHandlers.");
				else
					throw new IsoMessageWriteException($"Cannot find data type handler for data type: {DataType}. Please add it from GenericIsoProtocolField.DataTypeHandlers.");
			else
				return dataTypeHandler;
		}
		private Encoding encoding;
		protected Encoding GetEncoding() => encoding ?? (encoding = System.Text.Encoding.GetEncoding(Encoding));

		protected internal abstract void Read(MemoryStream memoryStream, int fieldNo, IsoMessage message);
		protected internal abstract void Write(MemoryStream memoryStream, int fieldNo, IsoMessage message);

	}
}