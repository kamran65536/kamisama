namespace KamiSama.SecureModule.Api
{
	public class KeyGenerationSettings
	{
		public bool Exportable { get; set; }
		public IKey ParentKey { get; set; }
	}
}
