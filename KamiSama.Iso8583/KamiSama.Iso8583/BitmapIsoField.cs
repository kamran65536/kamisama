using System;
using System.Linq;
using KamiSama.Extenders;

namespace KamiSama.Iso8583
{
	public class BitmapIsoField : IsoFieldBase
	{
		private bool[] flags;

		public BitmapIsoField()
		{
			this.flags = new bool[64];
		}

		public bool this[int fieldNo]
		{
			get
			{
				var org = fieldNo;
				if (fieldNo > 64)
					fieldNo -= 64;

				if ((fieldNo <= 0) || (fieldNo > 64))
					throw new IndexOutOfRangeException($"Invalid field no: {org}");

				return flags[fieldNo - 1];
			}
			set
			{
				var org = fieldNo;
				if (fieldNo > 64)
					fieldNo -= 64;

				if ((fieldNo <= 0) || (fieldNo > 64))
					throw new IndexOutOfRangeException($"Invalid field no: {org}");

				flags[fieldNo - 1] = value;
			}
		}

		public static BitmapIsoField FromHex(string str)
		{
			var arr = str.FromHex();

			var result = new BitmapIsoField();

			for (int i = 0; i < 64; i++)
			{
				var bit = 1 << (7 - i % 8);

				result.flags[i] = (arr[i / 8] & bit) == bit;
			}
			return result;
		}

		public string GetBitmapHex()
		{
			byte[] arr = new byte[8];

			for (int i = 0; i < 64; i++)
			{
				var bit = 1 << (7 - i % 8);

				if (flags[i])
					arr[i / 8] |= (byte) bit;
			}

			return arr.ToHex();
		}

	

		public override string ToDebugString(int fieldNo)
		{
			var prefix = (fieldNo == 0) ? "P" : "S";
			var fieldBase = (fieldNo == 0) ? 0 : 64;
			var fields = Enumerable
				.Range(0, 64)
				.Where(x => flags[x])
				.Select(x => prefix + (fieldBase + x + 1).ToString("00"));
			
			return $"(Bitmap) hex: {GetBitmapHex()} fields: {string.Join(", ", fields)}";
		}

		public override string ToString() => GetBitmapHex();
	}
}