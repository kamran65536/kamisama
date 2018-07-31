using System;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Xml
{
	[Serializable]
	public class XmlIsoField
	{
		[XmlAttribute("no")]
		public int FieldNo { get; set; }
		[XmlText]
		public string Data { get; set; }
		[XmlAttribute("type")]
		public XmlIsoFieldType Type { get; set; } = XmlIsoFieldType.String;

		public IsoFieldBase GetIsoField()
		{
			switch (Type)
			{
				default:
					throw new NotSupportedException($"Type {Type} is not supporte.");
				case XmlIsoFieldType.String:
					return new StringIsoField { Data = Data };
				case XmlIsoFieldType.BinaryHex:
					return new BinaryIsoField { Data = Data.FromHex() };
				case XmlIsoFieldType.BitmapHex:
					return BitmapIsoField.FromHex(Data);
			}
		}
	}
}