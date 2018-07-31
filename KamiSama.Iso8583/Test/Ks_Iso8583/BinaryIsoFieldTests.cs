using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583
{
	[TestClass]
	[TestCategory("Ks.Iso8583.BinaryIsoField")]
	[ExcludeFromCodeCoverage]
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