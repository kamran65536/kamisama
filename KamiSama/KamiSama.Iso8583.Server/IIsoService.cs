namespace KamiSama.Iso8583.Server
{
	public interface IIsoService
	{
		bool CanHandle(IsoMessage request);
		IsoMessage Handle(IsoMessage request);
	}
}
