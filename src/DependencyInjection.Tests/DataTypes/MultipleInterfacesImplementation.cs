namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes;

class MultipleInterfacesImplementation : ISampleInterface, ISampleInterface2
{
	public int Y { get; set; }
	public int X { get; set; }
}
