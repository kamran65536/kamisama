using System.IO;
using System.Text;
using System.Text.Json;

namespace KamiSama.Extensions
{
	public static class JsonSerializationExtensions
	{
		#region Serialization

		public static string SerializeToJson(this object obj, JsonSerializerOptions options = null)
			=> JsonSerializer.Serialize(obj, options);

		public static void SerializeToJson(this object obj, TextWriter writer, JsonSerializerOptions options = null)
			=> writer.Write(obj.SerializeToJson(options));
		public static void SerializeToJson(this object obj, Stream stream, JsonSerializerOptions options = null, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8))
				obj.SerializeToJson(writer);
		}
		public static void SerializeToJson(this object obj, FileInfo fileInfo, JsonSerializerOptions options = null, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(fileInfo.FullName, false, encoding ?? Encoding.UTF8))
				obj.SerializeToJson(writer, options);
		}
		#endregion
		#region Deserialization

		public static _ObjectType DeserializeFromJson<_ObjectType>(this string str)
			=> JsonSerializer.Deserialize<_ObjectType>(str);
		public static _ObjectType DeserializeFromJson<_ObjectType>(this TextReader reader)
			=> reader.ReadToEnd().DeserializeFromJson<_ObjectType>();
		public static _ObjectType DeserializeFromJson<_ObjectType>(this Stream stream, Encoding encoding = null)
		{
			using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
				return reader.DeserializeFromJson<_ObjectType>();
		}
		public static _ObjectType DeserializeFromJson<_ObjectType>(this FileInfo fileInfo, Encoding encoding = null)
		{
			using (var reader = new StreamReader(fileInfo.FullName, encoding ?? Encoding.UTF8))
				return reader.DeserializeFromJson<_ObjectType>();
		}
		#endregion
	}
}