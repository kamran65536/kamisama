using KamiSama.Extenders;

namespace KamiSama.Iso8583
{
	public class BinaryIsoField : IsoFieldBase
	{
		public byte[] Data { get; set; }

		

		public override string ToDebugString(int fieldNo)
			=> "hex:"+Data.ToHex("");
		public override string ToString() => Data?.ToHex();
	}
}
