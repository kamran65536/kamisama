using KamiSama.Extensions;
using System;

namespace KamiSama.Iso8583.Serialization
{
	/// <summary>
	/// Iso Field extensions
	/// </summary>
	public static class IsoFieldExtensions
    {
		/// <summary>
		/// Converts an iso field to serializable form (SerializableIsoField)
		/// </summary>
		/// <param name="field">iso field</param>
		/// <param name="fieldNo">field number</param>
		/// <returns></returns>
		public static SerializableIsoField AsSerializable(this IsoFieldBase field, int fieldNo)
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
