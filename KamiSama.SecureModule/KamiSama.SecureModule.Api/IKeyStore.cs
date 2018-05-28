namespace KamiSama.SecureModule.Api
{
	public interface IKeyStore
    {
		ISecureModule SecurityModule { get; }

		IKey LoadKey(string name);
		void SaveKey(string name, IKey key);
	}
	public interface IKeyStore<_KeyType> : IKeyStore
		where _KeyType : class, IKey
	{
		new ISecureModule<_KeyType> SecurityModule { get; }
		new _KeyType LoadKey(string name);
		void SaveKey(string name, _KeyType key);
	}
}
