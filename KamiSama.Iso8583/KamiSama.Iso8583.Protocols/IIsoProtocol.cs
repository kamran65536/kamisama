using System.IO;

namespace KamiSama.Iso8583.Protocols
{
	public interface IIsoProtocol
    {
		IsoMessage Read(Stream stream);
		void Write(Stream stream, IsoMessage message);
    }
}
