using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json.Tests
{
	public class A
	{
		[JsonConverter(typeof(HexByteArrayJsonConverter))]
		public byte[] Arr { get; set; }
	}
	[TestClass]
	public class HexByteArrayJsonConverterTests
	{
		[TestMethod]
		public void Read_must_read_hex_string_as_byte_array()
		{
			var str = @"""0102030405""";

			var arr = str.DeserializeFromJson<byte[]>(options => options.Converters.Add(new HexByteArrayJsonConverter()));

			CollectionAssert.AreEqual(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 }, arr);
		}
		[TestMethod]
		public void Read_must_read_hex_string_as_byte_array_for_properties()
		{
			var str = @"{ ""Arr"" : ""0102030405"" }";

			var a = str.DeserializeFromJson<A>();

			CollectionAssert.AreEqual(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 }, a.Arr);
		}
		[TestMethod]
		public void Read_must_read_null_as_null_byte_array()
		{
			var arr = "null".DeserializeFromJson<byte[]>(options => options.Converters.Add(new HexByteArrayJsonConverter()));

			Assert.IsNull(arr);
		}
		[TestMethod]
		public void Read_must_read_null_as_null_byte_array_for_properties()
		{
			var str1 = @"{ ""Arr"" : null }";
			var str2 = @"{ }";

			var a1 = str1.DeserializeFromJson<A>();
			var a2 = str2.DeserializeFromJson<A>();

			Assert.IsNull(a1.Arr);
			Assert.IsNull(a2.Arr);
		}
		[TestMethod]
		public void Write_must_write_byte_array_as_hex_value()
		{
			var arr = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };

			var str = arr.SerializeToJson(options => options.Converters.Add(new HexByteArrayJsonConverter()));

			Assert.IsTrue(str.Contains(@"""0102030405"""));
		}
		[TestMethod]
		public void Write_must_write_byte_array_as_hex_value_for_properties()
		{
			var a = new A { Arr = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 } };

			var str = a.SerializeToJson();

			Assert.IsTrue(str.Contains(@"""0102030405"""));
		}
		[TestMethod]
		public void Write_must_write_null_array_to_null()
		{
			var arr = (byte[])null;

			var str = arr.SerializeToJson(options => options.Converters.Add(new HexByteArrayJsonConverter()));

			Assert.AreEqual("null", str);
		}
		[TestMethod]
		public void Write_must_write_null_array_to_null_for_properties()
		{
			var a = new A();

			var str = a.SerializeToJson(options => options.Converters.Add(new HexByteArrayJsonConverter()));

			Assert.IsTrue(str.Contains("null"));
		}
	}
}
