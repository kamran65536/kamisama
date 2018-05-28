using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Xunit;


namespace XTest.Ks.Extenders
{
	public enum Enum1
	{
		None = 0,
		A = 1,
	}
	[Trait("Category", "KS.Ex.Conversion")]
	[ExcludeFromCodeCoverage]
	public class ConversionTests
	{
		[Fact(DisplayName = "Int")]
		public void IntTest()
		{
			Assert.Equal(10, "10".ConvertTo(0));
		}
		[Fact(DisplayName = "Double")]
		public void DoubleTest()
		{
			Assert.Equal(10.0, "10.0".ConvertTo(0.0));
		}
		[Fact(DisplayName = "Enum")]
		public void EnumTest()
		{
			Assert.Equal(Enum1.A, "A".ConvertTo(Enum1.None));
			Assert.Equal(Enum1.A, "a".ConvertTo(Enum1.None));
			Assert.Equal(Enum1.A, "1".ConvertTo(Enum1.None));
		}

		[Fact(DisplayName = "Nullable")]
		public void NullableTest()
		{
			Assert.Null("SDDE".ConvertTo<int?>(null));
		}

		[Fact(DisplayName = "Null Conversion")]
		public void NullConversionTest()
		{
			Assert.Null(((object) null).ConvertTo<int?>(null));
		}
	}
}
