namespace KamiSama.SecureModule.Api
{
	public enum ExportPart
	{
		Secret = 0x01,  // symetric keys
		Public = 0x02,	// asymetric keys
		Private = 0x04, // asymetric keys
		All = 0x07
	}
}