using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.HexBitmapDataTypeHandler")]
	[ExcludeFromCodeCoverage]
	public class HexBitmapDataTypeHandlerTests
	{
		[TestMethod]
		public void ConvertToByteArrayMustConvertBitmapIsoAsByteArray()
		{
			var field = BitmapIsoField.FromHex("1000000000000000");

			var handler = new HexBitmapDataTypeHandler();

			var result = handler.ConvertToByteArray(field, Encoding.UTF8);

			Assert.AreEqual("1000000000000000".ToBytes().ToHex(), result.ToHex());
		}
		[TestMethod]
		public void ConvertToByteArrayMustThrowExceptionOnInvalidType()
		{
			var handler = new HexBitmapDataTypeHandler();

			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(new SomeOtherIsoFieldType(), Encoding.UTF8));
			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(new BinaryIsoField(), Encoding.UTF8));
			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(new StringIsoField(), Encoding.UTF8));
			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(null, Encoding.UTF8));
		}
		[TestMethod]
		public void ConvertToIsoFieldMustCreateBitmapIsoField()
		{
			var handler = new HexBitmapDataTypeHandler();
			var data = "1000000000000000".ToBytes();

			var result = handler.ConvertToIsoField(data, Encoding.UTF8);

			var bitmapField = result as BitmapIsoField;

			Assert.IsNotNull(bitmapField);
			Assert.AreEqual("1000000000000000", bitmapField.GetBitmapHex());
		}
		[TestMethod]
		public void ReadAsLengthMustThrowException()
		{
			var handler = new HexBitmapDataTypeHandler();
			var stream = new MemoryStream("100203040506".FromHex());

			Assert.ThrowsException<NotSupportedException>(() => handler.ReadAsLength(stream, VariableLengthType.LVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.ReadAsLength(stream, VariableLengthType.LLVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.ReadAsLength(stream, VariableLengthType.LLLVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.ReadAsLength(stream, VariableLengthType.LLLLVar, 100));
		}
		[TestMethod]
		public void WriteAsLengthMustThrowException()
		{
			var handler = new HexBitmapDataTypeHandler();
			var stream = new MemoryStream();

			Assert.ThrowsException<NotSupportedException>(() => handler.WriteAsLength(stream, 10, VariableLengthType.LVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.WriteAsLength(stream, 10, VariableLengthType.LLVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.WriteAsLength(stream, 10, VariableLengthType.LLLVar, 100));
			Assert.ThrowsException<NotSupportedException>(() => handler.WriteAsLength(stream, 10, VariableLengthType.LLLLVar, 100));
		}
	}
}
