using KamiSama.Extensions.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
		public static string SerializeToJson(this object obj, JsonSerializerOptions? options = null)
			=> JsonSerializer.Serialize(obj, options);
		/// <summary>
		/// Converts an element to dynamic object (using expando object)
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static object? ConvertJsonToDynamicObject(this JsonElement element)
		{
			switch (element.ValueKind)
			{
				default:
				case JsonValueKind.Undefined:
				case JsonValueKind.Null: return null;
				case JsonValueKind.Object:

					var obj = new ExpandoObject();

					var dic = obj as IDictionary<string, object?>;

					foreach (var item in element.EnumerateObject())
					{
						var value = ConvertJsonToDynamicObject(item.Value);

						dic[item.Name] = value;
					}

					return obj;
				case JsonValueKind.Array:
					List<object> result = new();

					foreach (var item in element.EnumerateArray())
						result.Add(ConvertJsonToDynamicObject(item)!);

					return result.ToArray();
				case JsonValueKind.String: return element.GetString();
				case JsonValueKind.Number: 
					var d = element.GetDouble();

					if ((int)d == d)
						return (int)d;
					else
						return d;
				case JsonValueKind.True:
				case JsonValueKind.False: return element.GetBoolean();
			}
		}
		/// <summary>
		/// Converts an json string to dynamic object (using expando object)
		/// </summary>
		/// <param name="jsonStr"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static object? ConvertJsonToDynamicObject(this string jsonStr, JsonDocumentOptions options = default)
		{
			var doc = JsonDocument.Parse(jsonStr, options);

			return doc.RootElement.ConvertJsonToDynamicObject();
		}
		/// <summary>
		/// Converts an json string to dynamic object (using expando object)
		/// </summary>
		/// <param name="jsonStr"></param>
		/// <param name="config"></param>
		/// <returns></returns>
		public static object? ConvertJsonToDynamicObject(this string jsonStr, Action<JsonDocumentOptions> config)
		{
			var options = new JsonDocumentOptions();

			config?.Invoke(options);

			return jsonStr.ConvertJsonToDynamicObject(options);
		}
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
		public static TObject? DeserializeFromJson<TObject>(this string str, JsonSerializerOptions? options = null)
			=> JsonSerializer.Deserialize<TObject>(str, options);
		/// <summary>
		/// Deserializes from json string using <see cref="JsonSerializer"/>
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="str"></param>
		/// <param name="configure">configure action</param>
		/// <returns></returns>
		public static TObject? DeserializeFromJson<TObject>(this string str, Action<JsonSerializerOptions> configure)
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
		/// Adds a hierarchical converter based on <see cref="HierarchicalJsonConverter{T}"/> to the options
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="options"></param>
		/// <returns></returns>
		public static JsonSerializerOptions AddHierarchicalConverter<T>(this JsonSerializerOptions options)
			where T : class
		{
			options.Converters.Add(new HierarchicalJsonConverter<T>());
			return options;
		}
		/// <summary>
		/// Adds TimeSpanJsonConverter as default converter for json
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		public static JsonSerializerOptions AddTimeSpanJsonConverter(this JsonSerializerOptions options)
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