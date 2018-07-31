using System.Diagnostics.CodeAnalysis;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583
{
	[TestClass]
	[TestCategory("Ks.Iso8583.StringIsoField")]
	[ExcludeFromCodeCoverage]
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