using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Service Provider Extensions for named service
	/// </summary>
	public static class ServiceProviderExtensions
	{
		/// <summary>
		/// Returns an service named instance of service
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <param name="serviceType">the service type</param>
		/// <param name="name">name of the implementation</param>
		/// <returns>instance of implemented type</returns>
		public static object GetService(this IServiceProvider serviceProvider, Type serviceType, string name)
		{
			var factoryType = typeof(NamedFactory<>).MakeGenericType(serviceType);

			var namedFactory = (NamedFactory) serviceProvider.GetService(factoryType);

			return namedFactory.FindByName(serviceProvider, name);
		}
		/// <summary>
		/// Returns an named instance of service
		/// </summary>
		/// <typeparam name="_ServiceType"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <param name="name">name of the implementation</param>
		/// <returns>instance of implemented type</returns>
		[ExcludeFromCodeCoverage]
		public static _ServiceType GetService<_ServiceType>(this IServiceProvider serviceProvider, string name)
			=> (_ServiceType) serviceProvider.GetService(typeof(_ServiceType), name);
	}
}
