namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Transient value
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ITransient<T>
	{
		/// <summary>
		/// inner value for transient
		/// </summary>
		T Value { get; }
	}
}
