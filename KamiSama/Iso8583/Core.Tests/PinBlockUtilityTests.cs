using KamiSama.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Tests
{
	[TestClass]
	public class PinBlockUtilityTests
	{
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		[ExcludeFromCodeCoverage]
		[DataRow(null, "1", new byte[0])]
		[DataRow("1", null, new byte[0])]
		[DataRow("1", "2", null)]
		public void GetPinBlock_throws_Exception_on_null_input_parameter(string pan, string pin, byte[] pinKey)
		{
			PinBlockUtility.GetPinBlock(pan, pin, pinKey);
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
