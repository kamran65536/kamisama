using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Xml
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Xml.IsoField")]
	[ExcludeFromCodeCoverage]
	public class XmlIsoFieldTests
	{
		[TestMethod]
		public void GetIsoFieldWithStringTypeReturnsStringIsoField()
		{
			var xmlField = new XmlIsoField { FieldNo = 2, Data = "123456", Type = XmlIsoFieldType.String };

			var field = xmlField.GetIsoField();
			var stringIsoField = field as StringIsoField;

			Assert.IsNotNull(stringIsoField);
			Assert.AreEqual("123456", stringIsoField.Data);
		}
		[TestMethod]
		public void GetIsoFieldWithBinaryTypeReturnsStringIsoField()
		{
			var xmlField = new XmlIsoField { FieldNo = 2, Data = "010203", Type = XmlIsoFieldType.BinaryHex };

			var field = xmlField.GetIsoField();
			var binaryIsoField = field as BinaryIsoField;

			Assert.IsNotNull(binaryIsoField);
			Assert.AreEqual("010203", binaryIsoField.Data.ToHex());
		}
		[TestMethod]
		public void GetIsoFieldWithBitmapTypeReturnsStringIsoField()
		{
			var xmlField = new XmlIsoField { FieldNo = 2, Data = "C000000000000000", Type = XmlIsoFieldType.BitmapHex };

			var field = xmlField.GetIsoField();
			var bitmap = field as BitmapIsoField;

			Assert.IsNotNull(bitmap);
			Assert.AreEqual("C000000000000000", bitmap.GetBitmapHex());
		}
		[TestMethod]
		public void GetIsoFieldWithIncorrectTypeMustThrowException()
		{
			var xmlField = new XmlIsoField { FieldNo = 2, Data = "C000000000000000", Type = (XmlIsoFieldType) 111 };
			Assert.ThrowsException<NotSupportedException>(() => xmlField.GetIsoField());
		}
	}
}
