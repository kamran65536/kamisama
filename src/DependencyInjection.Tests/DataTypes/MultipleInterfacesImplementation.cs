namespace KamiSama.Extensions.DependencyInjection.Tests.DataTypes
{
	class MultipleInterfacesImplementation : SampleInteface, SampleInterface2
	{
		public int Y { get; set; }
		public int X { get; set; }
	}
}
