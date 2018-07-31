using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Xml
{
	[Serializable]
	[XmlRoot("message")]
	public class XmlIsoMessage
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlElement("field")]
		public XmlIsoField[] Fields { get; set; }

		public static XmlIsoMessage LoadFromXmlFile(string path)
			=> File.ReadAllText(path).Deserialize<XmlIsoMessage>();

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
