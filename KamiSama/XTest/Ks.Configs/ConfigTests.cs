using System.Diagnostics.CodeAnalysis;
using KamiSama.Configs;
using Xunit;


namespace XTest.Ks.Configs
{
	[Trait("Category", "KS.Configs")]
	[ExcludeFromCodeCoverage]
	public class ConfigTests
	{
		[Fact(DisplayName = "InMemory Provider")]
		public void TestInMemory()
		{
			var tmp = new SampleSettings
			{
				X = 11,
				Y = 10
			};

			Assert.False(object.ReferenceEquals(tmp, SampleSettings.Instance));

			SampleSettings.Instance.UseInMemoryPrvider(tmp);
			Assert.True(object.ReferenceEquals(tmp, SampleSettings.Instance));

			tmp.X = 12;
			tmp.Y = 13;

			SampleSettings.Save();
			SampleSettings.Load();

			Assert.Equal(12, SampleSettings.Instance.X);
			Assert.Equal(13, SampleSettings.Instance.Y);
		}
	}

}
