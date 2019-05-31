using System.Diagnostics.CodeAnalysis;
using System.Text;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.GenericIsoFieldBase")]
	[ExcludeFromCodeCoverage]
	public class GenericIsoProtocolFieldTests
	{
		private static void VerifyGetDataHandlerOutput<_HandlerType>(params string[] dataTypes)
		{
			foreach (var dataType in dataTypes)
			{
				var field = new FixedIsoField { DataType = dataType, FieldNo = 2, Length = 10 };

				var handler = field.GetDataTypeHandler(true);

				Assert.IsInstanceOfType(handler, typeof(_HandlerType));
			}
		}
		[TestMethod]
		public void GetDataTypeHandlerMustResolveTextDataHandlerForTxt()
		{
			VerifyGetDataHandlerOutput<TextDataTypeHandler>("txt", "text");
			VerifyGetDataHandlerOutput<BinaryDataTypeHandler>("bin", "binary");
			VerifyGetDataHandlerOutput<BcdDataTypeHandler>("bcd");
			VerifyGetDataHandlerOutput<BitmapDataTypeHandler>("bmp", "bitmap");
			VerifyGetDataHandlerOutput<HexBitmapDataTypeHandler>("hex-bmp", "bmp-hex", "hex-bitmap", "bitmap-hex");
		}
		[TestMethod]
		public void GetDataTypeHandlerMustCacheTextDataHanlerResolution()
		{
			var field = new FixedIsoField { DataType = "text", FieldNo = 2, Length = 10 };

			var handler1 = field.GetDataTypeHandler(true);
			var handler2 = field.GetDataTypeHandler(true);

			Assert.ReferenceEquals(handler1, handler2);
		}
		[TestMethod]
		public void GetDataTypeHandlerMustThrowAppropiateExceptionIfHanlderNotFound()
		{
			var field = new FixedIsoField { DataType = "kskssk", FieldNo = 2, Length = 10, Encoding = "utf-8" };

			Assert.ThrowsException<IsoMessageReadException>(() => field.GetDataTypeHandler(true));
			Assert.ThrowsException<IsoMessageWriteException>(() => field.GetDataTypeHandler(false));
		}
		[TestMethod]
		public void GenericIsoFieldMustUseUtf8AsDefaultEncoding()
		{
			var field = new FixedIsoField { DataType = "kskssk", FieldNo = 2, Length = 10 };

			Assert.AreEqual(field.Encoding, "utf-8");
		}
		[TestMethod]
		public void EncodingFieldMustBeCached()
		{
			var field = new FixedIsoField { DataType = "kskssk", FieldNo = 2, Length = 10 };

			Assert.IsNull(field.encoding);

			var encoding = field.GetEncoding();

			Assert.IsNotNull(field.encoding);
			Assert.AreEqual(field.encoding, encoding);
		}
	}
}
