namespace KamiSama.Extensions.Xml.Tests
{
	static class ArrayUtility
	{
		public static bool ArrayEqual<T>(T[] arr1, T[] arr2)
		{
			if (arr1 == null)
				return arr2 == null;
			if (arr1.Length != arr2.Length)
				return false;

			for (int i = 0; i < arr1.Length; i++)
				if (!arr1[i].Equals(arr2[i]))
					return false;

			return true;
		}
	}
}
