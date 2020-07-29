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
		/// <param name="transient"></param>
		public Singleton(ITransient<T> transient)
		{
			this.Value = transient.Value;
		}
	}
}
