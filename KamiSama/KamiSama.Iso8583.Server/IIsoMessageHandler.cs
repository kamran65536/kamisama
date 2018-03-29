using System.Net.Sockets;
using KamiSama.Iso8583.Protocols;

namespace KamiSama.Iso8583.Server
{
	public interface IIsoMessageHandler
	{
		void Handle(TcpClient tcpClient, IIsoProtocol protcol);
	}
}
