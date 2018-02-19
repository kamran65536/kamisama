using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Xunit;
using Xunit.Categories;

namespace XTest
{
	[Category("Array")]
	[ExcludeFromCodeCoverage]
	public class ArrayTests
	{
		[Fact(DisplayName = "Pad")]
		public void PaddingTest()
		{
			var arr = "0102030405".FromHex();
			var padded = arr.Pad(len => len % 8 == 0);

			Assert.Equal("0102030405000000", padded.ToHex());
			padded = padded.Pad(len => len % 8 == 0);
			Assert.Equal("0102030405000000", padded.ToHex());
		}

		[Fact(DisplayName = "TrimEnd")]
		public void TrimmingTest()
		{
			var arr = "0102030405000000".FromHex();
			var trimmed = arr.TrimEnd((byte)0);

			Assert.Equal("0102030405", trimmed.ToHex());
			trimmed = trimmed.TrimEnd((byte)0);
			Assert.Equal("0102030405", trimmed.ToHex());
		}
		[Fact(DisplayName = "TrimEnd-EmptyArray")]
		public void TrimmingEmptyArrayTest()
		{
			var arr = new object[] {null, null, null};
			var trimmed = arr.TrimEnd((object) null);

			Assert.Equal(new object[] { }, trimmed);
		}
	}
}
