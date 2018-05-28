using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks.Extenders
{
	public enum Enum1
	{
		None = 0,
		A = 1,
	}
	[TestClass]
	[TestCategory("KS.Ex.Conversion")]
	[ExcludeFromCodeCoverage]
	public class ConversionTests
	{
		[TestMethod]
		public void IntTest()
		{
			AssertEx.AreEqual(10, "10".ConvertTo(0));
		}
		[TestMethod]
		public void DoubleTest()
		{
			AssertEx.AreEqual(10.0, "10.0".ConvertTo(0.0));
		}
		[TestMethod]
		public void EnumTest()
		{
			AssertEx.AreEqual(Enum1.A, "A".ConvertTo(Enum1.None));
			AssertEx.AreEqual(Enum1.A, "a".ConvertTo(Enum1.None));
			AssertEx.AreEqual(Enum1.A, "1".ConvertTo(Enum1.None));
		}

		[TestMethod]
		public void NullableTest()
		{
			AssertEx.IsNull("SDDE".ConvertTo<int?>(null));
		}

		[TestMethod]
		public void NullConversionTest()
		{
			AssertEx.IsNull(((object) null).ConvertTo<int?>(null));
		}
	}
}
