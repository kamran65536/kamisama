using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Ks.Extenders
{
	[TestClass]
	[TestCategory("KS.Ex.ByteArray Extensions")]
	[ExcludeFromCodeCoverage]
	public class ByteArrayTests
	{
		[TestMethod]
		public void ToHexTest()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB};

			var hex = arr.ToHex();

			AssertEx.AreEqual("01A0BB", hex);
		}
		[TestMethod]
		public void ToBase64Test()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB };

			var str = Convert.ToBase64String(arr);

			AssertEx.AreEqual(str, arr.ToBase64());
		}

		[TestMethod]
		public void GetString()
		{
			var arr = new byte[] { 0x30, 0x31, 0x32 };

			var str = arr.GetString();

			AssertEx.AreEqual("012", str);
		}
	}
}
