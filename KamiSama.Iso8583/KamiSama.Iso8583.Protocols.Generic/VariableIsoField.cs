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

		protected IsoDataTypeHandler GetLengthDataTypeHandler(bool readOrWrite)
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

		protected internal override void Read(MemoryStream memoryStream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			var length = GetLengthDataTypeHandler(true).ReadAsLength(memoryStream, LengthType, retryCount);
			if (length < 0)
				throw new IsoMessageReadException($"Invalid length for field: {fieldNo}");

			var data = memoryStream.ReadComplete(length, retryCount);

			message[fieldNo] = GetDataTypeHandler(true).ConvertToIsoField(data, GetEncoding());

			data = null;
		}
		protected internal override void Write(MemoryStream memoryStream, int fieldNo, IsoMessage message, int retryCount = 100)
		{
			var data = GetDataTypeHandler(false).ConvertToByteArray(message[fieldNo], GetEncoding());

			GetLengthDataTypeHandler(false).WriteAsLength(memoryStream, data.Length, LengthType, retryCount);
			memoryStream.Write(data);

			data = null;
		}
	}
}