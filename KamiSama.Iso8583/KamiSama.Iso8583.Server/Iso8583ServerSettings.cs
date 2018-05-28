using System;
using System.Net;
using KamiSama.Iso8583.Protocols;

namespace KamiSama.Iso8583.Server
{
	public class Iso8583ServerSettings
    {
		public string ServerName { get; set; } = "IsoServer";
		public IPEndPoint LocalEndPoint { get; set; }
		public TimeSpan WaitInterval { get; set; } = TimeSpan.FromMilliseconds(100);
		public IIsoProtocol Protocol { get; set; }
	}
}
