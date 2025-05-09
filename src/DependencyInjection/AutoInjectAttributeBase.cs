using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Base class for auto-inject attributes
/// </summary>
public abstract class AutoInjectAttributeBase : Attribute
{
	/// <summary>
	/// if present, adds the service as keyed and you should use it by <see cref="ServiceProviderKeyedServiceExtensions.GetKeyedServices" /> methods
	/// </summary>
	public object? ServiceKey { get; set; }
	/// <summary>
	/// Service Type, it null the 
	/// </summary>
	protected Type? ServiceType { get; set; }
	/// <summary>
	/// Service Lifetime (default is Transient)
	/// </summary>
	protected ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
	/// <summary>
	/// Gets or sets a value indicating whether multiple instances of the associated attribute are allowed.
	/// </summary>
	public bool AllowMultiple { get; set; } = false;

	/// <summary>
	/// Add binding to the service
	/// </summary>
	/// <param name="services"></param>
	/// <param name="type"></param>
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
