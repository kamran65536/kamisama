using System.Diagnostics.CodeAnalysis;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeyStores.InMemory
{
	[ExcludeFromCodeCoverage]
	public class InMemoryKeyRecord<_KeyType>
		where _KeyType : IKey
    {
		public string Name { get; set; }
		public string Group { get; set; }
		public int Algorithm { get; set; }
		public _KeyType Key { get; set; }
	}
}
