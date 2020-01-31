using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using KamiSama.Extensions;

namespace KamiSama.Iso8583.Serialization
{
	/// <summary>
	/// Serializable Iso Field
	/// </summary>
	[Serializable]
	public class SerializableIsoField
	{
		/// <summary>
		/// Field Number
		/// </summary>
		[XmlAttribute("no")]
		public int FieldNo { get; set; }
		/// <summary>
		/// Field Data (if binary, the value is hexadecimal)
		/// </summary>
		[XmlText]
		public string Data { get; set; }
		/// <summary>
		/// Serializable Iso Field Type, default is String
		/// </summary>
		[XmlAttribute("type")]
		public SerializableIsoFieldType Type { get; set; } = SerializableIsoFieldType.String;
		/// <summary>
		/// returns original iso field
		/// </summary>
		/// <returns></returns>
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