using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols
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
			Assert.AreEqual("12345678", memStream.ToArray().ToHex());
		}
		[TestMethod]
		public void ReadHeaderAndDataMustThrowExceptionOnInvalidLength()
		{
			var protocol = new GenericIsoProtocol();
			var stream = new MemoryStream("00".FromHex());

			Assert.ThrowsException<IsoMessageReadException>(() => protocol.ReadHeaderAndData(stream, out MemoryStream memStream, out IsoMessage msg, 100));
			stream = new MemoryStream("3030303b".FromHex());
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
	}
}
