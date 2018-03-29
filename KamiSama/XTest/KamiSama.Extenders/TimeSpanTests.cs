using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Xunit;
using Xunit.Categories;

namespace XTest.KamiSama.Extenders
{
	[Category("KS.Ex.TimeSpan")]
	[ExcludeFromCodeCoverage]
	public class TimeSpanTests
	{
		[Fact(DisplayName = "Miliseconds")]
		public void MillisecondsTest()
			=> Assert.Equal(13.Milliseconds(), TimeSpan.FromMilliseconds(13));
		[Fact(DisplayName = "Seconds")]
		public void SecondsTest()
			=> Assert.Equal(13.Seconds(), TimeSpan.FromSeconds(13));
		[Fact(DisplayName = "Minutes")]
		public void MinutesTest()
			=> Assert.Equal(13.Minutes(), TimeSpan.FromMinutes(13));
		[Fact(DisplayName = "Hours")]
		public void HoursTest()
			=> Assert.Equal(13.Hours(), TimeSpan.FromHours(13));
		[Fact(DisplayName = "Days")]
		public void DayssTest()
			=> Assert.Equal(13.Days(), TimeSpan.FromDays(13));
	}
}
