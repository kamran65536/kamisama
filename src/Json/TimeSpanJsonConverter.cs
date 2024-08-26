namespace KamiSama.Extensions.Json;

/// <summary>
/// Time Span converter for system.text.json as it sucks displaying timespan values by now!
/// </summary>
public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
{
	/// <summary>
	/// parses string as timespan
	/// </summary>
	/// <param name="reader"></param>
	/// <param name="typeToConvert"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> TimeSpan.Parse(reader.GetString()!);
	/// <summary>
	/// Writes timespan string
	/// </summary>
	/// <param name="writer"></param>
	/// <param name="value"></param>
	/// <param name="options"></param>
	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString());
}
