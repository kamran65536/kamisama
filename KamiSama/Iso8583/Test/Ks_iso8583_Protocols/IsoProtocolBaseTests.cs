using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Exceptions;
using KamiSama.Iso8583.Protocols.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_iso8583_Protocols
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Protocols.IsoPrtocolBase")]
	[ExcludeFromCodeCoverage]
	public class IsoProtocolBaseTests
	{
		private static byte[] GenerateMac(byte[] messageData)
			=> messageData.DesSign("1234567891234567".FromHex(), padding: PaddingMode.Zeros);

		[TestMethod]
		public void VerifyMacMustGenerateMacAndCompareIt()
		{
			var protocol = new GenericIsoProtocol(GenerateMac);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = GenerateMac("123456".FromHex()).ToHex();

			protocol.VerifyMac(msg, memStream, 3);
		}
		[TestMethod]
		public void VerifyMacMustThrowExceptionOnInvalidMac()
		{
			var protocol = new GenericIsoProtocol(GenerateMac);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131";

			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream, 3));
			msg[64] = null;
			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream, 3));
			msg[64] = new StringIsoField { Data = null };
			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream, 3));
		}
		[TestMethod]
		public void VerifyMacMustThrowExceptionIfMacPositionNotFound()
		{
			var protocol = new GenericIsoProtocol(GenerateMac);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131";

			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream, -1));
		}
		[TestMethod]
		public void VerifyMacMustIgnoreMacIfMacGenerationFunIsNull()
		{
			var protocol = new GenericIsoProtocol(null);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131".FromHex();

			protocol.VerifyMac(msg, memStream, 0);
		}
		[TestMethod]
		public void VerifyMacMustThrowExceptionOnInvalidGenereateMacFunc()
		{
			var protocol = new GenericIsoProtocol(stream => null);
			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131";

			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream, 3));
		}
		[TestMethod]
		public void WriteMacMustWriteMacAtP64OrS128()
		{
			var protocol = new GenericIsoProtocol(GenerateMac)
			{
				Fields = new GenericIsoProtocolField[]
				{
					new FixedIsoField { DataType = "text", FieldNo = 64, Length= 16 },
					new FixedIsoField { DataType = "text", FieldNo = 128, Length= 16 },
				}
			};
			var memStream = new MemoryStream();
			var stream = new MemoryStream();
			var msg = new IsoMessage(1100);
			memStream.Write("123456".FromHex());
			var mac = GenerateMac(memStream.ToArray());
			protocol.WriteMac(stream, msg, memStream, 100);

			Assert.AreEqual(mac.ToHex(), (msg[64] as StringIsoField).Data);

			msg[65] = "1234566"; // secondary bitmap must be present.
			mac = GenerateMac(memStream.ToArray());
			stream = new MemoryStream();

			protocol.WriteMac(stream, msg, memStream, 100);
			Assert.AreEqual(mac.ToHex(), (msg[128] as StringIsoField).Data);
		}
		[TestMethod]
		public void WriteMacMustIgnoreIfGenerateMacFuncIsNull()
		{
			var protocol = new GenericIsoProtocol(null)
			{
				Fields = new GenericIsoProtocolField[]
				{
					new FixedIsoField { DataType = "bin", FieldNo = 64, Length= 8 },
					new FixedIsoField { DataType = "bin", FieldNo = 128, Length= 8 },
				}
			};
			var memStream = new MemoryStream("123456".FromHex());
			var stream = new MemoryStream();
			var msg = new IsoMessage(1100);

			Assert.IsNull(msg[64]);

			protocol.WriteMac(stream, msg, memStream, 100);

			Assert.IsNull(msg[64]);

			msg[65] = "13445678";
			stream = new MemoryStream();

			Assert.IsNull(msg[128]);
			protocol.WriteMac(stream, msg, memStream, 100);

			Assert.IsNull(msg[128]);
		}
		[TestMethod]
		public void ReadMustReadSampleIsoMessage128()
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;
			var data = @"30343533313130304632334338343031383845313130303030313030303030303130303030303031163632383032333030303030303030303035353030303030303030303030303030303030383130313532363431343436363430393630383130313532363431303831303939313130383130363130353030363133313443063632383032330636323830323330303030303034343636343030393939393431353030303030303030393939393431354020202020202020202020202020202020202020202020202020202020496E7465726E657442616E6B01964D6574686F643D234170706C69636174696F6E3D496E7465726E657442616E6B696E6723557365726E616D653D6C6567616C74657374312350617373776F72643D4531304144433339343942413539414242453536453035374632304638383345234163636F756E744E756D6265723D236368616C6C656E67653D23436C69656E7449703D3A3A3123486173546F6B656E3D46616C736523466F726365436865636B50617373776F72643D46616C73652369734C6F67696E4D6573736167653D54727565433536324130413330373839393533320001200636323830323345433236413637304343303138394434";
			var stream = new MemoryStream(data.FromHex());

			var msg = protocol.Read(stream, 100);

			Assert.AreEqual(data.Length / 2, stream.Position);
			Assert.AreEqual("F23C840188E11000", msg.PrimaryBitmap.GetBitmapHex());
			Assert.AreEqual("0100000010000001", msg.SecondaryBitmap.GetBitmapHex());
			Assert.AreEqual("6280230000000000", (msg[2] as StringIsoField).Data);
			Assert.AreEqual("550000", (msg[3] as StringIsoField).Data);
			Assert.AreEqual("000000000000", (msg[4] as StringIsoField).Data);
			Assert.AreEqual("0810152641", (msg[7] as StringIsoField).Data);
			Assert.AreEqual("446640", (msg[11] as StringIsoField).Data);
			Assert.AreEqual("960810152641", (msg[12] as StringIsoField).Data);
			Assert.AreEqual("0810", (msg[13] as StringIsoField).Data);
			Assert.AreEqual("9911", (msg[14] as StringIsoField).Data);
			Assert.AreEqual("0810", (msg[17] as StringIsoField).Data);
			Assert.AreEqual("61050061314C", (msg[22] as StringIsoField).Data);
			Assert.AreEqual("628023", (msg[32] as StringIsoField).Data);
			Assert.AreEqual("628023", (msg[33] as StringIsoField).Data);
			Assert.AreEqual("000000446640", (msg[37] as StringIsoField).Data);
			Assert.AreEqual("09999415", (msg[41] as StringIsoField).Data);
			Assert.AreEqual("000000009999415", (msg[42] as StringIsoField).Data);
			Assert.AreEqual("                            InternetBank", (msg[43] as StringIsoField).Data);
			Assert.AreEqual("Method=#Application=InternetBanking#Username=legaltest1#Password=E10ADC3949BA59ABBE56E057F20F883E#AccountNumber=#challenge=#ClientIp=::1#HasToken=False#ForceCheckPassword=False#isLoginMessage=True", (msg[48] as StringIsoField).Data);
			Assert.AreEqual("C562A0A307899532", (msg[52] as StringIsoField).Data);
			Assert.AreEqual(" ", (msg[72] as StringIsoField).Data);
			Assert.AreEqual("628023", (msg[100] as StringIsoField).Data);
			Assert.AreEqual("EC26A670CC0189D4", (msg[128] as StringIsoField).Data);
		}
		[TestMethod]
		public void ReadMustReadSampleIsoMessage64()
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;
			var data = @"303432373131303037323343383430313838453131303031163632383032333030303030303030303035353030303030303030303030303030303030383130313532363431343436363430393630383130313532363431303831303939313130383130363130353030363133313443063632383032330636323830323330303030303034343636343030393939393431353030303030303030393939393431354020202020202020202020202020202020202020202020202020202020496E7465726E657442616E6B01964D6574686F643D234170706C69636174696F6E3D496E7465726E657442616E6B696E6723557365726E616D653D6C6567616C74657374312350617373776F72643D4531304144433339343942413539414242453536453035374632304638383345234163636F756E744E756D6265723D236368616C6C656E67653D23436C69656E7449703D3A3A3123486173546F6B656E3D46616C736523466F726365436865636B50617373776F72643D46616C73652369734C6F67696E4D6573736167653D547275654335363241304133303738393935333233393042383546463930303936443546";
			var stream = new MemoryStream(data.FromHex());

			var msg = protocol.Read(stream, 100);

			Assert.AreEqual(data.Length / 2, stream.Position);
			Assert.AreEqual("723C840188E11001", msg.PrimaryBitmap.GetBitmapHex());
			Assert.AreEqual("6280230000000000", (msg[2] as StringIsoField).Data);
			Assert.AreEqual("550000", (msg[3] as StringIsoField).Data);
			Assert.AreEqual("000000000000", (msg[4] as StringIsoField).Data);
			Assert.AreEqual("0810152641", (msg[7] as StringIsoField).Data);
			Assert.AreEqual("446640", (msg[11] as StringIsoField).Data);
			Assert.AreEqual("960810152641", (msg[12] as StringIsoField).Data);
			Assert.AreEqual("0810", (msg[13] as StringIsoField).Data);
			Assert.AreEqual("9911", (msg[14] as StringIsoField).Data);
			Assert.AreEqual("0810", (msg[17] as StringIsoField).Data);
			Assert.AreEqual("61050061314C", (msg[22] as StringIsoField).Data);
			Assert.AreEqual("628023", (msg[32] as StringIsoField).Data);
			Assert.AreEqual("628023", (msg[33] as StringIsoField).Data);
			Assert.AreEqual("000000446640", (msg[37] as StringIsoField).Data);
			Assert.AreEqual("09999415", (msg[41] as StringIsoField).Data);
			Assert.AreEqual("000000009999415", (msg[42] as StringIsoField).Data);
			Assert.AreEqual("                            InternetBank", (msg[43] as StringIsoField).Data);
			Assert.AreEqual("Method=#Application=InternetBanking#Username=legaltest1#Password=E10ADC3949BA59ABBE56E057F20F883E#AccountNumber=#challenge=#ClientIp=::1#HasToken=False#ForceCheckPassword=False#isLoginMessage=True", (msg[48] as StringIsoField).Data);
			Assert.AreEqual("C562A0A307899532", (msg[52] as StringIsoField).Data);
			Assert.AreEqual("390B85FF90096D5F", (msg[64] as StringIsoField).Data);
		}
		[TestMethod]
		public void WriteMustWriteSampleIsoMessage64()
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;
			var msg = new IsoMessage(1100);
			msg[2] = "6280230000000000";
			msg[3] = "550000";
			msg[4] = "000000000000";
			msg[7] = "0810152641";
			msg[11] = "446640";
			msg[12] = "960810152641";
			msg[13] = "0810";
			msg[14] = "9911";
			msg[17] = "0810";
			msg[22] = "61050061314C";
			msg[32] = "628023";
			msg[33] = "628023";
			msg[37] = "000000446640";
			msg[41] = "09999415";
			msg[42] = "000000009999415";
			msg[43] = "                            InternetBank";
			msg[48] = "Method=#Application=InternetBanking#Username=legaltest1#Password=E10ADC3949BA59ABBE56E057F20F883E#AccountNumber=#challenge=#ClientIp=::1#HasToken=False#ForceCheckPassword=False#isLoginMessage=True";
			msg[52] = "C562A0A307899532";

			var memStream = new MemoryStream();

			protocol.Write(memStream, msg, 100);
			Assert.AreEqual("390B85FF90096D5F", (msg[64] as StringIsoField).Data);
			Assert.AreEqual("303432373131303037323343383430313838453131303031163632383032333030303030303030303035353030303030303030303030303030303030383130313532363431343436363430393630383130313532363431303831303939313130383130363130353030363133313443063632383032330636323830323330303030303034343636343030393939393431353030303030303030393939393431354020202020202020202020202020202020202020202020202020202020496E7465726E657442616E6B01964D6574686F643D234170706C69636174696F6E3D496E7465726E657442616E6B696E6723557365726E616D653D6C6567616C74657374312350617373776F72643D4531304144433339343942413539414242453536453035374632304638383345234163636F756E744E756D6265723D236368616C6C656E67653D23436C69656E7449703D3A3A3123486173546F6B656E3D46616C736523466F726365436865636B50617373776F72643D46616C73652369734C6F67696E4D6573736167653D547275654335363241304133303738393935333233393042383546463930303936443546", memStream.ToArray().ToHex());
		}
		[TestMethod]
		public void WriteMustWriteSampleIsoMessage128()
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;
			var msg = new IsoMessage(1100);
			msg[2] = "6280230000000000";
			msg[3] = "550000";
			msg[4] = "000000000000";
			msg[7] = "0810152641";
			msg[11] = "446640";
			msg[12] = "960810152641";
			msg[13] = "0810";
			msg[14] = "9911";
			msg[17] = "0810";
			msg[22] = "61050061314C";
			msg[32] = "628023";
			msg[33] = "628023";
			msg[37] = "000000446640";
			msg[41] = "09999415";
			msg[42] = "000000009999415";
			msg[43] = "                            InternetBank";
			msg[48] = "Method=#Application=InternetBanking#Username=legaltest1#Password=E10ADC3949BA59ABBE56E057F20F883E#AccountNumber=#challenge=#ClientIp=::1#HasToken=False#ForceCheckPassword=False#isLoginMessage=True";
			msg[52] = "C562A0A307899532";
			msg[72] = " ";
			msg[100] = "628023";
			
			var memStream = new MemoryStream();

			protocol.Write(memStream, msg, 100);

			Assert.AreEqual("EC26A670CC0189D4", (msg[128] as StringIsoField).Data);
			Assert.AreEqual("30343533313130304632334338343031383845313130303030313030303030303130303030303031163632383032333030303030303030303035353030303030303030303030303030303030383130313532363431343436363430393630383130313532363431303831303939313130383130363130353030363133313443063632383032330636323830323330303030303034343636343030393939393431353030303030303030393939393431354020202020202020202020202020202020202020202020202020202020496E7465726E657442616E6B01964D6574686F643D234170706C69636174696F6E3D496E7465726E657442616E6B696E6723557365726E616D653D6C6567616C74657374312350617373776F72643D4531304144433339343942413539414242453536453035374632304638383345234163636F756E744E756D6265723D236368616C6C656E67653D23436C69656E7449703D3A3A3123486173546F6B656E3D46616C736523466F726365436865636B50617373776F72643D46616C73652369734C6F67696E4D6573736167653D54727565433536324130413330373839393533320001200636323830323345433236413637304343303138394434", memStream.ToArray().ToHex());
		}
	}
}
