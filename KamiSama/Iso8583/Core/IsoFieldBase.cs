namespace KamiSama.Iso8583
{
	public abstract class IsoFieldBase
	{
		public abstract string ToDebugString(int fieldNo);

		public static implicit operator IsoFieldBase(string data)
			=> new StringIsoField { Data = data };
		public static implicit operator IsoFieldBase(byte[] data)
			=> new BinaryIsoField { Data = data };
	}
}