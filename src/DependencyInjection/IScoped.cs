namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Scoped Object in the dependency injection
	/// </summary>
	/// <typeparam name="T">inner object value</typeparam>
	public interface IScoped<T>
	{
		T Value { get; }
	}
}
