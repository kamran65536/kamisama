using System;

namespace KamiSama.SecureModule.Api
{
	public class KeyGenerationSettings
	{
		public string Group { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string KeyName { get; set; }
		public int Algorithm { get; set; }
		public int KeySize { get; set; }
	}
}
