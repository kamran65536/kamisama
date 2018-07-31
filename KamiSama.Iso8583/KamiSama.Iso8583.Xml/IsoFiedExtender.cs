using System;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Xml
{
	public static class IsoFiedExtender
    {
		public static XmlIsoField GetXmlIsoField(this IsoFieldBase field, int fieldNo)
		{
			if (field == null)
				throw new NullReferenceException($"Field {fieldNo} is null.");
			if (field is StringIsoField stringIsoField)
				return new XmlIsoField { FieldNo = fieldNo, Type = XmlIsoFieldType.String, Data = stringIsoField.Data };
			else if (field is BinaryIsoField rawIsoField)
				return new XmlIsoField { FieldNo = fieldNo, Type = XmlIsoFieldType.BinaryHex, Data = rawIsoField.Data.ToHex() };
			else if (field is BitmapIsoField isoBitmap)
				return new XmlIsoField { FieldNo = fieldNo, Type = XmlIsoFieldType.BitmapHex, Data = isoBitmap.GetBitmapHex() };
			else
				throw new NotSupportedException($"Field type {field.GetType()} is not supported.");
		}
    }
}
