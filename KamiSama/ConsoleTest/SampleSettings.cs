using System;
using KamiSama.Configs;

namespace ConsoleTest
{
	[Serializable]
	public class SampleSettings : ConfigData<SampleSettings>
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
