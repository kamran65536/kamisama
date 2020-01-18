using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;

namespace KamiSama.Iso8583.Client
{
	[ExcludeFromCodeCoverage]
	class InternalTcpClient : ITcpClient
	{
		private TcpClient _client;

		public InternalTcpClient()
		{
			_client = new TcpClient();
		}

		public InternalTcpClient(TcpClient _client)
		{
			this._client = _client;
		}

		public void Dispose() => _client.Dispose();
		public NetworkStream GetStream() => _client.GetStream();

		public void Connect(IPEndPoint endPoint) => _client.Connect(endPoint);
		public void Connect(string host, int port) => _client.Connect(host, port);
	}
}
