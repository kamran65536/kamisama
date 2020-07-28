using KamiSama.Extensions.Json;
using System;
using System.Text.Json;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Json Serialization Extensions
	/// </summary>
	public static class JsonSerializationExtensions
	{
		/// <summary>
		/// Serializes to Json using <see cref="JsonSerializer"/>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static string SerializeToJson(this object obj, JsonSerializerOptions options = null)
			=> JsonSerializer.Serialize(obj, options);
		/// <summary>
		/// Serializes to Json using <see cref="JsonSerializer"/>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="configure"></param>
		/// <returns></returns>
		public static string SerializeToJson(this object obj, Action<JsonSerializerOptions> configure)
		{
			if (configure != null)
			{
				var options = new JsonSerializerOptions();
				configure(options);

				return JsonSerializer.Serialize(obj, options);
			}
			else
				return JsonSerializer.Serialize(obj);
		}
		/// <summary>
		/// Deserializes from json string using <see cref="JsonSerializer"/>
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="str"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static TObject DeserializeFromJson<TObject>(this string str, JsonSerializerOptions options = null)
			=> JsonSerializer.Deserialize<TObject>(str, options);
		/// <summary>
		/// Deserializes from json string using <see cref="JsonSerializer"/>
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="str"></param>
		/// <param name="configure">configure action</param>
		/// <returns></returns>
		public static TObject DeserializeFromJson<TObject>(this string str, Action<JsonSerializerOptions> configure)
		{
			if (configure != null)
			{
				var options = new JsonSerializerOptions();
				configure(options);

				return JsonSerializer.Deserialize<TObject>(str, options);
			}
			else
				return JsonSerializer.Deserialize<TObject>(str);
		}
		/// <summary>
		/// Adds a hirarchial converter based on <see cref="HirerarchialJsonConverter{T}"/> to the options
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="options"></param>
		/// <returns></returns>
		public static JsonSerializerOptions AddHirerarchialConverter<T>(this JsonSerializerOptions options)
			where T : class
		{
			options.Converters.Add(new HirerarchialJsonConverter<T>());
			return options;
		}
		/// <summary>
		/// Adds TimeSpanJsonConverter as default converter for json
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		public static JsonSerializerOptions AddTimeSpanJsonConveter(this JsonSerializerOptions options)
		{
			options.Converters.Add(new TimeSpanJsonConverter());

			return options;
		}
		/// <summary>
		/// Adds TimeSpanJsonConverter as default converter for json
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		public static JsonSerializerOptions AddHexByteConverter(this JsonSerializerOptions options)
		{
			options.Converters.Add(new HexByteArrayJsonConverter());

			return options;
		}
	}
}