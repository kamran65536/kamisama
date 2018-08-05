using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Iso8583.Protocols.Generic;
using KamiSama.Iso8583.Protocols.Generic.DataTypeHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583_Protocols
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.Generic.FixedIsoField")]
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
	}
}
