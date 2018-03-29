using System;
using System.Net.Sockets;
using System.Threading;
using KamiSama.Agents;

namespace KamiSama.Iso8583.Server
{
	public class Iso8583Server : RepeatingAgent
	{
		public Iso8583ServerSettings Settings { get; }
		public TcpListener Listener { get; }
		public IIsoMessageHandler IsoMessageHandler { get; set; }

		public Iso8583Server(Iso8583ServerSettings settings, IIsoMessageHandler messageHandler = null)
			: base(settings.ServerName, settings.WaitInterval)
		{
			this.Settings = settings;
			this.Listener = new TcpListener(settings.LocalEndPoint);
			this.IsoMessageHandler = messageHandler ?? new ServiceBasedIsoMessageHandler();
		}

		protected override void OnStart()
		{
			Listener.Start();
		}
		protected override void OnStop()
		{
			Listener.Stop();
		}

		protected override bool DoJob(RepeatingAgent agent)
		{
			var tcpClient = Listener.AcceptTcpClient();

			var thread = new Thread(HandleClient);

			thread.Start(tcpClient);

			return true;
		}

		private void HandleClient(object obj)
		{
			try
			{
				IsoMessageHandler?.Handle(obj as TcpClient, Settings.Protocol);
			}
			catch (Exception)
			{
			}
		}
	}
}