namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Scoped Object for dependency injection
	/// </summary>
	/// <typeparam name="T">Type of object</typeparam>
	public class Scoped<T> : IScoped<T>
	{
		/// <summary>
		/// inner value of the scoped object
		/// </summary>
		public T Value { get; }
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="transient"></param>
		public Scoped(ITransient<T> transient)
		{
			this.Value = transient.Value;
		}
	}
}
