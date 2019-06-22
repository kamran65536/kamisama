using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Protocols.Generic;
using KamiSama.Extenders;
using System.Security.Cryptography;
using KamiSama.Iso8583.Client;

namespace ConsoleTest
{
	class Program
	{
		private static byte[] GenerateMac(byte[] arr)
			=>arr.DesSign("1234567891234567".FromHex(), padding: PaddingMode.Zeros);

		static void Main(string[] args)
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;

			var msg = new IsoMessage(1200);

			msg[02] = "6280231400751292";
			msg[03] = "310000";
			msg[04] = "000000000000";
			msg[06] = "000000000000";
			msg[07] = "0808121800";
			msg[11] = "446802";
			msg[12] = "970517161200";
			msg[14] = "9903";
			msg[17] = "0810";
			msg[22] = "61050061313C"; //"61050061314C" //"000010000000";
			msg[32] = "628023";
			msg[33] = "628023";
			msg[37] = "000000446624";
			msg[41] = "09999411";   //09999411 --> USSD    //09999415 --> InternetBank
			msg[42] = "000000009999411";  //000000009999411 --> USSD    //000000009999415 --> InternetBank
			msg[43] = "UssdMPayment";
			msg[48] = "";
			msg[52] = PinBlockUtility.GetPinBlock("6280231400751292", "555555", "1234567891234567".FromHex());
			msg[53] = "1234567891234567".FromHex();

			var client = new Iso8583Client(protocol);

			//var response = client.Send(msg, "tabnak.ir", 443);
			var response = client.Send(msg, "10.9.12.41", 19000);
			//var response = client.Send(msg, "10.11.21.42", 19000);

			Console.WriteLine(response[39] + "");
		}
	}
}
