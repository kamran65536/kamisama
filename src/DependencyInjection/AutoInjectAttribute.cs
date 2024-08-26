namespace KamiSama.Extensions.DependencyInjection;

/// <summary>
/// Inject Attribute tries to bind the current class as implementation to a service
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class AutoInjectAttribute : AutoInjectAttributeBase
{
	/// <summary>
	/// Service Type
	/// </summary>
	public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }
	/// <summary>
	/// Service Lifetime (default is Transient)
	/// </summary>
	public new ServiceLifetime Lifetime { get => base.Lifetime; set => base.Lifetime = value; }
}
