using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.GenericIsoProtocol")]
	[ExcludeFromCodeCoverage]
	public class GenericIsoProtocolTests
	{
		[TestMethod]
		public void ReadHeaderAndDataMustReadIdAndLengthAndReturnsTheRestAsMemoryStream()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream("303030383131303012345678".FromHex());

			protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100);

			Assert.IsNotNull(msg);
			Assert.IsNotNull(memStream);
			Assert.AreEqual("1100", msg.Id);
			Assert.AreEqual("3131303012345678", memStream.ToArray().ToHex());
		}
		[TestMethod]
		public void ReadHeaderAndDataMustThrowExceptionOnInvalidLength()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream("00".FromHex());

			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
			stream = new MemoryStream("3030303b".FromHex());
			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
			stream = new MemoryStream("303030323030".FromHex());
			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
		}
		[TestMethod]
		public void ReadHeaderAndDataMustThrowExceptionOnInvalidId()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream("30303033".FromHex());
			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
		}
		[TestMethod]
		public void ReadHeaderAndDataMustThrowExceptionIfNoDataIsPresentForMessageBody()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream("3030303531313030".FromHex());
			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
		}
		[TestMethod]
		public void WriteHeaderAndDataMustWriteLengthAndThenId()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream();
			var memStream = new MemoryStream("010203".FromHex());
			var msg = new IsoMessage(1100);

			protocol.WrtieHeaderAndData(stream, memStream, msg, 100);

			Assert.AreEqual("3030303731313030010203", stream.ToArray().ToHex());
		}
		[TestMethod]
		public void ReadFieldMustReadFieldBasedOnProtocolFields()
		{
			var protocol = new GenericIsoProtocol();
			protocol.Fields = new GenericIsoProtocolField[]
			{
				new FixedIsoField { FieldNo = 2, DataType = "text", Length = 6 },
			};

			var msg = new IsoMessage(1100);

			var stream = new MemoryStream("123456".ToBytes());

			protocol.ReadField(stream, 2, msg, 100);

			var stringIsoField = msg[2] as StringIsoField;

			Assert.IsNotNull(stringIsoField);
			Assert.AreEqual("123456", stringIsoField.Data);
		}
		[TestMethod]
		public void ReadFieldMustThrowExceptionIfFieldIsNotFoundInProtocol()
		{
			var protocol = new GenericIsoProtocol();
			protocol.Fields = new GenericIsoProtocolField[]
			{
				new FixedIsoField { FieldNo = 3, DataType = "text", Length = 6 },
			};

			var msg = new IsoMessage(1100);

			var stream = new MemoryStream("123456".ToBytes());

			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadField(stream, 2, msg, 100));
		}
		[TestMethod]
		public void WriteFieldMustWriteFieldBasedOnProtocolFields()
		{
			var protocol = new GenericIsoProtocol();
			protocol.Fields = new GenericIsoProtocolField[]
			{
				new FixedIsoField { FieldNo = 2, DataType = "text", Length = 6 },
			};

			var msg = new IsoMessage(1100);
			msg[2] = "123456";

			var stream = new MemoryStream();

			protocol.WriteField(stream, 2, msg, 100);

			Assert.AreEqual("123456".ToBytes().ToHex(), stream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteFieldMustThrowExceptionIfFieldIsNotFoundInProtocol()
		{
			var protocol = new GenericIsoProtocol();
			protocol.Fields = new GenericIsoProtocolField[]
			{
				new FixedIsoField { FieldNo = 3, DataType = "text", Length = 6 },
			};

			var msg = new IsoMessage(1100);
			msg[2] = "123456";

			var stream = new MemoryStream();

			Assert.ThrowsException<IsoMessageReadException>(() => protocol.WriteField(stream, 2, msg, 100));
		}
	}
}
