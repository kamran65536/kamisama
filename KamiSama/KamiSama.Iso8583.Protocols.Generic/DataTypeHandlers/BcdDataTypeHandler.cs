using System.IO;
using System.Text;
using KamiSama.Extenders;

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

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType)
		{
			var lengthLength = ((int)lengthType + 1) / 2;

			var arr = stream.ReadComplete(lengthLength);

			var result = arr.ToHex().ConvertTo(-1);

			arr = null;

			return result;
		}

		protected internal override void WrtieAsLength(Stream stream, int length, VariableLengthType lengthType)
		{
			var lengthLength = ((int)lengthType + 1) / 2;

			var str = length.ToString().PadLeft(lengthLength * 2, '0');

			stream.Write(str.FromHex());
		}
	}
}