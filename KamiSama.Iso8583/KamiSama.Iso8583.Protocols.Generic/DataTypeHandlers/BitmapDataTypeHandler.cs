using System;
using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public class BitmapDataTypeHandler : IsoDataTypeHandler
	{
		protected internal override byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding)
		{
			if (!(isoField is BitmapIsoField bitmapIsoField))
				throw new IsoMessageReadException($"Only BitmapIsoField can be coverted by BitmapDataHandler.");

			return bitmapIsoField.GetBitmapHex().FromHex();
		}

		protected internal override IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding)
			=> BitmapIsoField.FromHex(data.ToHex());

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType, int retryCount)
			=> throw new NotSupportedException($"BitmapDataTypeHandler cannot be used for Length");

		protected internal override void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount)
			=> throw new NotSupportedException($"BitmapDataTypeHandler cannot be used for Length");
	}
}
