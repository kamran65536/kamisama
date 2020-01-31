using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamiSama.Iso8583.Tests
{
	[TestClass]
	public class StringIsoFieldTests
	{
		[TestMethod]
		public void DebugStringMustDisplayHexValue()
		{
			var field = new StringIsoField { Data = "123456" };

			Assert.AreEqual("123456", field.ToDebugString(0));
		}
		[TestMethod]
		public void ToStringMethodMustDisplayHexValue()
		{
			var field = new StringIsoField { Data = "123456" };

			Assert.AreEqual("123456", field.ToString());
		}
		[TestMethod]
		public void NullDataMustDisplayNull()
		{
			var field = new StringIsoField { Data = null };

			Assert.IsNull(field.ToString());
		}
	}
}