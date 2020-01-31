using KamiSama.Extensions;
using KamiSama.Iso8583.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Tests.Serialization
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class IsoFieldExtenderTests
	{
		[TestMethod]
		public void StringIsoFieldMustBeMapToSimpleStringSerializableIsoField()
		{
			var isoField = new StringIsoField { Data = "123456" };
			var SerializableIsoField = isoField.AsSerializable(1);

			Assert.AreEqual(SerializableIsoFieldType.String, SerializableIsoField.Type);
			Assert.AreEqual("123456", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		[TestMethod]
		public void	BinaryIsoFieldMustBeMapToBinHexValue()
		{
			var isoField = new BinaryIsoField { Data = "010203".FromHex() };
			var SerializableIsoField = isoField.AsSerializable(1);

			Assert.AreEqual(SerializableIsoFieldType.BinaryHex, SerializableIsoField.Type);
			Assert.AreEqual("010203", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		[TestMethod]
		public void BitmapIsoFieldMustBeMapToBitmapHexValue()
		{
			var isoField = BitmapIsoField.FromHex("F23C840188E10000");

			var SerializableIsoField = isoField.AsSerializable(1);

			Assert.AreEqual(SerializableIsoFieldType.BitmapHex, SerializableIsoField.Type);
			Assert.AreEqual("F23C840188E10000", SerializableIsoField.Data);
			Assert.AreEqual(1, SerializableIsoField.FieldNo);
		}
		class SomeOtherIsoField : IsoFieldBase
		{
			public override string ToDebugString(int fieldNo) => "Sample";
		}
		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void AsSerializable_must_throw_Exception_on_null_IsoFields()
		{
			IsoFieldBase isoField = null;

			isoField.AsSerializable(1);
		}
		[TestMethod]
		[ExpectedException(typeof(NotSupportedException))]
		public void AsSerializable_must_throw_Exception_on_other_IsoFields()
		{
			var isoField = new SomeOtherIsoField();

			isoField.AsSerializable(1);
			isoField.AsSerializable(1);
		}
	}
}
