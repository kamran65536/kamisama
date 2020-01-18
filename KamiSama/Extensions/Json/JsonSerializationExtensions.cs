using System.Text.Json;

namespace KamiSama.Extensions
{
	public static class JsonSerializationExtensions
	{
		public static string SerializeToJson(this object obj, JsonSerializerOptions options = null)
			=> JsonSerializer.Serialize(obj, options);
		public static _ObjectType DeserializeFromJson<_ObjectType>(this string str, JsonSerializerOptions options = null)
			=> JsonSerializer.Deserialize<_ObjectType>(str, options);
	}
}