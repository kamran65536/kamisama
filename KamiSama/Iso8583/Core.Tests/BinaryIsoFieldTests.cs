using KamiSama.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamiSama.Iso8583.Tests
{
	[TestClass]
	public class BinaryIsoFieldTests
	{
		[TestMethod]
		public void DebugStringMustDisplayHexValue()
		{
			var field = new BinaryIsoField { Data = "010203".FromHex() };

			Assert.AreEqual("hex:010203", field.ToDebugString(0));
		}
		[TestMethod]
		public void ToStringMethodMustDisplayHexValue()
		{
			var field = new BinaryIsoField { Data = "010203".FromHex() };

			Assert.AreEqual("010203", field.ToString());
		}
		[TestMethod]
		public void NullDataMustDisplayNull()
		{
			var field = new BinaryIsoField { Data = null };

			Assert.IsNull(field.ToString());
		}
	}
}