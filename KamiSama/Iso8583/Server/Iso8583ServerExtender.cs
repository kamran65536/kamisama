namespace KamiSama.Iso8583.Server
{
	public static class Iso8583ServerExtender
    {
		public static Iso8583Server BindServices(this Iso8583Server server, params IIsoService[] services)
		{
			var handler = server.IsoMessageHandler as ServiceBasedIsoMessageHandler;

			if (handler == null)
				server.IsoMessageHandler = handler = new ServiceBasedIsoMessageHandler();

			handler.Services.AddRange(services);

			return server;
		}
    }
}
