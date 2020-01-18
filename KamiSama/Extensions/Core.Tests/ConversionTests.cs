using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamiSama.Extensions.Tests
{
	public enum Enum1
	{
		None = 0,
		A = 1,
	}
	[TestClass]
	public class ConversionTests
	{
		[TestMethod]
		public void IntTest()
		{
			Assert.AreEqual(10, "10".ConvertTo(0));
		}
		[TestMethod]
		public void DoubleTest()
		{
			Assert.AreEqual(10.0, "10.0".ConvertTo(0.0));
		}
		[TestMethod]
		public void EnumTest()
		{
			Assert.AreEqual(Enum1.A, "A".ConvertTo(Enum1.None));
			Assert.AreEqual(Enum1.A, "a".ConvertTo(Enum1.None));
			Assert.AreEqual(Enum1.A, "1".ConvertTo(Enum1.None));
			Assert.AreEqual(Enum1.None, ((string) null).ConvertTo(Enum1.None));
		}

		[TestMethod]
		public void NullableTest()
		{
			Assert.IsNull("SDDE".ConvertTo<int?>(null));
		}

		[TestMethod]
		public void NullConversionTest()
		{
			Assert.IsNull(((object) null).ConvertTo<int?>(null));
		}
	}
}
