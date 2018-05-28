using System;

namespace KamiSama.SecureModule.Api
{
	public class KeyGenerationSettings
	{
		public IKey ParentKey { get; set; }
		public string Group { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public bool IsExternalKey { get; set; }
		public string KeyStoreName { get; set; }
		public string KeyName { get; set; }
		public string Algorithm { get; set; }
		public byte[] KeyData { get; set; } 
	}
}
