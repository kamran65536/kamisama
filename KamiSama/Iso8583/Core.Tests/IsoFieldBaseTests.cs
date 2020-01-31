using KamiSama.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Tests
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class IsoFieldBaseTests
	{
		[TestMethod]
		public void StringDataMustBeCastedToStringIsoField()
		{
			var str = "11111";
			var isoField = (IsoFieldBase)str;
			var stringIsoField = isoField as StringIsoField;

			Assert.IsNotNull(stringIsoField);
			Assert.AreEqual("11111", stringIsoField.Data);
		}
		[TestMethod]
		public void ByteArrayMustBeCastedToBinaryIsoField()
		{
			var arr = new byte[] { 0x01, 0x02, 0x03 };

			var isoField = (IsoFieldBase)arr;
			var stringIsoField = isoField as BinaryIsoField;

			Assert.IsNotNull(stringIsoField);
			Assert.AreEqual("010203", stringIsoField.Data.ToHex());
		}
	}
}
