using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Defines the registration settings and application behavior shared by automatic injection attributes.
/// Derived attributes select a service contract, lifetime, optional key, and duplicate-registration policy.
/// </summary>
public abstract class AutoInjectAttributeBase : Attribute
{
	/// <summary>
	/// Gets or sets the key used to create a keyed service registration.
	/// A <see langword="null"/> value creates an ordinary unkeyed registration.
	/// </summary>
	public object? ServiceKey { get; set; }
	/// <summary>
	/// Gets or sets the service contract used for registration by a derived attribute.
	/// When it is <see langword="null"/>, the contract is inferred from the implementation type and its interfaces.
	/// </summary>
	protected Type? ServiceType { get; set; }
	/// <summary>
	/// Gets or sets the lifetime used by the generated service registration.
	/// The default lifetime is <see cref="ServiceLifetime.Transient"/>.
	/// </summary>
	protected ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
	/// <summary>
	/// Gets or sets whether the registration is always appended instead of added only when the service contract and key are absent.
	/// Set it to <see langword="true"/> when multiple implementations of the same service must be resolvable.
	/// </summary>
	public bool AllowMultiple { get; set; } = false;

	/// <summary>
	/// Registers the implementation using the configured service type, lifetime, key, and multiple-registration policy.
	/// If no service type is configured, the method uses the implementation itself, its sole interface, or throws when multiple interfaces make inference ambiguous.
	/// </summary>
	/// <param name="services">The service collection that receives the generated registration.</param>
	/// <param name="type">The attributed implementation type to register.</param>
	public virtual void ApplyInjection(IServiceCollection services, Type type)
	{
		var serviceType = ServiceType;

		if (serviceType == null)
		{
			var interfaces = type.GetInterfaces();

			serviceType = interfaces.Length switch
			{
				0 => type,
				1 => interfaces[0],
				_ => throw new InvalidOperationException($"There are more than one interface to bind for type {type.Name}.")
			};
		}

		if (ServiceKey == null) {
			switch (Lifetime)
			{
				case ServiceLifetime.Singleton:
					if (AllowMultiple)
						services.AddSingleton(serviceType, type);
					else
						services.TryAddSingleton(serviceType, type);
					break;
				case ServiceLifetime.Scoped:
					if (AllowMultiple)
						services.AddScoped(serviceType, type); 
					else
						services.TryAddScoped(serviceType, type);
					break;
				default:
				case ServiceLifetime.Transient:
					if (AllowMultiple)
						services.AddTransient(serviceType, type);
					else
						services.TryAddTransient(serviceType, type);
					break;
			}
		} else
		{
			switch (Lifetime)
			{
				case ServiceLifetime.Singleton:
					if (AllowMultiple)
						services.AddKeyedSingleton(serviceType, ServiceKey, type);
					else
						services.TryAddKeyedSingleton(serviceType, ServiceKey, type);
					break;
				case ServiceLifetime.Scoped:
					if (AllowMultiple)
						services.AddKeyedScoped(serviceType, ServiceKey, type);
					else
						services.TryAddKeyedScoped(serviceType, ServiceKey, type);
					break;
				default:
				case ServiceLifetime.Transient:
					if (AllowMultiple)
						services.AddKeyedTransient(serviceType, ServiceKey, type);
					else
						services.TryAddKeyedTransient(serviceType, ServiceKey, type);
					break;
			}
		}
	}
}
