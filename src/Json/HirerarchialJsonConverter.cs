using System.Reflection;

namespace KamiSama.Extensions.Json
{
	/// <summary>
	/// Deserializes instances of a base type as registered derived types selected by a discriminator property.
	/// Mark the base type's discriminator property and register every supported discriminator value before deserialization.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class HierarchicalJsonConverter<T> : JsonConverter<T>
		where T : class
	{
		private static readonly Type type;
		private static readonly string discriminatorMapKeyName;
		private static readonly PropertyInfo discriminatorProperty;
		/// <summary>
		/// map from discriminator key value to child type
		/// </summary>
		internal static readonly Dictionary<string, Type> typeMap = new(StringComparer.InvariantCultureIgnoreCase);
		/// <summary>
		/// Associates a discriminator value with the derived type <typeparamref name="TChild"/>.
		/// </summary>
		/// <typeparam name="TChild"></typeparam>
		/// <param name="discriminatorKeyValue"></param>
		public static void Register<TChild>(string discriminatorKeyValue) where TChild : T
			=> typeMap[discriminatorKeyValue] = typeof(TChild);
		/// <summary>
		/// Registers <typeparamref name="TChild"/> using the discriminator value obtained from a newly constructed instance.
		/// </summary>
		/// <typeparam name="TChild"></typeparam>
		public static void Register<TChild>() where TChild : T, new()
		{
			var instance = new TChild();
			Register<TChild>(discriminatorProperty.GetValue(instance) + "");
		}
		/// <summary>
		/// Associates a discriminator value with the specified runtime type.
		/// </summary>
		/// <param name="discriminatorKeyValue"></param>
		/// <param name="type"></param>
		public static void Register(string discriminatorKeyValue, Type type)
			=> typeMap[discriminatorKeyValue] = type;
		/// <summary>
		/// constructor
		/// </summary>
		static HierarchicalJsonConverter()
		{
			type = typeof(T);


			discriminatorProperty = type
				.GetProperties()
				.FirstOrDefault(x => x.GetCustomAttribute<JsonHirerarchyDiscriminatorAttribute>() != null) 
				?? throw new ArgumentException($"Type {type.Name} does not have a property with JsonDiscriminatorAttribute.");

			var attr = discriminatorProperty.GetCustomAttribute<JsonPropertyNameAttribute>();

			discriminatorMapKeyName = attr?.Name ?? discriminatorProperty.Name;
		}
		/// <summary>
		/// Serializes the value using its runtime type.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="options"></param>
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
			=> JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
		/// <summary>
		/// Deserializes a JSON object as the derived type registered for its discriminator value.
		/// </summary>
		/// <param name="reader">JsonReader</param>
		/// <param name="typeToConvert"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			// Check for null values
			if (reader.TokenType == JsonTokenType.Null)
				return default;

			// Copy the current state from reader (it's a struct)
			var readerAtStart = reader;

			// Read the `discriminator` from our JSON document
			using var jsonDocument = JsonDocument.ParseValue(ref reader);

			var jsonObject = jsonDocument.RootElement;

			if (!jsonObject.TryGetProperty(discriminatorMapKeyName, out JsonElement jsonElement))
				throw new Exception($"{discriminatorMapKeyName} is not found in the json. It is mandatory.");

			var key = jsonElement
				.GetString();

			if (!string.IsNullOrWhiteSpace(key) && typeMap.TryGetValue(key, out Type? type))
				return JsonSerializer.Deserialize(ref readerAtStart, type, options) as T;
			else
				throw new NotSupportedException($"{key ?? "<unknown>"} can not be deserialized");
		}
	}
}
