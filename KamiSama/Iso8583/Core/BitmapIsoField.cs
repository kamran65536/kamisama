using System;
using System.Linq;
using KamiSama.Extensions;

namespace KamiSama.Iso8583
{
	/// <summary>
	/// Bitmap Iso field containing flags which fields should be in the iso message
	/// </summary>
	public class BitmapIsoField : IsoFieldBase
	{
		private bool[] flags = new bool[64];
		/// <summary>
		/// returns field's flag
		/// </summary>
		/// <param name="fieldNo">the field number to return</param>
		/// <returns></returns>
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
		/// <summary>
		/// creates bitmap from hexadecimal value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
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
		/// <summary>
		/// returns bitmap hexadecimal value
		/// </summary>
		/// <returns></returns>
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
		/// <summary>
		/// returns debug string showing which fields flag is set. like P03, S100
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
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
		/// <summary>
		/// returns hexadecimal value of the iso bitmap
		/// </summary>
		/// <returns></returns>
		public override string ToString() => GetBitmapHex();
	}
}