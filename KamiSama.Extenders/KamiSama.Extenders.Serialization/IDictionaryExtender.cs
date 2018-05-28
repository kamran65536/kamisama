using System.Collections.Generic;

namespace KamiSama.Extenders.Serialization
{
	public static class IDictionaryExtender
    {
		public static XmlDictionary<_Key, _Value> ToXmlDictionary<_Key, _Value>(IDictionary<_Key, _Value> dictionary)
			=> new XmlDictionary<_Key, _Value>(dictionary);
    }
}
