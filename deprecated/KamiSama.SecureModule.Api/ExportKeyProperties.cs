using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	[ExcludeFromCodeCoverage]
	public class ExportKeyProperties
	{
		public KeyBlobType KeyBlobType { get; set; }
		public ExportPart ExportParts { get; set; }
		public IKey ParentKey { get; set; }
		public PaddingMode KeyBlobPaddingMode { get; set; }
		public CipherMode KeyBlobCipherMode { get; set; }
	}
}