using KamiSama.Extensions;
using KamiSama.Iso8583.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Tests.Serialization
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class SerializableIsoFieldTests
	{
		[TestMethod]
		public void GetIsoFieldWithStringTypeReturnsStringIsoField()
		{
			var xmlField = new SerializableIsoField { FieldNo = 2, Data = "123456", Type = SerializableIsoFieldType.String };

			var field = xmlField.GetIsoField();
			var stringIsoField = field as StringIsoField;

			Assert.IsNotNull(stringIsoField);
			Assert.AreEqual("123456", stringIsoField.Data);
		}
		[TestMethod]
		public void GetIsoFieldWithBinaryTypeReturnsStringIsoField()
		{
			var xmlField = new SerializableIsoField { FieldNo = 2, Data = "010203", Type = SerializableIsoFieldType.BinaryHex };

			var field = xmlField.GetIsoField();
			var binaryIsoField = field as BinaryIsoField;

			Assert.IsNotNull(binaryIsoField);
			Assert.AreEqual("010203", binaryIsoField.Data.ToHex());
		}
		[TestMethod]
		public void GetIsoFieldWithBitmapTypeReturnsStringIsoField()
		{
			var xmlField = new SerializableIsoField { FieldNo = 2, Data = "C000000000000000", Type = SerializableIsoFieldType.BitmapHex };

			var field = xmlField.GetIsoField();
			var bitmap = field as BitmapIsoField;

			Assert.IsNotNull(bitmap);
			Assert.AreEqual("C000000000000000", bitmap.GetBitmapHex());
		}
		[TestMethod]
		public void GetIsoFieldWithIncorrectTypeMustThrowException()
		{
			var xmlField = new SerializableIsoField { FieldNo = 2, Data = "C000000000000000", Type = (SerializableIsoFieldType) 111 };
			Assert.ThrowsException<NotSupportedException>(() => xmlField.GetIsoField());
		}
	}
}
