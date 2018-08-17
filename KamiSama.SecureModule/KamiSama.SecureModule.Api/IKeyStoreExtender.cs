namespace KamiSama.SecureModule.Api
{
	public static class IKeyStoreExtender
    {
		public static IKey FindKey(this IKeyStore keyStore, string name, string group = null, int? algorithm = null) => keyStore.FindKey(new KeySearchProperties { Name = name, Group = group, Algorithm = algorithm });
		public static _KeyType FindKey<_KeyType>(this IKeyStore<_KeyType> keyStore, string name, string group = null, int? algorithm =null) 
			where _KeyType : IKey
			=> keyStore.FindKey(new KeySearchProperties { Name = name, Group = group, Algorithm = algorithm });
    }
}
