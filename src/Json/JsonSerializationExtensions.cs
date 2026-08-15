using KamiSama.Extensions.Json;
using System.Dynamic;

namespace KamiSama.Extensions;

/// <summary>
/// Provides extensions for JSON serialization, deserialization, dynamic conversion, and converter registration.
/// The registration helpers mutate and return the supplied <see cref="JsonSerializerOptions"/> instance.
/// </summary>
public static class JsonSerializationExtensions
{
	/// <summary>
	/// Serializes the object to JSON using <see cref="JsonSerializer"/> and the supplied options.
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public static string SerializeToJson(this object obj, JsonSerializerOptions? options = null)
		=> JsonSerializer.Serialize(obj, options);
	/// <summary>
	/// Converts a JSON element to an <c>ExpandoObject</c>, object array, scalar CLR value, or <see langword="null"/>.
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
				List<object> result = [];

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
	/// Parses a JSON string with the specified document options and converts it to a dynamic CLR object graph.
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
	/// Parses a JSON string using configured document options and converts it to a dynamic CLR object graph.
	/// </summary>
	/// <param name="jsonStr"></param>
	/// <param name="config"></param>
	/// <returns></returns>
	public static object? ConvertJsonToDynamicObject(this string jsonStr, Action<JsonDocumentOptions>? config)
	{
		var options = new JsonDocumentOptions();

		config?.Invoke(options);

		return jsonStr.ConvertJsonToDynamicObject(options);
	}
	/// <summary>
	/// Serializes the object to JSON using serializer options configured by the supplied callback.
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="configure"></param>
	/// <returns></returns>
	public static string SerializeToJson(this object? obj, Action<JsonSerializerOptions>? configure)
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
	/// Deserializes the JSON string as <typeparamref name="TObject"/> using the supplied options.
	/// </summary>
	/// <typeparam name="TObject"></typeparam>
	/// <param name="str"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public static TObject? DeserializeFromJson<TObject>(this string str, JsonSerializerOptions? options = null)
		=> JsonSerializer.Deserialize<TObject>(str, options);
	/// <summary>
	/// Deserializes the JSON string as <typeparamref name="TObject"/> using options configured by the supplied callback.
	/// </summary>
	/// <typeparam name="TObject"></typeparam>
	/// <param name="str"></param>
	/// <param name="configure">configure action</param>
	/// <returns></returns>
	public static TObject? DeserializeFromJson<TObject>(this string str, Action<JsonSerializerOptions>? configure)
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
	/// Adds a <see cref="HierarchicalJsonConverter{T}"/> to these serializer options.
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
	/// Adds a <see cref="TimeSpanJsonConverter"/> to these serializer options.
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public static JsonSerializerOptions AddTimeSpanJsonConverter(this JsonSerializerOptions options)
	{
		options.Converters.Add(new TimeSpanJsonConverter());

		return options;
	}
	/// <summary>
	/// Adds a <see cref="HexByteArrayJsonConverter"/> to these serializer options.
	/// </summary>
	/// <param name="options"></param>
	/// <returns></returns>
	public static JsonSerializerOptions AddHexByteConverter(this JsonSerializerOptions options)
	{
		options.Converters.Add(new HexByteArrayJsonConverter());

		return options;
	}
}
