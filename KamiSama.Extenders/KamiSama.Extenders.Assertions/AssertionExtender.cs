using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KamiSama.Extenders.Assertions
{
	public static class AssertionExtender
	{
		[DebuggerHidden]
		public static void MustBeTrue(this bool condition, string message = null) => Assert.IsTrue(condition, message);
		[DebuggerHidden]
		public static void MustBeFalse(this bool condition, string message = null) => Assert.IsFalse(condition, message);
		[DebuggerHidden]
		public static void MustBeNull(this object obj, string message = null) => Assert.IsNull(obj, message);
		[DebuggerHidden]
		public static void MustNotBeNull(this object obj, string message = null) => Assert.IsNotNull(obj, message);
		[DebuggerHidden]
		public static void MustBeEqual<TObject>(this TObject obj1, TObject obj2, string message = null) => Assert.AreEqual(obj1, obj2, message);
		[DebuggerHidden]
		public static void MustNotBeEqual<TObject>(this TObject obj1, TObject obj2, string message = null) => Assert.AreNotEqual(obj1, obj2, message);
		[DebuggerHidden]
		public static void MustBeReferenceEqual<TObject>(this TObject obj1, TObject obj2, string message = null) => Assert.AreReferenceEqual(obj1, obj2, message);
		[DebuggerHidden]
		public static void MustBeNullOrEmpty(this string str, string message = null) => Assert.IsNullOrEmpty(str, message);
		[DebuggerHidden]
		public static void MustNotBeNullOrEmpty(this string str, string message = null) => Assert.IsNotNullOrEmpty(str, message);
		[DebuggerHidden]
		public static void MustBeNullOrWhitespace(this string str, string message = null) => Assert.IsNullOrWhitespace(str, message);
		[DebuggerHidden]
		public static void MustNotBeNullOrWhitespace(this string str, string message = null) => Assert.IsNotNullOrWhitespace(str, message);
		[DebuggerHidden]
		public static void MustBeEmpty<T>(IEnumerable<T> enumeration, string message = null) => Assert.IsEmpty(enumeration, message);
		[DebuggerHidden]
		public static void MustBeNullOrEmpty<T>(IEnumerable<T> enumeration, string message = null) => Assert.IsNullOrEmpty(enumeration, message);
		[DebuggerHidden]
		public static void MustContain<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate, string message = null) => Assert.Contains(enumeration, predicate, message);
		[DebuggerHidden]
		public static void MustContain<T>(this IEnumerable<T> enumeration, T value, string message = null) => Assert.Contains(enumeration, value, message);
		[DebuggerHidden]
		public static void MustBeEqual<T>(this T[] arr1, T[] arr2, string message = null) => Assert.AreEqual(arr1, arr2, message);
		[DebuggerHidden]
		public static void MustBeInstanceOfType(this object obj, Type type, string message = null)
			=> Assert.IsInstanceOfType(obj, type, message);
		[DebuggerHidden]
		public static void MustBeInstanceOfType<T>(this object obj, string message = null)
			=> Assert.IsInstanceOfType<T>(obj, message);
		[DebuggerHidden]
		public static void MustNotBeInstanceOfType(this object obj, Type type, string message = null)
			=> Assert.IsNotInstanceOfType(obj, type, message);
		[DebuggerHidden]
		public static void MustNotBeInstanceOfType<T>(this object obj, string message = null)
			=> Assert.IsNotInstanceOfType<T>(obj, message);
		[DebuggerHidden]
		public static void MustThrowException(this Action action, string message = null)
			=> Assert.ThrowsException(action, message);
		[DebuggerHidden]
		public static async Task MustThrowExceptionAsync(this Func<Task> action, string message = null)
			=> await Assert.ThrowsExceptionAsync(action, message);
		[DebuggerHidden]
		public static void MustThrowException<TException>(this Action action, string message = null)
			where TException : Exception
			=> Assert.ThrowsException<TException>(action, message);
		[DebuggerHidden]
		public static async Task MustThrowExceptionAsync<TException>(this Func<Task> action, string message)
			where TException : Exception
			=> await Assert.ThrowsExceptionAsync<TException>(action, message);
	}
}