using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes
{
	[Inject(lifetime: ServiceLifetime.Singleton)]
	class InjectedImplementation : ISampleInteface
	{
		public int X { get; set; }
	}
}
