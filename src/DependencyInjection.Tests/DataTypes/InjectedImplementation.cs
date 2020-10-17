using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes
{
	[Inject(lifetime: ServiceLifetime.Singleton)]
	class InjectedImplementation : SampleInteface
	{
		public int X { get; set; }
	}
}
