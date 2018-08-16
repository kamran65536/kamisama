using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeySerializers
{
	public interface IKeySerializer
    {
		byte[] SerializeKey(IKey key);
		IKey DeserializeKey(byte[] keyData);
    }
	public interface IKeySerializer<_KeyType> : IKeySerializer
		where _KeyType : IKey
	{
		byte[] SerializeKey(_KeyType key);
		new _KeyType DeserializeKey(byte[] keyData);
	}
}
