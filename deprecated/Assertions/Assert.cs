using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KamiSama.Extensions.Assertions
{
	public class Assert
	{
		public static Assert That { get; } = new Assert();
		public Action<string> AssertionFailed { get; set; }
		[DebuggerHidden]
		protected Assert()
		{
			AssertionFailed += message => throw new AssertionFailedException(message);
		}
		#region basic boolean assertions
		[DebuggerHidden]
		public static void IsTrue(bool condition, string message = null)
		{
			if (!condition)
				That.AssertionFailed(message ?? "Condition must be true.");
		}
		[DebuggerHidden]
		public static void IsFalse(bool condition, string message = null)
			=> IsTrue(!condition, message ?? "Condition must be false.");
		#endregion
		#region object assertions
		[DebuggerHidden]
		public static void IsNull(object obj, string message = null)
			=> IsTrue(obj == null, message ?? $"Object [{obj}] must be null.");
		[DebuggerHidden]
		public static void IsNotNull(object obj, string message = null)
			=> IsTrue(obj != null, message ?? $"Object [{obj}] must not be null.");
		[DebuggerHidden]
		public static void AreEqual<TObject>(TObject obj1, TObject obj2, string message = null)
			=> IsTrue(object.Equals(obj1, obj2), message ?? $"Obj1 [{obj1}] and obj2 [{obj2}] must be equal.");
		[DebuggerHidden]
		public static void AreNotEqual<TObject>(TObject obj1, TObject obj2, string message = null)
			=> IsTrue(!object.Equals(obj1, obj2), message ?? $"Obj1 [{obj1}] and obj2 [{obj2}] must not be equal.");
		[DebuggerHidden]
		public static void AreReferenceEqual<TObject>(TObject obj1, TObject obj2, string message = null)
			=> IsTrue(object.ReferenceEquals(obj1, obj2), message ?? $"Obj1 [{obj1}] and obj2 [{obj2}] references must be equal.");
		#endregion
		#region string assertions
		[DebuggerHidden]
		public static void IsNullOrEmpty(string str, string message = null)
			=> IsTrue(string.IsNullOrEmpty(str), message ?? $"Str [{str}] must be null or empty.");
		[DebuggerHidden]
		public static void IsNotNullOrEmpty(string str, string message = null)
			=> IsTrue(!string.IsNullOrEmpty(str), message ?? $"Str [{str}] must not be null or empty.");
		[DebuggerHidden]
		public static void IsNullOrWhitespace(string str, string message = null)
			=> IsTrue(string.IsNullOrWhiteSpace(str), message ?? $"Str [{str}] must be null or whitespace.");
		[DebuggerHidden]
		public static void IsNotNullOrWhitespace(string str, string message = null)
			=> IsTrue(!string.IsNullOrWhiteSpace(str), message ?? $"Str [{str}] must not be null or whitespace.");
		#endregion
		#region enumeration assertions
		[DebuggerHidden]
		public static void IsEmpty<T>(IEnumerable<T> enumeration, string message = null)
			=> IsTrue(enumeration.Any(), message ?? $"Enumeration [{enumeration}] must be empty.");
		[DebuggerHidden]
		public static void IsNullOrEmpty<T>(IEnumerable<T> enumeration, string message = null)
			=> IsTrue((enumeration == null) || enumeration.Any(), message ?? $"Enumeration [{enumeration}] must be null or empty.");
		[DebuggerHidden]
		public static void Contains<T>(IEnumerable<T> enumeration, Func<T, bool> predicate, string message = null)
			=> IsTrue(enumeration.Any(predicate), message ?? "enumeration must contain any with specified predicate.");
		[DebuggerHidden]
		public static void Contains<T>(IEnumerable<T> enumeration, T value, string message = null)
			=> IsTrue(enumeration.Contains(value), message ?? $"Enumeration [{enumeration}] must contain the value.");
		[DebuggerHidden]
		public static void AreEqual<T>(T[] arr1, T[] arr2, string message = null)
		{
			if (message == null)
				message = $"Arr1 [{arr1}] must be equal to arr2 [{arr2}].";

			if ((arr1 == null) && (arr2 == null))
				return;

			Assert.IsTrue(arr1.Length == arr2.Length, message);
			for (int i = 0; i < arr1.Length; i++)
				Assert.AreEqual(arr1[i], arr2[i], message);
		}
		#endregion
		#region Type hirerachy assertions
		[DebuggerHidden]
		public static void IsInstanceOfType(object obj, Type type, string message = null)
			=> IsTrue(type.IsInstanceOfType(obj), message ?? $"Obj [{obj}] must be instance of type {type}");
		[DebuggerHidden]
		public static void IsInstanceOfType<T>(object obj, string message = null)
			=> IsInstanceOfType(obj, typeof(T), message);
		[DebuggerHidden]
		public static void IsNotInstanceOfType(object obj, Type type, string message = null)
			=> IsTrue(!type.IsInstanceOfType(obj), message ?? $"Obj [{obj}] must be instance of type {type}");
		[DebuggerHidden]
		public static void IsNotInstanceOfType<T>(object obj, string message = null)
			=> IsNotInstanceOfType(obj, typeof(T), message);
		#endregion
		#region Exception throwing assertions
		[DebuggerHidden]
		public static void ThrowsException(Action action, string message = null)
		{
			try
			{
				action();
			}
			catch
			{
				return;
			}
			That.AssertionFailed(message ?? $"Action [{action}] must throw exception.");
		}
		[DebuggerHidden]
		public static async Task ThrowsExceptionAsync(Func<Task> action, string message = null)
		{
			try
			{
				await action();
			}
			catch
			{
				return;
			}
			That.AssertionFailed(message ?? $"Action [{action}] must throw exception.");
		}
		[DebuggerHidden]
		public static void ThrowsException<TException>(Action action, string message = null)
			where TException : Exception
		{
			try
			{
				action();
			}
			catch (TException)
			{
				return;
			}
			That.AssertionFailed(message ?? $"Action [{action}] must throw exception of type {typeof(TException)}.");
		}
		[DebuggerHidden]
		public static async Task ThrowsExceptionAsync<TException>(Func<Task> action, string message = null)
			where TException : Exception
		{
			try
			{
				await action();
			}
			catch (TException)
			{
				return;
			}
			throw new AssertionFailedException(message ?? $"Action [{action}] must throw exception of type {typeof(TException)}.");
		}
		#endregion
	}
}
