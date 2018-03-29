using System;
using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583.Protocols.Exceptions;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public class HexBitmapDataTypeHandler : IsoDataTypeHandler
	{
		protected internal override byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding)
		{
			if (!(isoField is BitmapIsoField bitmapIsoField))
				throw new IsoMessageReadException($"Only BitmapIsoField can be coverted by BitmapDataHandler.");

			return bitmapIsoField.GetBitmapHex().ToBytes();
		}

		protected internal override IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding)
			=> BitmapIsoField.FromHex(data.GetString());

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType)
			=> throw new NotSupportedException($"BitmapDataTypeHandler cannot be used for Length");

		protected internal override void WrtieAsLength(Stream stream, int length, VariableLengthType lengthType)
			=> throw new NotSupportedException($"BitmapDataTypeHandler cannot be used for Length");
	}
}
