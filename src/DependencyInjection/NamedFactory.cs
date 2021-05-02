using System;
using System.Collections.Generic;

namespace KamiSama.Extensions.DependencyInjection
{
	/// <summary>
	/// Named Factory used for named service registration inside the Microsoft.DependencyInjection library.
	/// </summary>
	public class NamedFactory
	{
		/// <summary>
		/// internal map for type  mapping
		/// </summary>
		internal Dictionary<string, Type> namedTypes = new(StringComparer.InvariantCultureIgnoreCase);
		/// <summary>
		/// returns the service type (you are looking for implementation)
		/// </summary>
		public Type ServiceType { get; }
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="serviceType">the service type (you are looking for implementation)</param>
		public NamedFactory(Type serviceType)
		{
			this.ServiceType = serviceType;
		}
		/// <summary>
		/// Registers the implementation type with specified name inside the factory
		/// </summary>
		/// <param name="name">name of the implementation</param>
		/// <param name="type">type implementation type</param>
		public void Register(string name, Type type)
			=> namedTypes[name] = type;
		/// <summary>
		/// Registers the implementation type with specified name inside the factory
		/// </summary>
		/// /// <param name="name">name of the implementation</param>
		/// <typeparam name="_ImplementationType">type implementation type</typeparam>
		public void Register<_ImplementationType>(string name)
			=> Register(name, typeof(_ImplementationType));
		/// <summary>
		/// Finds a imeplemntation type and returns an instance using service provider
		/// </summary>
		/// <param name="serviceProvider">service provider</param>
		/// <param name="name">name of the implementation</param>
		/// <returns>instance of implementation</returns>
		public object FindByName(IServiceProvider serviceProvider, string name)
		{
			if (!namedTypes.TryGetValue(name, out Type type))
				throw new Exception($"Cannot find named instance for name:{name}, service type: {ServiceType}");

			return serviceProvider.GetService(type);
		}
	}
	/// <summary>
	/// Generic type for NamedFactory
	/// </summary>
	/// <typeparam name="TService">the type of service</typeparam>
	public class NamedFactory<TService> : NamedFactory
	{
		/// <summary>
		/// constructor
		/// </summary>
		public NamedFactory() : base(typeof(TService))
		{
		}
	}
}
