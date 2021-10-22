using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json.Tests
{
	public class TestObject
	{
		[JsonConverter(typeof(DynamicObjectConverter))]
		public dynamic DynamicObject { get; set; }
	}
	[TestClass]
	public class DynamicObjectConverterTests
	{
		[TestMethod]
		public void Read_must_read_a_complex_object()
		{
			var obj = new
			{
				x = 1,
				y = 1.1,
				str = "some text",
				obj = new
				{
					ox = 2,
					oy = 1.2,
					ostr = "another text",
					obj2 = new
					{
						oox = 3
					}
				}
			};

			var test = new TestObject { DynamicObject = obj };

			var str = test.SerializeToJson();
			var test2 = str.DeserializeFromJson<TestObject>();

			Assert.IsTrue(obj.x == test2.DynamicObject.x);
			Assert.IsTrue(obj.y == test2.DynamicObject.y);
			Assert.IsTrue(obj.str == test2.DynamicObject.str);
			Assert.IsTrue(obj.obj.ox == test2.DynamicObject.obj.ox);
			Assert.IsTrue(obj.obj.oy == test2.DynamicObject.obj.oy);
			Assert.IsTrue(obj.obj.ostr == test2.DynamicObject.obj.ostr);
			Assert.IsTrue(obj.obj.obj2.oox == test2.DynamicObject.obj.obj2.oox);
		}
	}
}
