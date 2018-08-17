using System.Diagnostics.CodeAnalysis;

namespace KamiSama.SecureModule.Api
{
	[ExcludeFromCodeCoverage]
	public class KeyInjectionProperties
	{
		public string Name { get; set; }
		public string Group { get; set; }
		public int Algorithm { get; set; }
		public int KeySize { get; set; }
	}
}