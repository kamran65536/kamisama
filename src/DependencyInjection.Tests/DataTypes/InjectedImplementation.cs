using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes
{
	[AutoInject(Lifetime = ServiceLifetime.Singleton)]
	class InjectedImplementation : ISampleInteface
	{
		public int X { get; set; }
	}
}
