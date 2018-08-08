using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.BinaryDataTypeHandler")]
	[ExcludeFromCodeCoverage]
	public class BinaryDataTypeHandlerTests
	{
		[TestMethod]
		public void ConvertToByteArrayMustConvertStringIsoAsStringBytes()
		{
			var field = (StringIsoField)"1234567890";

			var handler = new BinaryDataTypeHandler();

			var result = handler.ConvertToByteArray(field, Encoding.UTF8);

			Assert.AreEqual(result.GetString(), "1234567890");
		}
		[TestMethod]
		public void ConvertToByteArrayMustConvertBitmapIsoAsBytes()
		{
			var field = new BitmapIsoField();
			field[1] = true;

			var handler = new BinaryDataTypeHandler();

			var result = handler.ConvertToByteArray(field, Encoding.UTF8);

			Assert.AreEqual("8000000000000000", result.ToHex());
		}
		[TestMethod]
		public void CovnertToByteArrayMustReturnSameArrayForBinaryIsoField()
		{
			var field = new BinaryIsoField { Data = "010203".FromHex() };

			var handler = new BinaryDataTypeHandler();

			var result = handler.ConvertToByteArray(field, Encoding.UTF8);

			Assert.AreEqual("010203", result.ToHex());
		}
		[TestMethod]
		public void ConvertToByteArrayMustThrowExceptionOnInvalidType()
		{
			var field = new SomeOtherIsoFieldType();

			var handler = new BinaryDataTypeHandler();

			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(field, Encoding.UTF8));
			Assert.ThrowsException<IsoMessageReadException>(() => handler.ConvertToByteArray(null, Encoding.UTF8));
		}
		[TestMethod]
		public void ConvertToIsoFieldMustCreateBinaryIsoField()
		{
			var handler = new BinaryDataTypeHandler();
			var data = "12345678".FromHex();

			var result = handler.ConvertToIsoField(data, Encoding.UTF8);

			var binaryField = result as BinaryIsoField;

			Assert.IsNotNull(binaryField);
			Assert.AreEqual("12345678", binaryField.Data.ToHex());
		}
		[TestMethod]
		public void ReadAsLengthMustReadLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream("01".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LVar, 100);

			Assert.AreEqual(1, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadOddLengthLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream("11".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LVar, 100);

			Assert.AreEqual(17, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadLLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream("0021".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LLVar, 100);

			Assert.AreEqual(0x21, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadLLLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream("000211".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LLLVar, 100);

			Assert.AreEqual(0x0211, length);
		}
		[TestMethod]
		public void WriteAsLengthMustWithAsLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 11, VariableLengthType.LVar, 100);

			Assert.AreEqual("0B", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWithAsLLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 19, VariableLengthType.LLVar, 100);

			Assert.AreEqual("0013", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWithAsLLLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 119, VariableLengthType.LLLVar, 100);

			Assert.AreEqual("000077", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWithAsLLLLVar()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 19, VariableLengthType.LLLLVar, 100);

			Assert.AreEqual("00000013", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthThrowExceptionForInvalidLength()
		{
			var handler = new BinaryDataTypeHandler();
			var stream = new MemoryStream();

			Assert.ThrowsException<IsoMessageWriteException>(() => handler.WriteAsLength(stream, 1119, VariableLengthType.LVar, 100));
		}
	}
}
