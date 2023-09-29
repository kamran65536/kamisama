using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json
{
	/// <summary>
	/// dynamic object converter is used to covert json elements into object and vise versa
	/// </summary>
	public class DynamicObjectConverter : JsonConverter<object>
	{
		/// <inheritdoc />
		public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
			=> JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
		/// <inheritdoc />
		public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using var doc = JsonDocument.ParseValue(ref reader);

			return doc.RootElement.ConvertJsonToDynamicObject()!;
		}
	}
}
