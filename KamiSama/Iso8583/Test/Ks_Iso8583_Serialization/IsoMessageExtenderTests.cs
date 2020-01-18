using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Serialization
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Serialization.SerilizableIsoFieldExtender")]
	[ExcludeFromCodeCoverage]
	public class IsoMessageExtenderTests
	{
		[TestMethod]
		public void GetSerializableMessageWithoutBitmapMustCreateSerializableIsoMessageWithoutBitmaps()
		{
			var msg = new IsoMessage(1100);
			msg[2] = "5022291000000000";
			msg[65] = "5022291000000001";

			var xmlMsg = msg.GetSerializableMessage();

			Assert.IsNotNull(xmlMsg);
			Assert.AreEqual("1100", xmlMsg.Id);
			var field2 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 2);
			var field65 = xmlMsg.Fields.FirstOrDefault(x => x.FieldNo == 65);

			Assert.AreEqual(2, xmlMsg.Fields.Length);
			Assert.AreEqual("5022291000000000", field2.Data);
			Assert.AreEqual("5022291000000001", field65.Data);
		}
		[TestMethod]
		public void GetSerializableMessageWithBitmapMustCreateSerializableIsoMessageWithBitmaps()
		{
			var msg = new IsoMessage(1100);
			msg[2] = "5022291000000000";
			msg[65] = "5022291000000001";

			var xmlMsg = msg.GetSerializableMessage(true);

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
