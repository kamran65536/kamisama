using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// AutoInject Scoped Attribute
/// </summary>
public class AutoInjectScopedAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Service Type
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }

	/// <inheritdoc/>
	public AutoInjectScopedAttribute(Type? serviceType)
	{
		Lifetime = ServiceLifetime.Scoped;
		ServiceType = serviceType;
	}
	/// <inheritdoc />
	public AutoInjectScopedAttribute() : this(null)
	{
	}
}
/// <summary>
///  AutoInject Scoped Attribute using generic service type
/// </summary>
[ExcludeFromCodeCoverage]
public class AutoInjectScopedAttribute<TServiceType>() : AutoInjectScopedAttribute(typeof(TServiceType));