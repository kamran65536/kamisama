using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public class BinaryDataTypeHandler : IsoDataTypeHandler
	{
		protected internal override byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding)
		{
			if ((isoField is BinaryIsoField binaryIsoField))
				return binaryIsoField.Data;
			else if ((isoField is StringIsoField stringIsoField))
				return encoding.GetBytes(stringIsoField.Data);
			else if ((isoField is BitmapIsoField bitmapIsoField))
				return bitmapIsoField.GetBitmapHex().FromHex();
			else
				throw new IsoMessageReadException($"BinaryDataTypeHandler does not support field type {isoField?.GetType()}");
		}

		protected internal override IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding)
			=> data;

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType, int retryCount)
		{
			var arr = stream.ReadComplete((int)lengthType);

			var result = 0;

			for (int i = arr.Length - 1; i >= 0; i--)
				result = result * 8 + arr[i];

			arr = null;

			return result;
		}
		
		protected internal override void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount)
		{
			var str = length.ToString("X2").PadLeft((int)lengthType * 2, '0');

			stream.Write(str.FromHex());
		}
	}
}