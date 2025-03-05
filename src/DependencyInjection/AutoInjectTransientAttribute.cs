using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// AutoInject Transient Attribute
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class AutoInjectTransientAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Service Type
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }

	/// <inheritdoc/>
	public AutoInjectTransientAttribute(Type? serviceType)
	{
		Lifetime = ServiceLifetime.Transient;
		ServiceType = serviceType;
	}
	/// <inheritdoc />
	public AutoInjectTransientAttribute() : this(null)
	{
	}
}
/// <summary>
/// AutoInject Transient Attribute with generic service type
/// </summary>
[ExcludeFromCodeCoverage]
public class AutoInjectTransientAttribute<TService>() : AutoInjectTransientAttribute(typeof(TService));