namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Singleton object in dependency injection
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public interface ISingleton<T>
	{
		/// <summary>
		/// inner value for the singleton
		/// </summary>
		T Value { get; }
	}
}
