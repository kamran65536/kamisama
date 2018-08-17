using System.Diagnostics.CodeAnalysis;

namespace KamiSama.SecureModule.Api
{
	[ExcludeFromCodeCoverage]
	public class KeySearchProperties
	{
		public string Name { get; set; }
		public string Group { get; set; }
		public int? Algorithm { get; set; }
	}
}