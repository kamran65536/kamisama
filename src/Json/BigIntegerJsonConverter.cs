using System.Numerics;

namespace KamiSama.Extensions.Json;

/// <summary>
/// Converts <see cref="BigInteger"/> values to and from JSON, writing values as decimal strings.
/// String tokens preserve arbitrary precision; numeric tokens are limited to the <see cref="decimal"/> range.
/// </summary>
public class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
	/// <summary>
	/// Reads a <see cref="BigInteger"/> from a JSON string or number token.
	/// </summary>
	public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.TokenType switch
		{
			JsonTokenType.String => BigInteger.TryParse(reader.GetString(), out var x) ? x : throw new JsonException($"cannot parse to BigInteger value from {typeToConvert}"),
			JsonTokenType.Number => new BigInteger(reader.GetDecimal()),
			_ => throw new JsonException($"Does not support token type of {reader.TokenType}")
		};
	/// <summary>
	/// Writes the <see cref="BigInteger"/> as a JSON string containing its decimal representation.
	/// </summary>
	public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}
