using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Iso8583;

namespace Test.Ks_Iso8583_Protocols_Generic
{
	class SomeOtherIsoFieldType : IsoFieldBase
	{
		public override string ToDebugString(int fieldNo)
		{
			return "SomeOtherIsoField " + fieldNo;
		}
	}
}
