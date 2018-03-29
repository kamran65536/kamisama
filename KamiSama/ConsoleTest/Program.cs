using System;
using System.Security.Cryptography;
using KamiSama.Extenders;
using KamiSama.Iso8583;
using KamiSama.Iso8583.Xml;
using Ninject.Planning.Bindings;
using KamiSama.Extenders;
using System.Linq;

namespace ConsoleTest
{
	public class KamranBinding : Binding
	{
		public KamranBinding(Type service) : base(service)
		{
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//var msg = new IsoMessage(1100);

			//msg[2] = "6280231110000444";
			//msg[65] = "salaam";
			//msg[128] = "6280231110000444";

			//Console.WriteLine(msg.ToDebugString());
			//var str = msg.GetXmlIsoMessage(true).Serialize(true);
			//Console.WriteLine(str);

			//msg = str.Deserialize<XmlIsoMessage>().GetIsoMessage();
			//str = msg.GetXmlIsoMessage(true).Serialize(true);
			//Console.WriteLine(str);

			var aes = TripleDES.Create();
			
			aes.GenerateKey();
			var key = aes.Key;
			var data = Enumerable.Range(1, 64).Select(x => (byte) x).ToArray();
			Console.WriteLine($"data     ({data.Length})" + data.ToHex());
			var cipher = data.TripleDesEncrypt(key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);
			Console.WriteLine($"cipher    ({cipher.Length})" + cipher.ToHex());
			var data2 = cipher.TripleDesDecrypt(key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);
			Console.WriteLine($"data2    ({data2.Length})" + data2.ToHex());


		}
	}
}
