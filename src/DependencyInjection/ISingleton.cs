namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Singleton object in dependency injection
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public interface ISingleton<T>
	{
		T Value { get; }
	}
}
