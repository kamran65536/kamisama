using System.Numerics;

namespace KamiSama.Extensions.Json;

/// <summary>
/// Big Integer Json Converter
/// </summary>
public class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
	/// <inheritdoc />
	public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.TokenType switch
		{
			JsonTokenType.String => BigInteger.TryParse(reader.GetString(), out var x) ? x : throw new JsonException($"cannot parse to BigInteger value from {typeToConvert}"),
			JsonTokenType.Number => new BigInteger(reader.GetDecimal()),
			_ => throw new JsonException($"Does not support token type of {reader.TokenType}")
		};
	/// <inheritdoc />
	public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}
