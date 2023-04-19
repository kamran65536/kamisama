using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json
{
	/// <summary>
	/// Hexadecimal byte array
	/// </summary>
	public class HexByteArrayJsonConverter : JsonConverter<byte[]>
	{
		/// <summary>
		/// Reads hex value as byte array from input
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
		/// Writes byte array as hex to output
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
}
