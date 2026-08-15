namespace KamiSama.Extensions.Json;

/// <summary>
/// Converts byte arrays to and from hexadecimal JSON strings.
/// Use it when binary values should be represented as hexadecimal text instead of Base64.
/// </summary>
public class HexByteArrayJsonConverter : JsonConverter<byte[]>
{
	/// <summary>
	/// Reads a hexadecimal JSON string as a byte array, or returns <see langword="null"/> for a null token.
	/// </summary>
	/// <param name="reader"></param>
	/// <param name="typeToConvert"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		// Check for null values
		if (reader.TokenType == JsonTokenType.Null)
			return default;
		else
			return reader.GetString()?.FromHex();
	}
	/// <summary>
	/// Writes the byte array as an uppercase hexadecimal JSON string.
	/// </summary>
	/// <param name="writer"></param>
	/// <param name="value"></param>
	/// <param name="options"></param>
	public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
	{
		if (value == null)
			writer.WriteNullValue();
		else
			writer.WriteStringValue(value.ToHex());
	}
}
