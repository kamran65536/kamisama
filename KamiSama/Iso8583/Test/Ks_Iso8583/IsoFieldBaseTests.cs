using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583
{
	[TestClass]
	[TestCategory("Ks.Iso8583.IsoFieldBase")]
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
