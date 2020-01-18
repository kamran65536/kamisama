using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Serialization
{
	[Serializable]
	public class SerializableIsoField
	{
		[XmlAttribute("no")]
		public int FieldNo { get; set; }
		[XmlText]
		public string Data { get; set; }
		[XmlAttribute("type")]
		public SerializableIsoFieldType Type { get; set; } = SerializableIsoFieldType.String;

		public IsoFieldBase GetIsoField()
		{
			switch (Type)
			{
				default:
					throw new NotSupportedException($"Type {Type} is not supporte.");
				case SerializableIsoFieldType.String:
					return new StringIsoField { Data = Data };
				case SerializableIsoFieldType.BinaryHex:
					return new BinaryIsoField { Data = Data.FromHex() };
				case SerializableIsoFieldType.BitmapHex:
					return BitmapIsoField.FromHex(Data);
			}
		}
	}
}