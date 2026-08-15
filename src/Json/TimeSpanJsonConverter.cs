namespace KamiSama.Extensions.Json;

/// <summary>
/// Converts <see cref="TimeSpan"/> values to and from their standard JSON string representation.
/// Use it when an application needs this package's explicit string-format compatibility behavior.
/// </summary>
public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
{
	/// <summary>
	/// Reads a JSON string token and parses it as a <see cref="TimeSpan"/>.
	/// </summary>
	/// <param name="reader"></param>
	/// <param name="typeToConvert"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> TimeSpan.Parse(reader.GetString()!);
	/// <summary>
	/// Writes the <see cref="TimeSpan"/> as a JSON string using its standard representation.
	/// </summary>
	/// <param name="writer"></param>
	/// <param name="value"></param>
	/// <param name="options"></param>
	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString());
}
