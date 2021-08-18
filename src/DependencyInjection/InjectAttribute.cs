using Microsoft.Extensions.DependencyInjection;
using System;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Inject Attribute tries to bind the current class as implementation to a service
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	[Obsolete("This attribute is going to be removed in 2.5.+ version as it is similar to asp net core Inject attribute.")]
	public class InjectAttribute : AutoInjectAttribute
	{
		/// <inheritdoc />
		public InjectAttribute(Type serviceType = null, ServiceLifetime lifetime = ServiceLifetime.Transient)
			: base(serviceType, lifetime)
		{
		}
	}
}
