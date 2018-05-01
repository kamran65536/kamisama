using System;
using System.Collections.Generic;
using KamiSama.SecureModule.Api;

namespace KamiSama.SecureModule.KeyStores
{
	public class InMemoryKeyStore<_KeyType> : KeyStoreBase<_KeyType>
		where _KeyType : class, IKey
	{
		private Dictionary<string, _KeyType> keys;

		public InMemoryKeyStore(ISecureModule<_KeyType> securityModule) : base(securityModule)
		{
			this.keys = new Dictionary<string, _KeyType>(StringComparer.InvariantCultureIgnoreCase);
		}

		public override _KeyType LoadKey(string name)
		{
			lock (keys)
				return keys[name];
		}

		public override void SaveKey(string name, _KeyType key)
		{
			if (key == null)
				throw new NullReferenceException("Key cannot be null.");

			lock (keys)
			{
				if (keys.ContainsKey(name))
					keys[name] = key;
				else
					keys.Add(name, key);
			}
		}
	}
}
