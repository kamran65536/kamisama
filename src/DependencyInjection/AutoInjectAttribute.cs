using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Reflection;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Inject Attribute tries to bind the current class as implementation to a service
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public class AutoInjectAttribute : Attribute
	{
		/// <summary>
		/// Service Type
		/// </summary>
		public Type ServiceType { get; set; }
		/// <summary>
		/// Service Lifetime (default is Transient)
		/// </summary>
		public ServiceLifetime Lifetime { get; set; }
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="serviceType">if null, the default interface will be used</param>
		/// <param name="lifetime">service lifetime, default is Transient</param>
		public AutoInjectAttribute(Type serviceType = null, ServiceLifetime lifetime = ServiceLifetime.Transient)
		{
			this.Lifetime = lifetime;
			this.ServiceType = serviceType;
		}
		/// <summary>
		/// Add binding to the service
		/// </summary>
		/// <param name="services"></param>
		/// <param name="type"></param>
		public void TryAddInjection(IServiceCollection services, Type type)
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

			switch (Lifetime)
			{
				case ServiceLifetime.Singleton:
					services.TryAddSingleton(serviceType, type);
					break;
				case ServiceLifetime.Scoped:
					services.TryAddScoped(serviceType, type);
					break;
				default:
				case ServiceLifetime.Transient:
					services.TryAddTransient(serviceType, type);
					break;
			}
		}
	}
}
