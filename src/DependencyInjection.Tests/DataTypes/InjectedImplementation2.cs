namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes;

[AutoInjectSingleton<ISampleInterface2>]
class InjectedImplementation2 : ISampleInterface2
{
	public int X { get; set; }
	public int Y { get; set; }
}
