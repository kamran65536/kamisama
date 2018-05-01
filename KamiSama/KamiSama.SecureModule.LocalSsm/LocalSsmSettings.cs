using System;
using KamiSama.Configs;

namespace KamiSama.SecureModule.LocalSsm
{
	public class LocalSsmSettings : ConfigData<LocalSsmSettings>
    {
		public byte[] MasterKey { get; set; }
		public string MasterKeyAlgorithm { get; set; }

		public string FileBasedKeyStorePath { get; set; } = "./local-ssm/";
	}
}
