using KamiSama.Extenders;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Ks_Iso8583
{
	[TestClass]
	[TestCategory("Ks.Iso8583.PinBlockUtility")]
	public class PinBlockUtilityTests
	{
		[TestMethod]
		public void GetPinBlock_throws_Exception_on_null_input_parameter()
		{
			Assert.ThrowsException<Exception>(() => PinBlockUtility.GetPinBlock(null, "1", new byte[0]));
			Assert.ThrowsException<Exception>(() => PinBlockUtility.GetPinBlock("1", null, new byte[0]));
			Assert.ThrowsException<Exception>(() => PinBlockUtility.GetPinBlock("1", "2", null));
		}
		[TestMethod]
		public void GetPinBlock_calculates_pinblock()
		{
			var key = "1234567890123456".FromHex();

			var result = PinBlockUtility.GetPinBlock("6280231110000444", "1234", key);

			Assert.AreEqual("FD4C7A18DE48DA89", result);
		}
	}
}
