using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Serialization
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Serialization.IsoMessage")]
	[ExcludeFromCodeCoverage]
	public class SerializableIsoMessageTests
	{
		[TestMethod]
		public void GetIsoMessageMustReturnEquivalantIsoMessage()
		{
			var xmlMsg = new SerializableIsoMessage
			{
				Id = "1100",
				Fields = new SerializableIsoField[]
				{
					new SerializableIsoField { FieldNo = 2, Data = "1234567", Type = SerializableIsoFieldType.String },
					new SerializableIsoField { FieldNo = 65, Data = "010203", Type = SerializableIsoFieldType.BinaryHex },
				}
			};

			var msg = xmlMsg.GetIsoMessage();

			Assert.AreEqual("1100", msg.Id);
			Assert.AreEqual("C000000000000000", msg.PrimaryBitmap.GetBitmapHex());
			Assert.AreEqual("8000000000000000", msg.SecondaryBitmap.GetBitmapHex());
			Assert.AreEqual("1234567", (msg[2] as StringIsoField).Data);
			Assert.AreEqual("010203", (msg[65] as BinaryIsoField).Data.ToHex());
		}
		[TestMethod]
		public void SaveToXmlFileAndLoadFromXmlFileMustCreateSameSerializableIsoMessage()
		{
			var filename = "./isomessage-test.xml";

			var xmlMsg1 = new SerializableIsoMessage
			{
				Id = "1100",
				Fields = new SerializableIsoField[]
				{
					new SerializableIsoField { FieldNo = 2, Data = "1234567", Type = SerializableIsoFieldType.String },
					new SerializableIsoField { FieldNo = 65, Data = "010203", Type = SerializableIsoFieldType.BinaryHex },
				}
			};

			xmlMsg1.SaveToXmlFile(filename);
			var xmlMsg2 = SerializableIsoMessage.LoadFromXmlFile(filename);

			Assert.AreEqual(xmlMsg1.Id, xmlMsg2.Id);
			Assert.AreEqual(xmlMsg1.Fields.Length, xmlMsg2.Fields.Length);

			var side1_field2 = xmlMsg1.Fields.FirstOrDefault(x => x.FieldNo == 2);
			var side2_field2 = xmlMsg2.Fields.FirstOrDefault(x => x.FieldNo == 2);
			var side1_field65 = xmlMsg1.Fields.FirstOrDefault(x => x.FieldNo == 65);
			var side2_field65 = xmlMsg1.Fields.FirstOrDefault(x => x.FieldNo == 65);

			Assert.AreEqual(side1_field2.Data, side2_field2.Data);
			Assert.AreEqual(side1_field2.Type, side2_field2.Type);
			Assert.AreEqual(side1_field65.Data, side2_field65.Data);
			Assert.AreEqual(side1_field65.Type, side2_field65.Type);
		}
	}
}
