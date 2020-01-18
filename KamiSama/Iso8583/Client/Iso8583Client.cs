using KamiSama.Iso8583.Client.Exceptions;
using KamiSama.Iso8583.Protocols;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;

namespace KamiSama.Iso8583.Client
{
	public class Iso8583Client
	{
		public IIsoProtocol Protocol { get; }

		public Iso8583Client(IIsoProtocol protocol)
		{
			this.Protocol = protocol;
		}
		[ExcludeFromCodeCoverage]
		public IsoMessage Send(IsoMessage request, TcpClient client) => Send(request, new InternalTcpClient(client));
		public IsoMessage Send(IsoMessage request, ITcpClient client)
		{
			NetworkStream stream;
			try
			{
				stream = client.GetStream();

				Protocol.Write(stream, request);
			}
			catch (Exception ex)
			{
				throw new SendingMessageFailedException($"Cannot send message.", ex);
			}
			try
			{
				return Protocol.Read(stream);
			}
			catch (Exception ex)
			{
				throw new ReceivingMessageFailedException($"Reading response message failed.", ex);
			}
		}
		[ExcludeFromCodeCoverage]
		public IsoMessage Send(IsoMessage request, IPEndPoint endPoint)
		{
			using (var client = new InternalTcpClient())
			{
				try
				{
					client.Connect(endPoint);
				}
				catch (Exception ex)
				{
					throw new ConnectionRefusedException($"Cannot connect to {endPoint}.", ex);
				}

				return Send(request, client);
			}
		}
		[ExcludeFromCodeCoverage]
		public IsoMessage Send(IsoMessage request, string host, int port)
		{
			using (var client = new InternalTcpClient())
			{
				try
				{
					client.Connect(host, port);
				}
				catch (Exception ex)
				{
					throw new ConnectionRefusedException($"Cannot connect to {host}:{port}.", ex);
				}

				return Send(request, client);
			}
		}
		[ExcludeFromCodeCoverage]
		public IsoMessage Send(IsoMessage request, IPAddress ipAddress, int port)
			=> Send(request, new IPEndPoint(ipAddress, port));
	}
}
