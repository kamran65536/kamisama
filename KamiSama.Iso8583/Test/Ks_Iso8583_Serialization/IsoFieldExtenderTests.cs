using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Serialization
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Serialization.SerilizableIsoFieldExtender")]
	[ExcludeFromCodeCoverage]
	public class IsoFieldExtenderTests
	{
		[TestMethod]
		public void StringIsoFieldMustBeMapToSimpleStringSerializableIsoField()
		{
			var isoField = new StringIsoField { Data = "123456" };
			var SerializableIsoField = isoField.GetSerializableField(1);

			Assert.AreEqual(SerializableIsoFieldType.String, SerializableIsoField.Type);
			Assert.AreEqual("123456", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		[TestMethod]
		public void	BinaryIsoFieldMustBeMapToBinHexValue()
		{
			var isoField = new BinaryIsoField { Data = "010203".FromHex() };
			var SerializableIsoField = isoField.GetSerializableField(1);

			Assert.AreEqual(SerializableIsoFieldType.BinaryHex, SerializableIsoField.Type);
			Assert.AreEqual("010203", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		[TestMethod]
		public void BitmapIsoFieldMustBeMapToBitmapHexValue()
		{
			var isoField = BitmapIsoField.FromHex("F23C840188E10000");

			var SerializableIsoField = isoField.GetSerializableField(1);

			Assert.AreEqual(SerializableIsoFieldType.BitmapHex, SerializableIsoField.Type);
			Assert.AreEqual("F23C840188E10000", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		class SomeOtherIsoField : IsoFieldBase
		{
			public override string ToDebugString(int fieldNo) => "Sample";
		}
		[TestMethod]
		public void GetIsoFieldMustThrowExceptionOnNullIsoField()
		{
			IsoFieldBase isoField = null;

			Assert.ThrowsException<NullReferenceException>(() => isoField.GetSerializableField(1));
		}
		[TestMethod]
		public void GetSerializableFieldMustThrowExceptionOnOtherIsoFields()
		{
			var isoField = new SomeOtherIsoField();

			Assert.ThrowsException<NotSupportedException>(() => isoField.GetSerializableField(1));
		}
	}
}
