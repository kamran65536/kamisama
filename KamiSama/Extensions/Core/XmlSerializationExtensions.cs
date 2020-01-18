using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	public static class XmlSerializationExtensions
	{
		public static string SerializeToXml(this object obj, Action<XmlWriterSettings> settingsAction = null, XmlSerializer serializer = null)
		{
			serializer = serializer ?? new XmlSerializer(obj.GetType());

			var settings = new XmlWriterSettings();

			if (settingsAction != null)
				settingsAction(settings);

			using (var writer = new StringWriter())
			{
				using (var xmlWriter = XmlWriter.Create(writer, settings))
				{
					serializer.Serialize(xmlWriter, obj);
				}

				return writer.ToString();
			}
		}
		public static _ObjectType DeserializeFromXml<_ObjectType>(this string str, XmlSerializer serializer = null)
		{
			serializer = serializer ?? new XmlSerializer(typeof(_ObjectType));

			using (var reader = new StringReader(str))
			{
				return (_ObjectType)serializer.Deserialize(reader);
			}
		}
	}
}