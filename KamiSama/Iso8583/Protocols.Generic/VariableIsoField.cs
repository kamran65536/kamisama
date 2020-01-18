using System;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;

namespace KamiSama.Iso8583.Protocols.Generic
{
	public class VariableIsoField : GenericIsoProtocolField
	{
		[XmlAttribute("length-datatype")]
		public string LengthDataType { get; set; }
		[XmlAttribute("length-type")]
		public VariableLengthType LengthType { get; set; }

		private IsoDataTypeHandler lengthDataTypeHandler;

		protected internal IsoDataTypeHandler GetLengthDataTypeHandler(bool readOrWrite)
		{
			if (lengthDataTypeHandler != null)
				return lengthDataTypeHandler;
			else if (!DataTypeHandlers.TryGetValue(LengthDataType, out lengthDataTypeHandler))
				if (readOrWrite)
					throw new IsoMessageReadException($"Cannot find data type handler for data type: {LengthDataType}. Please add it from GenericIsoProtocolField.DataTypeHandlers.");
				else
					throw new IsoMessageWriteException($"Cannot find data type handler for data type: {LengthDataType}. Please add it from GenericIsoProtocolField.DataTypeHandlers.");
			else
				return lengthDataTypeHandler;
		}

		protected internal override void Read(Stream stream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			try
			{
				var length = GetLengthDataTypeHandler(true).ReadAsLength(stream, LengthType, retryCount);
				if (length < 0)
					throw new IsoMessageReadException($"Invalid length for field: {fieldNo}");

				var data = stream.ReadComplete(length, retryCount);

				message[fieldNo] = GetDataTypeHandler(true).ConvertToIsoField(data, GetEncoding());

				data = null;
			}
			catch (Exception ex) when (!(ex is IsoMessageReadException))
			{
				throw new IsoMessageReadException($"Cannot read from the input for field {FieldNo}.", ex);
			}
		}
		protected internal override void Write(Stream stream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			try
			{
				var data = GetDataTypeHandler(false).ConvertToByteArray(message[fieldNo], GetEncoding());

				GetLengthDataTypeHandler(false).WriteAsLength(stream, data.Length, LengthType, retryCount);
				stream.Write(data);

				data = null;
			}
			catch (Exception ex) when (!(ex is IsoMessageWriteException))
			{
				throw new IsoMessageWriteException($"Cannot read from the input for field {FieldNo}.", ex);
			}
		}
	}
}