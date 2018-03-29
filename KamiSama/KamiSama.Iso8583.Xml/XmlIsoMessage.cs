using System;
using System.IO;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Xml
{
	[Serializable]
	public class XmlIsoMessage
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlElement("field")]
		public XmlIsoField[] Fields { get; set; }

		public static XmlIsoMessage LoadFromFile(string path)
			=> File.ReadAllText(path).Deserialize<XmlIsoMessage>();

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
