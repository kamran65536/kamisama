namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes;

[AutoInject(Lifetime = ServiceLifetime.Singleton)]
class InjectedImplementation : ISampleInterface
{
	public int X { get; set; }
}
