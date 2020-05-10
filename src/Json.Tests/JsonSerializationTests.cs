using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace KamiSama.Extensions.Json.Tests
{
	[TestClass]
	public class JsonSerializationTests
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

			StringAssert.Contains(result, "{");
			StringAssert.Contains(result, @"""X"":");
			StringAssert.Contains(result, "10");
			StringAssert.Contains(result, "}");
		}
		[TestMethod]
		public void SerializeToJson_must_configure_if_it_is_null()
		{
			var a = new A { X = 10 };

			var result = a.SerializeToJson(configure: null);

			StringAssert.Contains(result, "{");
			StringAssert.Contains(result, @"""X"":");
			StringAssert.Contains(result, "10");
			StringAssert.Contains(result, "}");
		}
		[TestMethod]
		public void SerializeToJson_must_use_options_if_any()
		{
			var a = new A { X = 10 };

			var result = a.SerializeToJson(new JsonSerializerOptions
			{
				WriteIndented = true
			});

			StringAssert.Contains(result, "{");
			StringAssert.Contains(result, @" ""X"":");
			StringAssert.Contains(result, "10");
			StringAssert.Contains(result, "}");
		}
		[TestMethod]
		public void SerializeToJson_must_use_optionsFunc_if_any()
		{
			var a = new A { X = 10 };

			var result = a.SerializeToJson(opt => opt.WriteIndented = true);

			StringAssert.Contains(result, "{");
			StringAssert.Contains(result, @" ""X"":");
			StringAssert.Contains(result, "10");
			StringAssert.Contains(result, "}");
		}
		[TestMethod]
		public void DeserializeFromJson_must_deserialize_object_from_string()
		{
			var str = "{\"X\":10}";

			var result = str.DeserializeFromJson<A>();

			Assert.AreEqual(10, result.X);
		}
		[TestMethod]
		public void DeserializeFromJson_must_ignore_configure_if_it_is_null()
		{
			var str = "{\"X\":10}";

			var result = str.DeserializeFromJson<A>(configure: null);

			Assert.AreEqual(10, result.X);
		}
		[TestMethod]
		public void DeserializeFromJson_must_use_options_if_any()
		{
			var str = "{\"X\":10,}";

			var result = str.DeserializeFromJson<A>(new JsonSerializerOptions
			{
				AllowTrailingCommas = true
			});

			Assert.AreEqual(10, result.X);
		}
		[TestMethod]
		public void DeserializeFromJson_must_use_optionsFunc_if_any()
		{
			var str = "{\"X\":10,}";

			var result = str.DeserializeFromJson<A>(opt => opt.AllowTrailingCommas = true);

			Assert.AreEqual(10, result.X);
		}
	}
}
