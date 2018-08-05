using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.FixedIsoField")]
	[ExcludeFromCodeCoverage]
	public class FixedIsoFieldTests
	{
		[TestMethod]
		public void FixedFieldMustBeReadAccordingToLength()
		{
			var field = new FixedIsoField
			{
				DataType = "txt",
				FieldNo = 2,
				Length = 10,
			};
			var isoMessage = new IsoMessage("1100");
			var memStream = new MemoryStream("1234567890aa".ToBytes());

			field.Read(memStream, 2, isoMessage);

			Assert.AreEqual("1234567890", isoMessage[2] + "");
			Assert.AreEqual(10, memStream.Position);
		}
		[TestMethod]
		public void FixedFieldMustThrowExceptionOnInvalidStream()
		{
			var field = new FixedIsoField
			{
				DataType = "txt",
				FieldNo = 2,
				Length = 10,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream("1234".ToBytes());

			Assert.ThrowsException<IsoMessageReadException>(() => field.Read(stream, 2, msg));
		}
		[TestMethod]
		public void FixedFieldMustWriteAccordingToLength()
		{
			var field = new FixedIsoField
			{
				DataType = "txt",
				FieldNo = 2,
				Length = 10,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream();

			msg[2] = "1234567890";

			field.Write(stream, 2, msg);

			Assert.AreEqual("1234567890", stream.ToArray().GetString());
		}
		[TestMethod]
		public void FixedFieldMustThrowExceptionOnInvalidLengthData()
		{
			var field = new FixedIsoField
			{
				DataType = "txt",
				FieldNo = 2,
				Length = 10,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream();

			msg[2] = "12345678";

			Assert.ThrowsException<IsoMessageWriteException>(() => field.Write(stream, 2, msg));
		}
	}
}
