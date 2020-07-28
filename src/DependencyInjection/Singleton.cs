using System;
using System.Collections.Generic;
using System.Text;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Singleton Object for dependency injection
	/// </summary>
	/// <typeparam name="T">Type of object</typeparam>
	public class Singleton<T> : ISingleton<T>
	{
		/// <summary>
		/// inner value of the singleton object
		/// </summary>
		public T Value { get; }
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="value"></param>
		public Singleton(T value)
		{
			this.Value = value;
		}
	}
}
