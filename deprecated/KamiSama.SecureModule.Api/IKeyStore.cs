namespace KamiSama.SecureModule.Api
{
	public interface IKeyStore
	{
		ISecureModule SecureModule { get; }

		IKey FindKey(KeySearchProperties keySearchProperties);
		IKey[] FindKeys(KeySearchProperties keySearchProperties);
		string[] ListKeyNames(KeySearchProperties keySearchProperties);
		byte[] ExportKey(IKey key, ExportKeyProperties exportKeyProperties);
		void DeleteKey(IKey key);
		IKey ImportKey(byte[] keyBlob, ImportKeyProperties importKeyProperties);
		void InjectKey(IKey key, KeyInjectionProperties keyInjectionProperties);
	}
	public interface IKeyStore<_KeyType> : IKeyStore
		where _KeyType : IKey
    {
		new ISecureModule<_KeyType> SecureModule { get; }

		new _KeyType FindKey(KeySearchProperties keySearchProperties);
		new _KeyType[] FindKeys(KeySearchProperties keySearchProperties);
		byte[] ExportKey(_KeyType key, ExportKeyProperties exportKeyProperties);
		new _KeyType ImportKey(byte[] keyBlob, ImportKeyProperties importKeyProperties);
		void InjectKey(_KeyType key, KeyInjectionProperties keyInjectionProperties);
		void DeleteKey(_KeyType key);
	}
}
