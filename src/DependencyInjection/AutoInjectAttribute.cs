namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Marks an implementation for automatic dependency injection registration with a configurable service type and lifetime.
/// The assembly scanner applies this attribute when it discovers the decorated class.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class AutoInjectAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Gets or sets the service contract used for registration.
	/// When it is <see langword="null"/>, the contract is inferred from the implementation type and its interfaces.
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }
	/// <summary>
	/// Gets or sets the lifetime of the generated service registration.
	/// The default lifetime is <see cref="ServiceLifetime.Transient"/>.
	/// </summary>
	public new ServiceLifetime Lifetime { get => base.Lifetime; set => base.Lifetime = value; }
}
