using System.IO;
using System.Text;

namespace KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers
{
	public abstract class IsoDataTypeHandler
	{
		protected internal abstract IsoFieldBase ConvertToIsoField(byte[] data, Encoding encoding);
		protected internal abstract int ReadAsLength(Stream stream, VariableLengthType lengthType, int retryCount);
		protected internal abstract byte[] ConvertToByteArray(IsoFieldBase isoField, Encoding encoding);
		protected internal abstract void WriteAsLength(Stream stream, int length, VariableLengthType lengthType, int retryCount);
	}
}