using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Marks an implementation for automatic singleton registration.
/// The service contract can be supplied to the constructor or inferred during scanning.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class AutoInjectSingletonAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Gets or sets the service contract used for the singleton registration.
	/// When it is <see langword="null"/>, the contract is inferred from the implementation type and its interfaces.
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }

	/// <summary>
	/// Initializes a singleton registration attribute with an optional explicit service contract.
	/// Passing <see langword="null"/> enables service-type inference during assembly scanning.
	/// </summary>
	/// <param name="serviceType">The service contract to register, or <see langword="null"/> to infer it.</param>
	public AutoInjectSingletonAttribute(Type? serviceType)
	{
		Lifetime = ServiceLifetime.Singleton;
		ServiceType = serviceType;
	}
	/// <summary>
	/// Initializes a singleton registration attribute that infers its service contract during assembly scanning.
	/// The decorated implementation is shared by the dependency injection container.
	/// </summary>
	public AutoInjectSingletonAttribute() : this(null)
	{
	}
}
/// <summary>
/// Marks an implementation for automatic singleton registration under <typeparamref name="TService"/>.
/// The generic argument supplies the service contract without a <see cref="Type"/> constructor argument.
/// </summary>
/// <typeparam name="TService">The service contract implemented by the decorated class.</typeparam>
[ExcludeFromCodeCoverage]
public class AutoInjectSingletonAttribute<TService>() : AutoInjectSingletonAttribute(typeof(TService));
