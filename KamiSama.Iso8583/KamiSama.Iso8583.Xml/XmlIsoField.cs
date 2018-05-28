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

		public IsoFieldBase GetIsoField()
		{
			if (Data.StartsWith("bin:"))
				return Data.Substring("bin:".Length).FromHex();
			else if (Data.StartsWith("text:"))
				return Data.Substring("text:".Length);
			else if (Data.StartsWith("bmp:"))
				return BitmapIsoField.FromHex(Data.Substring("bmp:".Length));
			else
				return Data;
		}
	}
}