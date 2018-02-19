using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KamiSama.Extenders
{
	public static class XmlSerializationExtender
	{
		#region Serialization

		public static string Serialize(this object obj, bool indented = false)
		{
			using (var writer = new StringWriter())
			{
				obj.Serialize(writer, indented);
				return writer.ToString();
			}
		}
		public static void Serialize(this object obj, TextWriter writer, bool indented = false)
		{
			var serializer = new XmlSerializer(obj.GetType());

			using (var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = indented }))
			{
				serializer.Serialize(xmlWriter, obj);
			}
		}
		public static void Serialize(this object obj, Stream stream, bool indented = false, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8))
			{
				obj.Serialize(writer, indented);
			}
		}

		public static void Serialize(this object obj, FileInfo fileInfo, bool indented = false, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(fileInfo.FullName, false, encoding ?? Encoding.UTF8))
			{
				obj.Serialize(writer, indented);
			}
		}
		#endregion

		#region Deserialization

		public static _ObjectType Deserialize<_ObjectType>(this string str)
		{
			using (var reader = new StringReader(str))
			{
				return reader.Deserialize<_ObjectType>();
			}
		}

		public static _ObjectType Deserialize<_ObjectType>(this TextReader reader)
		{
			var serializer = new XmlSerializer(typeof(_ObjectType));

			return (_ObjectType)serializer.Deserialize(reader);
		}

		public static _ObjectType Deserialize<_ObjectType>(this Stream stream, Encoding encoding = null)
		{
			using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
			{
				return reader.Deserialize<_ObjectType>();
			}
		}

		public static _ObjectType Deserialize<_ObjectType>(this FileInfo fileInfo, Encoding encoding = null)
		{
			using (var reader = new StreamReader(fileInfo.FullName, encoding ?? Encoding.UTF8))
			{
				return reader.Deserialize<_ObjectType>();
			}
		}
		#endregion
	}
}