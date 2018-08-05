using System.IO;
using System.Text;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public class TextDataTypeHandler : IsoDataTypeHandler
	{
		protected internal override byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding)
			=> encoding.GetBytes(isoField + "");

		protected internal override IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding)
			=> encoding.GetString(data);

		protected internal override int ReadAsLength(Stream stream, VariableLengthType lengthType, int retryCount)
			=> Encoding.ASCII.GetString(stream.ReadComplete((int)lengthType)).ConvertTo(-1);

		protected internal override void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount)
		{
			var str = (length + "").PadLeft((int)lengthType);

			stream.Write(str.ToBytes(Encoding.ASCII));
		}
	}
}
