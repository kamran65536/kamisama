using System;
using System.Collections.Generic;

namespace KamiSama.Extensions.DependencyInjection
{
	public class NamedFactory
	{
		private Dictionary<string, Type> namedTypes = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);

		public Type ServiceType { get; }

		public NamedFactory(Type serviceType)
		{
			this.ServiceType = serviceType;
		}

		public void Register(string name, Type type)
			=> namedTypes[name] = type;
		public void Register<_ImplementationType>(string name)
			=> Register(name, typeof(_ImplementationType));

		public object GetByName(IServiceProvider serviceProvider, string name)
		{
			if (!namedTypes.TryGetValue(name, out Type type))
				throw new Exception($"Cannot find named instance for name:{name}, service type: {ServiceType}");

			return serviceProvider.GetService(type);
		}
	}
	public class NamedFactory<_Service> : NamedFactory
	{
		public NamedFactory() : base(typeof(_Service))
		{
		}
	}
}
