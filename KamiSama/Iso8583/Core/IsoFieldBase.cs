namespace KamiSama.Iso8583
{
	/// <summary>
	/// Iso Field Base
	/// </summary>
	public abstract class IsoFieldBase
	{
		/// <summary>
		/// returns debug string (used for debugging)
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
		public abstract string ToDebugString(int fieldNo);
		/// <summary>
		/// Converts string to StringIsoField
		/// </summary>
		/// <param name="str"></param>
		public static implicit operator IsoFieldBase(string str)
			=> new StringIsoField { Data = str };
		/// <summary>
		/// Converts byte array to BinaryIsoField
		/// </summary>
		/// <param name="data"></param>
		public static implicit operator IsoFieldBase(byte[] data)
			=> new BinaryIsoField { Data = data };
	}
}