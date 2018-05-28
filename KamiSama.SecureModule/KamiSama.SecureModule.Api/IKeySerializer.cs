namespace KamiSama.SecureModule.Api
{
	public interface IKeySerializer
    {
		ISecureModule SecurityModule { get; }

		byte[] SerializeKey(IKey key);
		IKey DeserializeKey(byte[] keyData);
    }
	public interface IKeySerializer<_KeyType> : IKeySerializer
		where _KeyType : class, IKey
	{
		new ISecureModule<_KeyType> SecurityModule { get; }
		byte[] SerializeKey(_KeyType key);
		new _KeyType DeserializeKey(byte[] keyData);
	}
}
