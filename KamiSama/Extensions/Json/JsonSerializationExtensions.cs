using System.Text.Json;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Json Serialization Extensions
	/// </summary>
	public static class JsonSerializationExtensions
	{
		/// <summary>
		/// Serializes to Json using System.Text.Json
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static string SerializeToJson(this object obj, JsonSerializerOptions options = null)
			=> JsonSerializer.Serialize(obj, options);
		/// <summary>
		/// Deserializes from json string using System.Text.Json
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="str"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static TObject DeserializeFromJson<TObject>(this string str, JsonSerializerOptions options = null)
			=> JsonSerializer.Deserialize<TObject>(str, options);
	}
}