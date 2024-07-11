namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// AutoInject Transient Attribute
/// </summary>
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
