using System.IO;
using System.Text;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public abstract class IsoDataTypeHandler
	{
		protected internal abstract IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding);
		protected internal abstract int ReadAsLength(Stream stream, VariableLengthType lengthType);
		protected internal abstract byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding);
		protected internal abstract void WrtieAsLength(Stream stream, int length, VariableLengthType lengthType);
	}
}