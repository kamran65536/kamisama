using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Serialization
{
	[Serializable]
	[XmlRoot("message")]
	public class SerializableIsoMessage
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlElement("field")]
		public SerializableIsoField[] Fields { get; set; }

		public static SerializableIsoMessage LoadFromXmlFile(string path)
			=> File.ReadAllText(path).Deserialize<SerializableIsoMessage>();

		public void SaveToXmlFile(string path)
			=> File.WriteAllText(path, this.Serialize(indented: true));

		public IsoMessage GetIsoMessage()
		{
			var result = new IsoMessage(Id);

			foreach (var field in Fields)
				if (field.FieldNo > 1) //skipping bitmap fields
					result[field.FieldNo] = field.GetIsoField();

			return result;
		}
    }
}
