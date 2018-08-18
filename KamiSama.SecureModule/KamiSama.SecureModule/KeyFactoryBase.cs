using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule
{
	public abstract class KeyFactoryBase<_KeyType> : IKeyFactory<_KeyType>
		where _KeyType : IKey
	{
		IKey IKeyFactory.CreateKeyFrom(int algorithm, byte[] keyData)
			=> CreateKeyFrom(algorithm, keyData);

		public abstract _KeyType CreateKeyFrom(int algorithm, byte[] keyData);
	}
}
