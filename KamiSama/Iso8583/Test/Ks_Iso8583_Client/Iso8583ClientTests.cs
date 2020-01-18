using KamiSama.Iso8583;
using KamiSama.Iso8583.Client;
using KamiSama.Iso8583.Client.Exceptions;
using KamiSama.Iso8583.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.IO;
using System.Net.Sockets;

namespace Test.Ks_Iso8583_Client
{
	[TestClass]
	[TestCategory("Ks.Iso8583.Client.Iso8583Client")]
	public class Iso8583ClientTests
	{
		[TestMethod]
		public void Send_must_send_and_receive_successfuly()
		{
			var client = Substitute.For<ITcpClient>();
			var protocol = Substitute.For<IIsoProtocol>();

			protocol.When(p => p.Write(Arg.Any<Stream>(), Arg.Any<IsoMessage>())).Do(callInfo => { });
			protocol.Read(Arg.Any<Stream>()).Returns(new IsoMessage(210) { });
			var isoClient = new Iso8583Client(protocol);

			var result = isoClient.Send(new IsoMessage(200) { }, client);

			Assert.AreEqual("0210", result.Id);
		}
		[TestMethod]
		public void Send_throws_SendingMessageFailedException_if_sending_request_failed()
		{
			var client = Substitute.For<ITcpClient>();
			var protocol = Substitute.For<IIsoProtocol>();

			protocol.Read(Arg.Any<Stream>()).Returns(new IsoMessage(210) { });
			protocol.When(p => p.Write(Arg.Any<Stream>(), Arg.Any<IsoMessage>())).Do(callInfo => throw new Exception());

			var isoClient = new Iso8583Client(protocol);

			Assert.ThrowsException<SendingMessageFailedException>(() => isoClient.Send(new IsoMessage(200) { }, client));
		}
		[TestMethod]
		public void Send_throws_ReceivingMessageFailedException_if_receiving_response_failed()
		{
			var client = Substitute.For<ITcpClient>();
			var protocol = Substitute.For<IIsoProtocol>();

			protocol.When(p => p.Write(Arg.Any<Stream>(), Arg.Any<IsoMessage>())).Do(callInfo => { });
			protocol.When(p => p.Read(Arg.Any<Stream>())).Do(callInfo => throw new Exception());

			var isoClient = new Iso8583Client(protocol);

			Assert.ThrowsException<ReceivingMessageFailedException>(() => isoClient.Send(new IsoMessage(200) { }, client));
		}
	}
}
