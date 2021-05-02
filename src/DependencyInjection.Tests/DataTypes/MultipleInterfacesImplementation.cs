namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes
{
	class MultipleInterfacesImplementation : ISampleInteface, ISampleInterface2
	{
		public int Y { get; set; }
		public int X { get; set; }
	}
}
