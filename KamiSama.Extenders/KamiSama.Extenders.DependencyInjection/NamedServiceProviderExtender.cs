using System;

namespace KamiSama.Extenders.DependencyInjection
{
	public static class NamedServiceProviderExtender
	{
		public static object GetService(this IServiceProvider serviceProvider, Type serviceType, string name)
		{
			var factoryType = typeof(NamedFactory<>).MakeGenericType(serviceType);

			var namedFactory = (NamedFactory) serviceProvider.GetService(factoryType);

			return namedFactory.GetByName(serviceProvider, name);
		}
		public static _ServiceType GetService<_ServiceType>(this IServiceProvider serviceProvider, string name)
			=> (_ServiceType) serviceProvider.GetService(typeof(_ServiceType), name);
	}
}
