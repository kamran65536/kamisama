using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Ks.Extenders
{
	[TestClass]
	[TestCategory("KS.Ex.String Extensions")]
	[ExcludeFromCodeCoverage]
	public class StringTests
	{
		[TestMethod]
		public void EmptyFromHexTest()
		{
			AssertEx.AreEqual(new byte[0], (null as string).FromHex());
		}
		[TestMethod]
		public void EmptyToBytesTest()
		{
			AssertEx.AreEqual((null as string).ToBytes(), new byte[0]);
		}
		[TestMethod]
		public void FromHexTest()
		{
			var arrFromHex = "1A0BB".FromHex();
			var arr = new byte[] { 0x01, 0xA0, 0xBB};

			AssertEx.AreEqual(arrFromHex, arr);
		}
		[TestMethod]
		public void FromBase64Test()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB };
			var str = Convert.ToBase64String(arr);

			AssertEx.AreEqual(arr, str.FromBase64());
		}
		[TestMethod]
		public void GetBytes()
		{
			var arr1 = "012".ToBytes();

			var arr2 = new byte[] { 0x30, 0x31, 0x32 };

			AssertEx.AreEqual(arr1, arr2);
		}

	}
}
