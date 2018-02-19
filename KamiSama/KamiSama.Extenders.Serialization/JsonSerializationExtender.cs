using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace KamiSama.Extenders
{
	public static class JsonSerializationExtender
	{
		#region Serialization

		public static string SerializeToJson(this object obj, Formatting formatting = Formatting.None)
			=> JsonConvert.SerializeObject(obj, formatting);

		public static void SerializeToJson(this object obj, TextWriter writer, Formatting formatting = Formatting.None)
			=> writer.Write(obj.SerializeToJson(formatting));
		public static void SerializeToJson(this object obj, Stream stream, Formatting formatting = Formatting.None, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8))
			{
				obj.SerializeToJson(writer, formatting);
			}
		}

		public static void SerializeToJson(this object obj, FileInfo fileInfo, Formatting formatting = Formatting.None, Encoding encoding = null)
		{
			using (var writer = new StreamWriter(fileInfo.FullName, false, encoding ?? Encoding.UTF8))
			{
				obj.SerializeToJson(writer, formatting);
			}
		}
		#endregion
		#region Deserialization

		public static _ObjectType DeserializeFromJson<_ObjectType>(this string str)
			=> JsonConvert.DeserializeObject<_ObjectType>(str);

		public static _ObjectType DeserializeFromJson<_ObjectType>(this TextReader reader)
			=> reader.ReadToEnd().DeserializeFromJson<_ObjectType>();

		public static _ObjectType DeserializeFromJson<_ObjectType>(this Stream stream, Encoding encoding = null)
		{
			using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
			{
				return reader.DeserializeFromJson<_ObjectType>();
			}
		}
		public static _ObjectType DeserializeFromJson<_ObjectType>(this FileInfo fileInfo, Encoding encoding = null)
		{
			using (var reader = new StreamReader(fileInfo.FullName, encoding ?? Encoding.UTF8))
			{
				return reader.DeserializeFromJson<_ObjectType>();
			}
		}
		#endregion
	}
}