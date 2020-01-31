using KamiSama.Extensions;

namespace KamiSama.Iso8583
{
	/// <summary>
	/// Binary Iso Field, containing raw binary data (byte array)
	/// </summary>
	public class BinaryIsoField : IsoFieldBase
	{
		/// <summary>
		/// raw data
		/// </summary>
		public byte[] Data { get; set; }
		/// <summary>
		/// returns debug string (hexadecimal value)
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
		public override string ToDebugString(int fieldNo)
			=> "hex:"+Data.ToHex("");
		/// <summary>
		/// returns hexadecimal value of the binary iso field
		/// </summary>
		/// <returns></returns>
		public override string ToString() => Data?.ToHex();
	}
}
