using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KamiSama.Extenders.Serialization
{
	[XmlRoot("Dictionary")]
	public class XmlDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
	{
		#region Constructors
		public XmlDictionary()
		{
		}

		public XmlDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
		{
		}

		public XmlDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
		{
		}

		public XmlDictionary(int capacity) : base(capacity)
		{
		}

		public XmlDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer)
		{
		}

		public XmlDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
		{
		}

		protected XmlDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		} 
		#endregion
		#region IXmlSerializable Members
		public XmlSchema GetSchema()
		{
			return null;
		}
		public void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement();

			var serializer = new XmlSerializer(typeof(XmlKeyValue<TKey, TValue>));

			while (reader.NodeType != XmlNodeType.EndElement)
			{
				var item = serializer.Deserialize(reader) as XmlKeyValue<TKey, TValue>;
				this.Add(item.Key, item.Value);
			}

			reader.ReadEndElement();
		}
		public void WriteXml(XmlWriter writer)
		{
			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add("", "");

			var serializer = new XmlSerializer(typeof(XmlKeyValue<TKey, TValue>));

			foreach (var item in this)
				serializer.Serialize(writer, (XmlKeyValue<TKey, TValue>) item, namespaces);
		}
		#endregion
	}
}
