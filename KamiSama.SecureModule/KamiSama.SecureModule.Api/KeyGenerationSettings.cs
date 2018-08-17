using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.SecureModule.Api
{
	[ExcludeFromCodeCoverage]
	public class KeyGenerationSettings
	{
		public string Group { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string KeyName { get; set; }
		public int Algorithm { get; set; }
		public int KeySize { get; set; }
	}
}
