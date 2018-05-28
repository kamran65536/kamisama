using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace KamiSama.Extenders.Serialization
{
	[Serializable]
	[XmlRoot("item")]
    public class XmlKeyValue<_Key, _Value>
    {
		[XmlAttribute("key")]
		public _Key Key { get; set; }
		[XmlAttribute("value")]
		public _Value Value { get; set; }

		public XmlKeyValue()
		{
		}
		public XmlKeyValue(_Key key, _Value value)
		{
			this.Key = key;
			this.Value = value;
		}

		public static implicit operator XmlKeyValue<_Key, _Value>(KeyValuePair<_Key, _Value> kv)
			=> new XmlKeyValue<_Key, _Value>(kv.Key, kv.Value);
		public static implicit operator KeyValuePair<_Key, _Value>(XmlKeyValue<_Key, _Value> kv)
			=> new KeyValuePair<_Key, _Value>(kv.Key, kv.Value);
	}
}
