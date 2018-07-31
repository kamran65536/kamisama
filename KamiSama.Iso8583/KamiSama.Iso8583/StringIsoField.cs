using System;

namespace KamiSama.Iso8583
{
	public class StringIsoField : IsoFieldBase
	{
		public string Data { get; set; }
		public override string ToDebugString(int fieldNo) => Data;
		public override string ToString() => Data;
	}
}
