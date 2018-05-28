using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeySerializers
{
	public abstract class KeySerializerBase<_KeyType> : IKeySerializer<_KeyType>
		where _KeyType : class, IKey
	{
		public ISecureModule<_KeyType> SecurityModule { get; }

		ISecureModule IKeySerializer.SecurityModule => this.SecurityModule;

		public abstract byte[] SerializeKey(_KeyType key);
		byte[] IKeySerializer.SerializeKey(IKey key) => SerializeKey((_KeyType)key);

		public abstract _KeyType DeserializeKey(byte[] keyData);
		IKey IKeySerializer.DeserializeKey(byte[] keyData) => DeserializeKey(keyData);

		public KeySerializerBase(ISecureModule<_KeyType> securityModule)
		{
			this.SecurityModule = securityModule;
		}
	}
}
