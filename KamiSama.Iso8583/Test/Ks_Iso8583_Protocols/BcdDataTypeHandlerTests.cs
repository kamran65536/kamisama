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
	[TestCategory("Ks.Iso8583.Protocols.Generic.BcdDataTypeHandler")]
	[ExcludeFromCodeCoverage]
	public class BcdDataTypeHandlerTests
	{
		[TestMethod]
		public void ConvertToByteArrayMustConvertDataAsHex()
		{
			var msg = new IsoMessage(1100);

			msg[2] = "1234567890";

			var handler = new BcdDataTypeHandler();

			var result = handler.ConvertToByteArray(msg[2], Encoding.UTF8);

			Assert.AreEqual(result.ToHex(), "1234567890");
		}
		[TestMethod]
		public void ConvertToByteArrayMustConvertOddLengthDataAsHex()
		{
			var msg = new IsoMessage(1100);

			msg[2] = "123456789";

			var handler = new BcdDataTypeHandler();

			var result = handler.ConvertToByteArray(msg[2], Encoding.UTF8);

			Assert.AreEqual(result.ToHex(), "0123456789");
		}
		[TestMethod]
		public void ConvertToIsoFieldMustCreateStringIsoField()
		{
			var handler = new BcdDataTypeHandler();
			var data = "12345678".FromHex();

			var result = handler.ConvertToIsoField(data, Encoding.UTF8);

			var stringField = result as StringIsoField;

			Assert.IsNotNull(stringField);
			Assert.AreEqual("12345678", stringField.Data);
		}
		[TestMethod]
		public void ReadAsLengthMustReadLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream("01".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LVar, 100);

			Assert.AreEqual(1, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadOddLengthLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream("11".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LVar, 100);

			Assert.AreEqual(1, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream("21".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LLVar, 100);

			Assert.AreEqual(21, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadLLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream("0211".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LLLVar, 100);

			Assert.AreEqual(211, length);
		}
		[TestMethod]
		public void ReadAsLengthMustReadOddLengthLLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream("2211".FromHex());

			var length = handler.ReadAsLength(stream, VariableLengthType.LLLVar, 100);

			Assert.AreEqual(211, length);
		}
		[TestMethod]
		public void WriteAsLengthMustWrithAsLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 9, VariableLengthType.LVar, 100);

			Assert.AreEqual("09", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWrithAsLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 19, VariableLengthType.LLVar, 100);

			Assert.AreEqual("19", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWrithAsLLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 119, VariableLengthType.LLLVar, 100);

			Assert.AreEqual("0119", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthMustWrithAsLLLLVar()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream();

			handler.WriteAsLength(stream, 19, VariableLengthType.LLLLVar, 100);

			Assert.AreEqual("0019", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteAsLengthThrowExceptionForInvalidLength()
		{
			var handler = new BcdDataTypeHandler();
			var stream = new MemoryStream();

			Assert.ThrowsException<IsoMessageWriteException>(() => handler.WriteAsLength(stream, 19, VariableLengthType.LVar, 100));
		}
	}
}
