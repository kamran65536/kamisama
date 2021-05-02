using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Xml Serialization Extensions
	/// </summary>
	public static class XmlSerializationExtensions
	{
		/// <summary>
		/// Serializes the object into Xml using XmlSerializer
		/// </summary>
		/// <param name="obj">object to be serialied</param>
		/// <param name="settingsAction">action to configure xml serializer</param>
		/// <param name="serializer">the custom xml serializer, default is null and new xml serializer will be created</param>
		/// <returns></returns>
		public static string SerializeToXml(this object obj, Action<XmlWriterSettings> settingsAction = null, XmlSerializer serializer = null)
		{
			serializer ??= new XmlSerializer(obj.GetType());

			var settings = new XmlWriterSettings();

			settingsAction?.Invoke(settings);

			using var writer = new StringWriter();
			using (var xmlWriter = XmlWriter.Create(writer, settings))
			{
				serializer.Serialize(xmlWriter, obj);
			}

			return writer.ToString();
		}
		/// <summary>
		/// Deserializes a string into an object
		/// </summary>
		/// <typeparam name="TObject">result object type</typeparam>
		/// <param name="str">string to be deserialized</param>
		/// <param name="serializer">the custom xml serializer, default is null and new xml serializer will be created</param>
		/// <returns></returns>
		public static TObject DeserializeFromXml<TObject>(this string str, XmlSerializer serializer = null)
		{
			serializer ??= new XmlSerializer(typeof(TObject));

			using var reader = new StringReader(str);

			return (TObject)serializer.Deserialize(reader);
		}
	}
}