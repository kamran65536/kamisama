using System;
using System.Net.Sockets;

namespace KamiSama.Iso8583.Client
{
	public interface ITcpClient : IDisposable
	{
		NetworkStream GetStream();
	}
}