using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeyStores
{
	public abstract class KeyStoreBase<_KeyType> : IKeyStore<_KeyType>
		where _KeyType : class, IKey
	{
		public ISecureModule<_KeyType> SecurityModule { get; }

		ISecureModule IKeyStore.SecurityModule => this.SecurityModule;

		public abstract _KeyType LoadKey(string name);
		public abstract void SaveKey(string name, _KeyType key);
		void IKeyStore.SaveKey(string name, IKey key) => SaveKey(name, (_KeyType)key);
		IKey IKeyStore.LoadKey(string name) => LoadKey(name);

		public KeyStoreBase(ISecureModule<_KeyType> securityModule)
		{
			this.SecurityModule = securityModule;
		}
	}
}
