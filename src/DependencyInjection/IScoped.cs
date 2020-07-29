namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Scoped Object in the dependency injection
	/// </summary>
	/// <typeparam name="T">inner object value</typeparam>
	public interface IScoped<T>
	{
		/// <summary>
		/// inner value for the scope
		/// </summary>
		T Value { get; }
	}
}
