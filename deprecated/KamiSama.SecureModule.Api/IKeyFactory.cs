namespace KamiSama.SecureModule.Api
{
	public interface IKeyFactory
	{
		IKey CreateKeyFrom(int algorithm, byte[] keyData);
	}
	public interface IKeyFactory<_KeyType> : IKeyFactory
	{
		new _KeyType CreateKeyFrom(int algorithm, byte[] keyData);
	}
}
