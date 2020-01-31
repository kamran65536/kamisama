namespace KamiSama.Iso8583
{
	/// <summary>
	/// String Iso field
	/// </summary>
	public class StringIsoField : IsoFieldBase
	{
		/// <summary>
		/// inner data field
		/// </summary>
		public string Data { get; set; }
		/// <summary>
		/// returns the debug string: inner string
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
		public override string ToDebugString(int fieldNo) => Data;
		/// <summary>
		/// returns the inner string
		/// </summary>
		/// <returns></returns>
		public override string ToString() => Data;
	}
}
