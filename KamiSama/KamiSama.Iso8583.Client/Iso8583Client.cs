using System.Net;
using System.Net.Sockets;
using KamiSama.Iso8583.Protocols;

namespace KamiSama.Iso8583.Client
{
	public class Iso8583Client
	{
		public IIsoProtocol Protocol { get; }

		public Iso8583Client(IIsoProtocol protocol)
		{
			this.Protocol = protocol;
		}

		public IsoMessage Send(IsoMessage request, TcpClient client)
		{
			var stream = client.GetStream();

			Protocol.Write(stream, request);

			return Protocol.Read(stream);
		}
		public IsoMessage Send(IsoMessage request, IPEndPoint endPoint)
		{
			using (var client = new TcpClient())
			{
				client.Connect(endPoint);

				return Send(request, client);
			}
		}
		public IsoMessage Send(IsoMessage request, string host, int port)
		{
			var endpoint = new DnsEndPoint(host, port);

			using (var client = new TcpClient())
			{
				client.Connect(host, port);

				return Send(request, client);
			}
		}
		public IsoMessage Send(IsoMessage request, IPAddress ipAddress, int port)
			=> Send(request, new IPEndPoint(ipAddress, port));
	}
}
