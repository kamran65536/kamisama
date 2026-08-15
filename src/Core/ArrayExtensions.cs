namespace KamiSama.Extensions;

/// <summary>
/// Provides extension methods for padding arrays and removing matching trailing elements.
/// Use these helpers when an array must be resized or normalized without mutating the original instance.
/// </summary>
public static class ArrayExtensions
{
	/// <summary>
	/// Returns an array padded to the first length that satisfies the specified predicate.
	/// </summary>
	/// <typeparam name="TArrayItem"></typeparam>
	/// <param name="arr">the array to be padded</param>
	/// <param name="paddingCriteria">padding criteria</param>
	/// <param name="paddingValue">the padding value</param>
	/// <returns></returns>
	public static TArrayItem[] Pad<TArrayItem>(this TArrayItem[] arr, Func<int, bool> paddingCriteria, TArrayItem paddingValue = default!)
	{
		var newSize = arr.Length;
		while (!paddingCriteria(newSize))
			newSize++;

		return arr.Pad(newSize, paddingValue);
	}
	/// <summary>
	/// Returns an array padded to the specified length.
	/// </summary>
	/// <typeparam name="TArrayItem"></typeparam>
	/// <param name="arr">the array to be padded</param>
	/// <param name="newSize">array new size</param>
	/// <param name="paddingValue">the padding value</param>
	/// <returns></returns>
	/// <exception cref="ArgumentException">if new size is smaller than array's size</exception>
	public static TArrayItem[] Pad<TArrayItem>(this TArrayItem[] arr, int newSize, TArrayItem paddingValue = default!)
	{
		if (newSize == arr.Length)
			return arr;
		if (newSize < arr.Length)
			throw new ArgumentException($"New size {newSize} cannot be smaller than array's size {arr.Length}");

		var result = new TArrayItem[newSize];

		Array.Copy(arr, 0, result, 0, arr.Length);

		for (int i = arr.Length; i < newSize; i++)
			result[i] = paddingValue;

		return result;
	}
	/// <summary>
	/// Returns an array with consecutive trailing elements that satisfy the predicate removed.
	/// </summary>
	/// <typeparam name="TArrayItem"></typeparam>
	/// <param name="arr">the array to be trimmed</param>
	/// <param name="trimmingCriteria">the criteria for trimming</param>
	/// <returns></returns>
	public static TArrayItem[] TrimEnd<TArrayItem>(this TArrayItem[] arr, Func<TArrayItem, bool> trimmingCriteria)
	{
		int newSize = arr.Length;

		while ((newSize > 0) && trimmingCriteria(arr[newSize - 1]))
			newSize--;

		if (newSize == arr.Length)
			return arr;

		var result = new TArrayItem[newSize];

		Array.Copy(arr, 0, result, 0, newSize);

		return result;
	}
	/// <summary>
	/// Returns an array with consecutive trailing elements equal to the specified value removed.
	/// </summary>
	/// <typeparam name="TArrayItem"></typeparam>
	/// <param name="arr">the array to be trimmed</param>
	/// <param name="trimmingItem">the trimming item</param>
	/// <returns></returns>
	public static TArrayItem[] TrimEnd<TArrayItem>(this TArrayItem[] arr, TArrayItem trimmingItem)
	{
		if (object.Equals(trimmingItem, null))
			return arr.TrimEnd(x => object.Equals(x, null));
		else
			return arr.TrimEnd(x => trimmingItem.Equals(x));
	}
}
