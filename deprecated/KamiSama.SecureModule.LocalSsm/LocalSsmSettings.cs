using KamiSama.Configs;
using KamiSama.SecureModule.LocalSsm.Algorithms;

namespace KamiSama.SecureModule.LocalSsm
{
	public class LocalSsmSettings : ConfigData<LocalSsmSettings>
    {
		public byte[] MasterKey { get; set; }
		public Algorithm MasterKeyAlgorithm { get; set; }
	}
}
