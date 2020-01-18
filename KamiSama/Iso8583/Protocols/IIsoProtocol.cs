using System.IO;

namespace KamiSama.Iso8583.Protocols
{
	public interface IIsoProtocol
    {
		IsoMessage Read(Stream stream, int retryCount = 100);
		void Write(Stream stream, IsoMessage message, int retryCount = 100);
    }
}
