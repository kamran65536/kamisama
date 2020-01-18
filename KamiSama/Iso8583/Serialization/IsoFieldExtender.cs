using System;
using KamiSama.Extenders;

namespace KamiSama.Iso8583.Serialization
{
	public static class IsoFieldExtender
    {
		public static SerializableIsoField GetSerializableField(this IsoFieldBase field, int fieldNo)
		{
			if (field == null)
				throw new NullReferenceException($"Field {fieldNo} is null.");
			if (field is StringIsoField stringIsoField)
				return new SerializableIsoField { FieldNo = fieldNo, Type = SerializableIsoFieldType.String, Data = stringIsoField.Data };
			else if (field is BinaryIsoField rawIsoField)
				return new SerializableIsoField { FieldNo = fieldNo, Type = SerializableIsoFieldType.BinaryHex, Data = rawIsoField.Data.ToHex() };
			else if (field is BitmapIsoField isoBitmap)
				return new SerializableIsoField { FieldNo = fieldNo, Type = SerializableIsoFieldType.BitmapHex, Data = isoBitmap.GetBitmapHex() };
			else
				throw new NotSupportedException($"Field type {field.GetType()} is not supported.");
		}
    }
}
