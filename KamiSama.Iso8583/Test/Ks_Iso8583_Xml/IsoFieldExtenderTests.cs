using System.Diagnostics.CodeAnalysis;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamiSama.Iso8583.Xml;
using KamiSama.Extenders;
using System;

namespace Test.Ks_Iso8583_Xml
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Xml.IsoFieldExtender")]
	[ExcludeFromCodeCoverage]
	public class IsoFieldExtenderTests
	{
		[TestMethod]
		public void StringIsoFieldMustBeMapToSimpleStringXmlIsoField()
		{
			var isoField = new StringIsoField { Data = "123456" };
			var xmlIsoField = isoField.GetXmlIsoField(1);

			Assert.AreEqual(XmlIsoFieldType.String, xmlIsoField.Type);
			Assert.AreEqual("123456", xmlIsoField.Data);
			Assert.AreEqual(1, xmlIsoField.FieldNo);
		}
		[TestMethod]
		public void	BinaryIsoFieldMustBeMapToBinHexValue()
		{
			var isoField = new BinaryIsoField { Data = "010203".FromHex() };
			var xmlIsoField = isoField.GetXmlIsoField(1);

			Assert.AreEqual(XmlIsoFieldType.BinaryHex, xmlIsoField.Type);
			Assert.AreEqual("010203", xmlIsoField.Data);
			Assert.AreEqual(1, xmlIsoField.FieldNo);
		}
		[TestMethod]
		public void BitmapIsoFieldMustBeMapToBitmapHexValue()
		{
			var isoField = BitmapIsoField.FromHex("F23C840188E10000");

			var xmlIsoField = isoField.GetXmlIsoField(1);

			Assert.AreEqual(XmlIsoFieldType.BitmapHex, xmlIsoField.Type);
			Assert.AreEqual("F23C840188E10000", xmlIsoField.Data);
			Assert.AreEqual(1, xmlIsoField.FieldNo);
		}
		class SomeOtherIsoField : IsoFieldBase
		{
			public override string ToDebugString(int fieldNo) => "Sample";
		}
		[TestMethod]
		public void GetIsoFieldMustThrowExceptionOnNullIsoField()
		{
			IsoFieldBase isoField = null;

			Assert.ThrowsException<NullReferenceException>(() => isoField.GetXmlIsoField(1));
		}
		[TestMethod]
		public void GetXmlIsoFieldMustThrowExceptionOnOtherIsoFields()
		{
			var isoField = new SomeOtherIsoField();

			Assert.ThrowsException<NotSupportedException>(() => isoField.GetXmlIsoField(1));
		}
	}
}
