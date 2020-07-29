namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Transient Object for dependency injection
	/// </summary>
	/// <typeparam name="T">Type of object</typeparam>
	public class Transient<T> : ITransient<T>
	{
		/// <summary>
		/// inner value of the Transient object
		/// </summary>
		public T Value { get; }
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="value"></param>
		public Transient(T value)
		{
			this.Value = value;
		}
	}
}
