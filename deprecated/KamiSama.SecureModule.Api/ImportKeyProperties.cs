using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace KamiSama.SecureModule.Api
{
	[ExcludeFromCodeCoverage]
	public class ImportKeyProperties
    {
		public ImportKeyStoreType ImportKeyStoreType { get; set; } = ImportKeyStoreType.ImportAndStore;
		public IKey ParentKey { get; set; }
		public KeyBlobType KeyBlobType { get; set; }
		public PaddingMode KeyBlobPaddingMode { get; set; }
		public CipherMode KeyBlobCipherMode { get; set; }
		public string Name { get; set; }
		public string Group { get; set; }
		public int Algorithm { get; set; }
	}
}
