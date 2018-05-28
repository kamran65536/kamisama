using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Xunit;


namespace XTest.Ks.Extenders
{
	[Trait("Category", "KS.Ex.String Extensions")]
	[ExcludeFromCodeCoverage]
	public class StringTests
	{
		[Fact(DisplayName = "FromHex-EmptyString")]
		public void EmptyFromHexTest()
		{
			Assert.Equal(new byte[0], (null as string).FromHex());
		}
		[Fact(DisplayName = "ToBytes-EmptyString")]
		public void EmptyToBytesTest()
		{
			Assert.Equal((null as string).ToBytes(), new byte[0]);
		}
		[Fact(DisplayName = "FromHex")]
		public void FromHexTest()
		{
			var arrFromHex = "1A0BB".FromHex();
			var arr = new byte[] { 0x01, 0xA0, 0xBB};

			Assert.Equal(arrFromHex, arr);
		}
		[Fact(DisplayName = "FromBase64")]
		public void FromBase64Test()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB };
			var str = Convert.ToBase64String(arr);

			Assert.Equal(arr, str.FromBase64());
		}
		[Fact(DisplayName = "GetString")]
		public void GetBytes()
		{
			var arr1 = "012".ToBytes();

			var arr2 = new byte[] { 0x30, 0x31, 0x32 };

			Assert.Equal(arr1, arr2);
		}

	}
}
