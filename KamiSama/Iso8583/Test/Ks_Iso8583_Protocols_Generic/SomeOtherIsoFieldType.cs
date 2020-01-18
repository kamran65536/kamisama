using System.Diagnostics.CodeAnalysis;
using KamiSama.Iso8583;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	[ExcludeFromCodeCoverage]
	class SomeOtherIsoFieldType : IsoFieldBase
	{
		public override string ToDebugString(int fieldNo)
		{
			return "SomeOtherIsoField " + fieldNo;
		}
	}
}
