using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Xunit;
using Xunit.Categories;

namespace XTest
{
	[Category("ByteArray Extensions")]
	[ExcludeFromCodeCoverage]
	public class ByteArrayTests
	{
		[Fact(DisplayName = "ToHex")]
		public void ToHexTest()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB};

			var hex = arr.ToHex();

			Assert.Equal("01A0BB", hex);
		}
		[Fact(DisplayName = "ToBase64")]
		public void ToBase64Test()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB };

			var str = Convert.ToBase64String(arr);

			Assert.Equal(str, arr.ToBase64());
		}

		[Fact(DisplayName = "GetString")]
		public void GetString()
		{
			var arr = new byte[] { 0x30, 0x31, 0x32 };

			var str = arr.GetString();

			Assert.Equal("012", str);
		}
	}
}
