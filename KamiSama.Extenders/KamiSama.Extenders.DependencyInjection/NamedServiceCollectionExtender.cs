using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KamiSama.Extenders.DependencyInjection
{
	public static class NamedServiceCollectionExtender
	{
		#region AddNamed
		public static IServiceCollection AddNamed(this IServiceCollection services, string name, Type serviceType, Type implementationType)
		{
			var factoryType = typeof(NamedFactory<>);
			factoryType = factoryType.MakeGenericType(serviceType);

			NamedFactory factory = null;
			var serviceDescriptor = services.FirstOrDefault(x => x.ServiceType == factoryType);

			if (serviceDescriptor == null)
			{
				factory = (NamedFactory)Activator.CreateInstance(factoryType);
				services.AddSingleton(factoryType, factory);
			}
			else
				factory = (NamedFactory)serviceDescriptor.ImplementationInstance;

			factory.Register(name, implementationType);

			return services;
		}
		public static IServiceCollection AddNamed<_ServiceType>(this IServiceCollection services, string name, Type implementationType)
			=> services.AddNamed(name, typeof(_ServiceType), implementationType);
		public static IServiceCollection AddNamed<_ServiceType, _ImplementationType>(this IServiceCollection services, string name)
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)); 
		#endregion
		#region AddScoped
		public static IServiceCollection AddScoped(this IServiceCollection services, string name, Type serviceType, Type implementationType)
			=> services.AddNamed(name, serviceType, implementationType).AddScoped(implementationType);
		public static IServiceCollection AddScoped<_ServiceType, _ImplementationType>(this IServiceCollection services, string name)
			where _ServiceType : class
			where _ImplementationType : class, _ServiceType
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)).AddScoped<_ImplementationType>();
		public static IServiceCollection AddScoped<_ServiceType, _ImplementationType>(this IServiceCollection services, string name, Func<IServiceProvider, _ImplementationType> implementationFactory)
			where _ServiceType : class
			where _ImplementationType : class, _ServiceType
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)).AddScoped<_ImplementationType>(implementationFactory);
		#endregion
		#region AddSingleton
		public static IServiceCollection AddSingleton(this IServiceCollection services, string name, Type serviceType, Type implementationType)
			=> services.AddNamed(name, serviceType, implementationType).AddSingleton(implementationType);
		public static IServiceCollection AddSingleton<_ServiceType, _ImplementationType>(this IServiceCollection services, string name)
			where _ServiceType : class
			where _ImplementationType : class, _ServiceType
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)).AddSingleton<_ImplementationType>();
		public static IServiceCollection AddSingleton<_ServiceType, _ImplementationType>(this IServiceCollection services, string name, Func<IServiceProvider, _ImplementationType> implementationFactory)
			where _ServiceType : class
			where _ImplementationType : class, _ServiceType
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)).AddSingleton(implementationFactory);
		public static IServiceCollection AddSingleton<_ServiceType, _ImplementationType>(this IServiceCollection services, string name, _ImplementationType implementationInstance)
			where _ServiceType : class
			where _ImplementationType : class, _ServiceType
			=> services.AddNamed(name, typeof(_ServiceType), typeof(_ImplementationType)).AddSingleton(implementationInstance); 
		#endregion
	}
}