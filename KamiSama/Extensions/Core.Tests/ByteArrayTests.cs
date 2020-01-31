using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace KamiSama.Extensions.Core.Tests
{
	[TestClass]
	public class ByteArrayTests
	{
		[TestMethod]
		public void ToHexTest()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB};

			var hex = arr.ToHex();

			Assert.AreEqual("01A0BB", hex);
		}
		[TestMethod]
		public void ToBase64Test()
		{
			var arr = new byte[] { 0x01, 0xA0, 0xBB };

			var str = Convert.ToBase64String(arr);

			Assert.AreEqual(str, arr.ToBase64());
		}

		[TestMethod]
		public void GetString()
		{
			var arr = new byte[] { 0x30, 0x31, 0x32 };

			var str = arr.GetString();

			Assert.AreEqual("012", str);
		}
	}
}
