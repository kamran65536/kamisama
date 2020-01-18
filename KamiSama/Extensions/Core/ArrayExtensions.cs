using System;

namespace KamiSama.Extensions
{
	public static class ArrayExtensions
	{
		public static T[] Pad<T>(this T[] arr, Func<int, bool> padCriteria, T pad = default(T))
		{
			var newSize = arr.Length;
			while (!padCriteria(newSize))
				newSize++;

			return arr.Pad(newSize, pad);
		}
		public static T[] Pad<T>(this T[] arr, int newSize, T pad = default(T))
		{
			if (newSize == arr.Length)
				return arr;

			var result = new T[newSize];

			Array.Copy(arr, 0, result, 0, arr.Length);

			for (int i = arr.Length; i < newSize; i++)
				result[i] = pad;

			return result;
		}

		public static T[] TrimEnd<T>(this T[] arr, Func<T, bool> trimCriteria)
		{
			int newSize = arr.Length;

			while ((newSize > 0) && trimCriteria(arr[newSize - 1]))
				newSize--;

			if (newSize == arr.Length)
				return arr;

			var result = new T[newSize];

			Array.Copy(arr, 0, result, 0, newSize);

			return result;
		}

		public static T[] TrimEnd<T>(this T[] arr, T _item)
		{
			if (object.Equals(_item, null))
				return arr.TrimEnd(x => object.Equals(x, null));
			else
				return arr.TrimEnd(x => _item.Equals(x));
		}
	}
}
