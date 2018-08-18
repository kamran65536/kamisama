using KamiSama.SecureModule.LocalSsm.Algorithms;

namespace KamiSama.SecureModule.LocalSsm
{
	public class SsmKeyFactory : KeyFactoryBase<SsmKey>
	{
		public override SsmKey CreateKeyFrom(int algorithm, byte[] keyData)
		{
			return SsmKey.CreatePlainKey((Algorithm)algorithm, keyData);
		}
	}
}
