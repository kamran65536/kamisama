namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class TimeSpanTests
{
	[TestMethod]
	public void MillisecondsTest()
		=> Assert.AreEqual(13.Milliseconds(), TimeSpan.FromMilliseconds(13));
	[TestMethod]
	public void SecondsTest()
		=> Assert.AreEqual(13.Seconds(), TimeSpan.FromSeconds(13));
	[TestMethod]
	public void MinutesTest()
		=> Assert.AreEqual(13.Minutes(), TimeSpan.FromMinutes(13));
	[TestMethod]
	public void HoursTest()
		=> Assert.AreEqual(13.Hours(), TimeSpan.FromHours(13));
	[TestMethod]
	public void DayssTest()
		=> Assert.AreEqual(13.Days(), TimeSpan.FromDays(13));
}
