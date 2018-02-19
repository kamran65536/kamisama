using KamiSama.Configs;

namespace ConsoleTest
{
	public class SampleSettings : ConfigData<SampleSettings>
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
