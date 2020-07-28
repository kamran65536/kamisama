using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json.Tests
{
	public class AA
	{
		[JsonConverter(typeof(TimeSpanJsonConverter))]
		public TimeSpan TimeSpan { get; set; }
	}
	[TestClass]
	public class TimeSpanJsonConverterTests
	{
		[TestMethod]
		public void Read_must_read_string_as_TimeSpan()
		{
			var str = @"""1.12:13:14.777""";

			var ts = str.DeserializeFromJson<TimeSpan>(options => options.Converters.Add(new TimeSpanJsonConverter()));
			var expected = new TimeSpan(1, 12, 13, 14, 777);

			Assert.AreEqual(expected, ts);
		}
		[TestMethod]
		public void Read_must_read_hex_string_as_byte_array_for_properties()
		{
			var str = @"{ ""TimeSpan"" : ""1.12:13:14.777"" }";

			var a = str.DeserializeFromJson<AA>();
			var expected = new TimeSpan(1, 12, 13, 14, 777);

			Assert.AreEqual(expected, a.TimeSpan);
		}
		[TestMethod]
		public void Write_must_write_TimeSpan_as_TimeSpan_string()
		{
			var ts = new TimeSpan(1, 12, 13, 14, 777);

			var str = ts.SerializeToJson(options => options.Converters.Add(new TimeSpanJsonConverter()));
			var expected = @"1.12:13:14.777";

			Assert.IsTrue(str.Contains(expected));
		}
		[TestMethod]
		public void Write_must_write_byte_array_as_hex_value_for_properties()
		{
			var a = new AA
			{
				TimeSpan = new TimeSpan(1, 12, 13, 14, 777)
			};

			var str = a.SerializeToJson();
			var expected = @"1.12:13:14.777";

			Assert.IsTrue(str.Contains(expected));
		}
	}
}
