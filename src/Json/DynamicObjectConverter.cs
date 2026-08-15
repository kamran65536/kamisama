namespace KamiSama.Extensions.Json;

/// <summary>
/// Converts JSON values to dynamic CLR object graphs and serializes runtime object values back to JSON.
/// Objects become <c>ExpandoObject</c> instances, while arrays and scalar values use their corresponding CLR shapes.
/// </summary>
public class DynamicObjectConverter : JsonConverter<object>
{
	/// <summary>
	/// Serializes the value using its runtime type.
	/// </summary>
	public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
		=> JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
	/// <summary>
	/// Reads a JSON value and converts it to an <c>ExpandoObject</c>, array, scalar value, or <see langword="null"/>.
	/// </summary>
	public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		using var doc = JsonDocument.ParseValue(ref reader);

		return doc.RootElement.ConvertJsonToDynamicObject()!;
	}
}
