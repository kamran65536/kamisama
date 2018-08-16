using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeyStores
{
	public abstract class KeyStoreBase<_KeyType> : IKeyStore<_KeyType>
		where _KeyType : class, IKey
	{

		public KeyStoreBase(ISecureModule<_KeyType> secureModule)
		{
			this.SecureModule = secureModule;
		}
		#region IKeyStore<_KeyType>
		public ISecureModule<_KeyType> SecureModule { get; }
		public abstract _KeyType FindKey(KeySearchProperties keySearchProperties);
		public abstract _KeyType[] FindKeys(KeySearchProperties keySearchProperties);
		public abstract byte[] ExportKey(_KeyType key, ExportKeyProperties exportKeyProperties);
		public abstract _KeyType ImportKey(byte[] keyBlob, ImportKeyProperties importKeyProperties);
		public abstract void DeleteKey(_KeyType key);
		public abstract void InjectKey(_KeyType key, KeyInjectionProperties keyInjectionProperties);
		#endregion
		#region IKeyStore
		ISecureModule IKeyStore.SecureModule => this.SecureModule;
		byte[] IKeyStore.ExportKey(IKey key, ExportKeyProperties exportKeyProperties) => ExportKey((_KeyType)key, exportKeyProperties);
		IKey IKeyStore.ImportKey(byte[] keyBlob, ImportKeyProperties importKeyProperties) => ImportKey(keyBlob, importKeyProperties);
		IKey IKeyStore.FindKey(KeySearchProperties keySearchProperties) => FindKey(keySearchProperties); 
		IKey[] IKeyStore.FindKeys(KeySearchProperties keySearchProperties) => FindKeys(keySearchProperties);
		void IKeyStore.DeleteKey(IKey key) => DeleteKey((_KeyType)key);
		void IKeyStore.InjectKey(IKey key, KeyInjectionProperties keyInjectionProperties) => InjectKey((_KeyType)key, keyInjectionProperties);
		#endregion
	}
}
