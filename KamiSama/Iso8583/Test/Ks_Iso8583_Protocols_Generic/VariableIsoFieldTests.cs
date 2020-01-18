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
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.VariableIsoField")]
	[ExcludeFromCodeCoverage]
	public class VariableIsoFieldTests
	{
		[TestMethod]
		public void VariableFieldMustBeReadAccordingToLengthAndType()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LVar,
				FieldNo = 2,
			};
			var isoMessage = new IsoMessage("1100");
			var memStream = new MemoryStream("51234567".ToBytes());

			field.Read(memStream, 2, isoMessage);

			Assert.AreEqual("12345", isoMessage[2] + "");
			Assert.AreEqual(6, memStream.Position);
		}
		[TestMethod]
		public void VariableFieldMustThrowExceptionOnInvalidStream()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream("101234".ToBytes());

			Assert.ThrowsException<IsoMessageReadException>(() => field.Read(stream, 2, msg));
		}
		[TestMethod]
		public void VariableFieldMustThrowExceptionOnNegativeLength()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream("-11234".ToBytes());

			Assert.ThrowsException<IsoMessageReadException>(() => field.Read(stream, 2, msg));
		}
		[TestMethod]
		public void VariableFieldMustWriteAccordingToLength()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};
			var msg = new IsoMessage("1100");
			var stream = new MemoryStream();

			msg[2] = "1234567890";

			field.Write(stream, 2, msg);

			Assert.AreEqual("101234567890", stream.ToArray().GetString());
		}
		[TestMethod]
		public void VariableFieldMustThrowExceptionOnFaultyStream()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};
			var msg = new IsoMessage("1100");
			var stream = Substitute.For<MemoryStream>();

			stream.When(x => x.Write(Arg.Any<byte[]>(), Arg.Any<int>(), Arg.Any<int>())).Do(x => { throw new Exception(); });

			msg[2] = "1234567890";

			Assert.ThrowsException<IsoMessageWriteException>(() => field.Write(stream, 2, msg));
		}
		private static void VerifyGetLengthDataTypeHandlerOutput<_HandlerType>(params string[] lengthDataTypes)
		{
			foreach (var lengthDataType in lengthDataTypes)
			{
				var field = new VariableIsoField
				{
					DataType = "txt",
					LengthDataType = lengthDataType,
					LengthType = VariableLengthType.LLVar,
					FieldNo = 2,
				};

				var handler = field.GetLengthDataTypeHandler(true);

				Assert.IsInstanceOfType(handler, typeof(_HandlerType));
			}
		}
		[TestMethod]
		public void GetLengthDataTypeHandlerMustResolveTextDataHandlerForTxt()
		{
			VerifyGetLengthDataTypeHandlerOutput<TextDataTypeHandler>("txt", "text");
			VerifyGetLengthDataTypeHandlerOutput<BinaryDataTypeHandler>("bin", "binary");
			VerifyGetLengthDataTypeHandlerOutput<BcdDataTypeHandler>("bcd");
			VerifyGetLengthDataTypeHandlerOutput<BitmapDataTypeHandler>("bmp", "bitmap");
			VerifyGetLengthDataTypeHandlerOutput<HexBitmapDataTypeHandler>("hex-bmp", "bmp-hex", "hex-bitmap", "bitmap-hex");
		}
		[TestMethod]
		public void GetGetLengthDataTypeHandlerMustCacheTextDataHanlerResolution()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "txt",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};

			var handler1 = field.GetLengthDataTypeHandler(true);
			var handler2 = field.GetLengthDataTypeHandler(true);

			Assert.ReferenceEquals(handler1, handler2);
		}
		[TestMethod]
		public void GetLengthDataTypeHandlerMustThrowAppropiateExceptionIfHanlderNotFound()
		{
			var field = new VariableIsoField
			{
				DataType = "txt",
				LengthDataType = "kskssk",
				LengthType = VariableLengthType.LLVar,
				FieldNo = 2,
			};

			Assert.ThrowsException<IsoMessageReadException>(() => field.GetLengthDataTypeHandler(true));
			Assert.ThrowsException<IsoMessageWriteException>(() => field.GetLengthDataTypeHandler(false));
		}
		
	}
}
