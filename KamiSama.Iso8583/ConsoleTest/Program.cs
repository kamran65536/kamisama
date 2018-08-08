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
		private static byte[] GenerateMac(MemoryStream memoryStream)
		{
			var key = "1234567891234567".FromHex();
			return memoryStream.ToArray().DesSign(key, padding: PaddingMode.Zeros);
		}

		static void Main(string[] args)
		{
			var protocol = new FileInfo("./protocol.xml").Deserialize<GenericIsoProtocol>();
			protocol.GenerateMacFunc = GenerateMac;

			var data = @"30343132313130304632334338343031383845313030303030313030303030303130303030303030163632383032333030303030303030303035353030303030303030303030303030303030383130313135353431343436363234393630383130313135353431303831303939313130383130363130353030363133313443063632383032330636323830323330303030303034343636323430393939393431353030303030303030393939393431351620202020496E7465726E657442616E6B01964D6574686F643D234170706C69636174696F6E3D496E7465726E657442616E6B696E6723557365726E616D653D6C6567616C74657374312350617373776F72643D4531304144433339343942413539414242453536453035374632304638383345234163636F756E744E756D6265723D236368616C6C656E67653D23436C69656E7449703D3D3D3123486173546F6B656E3D46616C736523466F726365436865636B50617373776F72643D46616C73652369734C6F67696E4D6573736167653D5472756500000636323830323336313336384345393042314539333633";

			var request = protocol.Read(new MemoryStream(data.FromHex()), 100);

			var memStream = new MemoryStream();

			protocol.Write(memStream, request, 100);

			var data2 = memStream.ToArray().ToHex();

			Console.WriteLine(data == data2);
			Console.WriteLine($"data : {data}");
			Console.WriteLine($"data2: {data2}");

			var request2 = protocol.Read(new MemoryStream(data2.FromHex()), 100);

			Console.WriteLine(request2.ToDebugString());
		}
	}
}
