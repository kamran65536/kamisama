using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
	[ExcludeFromCodeCoverage]
	public static class AssertEx
	{
		public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> obj)
			=> AreEqual(expected, obj, "Arrays are not equal.");

		public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> obj, string message)
		{
			var expectedArr = expected?.ToArray();
			var arr = obj?.ToArray();

			if ((expectedArr == null) || (arr == null))
				if ((expectedArr != null) || (arr != null))
					Assert.Fail(message);

			if (arr.Length != expectedArr.Length)
				Assert.Fail(message);

			for (int i = 0; i < arr.Length; i++)
				if ((arr[i] == null) || (expectedArr[i] == null))
					if ((arr[i] != null) || (expectedArr[i] != null))
						Assert.Fail(message);
		}

		public static void AnyException<_ExceptionType>(Action action, string message)
			where _ExceptionType : Exception
		{
			try
			{
				action();
			}
			catch (_ExceptionType)
			{
				return;
			} catch (Exception exp)
			{
				Assert.Fail(message + $" exception of type {exp.GetType().Name} is catched.");
				return;
			}

			Assert.Fail(message + $" no exception is catched.");
		}
		public static void AnyException<_ExceptionType>(Action action)
			where _ExceptionType : Exception
			=> AnyException<_ExceptionType>(action, "");

		public static void AreEqual<T>(T[] expected, T[] arr, string message) => AreEqual((IEnumerable<T>)expected, (IEnumerable<T>)arr, message);
		public static void AreEqual<T>(T[] expected, T[] arr) => AreEqual((IEnumerable<T>)expected, (IEnumerable<T>)arr);
		public static void AreEqual<T>(T expected, T obj) => Assert.AreEqual(expected, obj);
		public static void AreEqual<T>(T expected, T obj, string message) => Assert.AreEqual(expected, obj, message);

		public static void ThrowsException<_ExceptionType>(Action action, string message) where _ExceptionType : Exception
			=> Assert.ThrowsException<_ExceptionType>(action, message);
		public static void ThrowsException<_ExceptionType>(Action action) where _ExceptionType : Exception
			=> Assert.ThrowsException<_ExceptionType>(action);

		public static void Null(object obj) => Assert.IsNull(obj);
		public static void IsNull(object obj) => Assert.IsNull(obj);
		public static void Null(object obj, string message) => Assert.IsNull(obj, message);
		public static void IsNull(object obj, string message) => Assert.IsNull(obj, message);
	}
}
