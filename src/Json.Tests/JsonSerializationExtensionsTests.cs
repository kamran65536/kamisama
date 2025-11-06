namespace KamiSama.Extensions.Json.Tests;

[TestClass]
public class JsonSerializationExtensionsTests
{
	public class A
	{
		public int X { get; set; }
	}

	[TestMethod]
	public void SerializeToJson_must_serialize_object_to_Json()
	{
		var a = new A { X = 10 };

		var result = a.SerializeToJson();

		Assert.Contains("{", result);
		Assert.Contains(@"""X"":", result);
		Assert.Contains("10", result);
		Assert.Contains("}", result);
	}
	[TestMethod]
	public void SerializeToJson_must_configure_if_it_is_null()
	{
		var a = new A { X = 10 };

		var result = a.SerializeToJson(configure: null);

		Assert.Contains("{", result);
		Assert.Contains(@"""X"":", result);
		Assert.Contains("10", result);
		Assert.Contains("}", result);
	}
	[TestMethod]
	public void SerializeToJson_must_use_options_if_any()
	{
		var a = new A { X = 10 };

		var result = a.SerializeToJson(new JsonSerializerOptions
		{
			WriteIndented = true
		});

		Assert.Contains("{", result);
		Assert.Contains(@" ""X"":", result);
		Assert.Contains("10", result);
		Assert.Contains("}", result);
	}
	[TestMethod]
	public void SerializeToJson_must_use_optionsFunc_if_any()
	{
		var a = new A { X = 10 };

		var result = a.SerializeToJson(opt => opt.WriteIndented = true);

		Assert.Contains("{", result);
		Assert.Contains(@" ""X"":", result);
		Assert.Contains("10", result);
		Assert.Contains("}", result);
	}
	[TestMethod]
	public void DeserializeFromJson_must_deserialize_object_from_string()
	{
		var str = "{\"X\":10}";

		var result = str.DeserializeFromJson<A>()!;

		Assert.AreEqual(10, result.X);
	}
	[TestMethod]
	public void DeserializeFromJson_must_ignore_configure_if_it_is_null()
	{
		var str = "{\"X\":10}";

		var result = str.DeserializeFromJson<A>(configure: null);

		Assert.AreEqual(10, result!.X);
	}
	[TestMethod]
	public void DeserializeFromJson_must_use_options_if_any()
	{
		var str = "{\"X\":10,}";

		var result = str.DeserializeFromJson<A>(new JsonSerializerOptions
		{
			AllowTrailingCommas = true
		})!;

		Assert.AreEqual(10, result.X);
	}
	[TestMethod]
	public void DeserializeFromJson_must_use_optionsFunc_if_any()
	{
		var str = "{\"X\":10,}";

		var result = str.DeserializeFromJson<A>(opt => opt.AllowTrailingCommas = true)!;

		Assert.AreEqual(10, result.X);
	}
	[TestMethod]
	public void AddHirerarchialConverter_must_add_AddHirerarchialConverter_to_options_Converters()
	{
		var options = new JsonSerializerOptions();

		Assert.IsFalse(options.Converters.Any(x => x is HierarchicalJsonConverter<SampleBaseClass>));
		options.AddHierarchicalConverter<SampleBaseClass>();
		Assert.IsTrue(options.Converters.Any(x => x is HierarchicalJsonConverter<SampleBaseClass>));
	}
	[TestMethod]
	public void TimeSpanJsonConverter_must_add_TimeSpanJsonConverter_to_options_Converters()
	{
		var options = new JsonSerializerOptions();

		Assert.IsFalse(options.Converters.Any(x => x is TimeSpanJsonConverter));
		options.AddTimeSpanJsonConverter();
		Assert.IsTrue(options.Converters.Any(x => x is TimeSpanJsonConverter));
	}
	[TestMethod]
	public void AddHexByteConverter_must_add_HexByteConverter_to_options_Converters()
	{
		var options = new JsonSerializerOptions();

		Assert.IsFalse(options.Converters.Any(x => x is HexByteArrayJsonConverter));
		options.AddHexByteConverter();
		Assert.IsTrue(options.Converters.Any(x => x is HexByteArrayJsonConverter));
	}
	[TestMethod]
	public void ConvertToDynamicObject_must_convert_an_jsonString_to_ExpandoObject()
	{
		var str = @"{ ""x"" : 10.0, ""y"": { ""a"" : ""kamran""}, ""z"" : [ 1.1, 2, null, true, false ]}";

		dynamic d = str.ConvertJsonToDynamicObject(opt => opt.MaxDepth = 100)!;

		Assert.AreEqual(10, d.x);
		Assert.AreEqual("kamran", d.y.a);
		Assert.AreEqual(1.1, d.z[0]);
		Assert.AreEqual(2, d.z[1]);
		Assert.IsNull(d.z[2]);
		Assert.IsTrue(d.z[3]);
		Assert.IsFalse(d.z[4]);
	}
	[TestMethod]
	public void ConvertToDynamicObject_must_convert_an_jsonString_to_ExpandoObject_for_null_config_action()
	{
		var str = @"{ ""x"" : 10, ""y"": { ""a"" : ""kamran""}, ""z"" : [ 1, 2, null, true, false ]}";

		dynamic d = str.ConvertJsonToDynamicObject(null as Action<JsonDocumentOptions>)!;

		Assert.AreEqual(10, d.x);
		Assert.AreEqual("kamran", d.y.a);
		Assert.AreEqual(1, d.z[0]);
		Assert.AreEqual(2, d.z[1]);
		Assert.IsNull(d.z[2]);
		Assert.IsTrue(d.z[3]);
		Assert.IsFalse(d.z[4]);
	}
}
