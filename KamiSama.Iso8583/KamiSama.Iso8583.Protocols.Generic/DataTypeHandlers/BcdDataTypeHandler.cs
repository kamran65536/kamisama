using System;
using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public class BcdDataTypeHandler : IsoDataTypeHandler
	{
		protected internal override byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding)
		{
			var str = isoField + "";

			if (str.Length % 2 != 0)
				str = '0' + str;

			return str.FromHex();
		}

		protected internal override IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding)
			=> data.ToHex();

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType, int retryCount)
		{
			var lengthLength = ((int)lengthType + 1) / 2;

			var arr = stream.ReadComplete(lengthLength, retryCount);

			if ((int)lengthType % 2 == 1)
				arr[0] &= 0x0f;

			var result = arr.ToHex().ConvertTo(-1);

			arr = null;

			return result;
		}

		protected internal override void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount)
		{
			if (Math.Log10(length) > (int)lengthType)
				throw new IsoMessageWriteException($"Invalid length ({length}) for type: {lengthType}");

			var lengthLength = ((int)lengthType + 1) / 2;

			var str = length.ToString().PadLeft(lengthLength * 2, '0');


			stream.Write(str.FromHex());
		}
	}
}