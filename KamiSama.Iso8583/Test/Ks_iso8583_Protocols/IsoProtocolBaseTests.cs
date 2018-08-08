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
		private static byte[] GenerateMac(MemoryStream stream)
			=> stream.ToArray().DesEncrypt("1234567891234567".FromHex(), padding: PaddingMode.Zeros, cipherMode: CipherMode.CBC);

		[TestMethod]
		public void VerifyMacMustGenerateMacAndCompareIt()
		{
			var protocol = new GenericIsoProtocol(GenerateMac);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = GenerateMac(memStream);

			protocol.VerifyMac(msg, memStream);
		}
		[TestMethod]
		public void VerifyMacMustThrowExceptionOnInvalidMac()
		{
			var protocol = new GenericIsoProtocol(GenerateMac);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131".FromHex();

			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream));
			msg[64] = null;
			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream));
			msg[64] = new BinaryIsoField { Data = null };
			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream));
		}
		[TestMethod]
		public void VerifyMacMustIgnoreMacIfMacGenerationFunIsNull()
		{
			var protocol = new GenericIsoProtocol(null);

			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131".FromHex();

			protocol.VerifyMac(msg, memStream);
		}
		[TestMethod]
		public void VerifyMacMustThrowExceptionOnInvalidGenereateMacFunc()
		{
			var protocol = new GenericIsoProtocol(stream => null);
			var memStream = new MemoryStream("123456".FromHex());
			var msg = new IsoMessage(1100);
			msg[64] = "133432131".FromHex();

			Assert.ThrowsException<MacVerificationFailedException>(() => protocol.VerifyMac(msg, memStream));
		}
	}
}
