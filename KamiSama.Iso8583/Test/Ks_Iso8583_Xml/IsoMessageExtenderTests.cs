using System.Diagnostics.CodeAnalysis;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamiSama.Iso8583.Xml;
using KamiSama.Extenders;
using System;
using System.Linq;

namespace Test.Ks_Iso8583_Xml
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Xml.IsoFieldExtender")]
	[ExcludeFromCodeCoverage]
	public class IsoMessageExtenderTests
	{
		[TestMethod]
		public void GetXmlIsoMessageWithoutBitmapMustCreateXmlIsoMessageWithoutBitmaps()
		{
			var msg = new IsoMessage(1100);
			msg[2] = "5022291000000000";
			msg[65] = "5022291000000001";

			var xmlMsg = msg.GetXmlIsoMessage();

			Assert.IsNotNull(xmlMsg);
			Assert.AreEqual("1100", xmlMsg.Id);
			var field2 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 2);
			var field65 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 65);

			Assert.AreEqual(2, xmlMsg.Fields.Length);
			Assert.AreEqual("5022291000000000", field2.Data);
			Assert.AreEqual("5022291000000001", field65.Data);
		}
		[TestMethod]
		public void GetXmlIsoMessageWithBitmapMustCreateXmlIsoMessageWithBitmaps()
		{
			var msg = new IsoMessage(1100);
			msg[2] = "5022291000000000";
			msg[65] = "5022291000000001";

			var xmlMsg = msg.GetXmlIsoMessage(true);

			Assert.IsNotNull(xmlMsg);
			Assert.AreEqual("1100", xmlMsg.Id);
			var field0 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 0);
			var field1 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 1);
			var field2 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 2);
			var field65 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 65);

			Assert.AreEqual(4, xmlMsg.Fields.Length);
			Assert.AreEqual("C000000000000000", field0.Data);
			Assert.AreEqual("8000000000000000", field1.Data);
			Assert.AreEqual("5022291000000000", field2.Data);
			Assert.AreEqual("5022291000000001", field65.Data);
		}
	}
}
