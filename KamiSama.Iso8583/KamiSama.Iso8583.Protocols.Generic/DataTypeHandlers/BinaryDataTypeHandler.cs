using System;
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
			var arr = stream.ReadComplete((int)lengthType, retryCount);

			var result = 0;

			for (int i = 0; i < arr.Length; i++)
				result = result * 256 + arr[i];

			arr = null;

			return result;
		}
		
		protected internal override void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount)
		{
			if (Math.Log10(length) > ((int)lengthType * 2))
				throw new IsoMessageWriteException($"Invalid length ({length}) for type: {lengthType}");

			var str = length.ToString("X2").PadLeft((int)lengthType * 2, '0');

			stream.Write(str.FromHex());
		}
	}
}