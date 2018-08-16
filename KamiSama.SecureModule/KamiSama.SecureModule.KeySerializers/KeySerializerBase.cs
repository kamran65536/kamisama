using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeySerializers
{
	public abstract class KeySerializerBase<_KeyType> : IKeySerializer<_KeyType>
		where _KeyType : IKey
	{
		public abstract _KeyType DeserializeKey(byte[] keyData);
		public abstract byte[] SerializeKey(_KeyType key);
		byte[] IKeySerializer.SerializeKey(IKey key) => SerializeKey((_KeyType)key);
		IKey IKeySerializer.DeserializeKey(byte[] keyData) => DeserializeKey(keyData);
	}
}
