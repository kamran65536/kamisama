namespace KamiSama.Extensions.Json.Tests;

[TestClass]
public class BitIntegerJsonConverterTests
{
	[TestMethod]
	public void Write_should_serialize_value_to_string()
	{
		var options = new JsonSerializerOptions();
		options.Converters.Add(new BigIntegerJsonConverter());

		var x = new BigInteger(100);
		var result = x.SerializeToJson(options);

		Assert.AreEqual("\"100\"", result);
	}
	[TestMethod]
	public void Read_should_read_string_values()
	{
		var str = "\"100\"";
		var options = new JsonSerializerOptions();
		options.Converters.Add(new BigIntegerJsonConverter());

		var x = str.DeserializeFromJson<BigInteger>(options);

		Assert.AreEqual(100, x);
	}
	[TestMethod]
	public void Read_should_read_number_values()
	{
		var str = "100";
		var options = new JsonSerializerOptions();
		options.Converters.Add(new BigIntegerJsonConverter());

		var x = str.DeserializeFromJson<BigInteger>(options);

		Assert.AreEqual(100, x);
	}
	[TestMethod]
	[ExpectedException(typeof(JsonException))]
	public void Read_throws_exception_if_value_is_neither_string_nor_number()
	{
		var str = "true";
		var options = new JsonSerializerOptions();
		options.Converters.Add(new BigIntegerJsonConverter());

		str.DeserializeFromJson<BigInteger>(options);
	}
	[TestMethod]
	[ExpectedException(typeof(JsonException))]
	public void Read_throws_exception_if_value_is_an_invalid_string()
	{
		var str = "\"abc\"";
		var options = new JsonSerializerOptions();
		options.Converters.Add(new BigIntegerJsonConverter());

		str.DeserializeFromJson<BigInteger>(options);
	}
}

