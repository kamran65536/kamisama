using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Service Collection Extension for named implementations
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		#region AddNamed
		/// <summary>
		/// simply add named service into the collection, remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="serviceType">the service type</param>
		/// <param name="implementationType">the implementation type to be used</param>
		/// <returns></returns>
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddNamed(this IServiceCollection services, string name, Type serviceType, Type implementationType)
		{
			var factoryType = typeof(NamedFactory<>);
			factoryType = factoryType.MakeGenericType(serviceType);
			
			NamedFactory? factory = null;
			var serviceDescriptor = services.FirstOrDefault(x => x.ServiceType == factoryType);

			if (serviceDescriptor == null)
			{
				factory = (NamedFactory)Activator.CreateInstance(factoryType)!;

				services.AddSingleton(factoryType, factory);
			}
			else
				factory = (NamedFactory)serviceDescriptor.ImplementationInstance!;

			factory.Register(name, implementationType);

			return services;
		}
		/// <summary>
		/// simply add named service into the collection, remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationType">the implementation type to be used</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddNamed<TService>(this IServiceCollection services, string name, Type implementationType)
			=> services.AddNamed(name, typeof(TService), implementationType);
		/// <summary>
		/// simply add named service into the collection, remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection services, string name)
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation));
		#endregion
		#region AddTransient
		/// <summary>
		/// Adds named transient implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationType">the implementation type to be used</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddTransient<TService>(this IServiceCollection services, string name, Type implementationType)
			=>	services.AddNamed<TService>(name, implementationType).AddTransient(implementationType);
		/// <summary>
		/// Adds named transient implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <param name="serviceType">type of service</param>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationType">the implementation type to be used</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddTransient(this IServiceCollection services, string name, Type serviceType, Type implementationType)
			=>	services.AddNamed(name, serviceType, implementationType).AddTransient(serviceType, implementationType);
		/// <summary>
		/// Adds named transient implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <param name="serviceType">type of service</param>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationFactory">adds an item using implementation factory</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddTransient<TImplementation>(this IServiceCollection services, string name, Type serviceType, Func<IServiceProvider, TImplementation> implementationFactory) where TImplementation : class
			=> services.AddNamed(name, serviceType, typeof(TImplementation)).AddTransient(implementationFactory);
		/// <summary>
		/// Adds named transient implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, string name) where TImplementation : class
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddTransient<TImplementation>();
		/// <summary>
		/// Adds named transient implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationFactory">adds an item using implementation factory</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory) where TImplementation : class
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddTransient(implementationFactory);
		#endregion
		#region AddScoped
		/// <summary>
		/// Adds named scoped implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <param name="implementationType">the implementation type to be used</param>
		/// <param name="serviceType">the service type</param>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddScoped(this IServiceCollection services, string name, Type serviceType, Type implementationType)
			=> services.AddNamed(name, serviceType, implementationType).AddScoped(implementationType);
		/// <summary>
		/// Adds named scoped implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, string name)
			where TService : class
			where TImplementation : class, TService
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddScoped<TImplementation>();
		/// <summary>
		/// Adds named scoped implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationFactory">factory for the named implementation instance</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory)
			where TService : class
			where TImplementation : class, TService
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddScoped<TImplementation>(implementationFactory);
		#endregion
		#region AddSingleton
		/// <summary>
		/// Adds named singleton implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <param name="implementationType">the implementation type to be used</param>
		/// <param name="serviceType">the service type</param>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddSingleton(this IServiceCollection services, string name, Type serviceType, Type implementationType)
			=> services.AddNamed(name, serviceType, implementationType).AddSingleton(implementationType);
		/// <summary>
		/// Adds named singleton implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, string name)
			where TService : class
			where TImplementation : class, TService
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddSingleton<TImplementation>();
		/// <summary>
		/// Adds named singleton implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationFactory">factory for the named implementation instance</param>
		/// <returns></returns>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory)
			where TService : class
			where TImplementation : class, TService
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddSingleton(implementationFactory);
		/// <summary>
		/// Adds named singleton implementation for service type into the collection, 
		/// remember that you must add the implementation service separately. 
		/// You can use AddSingleton, AddTransient and AddScoped too.
		/// </summary>
		/// <typeparam name="TService">type of service</typeparam>
		/// <typeparam name="TImplementation">the implementation type to be used</typeparam>
		/// <param name="services">the service collection</param>
		/// <param name="name">name of the implementation</param>
		/// <param name="implementationInstance">implementation instance</param>
		[ExcludeFromCodeCoverage]
		[Obsolete("This method is obsolete as .net 8 has added AddKeyed methods")]
		public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, string name, TImplementation implementationInstance)
			where TService : class
			where TImplementation : class, TService
			=> services.AddNamed(name, typeof(TService), typeof(TImplementation)).AddSingleton(implementationInstance);
		#endregion
		#region Automatic Dependency Injection
		/// <summary>
		/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
		/// </summary>
		/// <param name="services"></param>
		/// <param name="assemblies">list of assemblies to search, null means all assemblies</param>
		/// <returns></returns>
		public static IServiceCollection AutoAddDependencies(this IServiceCollection services, params Assembly[]? assemblies)
		{
			if ((assemblies == null) || (assemblies.Length == 0))
				assemblies = AppDomain.CurrentDomain.GetAssemblies();

			var types = assemblies
				.SelectMany(x => x.DefinedTypes)
				.ToArray();

			foreach (var type in types)
			{
				var attr = type.GetCustomAttribute<AutoInjectAttribute>();

				if (attr == null)
					continue;

				attr.TryAddInjection(services, type);
			}

			return services;
		}
		/// <summary>
		/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
		/// </summary>
		/// <returns></returns>
		public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType>(this IServiceCollection services) 
			=> services.AutoAddDependencies(typeof(TAssemblyType).Assembly);
		/// <summary>
		/// Automatically adds dependency injections using <see cref="AutoInjectAttribute"/>
		/// </summary>
		/// <returns></returns>
		public static IServiceCollection AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services)
			=> services.AutoAddDependencies(typeof(TAssemblyType1).Assembly, typeof(TAssemblyType2).Assembly);
		#endregion
	}
}