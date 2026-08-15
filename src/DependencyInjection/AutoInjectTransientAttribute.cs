using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Marks an implementation for automatic transient registration.
/// The service contract can be supplied to the constructor or inferred during scanning.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class AutoInjectTransientAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Gets or sets the service contract used for the transient registration.
	/// When it is <see langword="null"/>, the contract is inferred from the implementation type and its interfaces.
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }

	/// <summary>
	/// Initializes a transient registration attribute with an optional explicit service contract.
	/// Passing <see langword="null"/> enables service-type inference during assembly scanning.
	/// </summary>
	/// <param name="serviceType">The service contract to register, or <see langword="null"/> to infer it.</param>
	public AutoInjectTransientAttribute(Type? serviceType)
	{
		Lifetime = ServiceLifetime.Transient;
		ServiceType = serviceType;
	}
	/// <summary>
	/// Initializes a transient registration attribute that infers its service contract during assembly scanning.
	/// The container creates a new implementation whenever the service is requested.
	/// </summary>
	public AutoInjectTransientAttribute() : this(null)
	{
	}
}
/// <summary>
/// Marks an implementation for automatic transient registration under <typeparamref name="TService"/>.
/// The generic argument supplies the service contract without a <see cref="Type"/> constructor argument.
/// </summary>
/// <typeparam name="TService">The service contract implemented by the decorated class.</typeparam>
[ExcludeFromCodeCoverage]
public class AutoInjectTransientAttribute<TService>() : AutoInjectTransientAttribute(typeof(TService));
