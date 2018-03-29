using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using KamiSama.Iso8583.Protocols;

namespace KamiSama.Iso8583.Server
{
	public class ServiceBasedIsoMessageHandler : IIsoMessageHandler
	{
		public List<IIsoService> Services { get; } = new List<IIsoService>();

		public void Handle(TcpClient tcpClient, IIsoProtocol protocol)
		{
			try
			{
				var stream = tcpClient.GetStream();
				var request = protocol.Read(stream);

				var service = Services.FirstOrDefault(x => x.CanHandle(request));

				if (service == null)
					throw new Exception($"No Service can handle message:\r\n{request.ToDebugString()}");

				var response = service.Handle(request);

				if (response != null)
					protocol.Write(stream, response);
			}
			catch (Exception)
			{
			}
			finally
			{
				try
				{
					tcpClient.Close();
				}
				catch
				{
				}
			}
		}
	}
}
