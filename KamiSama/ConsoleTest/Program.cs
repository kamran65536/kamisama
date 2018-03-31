using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using KamiSama.Extenders;
using KamiSama.SecureModule.LocalSsm;
using Ninject.Planning.Bindings;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{

			//aes.GenerateKey();

			//var ssm = new LocalSoftwareSecureModule(masterKey);
			//var key = SsmKey.CreateEncryptedKey(ssm, "aes", aes.Key);

			//var data = "Salaam man kamranam".ToBytes(Encoding.UTF8);


			//var cipher = ssm.Encrypt(key, data, padding: PaddingMode.PKCS7);
			//var key2 = ssm.LoadKey(ssm.StoreKey(key));
			//var data2 = ssm.Decrypt(key2, cipher, padding: PaddingMode.PKCS7);

			//Console.WriteLine($"[{data2.GetString(Encoding.UTF8)}]");
		}
	}
}
