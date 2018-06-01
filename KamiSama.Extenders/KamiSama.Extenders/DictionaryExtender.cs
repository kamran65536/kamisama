using System.Collections.Generic;

namespace KamiSama.Extenders
{
	public static class DictionaryExtender
    {
		public static void AddOrUpdate<_KeyType, _ValueType>(this Dictionary<_KeyType, _ValueType> dictionary, _KeyType key, _ValueType value)
		{
			if (dictionary.ContainsKey(key))
				dictionary[key] = value;
			else
				dictionary.Add(key, value);
		}
    }
}
