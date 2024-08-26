using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// AutoInject Singleton Attribute
/// </summary>
public class AutoInjectSingletonAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Service Type
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }

	/// <inheritdoc/>
	public AutoInjectSingletonAttribute(Type? serviceType)
	{
		Lifetime = ServiceLifetime.Singleton;
		ServiceType = serviceType;
	}
	/// <inheritdoc />
	public AutoInjectSingletonAttribute() : this(null)
	{
	}
}
/// <summary>
/// AutoInject Singleton Attribute with generic service type
/// </summary>
/// <typeparam name="TService"></typeparam>
[ExcludeFromCodeCoverage]
public class AutoInjectSingletonAttribute<TService>() : AutoInjectSingletonAttribute(typeof(TService));